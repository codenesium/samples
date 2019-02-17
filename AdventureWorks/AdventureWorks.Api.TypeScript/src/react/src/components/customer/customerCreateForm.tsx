import React, { Component } from 'react';
import axios from 'axios';
import { CreateResponse } from '../../api/apiObjects';
import { FormikProps, FormikErrors, Field, withFormik } from 'formik';
import * as Yup from 'yup';
import { LoadingForm } from '../../lib/components/loadingForm';
import { ErrorForm } from '../../lib/components/errorForm';
import * as Api from '../../api/models';
import { Constants, ApiRoutes, ClientRoutes } from '../../constants';
import CustomerMapper from './customerMapper';
import CustomerViewModel from './customerViewModel';

interface Props {
  model?: CustomerViewModel;
}

const CustomerCreateDisplay: React.SFC<FormikProps<CustomerViewModel>> = (
  props: FormikProps<CustomerViewModel>
) => {
  let status = props.status as CreateResponse<Api.CustomerClientRequestModel>;

  let errorsForField = (name: string): string => {
    let response = '';
    if (
      props.touched[name as keyof CustomerViewModel] &&
      props.errors[name as keyof CustomerViewModel]
    ) {
      response += props.errors[name as keyof CustomerViewModel];
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
            errorExistForField('personID')
              ? 'col-sm-2 col-form-label is-invalid'
              : 'col-sm-2 col-form-label'
          }
        >
          PersonID
        </label>
        <div className="col-sm-12">
          <Field
            type="datetime-local"
            name="personID"
            className={
              errorExistForField('personID')
                ? 'form-control is-invalid'
                : 'form-control'
            }
          />
          {errorExistForField('personID') && (
            <small className="text-danger">{errorsForField('personID')}</small>
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
            errorExistForField('storeID')
              ? 'col-sm-2 col-form-label is-invalid'
              : 'col-sm-2 col-form-label'
          }
        >
          StoreID
        </label>
        <div className="col-sm-12">
          <Field
            type="datetime-local"
            name="storeID"
            className={
              errorExistForField('storeID')
                ? 'form-control is-invalid'
                : 'form-control'
            }
          />
          {errorExistForField('storeID') && (
            <small className="text-danger">{errorsForField('storeID')}</small>
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

const CustomerCreate = withFormik<Props, CustomerViewModel>({
  mapPropsToValues: props => {
    let response = new CustomerViewModel();
    if (props.model != undefined) {
      response.setProperties(
        props.model!.accountNumber,
        props.model!.customerID,
        props.model!.modifiedDate,
        props.model!.personID,
        props.model!.rowguid,
        props.model!.storeID,
        props.model!.territoryID
      );
    }
    return response;
  },

  validate: values => {
    let errors: FormikErrors<CustomerViewModel> = {};

    if (values.accountNumber == '') {
      errors.accountNumber = 'Required';
    }
    if (values.modifiedDate == undefined) {
      errors.modifiedDate = 'Required';
    }
    if (values.rowguid == undefined) {
      errors.rowguid = 'Required';
    }

    return errors;
  },

  handleSubmit: (values, actions) => {
    actions.setStatus(undefined);
    let mapper = new CustomerMapper();

    axios
      .post(
        Constants.ApiEndpoint + ApiRoutes.Customers,
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
            Api.CustomerClientRequestModel
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
  displayName: 'CustomerCreate',
})(CustomerCreateDisplay);

interface CustomerCreateComponentProps {}

interface CustomerCreateComponentState {
  model?: CustomerViewModel;
  loading: boolean;
  loaded: boolean;
  errorOccurred: boolean;
  errorMessage: string;
}

export default class CustomerCreateComponent extends React.Component<
  CustomerCreateComponentProps,
  CustomerCreateComponentState
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
      return <CustomerCreate model={this.state.model} />;
    } else {
      return null;
    }
  }
}


/*<Codenesium>
    <Hash>e989896dbaebca4a797f5e49cdfc2860</Hash>
</Codenesium>*/