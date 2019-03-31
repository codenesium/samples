import React, { FormEvent } from 'react';
import axios, { AxiosError, AxiosResponse} from 'axios';
import { Constants, AuthApiRoutes } from '../../constants';
import { AuthResponse } from '../../api/apiObjects';
import ChangePasswordMapper from './changePasswordMapper';
import ChangePasswordViewModel from './changePasswordViewModel';
import { Form, Input, Button, Spin, Alert } from 'antd';
import { WrappedFormUtils } from 'antd/es/form/Form';
import * as GlobalUtilities from '../../lib/globalUtilities'

interface ChangePasswordComponentProps {
  form: WrappedFormUtils;
  history: any;
  match: any;
}

interface ChangePasswordComponentState {
  model?: ChangePasswordViewModel;
  loading: boolean;
  loaded: boolean;
  submitting:boolean,
  submitted:boolean,
  errorOccurred: boolean;
  message: string;
}

class ChangePasswordComponent extends React.Component<
  ChangePasswordComponentProps,
  ChangePasswordComponentState
> {
  state = {
    model: new ChangePasswordViewModel(),
    loading: false,
    loaded: true,
    submitting:false,
    submitted:false,
    errorOccurred: false,
    message: ''
  };

  handleSubmit = (e: FormEvent<HTMLFormElement>) => {
    e.preventDefault();
    this.setState({ ...this.state, submitting: true, submitted: false });
    this.props.form.validateFields((err: any, values: any) => {
      if (!err) {
        let model = values as ChangePasswordViewModel;
        this.submit(model);
      } else {
        this.setState({ ...this.state, submitting: false, submitted: false });
      }
    });
  };

  submit = (model: ChangePasswordViewModel) => {
    let mapper = new ChangePasswordMapper();
    axios
      .post<AuthResponse>(
        Constants.ApiEndpoint + AuthApiRoutes.ChangePassword,
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
            errorOccurred: false,
            model:undefined,
            message:'Your password has been changed. You may now log in.',
          });
        })
		.catch((error:AxiosError) => {
            GlobalUtilities.logError(error);
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
        getFieldDecorator
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
            <label htmlFor='currentPassword'>Current Password</label>
            <br />
            {getFieldDecorator('currentPassword', {
              rules: [
                { required: true, message: 'Required' }
              ],
            })(<Input.Password action='' placeholder='Current Password' />)}
          </Form.Item>
          <Form.Item>
            <label htmlFor='newPassword'>New Password</label>
            <br />
            {getFieldDecorator('newPassword', {
              rules: [
                { required: true, message: 'Required' }
              ],
            })(<Input.Password action='' placeholder='New Password' />)}
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

export const WrappedChangePasswordComponent = Form.create({
  name: 'ChangePassword Form',
})(ChangePasswordComponent);

