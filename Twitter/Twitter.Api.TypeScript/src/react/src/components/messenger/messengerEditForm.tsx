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
  submitting: boolean;
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
    submitting: false,
  };

  componentDidMount() {
    this.setState({ ...this.state, loading: true });

    axios
      .get<Api.MessengerClientResponseModel>(
        Constants.ApiEndpoint +
          ApiRoutes.Messengers +
          '/' +
          this.props.match.params.id,
        {
          headers: GlobalUtilities.defaultHeaders(),
        }
      )
      .then(response => {
        GlobalUtilities.logInfo(response);

        let mapper = new MessengerMapper();

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
      .put<CreateResponse<Api.MessengerClientRequestModel>>(
        Constants.ApiEndpoint +
          ApiRoutes.Messengers +
          '/' +
          this.state.model!.id,
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

export const WrappedMessengerEditComponent = Form.create({
  name: 'Messenger Edit',
})(MessengerEditComponent);


/*<Codenesium>
    <Hash>0efa899dd9477f6184eab2bd0ed8dc60</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/