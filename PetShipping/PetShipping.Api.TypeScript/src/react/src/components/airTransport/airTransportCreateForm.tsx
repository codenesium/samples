import React, { Component, FormEvent } from 'react';
import axios from 'axios';
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
import { ToLowerCaseFirstLetter } from '../../lib/stringUtilities';
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
  };

  handleSubmit = (e: FormEvent<HTMLFormElement>) => {
    e.preventDefault();
    this.props.form.validateFields((err: any, values: any) => {
      if (!err) {
        let model = values as AirTransportViewModel;
        console.log('Received values of form: ', model);
        this.submit(model);
      }
    });
  };

  submit = (model: AirTransportViewModel) => {
    let mapper = new AirTransportMapper();
    axios
      .post(
        Constants.ApiEndpoint + ApiRoutes.AirTransports,
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
            Api.AirTransportClientRequestModel
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
          if (error.response.data) {
            let errorResponse = error.response.data as ActionResponse;

            errorResponse.validationErrors.forEach(x => {
              this.props.form.setFields({
                [ToLowerCaseFirstLetter(x.propertyName)]: {
                  value: this.props.form.getFieldValue(
                    ToLowerCaseFirstLetter(x.propertyName)
                  ),
                  errors: [new Error(x.errorMessage)],
                },
              });
            });
          }
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
      return <Spin size="large" />;
    } else if (this.state.loaded) {
      return (
        <Form onSubmit={this.handleSubmit}>
          <Form.Item>
            <label htmlFor="airlineId">airlineId</label>
            <br />
            {getFieldDecorator('airlineId', {
              rules: [{ required: true, message: 'Required' }],
            })(<Input placeholder={'airlineId'} />)}
          </Form.Item>

          <Form.Item>
            <label htmlFor="flightNumber">flightNumber</label>
            <br />
            {getFieldDecorator('flightNumber', {
              rules: [
                { required: true, message: 'Required' },
                { max: 12, message: 'Exceeds max length of 12' },
              ],
            })(<Input placeholder={'flightNumber'} />)}
          </Form.Item>

          <Form.Item>
            <label htmlFor="handlerId">handlerId</label>
            <br />
            {getFieldDecorator('handlerId', {
              rules: [{ required: true, message: 'Required' }],
            })(<Input placeholder={'handlerId'} />)}
          </Form.Item>

          <Form.Item>
            <label htmlFor="landDate">landDate</label>
            <br />
            {getFieldDecorator('landDate', {
              rules: [{ required: true, message: 'Required' }],
            })(<DatePicker format={'YYYY-MM-DD'} placeholder={'landDate'} />)}
          </Form.Item>

          <Form.Item>
            <label htmlFor="pipelineStepId">pipelineStepId</label>
            <br />
            {getFieldDecorator('pipelineStepId', {
              rules: [{ required: true, message: 'Required' }],
            })(<Input placeholder={'pipelineStepId'} />)}
          </Form.Item>

          <Form.Item>
            <label htmlFor="takeoffDate">takeoffDate</label>
            <br />
            {getFieldDecorator('takeoffDate', {
              rules: [{ required: true, message: 'Required' }],
            })(
              <DatePicker format={'YYYY-MM-DD'} placeholder={'takeoffDate'} />
            )}
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

export const WrappedAirTransportCreateComponent = Form.create({
  name: 'AirTransport Create',
})(AirTransportCreateComponent);


/*<Codenesium>
    <Hash>6ee68593683761ecc76362312908e95f</Hash>
</Codenesium>*/