import React, { Component, FormEvent } from 'react';
import axios from 'axios';
import { ActionResponse, CreateResponse } from '../../api/apiObjects';
import { Constants, ApiRoutes, ClientRoutes } from '../../constants';
import * as Api from '../../api/models';
import EventMapper from './eventMapper';
import EventViewModel from './eventViewModel';
import { Form, Input, Button, Switch, InputNumber, DatePicker, Spin, Alert, TimePicker } from 'antd';
import { WrappedFormUtils } from 'antd/es/form/Form';
import { ToLowerCaseFirstLetter } from '../../lib/stringUtilities';
import { EventStatusSelectComponent } from '../shared/eventStatusSelect'
	
interface EventCreateComponentProps {
  form:WrappedFormUtils;
  history:any;
  match:any;
}

interface EventCreateComponentState {
  model?: EventViewModel;
  loading: boolean;
  loaded: boolean;
  errorOccurred: boolean;
  errorMessage: string;
  submitted:boolean;
  submitting:boolean;
}

class EventCreateComponent extends React.Component<
  EventCreateComponentProps,
  EventCreateComponentState
> {
  state = {
    model: new EventViewModel(),
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
        let model = values as EventViewModel;
        console.log('Received values of form: ', model);
        this.submit(model);
      }
	  else {
	      this.setState({...this.state, submitting:false, submitted:false});
	  }
    });
  };

  submit = (model:EventViewModel) =>
  {  
    let mapper = new EventMapper();
     axios
      .post(
        Constants.ApiEndpoint + ApiRoutes.Events,
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
            Api.EventClientRequestModel
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
              <label htmlFor='actualEndDate'>Actual End Date</label>
              <br />             
              {getFieldDecorator('actualEndDate', {
              rules:[],
              
              })
              ( <DatePicker format={'YYYY-MM-DD'} placeholder={"Actual End Date"} /> )}
              </Form.Item>

						<Form.Item>
              <label htmlFor='actualStartDate'>Actual Start Date</label>
              <br />             
              {getFieldDecorator('actualStartDate', {
              rules:[],
              
              })
              ( <DatePicker format={'YYYY-MM-DD'} placeholder={"Actual Start Date"} /> )}
              </Form.Item>

						<Form.Item>
              <label htmlFor='billAmount'>Bill Amount</label>
              <br />             
              {getFieldDecorator('billAmount', {
              rules:[],
              
              })
              ( <InputNumber placeholder={"Bill Amount"} /> )}
              </Form.Item>

						<Form.Item>
              <label htmlFor='eventStatusId'>Event Status</label>
              <br />             
              {getFieldDecorator('eventStatusId', {
              rules:[{ required: true, message: 'Required' },
],
              
              })
              ( <InputNumber placeholder={"Event Status"} /> )}
              </Form.Item>

						<Form.Item>
              <label htmlFor='scheduledEndDate'>Scheduled End Date</label>
              <br />             
              {getFieldDecorator('scheduledEndDate', {
              rules:[],
              
              })
              ( <DatePicker format={'YYYY-MM-DD'} placeholder={"Scheduled End Date"} /> )}
              </Form.Item>

						<Form.Item>
              <label htmlFor='scheduledStartDate'>Scheduled Start Date</label>
              <br />             
              {getFieldDecorator('scheduledStartDate', {
              rules:[],
              
              })
              ( <DatePicker format={'YYYY-MM-DD'} placeholder={"Scheduled Start Date"} /> )}
              </Form.Item>

						<Form.Item>
              <label htmlFor='studentNote'>Student Note</label>
              <br />             
              {getFieldDecorator('studentNote', {
              rules:[],
              
              })
              ( <Input placeholder={"Student Note"} /> )}
              </Form.Item>

						<Form.Item>
              <label htmlFor='teacherNote'>Teacher Note</label>
              <br />             
              {getFieldDecorator('teacherNote', {
              rules:[],
              
              })
              ( <Input placeholder={"Teacher Note"} /> )}
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

export const WrappedEventCreateComponent = Form.create({ name: 'Event Create' })(EventCreateComponent);

/*<Codenesium>
    <Hash>5962c22df0b395d09626683abf830574</Hash>
</Codenesium>*/