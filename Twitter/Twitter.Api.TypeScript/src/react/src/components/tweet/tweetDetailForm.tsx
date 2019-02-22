import React, { Component, FormEvent } from 'react';
import axios from 'axios';
import { Constants, ApiRoutes, ClientRoutes } from '../../constants';
import * as Api from '../../api/models';
import TweetMapper from './tweetMapper';
import TweetViewModel from './tweetViewModel';
import { Form, Input, Button, Spin, Alert } from 'antd';
import { WrappedFormUtils } from 'antd/es/form/Form';
import { LikeTableComponent } from '../shared/likeTable';
import { QuoteTweetTableComponent } from '../shared/quoteTweetTable';
import { RetweetTableComponent } from '../shared/retweetTable';

interface TweetDetailComponentProps {
  form: WrappedFormUtils;
  history: any;
  match: any;
}

interface TweetDetailComponentState {
  model?: TweetViewModel;
  loading: boolean;
  loaded: boolean;
  errorOccurred: boolean;
  errorMessage: string;
}

class TweetDetailComponent extends React.Component<
  TweetDetailComponentProps,
  TweetDetailComponentState
> {
  state = {
    model: new TweetViewModel(),
    loading: false,
    loaded: true,
    errorOccurred: false,
    errorMessage: '',
  };

  handleEditClick(e: any) {
    this.props.history.push(
      ClientRoutes.Tweets + '/edit/' + this.state.model!.tweetId
    );
  }

  componentDidMount() {
    this.setState({ ...this.state, loading: true });

    axios
      .get(
        Constants.ApiEndpoint +
          ApiRoutes.Tweets +
          '/' +
          this.props.match.params.id,
        {
          headers: {
            'Content-Type': 'application/json',
          },
        }
      )
      .then(
        resp => {
          let response = resp.data as Api.TweetClientResponseModel;

          console.log(response);

          let mapper = new TweetMapper();

          this.setState({
            model: mapper.mapApiResponseToViewModel(response),
            loading: false,
            loaded: true,
            errorOccurred: false,
            errorMessage: '',
          });
        },
        error => {
          console.log(error);
          this.setState({
            model: undefined,
            loading: false,
            loaded: true,
            errorOccurred: true,
            errorMessage: 'Error from API',
          });
        }
      );
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
              <h3>content</h3>
              <p>{String(this.state.model!.content)}</p>
            </div>
            <div>
              <h3>date</h3>
              <p>{String(this.state.model!.date)}</p>
            </div>
            <div style={{ marginBottom: '10px' }}>
              <h3>location_id</h3>
              <p>
                {String(this.state.model!.locationIdNavigation!.toDisplay())}
              </p>
            </div>
            <div>
              <h3>time</h3>
              <p>{String(this.state.model!.time)}</p>
            </div>
            <div style={{ marginBottom: '10px' }}>
              <h3>user_user_id</h3>
              <p>
                {String(this.state.model!.userUserIdNavigation!.toDisplay())}
              </p>
            </div>
          </div>
          {message}
          <div>
            <h3>Likes</h3>
            <LikeTableComponent
              likerUserId={this.state.model!.likerUserId}
              history={this.props.history}
              match={this.props.match}
              apiRoute={
                Constants.ApiEndpoint +
                ApiRoutes.Tweets +
                '/' +
                this.state.model!.tweetId +
                '/' +
                ApiRoutes.Likes
              }
            />
          </div>
          <div>
            <h3>QuoteTweets</h3>
            <QuoteTweetTableComponent
              quoteTweetId={this.state.model!.quoteTweetId}
              history={this.props.history}
              match={this.props.match}
              apiRoute={
                Constants.ApiEndpoint +
                ApiRoutes.Tweets +
                '/' +
                this.state.model!.tweetId +
                '/' +
                ApiRoutes.QuoteTweets
              }
            />
          </div>
          <div>
            <h3>Retweets</h3>
            <RetweetTableComponent
              id={this.state.model!.id}
              history={this.props.history}
              match={this.props.match}
              apiRoute={
                Constants.ApiEndpoint +
                ApiRoutes.Tweets +
                '/' +
                this.state.model!.tweetId +
                '/' +
                ApiRoutes.Retweets
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

export const WrappedTweetDetailComponent = Form.create({
  name: 'Tweet Detail',
})(TweetDetailComponent);


/*<Codenesium>
    <Hash>54f83d4aec0ba2529b69c86b6cab1291</Hash>
</Codenesium>*/