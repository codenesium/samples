import React, { Component, FormEvent } from 'react';
import axios from 'axios';
import { ActionResponse, CreateResponse } from '../../api/apiObjects';
import { Constants, ApiRoutes, ClientRoutes } from '../../constants';
import * as Api from '../../api/models';
import SelfReferenceMapper from './selfReferenceMapper';
import SelfReferenceViewModel from './selfReferenceViewModel';
import { Form, Input, Button, Switch, InputNumber, DatePicker, Spin, Alert, TimePicker } from 'antd';
import { WrappedFormUtils } from 'antd/es/form/Form';
import { ToLowerCaseFirstLetter } from '../../lib/stringUtilities';

interface SelfReferenceCreateComponentProps {
  form:WrappedFormUtils;
  history:any;
  match:any;
}

interface SelfReferenceCreateComponentState {
  model?: SelfReferenceViewModel;
  loading: boolean;
  loaded: boolean;
  errorOccurred: boolean;
  errorMessage: string;
  submitted:boolean;
  submitting:boolean;
}

class SelfReferenceCreateComponent extends React.Component<
  SelfReferenceCreateComponentProps,
  SelfReferenceCreateComponentState
> {
  state = {
    model: new SelfReferenceViewModel(),
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
        let model = values as SelfReferenceViewModel;
        console.log('Received values of form: ', model);
        this.submit(model);
      }
	  else {
	      this.setState({...this.state, submitting:false, submitted:false});
	  }
    });
  };

  submit = (model:SelfReferenceViewModel) =>
  {  
    let mapper = new SelfReferenceMapper();
     axios
      .post(
        Constants.ApiEndpoint + ApiRoutes.SelfReferences,
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
            Api.SelfReferenceClientRequestModel
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
              <label htmlFor='selfReferenceId'>SelfReferenceId</label>
              <br />             
              {getFieldDecorator('selfReferenceId', {
              rules:[],
              
              })
              ( <Input placeholder={"SelfReferenceId"} /> )}
              </Form.Item>

						<Form.Item>
              <label htmlFor='selfReferenceId2'>SelfReferenceId2</label>
              <br />             
              {getFieldDecorator('selfReferenceId2', {
              rules:[],
              
              })
              ( <Input placeholder={"SelfReferenceId2"} /> )}
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

export const WrappedSelfReferenceCreateComponent = Form.create({ name: 'SelfReference Create' })(SelfReferenceCreateComponent);

/*<Codenesium>
    <Hash>80fe9bbcab24bf39ec6251b08867db51</Hash>
</Codenesium>*/