import React, { Component, FormEvent } from 'react';
import axios from 'axios';
import { CreateResponse } from '../../api/apiObjects';
import { LoadingForm } from '../../lib/components/loadingForm';
import { ErrorForm } from '../../lib/components/errorForm';
import { Constants, ApiRoutes, ClientRoutes } from '../../constants';
import * as Api from '../../api/models';
import AdminMapper from './adminMapper';
import AdminViewModel from './adminViewModel';
import { Form, Input, Button, Checkbox, InputNumber, DatePicker} from 'antd';
import { WrappedFormUtils } from 'antd/es/form/Form';
import { Alert } from 'antd';

interface AdminCreateComponentProps {
  form:WrappedFormUtils;
  history:any;
  match:any;
}

interface AdminCreateComponentState {
  model?: AdminViewModel;
  loading: boolean;
  loaded: boolean;
  errorOccurred: boolean;
  errorMessage: string;
  submitted:boolean;
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
	submitted:false
  };

 handleSubmit = (e:FormEvent<HTMLFormElement>) => {
     e.preventDefault();
     this.props.form.validateFields((err:any, values:any) => {
      if (!err) {
        let model = values as AdminViewModel;
        console.log('Received values of form: ', model);
        this.submit(model);
      }
    });
  };

  submit = (model:AdminViewModel) =>
  {  
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
          this.setState({...this.state, submitted:true, model:mapper.mapApiResponseToViewModel(response.record!), errorOccurred:false, errorMessage:''});
          console.log(response);
        },
        error => {
          console.log(error);
          this.setState({...this.state, submitted:true, errorOccurred:true, errorMessage:'Error from API'});
        }
      ); 
  }
  
  render() {

    const { getFieldDecorator, getFieldsError, getFieldError, isFieldTouched } = this.props.form;
        
    let message:JSX.Element = <div></div>;
    if(this.state.submitted)
    {
      if (this.state.errorOccurred) {
        message = <Alert message={this.state.errorMessage} type='error' />;
      }
      else
      {
        message = <Alert message='Submitted' type='success' />;
      }
    }

    if (this.state.loading) {
      return <LoadingForm />;
    } 
    else if (this.state.loaded) {

        return ( 
         <Form onSubmit={this.handleSubmit}>
            			<Form.Item>
              <label htmlFor='email'>email</label>
              <br />             
{getFieldDecorator('email', {
              rules:[],
              })
              ( <Input placeholder={"email"} id={"email"} /> )}
              </Form.Item>

						<Form.Item>
              <label htmlFor='firstName'>firstName</label>
              <br />             
{getFieldDecorator('firstName', {
              rules:[],
              })
              ( <Input placeholder={"firstName"} id={"firstName"} /> )}
              </Form.Item>

						<Form.Item>
              <label htmlFor='lastName'>lastName</label>
              <br />             
{getFieldDecorator('lastName', {
              rules:[],
              })
              ( <Input placeholder={"lastName"} id={"lastName"} /> )}
              </Form.Item>

						<Form.Item>
              <label htmlFor='password'>password</label>
              <br />             
{getFieldDecorator('password', {
              rules:[],
              })
              ( <Input placeholder={"password"} id={"password"} /> )}
              </Form.Item>

						<Form.Item>
              <label htmlFor='phone'>phone</label>
              <br />             
{getFieldDecorator('phone', {
              rules:[],
              })
              ( <InputNumber placeholder={"phone"} id={"phone"} /> )}
              </Form.Item>

						<Form.Item>
              <label htmlFor='username'>username</label>
              <br />             
{getFieldDecorator('username', {
              rules:[],
              })
              ( <Input placeholder={"username"} id={"username"} /> )}
              </Form.Item>

			
          <Form.Item>
            <Button type="primary" htmlType="submit">
                Submit
              </Button>
            </Form.Item>
			{message}
        </Form>);
    } else {
      return null;
    }
  }
}

export const WrappedAdminCreateComponent = Form.create({ name: 'Admin Create' })(AdminCreateComponent);

/*<Codenesium>
    <Hash>766226bcd0c5613779e329b3a92371ef</Hash>
</Codenesium>*/