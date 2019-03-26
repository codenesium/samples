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

interface TestAllFieldTypeCreateComponentProps {
  form: WrappedFormUtils;
  history: any;
  match: any;
}

interface TestAllFieldTypeCreateComponentState {
  model?: TestAllFieldTypeViewModel;
  loading: boolean;
  loaded: boolean;
  errorOccurred: boolean;
  errorMessage: string;
  submitted: boolean;
  submitting: boolean;
}

class TestAllFieldTypeCreateComponent extends React.Component<
  TestAllFieldTypeCreateComponentProps,
  TestAllFieldTypeCreateComponentState
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
      .post<CreateResponse<Api.TestAllFieldTypeClientRequestModel>>(
        Constants.ApiEndpoint + ApiRoutes.TestAllFieldTypes,
        mapper.mapViewModelToApiRequest(model),
        {
          headers: GlobalUtilities.defaultHeaders(),
        }
      )
      .then(response => {
        this.setState({
          ...this.state,
          submitted: true,
          submitting: false,
          model: mapper.mapApiResponseToViewModel(response.data.record!),
          errorOccurred: false,
          errorMessage: '',
        });
        GlobalUtilities.logInfo(response);
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
            <label htmlFor="fieldBigInt">Field Big Int</label>
            <br />
            {getFieldDecorator('fieldBigInt', {
              rules: [{ required: true, message: 'Required' }],
            })(<InputNumber placeholder={'Field Big Int'} />)}
          </Form.Item>

          <Form.Item>
            <label htmlFor="fieldBinary">Field Binary</label>
            <br />
            {getFieldDecorator('fieldBinary', {
              rules: [
                { required: true, message: 'Required' },
                { max: 50, message: 'Exceeds max length of 50' },
              ],
            })(<Input placeholder={'Field Binary'} />)}
          </Form.Item>

          <Form.Item>
            <label htmlFor="fieldBit">Field Bit</label>
            <br />
            {getFieldDecorator('fieldBit', {
              rules: [],
              valuePropName: 'checked',
            })(<Switch />)}
          </Form.Item>

          <Form.Item>
            <label htmlFor="fieldChar">Field Char</label>
            <br />
            {getFieldDecorator('fieldChar', {
              rules: [
                { required: true, message: 'Required' },
                { max: 10, message: 'Exceeds max length of 10' },
              ],
            })(<Input placeholder={'Field Char'} />)}
          </Form.Item>

          <Form.Item>
            <label htmlFor="fieldDate">Field Date</label>
            <br />
            {getFieldDecorator('fieldDate', {
              rules: [{ required: true, message: 'Required' }],
            })(<DatePicker format={'YYYY-MM-DD'} placeholder={'Field Date'} />)}
          </Form.Item>

          <Form.Item>
            <label htmlFor="fieldDateTime">Field Date Time</label>
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
            <label htmlFor="fieldDateTime2">Field Date Time2</label>
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
            <label htmlFor="fieldDateTimeOffset">Field Date Time Offset</label>
            <br />
            {getFieldDecorator('fieldDateTimeOffset', {
              rules: [{ required: true, message: 'Required' }],
            })(<Input placeholder={'Field Date Time Offset'} />)}
          </Form.Item>

          <Form.Item>
            <label htmlFor="fieldDecimal">Field Decimal</label>
            <br />
            {getFieldDecorator('fieldDecimal', {
              rules: [{ required: true, message: 'Required' }],
            })(<InputNumber placeholder={'Field Decimal'} />)}
          </Form.Item>

          <Form.Item>
            <label htmlFor="fieldFloat">Field Float</label>
            <br />
            {getFieldDecorator('fieldFloat', {
              rules: [{ required: true, message: 'Required' }],
            })(<InputNumber placeholder={'Field Float'} />)}
          </Form.Item>

          <Form.Item>
            <label htmlFor="fieldImage">Field Image</label>
            <br />
            {getFieldDecorator('fieldImage', {
              rules: [{ required: true, message: 'Required' }],
            })(<Input placeholder={'Field Image'} />)}
          </Form.Item>

          <Form.Item>
            <label htmlFor="fieldMoney">Field Money</label>
            <br />
            {getFieldDecorator('fieldMoney', {
              rules: [{ required: true, message: 'Required' }],
            })(<InputNumber placeholder={'Field Money'} />)}
          </Form.Item>

          <Form.Item>
            <label htmlFor="fieldNChar">Field N Char</label>
            <br />
            {getFieldDecorator('fieldNChar', {
              rules: [
                { required: true, message: 'Required' },
                { max: 10, message: 'Exceeds max length of 10' },
              ],
            })(<Input placeholder={'Field N Char'} />)}
          </Form.Item>

          <Form.Item>
            <label htmlFor="fieldNText">Field N Text</label>
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
            <label htmlFor="fieldNumeric">Field Numeric</label>
            <br />
            {getFieldDecorator('fieldNumeric', {
              rules: [{ required: true, message: 'Required' }],
            })(<InputNumber placeholder={'Field Numeric'} />)}
          </Form.Item>

          <Form.Item>
            <label htmlFor="fieldNVarchar">Field N Varchar</label>
            <br />
            {getFieldDecorator('fieldNVarchar', {
              rules: [
                { required: true, message: 'Required' },
                { max: 50, message: 'Exceeds max length of 50' },
              ],
            })(<Input placeholder={'Field N Varchar'} />)}
          </Form.Item>

          <Form.Item>
            <label htmlFor="fieldReal">Field Real</label>
            <br />
            {getFieldDecorator('fieldReal', {
              rules: [{ required: true, message: 'Required' }],
            })(<InputNumber placeholder={'Field Real'} />)}
          </Form.Item>

          <Form.Item>
            <label htmlFor="fieldSmallDateTime">Field Small Date Time</label>
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
            <label htmlFor="fieldSmallInt">Field Small Int</label>
            <br />
            {getFieldDecorator('fieldSmallInt', {
              rules: [{ required: true, message: 'Required' }],
            })(<InputNumber placeholder={'Field Small Int'} />)}
          </Form.Item>

          <Form.Item>
            <label htmlFor="fieldSmallMoney">Field Small Money</label>
            <br />
            {getFieldDecorator('fieldSmallMoney', {
              rules: [{ required: true, message: 'Required' }],
            })(<InputNumber placeholder={'Field Small Money'} />)}
          </Form.Item>

          <Form.Item>
            <label htmlFor="fieldText">Field Text</label>
            <br />
            {getFieldDecorator('fieldText', {
              rules: [{ required: true, message: 'Required' }],
            })(<Input.TextArea placeholder={'Field Text'} />)}
          </Form.Item>

          <Form.Item>
            <label htmlFor="fieldTime">Field Time</label>
            <br />
            {getFieldDecorator('fieldTime', {
              rules: [{ required: true, message: 'Required' }],
            })(<TimePicker />)}
          </Form.Item>

          <Form.Item>
            <label htmlFor="fieldTimestamp">Field Timestamp</label>
            <br />
            {getFieldDecorator('fieldTimestamp', {
              rules: [{ required: true, message: 'Required' }],
            })(<Input placeholder={'Field Timestamp'} />)}
          </Form.Item>

          <Form.Item>
            <label htmlFor="fieldTinyInt">Field Tiny Int</label>
            <br />
            {getFieldDecorator('fieldTinyInt', {
              rules: [{ required: true, message: 'Required' }],
            })(<InputNumber placeholder={'Field Tiny Int'} />)}
          </Form.Item>

          <Form.Item>
            <label htmlFor="fieldUniqueIdentifier">
              Field Unique Identifier
            </label>
            <br />
            {getFieldDecorator('fieldUniqueIdentifier', {
              rules: [{ required: true, message: 'Required' }],
            })(<Input placeholder={'Field Unique Identifier'} />)}
          </Form.Item>

          <Form.Item>
            <label htmlFor="fieldVarBinary">Field Var Binary</label>
            <br />
            {getFieldDecorator('fieldVarBinary', {
              rules: [
                { required: true, message: 'Required' },
                { max: 50, message: 'Exceeds max length of 50' },
              ],
            })(<Input placeholder={'Field Var Binary'} />)}
          </Form.Item>

          <Form.Item>
            <label htmlFor="fieldVarchar">Field Varchar</label>
            <br />
            {getFieldDecorator('fieldVarchar', {
              rules: [
                { required: true, message: 'Required' },
                { max: 50, message: 'Exceeds max length of 50' },
              ],
            })(<Input placeholder={'Field Varchar'} />)}
          </Form.Item>

          <Form.Item>
            <label htmlFor="fieldXML">Field X M L</label>
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

export const WrappedTestAllFieldTypeCreateComponent = Form.create({
  name: 'TestAllFieldType Create',
})(TestAllFieldTypeCreateComponent);


/*<Codenesium>
    <Hash>54a5b0176774af50c7b03c8ed4efc4c3</Hash>
</Codenesium>*/