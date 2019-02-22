import React, { Component, FormEvent } from 'react';
import axios from 'axios';
import { CreateResponse } from '../../api/apiObjects';
import { Constants, ApiRoutes, ClientRoutes } from '../../constants';
import * as Api from '../../api/models';
import FollowerMapper from './followerMapper';
import FollowerViewModel from './followerViewModel';
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

interface FollowerCreateComponentProps {
  form: WrappedFormUtils;
  history: any;
  match: any;
}

interface FollowerCreateComponentState {
  model?: FollowerViewModel;
  loading: boolean;
  loaded: boolean;
  errorOccurred: boolean;
  errorMessage: string;
  submitted: boolean;
}

class FollowerCreateComponent extends React.Component<
  FollowerCreateComponentProps,
  FollowerCreateComponentState
> {
  state = {
    model: new FollowerViewModel(),
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
        let model = values as FollowerViewModel;
        console.log('Received values of form: ', model);
        this.submit(model);
      }
    });
  };

  submit = (model: FollowerViewModel) => {
    let mapper = new FollowerMapper();
    axios
      .post(
        Constants.ApiEndpoint + ApiRoutes.Followers,
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
            Api.FollowerClientRequestModel
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
            <label htmlFor="blocked">blocked</label>
            <br />
            {getFieldDecorator('blocked', {
              rules: [
                { required: true, message: 'Required' },
                { whitespace: true, message: 'Required' },
                { max: 1, message: 'Exceeds max length of 1' },
              ],
            })(<Input placeholder={'blocked'} />)}
          </Form.Item>

          <Form.Item>
            <label htmlFor="dateFollowed">date_followed</label>
            <br />
            {getFieldDecorator('dateFollowed', {
              rules: [
                { required: true, message: 'Required' },
                { whitespace: true, message: 'Required' },
              ],
            })(<Input placeholder={'date_followed'} />)}
          </Form.Item>

          <Form.Item>
            <label htmlFor="followRequestStatu">follow_request_status</label>
            <br />
            {getFieldDecorator('followRequestStatu', {
              rules: [
                { required: true, message: 'Required' },
                { whitespace: true, message: 'Required' },
                { max: 1, message: 'Exceeds max length of 1' },
              ],
            })(<Input placeholder={'follow_request_status'} />)}
          </Form.Item>

          <Form.Item>
            <label htmlFor="followedUserId">followed_user_id</label>
            <br />
            {getFieldDecorator('followedUserId', {
              rules: [
                { required: true, message: 'Required' },
                { whitespace: true, message: 'Required' },
              ],
            })(<Input placeholder={'followed_user_id'} />)}
          </Form.Item>

          <Form.Item>
            <label htmlFor="followingUserId">following_user_id</label>
            <br />
            {getFieldDecorator('followingUserId', {
              rules: [
                { required: true, message: 'Required' },
                { whitespace: true, message: 'Required' },
              ],
            })(<Input placeholder={'following_user_id'} />)}
          </Form.Item>

          <Form.Item>
            <label htmlFor="muted">muted</label>
            <br />
            {getFieldDecorator('muted', {
              rules: [
                { required: true, message: 'Required' },
                { whitespace: true, message: 'Required' },
                { max: 1, message: 'Exceeds max length of 1' },
              ],
            })(<Input placeholder={'muted'} />)}
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

export const WrappedFollowerCreateComponent = Form.create({
  name: 'Follower Create',
})(FollowerCreateComponent);


/*<Codenesium>
    <Hash>0895424c782ca42afa3ed5d457f2aa5e</Hash>
</Codenesium>*/