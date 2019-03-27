import React, { Component, FormEvent } from 'react';
import axios, { AxiosError, AxiosResponse } from 'axios';
import { ActionResponse, CreateResponse } from '../../api/apiObjects';
import { Constants, ApiRoutes, ClientRoutes } from '../../constants';
import * as Api from '../../api/models';
import OfficerCapabilitiesMapper from './officerCapabilitiesMapper';
import OfficerCapabilitiesViewModel from './officerCapabilitiesViewModel';
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
import { OffCapabilitySelectComponent } from '../shared/offCapabilitySelect';
import { OfficerSelectComponent } from '../shared/officerSelect';

interface OfficerCapabilitiesCreateComponentProps {
  form: WrappedFormUtils;
  history: any;
  match: any;
}

interface OfficerCapabilitiesCreateComponentState {
  model?: OfficerCapabilitiesViewModel;
  loading: boolean;
  loaded: boolean;
  errorOccurred: boolean;
  errorMessage: string;
  submitted: boolean;
  submitting: boolean;
}

class OfficerCapabilitiesCreateComponent extends React.Component<
  OfficerCapabilitiesCreateComponentProps,
  OfficerCapabilitiesCreateComponentState
> {
  state = {
    model: new OfficerCapabilitiesViewModel(),
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
        let model = values as OfficerCapabilitiesViewModel;
        this.submit(model);
      } else {
        this.setState({ ...this.state, submitting: false, submitted: false });
      }
    });
  };

  submit = (model: OfficerCapabilitiesViewModel) => {
    let mapper = new OfficerCapabilitiesMapper();
    axios
      .post<CreateResponse<Api.OfficerCapabilitiesClientRequestModel>>(
        Constants.ApiEndpoint + ApiRoutes.OfficerCapabilities,
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
          <OffCapabilitySelectComponent
            apiRoute={Constants.ApiEndpoint + ApiRoutes.OffCapabilities}
            getFieldDecorator={this.props.form.getFieldDecorator}
            propertyName="capabilityId"
            required={true}
            selectedValue={this.state.model!.capabilityId}
          />

          <OfficerSelectComponent
            apiRoute={Constants.ApiEndpoint + ApiRoutes.Officers}
            getFieldDecorator={this.props.form.getFieldDecorator}
            propertyName="officerId"
            required={true}
            selectedValue={this.state.model!.officerId}
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

export const WrappedOfficerCapabilitiesCreateComponent = Form.create({
  name: 'OfficerCapabilities Create',
})(OfficerCapabilitiesCreateComponent);


/*<Codenesium>
    <Hash>a96461eb6c524378aaf13bd67d353a46</Hash>
</Codenesium>*/