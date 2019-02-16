import React, { Component } from 'react';
import axios from 'axios';
import * as Api from '../api/models';
import { UpdateResponse } from '../api/ApiObjects';
import Constants from '../constants';
import { FormikProps, FormikErrors, Field, withFormik } from 'formik';
import UserViewModel from '../viewmodels/userViewModel';
import UserMapper from '../mapping/userMapper';

interface Props {
  model?: UserViewModel;
}

const UserEditDisplay = (props: FormikProps<UserViewModel>) => {
  let status = props.status as UpdateResponse<Api.UserClientRequestModel>;

  let errorsForField = (name: string): string => {
    let response = '';
    if (
      props.touched[name as keyof UserViewModel] &&
      props.errors[name as keyof UserViewModel]
    ) {
      response += props.errors[name as keyof UserViewModel];
    }

    if (
      status &&
      status.validationErrors &&
      status.validationErrors.find(
        f => f.propertyName.toLowerCase() == name.toLowerCase()
      )
    ) {
      response += status.validationErrors.filter(
        f => f.propertyName.toLowerCase() == name.toLowerCase()
      )[0].errorMessage;
    }

    return response;
  };

  let errorExistForField = (name: string): boolean => {
    return errorsForField(name) != '';
  };

  return (
    <form onSubmit={props.handleSubmit} role="form">
      <div className="form-group row">
        <label
          htmlFor="name"
          className={
            errorExistForField('id')
              ? 'col-sm-2 col-form-label is-invalid'
              : 'col-sm-2 col-form-label'
          }
        >
          Id
        </label>
        <div className="col-sm-12">
          <Field
            type="input"
            name="id"
            className={
              errorExistForField('id')
                ? 'form-control is-invalid'
                : 'form-control'
            }
          />

          {errorExistForField('id') && (
            <small className="text-danger">{errorsForField('id')}</small>
          )}
        </div>
      </div>
      <div className="form-group row">
        <label
          htmlFor="name"
          className={
            errorExistForField('isDeleted')
              ? 'col-sm-2 col-form-label is-invalid'
              : 'col-sm-2 col-form-label'
          }
        >
          IsDeleted
        </label>
        <div className="col-sm-12">
          <Field
            type="input"
            name="isDeleted"
            className={
              errorExistForField('isDeleted')
                ? 'form-control is-invalid'
                : 'form-control'
            }
          />

          {errorExistForField('isDeleted') && (
            <small className="text-danger">{errorsForField('isDeleted')}</small>
          )}
        </div>
      </div>
      <div className="form-group row">
        <label
          htmlFor="name"
          className={
            errorExistForField('password')
              ? 'col-sm-2 col-form-label is-invalid'
              : 'col-sm-2 col-form-label'
          }
        >
          Password
        </label>
        <div className="col-sm-12">
          <Field
            type="input"
            name="password"
            className={
              errorExistForField('password')
                ? 'form-control is-invalid'
                : 'form-control'
            }
          />

          {errorExistForField('password') && (
            <small className="text-danger">{errorsForField('password')}</small>
          )}
        </div>
      </div>
      <div className="form-group row">
        <label
          htmlFor="name"
          className={
            errorExistForField('tenantId')
              ? 'col-sm-2 col-form-label is-invalid'
              : 'col-sm-2 col-form-label'
          }
        >
          TenantId
        </label>
        <div className="col-sm-12">
          <Field
            type="input"
            name="tenantId"
            className={
              errorExistForField('tenantId')
                ? 'form-control is-invalid'
                : 'form-control'
            }
          />

          {errorExistForField('tenantId') && (
            <small className="text-danger">{errorsForField('tenantId')}</small>
          )}
        </div>
      </div>
      <div className="form-group row">
        <label
          htmlFor="name"
          className={
            errorExistForField('username')
              ? 'col-sm-2 col-form-label is-invalid'
              : 'col-sm-2 col-form-label'
          }
        >
          Username
        </label>
        <div className="col-sm-12">
          <Field
            type="input"
            name="username"
            className={
              errorExistForField('username')
                ? 'form-control is-invalid'
                : 'form-control'
            }
          />

          {errorExistForField('username') && (
            <small className="text-danger">{errorsForField('username')}</small>
          )}
        </div>
      </div>

      <button type="submit" className="btn btn-primary" disabled={false}>
        Submit
      </button>
      <br />
      <br />
      {status && status.success ? (
        <div className="alert alert-success">Success</div>
      ) : null}

      {status && !status.success ? (
        <div className="alert alert-danger">Error occurred</div>
      ) : null}
    </form>
  );
};

const UserUpdate = withFormik<Props, UserViewModel>({
  mapPropsToValues: props => {
    let response = new UserViewModel();
    response.setProperties(
      props.model!.id,
      props.model!.isDeleted,
      props.model!.password,
      props.model!.tenantId,
      props.model!.username
    );
    return response;
  },

  // Custom sync validation
  validate: values => {
    let errors: FormikErrors<UserViewModel> = {};

    if (values.id == 0) {
      errors.id = 'Required';
    }
    if (values.isDeleted == false) {
      errors.isDeleted = 'Required';
    }
    if (values.password == '') {
      errors.password = 'Required';
    }
    if (values.tenantId == 0) {
      errors.tenantId = 'Required';
    }
    if (values.username == '') {
      errors.username = 'Required';
    }

    return errors;
  },
  handleSubmit: (values, actions) => {
    actions.setStatus(undefined);

    let mapper = new UserMapper();

    axios
      .put(
        Constants.ApiUrl + 'users/' + values.id,

        mapper.mapViewModelToApiRequest(values),
        {
          headers: {
            'Content-Type': 'application/json',
          },
        }
      )
      .then(
        resp => {
          let response = resp.data as UpdateResponse<
            Api.UserClientRequestModel
          >;
          actions.setStatus(response);
          console.log(response);
        },
        error => {
          let response = error.response.data as UpdateResponse<
            Api.UserClientRequestModel
          >;
          actions.setStatus(response);
          console.log(response);
        }
      )
      .then(response => {
        // cleanup
      });
  },

  displayName: 'UserEdit',
})(UserEditDisplay);

interface IParams {
  id: number;
}

interface IMatch {
  params: IParams;
}

interface UserEditComponentProps {
  match: IMatch;
}

interface UserEditComponentState {
  model?: UserViewModel;
  loading: boolean;
  loaded: boolean;
  errorOccurred: boolean;
  errorMessage: string;
}

export default class UserEditComponent extends React.Component<
  UserEditComponentProps,
  UserEditComponentState
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
      return <UserUpdate model={this.state.model} />;
    } else if (this.state.errorOccurred) {
      return <div>{this.state.errorMessage}</div>;
    } else {
      return <div />;
    }
  }
}


/*<Codenesium>
    <Hash>accf3af1e2870b0d82959f97e815ed33</Hash>
</Codenesium>*/