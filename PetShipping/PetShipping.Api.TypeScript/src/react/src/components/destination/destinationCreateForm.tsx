import React, { Component, FormEvent } from 'react';
import axios from 'axios';
import { ActionResponse, CreateResponse } from '../../api/apiObjects';
import { Constants, ApiRoutes, ClientRoutes } from '../../constants';
import * as Api from '../../api/models';
import DestinationMapper from './destinationMapper';
import DestinationViewModel from './destinationViewModel';
import { Form, Input, Button, Switch, InputNumber, DatePicker, Spin, Alert, TimePicker } from 'antd';
import { WrappedFormUtils } from 'antd/es/form/Form';
import { ToLowerCaseFirstLetter } from '../../lib/stringUtilities';
import { CountrySelectComponent } from '../shared/countrySelect'
	
interface DestinationCreateComponentProps {
  form:WrappedFormUtils;
  history:any;
  match:any;
}

interface DestinationCreateComponentState {
  model?: DestinationViewModel;
  loading: boolean;
  loaded: boolean;
  errorOccurred: boolean;
  errorMessage: string;
  submitted:boolean;
}

class DestinationCreateComponent extends React.Component<
  DestinationCreateComponentProps,
  DestinationCreateComponentState
> {
  state = {
    model: new DestinationViewModel(),
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
        let model = values as DestinationViewModel;
        console.log('Received values of form: ', model);
        this.submit(model);
      }
    });
  };

  submit = (model:DestinationViewModel) =>
  {  
    let mapper = new DestinationMapper();
     axios
      .post(
        Constants.ApiEndpoint + ApiRoutes.Destinations,
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
            Api.DestinationClientRequestModel
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
              <label htmlFor='order'>order</label>
              <br />             
              {getFieldDecorator('order', {
              rules:[{ required: true, message: 'Required' },
],
              
              })
              ( <InputNumber placeholder={"order"} /> )}
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

export const WrappedDestinationCreateComponent = Form.create({ name: 'Destination Create' })(DestinationCreateComponent);

/*<Codenesium>
    <Hash>20fc56ef65de12214afd84a55668ae0e</Hash>
</Codenesium>*/