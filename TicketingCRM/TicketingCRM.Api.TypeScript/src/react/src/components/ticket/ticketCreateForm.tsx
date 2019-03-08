import React, { Component, FormEvent } from 'react';
import axios from 'axios';
import { ActionResponse, CreateResponse } from '../../api/apiObjects';
import { Constants, ApiRoutes, ClientRoutes } from '../../constants';
import * as Api from '../../api/models';
import TicketMapper from './ticketMapper';
import TicketViewModel from './ticketViewModel';
import { Form, Input, Button, Switch, InputNumber, DatePicker, Spin, Alert, TimePicker } from 'antd';
import { WrappedFormUtils } from 'antd/es/form/Form';
import { ToLowerCaseFirstLetter } from '../../lib/stringUtilities';
import { TicketStatusSelectComponent } from '../shared/ticketStatusSelect'
	
interface TicketCreateComponentProps {
  form:WrappedFormUtils;
  history:any;
  match:any;
}

interface TicketCreateComponentState {
  model?: TicketViewModel;
  loading: boolean;
  loaded: boolean;
  errorOccurred: boolean;
  errorMessage: string;
  submitted:boolean;
  submitting:boolean;
}

class TicketCreateComponent extends React.Component<
  TicketCreateComponentProps,
  TicketCreateComponentState
> {
  state = {
    model: new TicketViewModel(),
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
        let model = values as TicketViewModel;
        console.log('Received values of form: ', model);
        this.submit(model);
      }
	  else {
	      this.setState({...this.state, submitting:false, submitted:false});
	  }
    });
  };

  submit = (model:TicketViewModel) =>
  {  
    let mapper = new TicketMapper();
     axios
      .post(
        Constants.ApiEndpoint + ApiRoutes.Tickets,
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
            Api.TicketClientRequestModel
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
              <label htmlFor='publicId'>Public</label>
              <br />             
              {getFieldDecorator('publicId', {
              rules:[{ required: true, message: 'Required' },
{ max: 8, message: 'Exceeds max length of 8' },
],
              
              })
              ( <Input placeholder={"Public"} /> )}
              </Form.Item>

						
                        <Form.Item>
                        <label htmlFor='ticketStatusId'>Ticket Status</label>
                        <br />   
                        <TicketStatusSelectComponent   
                          apiRoute={
                          Constants.ApiEndpoint +
                          ApiRoutes.TicketStatus}
                          getFieldDecorator={this.props.form.getFieldDecorator}
                          propertyName="ticketStatusId"
                          required={true}
                          selectedValue={this.state.model!.ticketStatusId}
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

export const WrappedTicketCreateComponent = Form.create({ name: 'Ticket Create' })(TicketCreateComponent);

/*<Codenesium>
    <Hash>1985c3d56e3e63f938cca6e1547c9425</Hash>
</Codenesium>*/