import React, { Component, FormEvent } from 'react';
import axios, { AxiosError, AxiosResponse } from 'axios';
import { ActionResponse, CreateResponse } from '../../api/apiObjects';
import { Constants, ApiRoutes, ClientRoutes } from '../../constants';
import * as Api from '../../api/models';
import AirTransportMapper from './airTransportMapper';
import AirTransportViewModel from './airTransportViewModel';
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

interface AirTransportCreateComponentProps {
  form: WrappedFormUtils;
  history: any;
  match: any;
}

interface AirTransportCreateComponentState {
  model?: AirTransportViewModel;
  loading: boolean;
  loaded: boolean;
  errorOccurred: boolean;
  errorMessage: string;
  submitted: boolean;
  submitting: boolean;
}

class AirTransportCreateComponent extends React.Component<
  AirTransportCreateComponentProps,
  AirTransportCreateComponentState
> {
  state = {
    model: new AirTransportViewModel(),
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
        let model = values as AirTransportViewModel;
        this.submit(model);
      } else {
        this.setState({ ...this.state, submitting: false, submitted: false });
      }
    });
  };

  submit = (model: AirTransportViewModel) => {
    let mapper = new AirTransportMapper();
    axios
      .post<CreateResponse<Api.AirTransportClientRequestModel>>(
        Constants.ApiEndpoint + ApiRoutes.AirTransports,
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
          <Form.Item>
            <label htmlFor="airlineId">Airline (required)</label>
            <br />
            {getFieldDecorator('airlineId', {
              rules: [{ required: true, message: 'Required' }],
            })(<InputNumber placeholder={'Airline'} />)}
          </Form.Item>

          <Form.Item>
            <label htmlFor="flightNumber">Flight Number (required)</label>
            <br />
            {getFieldDecorator('flightNumber', {
              rules: [
                { required: true, message: 'Required' },
                { max: 12, message: 'Exceeds max length of 12' },
              ],
            })(<Input placeholder={'Flight Number'} />)}
          </Form.Item>

          <HandlerSelectComponent
            apiRoute={Constants.ApiEndpoint + ApiRoutes.Handlers}
            getFieldDecorator={this.props.form.getFieldDecorator}
            propertyName="handlerId"
            required={true}
            selectedValue={this.state.model!.handlerId}
          />

          <Form.Item>
            <label htmlFor="landDate">Land Date (required)</label>
            <br />
            {getFieldDecorator('landDate', {
              rules: [{ required: true, message: 'Required' }],
            })(<DatePicker format={'YYYY-MM-DD'} placeholder={'Land Date'} />)}
          </Form.Item>

          <Form.Item>
            <label htmlFor="pipelineStepId">Pipeline Step (required)</label>
            <br />
            {getFieldDecorator('pipelineStepId', {
              rules: [{ required: true, message: 'Required' }],
            })(<InputNumber placeholder={'Pipeline Step'} />)}
          </Form.Item>

          <Form.Item>
            <label htmlFor="takeoffDate">Takeoff Date (required)</label>
            <br />
            {getFieldDecorator('takeoffDate', {
              rules: [{ required: true, message: 'Required' }],
            })(
              <DatePicker format={'YYYY-MM-DD'} placeholder={'Takeoff Date'} />
            )}
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

export const WrappedAirTransportCreateComponent = Form.create({
  name: 'AirTransport Create',
})(AirTransportCreateComponent);


/*<Codenesium>
    <Hash>180cd7a394cf256321185fac2014e529</Hash>
</Codenesium>*/