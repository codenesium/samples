import React, { Component, FormEvent } from 'react';
import axios from 'axios';
import { CreateResponse } from '../../api/apiObjects';
import { Constants, ApiRoutes, ClientRoutes } from '../../constants';
import * as Api from '../../api/models';
import CommentMapper from './commentMapper';
import CommentViewModel from './commentViewModel';
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

interface CommentCreateComponentProps {
  form: WrappedFormUtils;
  history: any;
  match: any;
}

interface CommentCreateComponentState {
  model?: CommentViewModel;
  loading: boolean;
  loaded: boolean;
  errorOccurred: boolean;
  errorMessage: string;
  submitted: boolean;
}

class CommentCreateComponent extends React.Component<
  CommentCreateComponentProps,
  CommentCreateComponentState
> {
  state = {
    model: new CommentViewModel(),
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
        let model = values as CommentViewModel;
        console.log('Received values of form: ', model);
        this.submit(model);
      }
    });
  };

  submit = (model: CommentViewModel) => {
    let mapper = new CommentMapper();
    axios
      .post(
        Constants.ApiEndpoint + ApiRoutes.Comments,
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
            Api.CommentClientRequestModel
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
              rules: [],
            })(<Input placeholder={'CreationDate'} id={'creationDate'} />)}
          </Form.Item>

          <Form.Item>
            <label htmlFor="postId">PostId</label>
            <br />
            {getFieldDecorator('postId', {
              rules: [],
            })(<Input placeholder={'PostId'} id={'postId'} />)}
          </Form.Item>

          <Form.Item>
            <label htmlFor="score">Score</label>
            <br />
            {getFieldDecorator('score', {
              rules: [],
            })(<Input placeholder={'Score'} id={'score'} />)}
          </Form.Item>

          <Form.Item>
            <label htmlFor="text">Text</label>
            <br />
            {getFieldDecorator('text', {
              rules: [],
            })(<Input placeholder={'Text'} id={'text'} />)}
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

export const WrappedCommentCreateComponent = Form.create({
  name: 'Comment Create',
})(CommentCreateComponent);


/*<Codenesium>
    <Hash>1ba7d2f83b5296aeaded96859d7f5b6d</Hash>
</Codenesium>*/