import React, { Component, FormEvent } from 'react';
import axios from 'axios';
import { CreateResponse } from '../../api/apiObjects';
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
  };

  handleSubmit = (e: FormEvent<HTMLFormElement>) => {
    e.preventDefault();
    this.props.form.validateFields((err: any, values: any) => {
      if (!err) {
        let model = values as MessengerViewModel;
        console.log('Received values of form: ', model);
        this.submit(model);
      }
    });
  };

  submit = (model: MessengerViewModel) => {
    let mapper = new MessengerMapper();
    axios
      .post(
        Constants.ApiEndpoint + ApiRoutes.Messengers,
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
            Api.MessengerClientRequestModel
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
            <label htmlFor="date">date</label>
            <br />
            {getFieldDecorator('date', {
              rules: [],
            })(<Input placeholder={'date'} />)}
          </Form.Item>

          <Form.Item>
            <label htmlFor="fromUserId">from_user_id</label>
            <br />
            {getFieldDecorator('fromUserId', {
              rules: [],
            })(<Input placeholder={'from_user_id'} />)}
          </Form.Item>

          <Form.Item>
            <label htmlFor="messageId">message_id</label>
            <br />
            {getFieldDecorator('messageId', {
              rules: [],
            })(<Input placeholder={'message_id'} />)}
          </Form.Item>

          <Form.Item>
            <label htmlFor="time">time</label>
            <br />
            {getFieldDecorator('time', {
              rules: [],
            })(<Input placeholder={'time'} />)}
          </Form.Item>

          <Form.Item>
            <label htmlFor="toUserId">to_user_id</label>
            <br />
            {getFieldDecorator('toUserId', {
              rules: [{ required: true, message: 'Required' }],
            })(<Input placeholder={'to_user_id'} />)}
          </Form.Item>

          <Form.Item>
            <label htmlFor="userId">user_id</label>
            <br />
            {getFieldDecorator('userId', {
              rules: [],
            })(<Input placeholder={'user_id'} />)}
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

export const WrappedMessengerCreateComponent = Form.create({
  name: 'Messenger Create',
})(MessengerCreateComponent);


/*<Codenesium>
    <Hash>9b098c8cfffb5bf001447c2bf71bbe83</Hash>
</Codenesium>*/