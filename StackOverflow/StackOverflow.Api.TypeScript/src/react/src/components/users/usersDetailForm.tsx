import React, { Component, FormEvent } from 'react';
import axios, { AxiosError, AxiosResponse } from 'axios';
import { Constants, ApiRoutes, ClientRoutes } from '../../constants';
import * as Api from '../../api/models';
import UsersMapper from './usersMapper';
import UsersViewModel from './usersViewModel';
import { Form, Input, Button, Spin, Alert } from 'antd';
import { WrappedFormUtils } from 'antd/es/form/Form';
import * as GlobalUtilities from '../../lib/globalUtilities';
import { BadgesTableComponent } from '../shared/badgesTable';
import { CommentsTableComponent } from '../shared/commentsTable';
import { PostsTableComponent } from '../shared/postsTable';
import { VotesTableComponent } from '../shared/votesTable';
import { PostHistoryTableComponent } from '../shared/postHistoryTable';

interface UsersDetailComponentProps {
  form: WrappedFormUtils;
  history: any;
  match: any;
}

interface UsersDetailComponentState {
  model?: UsersViewModel;
  loading: boolean;
  loaded: boolean;
  errorOccurred: boolean;
  errorMessage: string;
}

class UsersDetailComponent extends React.Component<
  UsersDetailComponentProps,
  UsersDetailComponentState
> {
  state = {
    model: new UsersViewModel(),
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
      .get<Api.UsersClientResponseModel>(
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

        let mapper = new UsersMapper();

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
            <BadgesTableComponent
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
            <CommentsTableComponent
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
            <PostsTableComponent
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
            <VotesTableComponent
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
            <h3>PostHistory</h3>
            <PostHistoryTableComponent
              history={this.props.history}
              match={this.props.match}
              apiRoute={
                Constants.ApiEndpoint +
                ApiRoutes.Users +
                '/' +
                this.state.model!.id +
                '/' +
                ApiRoutes.PostHistory
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

export const WrappedUsersDetailComponent = Form.create({
  name: 'Users Detail',
})(UsersDetailComponent);


/*<Codenesium>
    <Hash>48516dfec94404e998014f4285271759</Hash>
</Codenesium>*/