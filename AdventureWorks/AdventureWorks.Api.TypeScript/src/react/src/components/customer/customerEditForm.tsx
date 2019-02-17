import React, { Component } from 'react';
import axios from 'axios';
import * as Api from '../../api/models';
import { UpdateResponse } from '../../api/apiObjects';
import { Constants, ApiRoutes, ClientRoutes } from '../../constants';
import { FormikProps, FormikErrors, Field, withFormik } from 'formik';
import { LoadingForm } from '../../lib/components/loadingForm';
import { ErrorForm } from '../../lib/components/errorForm';
import CustomerViewModel from './customerViewModel';
import CustomerMapper from './customerMapper';

interface Props {
  model?: CustomerViewModel;
}

const CustomerEditDisplay = (props: FormikProps<CustomerViewModel>) => {
  let status = props.status as UpdateResponse<Api.CustomerClientRequestModel>;

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
            errorExistForField('customerID')
              ? 'col-sm-2 col-form-label is-invalid'
              : 'col-sm-2 col-form-label'
          }
        >
          CustomerID
        </label>
        <div className="col-sm-12">
          <Field
            type="datetime-local"
            name="customerID"
            className={
              errorExistForField('customerID')
                ? 'form-control is-invalid'
                : 'form-control'
            }
          />
          {errorExistForField('customerID') && (
            <small className="text-danger">
              {errorsForField('customerID')}
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

const CustomerEdit = withFormik<Props, CustomerViewModel>({
  mapPropsToValues: props => {
    let response = new CustomerViewModel();
    response.setProperties(
      props.model!.accountNumber,
      props.model!.customerID,
      props.model!.modifiedDate,
      props.model!.personID,
      props.model!.rowguid,
      props.model!.storeID,
      props.model!.territoryID
    );
    return response;
  },

  // Custom sync validation
  validate: values => {
    let errors: FormikErrors<CustomerViewModel> = {};

    if (values.accountNumber == '') {
      errors.accountNumber = 'Required';
    }
    if (values.customerID == 0) {
      errors.customerID = 'Required';
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
      .put(
        Constants.ApiEndpoint + ApiRoutes.Customers + '/' + values.customerID,

        mapper.mapViewModelToApiRequest(values),
        {
          headers: {
            'Content-Type': 'application/json',
          },
        }
      )
      .then(
        resp => {
          let response = resp.data as UpdateResponse<
            Api.CustomerClientRequestModel
          >;
          actions.setStatus(response);
          console.log(response);
        },
        error => {
          console.log(error);
          actions.setStatus('Error from API');
        }
      )
      .then(response => {
        // cleanup
      });
  },

  displayName: 'CustomerEdit',
})(CustomerEditDisplay);

interface IParams {
  customerID: number;
}

interface IMatch {
  params: IParams;
}

interface CustomerEditComponentProps {
  match: IMatch;
}

interface CustomerEditComponentState {
  model?: CustomerViewModel;
  loading: boolean;
  loaded: boolean;
  errorOccurred: boolean;
  errorMessage: string;
}

export default class CustomerEditComponent extends React.Component<
  CustomerEditComponentProps,
  CustomerEditComponentState
> {
  state = {
    model: undefined,
    loading: false,
    loaded: false,
    errorOccurred: false,
    errorMessage: '',
  };

  componentDidMount() {
    this.setState({ ...this.state, loading: true });

    axios
      .get(
        Constants.ApiEndpoint +
          ApiRoutes.Customers +
          '/' +
          this.props.match.params.customerID,
        {
          headers: {
            'Content-Type': 'application/json',
          },
        }
      )
      .then(
        resp => {
          let response = resp.data as Api.CustomerClientResponseModel;

          console.log(response);

          let mapper = new CustomerMapper();

          this.setState({
            model: mapper.mapApiResponseToViewModel(response),
            loading: false,
            loaded: true,
            errorOccurred: false,
            errorMessage: '',
          });
        },
        error => {
          console.log(error);
          this.setState({
            model: undefined,
            loading: false,
            loaded: false,
            errorOccurred: true,
            errorMessage: 'Error from API',
          });
        }
      );
  }
  render() {
    if (this.state.loading) {
      return <LoadingForm />;
    } else if (this.state.errorOccurred) {
      return <ErrorForm message={this.state.errorMessage} />;
    } else if (this.state.loaded) {
      return <CustomerEdit model={this.state.model} />;
    } else {
      return null;
    }
  }
}


/*<Codenesium>
    <Hash>d203caa2246ad2281f11bbc661cc7b80</Hash>
</Codenesium>*/