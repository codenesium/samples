import React, { Component, FormEvent } from 'react';
import axios from 'axios';
import { LoadingForm } from '../../lib/components/loadingForm';
import { Constants, ApiRoutes, ClientRoutes } from '../../constants';
import * as Api from '../../api/models';
import AdminMapper from './adminMapper';
import AdminViewModel from './adminViewModel';
import { Form, Input, Button } from 'antd';
import { WrappedFormUtils } from 'antd/es/form/Form';
import { Alert } from 'antd';

interface AdminDetailComponentProps {
  form: WrappedFormUtils;
  history: any;
  match: any;
}

interface AdminDetailComponentState {
  model?: AdminViewModel;
  loading: boolean;
  loaded: boolean;
  errorOccurred: boolean;
  errorMessage: string;
}

class AdminDetailComponent extends React.Component<
  AdminDetailComponentProps,
  AdminDetailComponentState
> {
  state = {
    model: new AdminViewModel(),
    loading: false,
    loaded: true,
    errorOccurred: false,
    errorMessage: '',
  };

  handleEditClick(e: any) {
    this.props.history.push(
      ClientRoutes.Admins + '/edit/' + this.state.model!.id
    );
  }

  componentDidMount() {
    this.setState({ ...this.state, loading: true });

    axios
      .get(
        Constants.ApiEndpoint +
          ApiRoutes.Admins +
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
          let response = resp.data as Api.AdminClientResponseModel;

          console.log(response);

          let mapper = new AdminMapper();

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
      return <LoadingForm />;
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
              <div>email</div>
              <div>{this.state.model!.email}</div>
            </div>
            <div>
              <div>firstName</div>
              <div>{this.state.model!.firstName}</div>
            </div>
            <div>
              <div>lastName</div>
              <div>{this.state.model!.lastName}</div>
            </div>
            <div>
              <div>password</div>
              <div>{this.state.model!.password}</div>
            </div>
            <div>
              <div>phone</div>
              <div>{this.state.model!.phone}</div>
            </div>
            <div>
              <div>username</div>
              <div>{this.state.model!.username}</div>
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

export const WrappedAdminDetailComponent = Form.create({
  name: 'Admin Detail',
})(AdminDetailComponent);


/*<Codenesium>
    <Hash>892787e13989f5ef030d9f78785c9feb</Hash>
</Codenesium>*/