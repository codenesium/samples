import React, { Component, FormEvent } from 'react';
import axios, { AxiosError, AxiosResponse } from 'axios';
import { Constants, ApiRoutes, ClientRoutes } from '../../constants';
import * as Api from '../../api/models';
import UserMapper from './userMapper';
import UserViewModel from './userViewModel';
import { Form, Input, Button, Spin, Alert } from 'antd';
import { WrappedFormUtils } from 'antd/es/form/Form';
import * as GlobalUtilities from '../../lib/globalUtilities';
import { AdminTableComponent } from '../shared/adminTable';
import { StudentTableComponent } from '../shared/studentTable';
import { TeacherTableComponent } from '../shared/teacherTable';

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
              <h3>Password</h3>
              <p>{String(this.state.model!.password)}</p>
            </div>
            <div>
              <h3>Username</h3>
              <p>{String(this.state.model!.username)}</p>
            </div>
          </div>
          {message}
          <div>
            <h3>Admins</h3>
            <AdminTableComponent
              history={this.props.history}
              match={this.props.match}
              apiRoute={
                Constants.ApiEndpoint +
                ApiRoutes.Users +
                '/' +
                this.state.model!.id +
                '/' +
                ApiRoutes.Admins
              }
            />
          </div>
          <div>
            <h3>Students</h3>
            <StudentTableComponent
              history={this.props.history}
              match={this.props.match}
              apiRoute={
                Constants.ApiEndpoint +
                ApiRoutes.Users +
                '/' +
                this.state.model!.id +
                '/' +
                ApiRoutes.Students
              }
            />
          </div>
          <div>
            <h3>Teachers</h3>
            <TeacherTableComponent
              history={this.props.history}
              match={this.props.match}
              apiRoute={
                Constants.ApiEndpoint +
                ApiRoutes.Users +
                '/' +
                this.state.model!.id +
                '/' +
                ApiRoutes.Teachers
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
    <Hash>0520091773c537979afcfa288586c35e</Hash>
</Codenesium>*/