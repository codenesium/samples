import React, { Component, FormEvent } from 'react';
import axios from 'axios';
import { Constants, ApiRoutes, ClientRoutes } from '../../constants';
import * as Api from '../../api/models';
import UserMapper from './userMapper';
import UserViewModel from './userViewModel';
import { Form, Input, Button, Spin, Alert } from 'antd';
import { WrappedFormUtils } from 'antd/es/form/Form';

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
      .get(
        Constants.ApiEndpoint +
          ApiRoutes.Users +
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
          let response = resp.data as Api.UserClientResponseModel;

          console.log(response);

          let mapper = new UserMapper();

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
            loaded: false,
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
              <h3>AboutMe</h3>
              <p>{String(this.state.model!.aboutMe)}</p>
            </div>
            <div>
              <h3>AccountId</h3>
              <p>{String(this.state.model!.accountId)}</p>
            </div>
            <div>
              <h3>Age</h3>
              <p>{String(this.state.model!.age)}</p>
            </div>
            <div>
              <h3>CreationDate</h3>
              <p>{String(this.state.model!.creationDate)}</p>
            </div>
            <div>
              <h3>DisplayName</h3>
              <p>{String(this.state.model!.displayName)}</p>
            </div>
            <div>
              <h3>DownVotes</h3>
              <p>{String(this.state.model!.downVote)}</p>
            </div>
            <div>
              <h3>EmailHash</h3>
              <p>{String(this.state.model!.emailHash)}</p>
            </div>
            <div>
              <h3>LastAccessDate</h3>
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
              <h3>UpVotes</h3>
              <p>{String(this.state.model!.upVote)}</p>
            </div>
            <div>
              <h3>Views</h3>
              <p>{String(this.state.model!.view)}</p>
            </div>
            <div>
              <h3>WebsiteUrl</h3>
              <p>{String(this.state.model!.websiteUrl)}</p>
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

export const WrappedUserDetailComponent = Form.create({ name: 'User Detail' })(
  UserDetailComponent
);


/*<Codenesium>
    <Hash>34fd04da1f713799c964352f64bde19d</Hash>
</Codenesium>*/