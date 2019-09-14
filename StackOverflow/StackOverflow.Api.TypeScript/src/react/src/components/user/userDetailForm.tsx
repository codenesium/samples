import React, { Component, FormEvent } from 'react';
import axios, { AxiosError, AxiosResponse } from 'axios';
import { Constants, ApiRoutes, ClientRoutes } from '../../constants';
import * as Api from '../../api/models';
import UserMapper from './userMapper';
import UserViewModel from './userViewModel';
import { Form, Input, Button, Spin, Alert } from 'antd';
import { WrappedFormUtils } from 'antd/es/form/Form';
import * as GlobalUtilities from '../../lib/globalUtilities';
import { BadgeTableComponent } from '../shared/badgeTable';
import { CommentTableComponent } from '../shared/commentTable';
import { PostTableComponent } from '../shared/postTable';
import { VoteTableComponent } from '../shared/voteTable';
import { PostHistoryTableComponent } from '../shared/postHistoryTable';

interface UserDetailComponentProps {
  form: WrappedFormUtils;
  history: any;
  match: any;
}

interface UserDetailComponentState {
  model?: UserViewModel;
  loading: boolean;
  loaded: boolean;
  errorOccurred: boolean;
  errorMessage: string;
}

class UserDetailComponent extends React.Component<
  UserDetailComponentProps,
  UserDetailComponentState
> {
  state = {
    model: new UserViewModel(),
    loading: false,
    loaded: true,
    errorOccurred: false,
    errorMessage: '',
  };

  handleEditClick(e: any) {
    this.props.history.push(
      ClientRoutes.Users + '/edit/' + this.state.model!.id
    );
  }

  componentDidMount() {
    this.setState({ ...this.state, loading: true });

    axios
      .get<Api.UserClientResponseModel>(
        Constants.ApiEndpoint +
          ApiRoutes.Users +
          '/' +
          this.props.match.params.id,
        {
          headers: GlobalUtilities.defaultHeaders(),
        }
      )
      .then(response => {
        GlobalUtilities.logInfo(response);

        let mapper = new UserMapper();

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
              <h3>About Me</h3>
              <p>{String(this.state.model!.aboutMe)}</p>
            </div>
            <div>
              <h3>Account</h3>
              <p>{String(this.state.model!.accountId)}</p>
            </div>
            <div>
              <h3>Age</h3>
              <p>{String(this.state.model!.age)}</p>
            </div>
            <div>
              <h3>Creation Date</h3>
              <p>{String(this.state.model!.creationDate)}</p>
            </div>
            <div>
              <h3>Display Name</h3>
              <p>{String(this.state.model!.displayName)}</p>
            </div>
            <div>
              <h3>Down Vote</h3>
              <p>{String(this.state.model!.downVote)}</p>
            </div>
            <div>
              <h3>Email Hash</h3>
              <p>{String(this.state.model!.emailHash)}</p>
            </div>
            <div>
              <h3>Last Access Date</h3>
              <p>{String(this.state.model!.lastAccessDate)}</p>
            </div>
            <div>
              <h3>Location</h3>
              <p>{String(this.state.model!.location)}</p>
            </div>
            <div>
              <h3>Reputation</h3>
              <p>{String(this.state.model!.reputation)}</p>
            </div>
            <div>
              <h3>Up Vote</h3>
              <p>{String(this.state.model!.upVote)}</p>
            </div>
            <div>
              <h3>View</h3>
              <p>{String(this.state.model!.view)}</p>
            </div>
            <div>
              <h3>Website Url</h3>
              <p>{String(this.state.model!.websiteUrl)}</p>
            </div>
          </div>
          {message}
          <div>
            <h3>Badges</h3>
            <BadgeTableComponent
              history={this.props.history}
              match={this.props.match}
              apiRoute={
                Constants.ApiEndpoint +
                ApiRoutes.Users +
                '/' +
                this.state.model!.id +
                '/' +
                ApiRoutes.Badges
              }
            />
          </div>
          <div>
            <h3>Comments</h3>
            <CommentTableComponent
              history={this.props.history}
              match={this.props.match}
              apiRoute={
                Constants.ApiEndpoint +
                ApiRoutes.Users +
                '/' +
                this.state.model!.id +
                '/' +
                ApiRoutes.Comments
              }
            />
          </div>
          <div>
            <h3>Posts</h3>
            <PostTableComponent
              history={this.props.history}
              match={this.props.match}
              apiRoute={
                Constants.ApiEndpoint +
                ApiRoutes.Users +
                '/' +
                this.state.model!.id +
                '/' +
                ApiRoutes.Posts
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
                ApiRoutes.Users +
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
                ApiRoutes.Users +
                '/' +
                this.state.model!.id +
                '/' +
                ApiRoutes.PostHistories
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

export const WrappedUserDetailComponent = Form.create({ name: 'User Detail' })(
  UserDetailComponent
);


/*<Codenesium>
    <Hash>d6eed0e8056e63739cd9bcbe3bab9c39</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/