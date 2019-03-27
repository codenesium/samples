import React, { Component, FormEvent } from 'react';
import axios, { AxiosError, AxiosResponse } from 'axios';
import { ActionResponse, CreateResponse } from '../../api/apiObjects';
import { Constants, ApiRoutes, ClientRoutes } from '../../constants';
import * as Api from '../../api/models';
import VehicleCapabilitiesMapper from './vehicleCapabilitiesMapper';
import VehicleCapabilitiesViewModel from './vehicleCapabilitiesViewModel';
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
import { VehCapabilitySelectComponent } from '../shared/vehCapabilitySelect';
import { VehicleSelectComponent } from '../shared/vehicleSelect';

interface VehicleCapabilitiesCreateComponentProps {
  form: WrappedFormUtils;
  history: any;
  match: any;
}

interface VehicleCapabilitiesCreateComponentState {
  model?: VehicleCapabilitiesViewModel;
  loading: boolean;
  loaded: boolean;
  errorOccurred: boolean;
  errorMessage: string;
  submitted: boolean;
  submitting: boolean;
}

class VehicleCapabilitiesCreateComponent extends React.Component<
  VehicleCapabilitiesCreateComponentProps,
  VehicleCapabilitiesCreateComponentState
> {
  state = {
    model: new VehicleCapabilitiesViewModel(),
    loading: false,
    loaded: true,
    errorOccurred: false,
    errorMessage: '',
    submitted: false,
    submitting: false,
  };

  handleSubmit = (e: FormEvent<HTMLFormElement>) => {
    e.preventDefault();
    this.setState({ ...this.state, submitting: true, submitted: false });
    this.props.form.validateFields((err: any, values: any) => {
      if (!err) {
        let model = values as VehicleCapabilitiesViewModel;
        this.submit(model);
      } else {
        this.setState({ ...this.state, submitting: false, submitted: false });
      }
    });
  };

  submit = (model: VehicleCapabilitiesViewModel) => {
    let mapper = new VehicleCapabilitiesMapper();
    axios
      .post<CreateResponse<Api.VehicleCapabilitiesClientRequestModel>>(
        Constants.ApiEndpoint + ApiRoutes.VehicleCapabilities,
        mapper.mapViewModelToApiRequest(model),
        {
          headers: GlobalUtilities.defaultHeaders(),
        }
      )
      .then(response => {
        this.setState({
          ...this.state,
          submitted: true,
          submitting: false,
          model: mapper.mapApiResponseToViewModel(response.data.record!),
          errorOccurred: false,
          errorMessage: '',
        });
        GlobalUtilities.logInfo(response);
      })
      .catch((error: AxiosError) => {
        GlobalUtilities.logError(error);

        if (error.response && error.response.status == 422) {
          let errorResponse = error.response.data as ActionResponse;
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
          this.setState({
            ...this.state,
            submitted: true,
            submitting: false,
            errorOccurred: false,
            errorMessage: '',
          });
        } else {
          this.setState({
            ...this.state,
            submitted: true,
            submitting: false,
            errorOccurred: true,
            errorMessage: 'Error Occurred',
          });
        }
      });
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
          <VehCapabilitySelectComponent
            apiRoute={Constants.ApiEndpoint + ApiRoutes.VehCapabilities}
            getFieldDecorator={this.props.form.getFieldDecorator}
            propertyName="vehicleCapabilityId"
            required={true}
            selectedValue={this.state.model!.vehicleCapabilityId}
          />

          <VehicleSelectComponent
            apiRoute={Constants.ApiEndpoint + ApiRoutes.Vehicles}
            getFieldDecorator={this.props.form.getFieldDecorator}
            propertyName="vehicleId"
            required={true}
            selectedValue={this.state.model!.vehicleId}
          />

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

export const WrappedVehicleCapabilitiesCreateComponent = Form.create({
  name: 'VehicleCapabilities Create',
})(VehicleCapabilitiesCreateComponent);


/*<Codenesium>
    <Hash>4f642246a399e9d9ba0c6f1150e86e23</Hash>
</Codenesium>*/