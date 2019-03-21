import React, { FormEvent } from 'react';
import axios from 'axios';
import { Constants, AuthApiRoutes } from '../../constants';
import { AuthResponse } from '../../api/apiObjects';
import { Form, Input, Button, Spin, Alert } from 'antd';
import { WrappedFormUtils } from 'antd/es/form/Form';
import { Link } from 'react-router-dom';
import { AuthClientRoutes } from '../../constants';

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
      .post(
        Constants.ApiEndpoint + AuthApiRoutes.ConfirmRegistration,
        JSON.stringify(data),
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
            message: 'Your account has been confirmed. You may now log in.',
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
        getFieldDecorator
      } = this.props.form;


    if (this.state.loading) {
      return <Spin size="large" />;
    } 
    else if(this.state.submitted)
    {
      if(this.state.errorOccurred)
      {
          return <Alert message={this.state.message} type="error" />;
      }
      else
      {
        return <div>
              <Alert message={this.state.message} type="success" /> 
              <br />          
             <Button
              type="primary"
              htmlType="submit"
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
              type="primary"
              htmlType="submit"
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

