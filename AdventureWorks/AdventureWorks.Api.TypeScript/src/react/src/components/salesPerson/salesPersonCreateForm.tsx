import React, { Component } from 'react';
import axios from 'axios';
import { CreateResponse } from '../../api/apiObjects';
import { FormikProps, FormikErrors, Field, withFormik } from 'formik';
import * as Yup from 'yup';
import { LoadingForm } from '../../lib/components/loadingForm';
import { ErrorForm } from '../../lib/components/errorForm';
import * as Api from '../../api/models';
import { Constants, ApiRoutes, ClientRoutes } from '../../constants';
import SalesPersonMapper from './salesPersonMapper';
import SalesPersonViewModel from './salesPersonViewModel';

interface Props {
  model?: SalesPersonViewModel;
}

const SalesPersonCreateDisplay: React.SFC<FormikProps<SalesPersonViewModel>> = (
  props: FormikProps<SalesPersonViewModel>
) => {
  let status = props.status as CreateResponse<
    Api.SalesPersonClientRequestModel
  >;

  let errorsForField = (name: string): string => {
    let response = '';
    if (
      props.touched[name as keyof SalesPersonViewModel] &&
      props.errors[name as keyof SalesPersonViewModel]
    ) {
      response += props.errors[name as keyof SalesPersonViewModel];
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
            errorExistForField('bonus')
              ? 'col-sm-2 col-form-label is-invalid'
              : 'col-sm-2 col-form-label'
          }
        >
          Bonus
        </label>
        <div className="col-sm-12">
          <Field
            type="datetime-local"
            name="bonus"
            className={
              errorExistForField('bonus')
                ? 'form-control is-invalid'
                : 'form-control'
            }
          />
          {errorExistForField('bonus') && (
            <small className="text-danger">{errorsForField('bonus')}</small>
          )}
        </div>
      </div>

      <div className="form-group row">
        <label
          htmlFor="name"
          className={
            errorExistForField('commissionPct')
              ? 'col-sm-2 col-form-label is-invalid'
              : 'col-sm-2 col-form-label'
          }
        >
          CommissionPct
        </label>
        <div className="col-sm-12">
          <Field
            type="datetime-local"
            name="commissionPct"
            className={
              errorExistForField('commissionPct')
                ? 'form-control is-invalid'
                : 'form-control'
            }
          />
          {errorExistForField('commissionPct') && (
            <small className="text-danger">
              {errorsForField('commissionPct')}
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
            errorExistForField('salesLastYear')
              ? 'col-sm-2 col-form-label is-invalid'
              : 'col-sm-2 col-form-label'
          }
        >
          SalesLastYear
        </label>
        <div className="col-sm-12">
          <Field
            type="datetime-local"
            name="salesLastYear"
            className={
              errorExistForField('salesLastYear')
                ? 'form-control is-invalid'
                : 'form-control'
            }
          />
          {errorExistForField('salesLastYear') && (
            <small className="text-danger">
              {errorsForField('salesLastYear')}
            </small>
          )}
        </div>
      </div>

      <div className="form-group row">
        <label
          htmlFor="name"
          className={
            errorExistForField('salesQuota')
              ? 'col-sm-2 col-form-label is-invalid'
              : 'col-sm-2 col-form-label'
          }
        >
          SalesQuota
        </label>
        <div className="col-sm-12">
          <Field
            type="datetime-local"
            name="salesQuota"
            className={
              errorExistForField('salesQuota')
                ? 'form-control is-invalid'
                : 'form-control'
            }
          />
          {errorExistForField('salesQuota') && (
            <small className="text-danger">
              {errorsForField('salesQuota')}
            </small>
          )}
        </div>
      </div>

      <div className="form-group row">
        <label
          htmlFor="name"
          className={
            errorExistForField('salesYTD')
              ? 'col-sm-2 col-form-label is-invalid'
              : 'col-sm-2 col-form-label'
          }
        >
          SalesYTD
        </label>
        <div className="col-sm-12">
          <Field
            type="datetime-local"
            name="salesYTD"
            className={
              errorExistForField('salesYTD')
                ? 'form-control is-invalid'
                : 'form-control'
            }
          />
          {errorExistForField('salesYTD') && (
            <small className="text-danger">{errorsForField('salesYTD')}</small>
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

const SalesPersonCreate = withFormik<Props, SalesPersonViewModel>({
  mapPropsToValues: props => {
    let response = new SalesPersonViewModel();
    if (props.model != undefined) {
      response.setProperties(
        props.model!.bonus,
        props.model!.businessEntityID,
        props.model!.commissionPct,
        props.model!.modifiedDate,
        props.model!.rowguid,
        props.model!.salesLastYear,
        props.model!.salesQuota,
        props.model!.salesYTD,
        props.model!.territoryID
      );
    }
    return response;
  },

  validate: values => {
    let errors: FormikErrors<SalesPersonViewModel> = {};

    if (values.bonus == 0) {
      errors.bonus = 'Required';
    }
    if (values.commissionPct == 0) {
      errors.commissionPct = 'Required';
    }
    if (values.modifiedDate == undefined) {
      errors.modifiedDate = 'Required';
    }
    if (values.rowguid == undefined) {
      errors.rowguid = 'Required';
    }
    if (values.salesLastYear == 0) {
      errors.salesLastYear = 'Required';
    }
    if (values.salesYTD == 0) {
      errors.salesYTD = 'Required';
    }

    return errors;
  },

  handleSubmit: (values, actions) => {
    actions.setStatus(undefined);
    let mapper = new SalesPersonMapper();

    axios
      .post(
        Constants.ApiEndpoint + ApiRoutes.SalesPersons,
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
            Api.SalesPersonClientRequestModel
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
  displayName: 'SalesPersonCreate',
})(SalesPersonCreateDisplay);

interface SalesPersonCreateComponentProps {}

interface SalesPersonCreateComponentState {
  model?: SalesPersonViewModel;
  loading: boolean;
  loaded: boolean;
  errorOccurred: boolean;
  errorMessage: string;
}

export default class SalesPersonCreateComponent extends React.Component<
  SalesPersonCreateComponentProps,
  SalesPersonCreateComponentState
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
      return <SalesPersonCreate model={this.state.model} />;
    } else {
      return null;
    }
  }
}


/*<Codenesium>
    <Hash>8c1d4470554ce76851014defe830ba17</Hash>
</Codenesium>*/