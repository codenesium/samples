import React, { Component, FormEvent } from 'react';
import axios from 'axios';
import { CreateResponse } from '../../api/apiObjects';
import { Constants, ApiRoutes, ClientRoutes } from '../../constants';
import * as Api from '../../api/models';
import PostLinkMapper from './postLinkMapper';
import PostLinkViewModel from './postLinkViewModel';
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

interface PostLinkCreateComponentProps {
  form: WrappedFormUtils;
  history: any;
  match: any;
}

interface PostLinkCreateComponentState {
  model?: PostLinkViewModel;
  loading: boolean;
  loaded: boolean;
  errorOccurred: boolean;
  errorMessage: string;
  submitted: boolean;
}

class PostLinkCreateComponent extends React.Component<
  PostLinkCreateComponentProps,
  PostLinkCreateComponentState
> {
  state = {
    model: new PostLinkViewModel(),
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
        let model = values as PostLinkViewModel;
        console.log('Received values of form: ', model);
        this.submit(model);
      }
    });
  };

  submit = (model: PostLinkViewModel) => {
    let mapper = new PostLinkMapper();
    axios
      .post(
        Constants.ApiEndpoint + ApiRoutes.PostLinks,
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
            Api.PostLinkClientRequestModel
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
            <label htmlFor="creationDate">CreationDate</label>
            <br />
            {getFieldDecorator('creationDate', {
              rules: [
                { required: true, message: 'Required' },
                { whitespace: true, message: 'Required' },
              ],
            })(<Input placeholder={'CreationDate'} />)}
          </Form.Item>

          <Form.Item>
            <label htmlFor="linkTypeId">LinkTypeId</label>
            <br />
            {getFieldDecorator('linkTypeId', {
              rules: [
                { required: true, message: 'Required' },
                { whitespace: true, message: 'Required' },
              ],
            })(<Input placeholder={'LinkTypeId'} />)}
          </Form.Item>

          <Form.Item>
            <label htmlFor="postId">PostId</label>
            <br />
            {getFieldDecorator('postId', {
              rules: [
                { required: true, message: 'Required' },
                { whitespace: true, message: 'Required' },
              ],
            })(<Input placeholder={'PostId'} />)}
          </Form.Item>

          <Form.Item>
            <label htmlFor="relatedPostId">RelatedPostId</label>
            <br />
            {getFieldDecorator('relatedPostId', {
              rules: [
                { required: true, message: 'Required' },
                { whitespace: true, message: 'Required' },
              ],
            })(<Input placeholder={'RelatedPostId'} />)}
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

export const WrappedPostLinkCreateComponent = Form.create({
  name: 'PostLink Create',
})(PostLinkCreateComponent);


/*<Codenesium>
    <Hash>8f392a9fa402d79c4fdf217aa3b6e333</Hash>
</Codenesium>*/