import React, { Component, FormEvent } from 'react';
import axios from 'axios';
import { CreateResponse } from '../../api/apiObjects';
import { Constants, ApiRoutes, ClientRoutes } from '../../constants';
import * as Api from '../../api/models';
import PostHistoryMapper from './postHistoryMapper';
import PostHistoryViewModel from './postHistoryViewModel';
import {
  Form,
  Input,
  Button,
  Switch,
  InputNumber,
  DatePicker,
  Spin,
  Alert,
} from 'antd';
import { WrappedFormUtils } from 'antd/es/form/Form';

interface PostHistoryCreateComponentProps {
  form: WrappedFormUtils;
  history: any;
  match: any;
}

interface PostHistoryCreateComponentState {
  model?: PostHistoryViewModel;
  loading: boolean;
  loaded: boolean;
  errorOccurred: boolean;
  errorMessage: string;
  submitted: boolean;
}

class PostHistoryCreateComponent extends React.Component<
  PostHistoryCreateComponentProps,
  PostHistoryCreateComponentState
> {
  state = {
    model: new PostHistoryViewModel(),
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
        let model = values as PostHistoryViewModel;
        console.log('Received values of form: ', model);
        this.submit(model);
      }
    });
  };

  submit = (model: PostHistoryViewModel) => {
    let mapper = new PostHistoryMapper();
    axios
      .post(
        Constants.ApiEndpoint + ApiRoutes.PostHistories,
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
            Api.PostHistoryClientRequestModel
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
            <label htmlFor="comment">Comment</label>
            <br />
            {getFieldDecorator('comment', {
              rules: [],
            })(<Input placeholder={'Comment'} id={'comment'} />)}
          </Form.Item>

          <Form.Item>
            <label htmlFor="creationDate">CreationDate</label>
            <br />
            {getFieldDecorator('creationDate', {
              rules: [],
            })(<Input placeholder={'CreationDate'} id={'creationDate'} />)}
          </Form.Item>

          <Form.Item>
            <label htmlFor="postHistoryTypeId">PostHistoryTypeId</label>
            <br />
            {getFieldDecorator('postHistoryTypeId', {
              rules: [],
            })(
              <Input
                placeholder={'PostHistoryTypeId'}
                id={'postHistoryTypeId'}
              />
            )}
          </Form.Item>

          <Form.Item>
            <label htmlFor="postId">PostId</label>
            <br />
            {getFieldDecorator('postId', {
              rules: [],
            })(<Input placeholder={'PostId'} id={'postId'} />)}
          </Form.Item>

          <Form.Item>
            <label htmlFor="revisionGUID">RevisionGUID</label>
            <br />
            {getFieldDecorator('revisionGUID', {
              rules: [],
            })(<Input placeholder={'RevisionGUID'} id={'revisionGUID'} />)}
          </Form.Item>

          <Form.Item>
            <label htmlFor="text">Text</label>
            <br />
            {getFieldDecorator('text', {
              rules: [],
            })(<Input placeholder={'Text'} id={'text'} />)}
          </Form.Item>

          <Form.Item>
            <label htmlFor="userDisplayName">UserDisplayName</label>
            <br />
            {getFieldDecorator('userDisplayName', {
              rules: [],
            })(
              <Input placeholder={'UserDisplayName'} id={'userDisplayName'} />
            )}
          </Form.Item>

          <Form.Item>
            <label htmlFor="userId">UserId</label>
            <br />
            {getFieldDecorator('userId', {
              rules: [],
            })(<Input placeholder={'UserId'} id={'userId'} />)}
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

export const WrappedPostHistoryCreateComponent = Form.create({
  name: 'PostHistory Create',
})(PostHistoryCreateComponent);


/*<Codenesium>
    <Hash>15ce1f436270aafd56c0c5b7c4576f31</Hash>
</Codenesium>*/