import React, { Component, FormEvent } from 'react';
import axios from 'axios';
import { CreateResponse } from '../../api/apiObjects';
import { LoadingForm } from '../../lib/components/loadingForm';
import { ErrorForm } from '../../lib/components/errorForm';
import { Constants, ApiRoutes, ClientRoutes } from '../../constants';
import * as Api from '../../api/models';
import DeviceActionMapper from './deviceActionMapper';
import DeviceActionViewModel from './deviceActionViewModel';
import { Form, Input, Button, Checkbox, InputNumber, DatePicker } from 'antd';
import { WrappedFormUtils } from 'antd/es/form/Form';
import { Alert } from 'antd';

interface DeviceActionCreateComponentProps {
  form: WrappedFormUtils;
  history: any;
  match: any;
}

interface DeviceActionCreateComponentState {
  model?: DeviceActionViewModel;
  loading: boolean;
  loaded: boolean;
  errorOccurred: boolean;
  errorMessage: string;
  submitted: boolean;
}

class DeviceActionCreateComponent extends React.Component<
  DeviceActionCreateComponentProps,
  DeviceActionCreateComponentState
> {
  state = {
    model: new DeviceActionViewModel(),
    loading: false,
    loaded: true,
    errorOccurred: false,
    errorMessage: '',
    submitted: false,
  };

  handleSubmit = (e: FormEvent<HTMLFormElement>) => {
    e.preventDefault();
    this.props.form.validateFields((err: any, values: any) => {
      if (!err) {
        let model = values as DeviceActionViewModel;
        console.log('Received values of form: ', model);
        this.submit(model);
      }
    });
  };

  submit = (model: DeviceActionViewModel) => {
    let mapper = new DeviceActionMapper();
    axios
      .post(
        Constants.ApiEndpoint + ApiRoutes.DeviceActions,
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
            Api.DeviceActionClientRequestModel
          >;
          this.setState({
            ...this.state,
            submitted: true,
            model: mapper.mapApiResponseToViewModel(response.record!),
            errorOccurred: false,
            errorMessage: '',
          });
          console.log(response);
        },
        error => {
          console.log(error);
          this.setState({
            ...this.state,
            submitted: true,
            errorOccurred: true,
            errorMessage: 'Error from API',
          });
        }
      );
  };

  render() {
    const {
      getFieldDecorator,
      getFieldsError,
      getFieldError,
      isFieldTouched,
    } = this.props.form;

    let message: JSX.Element = <div />;
    if (this.state.submitted) {
      if (this.state.errorOccurred) {
        message = <Alert message={this.state.errorMessage} type="error" />;
      } else {
        message = <Alert message="Submitted" type="success" />;
      }
    }

    if (this.state.loading) {
      return <LoadingForm />;
    } else if (this.state.loaded) {
      return (
        <Form onSubmit={this.handleSubmit}>
          <Form.Item>
            <label htmlFor="action">Action</label>
            {getFieldDecorator('action', {
              rules: [],
            })(<Input placeholder={'Action'} id={'action'} />)}
          </Form.Item>

          <Form.Item>
            <label htmlFor="deviceId">Device</label>
            {getFieldDecorator('deviceId', {
              rules: [],
            })(<Input placeholder={'Device'} id={'deviceId'} />)}
          </Form.Item>

          <Form.Item>
            <label htmlFor="name">Name</label>
            {getFieldDecorator('name', {
              rules: [],
            })(<Input placeholder={'Name'} id={'name'} />)}
          </Form.Item>

          <Form.Item>
            <Button type="primary" htmlType="submit">
              Submit
            </Button>
          </Form.Item>
          {message}
        </Form>
      );
    } else {
      return null;
    }
  }
}

export const WrappedDeviceActionCreateComponent = Form.create({
  name: 'DeviceAction Create',
})(DeviceActionCreateComponent);


/*<Codenesium>
    <Hash>1df6780a25fec06e004b5c8d0a4c7833</Hash>
</Codenesium>*/