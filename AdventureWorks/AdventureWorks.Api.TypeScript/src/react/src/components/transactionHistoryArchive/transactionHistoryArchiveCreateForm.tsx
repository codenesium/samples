import React, { Component, FormEvent } from 'react';
import axios from 'axios';
import { ActionResponse, CreateResponse } from '../../api/apiObjects';
import { Constants, ApiRoutes, ClientRoutes } from '../../constants';
import * as Api from '../../api/models';
import TransactionHistoryArchiveMapper from './transactionHistoryArchiveMapper';
import TransactionHistoryArchiveViewModel from './transactionHistoryArchiveViewModel';
import { Form, Input, Button, Switch, InputNumber, DatePicker, Spin, Alert, TimePicker } from 'antd';
import { WrappedFormUtils } from 'antd/es/form/Form';
import { ToLowerCaseFirstLetter } from '../../lib/stringUtilities';

interface TransactionHistoryArchiveCreateComponentProps {
  form:WrappedFormUtils;
  history:any;
  match:any;
}

interface TransactionHistoryArchiveCreateComponentState {
  model?: TransactionHistoryArchiveViewModel;
  loading: boolean;
  loaded: boolean;
  errorOccurred: boolean;
  errorMessage: string;
  submitted:boolean;
}

class TransactionHistoryArchiveCreateComponent extends React.Component<
  TransactionHistoryArchiveCreateComponentProps,
  TransactionHistoryArchiveCreateComponentState
> {
  state = {
    model: new TransactionHistoryArchiveViewModel(),
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
        let model = values as TransactionHistoryArchiveViewModel;
        console.log('Received values of form: ', model);
        this.submit(model);
      }
    });
  };

  submit = (model:TransactionHistoryArchiveViewModel) =>
  {  
    let mapper = new TransactionHistoryArchiveMapper();
     axios
      .post(
        Constants.ApiEndpoint + ApiRoutes.TransactionHistoryArchives,
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
            Api.TransactionHistoryArchiveClientRequestModel
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

export const WrappedTransactionHistoryArchiveCreateComponent = Form.create({ name: 'TransactionHistoryArchive Create' })(TransactionHistoryArchiveCreateComponent);

/*<Codenesium>
    <Hash>5bad2b946e6a3d88350731e3b33b85b1</Hash>
</Codenesium>*/