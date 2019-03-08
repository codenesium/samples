import React, { Component, FormEvent } from 'react';
import axios from 'axios';
import { ActionResponse, CreateResponse } from '../../api/apiObjects';
import { Constants, ApiRoutes, ClientRoutes } from '../../constants';
import * as Api from '../../api/models';
import SaleMapper from './saleMapper';
import SaleViewModel from './saleViewModel';
import { Form, Input, Button, Switch, InputNumber, DatePicker, Spin, Alert, TimePicker } from 'antd';
import { WrappedFormUtils } from 'antd/es/form/Form';
import { ToLowerCaseFirstLetter } from '../../lib/stringUtilities';
import { PaymentTypeSelectComponent } from '../shared/paymentTypeSelect'
	import { PetSelectComponent } from '../shared/petSelect'
	
interface SaleCreateComponentProps {
  form:WrappedFormUtils;
  history:any;
  match:any;
}

interface SaleCreateComponentState {
  model?: SaleViewModel;
  loading: boolean;
  loaded: boolean;
  errorOccurred: boolean;
  errorMessage: string;
  submitted:boolean;
  submitting:boolean;
}

class SaleCreateComponent extends React.Component<
  SaleCreateComponentProps,
  SaleCreateComponentState
> {
  state = {
    model: new SaleViewModel(),
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
        let model = values as SaleViewModel;
        console.log('Received values of form: ', model);
        this.submit(model);
      }
	  else {
	      this.setState({...this.state, submitting:false, submitted:false});
	  }
    });
  };

  submit = (model:SaleViewModel) =>
  {  
    let mapper = new SaleMapper();
     axios
      .post(
        Constants.ApiEndpoint + ApiRoutes.Sales,
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
            Api.SaleClientRequestModel
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
              <label htmlFor='amount'>Amount</label>
              <br />             
              {getFieldDecorator('amount', {
              rules:[{ required: true, message: 'Required' },
],
              
              })
              ( <InputNumber placeholder={"Amount"} /> )}
              </Form.Item>

						<Form.Item>
              <label htmlFor='firstName'>First Name</label>
              <br />             
              {getFieldDecorator('firstName', {
              rules:[{ required: true, message: 'Required' },
{ max: 90, message: 'Exceeds max length of 90' },
],
              
              })
              ( <Input placeholder={"First Name"} /> )}
              </Form.Item>

						<Form.Item>
              <label htmlFor='lastName'>Last Name</label>
              <br />             
              {getFieldDecorator('lastName', {
              rules:[{ required: true, message: 'Required' },
{ max: 90, message: 'Exceeds max length of 90' },
],
              
              })
              ( <Input placeholder={"Last Name"} /> )}
              </Form.Item>

						
                        <Form.Item>
                        <label htmlFor='paymentTypeId'>Payment Type</label>
                        <br />   
                        <PaymentTypeSelectComponent   
                          apiRoute={
                          Constants.ApiEndpoint +
                          ApiRoutes.PaymentTypes}
                          getFieldDecorator={this.props.form.getFieldDecorator}
                          propertyName="paymentTypeId"
                          required={true}
                          selectedValue={this.state.model!.paymentTypeId}
                         />
                        </Form.Item>

						
                        <Form.Item>
                        <label htmlFor='petId'>Pet</label>
                        <br />   
                        <PetSelectComponent   
                          apiRoute={
                          Constants.ApiEndpoint +
                          ApiRoutes.Pets}
                          getFieldDecorator={this.props.form.getFieldDecorator}
                          propertyName="petId"
                          required={true}
                          selectedValue={this.state.model!.petId}
                         />
                        </Form.Item>

						<Form.Item>
              <label htmlFor='phone'>Phone</label>
              <br />             
              {getFieldDecorator('phone', {
              rules:[{ required: true, message: 'Required' },
{ max: 10, message: 'Exceeds max length of 10' },
],
              
              })
              ( <Input placeholder={"Phone"} /> )}
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

export const WrappedSaleCreateComponent = Form.create({ name: 'Sale Create' })(SaleCreateComponent);

/*<Codenesium>
    <Hash>0f9aad646250cee952d67f279ea49816</Hash>
</Codenesium>*/