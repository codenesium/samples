import React, { FormEvent } from 'react';
import axios, { AxiosError, AxiosResponse} from 'axios';
import { Constants, AuthApiRoutes } from '../../constants';
import { AuthResponse } from '../../api/apiObjects';
import { Form, Input, Button, Spin, Alert } from 'antd';
import { WrappedFormUtils } from 'antd/es/form/Form';
import { Link } from 'react-router-dom';
import { AuthClientRoutes } from '../../constants';
import * as GlobalUtilities from '../../lib/globalUtilities'

interface ConfirmRegistrationComponentProps {
  form: WrappedFormUtils;
  history: any;
  match: any;
}

interface ConfirmRegistrationComponentState {
  loading: boolean;
  loaded: boolean;
  submitting:boolean,
  submitted:boolean,
  errorOccurred: boolean;
  message: string;
}

class ConfirmRegistrationComponent extends React.Component<
  ConfirmRegistrationComponentProps,
  ConfirmRegistrationComponentState
> {
  state = {
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
       this.submit();
  };

  submit = () => {
    
    let data = {'id':this.props.match.params.id, 'token':this.props.match.params.token};
    axios
      .post<AuthResponse>(
        Constants.ApiEndpoint + AuthApiRoutes.ConfirmRegistration,
        JSON.stringify(data),
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
            message: 'Your account has been confirmed. You may now log in.',
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


    if (this.state.loading) {
      return <Spin size='large' />;
    } 
    else if(this.state.submitted)
    {
      if(this.state.errorOccurred)
      {
          return <Alert message={this.state.message} type='error' />;
      }
      else
      {
        return <div>
              <Alert message={this.state.message} type='success' /> 
              <br />          
             <Button
              htmlType='submit'
			  type='primary'
             >
                 <Link to={AuthClientRoutes.Login}>Log in</Link>
            </Button>
            </div>;
      }
    }
    else if (this.state.loaded) {
      return (
        <div>
          <Form onSubmit={this.handleSubmit}>
          <Form.Item>
            <Button
              htmlType='submit'
			  type='primary'
              loading={this.state.submitting}
            >
              {this.state.submitting ? 'Submitting...' : 'Complete Registration'}
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

export const WrappedConfirmRegistrationComponent = Form.create({
  name: 'Confirm Registration Form',
})(ConfirmRegistrationComponent);

