import React, { Component, FormEvent } from 'react';
import axios from 'axios';
import { ActionResponse, CreateResponse } from '../../api/apiObjects';
import { Constants, ApiRoutes, ClientRoutes } from '../../constants';
import * as Api from '../../api/models';
import DeviceActionMapper from './deviceActionMapper';
import DeviceActionViewModel from './deviceActionViewModel';
import {
  Form,
  Input,
  Button,
  Switch,
  InputNumber,
  DatePicker,
  Spin,
  Alert,
  TimePicker,
} from 'antd';
import { WrappedFormUtils } from 'antd/es/form/Form';
import * as GlobalUtilities from '../../lib/globalUtilities';
import { DeviceSelectComponent } from '../shared/deviceSelect';
interface DeviceActionEditComponentProps {
  form: WrappedFormUtils;
  history: any;
  match: any;
}

interface DeviceActionEditComponentState {
  model?: DeviceActionViewModel;
  loading: boolean;
  loaded: boolean;
  errorOccurred: boolean;
  errorMessage: string;
  submitted: boolean;
  submitting: boolean;
}

class DeviceActionEditComponent extends React.Component<
  DeviceActionEditComponentProps,
  DeviceActionEditComponentState
> {
  state = {
    model: new DeviceActionViewModel(),
    loading: false,
    loaded: true,
    errorOccurred: false,
    errorMessage: '',
    submitted: false,
    submitting: false,
  };

  componentDidMount() {
    this.setState({ ...this.state, loading: true });

    axios
      .get(
        Constants.ApiEndpoint +
          ApiRoutes.DeviceActions +
          '/' +
          this.props.match.params.id,
        {
          headers: GlobalUtilities.defaultHeaders(),
        }
      )
      .then(
        resp => {
          let response = resp.data as Api.DeviceActionClientResponseModel;

          GlobalUtilities.logInfo(resp);

          let mapper = new DeviceActionMapper();

          this.setState({
            model: mapper.mapApiResponseToViewModel(response),
            loading: false,
            loaded: true,
            errorOccurred: false,
            errorMessage: '',
          });

          this.props.form.setFieldsValue(
            mapper.mapApiResponseToViewModel(response)
          );
        },
        error => {
          GlobalUtilities.logError(error);
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

  handleSubmit = (e: FormEvent<HTMLFormElement>) => {
    e.preventDefault();
    this.setState({ ...this.state, submitting: true, submitted: false });
    this.props.form.validateFields((err: any, values: any) => {
      if (!err) {
        let model = values as DeviceActionViewModel;
        this.submit(model);
      } else {
        this.setState({ ...this.state, submitting: false, submitted: false });
      }
    });
  };

  submit = (model: DeviceActionViewModel) => {
    let mapper = new DeviceActionMapper();
    axios
      .put(
        Constants.ApiEndpoint +
          ApiRoutes.DeviceActions +
          '/' +
          this.state.model!.id,
        mapper.mapViewModelToApiRequest(model),
        {
          headers: GlobalUtilities.defaultHeaders(),
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
            submitting: false,
            model: mapper.mapApiResponseToViewModel(response.record!),
            errorOccurred: false,
            errorMessage: '',
          });
          GlobalUtilities.logInfo(resp);
        },
        error => {
          GlobalUtilities.logError(error);
          let errorResponse = error.response.data as ActionResponse;
          if (error.response.data) {
            errorResponse.validationErrors.forEach(x => {
              this.props.form.setFields({
                [GlobalUtilities.toLowerCaseFirstLetter(x.propertyName)]: {
                  value: this.props.form.getFieldValue(
                    GlobalUtilities.toLowerCaseFirstLetter(x.propertyName)
                  ),
                  errors: [new Error(x.errorMessage)],
                },
              });
            });
          }
          this.setState({
            ...this.state,
            submitted: true,
            submitting: false,
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
      return <Spin size="large" />;
    } else if (this.state.loaded) {
      return (
        <Form onSubmit={this.handleSubmit}>
          <Form.Item>
            <label htmlFor="action">Action</label>
            <br />
            {getFieldDecorator('action', {
              rules: [
                { required: true, message: 'Required' },
                { max: 4000, message: 'Exceeds max length of 4000' },
              ],
            })(<Input placeholder={'Action'} />)}
          </Form.Item>

          <Form.Item>
            <label htmlFor="deviceId">Device</label>
            <br />
            <DeviceSelectComponent
              apiRoute={Constants.ApiEndpoint + ApiRoutes.Devices}
              getFieldDecorator={this.props.form.getFieldDecorator}
              propertyName="deviceId"
              required={true}
              selectedValue={this.state.model!.deviceId}
            />
          </Form.Item>

          <Form.Item>
            <label htmlFor="name">Name</label>
            <br />
            {getFieldDecorator('name', {
              rules: [
                { required: true, message: 'Required' },
                { max: 90, message: 'Exceeds max length of 90' },
              ],
            })(<Input placeholder={'Name'} />)}
          </Form.Item>

          <Form.Item>
            <Button
              type="primary"
              htmlType="submit"
              loading={this.state.submitting}
            >
              {this.state.submitting ? 'Submitting...' : 'Submit'}
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

export const WrappedDeviceActionEditComponent = Form.create({
  name: 'DeviceAction Edit',
})(DeviceActionEditComponent);


/*<Codenesium>
    <Hash>a1bf27fa10e83bd346c7871a89545ef2</Hash>
</Codenesium>*/