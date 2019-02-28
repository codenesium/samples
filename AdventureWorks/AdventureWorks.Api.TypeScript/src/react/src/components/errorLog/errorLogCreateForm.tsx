import React, { Component, FormEvent } from 'react';
import axios from 'axios';
import { ActionResponse, CreateResponse } from '../../api/apiObjects';
import { Constants, ApiRoutes, ClientRoutes } from '../../constants';
import * as Api from '../../api/models';
import ErrorLogMapper from './errorLogMapper';
import ErrorLogViewModel from './errorLogViewModel';
import { Form, Input, Button, Switch, InputNumber, DatePicker, Spin, Alert, TimePicker } from 'antd';
import { WrappedFormUtils } from 'antd/es/form/Form';
import { ToLowerCaseFirstLetter } from '../../lib/stringUtilities';

interface ErrorLogCreateComponentProps {
  form:WrappedFormUtils;
  history:any;
  match:any;
}

interface ErrorLogCreateComponentState {
  model?: ErrorLogViewModel;
  loading: boolean;
  loaded: boolean;
  errorOccurred: boolean;
  errorMessage: string;
  submitted:boolean;
  submitting:boolean;
}

class ErrorLogCreateComponent extends React.Component<
  ErrorLogCreateComponentProps,
  ErrorLogCreateComponentState
> {
  state = {
    model: new ErrorLogViewModel(),
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
        let model = values as ErrorLogViewModel;
        console.log('Received values of form: ', model);
        this.submit(model);
      }
	  else {
	      this.setState({...this.state, submitting:false, submitted:false});
	  }
    });
  };

  submit = (model:ErrorLogViewModel) =>
  {  
    let mapper = new ErrorLogMapper();
     axios
      .post(
        Constants.ApiEndpoint + ApiRoutes.ErrorLogs,
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
            Api.ErrorLogClientRequestModel
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
              <label htmlFor='errorLine'>ErrorLine</label>
              <br />             
              {getFieldDecorator('errorLine', {
              rules:[],
              
              })
              ( <DatePicker format={'YYYY-MM-DD'} placeholder={"ErrorLine"} /> )}
              </Form.Item>

						<Form.Item>
              <label htmlFor='errorMessage'>ErrorMessage</label>
              <br />             
              {getFieldDecorator('errorMessage', {
              rules:[{ required: true, message: 'Required' },
{ max: 4000, message: 'Exceeds max length of 4000' },
],
              
              })
              ( <DatePicker format={'YYYY-MM-DD'} placeholder={"ErrorMessage"} /> )}
              </Form.Item>

						<Form.Item>
              <label htmlFor='errorNumber'>ErrorNumber</label>
              <br />             
              {getFieldDecorator('errorNumber', {
              rules:[{ required: true, message: 'Required' },
],
              
              })
              ( <DatePicker format={'YYYY-MM-DD'} placeholder={"ErrorNumber"} /> )}
              </Form.Item>

						<Form.Item>
              <label htmlFor='errorProcedure'>ErrorProcedure</label>
              <br />             
              {getFieldDecorator('errorProcedure', {
              rules:[{ max: 126, message: 'Exceeds max length of 126' },
],
              
              })
              ( <DatePicker format={'YYYY-MM-DD'} placeholder={"ErrorProcedure"} /> )}
              </Form.Item>

						<Form.Item>
              <label htmlFor='errorSeverity'>ErrorSeverity</label>
              <br />             
              {getFieldDecorator('errorSeverity', {
              rules:[],
              
              })
              ( <DatePicker format={'YYYY-MM-DD'} placeholder={"ErrorSeverity"} /> )}
              </Form.Item>

						<Form.Item>
              <label htmlFor='errorState'>ErrorState</label>
              <br />             
              {getFieldDecorator('errorState', {
              rules:[],
              
              })
              ( <DatePicker format={'YYYY-MM-DD'} placeholder={"ErrorState"} /> )}
              </Form.Item>

						<Form.Item>
              <label htmlFor='errorTime'>ErrorTime</label>
              <br />             
              {getFieldDecorator('errorTime', {
              rules:[{ required: true, message: 'Required' },
],
              
              })
              ( <DatePicker format={'YYYY-MM-DD'} placeholder={"ErrorTime"} /> )}
              </Form.Item>

						<Form.Item>
              <label htmlFor='userName'>UserName</label>
              <br />             
              {getFieldDecorator('userName', {
              rules:[{ required: true, message: 'Required' },
{ max: 128, message: 'Exceeds max length of 128' },
],
              
              })
              ( <DatePicker format={'YYYY-MM-DD'} placeholder={"UserName"} /> )}
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

export const WrappedErrorLogCreateComponent = Form.create({ name: 'ErrorLog Create' })(ErrorLogCreateComponent);

/*<Codenesium>
    <Hash>33aa7d3a64a635d3afb9998c79521d9e</Hash>
</Codenesium>*/