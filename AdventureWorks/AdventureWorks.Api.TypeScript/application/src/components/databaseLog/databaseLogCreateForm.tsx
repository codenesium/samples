import React, { Component } from 'react';
import axios from 'axios';
import { CreateResponse } from '../../api/ApiObjects';
import { FormikProps, FormikErrors, Field, withFormik } from 'formik';
import * as Yup from 'yup';
import * as Api from '../../api/models';
import Constants from '../../constants';
import DatabaseLogMapper from './databaseLogMapper';
import DatabaseLogViewModel from './databaseLogViewModel';

interface Props {
  model?: DatabaseLogViewModel;
}

const DatabaseLogCreateDisplay: React.SFC<FormikProps<DatabaseLogViewModel>> = (
  props: FormikProps<DatabaseLogViewModel>
) => {
  let status = props.status as CreateResponse<
    Api.DatabaseLogClientRequestModel
  >;

  let errorsForField = (name: string): string => {
    let response = '';
    if (
      props.touched[name as keyof DatabaseLogViewModel] &&
      props.errors[name as keyof DatabaseLogViewModel]
    ) {
      response += props.errors[name as keyof DatabaseLogViewModel];
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
            errorExistForField('databaseUser')
              ? 'col-sm-2 col-form-label is-invalid'
              : 'col-sm-2 col-form-label'
          }
        >
          DatabaseUser
        </label>
        <div className="col-sm-12">
          <Field
            type="datetime-local"
            name="databaseUser"
            className={
              errorExistForField('databaseUser')
                ? 'form-control is-invalid'
                : 'form-control'
            }
          />
          {errorExistForField('databaseUser') && (
            <small className="text-danger">
              {errorsForField('databaseUser')}
            </small>
          )}
        </div>
      </div>

      <div className="form-group row">
        <label
          htmlFor="name"
          className={
            errorExistForField('postTime')
              ? 'col-sm-2 col-form-label is-invalid'
              : 'col-sm-2 col-form-label'
          }
        >
          PostTime
        </label>
        <div className="col-sm-12">
          <Field
            type="datetime-local"
            name="postTime"
            className={
              errorExistForField('postTime')
                ? 'form-control is-invalid'
                : 'form-control'
            }
          />
          {errorExistForField('postTime') && (
            <small className="text-danger">{errorsForField('postTime')}</small>
          )}
        </div>
      </div>

      <div className="form-group row">
        <label
          htmlFor="name"
          className={
            errorExistForField('schema')
              ? 'col-sm-2 col-form-label is-invalid'
              : 'col-sm-2 col-form-label'
          }
        >
          Schema
        </label>
        <div className="col-sm-12">
          <Field
            type="datetime-local"
            name="schema"
            className={
              errorExistForField('schema')
                ? 'form-control is-invalid'
                : 'form-control'
            }
          />
          {errorExistForField('schema') && (
            <small className="text-danger">{errorsForField('schema')}</small>
          )}
        </div>
      </div>

      <div className="form-group row">
        <label
          htmlFor="name"
          className={
            errorExistForField('tsql')
              ? 'col-sm-2 col-form-label is-invalid'
              : 'col-sm-2 col-form-label'
          }
        >
          TSQL
        </label>
        <div className="col-sm-12">
          <Field
            type="datetime-local"
            name="tsql"
            className={
              errorExistForField('tsql')
                ? 'form-control is-invalid'
                : 'form-control'
            }
          />
          {errorExistForField('tsql') && (
            <small className="text-danger">{errorsForField('tsql')}</small>
          )}
        </div>
      </div>

      <div className="form-group row">
        <label
          htmlFor="name"
          className={
            errorExistForField('xmlEvent')
              ? 'col-sm-2 col-form-label is-invalid'
              : 'col-sm-2 col-form-label'
          }
        >
          XmlEvent
        </label>
        <div className="col-sm-12">
          <Field
            type="datetime-local"
            name="xmlEvent"
            className={
              errorExistForField('xmlEvent')
                ? 'form-control is-invalid'
                : 'form-control'
            }
          />
          {errorExistForField('xmlEvent') && (
            <small className="text-danger">{errorsForField('xmlEvent')}</small>
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

const DatabaseLogCreate = withFormik<Props, DatabaseLogViewModel>({
  mapPropsToValues: props => {
    let response = new DatabaseLogViewModel();
    if (props.model != undefined) {
      response.setProperties(
        props.model!.databaseLogID,
        props.model!.databaseUser,
        props.model!.postTime,
        props.model!.schema,
        props.model!.tsql,
        props.model!.xmlEvent
      );
    }
    return response;
  },

  validate: values => {
    let errors: FormikErrors<DatabaseLogViewModel> = {};

    if (values.databaseUser == '') {
      errors.databaseUser = 'Required';
    }
    if (values.postTime == undefined) {
      errors.postTime = 'Required';
    }
    if (values.tsql == '') {
      errors.tsql = 'Required';
    }
    if (values.xmlEvent == '') {
      errors.xmlEvent = 'Required';
    }

    return errors;
  },

  handleSubmit: (values, actions) => {
    actions.setStatus(undefined);
    let mapper = new DatabaseLogMapper();

    axios
      .post(
        Constants.ApiUrl + 'databaselogs',
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
            Api.DatabaseLogClientRequestModel
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
  displayName: 'DatabaseLogCreate',
})(DatabaseLogCreateDisplay);

interface DatabaseLogCreateComponentProps {}

interface DatabaseLogCreateComponentState {
  model?: DatabaseLogViewModel;
  loading: boolean;
  loaded: boolean;
  errorOccurred: boolean;
  errorMessage: string;
}

export default class DatabaseLogCreateComponent extends React.Component<
  DatabaseLogCreateComponentProps,
  DatabaseLogCreateComponentState
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
      return <DatabaseLogCreate model={this.state.model} />;
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
    <Hash>dc10cfbd1cb5e6a3c8af15fca6b94e94</Hash>
</Codenesium>*/