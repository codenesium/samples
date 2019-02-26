import React, { Component, FormEvent } from 'react';
import axios from 'axios';
import { CreateResponse } from '../../api/apiObjects';
import { Constants, ApiRoutes, ClientRoutes } from '../../constants';
import * as Api from '../../api/models';
import TransactionHistoryMapper from './transactionHistoryMapper';
import TransactionHistoryViewModel from './transactionHistoryViewModel';
import { Form, Input, Button, Switch, InputNumber, DatePicker, Spin, Alert, TimePicker } from 'antd';
import { WrappedFormUtils } from 'antd/es/form/Form';
import { ProductSelectComponent } from '../shared/productSelect'
	
interface TransactionHistoryCreateComponentProps {
  form:WrappedFormUtils;
  history:any;
  match:any;
}

interface TransactionHistoryCreateComponentState {
  model?: TransactionHistoryViewModel;
  loading: boolean;
  loaded: boolean;
  errorOccurred: boolean;
  errorMessage: string;
  submitted:boolean;
}

class TransactionHistoryCreateComponent extends React.Component<
  TransactionHistoryCreateComponentProps,
  TransactionHistoryCreateComponentState
> {
  state = {
    model: new TransactionHistoryViewModel(),
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
        let model = values as TransactionHistoryViewModel;
        console.log('Received values of form: ', model);
        this.submit(model);
      }
    });
  };

  submit = (model:TransactionHistoryViewModel) =>
  {  
    let mapper = new TransactionHistoryMapper();
     axios
      .post(
        Constants.ApiEndpoint + ApiRoutes.TransactionHistories,
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
            Api.TransactionHistoryClientRequestModel
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
              <label htmlFor='actualCost'>ActualCost</label>
              <br />             
              {getFieldDecorator('actualCost', {
              rules:[{ required: true, message: 'Required' },
],
              
              })
              ( <DatePicker format={'YYYY-MM-DD'} placeholder={"ActualCost"} /> )}
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
              <label htmlFor='productID'>ProductID</label>
              <br />             
              {getFieldDecorator('productID', {
              rules:[{ required: true, message: 'Required' },
],
              
              })
              ( <DatePicker format={'YYYY-MM-DD'} placeholder={"ProductID"} /> )}
              </Form.Item>

						<Form.Item>
              <label htmlFor='quantity'>Quantity</label>
              <br />             
              {getFieldDecorator('quantity', {
              rules:[{ required: true, message: 'Required' },
],
              
              })
              ( <DatePicker format={'YYYY-MM-DD'} placeholder={"Quantity"} /> )}
              </Form.Item>

						<Form.Item>
              <label htmlFor='referenceOrderID'>ReferenceOrderID</label>
              <br />             
              {getFieldDecorator('referenceOrderID', {
              rules:[{ required: true, message: 'Required' },
],
              
              })
              ( <DatePicker format={'YYYY-MM-DD'} placeholder={"ReferenceOrderID"} /> )}
              </Form.Item>

						<Form.Item>
              <label htmlFor='referenceOrderLineID'>ReferenceOrderLineID</label>
              <br />             
              {getFieldDecorator('referenceOrderLineID', {
              rules:[{ required: true, message: 'Required' },
],
              
              })
              ( <DatePicker format={'YYYY-MM-DD'} placeholder={"ReferenceOrderLineID"} /> )}
              </Form.Item>

						<Form.Item>
              <label htmlFor='transactionDate'>TransactionDate</label>
              <br />             
              {getFieldDecorator('transactionDate', {
              rules:[{ required: true, message: 'Required' },
],
              
              })
              ( <DatePicker format={'YYYY-MM-DD'} placeholder={"TransactionDate"} /> )}
              </Form.Item>

						<Form.Item>
              <label htmlFor='transactionType'>TransactionType</label>
              <br />             
              {getFieldDecorator('transactionType', {
              rules:[{ required: true, message: 'Required' },
{ max: 1, message: 'Exceeds max length of 1' },
],
              
              })
              ( <DatePicker format={'YYYY-MM-DD'} placeholder={"TransactionType"} /> )}
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

export const WrappedTransactionHistoryCreateComponent = Form.create({ name: 'TransactionHistory Create' })(TransactionHistoryCreateComponent);

/*<Codenesium>
    <Hash>0df752a9897dac7289217eb35c9d9a91</Hash>
</Codenesium>*/