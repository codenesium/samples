import React, { Component, FormEvent } from 'react';
import axios, { AxiosError, AxiosResponse } from 'axios';
import { ActionResponse, CreateResponse } from '../../api/apiObjects';
import { Constants, ApiRoutes, ClientRoutes } from '../../constants';
import * as Api from '../../api/models';
import DatabaseLogMapper from './databaseLogMapper';
import DatabaseLogViewModel from './databaseLogViewModel';
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

interface DatabaseLogCreateComponentProps {
  form: WrappedFormUtils;
  history: any;
  match: any;
}

interface DatabaseLogCreateComponentState {
  model?: DatabaseLogViewModel;
  loading: boolean;
  loaded: boolean;
  errorOccurred: boolean;
  errorMessage: string;
  submitted: boolean;
  submitting: boolean;
}

class DatabaseLogCreateComponent extends React.Component<
  DatabaseLogCreateComponentProps,
  DatabaseLogCreateComponentState
> {
  state = {
    model: new DatabaseLogViewModel(),
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
        let model = values as DatabaseLogViewModel;
        this.submit(model);
      } else {
        this.setState({ ...this.state, submitting: false, submitted: false });
      }
    });
  };

  submit = (model: DatabaseLogViewModel) => {
    let mapper = new DatabaseLogMapper();
    axios
      .post<CreateResponse<Api.DatabaseLogClientRequestModel>>(
        Constants.ApiEndpoint + ApiRoutes.DatabaseLogs,
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
            <label htmlFor="databaseUser">Database User</label>
            <br />
            {getFieldDecorator('databaseUser', {
              rules: [
                { required: true, message: 'Required' },
                { max: 128, message: 'Exceeds max length of 128' },
              ],
            })(<Input placeholder={'Database User'} />)}
          </Form.Item>

          <Form.Item>
            <label htmlFor="reservedEvent">Event</label>
            <br />
            {getFieldDecorator('reservedEvent', {
              rules: [
                { required: true, message: 'Required' },
                { max: 128, message: 'Exceeds max length of 128' },
              ],
            })(<Input placeholder={'Event'} />)}
          </Form.Item>

          <Form.Item>
            <label htmlFor="reservedObject">Object</label>
            <br />
            {getFieldDecorator('reservedObject', {
              rules: [{ max: 128, message: 'Exceeds max length of 128' }],
            })(<Input placeholder={'Object'} />)}
          </Form.Item>

          <Form.Item>
            <label htmlFor="postTime">Post Time</label>
            <br />
            {getFieldDecorator('postTime', {
              rules: [{ required: true, message: 'Required' }],
            })(<DatePicker format={'YYYY-MM-DD'} placeholder={'Post Time'} />)}
          </Form.Item>

          <Form.Item>
            <label htmlFor="schema">Schema</label>
            <br />
            {getFieldDecorator('schema', {
              rules: [{ max: 128, message: 'Exceeds max length of 128' }],
            })(<Input placeholder={'Schema'} />)}
          </Form.Item>

          <Form.Item>
            <label htmlFor="tsql">T S Q L</label>
            <br />
            {getFieldDecorator('tsql', {
              rules: [{ required: true, message: 'Required' }],
            })(<Input placeholder={'T S Q L'} />)}
          </Form.Item>

          <Form.Item>
            <label htmlFor="xmlEvent">Xml Event</label>
            <br />
            {getFieldDecorator('xmlEvent', {
              rules: [{ required: true, message: 'Required' }],
            })(<Input placeholder={'Xml Event'} />)}
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

export const WrappedDatabaseLogCreateComponent = Form.create({
  name: 'DatabaseLog Create',
})(DatabaseLogCreateComponent);


/*<Codenesium>
    <Hash>7cd5c87aee6dd5c62c88d70711347637</Hash>
</Codenesium>*/