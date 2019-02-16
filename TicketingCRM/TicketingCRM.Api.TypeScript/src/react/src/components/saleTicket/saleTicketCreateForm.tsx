import React, { Component } from 'react';
import axios from 'axios';
import { CreateResponse } from '../../api/ApiObjects';
import { FormikProps, FormikErrors, Field, withFormik } from 'formik';
import * as Yup from 'yup';
import { LoadingForm } from '../../lib/components/loadingForm';
import { ErrorForm } from '../../lib/components/errorForm';
import * as Api from '../../api/models';
import { Constants, ApiRoutes, ClientRoutes } from '../../constants';
import SaleTicketMapper from './saleTicketMapper';
import SaleTicketViewModel from './saleTicketViewModel';

interface Props {
  model?: SaleTicketViewModel;
}

const SaleTicketCreateDisplay: React.SFC<FormikProps<SaleTicketViewModel>> = (
  props: FormikProps<SaleTicketViewModel>
) => {
  let status = props.status as CreateResponse<Api.SaleTicketClientRequestModel>;

  let errorsForField = (name: string): string => {
    let response = '';
    if (
      props.touched[name as keyof SaleTicketViewModel] &&
      props.errors[name as keyof SaleTicketViewModel]
    ) {
      response += props.errors[name as keyof SaleTicketViewModel];
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
            errorExistForField('saleId')
              ? 'col-sm-2 col-form-label is-invalid'
              : 'col-sm-2 col-form-label'
          }
        >
          SaleId
        </label>
        <div className="col-sm-12">
          <Field
            type="datetime-local"
            name="saleId"
            className={
              errorExistForField('saleId')
                ? 'form-control is-invalid'
                : 'form-control'
            }
          />
          {errorExistForField('saleId') && (
            <small className="text-danger">{errorsForField('saleId')}</small>
          )}
        </div>
      </div>

      <div className="form-group row">
        <label
          htmlFor="name"
          className={
            errorExistForField('ticketId')
              ? 'col-sm-2 col-form-label is-invalid'
              : 'col-sm-2 col-form-label'
          }
        >
          TicketId
        </label>
        <div className="col-sm-12">
          <Field
            type="datetime-local"
            name="ticketId"
            className={
              errorExistForField('ticketId')
                ? 'form-control is-invalid'
                : 'form-control'
            }
          />
          {errorExistForField('ticketId') && (
            <small className="text-danger">{errorsForField('ticketId')}</small>
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

const SaleTicketCreate = withFormik<Props, SaleTicketViewModel>({
  mapPropsToValues: props => {
    let response = new SaleTicketViewModel();
    if (props.model != undefined) {
      response.setProperties(
        props.model!.id,
        props.model!.saleId,
        props.model!.ticketId
      );
    }
    return response;
  },

  validate: values => {
    let errors: FormikErrors<SaleTicketViewModel> = {};

    if (values.saleId == 0) {
      errors.saleId = 'Required';
    }
    if (values.ticketId == 0) {
      errors.ticketId = 'Required';
    }

    return errors;
  },

  handleSubmit: (values, actions) => {
    actions.setStatus(undefined);
    let mapper = new SaleTicketMapper();

    axios
      .post(
        Constants.ApiEndpoint + ApiRoutes.SaleTickets,
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
            Api.SaleTicketClientRequestModel
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
  displayName: 'SaleTicketCreate',
})(SaleTicketCreateDisplay);

interface SaleTicketCreateComponentProps {}

interface SaleTicketCreateComponentState {
  model?: SaleTicketViewModel;
  loading: boolean;
  loaded: boolean;
  errorOccurred: boolean;
  errorMessage: string;
}

export default class SaleTicketCreateComponent extends React.Component<
  SaleTicketCreateComponentProps,
  SaleTicketCreateComponentState
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
      return <SaleTicketCreate model={this.state.model} />;
    } else {
      return null;
    }
  }
}


/*<Codenesium>
    <Hash>c7f5b3acf17a703b89cb3b5306affeb5</Hash>
</Codenesium>*/