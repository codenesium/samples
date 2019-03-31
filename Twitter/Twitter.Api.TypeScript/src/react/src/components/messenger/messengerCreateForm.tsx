import React, { Component, FormEvent } from 'react';
import axios, { AxiosError, AxiosResponse } from 'axios';
import { ActionResponse, CreateResponse } from '../../api/apiObjects';
import { Constants, ApiRoutes, ClientRoutes } from '../../constants';
import * as Api from '../../api/models';
import MessengerMapper from './messengerMapper';
import MessengerViewModel from './messengerViewModel';
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
import { MessageSelectComponent } from '../shared/messageSelect';
import { UserSelectComponent } from '../shared/userSelect';

interface MessengerCreateComponentProps {
  form: WrappedFormUtils;
  history: any;
  match: any;
}

interface MessengerCreateComponentState {
  model?: MessengerViewModel;
  loading: boolean;
  loaded: boolean;
  errorOccurred: boolean;
  errorMessage: string;
  submitted: boolean;
  submitting: boolean;
}

class MessengerCreateComponent extends React.Component<
  MessengerCreateComponentProps,
  MessengerCreateComponentState
> {
  state = {
    model: new MessengerViewModel(),
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
        let model = values as MessengerViewModel;
        this.submit(model);
      } else {
        this.setState({ ...this.state, submitting: false, submitted: false });
      }
    });
  };

  submit = (model: MessengerViewModel) => {
    let mapper = new MessengerMapper();
    axios
      .post<CreateResponse<Api.MessengerClientRequestModel>>(
        Constants.ApiEndpoint + ApiRoutes.Messengers,
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
            <label htmlFor="date">date (optional)</label>
            <br />
            {getFieldDecorator('date', {
              rules: [],
            })(<Input placeholder={'date'} />)}
          </Form.Item>

          <Form.Item>
            <label htmlFor="fromUserId">from_user_id (optional)</label>
            <br />
            {getFieldDecorator('fromUserId', {
              rules: [],
            })(<Input placeholder={'from_user_id'} />)}
          </Form.Item>

          <Form.Item>
            <label htmlFor="messageId">message_id (optional)</label>
            <br />
            {getFieldDecorator('messageId', {
              rules: [],
            })(<Input placeholder={'message_id'} />)}
          </Form.Item>

          <Form.Item>
            <label htmlFor="time">time (optional)</label>
            <br />
            {getFieldDecorator('time', {
              rules: [],
            })(<Input placeholder={'time'} />)}
          </Form.Item>

          <Form.Item>
            <label htmlFor="toUserId">to_user_id (required)</label>
            <br />
            {getFieldDecorator('toUserId', {
              rules: [{ required: true, message: 'Required' }],
            })(<Input placeholder={'to_user_id'} />)}
          </Form.Item>

          <Form.Item>
            <label htmlFor="userId">user_id (optional)</label>
            <br />
            {getFieldDecorator('userId', {
              rules: [],
            })(<Input placeholder={'user_id'} />)}
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

export const WrappedMessengerCreateComponent = Form.create({
  name: 'Messenger Create',
})(MessengerCreateComponent);


/*<Codenesium>
    <Hash>dd7cfd376522d72f3ca6f128cdf68b92</Hash>
</Codenesium>*/