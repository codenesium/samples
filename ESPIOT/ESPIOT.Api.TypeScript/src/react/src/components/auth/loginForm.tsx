import React, { Component, FormEvent } from 'react';
import axios, { AxiosError, AxiosResponse} from 'axios';
import { Constants, AuthApiRoutes } from '../../constants';
import { AuthResponse } from '../../api/apiObjects';
import LoginMapper from './loginMapper';
import LoginViewModel from './loginViewModel';
import { Form, Input, Button, Spin, Alert } from 'antd';
import { WrappedFormUtils } from 'antd/es/form/Form';
import * as GlobalUtilities from '../../lib/globalUtilities'

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

  componentDidMount () 
  {
    this.props.form.setFieldsValue({
      email:'test@test.com',
      password:'Passw0rd$'
    });
  }

  handleSubmit = (e: FormEvent<HTMLFormElement>) => {
    e.preventDefault();
    this.setState({ ...this.state, submitting: true, submitted: false });
    this.props.form.validateFields((err: any, values: any) => {
      if (!err) {
        let model = values as LoginViewModel;
        this.submit(model);
      } else {
        this.setState({ ...this.state, submitting: false, submitted: false });
      }
    });
  };

  submit = (model: LoginViewModel) => {
    let mapper = new LoginMapper();
    axios
      .post<AuthResponse>(
        Constants.ApiEndpoint + AuthApiRoutes.Login,
        mapper.mapViewModelToApiRequest(model),
        {
          headers: {
            'Content-Type': 'application/json',
          },
        }
      )
      .then(response => {
          GlobalUtilities.logInfo(response);
          this.setState({
            ...this.state,
            submitted: true,
            submitting: false,
            errorOccurred: false,
            message: '',
          });
          localStorage.setItem('authToken', response.data.token);
          this.props.history.push('/');
        })
		.catch((error:AxiosError) => {
			if (error.response && error.response.data) {
				let errorResponse = error.response.data as AuthResponse;

				this.setState({
					...this.state,
					submitted: true,
					submitting: false,
					errorOccurred: true,
					message: errorResponse.message
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
    if (this.state.message) {
        if(this.state.errorOccurred)
        {
            message = <Alert message={this.state.message} type='error' />;
        }
        else
        {
            message = <Alert message={this.state.message} type='success' />;
        }
    }

    if (this.state.loading) {
      return <Spin size='large' />;
    } else if (this.state.loaded) {
      return (
        <div>
          <div>
          <Form onSubmit={this.handleSubmit}>
          <Form.Item>
            <label htmlFor='email'>Email</label>
            <br />
            {getFieldDecorator('email', {
              rules: [
                { required: true, message: 'Required' },
				{ type: 'email', message: 'Not a valid email' }
              ],
            })(<Input placeholder={'Email'} />)}
          </Form.Item>

           <Form.Item>
            <label htmlFor='password'>Password</label>
            <br />
            {getFieldDecorator('password', {
              rules: [
                { required: true, message: 'Required' }
              ],
            })(<Input.Password action='' placeholder='Password' />)}
          </Form.Item>

          <Form.Item>
            <Button
              htmlType='submit'
			  type='primary'
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

