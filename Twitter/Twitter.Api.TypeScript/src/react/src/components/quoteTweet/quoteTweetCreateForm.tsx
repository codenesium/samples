import React, { Component, FormEvent } from 'react';
import axios, { AxiosError, AxiosResponse } from 'axios';
import { ActionResponse, CreateResponse } from '../../api/apiObjects';
import { Constants, ApiRoutes, ClientRoutes } from '../../constants';
import * as Api from '../../api/models';
import QuoteTweetMapper from './quoteTweetMapper';
import QuoteTweetViewModel from './quoteTweetViewModel';
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
import { TweetSelectComponent } from '../shared/tweetSelect';

interface QuoteTweetCreateComponentProps {
  form: WrappedFormUtils;
  history: any;
  match: any;
}

interface QuoteTweetCreateComponentState {
  model?: QuoteTweetViewModel;
  loading: boolean;
  loaded: boolean;
  errorOccurred: boolean;
  errorMessage: string;
  submitted: boolean;
  submitting: boolean;
}

class QuoteTweetCreateComponent extends React.Component<
  QuoteTweetCreateComponentProps,
  QuoteTweetCreateComponentState
> {
  state = {
    model: new QuoteTweetViewModel(),
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
        let model = values as QuoteTweetViewModel;
        this.submit(model);
      } else {
        this.setState({ ...this.state, submitting: false, submitted: false });
      }
    });
  };

  submit = (model: QuoteTweetViewModel) => {
    let mapper = new QuoteTweetMapper();
    axios
      .post<CreateResponse<Api.QuoteTweetClientRequestModel>>(
        Constants.ApiEndpoint + ApiRoutes.QuoteTweets,
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
            <label htmlFor="retweeterUserId">retweeter_user_id</label>
            <br />
            {getFieldDecorator('retweeterUserId', {
              rules: [{ required: true, message: 'Required' }],
            })(<Input placeholder={'retweeter_user_id'} />)}
          </Form.Item>

          <Form.Item>
            <label htmlFor="sourceTweetId">source_tweet_id</label>
            <br />
            {getFieldDecorator('sourceTweetId', {
              rules: [{ required: true, message: 'Required' }],
            })(<Input placeholder={'source_tweet_id'} />)}
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

export const WrappedQuoteTweetCreateComponent = Form.create({
  name: 'QuoteTweet Create',
})(QuoteTweetCreateComponent);


/*<Codenesium>
    <Hash>ae88ec67af687e8c808928df68d15ee6</Hash>
</Codenesium>*/