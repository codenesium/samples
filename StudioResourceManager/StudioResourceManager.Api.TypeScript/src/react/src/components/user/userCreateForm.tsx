import React, { Component } from 'react';
import axios from 'axios';
import { CreateResponse } from '../../api/ApiObjects';
import { FormikProps, FormikErrors, Field, withFormik } from 'formik';
import * as Yup from 'yup';
import { LoadingForm } from '../../lib/components/loadingForm';
import { ErrorForm } from '../../lib/components/errorForm';
import * as Api from '../../api/models';
import { Constants, ApiRoutes, ClientRoutes } from '../../constants';
import UserMapper from './userMapper';
import UserViewModel from './userViewModel';

interface Props {
  model?: UserViewModel;
}

const UserCreateDisplay: React.SFC<FormikProps<UserViewModel>> = (
  props: FormikProps<UserViewModel>
) => {
  let status = props.status as CreateResponse<Api.UserClientRequestModel>;

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
            errorExistForField('password')
              ? 'col-sm-2 col-form-label is-invalid'
              : 'col-sm-2 col-form-label'
          }
        >
          Password
        </label>
        <div className="col-sm-12">
          <Field
            type="textbox"
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
            errorExistForField('username')
              ? 'col-sm-2 col-form-label is-invalid'
              : 'col-sm-2 col-form-label'
          }
        >
          Username
        </label>
        <div className="col-sm-12">
          <Field
            type="textbox"
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

const UserCreate = withFormik<Props, UserViewModel>({
  mapPropsToValues: props => {
    let response = new UserViewModel();
    if (props.model != undefined) {
      response.setProperties(
        props.model!.id,
        props.model!.password,
        props.model!.username
      );
    }
    return response;
  },

  validate: values => {
    let errors: FormikErrors<UserViewModel> = {};

    if (values.password == '') {
      errors.password = 'Required';
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
      .post(
        Constants.ApiEndpoint + ApiRoutes.Users,
        mapper.mapViewModelToApiRequest(values),
        {
          headers: {
            'Content-Type': 'application/json',
          },
        }
      )
      .then(
        resp => {
          let response = resp.data as CreateResponse<
            Api.UserClientRequestModel
          >;
          actions.setStatus(response);
          console.log(response);
        },
        error => {
          console.log(error);
          actions.setStatus('Error from API');
        }
      );
  },
  displayName: 'UserCreate',
})(UserCreateDisplay);

interface UserCreateComponentProps {}

interface UserCreateComponentState {
  model?: UserViewModel;
  loading: boolean;
  loaded: boolean;
  errorOccurred: boolean;
  errorMessage: string;
}

export default class UserCreateComponent extends React.Component<
  UserCreateComponentProps,
  UserCreateComponentState
> {
  state = {
    model: undefined,
    loading: false,
    loaded: true,
    errorOccurred: false,
    errorMessage: '',
  };

  render() {
    if (this.state.loading) {
      return <LoadingForm />;
    } else if (this.state.errorOccurred) {
      return <ErrorForm message={this.state.errorMessage} />;
    } else if (this.state.loaded) {
      return <UserCreate model={this.state.model} />;
    } else {
      return null;
    }
  }
}


/*<Codenesium>
    <Hash>dd66a715d64bee0ebd1f7560acf65498</Hash>
</Codenesium>*/