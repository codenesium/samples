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
	submitted:false
  };

 handleSubmit = (e:FormEvent<HTMLFormElement>) => {
     e.preventDefault();
     this.props.form.validateFields((err:any, values:any) => {
      if (!err) {
        let model = values as SaleViewModel;
        console.log('Received values of form: ', model);
        this.submit(model);
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
              <label htmlFor='amount'>amount</label>
              <br />             
              {getFieldDecorator('amount', {
              rules:[{ required: true, message: 'Required' },
],
              
              })
              ( <InputNumber placeholder={"amount"} /> )}
              </Form.Item>

						<Form.Item>
              <label htmlFor='cutomerId'>cutomerId</label>
              <br />             
              {getFieldDecorator('cutomerId', {
              rules:[{ required: true, message: 'Required' },
],
              
              })
              ( <Input placeholder={"cutomerId"} /> )}
              </Form.Item>

						<Form.Item>
              <label htmlFor='note'>note</label>
              <br />             
              {getFieldDecorator('note', {
              rules:[{ required: true, message: 'Required' },
],
              
              })
              ( <Input placeholder={"note"} /> )}
              </Form.Item>

						<Form.Item>
              <label htmlFor='petId'>petId</label>
              <br />             
              {getFieldDecorator('petId', {
              rules:[{ required: true, message: 'Required' },
],
              
              })
              ( <Input placeholder={"petId"} /> )}
              </Form.Item>

						<Form.Item>
              <label htmlFor='saleDate'>saleDate</label>
              <br />             
              {getFieldDecorator('saleDate', {
              rules:[{ required: true, message: 'Required' },
],
              
              })
              ( <DatePicker format={'YYYY-MM-DD'} placeholder={"saleDate"} /> )}
              </Form.Item>

						<Form.Item>
              <label htmlFor='salesPersonId'>salesPersonId</label>
              <br />             
              {getFieldDecorator('salesPersonId', {
              rules:[{ required: true, message: 'Required' },
],
              
              })
              ( <Input placeholder={"salesPersonId"} /> )}
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

export const WrappedSaleCreateComponent = Form.create({ name: 'Sale Create' })(SaleCreateComponent);

/*<Codenesium>
    <Hash>8e6679226c1ba18337bd76a1e4c429a2</Hash>
</Codenesium>*/