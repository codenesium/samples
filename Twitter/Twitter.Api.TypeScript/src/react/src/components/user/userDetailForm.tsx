import React, { Component, FormEvent } from 'react';
import axios, { AxiosError, AxiosResponse } from 'axios';
import { Constants, ApiRoutes, ClientRoutes } from '../../constants';
import * as Api from '../../api/models';
import UserMapper from './userMapper';
import UserViewModel from './userViewModel';
import { Form, Input, Button, Spin, Alert } from 'antd';
import { WrappedFormUtils } from 'antd/es/form/Form';
import * as GlobalUtilities from '../../lib/globalUtilities';
import { DirectTweetTableComponent } from '../shared/directTweetTable';
import { FollowerTableComponent } from '../shared/followerTable';
import { MessageTableComponent } from '../shared/messageTable';
import { MessengerTableComponent } from '../shared/messengerTable';
import { QuoteTweetTableComponent } from '../shared/quoteTweetTable';
import { ReplyTableComponent } from '../shared/replyTable';
import { RetweetTableComponent } from '../shared/retweetTable';
import { TweetTableComponent } from '../shared/tweetTable';

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
      ClientRoutes.Users + '/edit/' + this.state.model!.userId
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
              <h3>bio_img_url</h3>
              <p>{String(this.state.model!.bioImgUrl)}</p>
            </div>
            <div>
              <h3>birthday</h3>
              <p>{String(this.state.model!.birthday)}</p>
            </div>
            <div>
              <h3>content_description</h3>
              <p>{String(this.state.model!.contentDescription)}</p>
            </div>
            <div>
              <h3>email</h3>
              <p>{String(this.state.model!.email)}</p>
            </div>
            <div>
              <h3>full_name</h3>
              <p>{String(this.state.model!.fullName)}</p>
            </div>
            <div>
              <h3>header_img_url</h3>
              <p>{String(this.state.model!.headerImgUrl)}</p>
            </div>
            <div>
              <h3>interest</h3>
              <p>{String(this.state.model!.interest)}</p>
            </div>
            <div style={{ marginBottom: '10px' }}>
              <h3>location_location_id</h3>
              <p>
                {String(
                  this.state.model!.locationLocationIdNavigation &&
                    this.state.model!.locationLocationIdNavigation!.toDisplay()
                )}
              </p>
            </div>
            <div>
              <h3>password</h3>
              <p>{String(this.state.model!.password)}</p>
            </div>
            <div>
              <h3>phone_number</h3>
              <p>{String(this.state.model!.phoneNumber)}</p>
            </div>
            <div>
              <h3>privacy</h3>
              <p>{String(this.state.model!.privacy)}</p>
            </div>
            <div>
              <h3>username</h3>
              <p>{String(this.state.model!.username)}</p>
            </div>
            <div>
              <h3>website</h3>
              <p>{String(this.state.model!.website)}</p>
            </div>
          </div>
          {message}
          <div>
            <h3>DirectTweets</h3>
            <DirectTweetTableComponent
              history={this.props.history}
              match={this.props.match}
              apiRoute={
                Constants.ApiEndpoint +
                ApiRoutes.Users +
                '/' +
                this.state.model!.userId +
                '/' +
                ApiRoutes.DirectTweets
              }
            />
          </div>
          <div>
            <h3>Followers</h3>
            <FollowerTableComponent
              history={this.props.history}
              match={this.props.match}
              apiRoute={
                Constants.ApiEndpoint +
                ApiRoutes.Users +
                '/' +
                this.state.model!.userId +
                '/' +
                ApiRoutes.Followers
              }
            />
          </div>
          <div>
            <h3>Messages</h3>
            <MessageTableComponent
              history={this.props.history}
              match={this.props.match}
              apiRoute={
                Constants.ApiEndpoint +
                ApiRoutes.Users +
                '/' +
                this.state.model!.userId +
                '/' +
                ApiRoutes.Messages
              }
            />
          </div>
          <div>
            <h3>Messengers</h3>
            <MessengerTableComponent
              history={this.props.history}
              match={this.props.match}
              apiRoute={
                Constants.ApiEndpoint +
                ApiRoutes.Users +
                '/' +
                this.state.model!.userId +
                '/' +
                ApiRoutes.Messengers
              }
            />
          </div>
          <div>
            <h3>QuoteTweets</h3>
            <QuoteTweetTableComponent
              history={this.props.history}
              match={this.props.match}
              apiRoute={
                Constants.ApiEndpoint +
                ApiRoutes.Users +
                '/' +
                this.state.model!.userId +
                '/' +
                ApiRoutes.QuoteTweets
              }
            />
          </div>
          <div>
            <h3>Replies</h3>
            <ReplyTableComponent
              history={this.props.history}
              match={this.props.match}
              apiRoute={
                Constants.ApiEndpoint +
                ApiRoutes.Users +
                '/' +
                this.state.model!.userId +
                '/' +
                ApiRoutes.Replies
              }
            />
          </div>
          <div>
            <h3>Retweets</h3>
            <RetweetTableComponent
              history={this.props.history}
              match={this.props.match}
              apiRoute={
                Constants.ApiEndpoint +
                ApiRoutes.Users +
                '/' +
                this.state.model!.userId +
                '/' +
                ApiRoutes.Retweets
              }
            />
          </div>
          <div>
            <h3>Tweets</h3>
            <TweetTableComponent
              history={this.props.history}
              match={this.props.match}
              apiRoute={
                Constants.ApiEndpoint +
                ApiRoutes.Users +
                '/' +
                this.state.model!.userId +
                '/' +
                ApiRoutes.Tweets
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
    <Hash>dcb815581cc1d18a9751cf334ad52796</Hash>
</Codenesium>*/