import React, { Component, FormEvent } from 'react';
import axios from 'axios';
import { CreateResponse } from '../../api/apiObjects';
import { Constants, ApiRoutes, ClientRoutes } from '../../constants';
import * as Api from '../../api/models';
import DeviceMapper from './deviceMapper';
import DeviceViewModel from './deviceViewModel';
import { Form, Input, Button, Switch, InputNumber, DatePicker, Spin, Alert, TimePicker } from 'antd';
import { WrappedFormUtils } from 'antd/es/form/Form';

interface DeviceCreateComponentProps {
  form:WrappedFormUtils;
  history:any;
  match:any;
}

interface DeviceCreateComponentState {
  model?: DeviceViewModel;
  loading: boolean;
  loaded: boolean;
  errorOccurred: boolean;
  errorMessage: string;
  submitted:boolean;
}

class DeviceCreateComponent extends React.Component<
  DeviceCreateComponentProps,
  DeviceCreateComponentState
> {
  state = {
    model: new DeviceViewModel(),
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
        let model = values as DeviceViewModel;
        console.log('Received values of form: ', model);
        this.submit(model);
      }
    });
  };

  submit = (model:DeviceViewModel) =>
  {  
    let mapper = new DeviceMapper();
     axios
      .post(
        Constants.ApiEndpoint + ApiRoutes.Devices,
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
            Api.DeviceClientRequestModel
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
              <label htmlFor='dateOfLastPing'>Date of Last Ping</label>
              <br />             
              {getFieldDecorator('dateOfLastPing', {
              rules:[{ required: true, message: 'Required' },
{ whitespace: true, message: 'Required' },
],
              
              })
              ( <DatePicker format={'YYYY-MM-DD'} placeholder={"Date of Last Ping"} /> )}
              </Form.Item>

						<Form.Item>
              <label htmlFor='isActive'>Active</label>
              <br />             
              {getFieldDecorator('isActive', {
              rules:[{ required: true, message: 'Required' },
{ whitespace: true, message: 'Required' },
],
              valuePropName: 'checked'
              })
              ( <Switch /> )}
              </Form.Item>

						<Form.Item>
              <label htmlFor='name'>Name</label>
              <br />             
              {getFieldDecorator('name', {
              rules:[{ required: true, message: 'Required' },
{ whitespace: true, message: 'Required' },
{ max: 90, message: 'Exceeds max length of 90' },
],
              
              })
              ( <Input placeholder={"Name"} /> )}
              </Form.Item>

						<Form.Item>
              <label htmlFor='publicId'>Public Id</label>
              <br />             
              {getFieldDecorator('publicId', {
              rules:[{ required: true, message: 'Required' },
{ whitespace: true, message: 'Required' },
],
              
              })
              ( <Input placeholder={"Public Id"} /> )}
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

export const WrappedDeviceCreateComponent = Form.create({ name: 'Device Create' })(DeviceCreateComponent);

/*<Codenesium>
    <Hash>bbfb6dfe56342f5f406e059e7e00b993</Hash>
</Codenesium>*/