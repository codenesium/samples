import React, { Component, FormEvent } from 'react';
import axios from 'axios';
import { ActionResponse, CreateResponse } from '../../api/apiObjects';
import { Constants, ApiRoutes, ClientRoutes } from '../../constants';
import * as Api from '../../api/models';
import AddressMapper from './addressMapper';
import AddressViewModel from './addressViewModel';
import { Form, Input, Button, Switch, InputNumber, DatePicker, Spin, Alert, TimePicker } from 'antd';
import { WrappedFormUtils } from 'antd/es/form/Form';
import { ToLowerCaseFirstLetter } from '../../lib/stringUtilities';

interface AddressCreateComponentProps {
  form:WrappedFormUtils;
  history:any;
  match:any;
}

interface AddressCreateComponentState {
  model?: AddressViewModel;
  loading: boolean;
  loaded: boolean;
  errorOccurred: boolean;
  errorMessage: string;
  submitted:boolean;
}

class AddressCreateComponent extends React.Component<
  AddressCreateComponentProps,
  AddressCreateComponentState
> {
  state = {
    model: new AddressViewModel(),
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
        let model = values as AddressViewModel;
        console.log('Received values of form: ', model);
        this.submit(model);
      }
    });
  };

  submit = (model:AddressViewModel) =>
  {  
    let mapper = new AddressMapper();
     axios
      .post(
        Constants.ApiEndpoint + ApiRoutes.Addresses,
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
            Api.AddressClientRequestModel
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
              rules:[{ max: 128, message: 'Exceeds max length of 128' },
],
              
              })
              ( <Input placeholder={"address2"} /> )}
              </Form.Item>

						<Form.Item>
              <label htmlFor='city'>city</label>
              <br />             
              {getFieldDecorator('city', {
              rules:[{ required: true, message: 'Required' },
{ max: 128, message: 'Exceeds max length of 128' },
],
              
              })
              ( <Input placeholder={"city"} /> )}
              </Form.Item>

						<Form.Item>
              <label htmlFor='state'>state</label>
              <br />             
              {getFieldDecorator('state', {
              rules:[{ required: true, message: 'Required' },
{ max: 2, message: 'Exceeds max length of 2' },
],
              
              })
              ( <Input placeholder={"state"} /> )}
              </Form.Item>

						<Form.Item>
              <label htmlFor='zip'>zip</label>
              <br />             
              {getFieldDecorator('zip', {
              rules:[{ max: 12, message: 'Exceeds max length of 12' },
],
              
              })
              ( <Input placeholder={"zip"} /> )}
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

export const WrappedAddressCreateComponent = Form.create({ name: 'Address Create' })(AddressCreateComponent);

/*<Codenesium>
    <Hash>ba049fd9e3fa14aa4678b9b518a47b91</Hash>
</Codenesium>*/