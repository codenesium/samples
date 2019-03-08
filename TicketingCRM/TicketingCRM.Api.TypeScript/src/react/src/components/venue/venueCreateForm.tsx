import React, { Component, FormEvent } from 'react';
import axios from 'axios';
import { ActionResponse, CreateResponse } from '../../api/apiObjects';
import { Constants, ApiRoutes, ClientRoutes } from '../../constants';
import * as Api from '../../api/models';
import VenueMapper from './venueMapper';
import VenueViewModel from './venueViewModel';
import { Form, Input, Button, Switch, InputNumber, DatePicker, Spin, Alert, TimePicker } from 'antd';
import { WrappedFormUtils } from 'antd/es/form/Form';
import { ToLowerCaseFirstLetter } from '../../lib/stringUtilities';
import { AdminSelectComponent } from '../shared/adminSelect'
	import { ProvinceSelectComponent } from '../shared/provinceSelect'
	
interface VenueCreateComponentProps {
  form:WrappedFormUtils;
  history:any;
  match:any;
}

interface VenueCreateComponentState {
  model?: VenueViewModel;
  loading: boolean;
  loaded: boolean;
  errorOccurred: boolean;
  errorMessage: string;
  submitted:boolean;
  submitting:boolean;
}

class VenueCreateComponent extends React.Component<
  VenueCreateComponentProps,
  VenueCreateComponentState
> {
  state = {
    model: new VenueViewModel(),
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
        let model = values as VenueViewModel;
        console.log('Received values of form: ', model);
        this.submit(model);
      }
	  else {
	      this.setState({...this.state, submitting:false, submitted:false});
	  }
    });
  };

  submit = (model:VenueViewModel) =>
  {  
    let mapper = new VenueMapper();
     axios
      .post(
        Constants.ApiEndpoint + ApiRoutes.Venues,
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
            Api.VenueClientRequestModel
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
              <label htmlFor='address1'>Address1</label>
              <br />             
              {getFieldDecorator('address1', {
              rules:[{ required: true, message: 'Required' },
{ max: 128, message: 'Exceeds max length of 128' },
],
              
              })
              ( <Input placeholder={"Address1"} /> )}
              </Form.Item>

						<Form.Item>
              <label htmlFor='address2'>Address2</label>
              <br />             
              {getFieldDecorator('address2', {
              rules:[{ required: true, message: 'Required' },
{ max: 128, message: 'Exceeds max length of 128' },
],
              
              })
              ( <Input placeholder={"Address2"} /> )}
              </Form.Item>

						
                        <Form.Item>
                        <label htmlFor='adminId'>Admin</label>
                        <br />   
                        <AdminSelectComponent   
                          apiRoute={
                          Constants.ApiEndpoint +
                          ApiRoutes.Admins}
                          getFieldDecorator={this.props.form.getFieldDecorator}
                          propertyName="adminId"
                          required={true}
                          selectedValue={this.state.model!.adminId}
                         />
                        </Form.Item>

						<Form.Item>
              <label htmlFor='email'>Email</label>
              <br />             
              {getFieldDecorator('email', {
              rules:[{ required: true, message: 'Required' },
{ max: 128, message: 'Exceeds max length of 128' },
],
              
              })
              ( <Input placeholder={"Email"} /> )}
              </Form.Item>

						<Form.Item>
              <label htmlFor='facebook'>Facebook</label>
              <br />             
              {getFieldDecorator('facebook', {
              rules:[{ required: true, message: 'Required' },
{ max: 128, message: 'Exceeds max length of 128' },
],
              
              })
              ( <Input placeholder={"Facebook"} /> )}
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
              <label htmlFor='phone'>Phone</label>
              <br />             
              {getFieldDecorator('phone', {
              rules:[{ required: true, message: 'Required' },
{ max: 128, message: 'Exceeds max length of 128' },
],
              
              })
              ( <InputNumber placeholder={"Phone"} /> )}
              </Form.Item>

						
                        <Form.Item>
                        <label htmlFor='provinceId'>Province</label>
                        <br />   
                        <ProvinceSelectComponent   
                          apiRoute={
                          Constants.ApiEndpoint +
                          ApiRoutes.Provinces}
                          getFieldDecorator={this.props.form.getFieldDecorator}
                          propertyName="provinceId"
                          required={true}
                          selectedValue={this.state.model!.provinceId}
                         />
                        </Form.Item>

						<Form.Item>
              <label htmlFor='website'>Website</label>
              <br />             
              {getFieldDecorator('website', {
              rules:[{ required: true, message: 'Required' },
{ max: 128, message: 'Exceeds max length of 128' },
],
              
              })
              ( <Input placeholder={"Website"} /> )}
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

export const WrappedVenueCreateComponent = Form.create({ name: 'Venue Create' })(VenueCreateComponent);

/*<Codenesium>
    <Hash>c4098569aea1d4f1784e2c79ff8a322a</Hash>
</Codenesium>*/