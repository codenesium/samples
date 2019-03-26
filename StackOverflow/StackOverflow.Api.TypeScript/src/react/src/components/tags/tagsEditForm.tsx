import React, { Component, FormEvent } from 'react';
import axios, { AxiosError, AxiosResponse } from 'axios';
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
import * as GlobalUtilities from '../../lib/globalUtilities';
import { PostsSelectComponent } from '../shared/postsSelect';
interface TagsEditComponentProps {
  form: WrappedFormUtils;
  history: any;
  match: any;
}

interface TagsEditComponentState {
  model?: TagsViewModel;
  loading: boolean;
  loaded: boolean;
  errorOccurred: boolean;
  errorMessage: string;
  submitted: boolean;
  submitting: boolean;
}

class TagsEditComponent extends React.Component<
  TagsEditComponentProps,
  TagsEditComponentState
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

  componentDidMount() {
    this.setState({ ...this.state, loading: true });

    axios
      .get<Api.TagsClientResponseModel>(
        Constants.ApiEndpoint +
          ApiRoutes.Tags +
          '/' +
          this.props.match.params.id,
        {
          headers: GlobalUtilities.defaultHeaders(),
        }
      )
      .then(response => {
        GlobalUtilities.logInfo(response);

        let mapper = new TagsMapper();

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
        let model = values as TagsViewModel;
        this.submit(model);
      } else {
        this.setState({ ...this.state, submitting: false, submitted: false });
      }
    });
  };

  submit = (model: TagsViewModel) => {
    let mapper = new TagsMapper();
    axios
      .put<CreateResponse<Api.TagsClientRequestModel>>(
        Constants.ApiEndpoint + ApiRoutes.Tags + '/' + this.state.model!.id,
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
            <label htmlFor="count">Count</label>
            <br />
            {getFieldDecorator('count', {
              rules: [{ required: true, message: 'Required' }],
            })(<Input placeholder={'Count'} />)}
          </Form.Item>

          <PostsSelectComponent
            apiRoute={Constants.ApiEndpoint + ApiRoutes.Posts}
            getFieldDecorator={this.props.form.getFieldDecorator}
            propertyName="excerptPostId"
            required={true}
            selectedValue={this.state.model!.excerptPostId}
          />

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

          <PostsSelectComponent
            apiRoute={Constants.ApiEndpoint + ApiRoutes.Posts}
            getFieldDecorator={this.props.form.getFieldDecorator}
            propertyName="wikiPostId"
            required={true}
            selectedValue={this.state.model!.wikiPostId}
          />

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

export const WrappedTagsEditComponent = Form.create({ name: 'Tags Edit' })(
  TagsEditComponent
);


/*<Codenesium>
    <Hash>da6b4d5f17ab97fad4513aaba43ecf6b</Hash>
</Codenesium>*/