import React, { Component, FormEvent } from 'react';
import axios from 'axios';
import { ActionResponse, CreateResponse } from '../../api/apiObjects';
import { Constants, ApiRoutes, ClientRoutes } from '../../constants';
import * as Api from '../../api/models';
import LinkMapper from './linkMapper';
import LinkViewModel from './linkViewModel';
import { Form, Input, Button, Switch, InputNumber, DatePicker, Spin, Alert, TimePicker } from 'antd';
import { WrappedFormUtils } from 'antd/es/form/Form';
import { ToLowerCaseFirstLetter } from '../../lib/stringUtilities';
import { MachineSelectComponent } from '../shared/machineSelect'
	import { ChainSelectComponent } from '../shared/chainSelect'
	import { LinkStatusSelectComponent } from '../shared/linkStatusSelect'
	
interface LinkCreateComponentProps {
  form:WrappedFormUtils;
  history:any;
  match:any;
}

interface LinkCreateComponentState {
  model?: LinkViewModel;
  loading: boolean;
  loaded: boolean;
  errorOccurred: boolean;
  errorMessage: string;
  submitted:boolean;
  submitting:boolean;
}

class LinkCreateComponent extends React.Component<
  LinkCreateComponentProps,
  LinkCreateComponentState
> {
  state = {
    model: new LinkViewModel(),
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
        let model = values as LinkViewModel;
        console.log('Received values of form: ', model);
        this.submit(model);
      }
	  else {
	      this.setState({...this.state, submitting:false, submitted:false});
	  }
    });
  };

  submit = (model:LinkViewModel) =>
  {  
    let mapper = new LinkMapper();
     axios
      .post(
        Constants.ApiEndpoint + ApiRoutes.Links,
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
            Api.LinkClientRequestModel
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
                        <label htmlFor='assignedMachineId'>AssignedMachineId</label>
                        <br />   
                        <MachineSelectComponent   
                          apiRoute={
                          Constants.ApiEndpoint +
                          ApiRoutes.Machines}
                          getFieldDecorator={this.props.form.getFieldDecorator}
                          propertyName="assignedMachineId"
                          required={false}
                          selectedValue={this.state.model!.assignedMachineId}
                         />
                        </Form.Item>

						
                        <Form.Item>
                        <label htmlFor='chainId'>ChainId</label>
                        <br />   
                        <ChainSelectComponent   
                          apiRoute={
                          Constants.ApiEndpoint +
                          ApiRoutes.Chains}
                          getFieldDecorator={this.props.form.getFieldDecorator}
                          propertyName="chainId"
                          required={true}
                          selectedValue={this.state.model!.chainId}
                         />
                        </Form.Item>

						<Form.Item>
              <label htmlFor='dateCompleted'>DateCompleted</label>
              <br />             
              {getFieldDecorator('dateCompleted', {
              rules:[],
              
              })
              ( <DatePicker format={'YYYY-MM-DD'} placeholder={"DateCompleted"} /> )}
              </Form.Item>

						<Form.Item>
              <label htmlFor='dateStarted'>DateStarted</label>
              <br />             
              {getFieldDecorator('dateStarted', {
              rules:[],
              
              })
              ( <DatePicker format={'YYYY-MM-DD'} placeholder={"DateStarted"} /> )}
              </Form.Item>

						<Form.Item>
              <label htmlFor='dynamicParameter'>DynamicParameter</label>
              <br />             
              {getFieldDecorator('dynamicParameter', {
              rules:[],
              
              })
              ( <Input placeholder={"DynamicParameter"} /> )}
              </Form.Item>

						<Form.Item>
              <label htmlFor='externalId'>ExternalId</label>
              <br />             
              {getFieldDecorator('externalId', {
              rules:[{ required: true, message: 'Required' },
],
              
              })
              ( <Input placeholder={"ExternalId"} /> )}
              </Form.Item>

						<Form.Item>
              <label htmlFor='linkStatusId'>LinkStatusId</label>
              <br />             
              {getFieldDecorator('linkStatusId', {
              rules:[{ required: true, message: 'Required' },
],
              
              })
              ( <Input placeholder={"LinkStatusId"} /> )}
              </Form.Item>

						<Form.Item>
              <label htmlFor='name'>Name</label>
              <br />             
              {getFieldDecorator('name', {
              rules:[{ required: true, message: 'Required' },
{ max: 128, message: 'Exceeds max length of 128' },
],
              
              })
              ( <Input placeholder={"Name"} /> )}
              </Form.Item>

						<Form.Item>
              <label htmlFor='order'>Order</label>
              <br />             
              {getFieldDecorator('order', {
              rules:[{ required: true, message: 'Required' },
],
              
              })
              ( <InputNumber placeholder={"Order"} /> )}
              </Form.Item>

						<Form.Item>
              <label htmlFor='response'>Response</label>
              <br />             
              {getFieldDecorator('response', {
              rules:[],
              
              })
              ( <Input placeholder={"Response"} /> )}
              </Form.Item>

						<Form.Item>
              <label htmlFor='staticParameter'>StaticParameter</label>
              <br />             
              {getFieldDecorator('staticParameter', {
              rules:[],
              
              })
              ( <Input.TextArea placeholder={"StaticParameter"} /> )}
              </Form.Item>

						<Form.Item>
              <label htmlFor='timeoutInSecond'>TimeoutInSecond</label>
              <br />             
              {getFieldDecorator('timeoutInSecond', {
              rules:[{ required: true, message: 'Required' },
],
              
              })
              ( <InputNumber placeholder={"TimeoutInSecond"} /> )}
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

export const WrappedLinkCreateComponent = Form.create({ name: 'Link Create' })(LinkCreateComponent);

/*<Codenesium>
    <Hash>3f8b18c2d6b2a568f5ee0b41c7887882</Hash>
</Codenesium>*/