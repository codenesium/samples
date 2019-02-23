import React, { Component, FormEvent } from 'react';
import axios from 'axios';
import { CreateResponse } from '../../api/apiObjects';
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
  };

  handleSubmit = (e: FormEvent<HTMLFormElement>) => {
    e.preventDefault();
    this.props.form.validateFields((err: any, values: any) => {
      if (!err) {
        let model = values as QuoteTweetViewModel;
        console.log('Received values of form: ', model);
        this.submit(model);
      }
    });
  };

  submit = (model: QuoteTweetViewModel) => {
    let mapper = new QuoteTweetMapper();
    axios
      .post(
        Constants.ApiEndpoint + ApiRoutes.QuoteTweets,
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
            Api.QuoteTweetClientRequestModel
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

export const WrappedQuoteTweetCreateComponent = Form.create({
  name: 'QuoteTweet Create',
})(QuoteTweetCreateComponent);


/*<Codenesium>
    <Hash>0142b33bc9d1d0015ee2e89d216766a3</Hash>
</Codenesium>*/