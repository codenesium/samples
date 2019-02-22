import React, { Component, FormEvent } from 'react';
import axios from 'axios';
import { CreateResponse } from '../../api/apiObjects';
import { Constants, ApiRoutes, ClientRoutes } from '../../constants';
import * as Api from '../../api/models';
import EmployeeMapper from './employeeMapper';
import EmployeeViewModel from './employeeViewModel';
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

interface EmployeeCreateComponentProps {
  form: WrappedFormUtils;
  history: any;
  match: any;
}

interface EmployeeCreateComponentState {
  model?: EmployeeViewModel;
  loading: boolean;
  loaded: boolean;
  errorOccurred: boolean;
  errorMessage: string;
  submitted: boolean;
}

class EmployeeCreateComponent extends React.Component<
  EmployeeCreateComponentProps,
  EmployeeCreateComponentState
> {
  state = {
    model: new EmployeeViewModel(),
    loading: false,
    loaded: true,
    errorOccurred: false,
    errorMessage: '',
    submitted: false,
  };

  handleSubmit = (e: FormEvent<HTMLFormElement>) => {
    e.preventDefault();
    this.props.form.validateFields((err: any, values: any) => {
      if (!err) {
        let model = values as EmployeeViewModel;
        console.log('Received values of form: ', model);
        this.submit(model);
      }
    });
  };

  submit = (model: EmployeeViewModel) => {
    let mapper = new EmployeeMapper();
    axios
      .post(
        Constants.ApiEndpoint + ApiRoutes.Employees,
        mapper.mapViewModelToApiRequest(model),
        {
          headers: {
            'Content-Type': 'application/json',
          },
        }
      )
      .then(
        resp => {
          let response = resp.data as CreateResponse<
            Api.EmployeeClientRequestModel
          >;
          this.setState({
            ...this.state,
            submitted: true,
            model: mapper.mapApiResponseToViewModel(response.record!),
            errorOccurred: false,
            errorMessage: '',
          });
          console.log(response);
        },
        error => {
          console.log(error);
          this.setState({
            ...this.state,
            submitted: true,
            errorOccurred: true,
            errorMessage: 'Error from API',
          });
        }
      );
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
            <label htmlFor="firstName">firstName</label>
            <br />
            {getFieldDecorator('firstName', {
              rules: [
                { required: true, message: 'Required' },
                { whitespace: true, message: 'Required' },
                { max: 128, message: 'Exceeds max length of 128' },
              ],
            })(<DatePicker format={'YYYY-MM-DD'} placeholder={'firstName'} />)}
          </Form.Item>

          <Form.Item>
            <label htmlFor="isSalesPerson">isSalesPerson</label>
            <br />
            {getFieldDecorator('isSalesPerson', {
              rules: [
                { required: true, message: 'Required' },
                { whitespace: true, message: 'Required' },
              ],
            })(
              <DatePicker format={'YYYY-MM-DD'} placeholder={'isSalesPerson'} />
            )}
          </Form.Item>

          <Form.Item>
            <label htmlFor="isShipper">isShipper</label>
            <br />
            {getFieldDecorator('isShipper', {
              rules: [
                { required: true, message: 'Required' },
                { whitespace: true, message: 'Required' },
              ],
            })(<DatePicker format={'YYYY-MM-DD'} placeholder={'isShipper'} />)}
          </Form.Item>

          <Form.Item>
            <label htmlFor="lastName">lastName</label>
            <br />
            {getFieldDecorator('lastName', {
              rules: [
                { required: true, message: 'Required' },
                { whitespace: true, message: 'Required' },
                { max: 128, message: 'Exceeds max length of 128' },
              ],
            })(<DatePicker format={'YYYY-MM-DD'} placeholder={'lastName'} />)}
          </Form.Item>

          <Form.Item>
            <Button type="primary" htmlType="submit">
              Submit
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

export const WrappedEmployeeCreateComponent = Form.create({
  name: 'Employee Create',
})(EmployeeCreateComponent);


/*<Codenesium>
    <Hash>e33e39eaebfe203b939bca7dae512ace</Hash>
</Codenesium>*/