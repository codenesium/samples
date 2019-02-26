import React, { Component, FormEvent } from 'react';
import axios from 'axios';
import { CreateResponse } from '../../api/apiObjects';
import { Constants, ApiRoutes, ClientRoutes } from '../../constants';
import * as Api from '../../api/models';
import CustomerMapper from './customerMapper';
import CustomerViewModel from './customerViewModel';
import { Form, Input, Button, Switch, InputNumber, DatePicker, Spin, Alert, TimePicker } from 'antd';
import { WrappedFormUtils } from 'antd/es/form/Form';
import { StoreSelectComponent } from '../shared/storeSelect'
	import { SalesTerritorySelectComponent } from '../shared/salesTerritorySelect'
	
interface CustomerCreateComponentProps {
  form:WrappedFormUtils;
  history:any;
  match:any;
}

interface CustomerCreateComponentState {
  model?: CustomerViewModel;
  loading: boolean;
  loaded: boolean;
  errorOccurred: boolean;
  errorMessage: string;
  submitted:boolean;
}

class CustomerCreateComponent extends React.Component<
  CustomerCreateComponentProps,
  CustomerCreateComponentState
> {
  state = {
    model: new CustomerViewModel(),
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
        let model = values as CustomerViewModel;
        console.log('Received values of form: ', model);
        this.submit(model);
      }
    });
  };

  submit = (model:CustomerViewModel) =>
  {  
    let mapper = new CustomerMapper();
     axios
      .post(
        Constants.ApiEndpoint + ApiRoutes.Customers,
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
            Api.CustomerClientRequestModel
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
      return <Spin size="large" />;
    } 
    else if (this.state.loaded) {

        return ( 
         <Form onSubmit={this.handleSubmit}>
            			<Form.Item>
              <label htmlFor='accountNumber'>AccountNumber</label>
              <br />             
              {getFieldDecorator('accountNumber', {
              rules:[{ required: true, message: 'Required' },
{ max: 10, message: 'Exceeds max length of 10' },
],
              
              })
              ( <DatePicker format={'YYYY-MM-DD'} placeholder={"AccountNumber"} /> )}
              </Form.Item>

						<Form.Item>
              <label htmlFor='modifiedDate'>ModifiedDate</label>
              <br />             
              {getFieldDecorator('modifiedDate', {
              rules:[{ required: true, message: 'Required' },
],
              
              })
              ( <DatePicker format={'YYYY-MM-DD'} placeholder={"ModifiedDate"} /> )}
              </Form.Item>

						<Form.Item>
              <label htmlFor='personID'>PersonID</label>
              <br />             
              {getFieldDecorator('personID', {
              rules:[],
              
              })
              ( <DatePicker format={'YYYY-MM-DD'} placeholder={"PersonID"} /> )}
              </Form.Item>

						<Form.Item>
              <label htmlFor='rowguid'>rowguid</label>
              <br />             
              {getFieldDecorator('rowguid', {
              rules:[{ required: true, message: 'Required' },
],
              
              })
              ( <DatePicker format={'YYYY-MM-DD'} placeholder={"rowguid"} /> )}
              </Form.Item>

						<Form.Item>
              <label htmlFor='storeID'>StoreID</label>
              <br />             
              {getFieldDecorator('storeID', {
              rules:[],
              
              })
              ( <DatePicker format={'YYYY-MM-DD'} placeholder={"StoreID"} /> )}
              </Form.Item>

						<Form.Item>
              <label htmlFor='territoryID'>TerritoryID</label>
              <br />             
              {getFieldDecorator('territoryID', {
              rules:[],
              
              })
              ( <DatePicker format={'YYYY-MM-DD'} placeholder={"TerritoryID"} /> )}
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

export const WrappedCustomerCreateComponent = Form.create({ name: 'Customer Create' })(CustomerCreateComponent);

/*<Codenesium>
    <Hash>65facd01d12708f0565b9944ed2ef78f</Hash>
</Codenesium>*/