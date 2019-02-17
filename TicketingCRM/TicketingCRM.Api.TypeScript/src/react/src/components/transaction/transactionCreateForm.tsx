import React, { Component } from 'react';
import axios from 'axios';
import { CreateResponse } from '../../api/apiObjects';
import { FormikProps, FormikErrors, Field, withFormik } from 'formik';
import * as Yup from 'yup';
import { LoadingForm } from '../../lib/components/loadingForm';
import { ErrorForm } from '../../lib/components/errorForm';
import * as Api from '../../api/models';
import { Constants, ApiRoutes, ClientRoutes } from '../../constants';
import TransactionMapper from './transactionMapper';
import TransactionViewModel from './transactionViewModel';

interface Props {
  model?: TransactionViewModel;
}

const TransactionCreateDisplay: React.SFC<FormikProps<TransactionViewModel>> = (
  props: FormikProps<TransactionViewModel>
) => {
  let status = props.status as CreateResponse<
    Api.TransactionClientRequestModel
  >;

  let errorsForField = (name: string): string => {
    let response = '';
    if (
      props.touched[name as keyof TransactionViewModel] &&
      props.errors[name as keyof TransactionViewModel]
    ) {
      response += props.errors[name as keyof TransactionViewModel];
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
            errorExistForField('amount')
              ? 'col-sm-2 col-form-label is-invalid'
              : 'col-sm-2 col-form-label'
          }
        >
          Amount
        </label>
        <div className="col-sm-12">
          <Field
            type="number"
            name="amount"
            className={
              errorExistForField('amount')
                ? 'form-control is-invalid'
                : 'form-control'
            }
          />
          {errorExistForField('amount') && (
            <small className="text-danger">{errorsForField('amount')}</small>
          )}
        </div>
      </div>

      <div className="form-group row">
        <label
          htmlFor="name"
          className={
            errorExistForField('gatewayConfirmationNumber')
              ? 'col-sm-2 col-form-label is-invalid'
              : 'col-sm-2 col-form-label'
          }
        >
          GatewayConfirmationNumber
        </label>
        <div className="col-sm-12">
          <Field
            type="textbox"
            name="gatewayConfirmationNumber"
            className={
              errorExistForField('gatewayConfirmationNumber')
                ? 'form-control is-invalid'
                : 'form-control'
            }
          />
          {errorExistForField('gatewayConfirmationNumber') && (
            <small className="text-danger">
              {errorsForField('gatewayConfirmationNumber')}
            </small>
          )}
        </div>
      </div>

      <div className="form-group row">
        <label
          htmlFor="name"
          className={
            errorExistForField('transactionStatusId')
              ? 'col-sm-2 col-form-label is-invalid'
              : 'col-sm-2 col-form-label'
          }
        >
          TransactionStatusId
        </label>
        <div className="col-sm-12">
          <Field
            type="textbox"
            name="transactionStatusId"
            className={
              errorExistForField('transactionStatusId')
                ? 'form-control is-invalid'
                : 'form-control'
            }
          />
          {errorExistForField('transactionStatusId') && (
            <small className="text-danger">
              {errorsForField('transactionStatusId')}
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

const TransactionCreate = withFormik<Props, TransactionViewModel>({
  mapPropsToValues: props => {
    let response = new TransactionViewModel();
    if (props.model != undefined) {
      response.setProperties(
        props.model!.amount,
        props.model!.gatewayConfirmationNumber,
        props.model!.id,
        props.model!.transactionStatusId
      );
    }
    return response;
  },

  validate: values => {
    let errors: FormikErrors<TransactionViewModel> = {};

    if (values.amount == 0) {
      errors.amount = 'Required';
    }
    if (values.gatewayConfirmationNumber == '') {
      errors.gatewayConfirmationNumber = 'Required';
    }
    if (values.transactionStatusId == 0) {
      errors.transactionStatusId = 'Required';
    }

    return errors;
  },

  handleSubmit: (values, actions) => {
    actions.setStatus(undefined);
    let mapper = new TransactionMapper();

    axios
      .post(
        Constants.ApiEndpoint + ApiRoutes.Transactions,
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
            Api.TransactionClientRequestModel
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
  displayName: 'TransactionCreate',
})(TransactionCreateDisplay);

interface TransactionCreateComponentProps {}

interface TransactionCreateComponentState {
  model?: TransactionViewModel;
  loading: boolean;
  loaded: boolean;
  errorOccurred: boolean;
  errorMessage: string;
}

export default class TransactionCreateComponent extends React.Component<
  TransactionCreateComponentProps,
  TransactionCreateComponentState
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
      return <TransactionCreate model={this.state.model} />;
    } else {
      return null;
    }
  }
}


/*<Codenesium>
    <Hash>b0f993fb0d541e018e848231045a30f7</Hash>
</Codenesium>*/