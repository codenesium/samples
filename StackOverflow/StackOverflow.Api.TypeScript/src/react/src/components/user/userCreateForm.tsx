import React, { Component, FormEvent } from 'react';
import axios from 'axios';
import { CreateResponse } from '../../api/apiObjects';
import { LoadingForm } from '../../lib/components/loadingForm';
import { ErrorForm } from '../../lib/components/errorForm';
import { Constants, ApiRoutes, ClientRoutes } from '../../constants';
import * as Api from '../../api/models';
import UserMapper from './userMapper';
import UserViewModel from './userViewModel';
import { Form, Input, Button, Checkbox, InputNumber, DatePicker } from 'antd';
import { WrappedFormUtils } from 'antd/es/form/Form';
import { Alert } from 'antd';

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
      return <LoadingForm />;
    } else if (this.state.loaded) {
      return (
        <Form onSubmit={this.handleSubmit}>
          <Form.Item>
            <label htmlFor="aboutMe">AboutMe</label>
            <br />
            {getFieldDecorator('aboutMe', {
              rules: [],
            })(<Input placeholder={'AboutMe'} id={'aboutMe'} />)}
          </Form.Item>

          <Form.Item>
            <label htmlFor="accountId">AccountId</label>
            <br />
            {getFieldDecorator('accountId', {
              rules: [],
            })(<Input placeholder={'AccountId'} id={'accountId'} />)}
          </Form.Item>

          <Form.Item>
            <label htmlFor="age">Age</label>
            <br />
            {getFieldDecorator('age', {
              rules: [],
            })(<Input placeholder={'Age'} id={'age'} />)}
          </Form.Item>

          <Form.Item>
            <label htmlFor="creationDate">CreationDate</label>
            <br />
            {getFieldDecorator('creationDate', {
              rules: [],
            })(<Input placeholder={'CreationDate'} id={'creationDate'} />)}
          </Form.Item>

          <Form.Item>
            <label htmlFor="displayName">DisplayName</label>
            <br />
            {getFieldDecorator('displayName', {
              rules: [],
            })(<Input placeholder={'DisplayName'} id={'displayName'} />)}
          </Form.Item>

          <Form.Item>
            <label htmlFor="downVote">DownVotes</label>
            <br />
            {getFieldDecorator('downVote', {
              rules: [],
            })(<Input placeholder={'DownVotes'} id={'downVote'} />)}
          </Form.Item>

          <Form.Item>
            <label htmlFor="emailHash">EmailHash</label>
            <br />
            {getFieldDecorator('emailHash', {
              rules: [],
            })(<Input placeholder={'EmailHash'} id={'emailHash'} />)}
          </Form.Item>

          <Form.Item>
            <label htmlFor="lastAccessDate">LastAccessDate</label>
            <br />
            {getFieldDecorator('lastAccessDate', {
              rules: [],
            })(<Input placeholder={'LastAccessDate'} id={'lastAccessDate'} />)}
          </Form.Item>

          <Form.Item>
            <label htmlFor="location">Location</label>
            <br />
            {getFieldDecorator('location', {
              rules: [],
            })(<Input placeholder={'Location'} id={'location'} />)}
          </Form.Item>

          <Form.Item>
            <label htmlFor="reputation">Reputation</label>
            <br />
            {getFieldDecorator('reputation', {
              rules: [],
            })(<Input placeholder={'Reputation'} id={'reputation'} />)}
          </Form.Item>

          <Form.Item>
            <label htmlFor="upVote">UpVotes</label>
            <br />
            {getFieldDecorator('upVote', {
              rules: [],
            })(<Input placeholder={'UpVotes'} id={'upVote'} />)}
          </Form.Item>

          <Form.Item>
            <label htmlFor="view">Views</label>
            <br />
            {getFieldDecorator('view', {
              rules: [],
            })(<Input placeholder={'Views'} id={'view'} />)}
          </Form.Item>

          <Form.Item>
            <label htmlFor="websiteUrl">WebsiteUrl</label>
            <br />
            {getFieldDecorator('websiteUrl', {
              rules: [],
            })(<Input placeholder={'WebsiteUrl'} id={'websiteUrl'} />)}
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
    <Hash>24aca5e77632ea5a1cc3d8080bfba94d</Hash>
</Codenesium>*/