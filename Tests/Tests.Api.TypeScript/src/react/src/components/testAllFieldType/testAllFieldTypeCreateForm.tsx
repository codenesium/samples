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
            <label htmlFor="fieldBigInt">Bigint</label>
            <br />
            {getFieldDecorator('fieldBigInt', {
              rules: [{ required: true, message: 'Required' }],
            })(<InputNumber placeholder={'Bigint'} />)}
          </Form.Item>

          <Form.Item>
            <label htmlFor="fieldBinary">Binary</label>
            <br />
            {getFieldDecorator('fieldBinary', {
              rules: [
                { required: true, message: 'Required' },
                { max: 50, message: 'Exceeds max length of 50' },
              ],
            })(<Input placeholder={'Binary'} />)}
          </Form.Item>

          <Form.Item>
            <label htmlFor="fieldBit">Bit</label>
            <br />
            {getFieldDecorator('fieldBit', {
              rules: [],
              valuePropName: 'checked',
            })(<Switch />)}
          </Form.Item>

          <Form.Item>
            <label htmlFor="fieldChar">Char</label>
            <br />
            {getFieldDecorator('fieldChar', {
              rules: [
                { required: true, message: 'Required' },
                { max: 10, message: 'Exceeds max length of 10' },
              ],
            })(<Input placeholder={'Char'} />)}
          </Form.Item>

          <Form.Item>
            <label htmlFor="fieldDate">Date</label>
            <br />
            {getFieldDecorator('fieldDate', {
              rules: [{ required: true, message: 'Required' }],
            })(<DatePicker format={'YYYY-MM-DD'} placeholder={'Date'} />)}
          </Form.Item>

          <Form.Item>
            <label htmlFor="fieldDateTime">DateTime</label>
            <br />
            {getFieldDecorator('fieldDateTime', {
              rules: [{ required: true, message: 'Required' }],
            })(<DatePicker format={'YYYY-MM-DD'} placeholder={'DateTime'} />)}
          </Form.Item>

          <Form.Item>
            <label htmlFor="fieldDateTime2">DateTime2</label>
            <br />
            {getFieldDecorator('fieldDateTime2', {
              rules: [{ required: true, message: 'Required' }],
            })(<DatePicker format={'YYYY-MM-DD'} placeholder={'DateTime2'} />)}
          </Form.Item>

          <Form.Item>
            <label htmlFor="fieldDateTimeOffset">DateTimeOffset</label>
            <br />
            {getFieldDecorator('fieldDateTimeOffset', {
              rules: [{ required: true, message: 'Required' }],
            })(<Input placeholder={'DateTimeOffset'} />)}
          </Form.Item>

          <Form.Item>
            <label htmlFor="fieldDecimal">Decimal</label>
            <br />
            {getFieldDecorator('fieldDecimal', {
              rules: [{ required: true, message: 'Required' }],
            })(<InputNumber placeholder={'Decimal'} />)}
          </Form.Item>

          <Form.Item>
            <label htmlFor="fieldFloat">Float</label>
            <br />
            {getFieldDecorator('fieldFloat', {
              rules: [{ required: true, message: 'Required' }],
            })(<InputNumber placeholder={'Float'} />)}
          </Form.Item>

          <Form.Item>
            <label htmlFor="fieldGeography">Geography</label>
            <br />
            {getFieldDecorator('fieldGeography', {
              rules: [{ required: true, message: 'Required' }],
            })(<Input placeholder={'Geography'} />)}
          </Form.Item>

          <Form.Item>
            <label htmlFor="fieldGeometry">Geometry</label>
            <br />
            {getFieldDecorator('fieldGeometry', {
              rules: [{ required: true, message: 'Required' }],
            })(<Input placeholder={'Geometry'} />)}
          </Form.Item>

          <Form.Item>
            <label htmlFor="fieldHierarchyId">HierarchyId</label>
            <br />
            {getFieldDecorator('fieldHierarchyId', {
              rules: [
                { required: true, message: 'Required' },
                { max: 892, message: 'Exceeds max length of 892' },
              ],
            })(<Input placeholder={'HierarchyId'} />)}
          </Form.Item>

          <Form.Item>
            <label htmlFor="fieldImage">Image</label>
            <br />
            {getFieldDecorator('fieldImage', {
              rules: [{ required: true, message: 'Required' }],
            })(<Input placeholder={'Image'} />)}
          </Form.Item>

          <Form.Item>
            <label htmlFor="fieldMoney">Money</label>
            <br />
            {getFieldDecorator('fieldMoney', {
              rules: [{ required: true, message: 'Required' }],
            })(<InputNumber placeholder={'Money'} />)}
          </Form.Item>

          <Form.Item>
            <label htmlFor="fieldNChar">NChar</label>
            <br />
            {getFieldDecorator('fieldNChar', {
              rules: [
                { required: true, message: 'Required' },
                { max: 10, message: 'Exceeds max length of 10' },
              ],
            })(<Input placeholder={'NChar'} />)}
          </Form.Item>

          <Form.Item>
            <label htmlFor="fieldNText">NText</label>
            <br />
            {getFieldDecorator('fieldNText', {
              rules: [
                { required: true, message: 'Required' },
                {
                  max: 1073741823,
                  message: 'Exceeds max length of 1073741823',
                },
              ],
            })(<Input.TextArea placeholder={'NText'} />)}
          </Form.Item>

          <Form.Item>
            <label htmlFor="fieldNumeric">Numeric</label>
            <br />
            {getFieldDecorator('fieldNumeric', {
              rules: [{ required: true, message: 'Required' }],
            })(<InputNumber placeholder={'Numeric'} />)}
          </Form.Item>

          <Form.Item>
            <label htmlFor="fieldNVarchar">NVarchar</label>
            <br />
            {getFieldDecorator('fieldNVarchar', {
              rules: [
                { required: true, message: 'Required' },
                { max: 50, message: 'Exceeds max length of 50' },
              ],
            })(<Input placeholder={'NVarchar'} />)}
          </Form.Item>

          <Form.Item>
            <label htmlFor="fieldReal">Real</label>
            <br />
            {getFieldDecorator('fieldReal', {
              rules: [{ required: true, message: 'Required' }],
            })(<InputNumber placeholder={'Real'} />)}
          </Form.Item>

          <Form.Item>
            <label htmlFor="fieldSmallDateTime">SmallDateTime</label>
            <br />
            {getFieldDecorator('fieldSmallDateTime', {
              rules: [{ required: true, message: 'Required' }],
            })(
              <DatePicker format={'YYYY-MM-DD'} placeholder={'SmallDateTime'} />
            )}
          </Form.Item>

          <Form.Item>
            <label htmlFor="fieldSmallInt">SmallInt</label>
            <br />
            {getFieldDecorator('fieldSmallInt', {
              rules: [{ required: true, message: 'Required' }],
            })(<InputNumber placeholder={'SmallInt'} />)}
          </Form.Item>

          <Form.Item>
            <label htmlFor="fieldSmallMoney">SmallMoney</label>
            <br />
            {getFieldDecorator('fieldSmallMoney', {
              rules: [{ required: true, message: 'Required' }],
            })(<InputNumber placeholder={'SmallMoney'} />)}
          </Form.Item>

          <Form.Item>
            <label htmlFor="fieldText">Text</label>
            <br />
            {getFieldDecorator('fieldText', {
              rules: [{ required: true, message: 'Required' }],
            })(<Input.TextArea placeholder={'Text'} />)}
          </Form.Item>

          <Form.Item>
            <label htmlFor="fieldTime">Time</label>
            <br />
            {getFieldDecorator('fieldTime', {
              rules: [{ required: true, message: 'Required' }],
            })(<TimePicker />)}
          </Form.Item>

          <Form.Item>
            <label htmlFor="fieldTimestamp">Timestamp</label>
            <br />
            {getFieldDecorator('fieldTimestamp', {
              rules: [{ required: true, message: 'Required' }],
            })(<Input placeholder={'Timestamp'} />)}
          </Form.Item>

          <Form.Item>
            <label htmlFor="fieldTinyInt">TinyInt</label>
            <br />
            {getFieldDecorator('fieldTinyInt', {
              rules: [{ required: true, message: 'Required' }],
            })(<InputNumber placeholder={'TinyInt'} />)}
          </Form.Item>

          <Form.Item>
            <label htmlFor="fieldUniqueIdentifier">UniqueIdentifier</label>
            <br />
            {getFieldDecorator('fieldUniqueIdentifier', {
              rules: [{ required: true, message: 'Required' }],
            })(<Input placeholder={'UniqueIdentifier'} />)}
          </Form.Item>

          <Form.Item>
            <label htmlFor="fieldVarBinary">VarBinary</label>
            <br />
            {getFieldDecorator('fieldVarBinary', {
              rules: [
                { required: true, message: 'Required' },
                { max: 50, message: 'Exceeds max length of 50' },
              ],
            })(<Input placeholder={'VarBinary'} />)}
          </Form.Item>

          <Form.Item>
            <label htmlFor="fieldVarchar">Varchar</label>
            <br />
            {getFieldDecorator('fieldVarchar', {
              rules: [
                { required: true, message: 'Required' },
                { max: 50, message: 'Exceeds max length of 50' },
              ],
            })(<Input placeholder={'Varchar'} />)}
          </Form.Item>

          <Form.Item>
            <label htmlFor="fieldVariant">Variant</label>
            <br />
            {getFieldDecorator('fieldVariant', {
              rules: [{ required: true, message: 'Required' }],
            })(<Input placeholder={'Variant'} />)}
          </Form.Item>

          <Form.Item>
            <label htmlFor="fieldXML">XML</label>
            <br />
            {getFieldDecorator('fieldXML', {
              rules: [{ required: true, message: 'Required' }],
            })(<Input.TextArea placeholder={'XML'} />)}
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
    <Hash>559c205f7674fd317fbb7ea752e973c4</Hash>
</Codenesium>*/