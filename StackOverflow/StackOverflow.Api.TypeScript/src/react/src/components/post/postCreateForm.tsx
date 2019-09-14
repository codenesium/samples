import React, { Component, FormEvent } from 'react';
import axios, { AxiosError, AxiosResponse } from 'axios';
import { ActionResponse, CreateResponse } from '../../api/apiObjects';
import { Constants, ApiRoutes, ClientRoutes } from '../../constants';
import * as Api from '../../api/models';
import PostMapper from './postMapper';
import PostViewModel from './postViewModel';
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
import { UserSelectComponent } from '../shared/userSelect';
import { PostSelectComponent } from '../shared/postSelect';
import { PostTypeSelectComponent } from '../shared/postTypeSelect';

interface PostCreateComponentProps {
  form: WrappedFormUtils;
  history: any;
  match: any;
}

interface PostCreateComponentState {
  model?: PostViewModel;
  loading: boolean;
  loaded: boolean;
  errorOccurred: boolean;
  errorMessage: string;
  submitted: boolean;
  submitting: boolean;
}

class PostCreateComponent extends React.Component<
  PostCreateComponentProps,
  PostCreateComponentState
> {
  state = {
    model: new PostViewModel(),
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
        let model = values as PostViewModel;
        this.submit(model);
      } else {
        this.setState({ ...this.state, submitting: false, submitted: false });
      }
    });
  };

  submit = (model: PostViewModel) => {
    let mapper = new PostMapper();
    axios
      .post<CreateResponse<Api.PostClientRequestModel>>(
        Constants.ApiEndpoint + ApiRoutes.Posts,
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
            <label htmlFor="acceptedAnswerId">Accepted Answer (optional)</label>
            <br />
            {getFieldDecorator('acceptedAnswerId', {
              rules: [],
            })(<Input placeholder={'Accepted Answer'} />)}
          </Form.Item>

          <Form.Item>
            <label htmlFor="answerCount">Answer Count (optional)</label>
            <br />
            {getFieldDecorator('answerCount', {
              rules: [],
            })(<InputNumber placeholder={'Answer Count'} />)}
          </Form.Item>

          <Form.Item>
            <label htmlFor="body">Body (required)</label>
            <br />
            {getFieldDecorator('body', {
              rules: [{ required: true, message: 'Required' }],
            })(<Input placeholder={'Body'} />)}
          </Form.Item>

          <Form.Item>
            <label htmlFor="closedDate">Closed Date (optional)</label>
            <br />
            {getFieldDecorator('closedDate', {
              rules: [],
            })(
              <DatePicker format={'YYYY-MM-DD'} placeholder={'Closed Date'} />
            )}
          </Form.Item>

          <Form.Item>
            <label htmlFor="commentCount">Comment Count (optional)</label>
            <br />
            {getFieldDecorator('commentCount', {
              rules: [],
            })(<InputNumber placeholder={'Comment Count'} />)}
          </Form.Item>

          <Form.Item>
            <label htmlFor="communityOwnedDate">
              Community Owned Date (optional)
            </label>
            <br />
            {getFieldDecorator('communityOwnedDate', {
              rules: [],
            })(
              <DatePicker
                format={'YYYY-MM-DD'}
                placeholder={'Community Owned Date'}
              />
            )}
          </Form.Item>

          <Form.Item>
            <label htmlFor="creationDate">Creation Date (required)</label>
            <br />
            {getFieldDecorator('creationDate', {
              rules: [{ required: true, message: 'Required' }],
            })(
              <DatePicker format={'YYYY-MM-DD'} placeholder={'Creation Date'} />
            )}
          </Form.Item>

          <Form.Item>
            <label htmlFor="favoriteCount">Favorite Count (optional)</label>
            <br />
            {getFieldDecorator('favoriteCount', {
              rules: [],
            })(<InputNumber placeholder={'Favorite Count'} />)}
          </Form.Item>

          <Form.Item>
            <label htmlFor="lastActivityDate">
              Last Activity Date (required)
            </label>
            <br />
            {getFieldDecorator('lastActivityDate', {
              rules: [{ required: true, message: 'Required' }],
            })(
              <DatePicker
                format={'YYYY-MM-DD'}
                placeholder={'Last Activity Date'}
              />
            )}
          </Form.Item>

          <Form.Item>
            <label htmlFor="lastEditDate">Last Edit Date (optional)</label>
            <br />
            {getFieldDecorator('lastEditDate', {
              rules: [],
            })(
              <DatePicker
                format={'YYYY-MM-DD'}
                placeholder={'Last Edit Date'}
              />
            )}
          </Form.Item>

          <Form.Item>
            <label htmlFor="lastEditorDisplayName">
              Last Editor Display Name (optional)
            </label>
            <br />
            {getFieldDecorator('lastEditorDisplayName', {
              rules: [{ max: 40, message: 'Exceeds max length of 40' }],
            })(<Input placeholder={'Last Editor Display Name'} />)}
          </Form.Item>

          <UserSelectComponent
            apiRoute={Constants.ApiEndpoint + ApiRoutes.Users}
            getFieldDecorator={this.props.form.getFieldDecorator}
            propertyName="lastEditorUserId"
            required={false}
            selectedValue={this.state.model!.lastEditorUserId}
          />

          <UserSelectComponent
            apiRoute={Constants.ApiEndpoint + ApiRoutes.Users}
            getFieldDecorator={this.props.form.getFieldDecorator}
            propertyName="ownerUserId"
            required={false}
            selectedValue={this.state.model!.ownerUserId}
          />

          <PostSelectComponent
            apiRoute={Constants.ApiEndpoint + ApiRoutes.Posts}
            getFieldDecorator={this.props.form.getFieldDecorator}
            propertyName="parentId"
            required={false}
            selectedValue={this.state.model!.parentId}
          />

          <PostTypeSelectComponent
            apiRoute={Constants.ApiEndpoint + ApiRoutes.PostTypes}
            getFieldDecorator={this.props.form.getFieldDecorator}
            propertyName="postTypeId"
            required={true}
            selectedValue={this.state.model!.postTypeId}
          />

          <Form.Item>
            <label htmlFor="score">Score (required)</label>
            <br />
            {getFieldDecorator('score', {
              rules: [{ required: true, message: 'Required' }],
            })(<InputNumber placeholder={'Score'} />)}
          </Form.Item>

          <Form.Item>
            <label htmlFor="tag">Tag (optional)</label>
            <br />
            {getFieldDecorator('tag', {
              rules: [{ max: 150, message: 'Exceeds max length of 150' }],
            })(<Input placeholder={'Tag'} />)}
          </Form.Item>

          <Form.Item>
            <label htmlFor="title">Title (optional)</label>
            <br />
            {getFieldDecorator('title', {
              rules: [{ max: 250, message: 'Exceeds max length of 250' }],
            })(<Input placeholder={'Title'} />)}
          </Form.Item>

          <Form.Item>
            <label htmlFor="viewCount">View Count (required)</label>
            <br />
            {getFieldDecorator('viewCount', {
              rules: [{ required: true, message: 'Required' }],
            })(<InputNumber placeholder={'View Count'} />)}
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

export const WrappedPostCreateComponent = Form.create({ name: 'Post Create' })(
  PostCreateComponent
);


/*<Codenesium>
    <Hash>10de8004f5db57bfd5daf684f0b779a9</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/