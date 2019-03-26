import React, { Component, FormEvent } from 'react';
import axios, { AxiosError, AxiosResponse } from 'axios';
import { ActionResponse, CreateResponse } from '../../api/apiObjects';
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
  TimePicker,
} from 'antd';
import { WrappedFormUtils } from 'antd/es/form/Form';
import * as GlobalUtilities from '../../lib/globalUtilities';
import { PostHistoryTypeSelectComponent } from '../shared/postHistoryTypeSelect';
import { PostSelectComponent } from '../shared/postSelect';
import { UserSelectComponent } from '../shared/userSelect';

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
  submitting: boolean;
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
    submitting: false,
  };

  handleSubmit = (e: FormEvent<HTMLFormElement>) => {
    e.preventDefault();
    this.setState({ ...this.state, submitting: true, submitted: false });
    this.props.form.validateFields((err: any, values: any) => {
      if (!err) {
        let model = values as PostHistoryViewModel;
        this.submit(model);
      } else {
        this.setState({ ...this.state, submitting: false, submitted: false });
      }
    });
  };

  submit = (model: PostHistoryViewModel) => {
    let mapper = new PostHistoryMapper();
    axios
      .post<CreateResponse<Api.PostHistoryClientRequestModel>>(
        Constants.ApiEndpoint + ApiRoutes.PostHistories,
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
            <label htmlFor="comment">Comment</label>
            <br />
            {getFieldDecorator('comment', {
              rules: [
                {
                  max: 1073741823,
                  message: 'Exceeds max length of 1073741823',
                },
              ],
            })(<Input placeholder={'Comment'} />)}
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

          <PostHistoryTypeSelectComponent
            apiRoute={Constants.ApiEndpoint + ApiRoutes.PostHistoryTypes}
            getFieldDecorator={this.props.form.getFieldDecorator}
            propertyName="postHistoryTypeId"
            required={true}
            selectedValue={this.state.model!.postHistoryTypeId}
          />

          <PostSelectComponent
            apiRoute={Constants.ApiEndpoint + ApiRoutes.Posts}
            getFieldDecorator={this.props.form.getFieldDecorator}
            propertyName="postId"
            required={true}
            selectedValue={this.state.model!.postId}
          />

          <Form.Item>
            <label htmlFor="revisionGUID">Revision GUID</label>
            <br />
            {getFieldDecorator('revisionGUID', {
              rules: [
                { required: true, message: 'Required' },
                { max: 36, message: 'Exceeds max length of 36' },
              ],
            })(<Input placeholder={'Revision GUID'} />)}
          </Form.Item>

          <Form.Item>
            <label htmlFor="text">Text</label>
            <br />
            {getFieldDecorator('text', {
              rules: [
                {
                  max: 1073741823,
                  message: 'Exceeds max length of 1073741823',
                },
              ],
            })(<Input placeholder={'Text'} />)}
          </Form.Item>

          <Form.Item>
            <label htmlFor="userDisplayName">User Display Name</label>
            <br />
            {getFieldDecorator('userDisplayName', {
              rules: [{ max: 40, message: 'Exceeds max length of 40' }],
            })(<Input placeholder={'User Display Name'} />)}
          </Form.Item>

          <UserSelectComponent
            apiRoute={Constants.ApiEndpoint + ApiRoutes.Users}
            getFieldDecorator={this.props.form.getFieldDecorator}
            propertyName="userId"
            required={false}
            selectedValue={this.state.model!.userId}
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

export const WrappedPostHistoryCreateComponent = Form.create({
  name: 'PostHistory Create',
})(PostHistoryCreateComponent);


/*<Codenesium>
    <Hash>0d0c6c23dd231272ae79b14c8fe0e16f</Hash>
</Codenesium>*/