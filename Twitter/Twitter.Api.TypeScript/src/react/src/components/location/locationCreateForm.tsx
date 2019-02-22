import React, { Component, FormEvent } from 'react';
import axios from 'axios';
import { CreateResponse } from '../../api/apiObjects';
import { Constants, ApiRoutes, ClientRoutes } from '../../constants';
import * as Api from '../../api/models';
import LocationMapper from './locationMapper';
import LocationViewModel from './locationViewModel';
import { Form, Input, Button, Switch, InputNumber, DatePicker, Spin, Alert, TimePicker } from 'antd';
import { WrappedFormUtils } from 'antd/es/form/Form';

interface LocationCreateComponentProps {
  form:WrappedFormUtils;
  history:any;
  match:any;
}

interface LocationCreateComponentState {
  model?: LocationViewModel;
  loading: boolean;
  loaded: boolean;
  errorOccurred: boolean;
  errorMessage: string;
  submitted:boolean;
}

class LocationCreateComponent extends React.Component<
  LocationCreateComponentProps,
  LocationCreateComponentState
> {
  state = {
    model: new LocationViewModel(),
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
        let model = values as LocationViewModel;
        console.log('Received values of form: ', model);
        this.submit(model);
      }
    });
  };

  submit = (model:LocationViewModel) =>
  {  
    let mapper = new LocationMapper();
     axios
      .post(
        Constants.ApiEndpoint + ApiRoutes.Locations,
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
            Api.LocationClientRequestModel
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
              <label htmlFor='gpsLat'>gps_lat</label>
              <br />             
              {getFieldDecorator('gpsLat', {
              rules:[{ required: true, message: 'Required' },
],
              
              })
              ( <Input placeholder={"gps_lat"} /> )}
              </Form.Item>

						<Form.Item>
              <label htmlFor='gpsLong'>gps_long</label>
              <br />             
              {getFieldDecorator('gpsLong', {
              rules:[{ required: true, message: 'Required' },
],
              
              })
              ( <Input placeholder={"gps_long"} /> )}
              </Form.Item>

						<Form.Item>
              <label htmlFor='locationName'>location_name</label>
              <br />             
              {getFieldDecorator('locationName', {
              rules:[{ required: true, message: 'Required' },
{ max: 64, message: 'Exceeds max length of 64' },
],
              
              })
              ( <Input placeholder={"location_name"} /> )}
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

export const WrappedLocationCreateComponent = Form.create({ name: 'Location Create' })(LocationCreateComponent);

/*<Codenesium>
    <Hash>30359b7026559a4826088c973aff9bf7</Hash>
</Codenesium>*/