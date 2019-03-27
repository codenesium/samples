import React, { FormEvent } from 'react';
import axios, { AxiosError, AxiosResponse} from 'axios';
import { Constants, AuthApiRoutes, AuthClientRoutes } from '../../constants';
import { AuthResponse } from '../../api/apiObjects';
import { Form, Input, Button, Spin, Alert } from 'antd';
import { WrappedFormUtils } from 'antd/es/form/Form';
import { Link } from 'react-router-dom';
import ConfirmChangeEmailViewModel from './confirmChangeEmailViewModel'
import * as GlobalUtilities from '../../lib/globalUtilities'

interface ConfirmChangeEmailComponentProps {
  form: WrappedFormUtils;
  history: any;
  match: any;
}

interface ConfirmChangeEmailComponentState {
  loading: boolean;
  loaded: boolean;
  submitting:boolean,
  submitted:boolean,
  errorOccurred: boolean;
  message: string;
  model?:ConfirmChangeEmailViewModel;
}

class ConfirmChangeEmailComponent extends React.Component<
  ConfirmChangeEmailComponentProps,
  ConfirmChangeEmailComponentState
> {
  state = {
    loading: false,
    loaded: true,
    submitting:false,
    submitted:false,
    errorOccurred: false,
    message: '',
    model:new ConfirmChangeEmailViewModel()
  };

  handleSubmit = (e: FormEvent<HTMLFormElement>) => {
    e.preventDefault();
    this.setState({ ...this.state, submitting: true, submitted: false });
    this.props.form.validateFields((err: any, values: any) => {
      let model:ConfirmChangeEmailViewModel = new ConfirmChangeEmailViewModel();
      model.setProperties(this.props.match.params.token);
      
      if (!err) {
        this.submit(model);
      } else {
        this.setState({ ...this.state, submitting: false, submitted: false });
      }
    });

  };

  submit = (model:ConfirmChangeEmailViewModel) => {
    
    axios
      .post<AuthResponse>(
        Constants.ApiEndpoint + AuthApiRoutes.ConfirmChangeEmail,
        JSON.stringify(model),
        {
          headers: GlobalUtilities.defaultHeaders()
        }
      )
      .then(response => {
          GlobalUtilities.logInfo(response);
		  this.setState({
            ...this.state,
            submitted: true,
            submitting: false,
            errorOccurred: false,
            message: 'Your email has been changed. You may now log in.',
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

      let errorMessage = <div></div>;
      if (this.state.errorOccurred)
      {
        errorMessage = <Alert message={this.state.message} type='error' />;
      }

      if (this.state.loading) {
        return <Spin size='large' />;
      } 
      else if(this.state.submitted && !this.state.errorOccurred)
      {
          return <div>
                <Alert message={this.state.message} type='success' /> 
                <br />          
               <Button
			    type='primary'
                htmlType='submit'
               >
                   <Link to={AuthClientRoutes.Login}>Log in</Link>
              </Button>
			 </div>;
			}
			else if (this.state.loaded) {
			  return (
				<div>
				  {errorMessage}
				  <Form onSubmit={this.handleSubmit}>
					<Form.Item>
					  <Button
						type='primary'
						htmlType='submit'
						loading={this.state.submitting}
					  >
						{this.state.submitting ? 'Submitting...' : 'Complete Email Change'}
					  </Button>
					</Form.Item>
				</Form>
				</div>
			  );
			} else {
      return null;
    }
  }
}

export const WrappedConfirmChangeEmailComponent = Form.create({
  name: 'Confirm Change Email Form',
})(ConfirmChangeEmailComponent);

