import React, { Component, FormEvent } from 'react';
import axios from 'axios';
import { ActionResponse, CreateResponse } from '../../api/apiObjects';
import { Constants, ApiRoutes, ClientRoutes } from '../../constants';
import * as Api from '../../api/models';
import VehicleCapabilitiesMapper from './vehicleCapabilitiesMapper';
import VehicleCapabilitiesViewModel from './vehicleCapabilitiesViewModel';
import { Form, Input, Button, Switch, InputNumber, DatePicker, Spin, Alert, TimePicker } from 'antd';
import { WrappedFormUtils } from 'antd/es/form/Form';
import { ToLowerCaseFirstLetter } from '../../lib/stringUtilities';
import { VehicleCapabilitySelectComponent } from '../shared/vehicleCapabilitySelect'
	import { VehicleSelectComponent } from '../shared/vehicleSelect'
	interface VehicleCapabilitiesEditComponentProps {
  form:WrappedFormUtils;
  history:any;
  match:any;
}

interface VehicleCapabilitiesEditComponentState {
  model?: VehicleCapabilitiesViewModel;
  loading: boolean;
  loaded: boolean;
  errorOccurred: boolean;
  errorMessage: string;
  submitted:boolean;
}

class VehicleCapabilitiesEditComponent extends React.Component<
  VehicleCapabilitiesEditComponentProps,
  VehicleCapabilitiesEditComponentState
> {
  state = {
    model: new VehicleCapabilitiesViewModel(),
    loading: false,
    loaded: true,
    errorOccurred: false,
    errorMessage: '',
	submitted:false
  };

    componentDidMount() {
    this.setState({ ...this.state, loading: true });

    axios
      .get(
        Constants.ApiEndpoint +
          ApiRoutes.VehicleCapabilities +
          '/' +
          this.props.match.params.id,
        {
          headers: {
            'Content-Type': 'application/json',
          },
        }
      )
      .then(
        resp => {
          let response = resp.data as Api.VehicleCapabilitiesClientResponseModel;

          console.log(response);

          let mapper = new VehicleCapabilitiesMapper();

          this.setState({
            model: mapper.mapApiResponseToViewModel(response),
            loading: false,
            loaded: true,
            errorOccurred: false,
            errorMessage: '',
          });

		  this.props.form.setFieldsValue(mapper.mapApiResponseToViewModel(response));
        },
        error => {
          console.log(error);
          this.setState({
            model: undefined,
            loading: false,
            loaded: false,
            errorOccurred: true,
            errorMessage: 'Error from API',
          });
        }
      );
 }
 
 handleSubmit = (e:FormEvent<HTMLFormElement>) => {
     e.preventDefault();
     this.props.form.validateFields((err:any, values:any) => {
      if (!err) {
        let model = values as VehicleCapabilitiesViewModel;
        console.log('Received values of form: ', model);
        this.submit(model);
      }
    });
  };

  submit = (model:VehicleCapabilitiesViewModel) =>
  {  
    let mapper = new VehicleCapabilitiesMapper();
     axios
      .put(
        Constants.ApiEndpoint + ApiRoutes.VehicleCapabilities + '/' + this.state.model!.vehicleId,
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
            Api.VehicleCapabilitiesClientRequestModel
          >;
          this.setState({...this.state, submitted:true, model:mapper.mapApiResponseToViewModel(response.record!), errorOccurred:false, errorMessage:''});
          console.log(response);
        },
        error => {
          console.log(error);
		  let errorResponse = error.response.data as ActionResponse; 
		  if(error.response.data)
          {
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
              <label htmlFor='vehicleCapabilityId'>vehicleCapabilityId</label>
              <br />             
              {getFieldDecorator('vehicleCapabilityId', {
              rules:[{ required: true, message: 'Required' },
],
              
              })
              ( <Input placeholder={"vehicleCapabilityId"} /> )}
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

export const WrappedVehicleCapabilitiesEditComponent = Form.create({ name: 'VehicleCapabilities Edit' })(VehicleCapabilitiesEditComponent);

/*<Codenesium>
    <Hash>99b5810004a2a46d7282dc3b89c1131c</Hash>
</Codenesium>*/