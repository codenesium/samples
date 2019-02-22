import React, { Component, FormEvent } from 'react';
import axios from 'axios';
import { CreateResponse } from '../../api/apiObjects';
import { Constants, ApiRoutes, ClientRoutes } from '../../constants';
import * as Api from '../../api/models';
import AdminMapper from './adminMapper';
import AdminViewModel from './adminViewModel';
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

interface AdminCreateComponentProps {
  form: WrappedFormUtils;
  history: any;
  match: any;
}

interface AdminCreateComponentState {
  model?: AdminViewModel;
  loading: boolean;
  loaded: boolean;
  errorOccurred: boolean;
  errorMessage: string;
  submitted: boolean;
}

class AdminCreateComponent extends React.Component<
  AdminCreateComponentProps,
  AdminCreateComponentState
> {
  state = {
    model: new AdminViewModel(),
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
        let model = values as AdminViewModel;
        console.log('Received values of form: ', model);
        this.submit(model);
      }
    });
  };

  submit = (model: AdminViewModel) => {
    let mapper = new AdminMapper();
    axios
      .post(
        Constants.ApiEndpoint + ApiRoutes.Admins,
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
            Api.AdminClientRequestModel
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
            <label htmlFor="birthday">birthday</label>
            <br />
            {getFieldDecorator('birthday', {
              rules: [],
            })(<DatePicker format={'YYYY-MM-DD'} placeholder={'birthday'} />)}
          </Form.Item>

          <Form.Item>
            <label htmlFor="email">email</label>
            <br />
            {getFieldDecorator('email', {
              rules: [
                { required: true, message: 'Required' },
                { max: 128, message: 'Exceeds max length of 128' },
              ],
            })(<Input placeholder={'email'} />)}
          </Form.Item>

          <Form.Item>
            <label htmlFor="firstName">First Name</label>
            <br />
            {getFieldDecorator('firstName', {
              rules: [
                { required: true, message: 'Required' },
                { max: 128, message: 'Exceeds max length of 128' },
              ],
            })(<Input placeholder={'First Name'} />)}
          </Form.Item>

          <Form.Item>
            <label htmlFor="lastName">Last Name</label>
            <br />
            {getFieldDecorator('lastName', {
              rules: [
                { required: true, message: 'Required' },
                { max: 128, message: 'Exceeds max length of 128' },
              ],
            })(<Input placeholder={'Last Name'} />)}
          </Form.Item>

          <Form.Item>
            <label htmlFor="phone">phone</label>
            <br />
            {getFieldDecorator('phone', {
              rules: [{ max: 128, message: 'Exceeds max length of 128' }],
            })(<InputNumber placeholder={'phone'} />)}
          </Form.Item>

          <Form.Item>
            <label htmlFor="userId">userId</label>
            <br />
            {getFieldDecorator('userId', {
              rules: [{ required: true, message: 'Required' }],
            })(<InputNumber placeholder={'userId'} />)}
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

export const WrappedAdminCreateComponent = Form.create({
  name: 'Admin Create',
})(AdminCreateComponent);


/*<Codenesium>
    <Hash>4a1df162994b7d4b912f895bb8595d66</Hash>
</Codenesium>*/