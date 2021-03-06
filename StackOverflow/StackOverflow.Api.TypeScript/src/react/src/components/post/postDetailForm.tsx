import React, { Component, FormEvent } from 'react';
import axios, { AxiosError, AxiosResponse } from 'axios';
import { Constants, ApiRoutes, ClientRoutes } from '../../constants';
import * as Api from '../../api/models';
import PostMapper from './postMapper';
import PostViewModel from './postViewModel';
import { Form, Input, Button, Spin, Alert } from 'antd';
import { WrappedFormUtils } from 'antd/es/form/Form';
import * as GlobalUtilities from '../../lib/globalUtilities';
import { CommentTableComponent } from '../shared/commentTable';
import { TagTableComponent } from '../shared/tagTable';
import { VoteTableComponent } from '../shared/voteTable';
import { PostHistoryTableComponent } from '../shared/postHistoryTable';
import { PostLinkTableComponent } from '../shared/postLinkTable';

interface PostDetailComponentProps {
  form: WrappedFormUtils;
  history: any;
  match: any;
}

interface PostDetailComponentState {
  model?: PostViewModel;
  loading: boolean;
  loaded: boolean;
  errorOccurred: boolean;
  errorMessage: string;
}

class PostDetailComponent extends React.Component<
  PostDetailComponentProps,
  PostDetailComponentState
> {
  state = {
    model: new PostViewModel(),
    loading: false,
    loaded: true,
    errorOccurred: false,
    errorMessage: '',
  };

  handleEditClick(e: any) {
    this.props.history.push(
      ClientRoutes.Posts + '/edit/' + this.state.model!.id
    );
  }

  componentDidMount() {
    this.setState({ ...this.state, loading: true });

    axios
      .get<Api.PostClientResponseModel>(
        Constants.ApiEndpoint +
          ApiRoutes.Posts +
          '/' +
          this.props.match.params.id,
        {
          headers: GlobalUtilities.defaultHeaders(),
        }
      )
      .then(response => {
        GlobalUtilities.logInfo(response);

        let mapper = new PostMapper();

        this.setState({
          model: mapper.mapApiResponseToViewModel(response.data),
          loading: false,
          loaded: true,
          errorOccurred: false,
          errorMessage: '',
        });
      })
      .catch((error: AxiosError) => {
        GlobalUtilities.logError(error);

        if (error.response && error.response.status == 422) {
          this.setState({
            ...this.state,
            errorOccurred: false,
            errorMessage: '',
          });
        } else {
          this.setState({
            ...this.state,
            errorOccurred: true,
            errorMessage: 'Error Occurred',
          });
        }
      });
  }

  render() {
    let message: JSX.Element = <div />;
    if (this.state.errorOccurred) {
      message = <Alert message={this.state.errorMessage} type="error" />;
    }

    if (this.state.loading) {
      return <Spin size="large" />;
    } else if (this.state.loaded) {
      return (
        <div>
          <Button
            style={{ float: 'right' }}
            type="primary"
            onClick={(e: any) => {
              this.handleEditClick(e);
            }}
          >
            <i className="fas fa-edit" />
          </Button>
          <div>
            <div>
              <h3>Accepted Answer</h3>
              <p>{String(this.state.model!.acceptedAnswerId)}</p>
            </div>
            <div>
              <h3>Answer Count</h3>
              <p>{String(this.state.model!.answerCount)}</p>
            </div>
            <div>
              <h3>Body</h3>
              <p>{String(this.state.model!.body)}</p>
            </div>
            <div>
              <h3>Closed Date</h3>
              <p>{String(this.state.model!.closedDate)}</p>
            </div>
            <div>
              <h3>Comment Count</h3>
              <p>{String(this.state.model!.commentCount)}</p>
            </div>
            <div>
              <h3>Community Owned Date</h3>
              <p>{String(this.state.model!.communityOwnedDate)}</p>
            </div>
            <div>
              <h3>Creation Date</h3>
              <p>{String(this.state.model!.creationDate)}</p>
            </div>
            <div>
              <h3>Favorite Count</h3>
              <p>{String(this.state.model!.favoriteCount)}</p>
            </div>
            <div>
              <h3>Last Activity Date</h3>
              <p>{String(this.state.model!.lastActivityDate)}</p>
            </div>
            <div>
              <h3>Last Edit Date</h3>
              <p>{String(this.state.model!.lastEditDate)}</p>
            </div>
            <div>
              <h3>Last Editor Display Name</h3>
              <p>{String(this.state.model!.lastEditorDisplayName)}</p>
            </div>
            <div style={{ marginBottom: '10px' }}>
              <h3>Last Editor User</h3>
              <p>
                {String(
                  this.state.model!.lastEditorUserIdNavigation &&
                    this.state.model!.lastEditorUserIdNavigation!.toDisplay()
                )}
              </p>
            </div>
            <div style={{ marginBottom: '10px' }}>
              <h3>Owner User</h3>
              <p>
                {String(
                  this.state.model!.ownerUserIdNavigation &&
                    this.state.model!.ownerUserIdNavigation!.toDisplay()
                )}
              </p>
            </div>
            <div style={{ marginBottom: '10px' }}>
              <h3>Parent</h3>
              <p>
                {String(
                  this.state.model!.parentIdNavigation &&
                    this.state.model!.parentIdNavigation!.toDisplay()
                )}
              </p>
            </div>
            <div style={{ marginBottom: '10px' }}>
              <h3>Post Type</h3>
              <p>
                {String(
                  this.state.model!.postTypeIdNavigation &&
                    this.state.model!.postTypeIdNavigation!.toDisplay()
                )}
              </p>
            </div>
            <div>
              <h3>Score</h3>
              <p>{String(this.state.model!.score)}</p>
            </div>
            <div>
              <h3>Tag</h3>
              <p>{String(this.state.model!.tag)}</p>
            </div>
            <div>
              <h3>Title</h3>
              <p>{String(this.state.model!.title)}</p>
            </div>
            <div>
              <h3>View Count</h3>
              <p>{String(this.state.model!.viewCount)}</p>
            </div>
          </div>
          {message}
          <div>
            <h3>Comments</h3>
            <CommentTableComponent
              history={this.props.history}
              match={this.props.match}
              apiRoute={
                Constants.ApiEndpoint +
                ApiRoutes.Posts +
                '/' +
                this.state.model!.id +
                '/' +
                ApiRoutes.Comments
              }
            />
          </div>
          <div>
            <h3>Tags</h3>
            <TagTableComponent
              history={this.props.history}
              match={this.props.match}
              apiRoute={
                Constants.ApiEndpoint +
                ApiRoutes.Posts +
                '/' +
                this.state.model!.id +
                '/' +
                ApiRoutes.Tags
              }
            />
          </div>
          <div>
            <h3>Votes</h3>
            <VoteTableComponent
              history={this.props.history}
              match={this.props.match}
              apiRoute={
                Constants.ApiEndpoint +
                ApiRoutes.Posts +
                '/' +
                this.state.model!.id +
                '/' +
                ApiRoutes.Votes
              }
            />
          </div>
          <div>
            <h3>PostHistories</h3>
            <PostHistoryTableComponent
              history={this.props.history}
              match={this.props.match}
              apiRoute={
                Constants.ApiEndpoint +
                ApiRoutes.Posts +
                '/' +
                this.state.model!.id +
                '/' +
                ApiRoutes.PostHistories
              }
            />
          </div>
          <div>
            <h3>PostLinks</h3>
            <PostLinkTableComponent
              history={this.props.history}
              match={this.props.match}
              apiRoute={
                Constants.ApiEndpoint +
                ApiRoutes.Posts +
                '/' +
                this.state.model!.id +
                '/' +
                ApiRoutes.PostLinks
              }
            />
          </div>
        </div>
      );
    } else {
      return null;
    }
  }
}

export const WrappedPostDetailComponent = Form.create({ name: 'Post Detail' })(
  PostDetailComponent
);


/*<Codenesium>
    <Hash>7b59960f2834377c53aee9351128f74a</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/