import React, { Component, FormEvent } from 'react';
import axios, { AxiosError, AxiosResponse } from 'axios';
import { ActionResponse, CreateResponse } from '../../api/apiObjects';
import { Constants, ApiRoutes, ClientRoutes } from '../../constants';
import * as Api from '../../api/models';
import UserMapper from './userMapper';
import UserViewModel from './userViewModel';
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
interface UserEditComponentProps {
  form: WrappedFormUtils;
  history: any;
  match: any;
}

interface UserEditComponentState {
  model?: UserViewModel;
  loading: boolean;
  loaded: boolean;
  errorOccurred: boolean;
  errorMessage: string;
  submitted: boolean;
  submitting: boolean;
}

class UserEditComponent extends React.Component<
  UserEditComponentProps,
  UserEditComponentState
> {
  state = {
    model: new UserViewModel(),
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
      .get<Api.UserClientResponseModel>(
        Constants.ApiEndpoint +
          ApiRoutes.Users +
          '/' +
          this.props.match.params.id,
        {
          headers: GlobalUtilities.defaultHeaders(),
        }
      )
      .then(response => {
        GlobalUtilities.logInfo(response);

        let mapper = new UserMapper();

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
        let model = values as UserViewModel;
        this.submit(model);
      } else {
        this.setState({ ...this.state, submitting: false, submitted: false });
      }
    });
  };

  submit = (model: UserViewModel) => {
    let mapper = new UserMapper();
    axios
      .put<CreateResponse<Api.UserClientRequestModel>>(
        Constants.ApiEndpoint + ApiRoutes.Users + '/' + this.state.model!.id,
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

export const WrappedUserEditComponent = Form.create({ name: 'User Edit' })(
  UserEditComponent
);


/*<Codenesium>
    <Hash>0a5152b5a7c17b4b96d39637d7c6d728</Hash>
</Codenesium>*/