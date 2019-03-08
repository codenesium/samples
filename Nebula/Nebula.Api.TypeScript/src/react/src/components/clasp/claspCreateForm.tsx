import React, { Component, FormEvent } from 'react';
import axios from 'axios';
import { ActionResponse, CreateResponse } from '../../api/apiObjects';
import { Constants, ApiRoutes, ClientRoutes } from '../../constants';
import * as Api from '../../api/models';
import ClaspMapper from './claspMapper';
import ClaspViewModel from './claspViewModel';
import { Form, Input, Button, Switch, InputNumber, DatePicker, Spin, Alert, TimePicker } from 'antd';
import { WrappedFormUtils } from 'antd/es/form/Form';
import { ToLowerCaseFirstLetter } from '../../lib/stringUtilities';
import { ChainSelectComponent } from '../shared/chainSelect'
	
interface ClaspCreateComponentProps {
  form:WrappedFormUtils;
  history:any;
  match:any;
}

interface ClaspCreateComponentState {
  model?: ClaspViewModel;
  loading: boolean;
  loaded: boolean;
  errorOccurred: boolean;
  errorMessage: string;
  submitted:boolean;
  submitting:boolean;
}

class ClaspCreateComponent extends React.Component<
  ClaspCreateComponentProps,
  ClaspCreateComponentState
> {
  state = {
    model: new ClaspViewModel(),
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
        let model = values as ClaspViewModel;
        console.log('Received values of form: ', model);
        this.submit(model);
      }
	  else {
	      this.setState({...this.state, submitting:false, submitted:false});
	  }
    });
  };

  submit = (model:ClaspViewModel) =>
  {  
    let mapper = new ClaspMapper();
     axios
      .post(
        Constants.ApiEndpoint + ApiRoutes.Clasps,
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
            Api.ClaspClientRequestModel
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
                        <label htmlFor='nextChainId'>NextChainId</label>
                        <br />   
                        <ChainSelectComponent   
                          apiRoute={
                          Constants.ApiEndpoint +
                          ApiRoutes.Chains}
                          getFieldDecorator={this.props.form.getFieldDecorator}
                          propertyName="nextChainId"
                          required={true}
                          selectedValue={this.state.model!.nextChainId}
                         />
                        </Form.Item>

						
                        <Form.Item>
                        <label htmlFor='previousChainId'>PreviousChainId</label>
                        <br />   
                        <ChainSelectComponent   
                          apiRoute={
                          Constants.ApiEndpoint +
                          ApiRoutes.Chains}
                          getFieldDecorator={this.props.form.getFieldDecorator}
                          propertyName="previousChainId"
                          required={true}
                          selectedValue={this.state.model!.previousChainId}
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

export const WrappedClaspCreateComponent = Form.create({ name: 'Clasp Create' })(ClaspCreateComponent);

/*<Codenesium>
    <Hash>f4a562e9581c29fb062bafa5e3f81d00</Hash>
</Codenesium>*/