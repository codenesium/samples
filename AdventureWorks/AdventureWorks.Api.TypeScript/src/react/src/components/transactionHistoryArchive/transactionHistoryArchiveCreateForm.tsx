import React, { Component } from 'react';
import axios from 'axios';
import { CreateResponse } from '../../api/apiObjects';
import { FormikProps, FormikErrors, Field, withFormik } from 'formik';
import * as Yup from 'yup';
import { LoadingForm } from '../../lib/components/loadingForm';
import { ErrorForm } from '../../lib/components/errorForm';
import * as Api from '../../api/models';
import { Constants, ApiRoutes, ClientRoutes } from '../../constants';
import TransactionHistoryArchiveMapper from './transactionHistoryArchiveMapper';
import TransactionHistoryArchiveViewModel from './transactionHistoryArchiveViewModel';

interface Props {
  model?: TransactionHistoryArchiveViewModel;
}

const TransactionHistoryArchiveCreateDisplay: React.SFC<
  FormikProps<TransactionHistoryArchiveViewModel>
> = (props: FormikProps<TransactionHistoryArchiveViewModel>) => {
  let status = props.status as CreateResponse<
    Api.TransactionHistoryArchiveClientRequestModel
  >;

  let errorsForField = (name: string): string => {
    let response = '';
    if (
      props.touched[name as keyof TransactionHistoryArchiveViewModel] &&
      props.errors[name as keyof TransactionHistoryArchiveViewModel]
    ) {
      response +=
        props.errors[name as keyof TransactionHistoryArchiveViewModel];
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
            errorExistForField('actualCost')
              ? 'col-sm-2 col-form-label is-invalid'
              : 'col-sm-2 col-form-label'
          }
        >
          ActualCost
        </label>
        <div className="col-sm-12">
          <Field
            type="datetime-local"
            name="actualCost"
            className={
              errorExistForField('actualCost')
                ? 'form-control is-invalid'
                : 'form-control'
            }
          />
          {errorExistForField('actualCost') && (
            <small className="text-danger">
              {errorsForField('actualCost')}
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
            errorExistForField('productID')
              ? 'col-sm-2 col-form-label is-invalid'
              : 'col-sm-2 col-form-label'
          }
        >
          ProductID
        </label>
        <div className="col-sm-12">
          <Field
            type="datetime-local"
            name="productID"
            className={
              errorExistForField('productID')
                ? 'form-control is-invalid'
                : 'form-control'
            }
          />
          {errorExistForField('productID') && (
            <small className="text-danger">{errorsForField('productID')}</small>
          )}
        </div>
      </div>

      <div className="form-group row">
        <label
          htmlFor="name"
          className={
            errorExistForField('quantity')
              ? 'col-sm-2 col-form-label is-invalid'
              : 'col-sm-2 col-form-label'
          }
        >
          Quantity
        </label>
        <div className="col-sm-12">
          <Field
            type="datetime-local"
            name="quantity"
            className={
              errorExistForField('quantity')
                ? 'form-control is-invalid'
                : 'form-control'
            }
          />
          {errorExistForField('quantity') && (
            <small className="text-danger">{errorsForField('quantity')}</small>
          )}
        </div>
      </div>

      <div className="form-group row">
        <label
          htmlFor="name"
          className={
            errorExistForField('referenceOrderID')
              ? 'col-sm-2 col-form-label is-invalid'
              : 'col-sm-2 col-form-label'
          }
        >
          ReferenceOrderID
        </label>
        <div className="col-sm-12">
          <Field
            type="datetime-local"
            name="referenceOrderID"
            className={
              errorExistForField('referenceOrderID')
                ? 'form-control is-invalid'
                : 'form-control'
            }
          />
          {errorExistForField('referenceOrderID') && (
            <small className="text-danger">
              {errorsForField('referenceOrderID')}
            </small>
          )}
        </div>
      </div>

      <div className="form-group row">
        <label
          htmlFor="name"
          className={
            errorExistForField('referenceOrderLineID')
              ? 'col-sm-2 col-form-label is-invalid'
              : 'col-sm-2 col-form-label'
          }
        >
          ReferenceOrderLineID
        </label>
        <div className="col-sm-12">
          <Field
            type="datetime-local"
            name="referenceOrderLineID"
            className={
              errorExistForField('referenceOrderLineID')
                ? 'form-control is-invalid'
                : 'form-control'
            }
          />
          {errorExistForField('referenceOrderLineID') && (
            <small className="text-danger">
              {errorsForField('referenceOrderLineID')}
            </small>
          )}
        </div>
      </div>

      <div className="form-group row">
        <label
          htmlFor="name"
          className={
            errorExistForField('transactionDate')
              ? 'col-sm-2 col-form-label is-invalid'
              : 'col-sm-2 col-form-label'
          }
        >
          TransactionDate
        </label>
        <div className="col-sm-12">
          <Field
            type="datetime-local"
            name="transactionDate"
            className={
              errorExistForField('transactionDate')
                ? 'form-control is-invalid'
                : 'form-control'
            }
          />
          {errorExistForField('transactionDate') && (
            <small className="text-danger">
              {errorsForField('transactionDate')}
            </small>
          )}
        </div>
      </div>

      <div className="form-group row">
        <label
          htmlFor="name"
          className={
            errorExistForField('transactionType')
              ? 'col-sm-2 col-form-label is-invalid'
              : 'col-sm-2 col-form-label'
          }
        >
          TransactionType
        </label>
        <div className="col-sm-12">
          <Field
            type="datetime-local"
            name="transactionType"
            className={
              errorExistForField('transactionType')
                ? 'form-control is-invalid'
                : 'form-control'
            }
          />
          {errorExistForField('transactionType') && (
            <small className="text-danger">
              {errorsForField('transactionType')}
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

const TransactionHistoryArchiveCreate = withFormik<
  Props,
  TransactionHistoryArchiveViewModel
>({
  mapPropsToValues: props => {
    let response = new TransactionHistoryArchiveViewModel();
    if (props.model != undefined) {
      response.setProperties(
        props.model!.actualCost,
        props.model!.modifiedDate,
        props.model!.productID,
        props.model!.quantity,
        props.model!.referenceOrderID,
        props.model!.referenceOrderLineID,
        props.model!.transactionDate,
        props.model!.transactionID,
        props.model!.transactionType
      );
    }
    return response;
  },

  validate: values => {
    let errors: FormikErrors<TransactionHistoryArchiveViewModel> = {};

    if (values.actualCost == 0) {
      errors.actualCost = 'Required';
    }
    if (values.modifiedDate == undefined) {
      errors.modifiedDate = 'Required';
    }
    if (values.productID == 0) {
      errors.productID = 'Required';
    }
    if (values.quantity == 0) {
      errors.quantity = 'Required';
    }
    if (values.referenceOrderID == 0) {
      errors.referenceOrderID = 'Required';
    }
    if (values.referenceOrderLineID == 0) {
      errors.referenceOrderLineID = 'Required';
    }
    if (values.transactionDate == undefined) {
      errors.transactionDate = 'Required';
    }
    if (values.transactionType == '') {
      errors.transactionType = 'Required';
    }

    return errors;
  },

  handleSubmit: (values, actions) => {
    actions.setStatus(undefined);
    let mapper = new TransactionHistoryArchiveMapper();

    axios
      .post(
        Constants.ApiEndpoint + ApiRoutes.TransactionHistoryArchives,
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
            Api.TransactionHistoryArchiveClientRequestModel
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
  displayName: 'TransactionHistoryArchiveCreate',
})(TransactionHistoryArchiveCreateDisplay);

interface TransactionHistoryArchiveCreateComponentProps {}

interface TransactionHistoryArchiveCreateComponentState {
  model?: TransactionHistoryArchiveViewModel;
  loading: boolean;
  loaded: boolean;
  errorOccurred: boolean;
  errorMessage: string;
}

export default class TransactionHistoryArchiveCreateComponent extends React.Component<
  TransactionHistoryArchiveCreateComponentProps,
  TransactionHistoryArchiveCreateComponentState
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
      return <TransactionHistoryArchiveCreate model={this.state.model} />;
    } else {
      return null;
    }
  }
}


/*<Codenesium>
    <Hash>eefd16fd88699302ba1d2b66f36239ba</Hash>
</Codenesium>*/