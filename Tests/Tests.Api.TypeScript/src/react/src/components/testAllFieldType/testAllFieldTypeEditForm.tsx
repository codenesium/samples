import React, { Component, FormEvent } from 'react';
import axios, { AxiosError, AxiosResponse } from 'axios';
import { ActionResponse, CreateResponse } from '../../api/apiObjects';
import { Constants, ApiRoutes, ClientRoutes } from '../../constants';
import * as Api from '../../api/models';
import TestAllFieldTypeMapper from './testAllFieldTypeMapper';
import TestAllFieldTypeViewModel from './testAllFieldTypeViewModel';
import {
  Form,
  Input,
  Button,
  Switch,
  InputNumber,
  DatePicker,
  Spin,
  Alert,
  TimePicker,
} from 'antd';
import { WrappedFormUtils } from 'antd/es/form/Form';
import * as GlobalUtilities from '../../lib/globalUtilities';
interface TestAllFieldTypeEditComponentProps {
  form: WrappedFormUtils;
  history: any;
  match: any;
}

interface TestAllFieldTypeEditComponentState {
  model?: TestAllFieldTypeViewModel;
  loading: boolean;
  loaded: boolean;
  errorOccurred: boolean;
  errorMessage: string;
  submitted: boolean;
  submitting: boolean;
}

class TestAllFieldTypeEditComponent extends React.Component<
  TestAllFieldTypeEditComponentProps,
  TestAllFieldTypeEditComponentState
> {
  state = {
    model: new TestAllFieldTypeViewModel(),
    loading: false,
    loaded: true,
    errorOccurred: false,
    errorMessage: '',
    submitted: false,
    submitting: false,
  };

  componentDidMount() {
    this.setState({ ...this.state, loading: true });

    axios
      .get<Api.TestAllFieldTypeClientResponseModel>(
        Constants.ApiEndpoint +
          ApiRoutes.TestAllFieldTypes +
          '/' +
          this.props.match.params.id,
        {
          headers: GlobalUtilities.defaultHeaders(),
        }
      )
      .then(response => {
        GlobalUtilities.logInfo(response);

        let mapper = new TestAllFieldTypeMapper();

        this.setState({
          model: mapper.mapApiResponseToViewModel(response.data),
          loading: false,
          loaded: true,
          errorOccurred: false,
          errorMessage: '',
        });

        this.props.form.setFieldsValue(
          mapper.mapApiResponseToViewModel(response.data)
        );
      })
      .catch((error: AxiosError) => {
        GlobalUtilities.logError(error);

        if (error.response && error.response.status == 422) {
          this.setState({
            ...this.state,
            submitted: true,
            submitting: false,
            errorOccurred: false,
            errorMessage: '',
          });
        } else {
          this.setState({
            ...this.state,
            submitted: true,
            submitting: false,
            errorOccurred: true,
            errorMessage: 'Error Occurred',
          });
        }
      });
  }

  handleSubmit = (e: FormEvent<HTMLFormElement>) => {
    e.preventDefault();
    this.setState({ ...this.state, submitting: true, submitted: false });
    this.props.form.validateFields((err: any, values: any) => {
      if (!err) {
        let model = values as TestAllFieldTypeViewModel;
        this.submit(model);
      } else {
        this.setState({ ...this.state, submitting: false, submitted: false });
      }
    });
  };

  submit = (model: TestAllFieldTypeViewModel) => {
    let mapper = new TestAllFieldTypeMapper();
    axios
      .put<CreateResponse<Api.TestAllFieldTypeClientRequestModel>>(
        Constants.ApiEndpoint +
          ApiRoutes.TestAllFieldTypes +
          '/' +
          this.state.model!.id,
        mapper.mapViewModelToApiRequest(model),
        {
          headers: GlobalUtilities.defaultHeaders(),
        }
      )
      .then(response => {
        GlobalUtilities.logInfo(response);
        this.setState({
          ...this.state,
          submitted: true,
          submitting: false,
          model: mapper.mapApiResponseToViewModel(response.data.record!),
          errorOccurred: false,
          errorMessage: '',
        });
      })
      .catch((error: AxiosError) => {
        GlobalUtilities.logError(error);

        if (error.response && error.response.status == 422) {
          let errorResponse = error.response.data as ActionResponse;
          errorResponse.validationErrors.forEach(x => {
            this.props.form.setFields({
              [GlobalUtilities.toLowerCaseFirstLetter(x.propertyName)]: {
                value: this.props.form.getFieldValue(
                  GlobalUtilities.toLowerCaseFirstLetter(x.propertyName)
                ),
                errors: [new Error(x.errorMessage)],
              },
            });
          });
          this.setState({
            ...this.state,
            submitted: true,
            submitting: false,
            errorOccurred: false,
            errorMessage: '',
          });
        } else {
          this.setState({
            ...this.state,
            submitted: true,
            submitting: false,
            errorOccurred: true,
            errorMessage: 'Error Occurred',
          });
        }
      });
  };

  render() {
    const {
      getFieldDecorator,
      getFieldsError,
      getFieldError,
      isFieldTouched,
    } = this.props.form;

    let message: JSX.Element = <div />;
    if (this.state.submitted) {
      if (this.state.errorOccurred) {
        message = <Alert message={this.state.errorMessage} type="error" />;
      } else {
        message = <Alert message="Submitted" type="success" />;
      }
    }

    if (this.state.loading) {
      return <Spin size="large" />;
    } else if (this.state.loaded) {
      return (
        <Form onSubmit={this.handleSubmit}>
          <Form.Item>
            <label htmlFor="fieldBigInt">Field Big Int (required)</label>
            <br />
            {getFieldDecorator('fieldBigInt', {
              rules: [{ required: true, message: 'Required' }],
            })(<InputNumber placeholder={'Field Big Int'} />)}
          </Form.Item>

          <Form.Item>
            <label htmlFor="fieldBinary">Field Binary (required)</label>
            <br />
            {getFieldDecorator('fieldBinary', {
              rules: [
                { required: true, message: 'Required' },
                { max: 50, message: 'Exceeds max length of 50' },
              ],
            })(<Input placeholder={'Field Binary'} />)}
          </Form.Item>

          <Form.Item>
            <label htmlFor="fieldBit">Field Bit (required)</label>
            <br />
            {getFieldDecorator('fieldBit', {
              rules: [],
              valuePropName: 'checked',
            })(<Switch />)}
          </Form.Item>

          <Form.Item>
            <label htmlFor="fieldChar">Field Char (required)</label>
            <br />
            {getFieldDecorator('fieldChar', {
              rules: [
                { required: true, message: 'Required' },
                { max: 10, message: 'Exceeds max length of 10' },
              ],
            })(<Input placeholder={'Field Char'} />)}
          </Form.Item>

          <Form.Item>
            <label htmlFor="fieldDate">Field Date (required)</label>
            <br />
            {getFieldDecorator('fieldDate', {
              rules: [{ required: true, message: 'Required' }],
            })(<DatePicker format={'YYYY-MM-DD'} placeholder={'Field Date'} />)}
          </Form.Item>

          <Form.Item>
            <label htmlFor="fieldDateTime">Field Date Time (required)</label>
            <br />
            {getFieldDecorator('fieldDateTime', {
              rules: [{ required: true, message: 'Required' }],
            })(
              <DatePicker
                format={'YYYY-MM-DD'}
                placeholder={'Field Date Time'}
              />
            )}
          </Form.Item>

          <Form.Item>
            <label htmlFor="fieldDateTime2">Field Date Time2 (required)</label>
            <br />
            {getFieldDecorator('fieldDateTime2', {
              rules: [{ required: true, message: 'Required' }],
            })(
              <DatePicker
                format={'YYYY-MM-DD'}
                placeholder={'Field Date Time2'}
              />
            )}
          </Form.Item>

          <Form.Item>
            <label htmlFor="fieldDateTimeOffset">
              Field Date Time Offset (required)
            </label>
            <br />
            {getFieldDecorator('fieldDateTimeOffset', {
              rules: [{ required: true, message: 'Required' }],
            })(<Input placeholder={'Field Date Time Offset'} />)}
          </Form.Item>

          <Form.Item>
            <label htmlFor="fieldDecimal">Field Decimal (required)</label>
            <br />
            {getFieldDecorator('fieldDecimal', {
              rules: [{ required: true, message: 'Required' }],
            })(<InputNumber placeholder={'Field Decimal'} />)}
          </Form.Item>

          <Form.Item>
            <label htmlFor="fieldFloat">Field Float (required)</label>
            <br />
            {getFieldDecorator('fieldFloat', {
              rules: [{ required: true, message: 'Required' }],
            })(<InputNumber placeholder={'Field Float'} />)}
          </Form.Item>

          <Form.Item>
            <label htmlFor="fieldImage">Field Image (required)</label>
            <br />
            {getFieldDecorator('fieldImage', {
              rules: [{ required: true, message: 'Required' }],
            })(<Input placeholder={'Field Image'} />)}
          </Form.Item>

          <Form.Item>
            <label htmlFor="fieldMoney">Field Money (required)</label>
            <br />
            {getFieldDecorator('fieldMoney', {
              rules: [{ required: true, message: 'Required' }],
            })(<InputNumber placeholder={'Field Money'} />)}
          </Form.Item>

          <Form.Item>
            <label htmlFor="fieldNChar">Field N Char (required)</label>
            <br />
            {getFieldDecorator('fieldNChar', {
              rules: [
                { required: true, message: 'Required' },
                { max: 10, message: 'Exceeds max length of 10' },
              ],
            })(<Input placeholder={'Field N Char'} />)}
          </Form.Item>

          <Form.Item>
            <label htmlFor="fieldNText">Field N Text (required)</label>
            <br />
            {getFieldDecorator('fieldNText', {
              rules: [
                { required: true, message: 'Required' },
                {
                  max: 1073741823,
                  message: 'Exceeds max length of 1073741823',
                },
              ],
            })(<Input.TextArea placeholder={'Field N Text'} />)}
          </Form.Item>

          <Form.Item>
            <label htmlFor="fieldNumeric">Field Numeric (required)</label>
            <br />
            {getFieldDecorator('fieldNumeric', {
              rules: [{ required: true, message: 'Required' }],
            })(<InputNumber placeholder={'Field Numeric'} />)}
          </Form.Item>

          <Form.Item>
            <label htmlFor="fieldNVarchar">Field N Varchar (required)</label>
            <br />
            {getFieldDecorator('fieldNVarchar', {
              rules: [
                { required: true, message: 'Required' },
                { max: 50, message: 'Exceeds max length of 50' },
              ],
            })(<Input placeholder={'Field N Varchar'} />)}
          </Form.Item>

          <Form.Item>
            <label htmlFor="fieldReal">Field Real (required)</label>
            <br />
            {getFieldDecorator('fieldReal', {
              rules: [{ required: true, message: 'Required' }],
            })(<InputNumber placeholder={'Field Real'} />)}
          </Form.Item>

          <Form.Item>
            <label htmlFor="fieldSmallDateTime">
              Field Small Date Time (required)
            </label>
            <br />
            {getFieldDecorator('fieldSmallDateTime', {
              rules: [{ required: true, message: 'Required' }],
            })(
              <DatePicker
                format={'YYYY-MM-DD'}
                placeholder={'Field Small Date Time'}
              />
            )}
          </Form.Item>

          <Form.Item>
            <label htmlFor="fieldSmallInt">Field Small Int (required)</label>
            <br />
            {getFieldDecorator('fieldSmallInt', {
              rules: [{ required: true, message: 'Required' }],
            })(<InputNumber placeholder={'Field Small Int'} />)}
          </Form.Item>

          <Form.Item>
            <label htmlFor="fieldSmallMoney">
              Field Small Money (required)
            </label>
            <br />
            {getFieldDecorator('fieldSmallMoney', {
              rules: [{ required: true, message: 'Required' }],
            })(<InputNumber placeholder={'Field Small Money'} />)}
          </Form.Item>

          <Form.Item>
            <label htmlFor="fieldText">Field Text (required)</label>
            <br />
            {getFieldDecorator('fieldText', {
              rules: [{ required: true, message: 'Required' }],
            })(<Input.TextArea placeholder={'Field Text'} />)}
          </Form.Item>

          <Form.Item>
            <label htmlFor="fieldTime">Field Time (required)</label>
            <br />
            {getFieldDecorator('fieldTime', {
              rules: [{ required: true, message: 'Required' }],
            })(<TimePicker />)}
          </Form.Item>

          <Form.Item>
            <label htmlFor="fieldTimestamp">Field Timestamp (required)</label>
            <br />
            {getFieldDecorator('fieldTimestamp', {
              rules: [{ required: true, message: 'Required' }],
            })(<Input placeholder={'Field Timestamp'} />)}
          </Form.Item>

          <Form.Item>
            <label htmlFor="fieldTinyInt">Field Tiny Int (required)</label>
            <br />
            {getFieldDecorator('fieldTinyInt', {
              rules: [{ required: true, message: 'Required' }],
            })(<InputNumber placeholder={'Field Tiny Int'} />)}
          </Form.Item>

          <Form.Item>
            <label htmlFor="fieldUniqueIdentifier">
              Field Unique Identifier (required)
            </label>
            <br />
            {getFieldDecorator('fieldUniqueIdentifier', {
              rules: [{ required: true, message: 'Required' }],
            })(<Input placeholder={'Field Unique Identifier'} />)}
          </Form.Item>

          <Form.Item>
            <label htmlFor="fieldVarBinary">Field Var Binary (required)</label>
            <br />
            {getFieldDecorator('fieldVarBinary', {
              rules: [
                { required: true, message: 'Required' },
                { max: 50, message: 'Exceeds max length of 50' },
              ],
            })(<Input placeholder={'Field Var Binary'} />)}
          </Form.Item>

          <Form.Item>
            <label htmlFor="fieldVarchar">Field Varchar (required)</label>
            <br />
            {getFieldDecorator('fieldVarchar', {
              rules: [
                { required: true, message: 'Required' },
                { max: 50, message: 'Exceeds max length of 50' },
              ],
            })(<Input placeholder={'Field Varchar'} />)}
          </Form.Item>

          <Form.Item>
            <label htmlFor="fieldXML">Field X M L (required)</label>
            <br />
            {getFieldDecorator('fieldXML', {
              rules: [{ required: true, message: 'Required' }],
            })(<Input.TextArea placeholder={'Field X M L'} />)}
          </Form.Item>

          <Form.Item>
            <Button
              type="primary"
              htmlType="submit"
              loading={this.state.submitting}
            >
              {this.state.submitting ? 'Submitting...' : 'Submit'}
            </Button>
          </Form.Item>
          {message}
        </Form>
      );
    } else {
      return null;
    }
  }
}

export const WrappedTestAllFieldTypeEditComponent = Form.create({
  name: 'TestAllFieldType Edit',
})(TestAllFieldTypeEditComponent);


/*<Codenesium>
    <Hash>7fe0e94f35cad9a7e5ef14bb79efe9a8</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/