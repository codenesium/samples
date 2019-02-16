import React, { Component } from 'react';
import axios from 'axios';
import { CreateResponse } from '../../api/ApiObjects';
import { FormikProps, FormikErrors, Field, withFormik } from 'formik';
import * as Yup from 'yup';
import * as Api from '../../api/models';
import Constants from '../../constants';
import StateProvinceMapper from './stateProvinceMapper';
import StateProvinceViewModel from './stateProvinceViewModel';

interface Props {
  model?: StateProvinceViewModel;
}

const StateProvinceCreateDisplay: React.SFC<
  FormikProps<StateProvinceViewModel>
> = (props: FormikProps<StateProvinceViewModel>) => {
  let status = props.status as CreateResponse<
    Api.StateProvinceClientRequestModel
  >;

  let errorsForField = (name: string): string => {
    let response = '';
    if (
      props.touched[name as keyof StateProvinceViewModel] &&
      props.errors[name as keyof StateProvinceViewModel]
    ) {
      response += props.errors[name as keyof StateProvinceViewModel];
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
            errorExistForField('countryRegionCode')
              ? 'col-sm-2 col-form-label is-invalid'
              : 'col-sm-2 col-form-label'
          }
        >
          CountryRegionCode
        </label>
        <div className="col-sm-12">
          <Field
            type="datetime-local"
            name="countryRegionCode"
            className={
              errorExistForField('countryRegionCode')
                ? 'form-control is-invalid'
                : 'form-control'
            }
          />
          {errorExistForField('countryRegionCode') && (
            <small className="text-danger">
              {errorsForField('countryRegionCode')}
            </small>
          )}
        </div>
      </div>

      <div className="form-group row">
        <label
          htmlFor="name"
          className={
            errorExistForField('isOnlyStateProvinceFlag')
              ? 'col-sm-2 col-form-label is-invalid'
              : 'col-sm-2 col-form-label'
          }
        >
          IsOnlyStateProvinceFlag
        </label>
        <div className="col-sm-12">
          <Field
            type="datetime-local"
            name="isOnlyStateProvinceFlag"
            className={
              errorExistForField('isOnlyStateProvinceFlag')
                ? 'form-control is-invalid'
                : 'form-control'
            }
          />
          {errorExistForField('isOnlyStateProvinceFlag') && (
            <small className="text-danger">
              {errorsForField('isOnlyStateProvinceFlag')}
            </small>
          )}
        </div>
      </div>

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
            errorExistForField('name')
              ? 'col-sm-2 col-form-label is-invalid'
              : 'col-sm-2 col-form-label'
          }
        >
          Name
        </label>
        <div className="col-sm-12">
          <Field
            type="datetime-local"
            name="name"
            className={
              errorExistForField('name')
                ? 'form-control is-invalid'
                : 'form-control'
            }
          />
          {errorExistForField('name') && (
            <small className="text-danger">{errorsForField('name')}</small>
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

      <div className="form-group row">
        <label
          htmlFor="name"
          className={
            errorExistForField('stateProvinceCode')
              ? 'col-sm-2 col-form-label is-invalid'
              : 'col-sm-2 col-form-label'
          }
        >
          StateProvinceCode
        </label>
        <div className="col-sm-12">
          <Field
            type="datetime-local"
            name="stateProvinceCode"
            className={
              errorExistForField('stateProvinceCode')
                ? 'form-control is-invalid'
                : 'form-control'
            }
          />
          {errorExistForField('stateProvinceCode') && (
            <small className="text-danger">
              {errorsForField('stateProvinceCode')}
            </small>
          )}
        </div>
      </div>

      <div className="form-group row">
        <label
          htmlFor="name"
          className={
            errorExistForField('territoryID')
              ? 'col-sm-2 col-form-label is-invalid'
              : 'col-sm-2 col-form-label'
          }
        >
          TerritoryID
        </label>
        <div className="col-sm-12">
          <Field
            type="datetime-local"
            name="territoryID"
            className={
              errorExistForField('territoryID')
                ? 'form-control is-invalid'
                : 'form-control'
            }
          />
          {errorExistForField('territoryID') && (
            <small className="text-danger">
              {errorsForField('territoryID')}
            </small>
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

const StateProvinceCreate = withFormik<Props, StateProvinceViewModel>({
  mapPropsToValues: props => {
    let response = new StateProvinceViewModel();
    if (props.model != undefined) {
      response.setProperties(
        props.model!.countryRegionCode,
        props.model!.isOnlyStateProvinceFlag,
        props.model!.modifiedDate,
        props.model!.name,
        props.model!.rowguid,
        props.model!.stateProvinceCode,
        props.model!.stateProvinceID,
        props.model!.territoryID
      );
    }
    return response;
  },

  validate: values => {
    let errors: FormikErrors<StateProvinceViewModel> = {};

    if (values.countryRegionCode == '') {
      errors.countryRegionCode = 'Required';
    }
    if (values.isOnlyStateProvinceFlag == false) {
      errors.isOnlyStateProvinceFlag = 'Required';
    }
    if (values.modifiedDate == undefined) {
      errors.modifiedDate = 'Required';
    }
    if (values.name == '') {
      errors.name = 'Required';
    }
    if (values.rowguid == undefined) {
      errors.rowguid = 'Required';
    }
    if (values.stateProvinceCode == '') {
      errors.stateProvinceCode = 'Required';
    }
    if (values.territoryID == 0) {
      errors.territoryID = 'Required';
    }

    return errors;
  },

  handleSubmit: (values, actions) => {
    actions.setStatus(undefined);
    let mapper = new StateProvinceMapper();

    axios
      .post(
        Constants.ApiUrl + 'stateprovinces',
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
            Api.StateProvinceClientRequestModel
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
  displayName: 'StateProvinceCreate',
})(StateProvinceCreateDisplay);

interface StateProvinceCreateComponentProps {}

interface StateProvinceCreateComponentState {
  model?: StateProvinceViewModel;
  loading: boolean;
  loaded: boolean;
  errorOccurred: boolean;
  errorMessage: string;
}

export default class StateProvinceCreateComponent extends React.Component<
  StateProvinceCreateComponentProps,
  StateProvinceCreateComponentState
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
      return <StateProvinceCreate model={this.state.model} />;
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
    <Hash>d64a87556f918d722309217adae32055</Hash>
</Codenesium>*/