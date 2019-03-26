import React, { Component, FormEvent } from 'react';
import axios, { AxiosError, AxiosResponse } from 'axios';
import { ActionResponse, CreateResponse } from '../../api/apiObjects';
import { Constants, ApiRoutes, ClientRoutes } from '../../constants';
import * as Api from '../../api/models';
import ErrorLogMapper from './errorLogMapper';
import ErrorLogViewModel from './errorLogViewModel';
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

interface ErrorLogCreateComponentProps {
  form: WrappedFormUtils;
  history: any;
  match: any;
}

interface ErrorLogCreateComponentState {
  model?: ErrorLogViewModel;
  loading: boolean;
  loaded: boolean;
  errorOccurred: boolean;
  errorMessage: string;
  submitted: boolean;
  submitting: boolean;
}

class ErrorLogCreateComponent extends React.Component<
  ErrorLogCreateComponentProps,
  ErrorLogCreateComponentState
> {
  state = {
    model: new ErrorLogViewModel(),
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
        let model = values as ErrorLogViewModel;
        this.submit(model);
      } else {
        this.setState({ ...this.state, submitting: false, submitted: false });
      }
    });
  };

  submit = (model: ErrorLogViewModel) => {
    let mapper = new ErrorLogMapper();
    axios
      .post<CreateResponse<Api.ErrorLogClientRequestModel>>(
        Constants.ApiEndpoint + ApiRoutes.ErrorLogs,
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
            <label htmlFor="errorLine">Error Line</label>
            <br />
            {getFieldDecorator('errorLine', {
              rules: [],
            })(<InputNumber placeholder={'Error Line'} />)}
          </Form.Item>

          <Form.Item>
            <label htmlFor="errorMessage">Error Message</label>
            <br />
            {getFieldDecorator('errorMessage', {
              rules: [
                { required: true, message: 'Required' },
                { max: 4000, message: 'Exceeds max length of 4000' },
              ],
            })(<Input placeholder={'Error Message'} />)}
          </Form.Item>

          <Form.Item>
            <label htmlFor="errorNumber">Error Number</label>
            <br />
            {getFieldDecorator('errorNumber', {
              rules: [{ required: true, message: 'Required' }],
            })(<InputNumber placeholder={'Error Number'} />)}
          </Form.Item>

          <Form.Item>
            <label htmlFor="errorProcedure">Error Procedure</label>
            <br />
            {getFieldDecorator('errorProcedure', {
              rules: [{ max: 126, message: 'Exceeds max length of 126' }],
            })(<Input placeholder={'Error Procedure'} />)}
          </Form.Item>

          <Form.Item>
            <label htmlFor="errorSeverity">Error Severity</label>
            <br />
            {getFieldDecorator('errorSeverity', {
              rules: [],
            })(<InputNumber placeholder={'Error Severity'} />)}
          </Form.Item>

          <Form.Item>
            <label htmlFor="errorState">Error State</label>
            <br />
            {getFieldDecorator('errorState', {
              rules: [],
            })(<InputNumber placeholder={'Error State'} />)}
          </Form.Item>

          <Form.Item>
            <label htmlFor="errorTime">Error Time</label>
            <br />
            {getFieldDecorator('errorTime', {
              rules: [{ required: true, message: 'Required' }],
            })(<DatePicker format={'YYYY-MM-DD'} placeholder={'Error Time'} />)}
          </Form.Item>

          <Form.Item>
            <label htmlFor="userName">User Name</label>
            <br />
            {getFieldDecorator('userName', {
              rules: [
                { required: true, message: 'Required' },
                { max: 128, message: 'Exceeds max length of 128' },
              ],
            })(<Input placeholder={'User Name'} />)}
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

export const WrappedErrorLogCreateComponent = Form.create({
  name: 'ErrorLog Create',
})(ErrorLogCreateComponent);


/*<Codenesium>
    <Hash>15394a27cf95e6b49045a0c402d77da7</Hash>
</Codenesium>*/