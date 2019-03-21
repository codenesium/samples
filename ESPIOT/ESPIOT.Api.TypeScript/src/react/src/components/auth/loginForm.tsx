import React, { Component, FormEvent } from 'react';
import axios from 'axios';
import { Constants, AuthClientRoutes, AuthApiRoutes } from '../../constants';
import * as Api from './models';
import { ActionResponse, CreateResponse, AuthResponse } from '../../api/apiObjects';
import LoginMapper from './loginMapper';
import LoginViewModel from './loginViewModel';
import { Form, Input, Button, Spin, Alert } from 'antd';
import { WrappedFormUtils } from 'antd/es/form/Form';
import { ToLowerCaseFirstLetter } from '../../lib/stringUtilities';

interface LoginComponentProps {
  form: WrappedFormUtils;
  history: any;
  match: any;
}

interface LoginComponentState {
  model?: LoginViewModel;
  loading: boolean;
  loaded: boolean;
  submitting:boolean,
  submitted:boolean,
  errorOccurred: boolean;
  message: string;
}

class LoginComponent extends React.Component<
  LoginComponentProps,
  LoginComponentState
> {
  state = {
    model: new LoginViewModel(),
    loading: false,
    loaded: true,
    submitting:false,
    submitted:false,
    errorOccurred: false,
    message: '',
  };

  handleSubmit = (e: FormEvent<HTMLFormElement>) => {
    e.preventDefault();
    this.setState({ ...this.state, submitting: true, submitted: false });
    this.props.form.validateFields((err: any, values: any) => {
      if (!err) {
        let model = values as LoginViewModel;
        console.log('Received values of form: ', model);
        this.submit(model);
      } else {
        this.setState({ ...this.state, submitting: false, submitted: false });
      }
    });
  };

  submit = (model: LoginViewModel) => {
    let mapper = new LoginMapper();
    axios
      .post(
        Constants.ApiEndpoint + AuthApiRoutes.Login,
        mapper.mapViewModelToApiRequest(model),
        {
          headers: {
            'Content-Type': 'application/json',
          },
        }
      )
      .then(
        resp => {
          let response = resp.data as AuthResponse;
          this.setState({
            ...this.state,
            submitted: true,
            submitting: false,
            errorOccurred: false,
            message: '',
          });
          console.log(response);
          localStorage.setItem("token", response.token);
          this.props.history.push('/');
        },
        error => {
          console.log(error);
          if (error.response.data) {
            let errorResponse = error.response.data as AuthResponse;

            this.setState({
                ...this.state,
                submitted: true,
                submitting: false,
                errorOccurred: true,
                message: errorResponse.message
            });
        }
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
    if (this.state.message) {
        if(this.state.errorOccurred)
        {
            message = <Alert message={this.state.message} type="error" />;
        }
        else
        {
            message = <Alert message={this.state.message} type="success" />;
        }
    }

    if (this.state.loading) {
      return <Spin size="large" />;
    } else if (this.state.loaded) {
      return (
        <div>
          <div>
          <Form onSubmit={this.handleSubmit}>
          <Form.Item>
            <label htmlFor="email">Email</label>
            <br />
            {getFieldDecorator('email', {
              rules: [
                { required: true, message: 'Required' }
              ],
            })(<Input placeholder={'Email'} />)}
          </Form.Item>

           <Form.Item>
            <label htmlFor="password">Password</label>
            <br />
            {getFieldDecorator('password', {
              rules: [
                { required: true, message: 'Required' }
              ],
            })(<Input.Password placeholder='Password' />)}
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
        </Form>
          </div>
          {message}
          
        </div>
      );
    } else {
      return null;
    }
  }
}

export const WrappedLoginComponent = Form.create({
  name: 'Login Form',
})(LoginComponent);

