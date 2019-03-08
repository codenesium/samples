import React, { Component, FormEvent } from 'react';
import axios from 'axios';
import { ActionResponse, CreateResponse } from '../../api/apiObjects';
import { Constants, ApiRoutes, ClientRoutes } from '../../constants';
import * as Api from '../../api/models';
import TagsMapper from './tagsMapper';
import TagsViewModel from './tagsViewModel';
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
import { ToLowerCaseFirstLetter } from '../../lib/stringUtilities';
import { PostsSelectComponent } from '../shared/postsSelect';

interface TagsCreateComponentProps {
  form: WrappedFormUtils;
  history: any;
  match: any;
}

interface TagsCreateComponentState {
  model?: TagsViewModel;
  loading: boolean;
  loaded: boolean;
  errorOccurred: boolean;
  errorMessage: string;
  submitted: boolean;
  submitting: boolean;
}

class TagsCreateComponent extends React.Component<
  TagsCreateComponentProps,
  TagsCreateComponentState
> {
  state = {
    model: new TagsViewModel(),
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
        let model = values as TagsViewModel;
        console.log('Received values of form: ', model);
        this.submit(model);
      } else {
        this.setState({ ...this.state, submitting: false, submitted: false });
      }
    });
  };

  submit = (model: TagsViewModel) => {
    let mapper = new TagsMapper();
    axios
      .post(
        Constants.ApiEndpoint + ApiRoutes.Tags,
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
            Api.TagsClientRequestModel
          >;
          this.setState({
            ...this.state,
            submitted: true,
            submitting: false,
            model: mapper.mapApiResponseToViewModel(response.record!),
            errorOccurred: false,
            errorMessage: '',
          });
          console.log(response);
        },
        error => {
          console.log(error);
          if (error.response.data) {
            let errorResponse = error.response.data as ActionResponse;

            errorResponse.validationErrors.forEach(x => {
              this.props.form.setFields({
                [ToLowerCaseFirstLetter(x.propertyName)]: {
                  value: this.props.form.getFieldValue(
                    ToLowerCaseFirstLetter(x.propertyName)
                  ),
                  errors: [new Error(x.errorMessage)],
                },
              });
            });
          }
          this.setState({
            ...this.state,
            submitted: true,
            submitting: false,
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
            <label htmlFor="count">Count</label>
            <br />
            {getFieldDecorator('count', {
              rules: [{ required: true, message: 'Required' }],
            })(<Input placeholder={'Count'} />)}
          </Form.Item>

          <Form.Item>
            <label htmlFor="excerptPostId">Excerpt Post</label>
            <br />
            <PostsSelectComponent
              apiRoute={Constants.ApiEndpoint + ApiRoutes.Posts}
              getFieldDecorator={this.props.form.getFieldDecorator}
              propertyName="excerptPostId"
              required={true}
              selectedValue={this.state.model!.excerptPostId}
            />
          </Form.Item>

          <Form.Item>
            <label htmlFor="tagName">Tag Name</label>
            <br />
            {getFieldDecorator('tagName', {
              rules: [
                { required: true, message: 'Required' },
                { max: 150, message: 'Exceeds max length of 150' },
              ],
            })(<Input placeholder={'Tag Name'} />)}
          </Form.Item>

          <Form.Item>
            <label htmlFor="wikiPostId">Wiki Post</label>
            <br />
            <PostsSelectComponent
              apiRoute={Constants.ApiEndpoint + ApiRoutes.Posts}
              getFieldDecorator={this.props.form.getFieldDecorator}
              propertyName="wikiPostId"
              required={true}
              selectedValue={this.state.model!.wikiPostId}
            />
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

export const WrappedTagsCreateComponent = Form.create({ name: 'Tags Create' })(
  TagsCreateComponent
);


/*<Codenesium>
    <Hash>02eac82317db77c4bf11e651b9ab6e4b</Hash>
</Codenesium>*/