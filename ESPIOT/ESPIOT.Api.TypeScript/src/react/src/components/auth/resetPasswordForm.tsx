import React, { FormEvent } from 'react';
import axios from 'axios';
import { Constants, AuthApiRoutes } from '../../constants';
import { AuthResponse } from '../../api/apiObjects';
import ResetPasswordMapper from './resetPasswordMapper';
import ResetPasswordViewModel from './resetPasswordViewModel';
import { Form, Input, Button, Spin, Alert } from 'antd';
import { WrappedFormUtils } from 'antd/es/form/Form';

interface ResetPasswordComponentProps {
  form: WrappedFormUtils;
  history: any;
  match: any;
}

interface ResetPasswordComponentState {
  model?: ResetPasswordViewModel;
  loading: boolean;
  loaded: boolean;
  submitting:boolean,
  submitted:boolean,
  errorOccurred: boolean;
  message: string;
}

class ResetPasswordComponent extends React.Component<
  ResetPasswordComponentProps,
  ResetPasswordComponentState
> {
  state = {
    model: new ResetPasswordViewModel(),
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
        let model = values as ResetPasswordViewModel;
        console.log('Received values of form: ', model);
        this.submit(model);
      } else {
        this.setState({ ...this.state, submitting: false, submitted: false });
      }
    });
  };

  submit = (model: ResetPasswordViewModel) => {
    let mapper = new ResetPasswordMapper();
    axios
      .post(
        Constants.ApiEndpoint + AuthApiRoutes.ResetPassword,
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
            model:undefined,
            message: 'A password reset link has been sent to your email. Click the link to continue.',
          });
          console.log(response);
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

export const WrappedResetPasswordComponent = Form.create({
  name: 'ResetPassword Form',
})(ResetPasswordComponent);

