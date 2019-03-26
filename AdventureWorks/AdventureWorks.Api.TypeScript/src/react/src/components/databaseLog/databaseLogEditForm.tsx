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
interface DatabaseLogEditComponentProps {
  form: WrappedFormUtils;
  history: any;
  match: any;
}

interface DatabaseLogEditComponentState {
  model?: DatabaseLogViewModel;
  loading: boolean;
  loaded: boolean;
  errorOccurred: boolean;
  errorMessage: string;
  submitted: boolean;
  submitting: boolean;
}

class DatabaseLogEditComponent extends React.Component<
  DatabaseLogEditComponentProps,
  DatabaseLogEditComponentState
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

  componentDidMount() {
    this.setState({ ...this.state, loading: true });

    axios
      .get<Api.DatabaseLogClientResponseModel>(
        Constants.ApiEndpoint +
          ApiRoutes.DatabaseLogs +
          '/' +
          this.props.match.params.id,
        {
          headers: GlobalUtilities.defaultHeaders(),
        }
      )
      .then(response => {
        GlobalUtilities.logInfo(response);

        let mapper = new DatabaseLogMapper();

        this.setState({
          model: mapper.mapApiResponseToViewModel(response.data),
          loading: false,
          loaded: true,
          errorOccurred: false,
          errorMessage: '',
        });

        this.props.form.setFieldsValue(
          mapper.mapApiResponseToViewModel(response.data)
        );
      })
      .catch((error: AxiosError) => {
        GlobalUtilities.logError(error);

        if (error.response && error.response.status == 422) {
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
  }

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
      .put<CreateResponse<Api.DatabaseLogClientRequestModel>>(
        Constants.ApiEndpoint +
          ApiRoutes.DatabaseLogs +
          '/' +
          this.state.model!.databaseLogID,
        mapper.mapViewModelToApiRequest(model),
        {
          headers: GlobalUtilities.defaultHeaders(),
        }
      )
      .then(response => {
        GlobalUtilities.logInfo(response);
        this.setState({
          ...this.state,
          submitted: true,
          submitting: false,
          model: mapper.mapApiResponseToViewModel(response.data.record!),
          errorOccurred: false,
          errorMessage: '',
        });
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

export const WrappedDatabaseLogEditComponent = Form.create({
  name: 'DatabaseLog Edit',
})(DatabaseLogEditComponent);


/*<Codenesium>
    <Hash>f1ca6f28668d018531f1697b134a41ed</Hash>
</Codenesium>*/