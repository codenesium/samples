import React, { Component, FormEvent } from 'react';
import axios, { AxiosError, AxiosResponse } from 'axios';
import { Constants, ApiRoutes, ClientRoutes } from '../../constants';
import * as Api from '../../api/models';
import FollowerMapper from './followerMapper';
import FollowerViewModel from './followerViewModel';
import { Form, Input, Button, Spin, Alert } from 'antd';
import { WrappedFormUtils } from 'antd/es/form/Form';
import * as GlobalUtilities from '../../lib/globalUtilities';

interface FollowerDetailComponentProps {
  form: WrappedFormUtils;
  history: any;
  match: any;
}

interface FollowerDetailComponentState {
  model?: FollowerViewModel;
  loading: boolean;
  loaded: boolean;
  errorOccurred: boolean;
  errorMessage: string;
}

class FollowerDetailComponent extends React.Component<
  FollowerDetailComponentProps,
  FollowerDetailComponentState
> {
  state = {
    model: new FollowerViewModel(),
    loading: false,
    loaded: true,
    errorOccurred: false,
    errorMessage: '',
  };

  handleEditClick(e: any) {
    this.props.history.push(
      ClientRoutes.Followers + '/edit/' + this.state.model!.id
    );
  }

  componentDidMount() {
    this.setState({ ...this.state, loading: true });

    axios
      .get<Api.FollowerClientResponseModel>(
        Constants.ApiEndpoint +
          ApiRoutes.Followers +
          '/' +
          this.props.match.params.id,
        {
          headers: GlobalUtilities.defaultHeaders(),
        }
      )
      .then(response => {
        GlobalUtilities.logInfo(response);

        let mapper = new FollowerMapper();

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
              <h3>blocked</h3>
              <p>{String(this.state.model!.blocked)}</p>
            </div>
            <div>
              <h3>date_followed</h3>
              <p>{String(this.state.model!.dateFollowed)}</p>
            </div>
            <div>
              <h3>follow_request_status</h3>
              <p>{String(this.state.model!.followRequestStatu)}</p>
            </div>
            <div style={{ marginBottom: '10px' }}>
              <h3>followed_user_id</h3>
              <p>
                {String(
                  this.state.model!.followedUserIdNavigation &&
                    this.state.model!.followedUserIdNavigation!.toDisplay()
                )}
              </p>
            </div>
            <div style={{ marginBottom: '10px' }}>
              <h3>following_user_id</h3>
              <p>
                {String(
                  this.state.model!.followingUserIdNavigation &&
                    this.state.model!.followingUserIdNavigation!.toDisplay()
                )}
              </p>
            </div>
            <div>
              <h3>muted</h3>
              <p>{String(this.state.model!.muted)}</p>
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

export const WrappedFollowerDetailComponent = Form.create({
  name: 'Follower Detail',
})(FollowerDetailComponent);


/*<Codenesium>
    <Hash>aeca46e4271f243aef30140b2e782d96</Hash>
</Codenesium>*/