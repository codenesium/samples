import React, { Component, FormEvent } from 'react';
import axios from 'axios';
import { CreateResponse } from '../../api/apiObjects';
import { Constants, ApiRoutes, ClientRoutes } from '../../constants';
import * as Api from '../../api/models';
import SalesTaxRateMapper from './salesTaxRateMapper';
import SalesTaxRateViewModel from './salesTaxRateViewModel';
import { Form, Input, Button, Switch, InputNumber, DatePicker, Spin, Alert, TimePicker } from 'antd';
import { WrappedFormUtils } from 'antd/es/form/Form';

interface SalesTaxRateCreateComponentProps {
  form:WrappedFormUtils;
  history:any;
  match:any;
}

interface SalesTaxRateCreateComponentState {
  model?: SalesTaxRateViewModel;
  loading: boolean;
  loaded: boolean;
  errorOccurred: boolean;
  errorMessage: string;
  submitted:boolean;
}

class SalesTaxRateCreateComponent extends React.Component<
  SalesTaxRateCreateComponentProps,
  SalesTaxRateCreateComponentState
> {
  state = {
    model: new SalesTaxRateViewModel(),
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
        let model = values as SalesTaxRateViewModel;
        console.log('Received values of form: ', model);
        this.submit(model);
      }
    });
  };

  submit = (model:SalesTaxRateViewModel) =>
  {  
    let mapper = new SalesTaxRateMapper();
     axios
      .post(
        Constants.ApiEndpoint + ApiRoutes.SalesTaxRates,
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
            Api.SalesTaxRateClientRequestModel
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
              <label htmlFor='modifiedDate'>ModifiedDate</label>
              <br />             
              {getFieldDecorator('modifiedDate', {
              rules:[{ required: true, message: 'Required' },
{ whitespace: true, message: 'Required' },
],
              
              })
              ( <DatePicker format={'YYYY-MM-DD'} placeholder={"ModifiedDate"} /> )}
              </Form.Item>

						<Form.Item>
              <label htmlFor='name'>Name</label>
              <br />             
              {getFieldDecorator('name', {
              rules:[{ required: true, message: 'Required' },
{ whitespace: true, message: 'Required' },
{ max: 50, message: 'Exceeds max length of 50' },
],
              
              })
              ( <DatePicker format={'YYYY-MM-DD'} placeholder={"Name"} /> )}
              </Form.Item>

						<Form.Item>
              <label htmlFor='rowguid'>rowguid</label>
              <br />             
              {getFieldDecorator('rowguid', {
              rules:[{ required: true, message: 'Required' },
{ whitespace: true, message: 'Required' },
],
              
              })
              ( <DatePicker format={'YYYY-MM-DD'} placeholder={"rowguid"} /> )}
              </Form.Item>

						<Form.Item>
              <label htmlFor='stateProvinceID'>StateProvinceID</label>
              <br />             
              {getFieldDecorator('stateProvinceID', {
              rules:[{ required: true, message: 'Required' },
{ whitespace: true, message: 'Required' },
],
              
              })
              ( <DatePicker format={'YYYY-MM-DD'} placeholder={"StateProvinceID"} /> )}
              </Form.Item>

						<Form.Item>
              <label htmlFor='taxRate'>TaxRate</label>
              <br />             
              {getFieldDecorator('taxRate', {
              rules:[{ required: true, message: 'Required' },
{ whitespace: true, message: 'Required' },
],
              
              })
              ( <DatePicker format={'YYYY-MM-DD'} placeholder={"TaxRate"} /> )}
              </Form.Item>

						<Form.Item>
              <label htmlFor='taxType'>TaxType</label>
              <br />             
              {getFieldDecorator('taxType', {
              rules:[{ required: true, message: 'Required' },
{ whitespace: true, message: 'Required' },
],
              
              })
              ( <DatePicker format={'YYYY-MM-DD'} placeholder={"TaxType"} /> )}
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

export const WrappedSalesTaxRateCreateComponent = Form.create({ name: 'SalesTaxRate Create' })(SalesTaxRateCreateComponent);

/*<Codenesium>
    <Hash>fa72a1176db7ba15c6404e484808b3fd</Hash>
</Codenesium>*/