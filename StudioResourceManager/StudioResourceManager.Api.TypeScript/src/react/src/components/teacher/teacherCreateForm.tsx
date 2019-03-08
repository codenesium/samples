import React, { Component, FormEvent } from 'react';
import axios from 'axios';
import { ActionResponse, CreateResponse } from '../../api/apiObjects';
import { Constants, ApiRoutes, ClientRoutes } from '../../constants';
import * as Api from '../../api/models';
import TeacherMapper from './teacherMapper';
import TeacherViewModel from './teacherViewModel';
import { Form, Input, Button, Switch, InputNumber, DatePicker, Spin, Alert, TimePicker } from 'antd';
import { WrappedFormUtils } from 'antd/es/form/Form';
import { ToLowerCaseFirstLetter } from '../../lib/stringUtilities';
import { UserSelectComponent } from '../shared/userSelect'
	
interface TeacherCreateComponentProps {
  form:WrappedFormUtils;
  history:any;
  match:any;
}

interface TeacherCreateComponentState {
  model?: TeacherViewModel;
  loading: boolean;
  loaded: boolean;
  errorOccurred: boolean;
  errorMessage: string;
  submitted:boolean;
  submitting:boolean;
}

class TeacherCreateComponent extends React.Component<
  TeacherCreateComponentProps,
  TeacherCreateComponentState
> {
  state = {
    model: new TeacherViewModel(),
    loading: false,
    loaded: true,
    errorOccurred: false,
    errorMessage: '',
	submitted:false,
	submitting:false
  };

 handleSubmit = (e:FormEvent<HTMLFormElement>) => {
     e.preventDefault();
	 this.setState({...this.state, submitting:true, submitted:false});
     this.props.form.validateFields((err:any, values:any) => {
      if (!err) {
        let model = values as TeacherViewModel;
        console.log('Received values of form: ', model);
        this.submit(model);
      }
	  else {
	      this.setState({...this.state, submitting:false, submitted:false});
	  }
    });
  };

  submit = (model:TeacherViewModel) =>
  {  
    let mapper = new TeacherMapper();
     axios
      .post(
        Constants.ApiEndpoint + ApiRoutes.Teachers,
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
            Api.TeacherClientRequestModel
          >;
          this.setState({...this.state, submitted:true, submitting:false, model:mapper.mapApiResponseToViewModel(response.record!), errorOccurred:false, errorMessage:''});
          console.log(response);
        },
        error => {
          console.log(error);
          if(error.response.data)
          {
			  let errorResponse = error.response.data as ActionResponse; 

			  errorResponse.validationErrors.forEach(x =>
			  {
				this.props.form.setFields({
				 [ToLowerCaseFirstLetter(x.propertyName)]: {
				  value:this.props.form.getFieldValue(ToLowerCaseFirstLetter(x.propertyName)),
				  errors: [new Error(x.errorMessage)]
				},
				})
			  });
		  }
          this.setState({...this.state, submitted:true, submitting:false, errorOccurred:true, errorMessage:'Error from API'});
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
      return <Spin size="large" />;
    } 
    else if (this.state.loaded) {

        return ( 
         <Form onSubmit={this.handleSubmit}>
            			<Form.Item>
              <label htmlFor='birthday'>Birthday</label>
              <br />             
              {getFieldDecorator('birthday', {
              rules:[{ required: true, message: 'Required' },
],
              
              })
              ( <DatePicker format={'YYYY-MM-DD'} placeholder={"Birthday"} /> )}
              </Form.Item>

						<Form.Item>
              <label htmlFor='email'>Email</label>
              <br />             
              {getFieldDecorator('email', {
              rules:[{ required: true, message: 'Required' },
{ max: 128, message: 'Exceeds max length of 128' },
],
              
              })
              ( <Input placeholder={"Email"} /> )}
              </Form.Item>

						<Form.Item>
              <label htmlFor='firstName'>First Name</label>
              <br />             
              {getFieldDecorator('firstName', {
              rules:[{ required: true, message: 'Required' },
{ max: 128, message: 'Exceeds max length of 128' },
],
              
              })
              ( <Input placeholder={"First Name"} /> )}
              </Form.Item>

						<Form.Item>
              <label htmlFor='lastName'>Last Name</label>
              <br />             
              {getFieldDecorator('lastName', {
              rules:[{ required: true, message: 'Required' },
{ max: 128, message: 'Exceeds max length of 128' },
],
              
              })
              ( <Input placeholder={"Last Name"} /> )}
              </Form.Item>

						<Form.Item>
              <label htmlFor='phone'>Phone</label>
              <br />             
              {getFieldDecorator('phone', {
              rules:[{ max: 128, message: 'Exceeds max length of 128' },
],
              
              })
              ( <InputNumber placeholder={"Phone"} /> )}
              </Form.Item>

						
                        <Form.Item>
                        <label htmlFor='userId'>User</label>
                        <br />   
                        <UserSelectComponent   
                          apiRoute={
                          Constants.ApiEndpoint +
                          ApiRoutes.Users}
                          getFieldDecorator={this.props.form.getFieldDecorator}
                          propertyName="userId"
                          required={true}
                          selectedValue={this.state.model!.userId}
                         />
                        </Form.Item>

			
           <Form.Item>
            <Button type="primary" htmlType="submit" loading={this.state.submitting} >
                {(this.state.submitting ? "Submitting..." : "Submit")}
              </Button>
            </Form.Item>
			{message}
        </Form>);
    } else {
      return null;
    }
  }
}

export const WrappedTeacherCreateComponent = Form.create({ name: 'Teacher Create' })(TeacherCreateComponent);

/*<Codenesium>
    <Hash>f4987cc6f6dbbdd979ab98fd6c29694c</Hash>
</Codenesium>*/