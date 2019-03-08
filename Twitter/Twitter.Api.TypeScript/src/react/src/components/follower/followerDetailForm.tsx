import React, { Component, FormEvent } from 'react';
import axios from 'axios';
import { Constants, ApiRoutes, ClientRoutes } from '../../constants';
import * as Api from '../../api/models';
import FollowerMapper from './followerMapper';
import FollowerViewModel from './followerViewModel';
import { Form, Input, Button, Spin, Alert } from 'antd';
import { WrappedFormUtils } from 'antd/es/form/Form';

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
      .get(
        Constants.ApiEndpoint +
          ApiRoutes.Followers +
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
          let response = resp.data as Api.FollowerClientResponseModel;

          console.log(response);

          let mapper = new FollowerMapper();

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
                  this.state.model!.followedUserIdNavigation!.toDisplay()
                )}
              </p>
            </div>
            <div style={{ marginBottom: '10px' }}>
              <h3>following_user_id</h3>
              <p>
                {String(
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
    <Hash>6a5c913c56fec2f19f6d0602b0f3734c</Hash>
</Codenesium>*/