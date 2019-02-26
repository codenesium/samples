import React, { Component, FormEvent } from 'react';
import axios from 'axios';
import { ActionResponse, CreateResponse } from '../../api/apiObjects';
import { Constants, ApiRoutes, ClientRoutes } from '../../constants';
import * as Api from '../../api/models';
import CustomerCommunicationMapper from './customerCommunicationMapper';
import CustomerCommunicationViewModel from './customerCommunicationViewModel';
import { Form, Input, Button, Switch, InputNumber, DatePicker, Spin, Alert, TimePicker } from 'antd';
import { WrappedFormUtils } from 'antd/es/form/Form';
import { ToLowerCaseFirstLetter } from '../../lib/stringUtilities';
import { CustomerSelectComponent } from '../shared/customerSelect'
	import { EmployeeSelectComponent } from '../shared/employeeSelect'
	
interface CustomerCommunicationCreateComponentProps {
  form:WrappedFormUtils;
  history:any;
  match:any;
}

interface CustomerCommunicationCreateComponentState {
  model?: CustomerCommunicationViewModel;
  loading: boolean;
  loaded: boolean;
  errorOccurred: boolean;
  errorMessage: string;
  submitted:boolean;
}

class CustomerCommunicationCreateComponent extends React.Component<
  CustomerCommunicationCreateComponentProps,
  CustomerCommunicationCreateComponentState
> {
  state = {
    model: new CustomerCommunicationViewModel(),
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
        let model = values as CustomerCommunicationViewModel;
        console.log('Received values of form: ', model);
        this.submit(model);
      }
    });
  };

  submit = (model:CustomerCommunicationViewModel) =>
  {  
    let mapper = new CustomerCommunicationMapper();
     axios
      .post(
        Constants.ApiEndpoint + ApiRoutes.CustomerCommunications,
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
            Api.CustomerCommunicationClientRequestModel
          >;
          this.setState({...this.state, submitted:true, model:mapper.mapApiResponseToViewModel(response.record!), errorOccurred:false, errorMessage:''});
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
      return <Spin size="large" />;
    } 
    else if (this.state.loaded) {

        return ( 
         <Form onSubmit={this.handleSubmit}>
            			<Form.Item>
              <label htmlFor='customerId'>customerId</label>
              <br />             
              {getFieldDecorator('customerId', {
              rules:[{ required: true, message: 'Required' },
],
              
              })
              ( <Input placeholder={"customerId"} /> )}
              </Form.Item>

						<Form.Item>
              <label htmlFor='dateCreated'>dateCreated</label>
              <br />             
              {getFieldDecorator('dateCreated', {
              rules:[{ required: true, message: 'Required' },
],
              
              })
              ( <DatePicker format={'YYYY-MM-DD'} placeholder={"dateCreated"} /> )}
              </Form.Item>

						<Form.Item>
              <label htmlFor='employeeId'>employeeId</label>
              <br />             
              {getFieldDecorator('employeeId', {
              rules:[{ required: true, message: 'Required' },
],
              
              })
              ( <Input placeholder={"employeeId"} /> )}
              </Form.Item>

						<Form.Item>
              <label htmlFor='note'>notes</label>
              <br />             
              {getFieldDecorator('note', {
              rules:[{ required: true, message: 'Required' },
],
              
              })
              ( <Input placeholder={"notes"} /> )}
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

export const WrappedCustomerCommunicationCreateComponent = Form.create({ name: 'CustomerCommunication Create' })(CustomerCommunicationCreateComponent);

/*<Codenesium>
    <Hash>c08450d9e568c074a4854bcd1b79f717</Hash>
</Codenesium>*/