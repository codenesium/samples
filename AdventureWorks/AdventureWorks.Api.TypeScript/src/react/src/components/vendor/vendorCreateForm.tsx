import React, { Component } from 'react';
import axios from 'axios';
import { CreateResponse } from '../../api/apiObjects';
import { FormikProps, FormikErrors, Field, withFormik } from 'formik';
import * as Yup from 'yup';
import { LoadingForm } from '../../lib/components/loadingForm';
import { ErrorForm } from '../../lib/components/errorForm';
import * as Api from '../../api/models';
import { Constants, ApiRoutes, ClientRoutes } from '../../constants';
import VendorMapper from './vendorMapper';
import VendorViewModel from './vendorViewModel';

interface Props {
  model?: VendorViewModel;
}

const VendorCreateDisplay: React.SFC<FormikProps<VendorViewModel>> = (
  props: FormikProps<VendorViewModel>
) => {
  let status = props.status as CreateResponse<Api.VendorClientRequestModel>;

  let errorsForField = (name: string): string => {
    let response = '';
    if (
      props.touched[name as keyof VendorViewModel] &&
      props.errors[name as keyof VendorViewModel]
    ) {
      response += props.errors[name as keyof VendorViewModel];
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
            errorExistForField('accountNumber')
              ? 'col-sm-2 col-form-label is-invalid'
              : 'col-sm-2 col-form-label'
          }
        >
          AccountNumber
        </label>
        <div className="col-sm-12">
          <Field
            type="datetime-local"
            name="accountNumber"
            className={
              errorExistForField('accountNumber')
                ? 'form-control is-invalid'
                : 'form-control'
            }
          />
          {errorExistForField('accountNumber') && (
            <small className="text-danger">
              {errorsForField('accountNumber')}
            </small>
          )}
        </div>
      </div>

      <div className="form-group row">
        <label
          htmlFor="name"
          className={
            errorExistForField('activeFlag')
              ? 'col-sm-2 col-form-label is-invalid'
              : 'col-sm-2 col-form-label'
          }
        >
          ActiveFlag
        </label>
        <div className="col-sm-12">
          <Field
            type="datetime-local"
            name="activeFlag"
            className={
              errorExistForField('activeFlag')
                ? 'form-control is-invalid'
                : 'form-control'
            }
          />
          {errorExistForField('activeFlag') && (
            <small className="text-danger">
              {errorsForField('activeFlag')}
            </small>
          )}
        </div>
      </div>

      <div className="form-group row">
        <label
          htmlFor="name"
          className={
            errorExistForField('creditRating')
              ? 'col-sm-2 col-form-label is-invalid'
              : 'col-sm-2 col-form-label'
          }
        >
          CreditRating
        </label>
        <div className="col-sm-12">
          <Field
            type="datetime-local"
            name="creditRating"
            className={
              errorExistForField('creditRating')
                ? 'form-control is-invalid'
                : 'form-control'
            }
          />
          {errorExistForField('creditRating') && (
            <small className="text-danger">
              {errorsForField('creditRating')}
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
            errorExistForField('preferredVendorStatu')
              ? 'col-sm-2 col-form-label is-invalid'
              : 'col-sm-2 col-form-label'
          }
        >
          PreferredVendorStatus
        </label>
        <div className="col-sm-12">
          <Field
            type="datetime-local"
            name="preferredVendorStatu"
            className={
              errorExistForField('preferredVendorStatu')
                ? 'form-control is-invalid'
                : 'form-control'
            }
          />
          {errorExistForField('preferredVendorStatu') && (
            <small className="text-danger">
              {errorsForField('preferredVendorStatu')}
            </small>
          )}
        </div>
      </div>

      <div className="form-group row">
        <label
          htmlFor="name"
          className={
            errorExistForField('purchasingWebServiceURL')
              ? 'col-sm-2 col-form-label is-invalid'
              : 'col-sm-2 col-form-label'
          }
        >
          PurchasingWebServiceURL
        </label>
        <div className="col-sm-12">
          <Field
            type="datetime-local"
            name="purchasingWebServiceURL"
            className={
              errorExistForField('purchasingWebServiceURL')
                ? 'form-control is-invalid'
                : 'form-control'
            }
          />
          {errorExistForField('purchasingWebServiceURL') && (
            <small className="text-danger">
              {errorsForField('purchasingWebServiceURL')}
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

const VendorCreate = withFormik<Props, VendorViewModel>({
  mapPropsToValues: props => {
    let response = new VendorViewModel();
    if (props.model != undefined) {
      response.setProperties(
        props.model!.accountNumber,
        props.model!.activeFlag,
        props.model!.businessEntityID,
        props.model!.creditRating,
        props.model!.modifiedDate,
        props.model!.name,
        props.model!.preferredVendorStatu,
        props.model!.purchasingWebServiceURL
      );
    }
    return response;
  },

  validate: values => {
    let errors: FormikErrors<VendorViewModel> = {};

    if (values.accountNumber == '') {
      errors.accountNumber = 'Required';
    }
    if (values.creditRating == 0) {
      errors.creditRating = 'Required';
    }
    if (values.modifiedDate == undefined) {
      errors.modifiedDate = 'Required';
    }
    if (values.name == '') {
      errors.name = 'Required';
    }

    return errors;
  },

  handleSubmit: (values, actions) => {
    actions.setStatus(undefined);
    let mapper = new VendorMapper();

    axios
      .post(
        Constants.ApiEndpoint + ApiRoutes.Vendors,
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
            Api.VendorClientRequestModel
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
  displayName: 'VendorCreate',
})(VendorCreateDisplay);

interface VendorCreateComponentProps {}

interface VendorCreateComponentState {
  model?: VendorViewModel;
  loading: boolean;
  loaded: boolean;
  errorOccurred: boolean;
  errorMessage: string;
}

export default class VendorCreateComponent extends React.Component<
  VendorCreateComponentProps,
  VendorCreateComponentState
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
      return <VendorCreate model={this.state.model} />;
    } else {
      return null;
    }
  }
}


/*<Codenesium>
    <Hash>1a0f613b7ace3c0535d19bd4eccfc946</Hash>
</Codenesium>*/