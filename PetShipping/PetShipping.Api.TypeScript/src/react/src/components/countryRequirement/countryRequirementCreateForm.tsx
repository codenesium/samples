import React, { Component, FormEvent } from 'react';
import axios from 'axios';
import { ActionResponse, CreateResponse } from '../../api/apiObjects';
import { Constants, ApiRoutes, ClientRoutes } from '../../constants';
import * as Api from '../../api/models';
import CountryRequirementMapper from './countryRequirementMapper';
import CountryRequirementViewModel from './countryRequirementViewModel';
import { Form, Input, Button, Switch, InputNumber, DatePicker, Spin, Alert, TimePicker } from 'antd';
import { WrappedFormUtils } from 'antd/es/form/Form';
import { ToLowerCaseFirstLetter } from '../../lib/stringUtilities';
import { CountrySelectComponent } from '../shared/countrySelect'
	
interface CountryRequirementCreateComponentProps {
  form:WrappedFormUtils;
  history:any;
  match:any;
}

interface CountryRequirementCreateComponentState {
  model?: CountryRequirementViewModel;
  loading: boolean;
  loaded: boolean;
  errorOccurred: boolean;
  errorMessage: string;
  submitted:boolean;
}

class CountryRequirementCreateComponent extends React.Component<
  CountryRequirementCreateComponentProps,
  CountryRequirementCreateComponentState
> {
  state = {
    model: new CountryRequirementViewModel(),
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
        let model = values as CountryRequirementViewModel;
        console.log('Received values of form: ', model);
        this.submit(model);
      }
    });
  };

  submit = (model:CountryRequirementViewModel) =>
  {  
    let mapper = new CountryRequirementMapper();
     axios
      .post(
        Constants.ApiEndpoint + ApiRoutes.CountryRequirements,
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
            Api.CountryRequirementClientRequestModel
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
              <label htmlFor='countryId'>countryId</label>
              <br />             
              {getFieldDecorator('countryId', {
              rules:[{ required: true, message: 'Required' },
],
              
              })
              ( <Input placeholder={"countryId"} /> )}
              </Form.Item>

						<Form.Item>
              <label htmlFor='detail'>details</label>
              <br />             
              {getFieldDecorator('detail', {
              rules:[{ required: true, message: 'Required' },
],
              
              })
              ( <Input placeholder={"details"} /> )}
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

export const WrappedCountryRequirementCreateComponent = Form.create({ name: 'CountryRequirement Create' })(CountryRequirementCreateComponent);

/*<Codenesium>
    <Hash>79ffc1d79e8e184b12a457aedb04c8ce</Hash>
</Codenesium>*/