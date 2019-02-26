import React, { Component, FormEvent } from 'react';
import axios from 'axios';
import { Constants, ApiRoutes, ClientRoutes } from '../../constants';
import * as Api from '../../api/models';
import QuoteTweetMapper from './quoteTweetMapper';
import QuoteTweetViewModel from './quoteTweetViewModel';
import { Form, Input, Button, Spin, Alert } from 'antd';
import { WrappedFormUtils } from 'antd/es/form/Form';

interface QuoteTweetDetailComponentProps {
  form: WrappedFormUtils;
  history: any;
  match: any;
}

interface QuoteTweetDetailComponentState {
  model?: QuoteTweetViewModel;
  loading: boolean;
  loaded: boolean;
  errorOccurred: boolean;
  errorMessage: string;
}

class QuoteTweetDetailComponent extends React.Component<
  QuoteTweetDetailComponentProps,
  QuoteTweetDetailComponentState
> {
  state = {
    model: new QuoteTweetViewModel(),
    loading: false,
    loaded: true,
    errorOccurred: false,
    errorMessage: '',
  };

  handleEditClick(e: any) {
    this.props.history.push(
      ClientRoutes.QuoteTweets + '/edit/' + this.state.model!.quoteTweetId
    );
  }

  componentDidMount() {
    this.setState({ ...this.state, loading: true });

    axios
      .get(
        Constants.ApiEndpoint +
          ApiRoutes.QuoteTweets +
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
          let response = resp.data as Api.QuoteTweetClientResponseModel;

          console.log(response);

          let mapper = new QuoteTweetMapper();

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
              <h3>retweeter_user_id</h3>
              <p>
                {String(
                  this.state.model!.retweeterUserIdNavigation!.toDisplay()
                )}
              </p>
            </div>
            <div style={{ marginBottom: '10px' }}>
              <h3>source_tweet_id</h3>
              <p>
                {String(this.state.model!.sourceTweetIdNavigation!.toDisplay())}
              </p>
            </div>
            <div>
              <h3>time</h3>
              <p>{String(this.state.model!.time)}</p>
            </div>
          </div>
          {message}
        </div>
      );
    } else {
      return null;
    }
  }
}

export const WrappedQuoteTweetDetailComponent = Form.create({
  name: 'QuoteTweet Detail',
})(QuoteTweetDetailComponent);


/*<Codenesium>
    <Hash>c54aa7ca5e2e086300f017f0c50877e7</Hash>
</Codenesium>*/