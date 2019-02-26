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
interface MessengerEditComponentProps {
  form: WrappedFormUtils;
  history: any;
  match: any;
}

interface MessengerEditComponentState {
  model?: MessengerViewModel;
  loading: boolean;
  loaded: boolean;
  errorOccurred: boolean;
  errorMessage: string;
  submitted: boolean;
}

class MessengerEditComponent extends React.Component<
  MessengerEditComponentProps,
  MessengerEditComponentState
> {
  state = {
    model: new MessengerViewModel(),
    loading: false,
    loaded: true,
    errorOccurred: false,
    errorMessage: '',
    submitted: false,
  };

  componentDidMount() {
    this.setState({ ...this.state, loading: true });

    axios
      .get(
        Constants.ApiEndpoint +
          ApiRoutes.Messengers +
          '/' +
          this.props.match.params.id,
        {
          headers: {
            'Content-Type': 'application/json',
          },
        }
      )
      .then(
        resp => {
          let response = resp.data as Api.MessengerClientResponseModel;

          console.log(response);

          let mapper = new MessengerMapper();

          this.setState({
            model: mapper.mapApiResponseToViewModel(response),
            loading: false,
            loaded: true,
            errorOccurred: false,
            errorMessage: '',
          });

          this.props.form.setFieldsValue(
            mapper.mapApiResponseToViewModel(response)
          );
        },
        error => {
          console.log(error);
          this.setState({
            model: undefined,
            loading: false,
            loaded: false,
            errorOccurred: true,
            errorMessage: 'Error from API',
          });
        }
      );
  }

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
      .put(
        Constants.ApiEndpoint +
          ApiRoutes.Messengers +
          '/' +
          this.state.model!.id,
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

export const WrappedMessengerEditComponent = Form.create({
  name: 'Messenger Edit',
})(MessengerEditComponent);


/*<Codenesium>
    <Hash>06568a9b2a9ae58843624d4553b908c4</Hash>
</Codenesium>*/