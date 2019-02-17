import React, { Component } from 'react';
import axios from 'axios';
import { CreateResponse } from '../../api/apiObjects';
import { FormikProps, FormikErrors, Field, withFormik } from 'formik';
import * as Yup from 'yup';
import { LoadingForm } from '../../lib/components/loadingForm';
import { ErrorForm } from '../../lib/components/errorForm';
import * as Api from '../../api/models';
import { Constants, ApiRoutes, ClientRoutes } from '../../constants';
import SaleMapper from './saleMapper';
import SaleViewModel from './saleViewModel';

interface Props {
  model?: SaleViewModel;
}

const SaleCreateDisplay: React.SFC<FormikProps<SaleViewModel>> = (
  props: FormikProps<SaleViewModel>
) => {
  let status = props.status as CreateResponse<Api.SaleClientRequestModel>;

  let errorsForField = (name: string): string => {
    let response = '';
    if (
      props.touched[name as keyof SaleViewModel] &&
      props.errors[name as keyof SaleViewModel]
    ) {
      response += props.errors[name as keyof SaleViewModel];
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
            errorExistForField('ipAddress')
              ? 'col-sm-2 col-form-label is-invalid'
              : 'col-sm-2 col-form-label'
          }
        >
          IpAddress
        </label>
        <div className="col-sm-12">
          <Field
            type="textbox"
            name="ipAddress"
            className={
              errorExistForField('ipAddress')
                ? 'form-control is-invalid'
                : 'form-control'
            }
          />
          {errorExistForField('ipAddress') && (
            <small className="text-danger">{errorsForField('ipAddress')}</small>
          )}
        </div>
      </div>

      <div className="form-group row">
        <label
          htmlFor="name"
          className={
            errorExistForField('note')
              ? 'col-sm-2 col-form-label is-invalid'
              : 'col-sm-2 col-form-label'
          }
        >
          Notes
        </label>
        <div className="col-sm-12">
          <Field
            type="textbox"
            name="note"
            className={
              errorExistForField('note')
                ? 'form-control is-invalid'
                : 'form-control'
            }
          />
          {errorExistForField('note') && (
            <small className="text-danger">{errorsForField('note')}</small>
          )}
        </div>
      </div>

      <div className="form-group row">
        <label
          htmlFor="name"
          className={
            errorExistForField('saleDate')
              ? 'col-sm-2 col-form-label is-invalid'
              : 'col-sm-2 col-form-label'
          }
        >
          SaleDate
        </label>
        <div className="col-sm-12">
          <Field
            type="datetime-local"
            name="saleDate"
            className={
              errorExistForField('saleDate')
                ? 'form-control is-invalid'
                : 'form-control'
            }
          />
          {errorExistForField('saleDate') && (
            <small className="text-danger">{errorsForField('saleDate')}</small>
          )}
        </div>
      </div>

      <div className="form-group row">
        <label
          htmlFor="name"
          className={
            errorExistForField('transactionId')
              ? 'col-sm-2 col-form-label is-invalid'
              : 'col-sm-2 col-form-label'
          }
        >
          TransactionId
        </label>
        <div className="col-sm-12">
          <Field
            type="textbox"
            name="transactionId"
            className={
              errorExistForField('transactionId')
                ? 'form-control is-invalid'
                : 'form-control'
            }
          />
          {errorExistForField('transactionId') && (
            <small className="text-danger">
              {errorsForField('transactionId')}
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

const SaleCreate = withFormik<Props, SaleViewModel>({
  mapPropsToValues: props => {
    let response = new SaleViewModel();
    if (props.model != undefined) {
      response.setProperties(
        props.model!.id,
        props.model!.ipAddress,
        props.model!.note,
        props.model!.saleDate,
        props.model!.transactionId
      );
    }
    return response;
  },

  validate: values => {
    let errors: FormikErrors<SaleViewModel> = {};

    if (values.ipAddress == '') {
      errors.ipAddress = 'Required';
    }
    if (values.note == '') {
      errors.note = 'Required';
    }
    if (values.saleDate == undefined) {
      errors.saleDate = 'Required';
    }
    if (values.transactionId == 0) {
      errors.transactionId = 'Required';
    }

    return errors;
  },

  handleSubmit: (values, actions) => {
    actions.setStatus(undefined);
    let mapper = new SaleMapper();

    axios
      .post(
        Constants.ApiEndpoint + ApiRoutes.Sales,
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
            Api.SaleClientRequestModel
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
  displayName: 'SaleCreate',
})(SaleCreateDisplay);

interface SaleCreateComponentProps {}

interface SaleCreateComponentState {
  model?: SaleViewModel;
  loading: boolean;
  loaded: boolean;
  errorOccurred: boolean;
  errorMessage: string;
}

export default class SaleCreateComponent extends React.Component<
  SaleCreateComponentProps,
  SaleCreateComponentState
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
      return <SaleCreate model={this.state.model} />;
    } else {
      return null;
    }
  }
}


/*<Codenesium>
    <Hash>e0e09d1ad328d81a65d8c7485540155f</Hash>
</Codenesium>*/