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
import { LocationSelectComponent } from '../shared/locationSelect';

interface UserCreateComponentProps {
  form: WrappedFormUtils;
  history: any;
  match: any;
}

interface UserCreateComponentState {
  model?: UserViewModel;
  loading: boolean;
  loaded: boolean;
  errorOccurred: boolean;
  errorMessage: string;
  submitted: boolean;
  submitting: boolean;
}

class UserCreateComponent extends React.Component<
  UserCreateComponentProps,
  UserCreateComponentState
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
      .post<CreateResponse<Api.UserClientRequestModel>>(
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
            <label htmlFor="bioImgUrl">bio_img_url (optional)</label>
            <br />
            {getFieldDecorator('bioImgUrl', {
              rules: [{ max: 32, message: 'Exceeds max length of 32' }],
            })(<Input placeholder={'bio_img_url'} />)}
          </Form.Item>

          <Form.Item>
            <label htmlFor="birthday">birthday (optional)</label>
            <br />
            {getFieldDecorator('birthday', {
              rules: [],
            })(<Input placeholder={'birthday'} />)}
          </Form.Item>

          <Form.Item>
            <label htmlFor="contentDescription">
              content_description (optional)
            </label>
            <br />
            {getFieldDecorator('contentDescription', {
              rules: [{ max: 128, message: 'Exceeds max length of 128' }],
            })(<Input placeholder={'content_description'} />)}
          </Form.Item>

          <Form.Item>
            <label htmlFor="email">email (required)</label>
            <br />
            {getFieldDecorator('email', {
              rules: [
                { required: true, message: 'Required' },
                { max: 32, message: 'Exceeds max length of 32' },
              ],
            })(<Input placeholder={'email'} />)}
          </Form.Item>

          <Form.Item>
            <label htmlFor="fullName">full_name (required)</label>
            <br />
            {getFieldDecorator('fullName', {
              rules: [
                { required: true, message: 'Required' },
                { max: 64, message: 'Exceeds max length of 64' },
              ],
            })(<Input placeholder={'full_name'} />)}
          </Form.Item>

          <Form.Item>
            <label htmlFor="headerImgUrl">header_img_url (optional)</label>
            <br />
            {getFieldDecorator('headerImgUrl', {
              rules: [{ max: 32, message: 'Exceeds max length of 32' }],
            })(<Input placeholder={'header_img_url'} />)}
          </Form.Item>

          <Form.Item>
            <label htmlFor="interest">interest (optional)</label>
            <br />
            {getFieldDecorator('interest', {
              rules: [{ max: 128, message: 'Exceeds max length of 128' }],
            })(<Input placeholder={'interest'} />)}
          </Form.Item>

          <Form.Item>
            <label htmlFor="locationLocationId">
              location_location_id (required)
            </label>
            <br />
            {getFieldDecorator('locationLocationId', {
              rules: [{ required: true, message: 'Required' }],
            })(<Input placeholder={'location_location_id'} />)}
          </Form.Item>

          <Form.Item>
            <label htmlFor="password">password (required)</label>
            <br />
            {getFieldDecorator('password', {
              rules: [
                { required: true, message: 'Required' },
                { max: 32, message: 'Exceeds max length of 32' },
              ],
            })(<Input placeholder={'password'} />)}
          </Form.Item>

          <Form.Item>
            <label htmlFor="phoneNumber">phone_number (optional)</label>
            <br />
            {getFieldDecorator('phoneNumber', {
              rules: [{ max: 32, message: 'Exceeds max length of 32' }],
            })(<Input placeholder={'phone_number'} />)}
          </Form.Item>

          <Form.Item>
            <label htmlFor="privacy">privacy (required)</label>
            <br />
            {getFieldDecorator('privacy', {
              rules: [
                { required: true, message: 'Required' },
                { max: 1, message: 'Exceeds max length of 1' },
              ],
            })(<Input placeholder={'privacy'} />)}
          </Form.Item>

          <Form.Item>
            <label htmlFor="username">username (required)</label>
            <br />
            {getFieldDecorator('username', {
              rules: [
                { required: true, message: 'Required' },
                { max: 64, message: 'Exceeds max length of 64' },
              ],
            })(<Input placeholder={'username'} />)}
          </Form.Item>

          <Form.Item>
            <label htmlFor="website">website (optional)</label>
            <br />
            {getFieldDecorator('website', {
              rules: [{ max: 32, message: 'Exceeds max length of 32' }],
            })(<Input placeholder={'website'} />)}
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

export const WrappedUserCreateComponent = Form.create({ name: 'User Create' })(
  UserCreateComponent
);


/*<Codenesium>
    <Hash>d25c0250536f2b9c81d0d8d13d273c87</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/