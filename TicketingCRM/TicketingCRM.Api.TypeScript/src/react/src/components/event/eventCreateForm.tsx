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
import { CitySelectComponent } from '../shared/citySelect'
	
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
	submitted:false
  };

 handleSubmit = (e:FormEvent<HTMLFormElement>) => {
     e.preventDefault();
     this.props.form.validateFields((err:any, values:any) => {
      if (!err) {
        let model = values as EventViewModel;
        console.log('Received values of form: ', model);
        this.submit(model);
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
              <label htmlFor='address1'>address1</label>
              <br />             
              {getFieldDecorator('address1', {
              rules:[{ required: true, message: 'Required' },
{ max: 128, message: 'Exceeds max length of 128' },
],
              
              })
              ( <Input placeholder={"address1"} /> )}
              </Form.Item>

						<Form.Item>
              <label htmlFor='address2'>address2</label>
              <br />             
              {getFieldDecorator('address2', {
              rules:[{ required: true, message: 'Required' },
{ max: 128, message: 'Exceeds max length of 128' },
],
              
              })
              ( <Input placeholder={"address2"} /> )}
              </Form.Item>

						<Form.Item>
              <label htmlFor='cityId'>cityId</label>
              <br />             
              {getFieldDecorator('cityId', {
              rules:[{ required: true, message: 'Required' },
],
              
              })
              ( <Input placeholder={"cityId"} /> )}
              </Form.Item>

						<Form.Item>
              <label htmlFor='date'>date</label>
              <br />             
              {getFieldDecorator('date', {
              rules:[{ required: true, message: 'Required' },
],
              
              })
              ( <DatePicker format={'YYYY-MM-DD'} placeholder={"date"} /> )}
              </Form.Item>

						<Form.Item>
              <label htmlFor='description'>description</label>
              <br />             
              {getFieldDecorator('description', {
              rules:[{ required: true, message: 'Required' },
],
              
              })
              ( <Input placeholder={"description"} /> )}
              </Form.Item>

						<Form.Item>
              <label htmlFor='endDate'>endDate</label>
              <br />             
              {getFieldDecorator('endDate', {
              rules:[{ required: true, message: 'Required' },
],
              
              })
              ( <DatePicker format={'YYYY-MM-DD'} placeholder={"endDate"} /> )}
              </Form.Item>

						<Form.Item>
              <label htmlFor='facebook'>facebook</label>
              <br />             
              {getFieldDecorator('facebook', {
              rules:[{ required: true, message: 'Required' },
{ max: 128, message: 'Exceeds max length of 128' },
],
              
              })
              ( <Input placeholder={"facebook"} /> )}
              </Form.Item>

						<Form.Item>
              <label htmlFor='name'>name</label>
              <br />             
              {getFieldDecorator('name', {
              rules:[{ required: true, message: 'Required' },
{ max: 128, message: 'Exceeds max length of 128' },
],
              
              })
              ( <Input placeholder={"name"} /> )}
              </Form.Item>

						<Form.Item>
              <label htmlFor='startDate'>startDate</label>
              <br />             
              {getFieldDecorator('startDate', {
              rules:[{ required: true, message: 'Required' },
],
              
              })
              ( <DatePicker format={'YYYY-MM-DD'} placeholder={"startDate"} /> )}
              </Form.Item>

						<Form.Item>
              <label htmlFor='website'>website</label>
              <br />             
              {getFieldDecorator('website', {
              rules:[{ required: true, message: 'Required' },
{ max: 128, message: 'Exceeds max length of 128' },
],
              
              })
              ( <Input placeholder={"website"} /> )}
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

export const WrappedEventCreateComponent = Form.create({ name: 'Event Create' })(EventCreateComponent);

/*<Codenesium>
    <Hash>8fe22667229372c02c929e5f82983805</Hash>
</Codenesium>*/