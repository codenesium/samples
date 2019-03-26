import React, { Component, FormEvent } from 'react';
import axios, { AxiosError, AxiosResponse } from 'axios';
import { Constants, ApiRoutes, ClientRoutes } from '../../constants';
import * as Api from '../../api/models';
import DirectTweetMapper from './directTweetMapper';
import DirectTweetViewModel from './directTweetViewModel';
import { Form, Input, Button, Spin, Alert } from 'antd';
import { WrappedFormUtils } from 'antd/es/form/Form';
import * as GlobalUtilities from '../../lib/globalUtilities';

interface DirectTweetDetailComponentProps {
  form: WrappedFormUtils;
  history: any;
  match: any;
}

interface DirectTweetDetailComponentState {
  model?: DirectTweetViewModel;
  loading: boolean;
  loaded: boolean;
  errorOccurred: boolean;
  errorMessage: string;
}

class DirectTweetDetailComponent extends React.Component<
  DirectTweetDetailComponentProps,
  DirectTweetDetailComponentState
> {
  state = {
    model: new DirectTweetViewModel(),
    loading: false,
    loaded: true,
    errorOccurred: false,
    errorMessage: '',
  };

  handleEditClick(e: any) {
    this.props.history.push(
      ClientRoutes.DirectTweets + '/edit/' + this.state.model!.tweetId
    );
  }

  componentDidMount() {
    this.setState({ ...this.state, loading: true });

    axios
      .get<Api.DirectTweetClientResponseModel>(
        Constants.ApiEndpoint +
          ApiRoutes.DirectTweets +
          '/' +
          this.props.match.params.id,
        {
          headers: GlobalUtilities.defaultHeaders(),
        }
      )
      .then(response => {
        GlobalUtilities.logInfo(response);

        let mapper = new DirectTweetMapper();

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
              <h3>content</h3>
              <p>{String(this.state.model!.content)}</p>
            </div>
            <div>
              <h3>date</h3>
              <p>{String(this.state.model!.date)}</p>
            </div>
            <div style={{ marginBottom: '10px' }}>
              <h3>tagged_user_id</h3>
              <p>
                {String(
                  this.state.model!.taggedUserIdNavigation &&
                    this.state.model!.taggedUserIdNavigation!.toDisplay()
                )}
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

export const WrappedDirectTweetDetailComponent = Form.create({
  name: 'DirectTweet Detail',
})(DirectTweetDetailComponent);


/*<Codenesium>
    <Hash>e0728e66a04b4f435f69bc3c48e92a3c</Hash>
</Codenesium>*/