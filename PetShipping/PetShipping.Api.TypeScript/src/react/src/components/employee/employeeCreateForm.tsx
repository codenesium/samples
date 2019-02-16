import React, { Component } from 'react';
import axios from 'axios';
import { CreateResponse } from '../../api/ApiObjects';
import { FormikProps, FormikErrors, Field, withFormik } from 'formik';
import * as Yup from 'yup';
import { LoadingForm } from '../../lib/components/loadingForm';
import { ErrorForm } from '../../lib/components/errorForm';
import * as Api from '../../api/models';
import { Constants, ApiRoutes, ClientRoutes } from '../../constants';
import EmployeeMapper from './employeeMapper';
import EmployeeViewModel from './employeeViewModel';

interface Props {
  model?: EmployeeViewModel;
}

const EmployeeCreateDisplay: React.SFC<FormikProps<EmployeeViewModel>> = (
  props: FormikProps<EmployeeViewModel>
) => {
  let status = props.status as CreateResponse<Api.EmployeeClientRequestModel>;

  let errorsForField = (name: string): string => {
    let response = '';
    if (
      props.touched[name as keyof EmployeeViewModel] &&
      props.errors[name as keyof EmployeeViewModel]
    ) {
      response += props.errors[name as keyof EmployeeViewModel];
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
            errorExistForField('firstName')
              ? 'col-sm-2 col-form-label is-invalid'
              : 'col-sm-2 col-form-label'
          }
        >
          FirstName
        </label>
        <div className="col-sm-12">
          <Field
            type="datetime-local"
            name="firstName"
            className={
              errorExistForField('firstName')
                ? 'form-control is-invalid'
                : 'form-control'
            }
          />
          {errorExistForField('firstName') && (
            <small className="text-danger">{errorsForField('firstName')}</small>
          )}
        </div>
      </div>

      <div className="form-group row">
        <label
          htmlFor="name"
          className={
            errorExistForField('isSalesPerson')
              ? 'col-sm-2 col-form-label is-invalid'
              : 'col-sm-2 col-form-label'
          }
        >
          IsSalesPerson
        </label>
        <div className="col-sm-12">
          <Field
            type="datetime-local"
            name="isSalesPerson"
            className={
              errorExistForField('isSalesPerson')
                ? 'form-control is-invalid'
                : 'form-control'
            }
          />
          {errorExistForField('isSalesPerson') && (
            <small className="text-danger">
              {errorsForField('isSalesPerson')}
            </small>
          )}
        </div>
      </div>

      <div className="form-group row">
        <label
          htmlFor="name"
          className={
            errorExistForField('isShipper')
              ? 'col-sm-2 col-form-label is-invalid'
              : 'col-sm-2 col-form-label'
          }
        >
          IsShipper
        </label>
        <div className="col-sm-12">
          <Field
            type="datetime-local"
            name="isShipper"
            className={
              errorExistForField('isShipper')
                ? 'form-control is-invalid'
                : 'form-control'
            }
          />
          {errorExistForField('isShipper') && (
            <small className="text-danger">{errorsForField('isShipper')}</small>
          )}
        </div>
      </div>

      <div className="form-group row">
        <label
          htmlFor="name"
          className={
            errorExistForField('lastName')
              ? 'col-sm-2 col-form-label is-invalid'
              : 'col-sm-2 col-form-label'
          }
        >
          LastName
        </label>
        <div className="col-sm-12">
          <Field
            type="datetime-local"
            name="lastName"
            className={
              errorExistForField('lastName')
                ? 'form-control is-invalid'
                : 'form-control'
            }
          />
          {errorExistForField('lastName') && (
            <small className="text-danger">{errorsForField('lastName')}</small>
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

const EmployeeCreate = withFormik<Props, EmployeeViewModel>({
  mapPropsToValues: props => {
    let response = new EmployeeViewModel();
    if (props.model != undefined) {
      response.setProperties(
        props.model!.firstName,
        props.model!.id,
        props.model!.isSalesPerson,
        props.model!.isShipper,
        props.model!.lastName
      );
    }
    return response;
  },

  validate: values => {
    let errors: FormikErrors<EmployeeViewModel> = {};

    if (values.firstName == '') {
      errors.firstName = 'Required';
    }
    if (values.lastName == '') {
      errors.lastName = 'Required';
    }

    return errors;
  },

  handleSubmit: (values, actions) => {
    actions.setStatus(undefined);
    let mapper = new EmployeeMapper();

    axios
      .post(
        Constants.ApiEndpoint + ApiRoutes.Employees,
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
            Api.EmployeeClientRequestModel
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
  displayName: 'EmployeeCreate',
})(EmployeeCreateDisplay);

interface EmployeeCreateComponentProps {}

interface EmployeeCreateComponentState {
  model?: EmployeeViewModel;
  loading: boolean;
  loaded: boolean;
  errorOccurred: boolean;
  errorMessage: string;
}

export default class EmployeeCreateComponent extends React.Component<
  EmployeeCreateComponentProps,
  EmployeeCreateComponentState
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
      return <EmployeeCreate model={this.state.model} />;
    } else {
      return null;
    }
  }
}


/*<Codenesium>
    <Hash>f1b7f9c7abd745247a7147b8f04bfd9d</Hash>
</Codenesium>*/