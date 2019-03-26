import React, { Component, FormEvent } from 'react';
import axios, { AxiosError, AxiosResponse } from 'axios';
import { ActionResponse, CreateResponse } from '../../api/apiObjects';
import { Constants, ApiRoutes, ClientRoutes } from '../../constants';
import * as Api from '../../api/models';
import ReplyMapper from './replyMapper';
import ReplyViewModel from './replyViewModel';
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
import { UserSelectComponent } from '../shared/userSelect';

interface ReplyCreateComponentProps {
  form: WrappedFormUtils;
  history: any;
  match: any;
}

interface ReplyCreateComponentState {
  model?: ReplyViewModel;
  loading: boolean;
  loaded: boolean;
  errorOccurred: boolean;
  errorMessage: string;
  submitted: boolean;
  submitting: boolean;
}

class ReplyCreateComponent extends React.Component<
  ReplyCreateComponentProps,
  ReplyCreateComponentState
> {
  state = {
    model: new ReplyViewModel(),
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
        let model = values as ReplyViewModel;
        this.submit(model);
      } else {
        this.setState({ ...this.state, submitting: false, submitted: false });
      }
    });
  };

  submit = (model: ReplyViewModel) => {
    let mapper = new ReplyMapper();
    axios
      .post<CreateResponse<Api.ReplyClientRequestModel>>(
        Constants.ApiEndpoint + ApiRoutes.Replies,
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
            <label htmlFor="content">content</label>
            <br />
            {getFieldDecorator('content', {
              rules: [
                { required: true, message: 'Required' },
                { max: 140, message: 'Exceeds max length of 140' },
              ],
            })(<Input placeholder={'content'} />)}
          </Form.Item>

          <Form.Item>
            <label htmlFor="date">date</label>
            <br />
            {getFieldDecorator('date', {
              rules: [{ required: true, message: 'Required' }],
            })(<Input placeholder={'date'} />)}
          </Form.Item>

          <Form.Item>
            <label htmlFor="replierUserId">replier_user_id</label>
            <br />
            {getFieldDecorator('replierUserId', {
              rules: [{ required: true, message: 'Required' }],
            })(<Input placeholder={'replier_user_id'} />)}
          </Form.Item>

          <Form.Item>
            <label htmlFor="time">time</label>
            <br />
            {getFieldDecorator('time', {
              rules: [{ required: true, message: 'Required' }],
            })(<Input placeholder={'time'} />)}
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

export const WrappedReplyCreateComponent = Form.create({
  name: 'Reply Create',
})(ReplyCreateComponent);


/*<Codenesium>
    <Hash>587788547ec34f5515aa6cf894cd9546</Hash>
</Codenesium>*/