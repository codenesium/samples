import React, { Component } from 'react';
import axios from 'axios';
import { CreateResponse } from '../../api/ApiObjects';
import { FormikProps, FormikErrors, Field, withFormik } from 'formik';
import * as Yup from 'yup';
import * as Api from '../../api/models';
import Constants from '../../constants';
import PasswordMapper from './passwordMapper';
import PasswordViewModel from './passwordViewModel';

interface Props {
  model?: PasswordViewModel;
}

const PasswordCreateDisplay: React.SFC<FormikProps<PasswordViewModel>> = (
  props: FormikProps<PasswordViewModel>
) => {
  let status = props.status as CreateResponse<Api.PasswordClientRequestModel>;

  let errorsForField = (name: string): string => {
    let response = '';
    if (
      props.touched[name as keyof PasswordViewModel] &&
      props.errors[name as keyof PasswordViewModel]
    ) {
      response += props.errors[name as keyof PasswordViewModel];
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
            errorExistForField('modifiedDate')
              ? 'col-sm-2 col-form-label is-invalid'
              : 'col-sm-2 col-form-label'
          }
        >
          ModifiedDate
        </label>
        <div className="col-sm-12">
          <Field
            type="datetime-local"
            name="modifiedDate"
            className={
              errorExistForField('modifiedDate')
                ? 'form-control is-invalid'
                : 'form-control'
            }
          />
          {errorExistForField('modifiedDate') && (
            <small className="text-danger">
              {errorsForField('modifiedDate')}
            </small>
          )}
        </div>
      </div>

      <div className="form-group row">
        <label
          htmlFor="name"
          className={
            errorExistForField('passwordHash')
              ? 'col-sm-2 col-form-label is-invalid'
              : 'col-sm-2 col-form-label'
          }
        >
          PasswordHash
        </label>
        <div className="col-sm-12">
          <Field
            type="datetime-local"
            name="passwordHash"
            className={
              errorExistForField('passwordHash')
                ? 'form-control is-invalid'
                : 'form-control'
            }
          />
          {errorExistForField('passwordHash') && (
            <small className="text-danger">
              {errorsForField('passwordHash')}
            </small>
          )}
        </div>
      </div>

      <div className="form-group row">
        <label
          htmlFor="name"
          className={
            errorExistForField('passwordSalt')
              ? 'col-sm-2 col-form-label is-invalid'
              : 'col-sm-2 col-form-label'
          }
        >
          PasswordSalt
        </label>
        <div className="col-sm-12">
          <Field
            type="datetime-local"
            name="passwordSalt"
            className={
              errorExistForField('passwordSalt')
                ? 'form-control is-invalid'
                : 'form-control'
            }
          />
          {errorExistForField('passwordSalt') && (
            <small className="text-danger">
              {errorsForField('passwordSalt')}
            </small>
          )}
        </div>
      </div>

      <div className="form-group row">
        <label
          htmlFor="name"
          className={
            errorExistForField('rowguid')
              ? 'col-sm-2 col-form-label is-invalid'
              : 'col-sm-2 col-form-label'
          }
        >
          Rowguid
        </label>
        <div className="col-sm-12">
          <Field
            type="datetime-local"
            name="rowguid"
            className={
              errorExistForField('rowguid')
                ? 'form-control is-invalid'
                : 'form-control'
            }
          />
          {errorExistForField('rowguid') && (
            <small className="text-danger">{errorsForField('rowguid')}</small>
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

const PasswordCreate = withFormik<Props, PasswordViewModel>({
  mapPropsToValues: props => {
    let response = new PasswordViewModel();
    if (props.model != undefined) {
      response.setProperties(
        props.model!.businessEntityID,
        props.model!.modifiedDate,
        props.model!.passwordHash,
        props.model!.passwordSalt,
        props.model!.rowguid
      );
    }
    return response;
  },

  validate: values => {
    let errors: FormikErrors<PasswordViewModel> = {};

    if (values.modifiedDate == undefined) {
      errors.modifiedDate = 'Required';
    }
    if (values.passwordHash == '') {
      errors.passwordHash = 'Required';
    }
    if (values.passwordSalt == '') {
      errors.passwordSalt = 'Required';
    }
    if (values.rowguid == undefined) {
      errors.rowguid = 'Required';
    }

    return errors;
  },

  handleSubmit: (values, actions) => {
    actions.setStatus(undefined);
    let mapper = new PasswordMapper();

    axios
      .post(
        Constants.ApiUrl + 'passwords',
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
            Api.PasswordClientRequestModel
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
  displayName: 'PasswordCreate',
})(PasswordCreateDisplay);

interface PasswordCreateComponentProps {}

interface PasswordCreateComponentState {
  model?: PasswordViewModel;
  loading: boolean;
  loaded: boolean;
  errorOccurred: boolean;
  errorMessage: string;
}

export default class PasswordCreateComponent extends React.Component<
  PasswordCreateComponentProps,
  PasswordCreateComponentState
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
      return <PasswordCreate model={this.state.model} />;
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
    <Hash>cccfb177bd9367c3a28daf5b2c8bb936</Hash>
</Codenesium>*/