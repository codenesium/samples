import React, { Component, FormEvent } from 'react';
import axios from 'axios';
import { CreateResponse } from '../../api/apiObjects';
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
  };

  handleSubmit = (e: FormEvent<HTMLFormElement>) => {
    e.preventDefault();
    this.props.form.validateFields((err: any, values: any) => {
      if (!err) {
        let model = values as UserViewModel;
        console.log('Received values of form: ', model);
        this.submit(model);
      }
    });
  };

  submit = (model: UserViewModel) => {
    let mapper = new UserMapper();
    axios
      .post(
        Constants.ApiEndpoint + ApiRoutes.Users,
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
            Api.UserClientRequestModel
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
            <label htmlFor="bioImgUrl">bio_img_url</label>
            <br />
            {getFieldDecorator('bioImgUrl', {
              rules: [{ max: 32, message: 'Exceeds max length of 32' }],
            })(<Input placeholder={'bio_img_url'} />)}
          </Form.Item>

          <Form.Item>
            <label htmlFor="birthday">birthday</label>
            <br />
            {getFieldDecorator('birthday', {
              rules: [],
            })(<Input placeholder={'birthday'} />)}
          </Form.Item>

          <Form.Item>
            <label htmlFor="contentDescription">content_description</label>
            <br />
            {getFieldDecorator('contentDescription', {
              rules: [{ max: 128, message: 'Exceeds max length of 128' }],
            })(<Input placeholder={'content_description'} />)}
          </Form.Item>

          <Form.Item>
            <label htmlFor="email">email</label>
            <br />
            {getFieldDecorator('email', {
              rules: [
                { required: true, message: 'Required' },
                { max: 32, message: 'Exceeds max length of 32' },
              ],
            })(<Input placeholder={'email'} />)}
          </Form.Item>

          <Form.Item>
            <label htmlFor="fullName">full_name</label>
            <br />
            {getFieldDecorator('fullName', {
              rules: [
                { required: true, message: 'Required' },
                { max: 64, message: 'Exceeds max length of 64' },
              ],
            })(<Input placeholder={'full_name'} />)}
          </Form.Item>

          <Form.Item>
            <label htmlFor="headerImgUrl">header_img_url</label>
            <br />
            {getFieldDecorator('headerImgUrl', {
              rules: [{ max: 32, message: 'Exceeds max length of 32' }],
            })(<Input placeholder={'header_img_url'} />)}
          </Form.Item>

          <Form.Item>
            <label htmlFor="interest">interest</label>
            <br />
            {getFieldDecorator('interest', {
              rules: [{ max: 128, message: 'Exceeds max length of 128' }],
            })(<Input placeholder={'interest'} />)}
          </Form.Item>

          <Form.Item>
            <label htmlFor="locationLocationId">location_location_id</label>
            <br />
            {getFieldDecorator('locationLocationId', {
              rules: [{ required: true, message: 'Required' }],
            })(<Input placeholder={'location_location_id'} />)}
          </Form.Item>

          <Form.Item>
            <label htmlFor="password">password</label>
            <br />
            {getFieldDecorator('password', {
              rules: [
                { required: true, message: 'Required' },
                { max: 32, message: 'Exceeds max length of 32' },
              ],
            })(<Input placeholder={'password'} />)}
          </Form.Item>

          <Form.Item>
            <label htmlFor="phoneNumber">phone_number</label>
            <br />
            {getFieldDecorator('phoneNumber', {
              rules: [{ max: 32, message: 'Exceeds max length of 32' }],
            })(<Input placeholder={'phone_number'} />)}
          </Form.Item>

          <Form.Item>
            <label htmlFor="privacy">privacy</label>
            <br />
            {getFieldDecorator('privacy', {
              rules: [
                { required: true, message: 'Required' },
                { max: 1, message: 'Exceeds max length of 1' },
              ],
            })(<Input placeholder={'privacy'} />)}
          </Form.Item>

          <Form.Item>
            <label htmlFor="username">username</label>
            <br />
            {getFieldDecorator('username', {
              rules: [
                { required: true, message: 'Required' },
                { max: 64, message: 'Exceeds max length of 64' },
              ],
            })(<Input placeholder={'username'} />)}
          </Form.Item>

          <Form.Item>
            <label htmlFor="website">website</label>
            <br />
            {getFieldDecorator('website', {
              rules: [{ max: 32, message: 'Exceeds max length of 32' }],
            })(<Input placeholder={'website'} />)}
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

export const WrappedUserCreateComponent = Form.create({ name: 'User Create' })(
  UserCreateComponent
);


/*<Codenesium>
    <Hash>a18b99050a5877cb819f9eeb55ec2f12</Hash>
</Codenesium>*/