import React, { Component, FormEvent } from 'react';
import axios, { AxiosError, AxiosResponse } from 'axios';
import { ActionResponse, CreateResponse } from '../../api/apiObjects';
import { Constants, ApiRoutes, ClientRoutes } from '../../constants';
import * as Api from '../../api/models';
import UsersMapper from './usersMapper';
import UsersViewModel from './usersViewModel';
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

interface UsersCreateComponentProps {
  form: WrappedFormUtils;
  history: any;
  match: any;
}

interface UsersCreateComponentState {
  model?: UsersViewModel;
  loading: boolean;
  loaded: boolean;
  errorOccurred: boolean;
  errorMessage: string;
  submitted: boolean;
  submitting: boolean;
}

class UsersCreateComponent extends React.Component<
  UsersCreateComponentProps,
  UsersCreateComponentState
> {
  state = {
    model: new UsersViewModel(),
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
        let model = values as UsersViewModel;
        this.submit(model);
      } else {
        this.setState({ ...this.state, submitting: false, submitted: false });
      }
    });
  };

  submit = (model: UsersViewModel) => {
    let mapper = new UsersMapper();
    axios
      .post<CreateResponse<Api.UsersClientRequestModel>>(
        Constants.ApiEndpoint + ApiRoutes.Users,
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
            <label htmlFor="aboutMe">About Me</label>
            <br />
            {getFieldDecorator('aboutMe', {
              rules: [],
            })(<Input placeholder={'About Me'} />)}
          </Form.Item>

          <Form.Item>
            <label htmlFor="accountId">Account</label>
            <br />
            {getFieldDecorator('accountId', {
              rules: [],
            })(<Input placeholder={'Account'} />)}
          </Form.Item>

          <Form.Item>
            <label htmlFor="age">Age</label>
            <br />
            {getFieldDecorator('age', {
              rules: [],
            })(<Input placeholder={'Age'} />)}
          </Form.Item>

          <Form.Item>
            <label htmlFor="creationDate">Creation Date</label>
            <br />
            {getFieldDecorator('creationDate', {
              rules: [{ required: true, message: 'Required' }],
            })(
              <DatePicker format={'YYYY-MM-DD'} placeholder={'Creation Date'} />
            )}
          </Form.Item>

          <Form.Item>
            <label htmlFor="displayName">Display Name</label>
            <br />
            {getFieldDecorator('displayName', {
              rules: [
                { required: true, message: 'Required' },
                { max: 40, message: 'Exceeds max length of 40' },
              ],
            })(<Input placeholder={'Display Name'} />)}
          </Form.Item>

          <Form.Item>
            <label htmlFor="downVote">Down Vote</label>
            <br />
            {getFieldDecorator('downVote', {
              rules: [{ required: true, message: 'Required' }],
            })(<Input placeholder={'Down Vote'} />)}
          </Form.Item>

          <Form.Item>
            <label htmlFor="emailHash">Email Hash</label>
            <br />
            {getFieldDecorator('emailHash', {
              rules: [{ max: 40, message: 'Exceeds max length of 40' }],
            })(<Input placeholder={'Email Hash'} />)}
          </Form.Item>

          <Form.Item>
            <label htmlFor="lastAccessDate">Last Access Date</label>
            <br />
            {getFieldDecorator('lastAccessDate', {
              rules: [{ required: true, message: 'Required' }],
            })(
              <DatePicker
                format={'YYYY-MM-DD'}
                placeholder={'Last Access Date'}
              />
            )}
          </Form.Item>

          <Form.Item>
            <label htmlFor="location">Location</label>
            <br />
            {getFieldDecorator('location', {
              rules: [{ max: 100, message: 'Exceeds max length of 100' }],
            })(<Input placeholder={'Location'} />)}
          </Form.Item>

          <Form.Item>
            <label htmlFor="reputation">Reputation</label>
            <br />
            {getFieldDecorator('reputation', {
              rules: [{ required: true, message: 'Required' }],
            })(<Input placeholder={'Reputation'} />)}
          </Form.Item>

          <Form.Item>
            <label htmlFor="upVote">Up Vote</label>
            <br />
            {getFieldDecorator('upVote', {
              rules: [{ required: true, message: 'Required' }],
            })(<Input placeholder={'Up Vote'} />)}
          </Form.Item>

          <Form.Item>
            <label htmlFor="view">View</label>
            <br />
            {getFieldDecorator('view', {
              rules: [{ required: true, message: 'Required' }],
            })(<Input placeholder={'View'} />)}
          </Form.Item>

          <Form.Item>
            <label htmlFor="websiteUrl">Website Url</label>
            <br />
            {getFieldDecorator('websiteUrl', {
              rules: [{ max: 200, message: 'Exceeds max length of 200' }],
            })(<Input placeholder={'Website Url'} />)}
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

export const WrappedUsersCreateComponent = Form.create({
  name: 'Users Create',
})(UsersCreateComponent);


/*<Codenesium>
    <Hash>c0ef0c48f220ec62fd60afc2af1a2b2b</Hash>
</Codenesium>*/