import React, { Component, FormEvent } from 'react';
import axios, { AxiosError, AxiosResponse } from 'axios';
import { ActionResponse, CreateResponse } from '../../api/apiObjects';
import { Constants, ApiRoutes, ClientRoutes } from '../../constants';
import * as Api from '../../api/models';
import OtherTransportMapper from './otherTransportMapper';
import OtherTransportViewModel from './otherTransportViewModel';
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
import { HandlerSelectComponent } from '../shared/handlerSelect';
import { PipelineStepSelectComponent } from '../shared/pipelineStepSelect';

interface OtherTransportCreateComponentProps {
  form: WrappedFormUtils;
  history: any;
  match: any;
}

interface OtherTransportCreateComponentState {
  model?: OtherTransportViewModel;
  loading: boolean;
  loaded: boolean;
  errorOccurred: boolean;
  errorMessage: string;
  submitted: boolean;
  submitting: boolean;
}

class OtherTransportCreateComponent extends React.Component<
  OtherTransportCreateComponentProps,
  OtherTransportCreateComponentState
> {
  state = {
    model: new OtherTransportViewModel(),
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
        let model = values as OtherTransportViewModel;
        this.submit(model);
      } else {
        this.setState({ ...this.state, submitting: false, submitted: false });
      }
    });
  };

  submit = (model: OtherTransportViewModel) => {
    let mapper = new OtherTransportMapper();
    axios
      .post<CreateResponse<Api.OtherTransportClientRequestModel>>(
        Constants.ApiEndpoint + ApiRoutes.OtherTransports,
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
          <HandlerSelectComponent
            apiRoute={Constants.ApiEndpoint + ApiRoutes.Handlers}
            getFieldDecorator={this.props.form.getFieldDecorator}
            propertyName="handlerId"
            required={true}
            selectedValue={this.state.model!.handlerId}
          />

          <PipelineStepSelectComponent
            apiRoute={Constants.ApiEndpoint + ApiRoutes.PipelineSteps}
            getFieldDecorator={this.props.form.getFieldDecorator}
            propertyName="pipelineStepId"
            required={true}
            selectedValue={this.state.model!.pipelineStepId}
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

export const WrappedOtherTransportCreateComponent = Form.create({
  name: 'OtherTransport Create',
})(OtherTransportCreateComponent);


/*<Codenesium>
    <Hash>738b81ddaeb4067f74c0eb2fa09900d3</Hash>
</Codenesium>*/