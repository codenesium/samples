import React, { FormEvent } from 'react';
import axios, { AxiosError, AxiosResponse} from 'axios';
import { Constants, AuthApiRoutes } from '../../constants';
import { AuthResponse } from '../../api/apiObjects';
import ResetPasswordMapper from './resetPasswordMapper';
import ResetPasswordViewModel from './resetPasswordViewModel';
import { Form, Input, Button, Spin, Alert } from 'antd';
import { WrappedFormUtils } from 'antd/es/form/Form';
import * as GlobalUtilities from '../../lib/globalUtilities'

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
  linkText:string;
  linkValue:string;
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
    linkText:'',
    linkValue:''
  };

  handleSubmit = (e: FormEvent<HTMLFormElement>) => {
    e.preventDefault();
    this.setState({ ...this.state, submitting: true, submitted: false });
    this.props.form.validateFields((err: any, values: any) => {
      if (!err) {
        let model = values as ResetPasswordViewModel;
        this.submit(model);
      } else {
        this.setState({ ...this.state, submitting: false, submitted: false });
      }
    });
  };

  submit = (model: ResetPasswordViewModel) => {
    let mapper = new ResetPasswordMapper();
    axios
      .post<AuthResponse>(
        Constants.ApiEndpoint + AuthApiRoutes.ResetPassword,
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
            model:undefined,
            message: response.data.message,
            linkText:response.data.linkText,
            linkValue:response.data.linkValue,
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

    let link = <div />;
   
    if(this.state.linkText){
      link = <Button><a href={this.state.linkValue}>{this.state.linkText}</a></Button>
    }

    let message: JSX.Element = <div />;
    if (this.state.message) {
        if(this.state.errorOccurred)
        {
            message = <Alert message={this.state.message} type='error' />
        }
        else
        {
            message = <Alert message={this.state.message} type='success' />
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
		  {link}
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