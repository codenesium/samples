import React, { Component, FormEvent } from 'react';
import axios, { AxiosError, AxiosResponse } from 'axios';
import { ActionResponse, CreateResponse } from '../../api/apiObjects';
import { Constants, ApiRoutes, ClientRoutes } from '../../constants';
import * as Api from '../../api/models';
import RetweetMapper from './retweetMapper';
import RetweetViewModel from './retweetViewModel';
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

interface RetweetCreateComponentProps {
  form: WrappedFormUtils;
  history: any;
  match: any;
}

interface RetweetCreateComponentState {
  model?: RetweetViewModel;
  loading: boolean;
  loaded: boolean;
  errorOccurred: boolean;
  errorMessage: string;
  submitted: boolean;
  submitting: boolean;
}

class RetweetCreateComponent extends React.Component<
  RetweetCreateComponentProps,
  RetweetCreateComponentState
> {
  state = {
    model: new RetweetViewModel(),
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
        let model = values as RetweetViewModel;
        this.submit(model);
      } else {
        this.setState({ ...this.state, submitting: false, submitted: false });
      }
    });
  };

  submit = (model: RetweetViewModel) => {
    let mapper = new RetweetMapper();
    axios
      .post<CreateResponse<Api.RetweetClientRequestModel>>(
        Constants.ApiEndpoint + ApiRoutes.Retweets,
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
            <label htmlFor="date">date</label>
            <br />
            {getFieldDecorator('date', {
              rules: [],
            })(<Input placeholder={'date'} />)}
          </Form.Item>

          <Form.Item>
            <label htmlFor="retwitterUserId">retwitter_user_id</label>
            <br />
            {getFieldDecorator('retwitterUserId', {
              rules: [],
            })(<Input placeholder={'retwitter_user_id'} />)}
          </Form.Item>

          <Form.Item>
            <label htmlFor="time">time</label>
            <br />
            {getFieldDecorator('time', {
              rules: [],
            })(<Input placeholder={'time'} />)}
          </Form.Item>

          <Form.Item>
            <label htmlFor="tweetTweetId">tweet_tweet_id</label>
            <br />
            {getFieldDecorator('tweetTweetId', {
              rules: [{ required: true, message: 'Required' }],
            })(<Input placeholder={'tweet_tweet_id'} />)}
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

export const WrappedRetweetCreateComponent = Form.create({
  name: 'Retweet Create',
})(RetweetCreateComponent);


/*<Codenesium>
    <Hash>fee26e6a2c94fd85a69b26176153d9c0</Hash>
</Codenesium>*/