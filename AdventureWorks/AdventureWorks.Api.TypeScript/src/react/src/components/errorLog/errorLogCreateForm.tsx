import React, { Component } from 'react';
import axios from 'axios';
import { CreateResponse } from '../../api/ApiObjects';
import { FormikProps, FormikErrors, Field, withFormik } from 'formik';
import * as Yup from 'yup';
import * as Api from '../../api/models';
import Constants from '../../constants';
import ErrorLogMapper from './errorLogMapper';
import ErrorLogViewModel from './errorLogViewModel';

interface Props {
  model?: ErrorLogViewModel;
}

const ErrorLogCreateDisplay: React.SFC<FormikProps<ErrorLogViewModel>> = (
  props: FormikProps<ErrorLogViewModel>
) => {
  let status = props.status as CreateResponse<Api.ErrorLogClientRequestModel>;

  let errorsForField = (name: string): string => {
    let response = '';
    if (
      props.touched[name as keyof ErrorLogViewModel] &&
      props.errors[name as keyof ErrorLogViewModel]
    ) {
      response += props.errors[name as keyof ErrorLogViewModel];
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
            errorExistForField('errorLine')
              ? 'col-sm-2 col-form-label is-invalid'
              : 'col-sm-2 col-form-label'
          }
        >
          ErrorLine
        </label>
        <div className="col-sm-12">
          <Field
            type="datetime-local"
            name="errorLine"
            className={
              errorExistForField('errorLine')
                ? 'form-control is-invalid'
                : 'form-control'
            }
          />
          {errorExistForField('errorLine') && (
            <small className="text-danger">{errorsForField('errorLine')}</small>
          )}
        </div>
      </div>

      <div className="form-group row">
        <label
          htmlFor="name"
          className={
            errorExistForField('errorMessage')
              ? 'col-sm-2 col-form-label is-invalid'
              : 'col-sm-2 col-form-label'
          }
        >
          ErrorMessage
        </label>
        <div className="col-sm-12">
          <Field
            type="datetime-local"
            name="errorMessage"
            className={
              errorExistForField('errorMessage')
                ? 'form-control is-invalid'
                : 'form-control'
            }
          />
          {errorExistForField('errorMessage') && (
            <small className="text-danger">
              {errorsForField('errorMessage')}
            </small>
          )}
        </div>
      </div>

      <div className="form-group row">
        <label
          htmlFor="name"
          className={
            errorExistForField('errorNumber')
              ? 'col-sm-2 col-form-label is-invalid'
              : 'col-sm-2 col-form-label'
          }
        >
          ErrorNumber
        </label>
        <div className="col-sm-12">
          <Field
            type="datetime-local"
            name="errorNumber"
            className={
              errorExistForField('errorNumber')
                ? 'form-control is-invalid'
                : 'form-control'
            }
          />
          {errorExistForField('errorNumber') && (
            <small className="text-danger">
              {errorsForField('errorNumber')}
            </small>
          )}
        </div>
      </div>

      <div className="form-group row">
        <label
          htmlFor="name"
          className={
            errorExistForField('errorProcedure')
              ? 'col-sm-2 col-form-label is-invalid'
              : 'col-sm-2 col-form-label'
          }
        >
          ErrorProcedure
        </label>
        <div className="col-sm-12">
          <Field
            type="datetime-local"
            name="errorProcedure"
            className={
              errorExistForField('errorProcedure')
                ? 'form-control is-invalid'
                : 'form-control'
            }
          />
          {errorExistForField('errorProcedure') && (
            <small className="text-danger">
              {errorsForField('errorProcedure')}
            </small>
          )}
        </div>
      </div>

      <div className="form-group row">
        <label
          htmlFor="name"
          className={
            errorExistForField('errorSeverity')
              ? 'col-sm-2 col-form-label is-invalid'
              : 'col-sm-2 col-form-label'
          }
        >
          ErrorSeverity
        </label>
        <div className="col-sm-12">
          <Field
            type="datetime-local"
            name="errorSeverity"
            className={
              errorExistForField('errorSeverity')
                ? 'form-control is-invalid'
                : 'form-control'
            }
          />
          {errorExistForField('errorSeverity') && (
            <small className="text-danger">
              {errorsForField('errorSeverity')}
            </small>
          )}
        </div>
      </div>

      <div className="form-group row">
        <label
          htmlFor="name"
          className={
            errorExistForField('errorState')
              ? 'col-sm-2 col-form-label is-invalid'
              : 'col-sm-2 col-form-label'
          }
        >
          ErrorState
        </label>
        <div className="col-sm-12">
          <Field
            type="datetime-local"
            name="errorState"
            className={
              errorExistForField('errorState')
                ? 'form-control is-invalid'
                : 'form-control'
            }
          />
          {errorExistForField('errorState') && (
            <small className="text-danger">
              {errorsForField('errorState')}
            </small>
          )}
        </div>
      </div>

      <div className="form-group row">
        <label
          htmlFor="name"
          className={
            errorExistForField('errorTime')
              ? 'col-sm-2 col-form-label is-invalid'
              : 'col-sm-2 col-form-label'
          }
        >
          ErrorTime
        </label>
        <div className="col-sm-12">
          <Field
            type="datetime-local"
            name="errorTime"
            className={
              errorExistForField('errorTime')
                ? 'form-control is-invalid'
                : 'form-control'
            }
          />
          {errorExistForField('errorTime') && (
            <small className="text-danger">{errorsForField('errorTime')}</small>
          )}
        </div>
      </div>

      <div className="form-group row">
        <label
          htmlFor="name"
          className={
            errorExistForField('userName')
              ? 'col-sm-2 col-form-label is-invalid'
              : 'col-sm-2 col-form-label'
          }
        >
          UserName
        </label>
        <div className="col-sm-12">
          <Field
            type="datetime-local"
            name="userName"
            className={
              errorExistForField('userName')
                ? 'form-control is-invalid'
                : 'form-control'
            }
          />
          {errorExistForField('userName') && (
            <small className="text-danger">{errorsForField('userName')}</small>
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

const ErrorLogCreate = withFormik<Props, ErrorLogViewModel>({
  mapPropsToValues: props => {
    let response = new ErrorLogViewModel();
    if (props.model != undefined) {
      response.setProperties(
        props.model!.errorLine,
        props.model!.errorLogID,
        props.model!.errorMessage,
        props.model!.errorNumber,
        props.model!.errorProcedure,
        props.model!.errorSeverity,
        props.model!.errorState,
        props.model!.errorTime,
        props.model!.userName
      );
    }
    return response;
  },

  validate: values => {
    let errors: FormikErrors<ErrorLogViewModel> = {};

    if (values.errorMessage == '') {
      errors.errorMessage = 'Required';
    }
    if (values.errorNumber == 0) {
      errors.errorNumber = 'Required';
    }
    if (values.errorTime == undefined) {
      errors.errorTime = 'Required';
    }
    if (values.userName == '') {
      errors.userName = 'Required';
    }

    return errors;
  },

  handleSubmit: (values, actions) => {
    actions.setStatus(undefined);
    let mapper = new ErrorLogMapper();

    axios
      .post(
        Constants.ApiUrl + 'errorlogs',
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
            Api.ErrorLogClientRequestModel
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
  displayName: 'ErrorLogCreate',
})(ErrorLogCreateDisplay);

interface ErrorLogCreateComponentProps {}

interface ErrorLogCreateComponentState {
  model?: ErrorLogViewModel;
  loading: boolean;
  loaded: boolean;
  errorOccurred: boolean;
  errorMessage: string;
}

export default class ErrorLogCreateComponent extends React.Component<
  ErrorLogCreateComponentProps,
  ErrorLogCreateComponentState
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
      return <div>loading</div>;
    } else if (this.state.loaded) {
      return <ErrorLogCreate model={this.state.model} />;
    } else if (this.state.errorOccurred) {
      return (
        <div className="alert alert-danger">{this.state.errorMessage}</div>
      );
    } else {
      return <div />;
    }
  }
}


/*<Codenesium>
    <Hash>83f8a26552d493adc519e581b8f8b968</Hash>
</Codenesium>*/