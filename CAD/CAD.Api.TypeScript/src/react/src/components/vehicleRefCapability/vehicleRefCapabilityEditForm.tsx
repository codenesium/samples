import React, { Component, FormEvent } from 'react';
import axios from 'axios';
import { CreateResponse } from '../../api/apiObjects';
import { Constants, ApiRoutes, ClientRoutes } from '../../constants';
import * as Api from '../../api/models';
import VehicleRefCapabilityMapper from './vehicleRefCapabilityMapper';
import VehicleRefCapabilityViewModel from './vehicleRefCapabilityViewModel';
import { Form, Input, Button, Switch, InputNumber, DatePicker, Spin, Alert, TimePicker } from 'antd';
import { WrappedFormUtils } from 'antd/es/form/Form';

interface VehicleRefCapabilityEditComponentProps {
  form:WrappedFormUtils;
  history:any;
  match:any;
}

interface VehicleRefCapabilityEditComponentState {
  model?: VehicleRefCapabilityViewModel;
  loading: boolean;
  loaded: boolean;
  errorOccurred: boolean;
  errorMessage: string;
  submitted:boolean;
}

class VehicleRefCapabilityEditComponent extends React.Component<
  VehicleRefCapabilityEditComponentProps,
  VehicleRefCapabilityEditComponentState
> {
  state = {
    model: new VehicleRefCapabilityViewModel(),
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
          ApiRoutes.VehicleRefCapabilities +
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
          let response = resp.data as Api.VehicleRefCapabilityClientResponseModel;

          console.log(response);

          let mapper = new VehicleRefCapabilityMapper();

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
      .put(
        Constants.ApiEndpoint + ApiRoutes.VehicleRefCapabilities + '/' + this.state.model!.id,
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

export const WrappedVehicleRefCapabilityEditComponent = Form.create({ name: 'VehicleRefCapability Edit' })(VehicleRefCapabilityEditComponent);

/*<Codenesium>
    <Hash>ec6d27c27517e5162d24707bc34bc9b6</Hash>
</Codenesium>*/