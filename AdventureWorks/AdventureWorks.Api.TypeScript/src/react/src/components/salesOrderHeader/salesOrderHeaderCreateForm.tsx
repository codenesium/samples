import React, { Component, FormEvent } from 'react';
import axios from 'axios';
import { CreateResponse } from '../../api/apiObjects';
import { Constants, ApiRoutes, ClientRoutes } from '../../constants';
import * as Api from '../../api/models';
import SalesOrderHeaderMapper from './salesOrderHeaderMapper';
import SalesOrderHeaderViewModel from './salesOrderHeaderViewModel';
import { Form, Input, Button, Switch, InputNumber, DatePicker, Spin, Alert } from 'antd';
import { WrappedFormUtils } from 'antd/es/form/Form';

interface SalesOrderHeaderCreateComponentProps {
  form:WrappedFormUtils;
  history:any;
  match:any;
}

interface SalesOrderHeaderCreateComponentState {
  model?: SalesOrderHeaderViewModel;
  loading: boolean;
  loaded: boolean;
  errorOccurred: boolean;
  errorMessage: string;
  submitted:boolean;
}

class SalesOrderHeaderCreateComponent extends React.Component<
  SalesOrderHeaderCreateComponentProps,
  SalesOrderHeaderCreateComponentState
> {
  state = {
    model: new SalesOrderHeaderViewModel(),
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
        let model = values as SalesOrderHeaderViewModel;
        console.log('Received values of form: ', model);
        this.submit(model);
      }
    });
  };

  submit = (model:SalesOrderHeaderViewModel) =>
  {  
    let mapper = new SalesOrderHeaderMapper();
     axios
      .post(
        Constants.ApiEndpoint + ApiRoutes.SalesOrderHeaders,
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
            Api.SalesOrderHeaderClientRequestModel
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
              rules:[],
              
              })
              ( <DatePicker format={'YYYY-MM-DD'} placeholder={"AccountNumber"} id={"accountNumber"} /> )}
              </Form.Item>

						<Form.Item>
              <label htmlFor='billToAddressID'>BillToAddressID</label>
              <br />             
              {getFieldDecorator('billToAddressID', {
              rules:[],
              
              })
              ( <DatePicker format={'YYYY-MM-DD'} placeholder={"BillToAddressID"} id={"billToAddressID"} /> )}
              </Form.Item>

						<Form.Item>
              <label htmlFor='comment'>Comment</label>
              <br />             
              {getFieldDecorator('comment', {
              rules:[],
              
              })
              ( <DatePicker format={'YYYY-MM-DD'} placeholder={"Comment"} id={"comment"} /> )}
              </Form.Item>

						<Form.Item>
              <label htmlFor='creditCardApprovalCode'>CreditCardApprovalCode</label>
              <br />             
              {getFieldDecorator('creditCardApprovalCode', {
              rules:[],
              
              })
              ( <DatePicker format={'YYYY-MM-DD'} placeholder={"CreditCardApprovalCode"} id={"creditCardApprovalCode"} /> )}
              </Form.Item>

						<Form.Item>
              <label htmlFor='creditCardID'>CreditCardID</label>
              <br />             
              {getFieldDecorator('creditCardID', {
              rules:[],
              
              })
              ( <DatePicker format={'YYYY-MM-DD'} placeholder={"CreditCardID"} id={"creditCardID"} /> )}
              </Form.Item>

						<Form.Item>
              <label htmlFor='currencyRateID'>CurrencyRateID</label>
              <br />             
              {getFieldDecorator('currencyRateID', {
              rules:[],
              
              })
              ( <DatePicker format={'YYYY-MM-DD'} placeholder={"CurrencyRateID"} id={"currencyRateID"} /> )}
              </Form.Item>

						<Form.Item>
              <label htmlFor='customerID'>CustomerID</label>
              <br />             
              {getFieldDecorator('customerID', {
              rules:[],
              
              })
              ( <DatePicker format={'YYYY-MM-DD'} placeholder={"CustomerID"} id={"customerID"} /> )}
              </Form.Item>

						<Form.Item>
              <label htmlFor='dueDate'>DueDate</label>
              <br />             
              {getFieldDecorator('dueDate', {
              rules:[],
              
              })
              ( <DatePicker format={'YYYY-MM-DD'} placeholder={"DueDate"} id={"dueDate"} /> )}
              </Form.Item>

						<Form.Item>
              <label htmlFor='freight'>Freight</label>
              <br />             
              {getFieldDecorator('freight', {
              rules:[],
              
              })
              ( <DatePicker format={'YYYY-MM-DD'} placeholder={"Freight"} id={"freight"} /> )}
              </Form.Item>

						<Form.Item>
              <label htmlFor='modifiedDate'>ModifiedDate</label>
              <br />             
              {getFieldDecorator('modifiedDate', {
              rules:[],
              
              })
              ( <DatePicker format={'YYYY-MM-DD'} placeholder={"ModifiedDate"} id={"modifiedDate"} /> )}
              </Form.Item>

						<Form.Item>
              <label htmlFor='onlineOrderFlag'>OnlineOrderFlag</label>
              <br />             
              {getFieldDecorator('onlineOrderFlag', {
              rules:[],
              
              })
              ( <DatePicker format={'YYYY-MM-DD'} placeholder={"OnlineOrderFlag"} id={"onlineOrderFlag"} /> )}
              </Form.Item>

						<Form.Item>
              <label htmlFor='orderDate'>OrderDate</label>
              <br />             
              {getFieldDecorator('orderDate', {
              rules:[],
              
              })
              ( <DatePicker format={'YYYY-MM-DD'} placeholder={"OrderDate"} id={"orderDate"} /> )}
              </Form.Item>

						<Form.Item>
              <label htmlFor='purchaseOrderNumber'>PurchaseOrderNumber</label>
              <br />             
              {getFieldDecorator('purchaseOrderNumber', {
              rules:[],
              
              })
              ( <DatePicker format={'YYYY-MM-DD'} placeholder={"PurchaseOrderNumber"} id={"purchaseOrderNumber"} /> )}
              </Form.Item>

						<Form.Item>
              <label htmlFor='revisionNumber'>RevisionNumber</label>
              <br />             
              {getFieldDecorator('revisionNumber', {
              rules:[],
              
              })
              ( <DatePicker format={'YYYY-MM-DD'} placeholder={"RevisionNumber"} id={"revisionNumber"} /> )}
              </Form.Item>

						<Form.Item>
              <label htmlFor='rowguid'>rowguid</label>
              <br />             
              {getFieldDecorator('rowguid', {
              rules:[],
              
              })
              ( <DatePicker format={'YYYY-MM-DD'} placeholder={"rowguid"} id={"rowguid"} /> )}
              </Form.Item>

						<Form.Item>
              <label htmlFor='salesOrderNumber'>SalesOrderNumber</label>
              <br />             
              {getFieldDecorator('salesOrderNumber', {
              rules:[],
              
              })
              ( <DatePicker format={'YYYY-MM-DD'} placeholder={"SalesOrderNumber"} id={"salesOrderNumber"} /> )}
              </Form.Item>

						<Form.Item>
              <label htmlFor='salesPersonID'>SalesPersonID</label>
              <br />             
              {getFieldDecorator('salesPersonID', {
              rules:[],
              
              })
              ( <DatePicker format={'YYYY-MM-DD'} placeholder={"SalesPersonID"} id={"salesPersonID"} /> )}
              </Form.Item>

						<Form.Item>
              <label htmlFor='shipDate'>ShipDate</label>
              <br />             
              {getFieldDecorator('shipDate', {
              rules:[],
              
              })
              ( <DatePicker format={'YYYY-MM-DD'} placeholder={"ShipDate"} id={"shipDate"} /> )}
              </Form.Item>

						<Form.Item>
              <label htmlFor='shipMethodID'>ShipMethodID</label>
              <br />             
              {getFieldDecorator('shipMethodID', {
              rules:[],
              
              })
              ( <DatePicker format={'YYYY-MM-DD'} placeholder={"ShipMethodID"} id={"shipMethodID"} /> )}
              </Form.Item>

						<Form.Item>
              <label htmlFor='shipToAddressID'>ShipToAddressID</label>
              <br />             
              {getFieldDecorator('shipToAddressID', {
              rules:[],
              
              })
              ( <DatePicker format={'YYYY-MM-DD'} placeholder={"ShipToAddressID"} id={"shipToAddressID"} /> )}
              </Form.Item>

						<Form.Item>
              <label htmlFor='status'>Status</label>
              <br />             
              {getFieldDecorator('status', {
              rules:[],
              
              })
              ( <DatePicker format={'YYYY-MM-DD'} placeholder={"Status"} id={"status"} /> )}
              </Form.Item>

						<Form.Item>
              <label htmlFor='subTotal'>SubTotal</label>
              <br />             
              {getFieldDecorator('subTotal', {
              rules:[],
              
              })
              ( <DatePicker format={'YYYY-MM-DD'} placeholder={"SubTotal"} id={"subTotal"} /> )}
              </Form.Item>

						<Form.Item>
              <label htmlFor='taxAmt'>TaxAmt</label>
              <br />             
              {getFieldDecorator('taxAmt', {
              rules:[],
              
              })
              ( <DatePicker format={'YYYY-MM-DD'} placeholder={"TaxAmt"} id={"taxAmt"} /> )}
              </Form.Item>

						<Form.Item>
              <label htmlFor='territoryID'>TerritoryID</label>
              <br />             
              {getFieldDecorator('territoryID', {
              rules:[],
              
              })
              ( <DatePicker format={'YYYY-MM-DD'} placeholder={"TerritoryID"} id={"territoryID"} /> )}
              </Form.Item>

						<Form.Item>
              <label htmlFor='totalDue'>TotalDue</label>
              <br />             
              {getFieldDecorator('totalDue', {
              rules:[],
              
              })
              ( <DatePicker format={'YYYY-MM-DD'} placeholder={"TotalDue"} id={"totalDue"} /> )}
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

export const WrappedSalesOrderHeaderCreateComponent = Form.create({ name: 'SalesOrderHeader Create' })(SalesOrderHeaderCreateComponent);

/*<Codenesium>
    <Hash>4fe5c25dd8e378e7734dae91de961fef</Hash>
</Codenesium>*/