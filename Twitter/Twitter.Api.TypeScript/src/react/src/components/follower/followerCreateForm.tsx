import React, { Component, FormEvent } from 'react';
import axios, { AxiosError, AxiosResponse } from 'axios';
import { ActionResponse, CreateResponse } from '../../api/apiObjects';
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
import * as GlobalUtilities from '../../lib/globalUtilities';
import { UserSelectComponent } from '../shared/userSelect';

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
  submitting: boolean;
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
    submitting: false,
  };

  handleSubmit = (e: FormEvent<HTMLFormElement>) => {
    e.preventDefault();
    this.setState({ ...this.state, submitting: true, submitted: false });
    this.props.form.validateFields((err: any, values: any) => {
      if (!err) {
        let model = values as FollowerViewModel;
        this.submit(model);
      } else {
        this.setState({ ...this.state, submitting: false, submitted: false });
      }
    });
  };

  submit = (model: FollowerViewModel) => {
    let mapper = new FollowerMapper();
    axios
      .post<CreateResponse<Api.FollowerClientRequestModel>>(
        Constants.ApiEndpoint + ApiRoutes.Followers,
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
            <label htmlFor="blocked">blocked (required)</label>
            <br />
            {getFieldDecorator('blocked', {
              rules: [
                { required: true, message: 'Required' },
                { max: 1, message: 'Exceeds max length of 1' },
              ],
            })(<Input placeholder={'blocked'} />)}
          </Form.Item>

          <Form.Item>
            <label htmlFor="dateFollowed">date_followed (required)</label>
            <br />
            {getFieldDecorator('dateFollowed', {
              rules: [{ required: true, message: 'Required' }],
            })(<Input placeholder={'date_followed'} />)}
          </Form.Item>

          <Form.Item>
            <label htmlFor="followRequestStatu">
              follow_request_status (required)
            </label>
            <br />
            {getFieldDecorator('followRequestStatu', {
              rules: [
                { required: true, message: 'Required' },
                { max: 1, message: 'Exceeds max length of 1' },
              ],
            })(<Input placeholder={'follow_request_status'} />)}
          </Form.Item>

          <Form.Item>
            <label htmlFor="followedUserId">followed_user_id (required)</label>
            <br />
            {getFieldDecorator('followedUserId', {
              rules: [{ required: true, message: 'Required' }],
            })(<Input placeholder={'followed_user_id'} />)}
          </Form.Item>

          <Form.Item>
            <label htmlFor="followingUserId">
              following_user_id (required)
            </label>
            <br />
            {getFieldDecorator('followingUserId', {
              rules: [{ required: true, message: 'Required' }],
            })(<Input placeholder={'following_user_id'} />)}
          </Form.Item>

          <Form.Item>
            <label htmlFor="muted">muted (required)</label>
            <br />
            {getFieldDecorator('muted', {
              rules: [
                { required: true, message: 'Required' },
                { max: 1, message: 'Exceeds max length of 1' },
              ],
            })(<Input placeholder={'muted'} />)}
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

export const WrappedFollowerCreateComponent = Form.create({
  name: 'Follower Create',
})(FollowerCreateComponent);


/*<Codenesium>
    <Hash>675469e096c99d9a7436ce942cff1c1a</Hash>
</Codenesium>*/