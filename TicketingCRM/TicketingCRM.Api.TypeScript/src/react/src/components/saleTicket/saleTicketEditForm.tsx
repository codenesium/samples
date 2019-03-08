import React, { Component, FormEvent } from 'react';
import axios from 'axios';
import { ActionResponse, CreateResponse } from '../../api/apiObjects';
import { Constants, ApiRoutes, ClientRoutes } from '../../constants';
import * as Api from '../../api/models';
import SaleTicketMapper from './saleTicketMapper';
import SaleTicketViewModel from './saleTicketViewModel';
import { Form, Input, Button, Switch, InputNumber, DatePicker, Spin, Alert, TimePicker } from 'antd';
import { WrappedFormUtils } from 'antd/es/form/Form';
import { ToLowerCaseFirstLetter } from '../../lib/stringUtilities';
import { SaleSelectComponent } from '../shared/saleSelect'
	import { TicketSelectComponent } from '../shared/ticketSelect'
	interface SaleTicketEditComponentProps {
  form:WrappedFormUtils;
  history:any;
  match:any;
}

interface SaleTicketEditComponentState {
  model?: SaleTicketViewModel;
  loading: boolean;
  loaded: boolean;
  errorOccurred: boolean;
  errorMessage: string;
  submitted:boolean;
  submitting:boolean;
}

class SaleTicketEditComponent extends React.Component<
  SaleTicketEditComponentProps,
  SaleTicketEditComponentState
> {
  state = {
    model: new SaleTicketViewModel(),
    loading: false,
    loaded: true,
    errorOccurred: false,
    errorMessage: '',
	submitted:false,
	submitting:false
  };

    componentDidMount() {
    this.setState({ ...this.state, loading: true });

    axios
      .get(
        Constants.ApiEndpoint +
          ApiRoutes.SaleTickets +
          '/' +
          this.props.match.params.id,
        {
          headers: {
            'Content-Type': 'application/json',
          },
        }
      )
      .then(
        resp => {
          let response = resp.data as Api.SaleTicketClientResponseModel;

          console.log(response);

          let mapper = new SaleTicketMapper();

          this.setState({
            model: mapper.mapApiResponseToViewModel(response),
            loading: false,
            loaded: true,
            errorOccurred: false,
            errorMessage: '',
          });

		  this.props.form.setFieldsValue(mapper.mapApiResponseToViewModel(response));
        },
        error => {
          console.log(error);
          this.setState({
            model: undefined,
            loading: false,
            loaded: false,
            errorOccurred: true,
            errorMessage: 'Error from API',
          });
        }
      );
 }
 
 handleSubmit = (e:FormEvent<HTMLFormElement>) => {
     e.preventDefault();
	 this.setState({...this.state, submitting:true, submitted:false});
     this.props.form.validateFields((err:any, values:any) => {
     if (!err) {
        let model = values as SaleTicketViewModel;
        console.log('Received values of form: ', model);
        this.submit(model);
      } 
	  else {
		  this.setState({...this.state, submitting:false, submitted:false});
	  }
    });
  };

  submit = (model:SaleTicketViewModel) =>
  {  
    let mapper = new SaleTicketMapper();
     axios
      .put(
        Constants.ApiEndpoint + ApiRoutes.SaleTickets + '/' + this.state.model!.id,
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
          this.setState({...this.state, submitted:true, submitting:false, model:mapper.mapApiResponseToViewModel(response.record!), errorOccurred:false, errorMessage:''});
          console.log(response);
        },
        error => {
          console.log(error);
		  let errorResponse = error.response.data as ActionResponse; 
		  if(error.response.data)
          {
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
                        <label htmlFor='saleId'>Sale</label>
                        <br />   
                        <SaleSelectComponent   
                          apiRoute={
                          Constants.ApiEndpoint +
                          ApiRoutes.Sales}
                          getFieldDecorator={this.props.form.getFieldDecorator}
                          propertyName="saleId"
                          required={true}
                          selectedValue={this.state.model!.saleId}
                         />
                        </Form.Item>

						
                        <Form.Item>
                        <label htmlFor='ticketId'>Ticket</label>
                        <br />   
                        <TicketSelectComponent   
                          apiRoute={
                          Constants.ApiEndpoint +
                          ApiRoutes.Tickets}
                          getFieldDecorator={this.props.form.getFieldDecorator}
                          propertyName="ticketId"
                          required={true}
                          selectedValue={this.state.model!.ticketId}
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

export const WrappedSaleTicketEditComponent = Form.create({ name: 'SaleTicket Edit' })(SaleTicketEditComponent);

/*<Codenesium>
    <Hash>e424ecda7504a25ebf8c116f0fc7532a</Hash>
</Codenesium>*/