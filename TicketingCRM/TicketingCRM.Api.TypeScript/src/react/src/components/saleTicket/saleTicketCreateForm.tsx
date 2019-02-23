import React, { Component, FormEvent } from 'react';
import axios from 'axios';
import { CreateResponse } from '../../api/apiObjects';
import { Constants, ApiRoutes, ClientRoutes } from '../../constants';
import * as Api from '../../api/models';
import SaleTicketMapper from './saleTicketMapper';
import SaleTicketViewModel from './saleTicketViewModel';
import { Form, Input, Button, Switch, InputNumber, DatePicker, Spin, Alert, TimePicker } from 'antd';
import { WrappedFormUtils } from 'antd/es/form/Form';

interface SaleTicketCreateComponentProps {
  form:WrappedFormUtils;
  history:any;
  match:any;
}

interface SaleTicketCreateComponentState {
  model?: SaleTicketViewModel;
  loading: boolean;
  loaded: boolean;
  errorOccurred: boolean;
  errorMessage: string;
  submitted:boolean;
}

class SaleTicketCreateComponent extends React.Component<
  SaleTicketCreateComponentProps,
  SaleTicketCreateComponentState
> {
  state = {
    model: new SaleTicketViewModel(),
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
        let model = values as SaleTicketViewModel;
        console.log('Received values of form: ', model);
        this.submit(model);
      }
    });
  };

  submit = (model:SaleTicketViewModel) =>
  {  
    let mapper = new SaleTicketMapper();
     axios
      .post(
        Constants.ApiEndpoint + ApiRoutes.SaleTickets,
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
            Api.SaleTicketClientRequestModel
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
              <label htmlFor='saleId'>saleId</label>
              <br />             
              {getFieldDecorator('saleId', {
              rules:[{ required: true, message: 'Required' },
],
              
              })
              ( <Input placeholder={"saleId"} /> )}
              </Form.Item>

						<Form.Item>
              <label htmlFor='ticketId'>ticketId</label>
              <br />             
              {getFieldDecorator('ticketId', {
              rules:[{ required: true, message: 'Required' },
],
              
              })
              ( <Input placeholder={"ticketId"} /> )}
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

export const WrappedSaleTicketCreateComponent = Form.create({ name: 'SaleTicket Create' })(SaleTicketCreateComponent);

/*<Codenesium>
    <Hash>cba98059ff46eb4c3c4031cdd1cfe494</Hash>
</Codenesium>*/