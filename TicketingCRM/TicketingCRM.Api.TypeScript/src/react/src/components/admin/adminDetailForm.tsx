import React, { Component, FormEvent } from 'react';
import axios, { AxiosError, AxiosResponse } from 'axios';
import { Constants, ApiRoutes, ClientRoutes } from '../../constants';
import * as Api from '../../api/models';
import AdminMapper from './adminMapper';
import AdminViewModel from './adminViewModel';
import { Form, Input, Button, Spin, Alert } from 'antd';
import { WrappedFormUtils } from 'antd/es/form/Form';
import * as GlobalUtilities from '../../lib/globalUtilities';
import { VenueTableComponent } from '../shared/venueTable';

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
      .get<Api.AdminClientResponseModel>(
        Constants.ApiEndpoint +
          ApiRoutes.Admins +
          '/' +
          this.props.match.params.id,
        {
          headers: GlobalUtilities.defaultHeaders(),
        }
      )
      .then(response => {
        GlobalUtilities.logInfo(response);

        let mapper = new AdminMapper();

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
              <h3>Email</h3>
              <p>{String(this.state.model!.email)}</p>
            </div>
            <div>
              <h3>First Name</h3>
              <p>{String(this.state.model!.firstName)}</p>
            </div>
            <div>
              <h3>Last Name</h3>
              <p>{String(this.state.model!.lastName)}</p>
            </div>
            <div>
              <h3>Password</h3>
              <p>{String(this.state.model!.password)}</p>
            </div>
            <div>
              <h3>Phone</h3>
              <p>{String(this.state.model!.phone)}</p>
            </div>
            <div>
              <h3>Username</h3>
              <p>{String(this.state.model!.username)}</p>
            </div>
          </div>
          {message}
          <div>
            <h3>Venues</h3>
            <VenueTableComponent
              history={this.props.history}
              match={this.props.match}
              apiRoute={
                Constants.ApiEndpoint +
                ApiRoutes.Admins +
                '/' +
                this.state.model!.id +
                '/' +
                ApiRoutes.Venues
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

export const WrappedAdminDetailComponent = Form.create({
  name: 'Admin Detail',
})(AdminDetailComponent);


/*<Codenesium>
    <Hash>2126a7fab69bd682fd28558c63e3fcd0</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/