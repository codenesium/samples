import React, { Component, FormEvent } from 'react';
import axios from 'axios';
import { CreateResponse } from '../../api/apiObjects';
import { Constants, ApiRoutes, ClientRoutes } from '../../constants';
import * as Api from '../../api/models';
import VehicleRefCapabilityMapper from './vehicleRefCapabilityMapper';
import VehicleRefCapabilityViewModel from './vehicleRefCapabilityViewModel';
import { Form, Input, Button, Switch, InputNumber, DatePicker, Spin, Alert, TimePicker } from 'antd';
import { WrappedFormUtils } from 'antd/es/form/Form';

interface VehicleRefCapabilityCreateComponentProps {
  form:WrappedFormUtils;
  history:any;
  match:any;
}

interface VehicleRefCapabilityCreateComponentState {
  model?: VehicleRefCapabilityViewModel;
  loading: boolean;
  loaded: boolean;
  errorOccurred: boolean;
  errorMessage: string;
  submitted:boolean;
}

class VehicleRefCapabilityCreateComponent extends React.Component<
  VehicleRefCapabilityCreateComponentProps,
  VehicleRefCapabilityCreateComponentState
> {
  state = {
    model: new VehicleRefCapabilityViewModel(),
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
        let model = values as VehicleRefCapabilityViewModel;
        console.log('Received values of form: ', model);
        this.submit(model);
      }
    });
  };

  submit = (model:VehicleRefCapabilityViewModel) =>
  {  
    let mapper = new VehicleRefCapabilityMapper();
     axios
      .post(
        Constants.ApiEndpoint + ApiRoutes.VehicleRefCapabilities,
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
            Api.VehicleRefCapabilityClientRequestModel
          >;
          this.setState({...this.state, submitted:true, model:mapper.mapApiResponseToViewModel(response.record!), errorOccurred:false, errorMessage:''});
          console.log(response);
        },
        error => {
          console.log(error);
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
              <label htmlFor='vehicleCapabilityId'>vehicleCapabilityId</label>
              <br />             
              {getFieldDecorator('vehicleCapabilityId', {
              rules:[{ required: true, message: 'Required' },
],
              
              })
              ( <Input placeholder={"vehicleCapabilityId"} /> )}
              </Form.Item>

						<Form.Item>
              <label htmlFor='vehicleId'>vehicleId</label>
              <br />             
              {getFieldDecorator('vehicleId', {
              rules:[{ required: true, message: 'Required' },
],
              
              })
              ( <Input placeholder={"vehicleId"} /> )}
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

export const WrappedVehicleRefCapabilityCreateComponent = Form.create({ name: 'VehicleRefCapability Create' })(VehicleRefCapabilityCreateComponent);

/*<Codenesium>
    <Hash>17ab314121e07eb5e126954d21a8a7b5</Hash>
</Codenesium>*/