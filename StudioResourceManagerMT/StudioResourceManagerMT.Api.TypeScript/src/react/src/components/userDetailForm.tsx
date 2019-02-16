import React, { Component } from 'react';
import axios from 'axios';
import * as Api from '../api/models';
import { UpdateResponse } from '../api/ApiObjects';
import Constants from '../constants';
import { FormikProps, FormikErrors, Field, withFormik } from 'formik';
import UserMapper from '../mapping/userMapper';
import UserViewModel from '../viewmodels/userViewModel';

interface Props {
  model?: UserViewModel;
}

const UserDetailDisplay = (model: Props) => {
  return (
    <form role="form">
      <div className="form-group row">
        <label htmlFor="id" className={'col-sm-2 col-form-label'}>
          Id
        </label>
        <div className="col-sm-12">{model.model!.id}</div>
      </div>

      <div className="form-group row">
        <label htmlFor="isDeleted" className={'col-sm-2 col-form-label'}>
          IsDeleted
        </label>
        <div className="col-sm-12">{model.model!.isDeleted}</div>
      </div>

      <div className="form-group row">
        <label htmlFor="password" className={'col-sm-2 col-form-label'}>
          Password
        </label>
        <div className="col-sm-12">{model.model!.password}</div>
      </div>

      <div className="form-group row">
        <label htmlFor="tenantId" className={'col-sm-2 col-form-label'}>
          TenantId
        </label>
        <div className="col-sm-12">{model.model!.tenantId}</div>
      </div>

      <div className="form-group row">
        <label htmlFor="username" className={'col-sm-2 col-form-label'}>
          Username
        </label>
        <div className="col-sm-12">{model.model!.username}</div>
      </div>
    </form>
  );
};

interface IParams {
  id: number;
}

interface IMatch {
  params: IParams;
}

interface UserDetailComponentProps {
  match: IMatch;
}

interface UserDetailComponentState {
  model?: UserViewModel;
  loading: boolean;
  loaded: boolean;
  errorOccurred: boolean;
  errorMessage: string;
}

export default class UserDetailComponent extends React.Component<
  UserDetailComponentProps,
  UserDetailComponentState
> {
  state = {
    model: undefined,
    loading: false,
    loaded: false,
    errorOccurred: false,
    errorMessage: '',
  };

  componentDidMount() {
    this.setState({ ...this.state, loading: true });

    axios
      .get(Constants.ApiUrl + 'users/' + this.props.match.params.id, {
        headers: {
          'Content-Type': 'application/json',
        },
      })
      .then(
        resp => {
          let response = resp.data as Api.UserClientResponseModel;

          let mapper = new UserMapper();

          console.log(response);

          this.setState({
            model: mapper.mapApiResponseToViewModel(response),
            loading: false,
            loaded: true,
            errorOccurred: false,
            errorMessage: '',
          });
        },
        error => {
          let response = error.response.data as UpdateResponse<
            Api.UserClientRequestModel
          >;
          this.setState({
            model: undefined,
            loading: false,
            loaded: false,
            errorOccurred: true,
            errorMessage: 'Error from API',
          });
          console.log(response);
        }
      );
  }
  render() {
    if (this.state.loading) {
      return <div>loading</div>;
    } else if (this.state.loaded) {
      return <UserDetailDisplay model={this.state.model} />;
    } else if (this.state.errorOccurred) {
      return <div>{this.state.errorMessage}</div>;
    } else {
      return <div />;
    }
  }
}


/*<Codenesium>
    <Hash>44e74a49d13e980a4ac6bb2091a7bc2e</Hash>
</Codenesium>*/