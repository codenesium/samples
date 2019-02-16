import React, { Component } from 'react';
import axios from 'axios';
import * as Api from '../../api/models';
import { UpdateResponse } from '../../api/ApiObjects';
import { Constants, ApiRoutes, ClientRoutes } from '../../constants';
import { FormikProps, FormikErrors, Field, withFormik } from 'formik';
import { LoadingForm } from '../../lib/components/loadingForm';
import { ErrorForm } from '../../lib/components/errorForm';
import SaleViewModel from './saleViewModel';
import SaleMapper from './saleMapper';

interface Props {
  model?: SaleViewModel;
}

const SaleEditDisplay = (props: FormikProps<SaleViewModel>) => {
  let status = props.status as UpdateResponse<Api.SaleClientRequestModel>;

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
            errorExistForField('amount')
              ? 'col-sm-2 col-form-label is-invalid'
              : 'col-sm-2 col-form-label'
          }
        >
          Amount
        </label>
        <div className="col-sm-12">
          <Field
            type="textbox"
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
            errorExistForField('firstName')
              ? 'col-sm-2 col-form-label is-invalid'
              : 'col-sm-2 col-form-label'
          }
        >
          FirstName
        </label>
        <div className="col-sm-12">
          <Field
            type="textbox"
            name="firstName"
            className={
              errorExistForField('firstName')
                ? 'form-control is-invalid'
                : 'form-control'
            }
          />
          {errorExistForField('firstName') && (
            <small className="text-danger">{errorsForField('firstName')}</small>
          )}
        </div>
      </div>
      <div className="form-group row">
        <label
          htmlFor="name"
          className={
            errorExistForField('lastName')
              ? 'col-sm-2 col-form-label is-invalid'
              : 'col-sm-2 col-form-label'
          }
        >
          LastName
        </label>
        <div className="col-sm-12">
          <Field
            type="textbox"
            name="lastName"
            className={
              errorExistForField('lastName')
                ? 'form-control is-invalid'
                : 'form-control'
            }
          />
          {errorExistForField('lastName') && (
            <small className="text-danger">{errorsForField('lastName')}</small>
          )}
        </div>
      </div>
      <div className="form-group row">
        <label
          htmlFor="name"
          className={
            errorExistForField('paymentTypeId')
              ? 'col-sm-2 col-form-label is-invalid'
              : 'col-sm-2 col-form-label'
          }
        >
          PaymentTypeId
        </label>
        <div className="col-sm-12">
          <Field
            type="textbox"
            name="paymentTypeId"
            className={
              errorExistForField('paymentTypeId')
                ? 'form-control is-invalid'
                : 'form-control'
            }
          />
          {errorExistForField('paymentTypeId') && (
            <small className="text-danger">
              {errorsForField('paymentTypeId')}
            </small>
          )}
        </div>
      </div>
      <div className="form-group row">
        <label
          htmlFor="name"
          className={
            errorExistForField('petId')
              ? 'col-sm-2 col-form-label is-invalid'
              : 'col-sm-2 col-form-label'
          }
        >
          PetId
        </label>
        <div className="col-sm-12">
          <Field
            type="textbox"
            name="petId"
            className={
              errorExistForField('petId')
                ? 'form-control is-invalid'
                : 'form-control'
            }
          />
          {errorExistForField('petId') && (
            <small className="text-danger">{errorsForField('petId')}</small>
          )}
        </div>
      </div>
      <div className="form-group row">
        <label
          htmlFor="name"
          className={
            errorExistForField('phone')
              ? 'col-sm-2 col-form-label is-invalid'
              : 'col-sm-2 col-form-label'
          }
        >
          Phone
        </label>
        <div className="col-sm-12">
          <Field
            type="textbox"
            name="phone"
            className={
              errorExistForField('phone')
                ? 'form-control is-invalid'
                : 'form-control'
            }
          />
          {errorExistForField('phone') && (
            <small className="text-danger">{errorsForField('phone')}</small>
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

const SaleEdit = withFormik<Props, SaleViewModel>({
  mapPropsToValues: props => {
    let response = new SaleViewModel();
    response.setProperties(
      props.model!.amount,
      props.model!.firstName,
      props.model!.id,
      props.model!.lastName,
      props.model!.paymentTypeId,
      props.model!.petId,
      props.model!.phone
    );
    return response;
  },

  // Custom sync validation
  validate: values => {
    let errors: FormikErrors<SaleViewModel> = {};

    if (values.amount == 0) {
      errors.amount = 'Required';
    }
    if (values.firstName == '') {
      errors.firstName = 'Required';
    }
    if (values.id == 0) {
      errors.id = 'Required';
    }
    if (values.lastName == '') {
      errors.lastName = 'Required';
    }
    if (values.paymentTypeId == 0) {
      errors.paymentTypeId = 'Required';
    }
    if (values.petId == 0) {
      errors.petId = 'Required';
    }
    if (values.phone == '') {
      errors.phone = 'Required';
    }

    return errors;
  },
  handleSubmit: (values, actions) => {
    actions.setStatus(undefined);

    let mapper = new SaleMapper();

    axios
      .put(
        Constants.ApiEndpoint + ApiRoutes.Sales + '/' + values.id,

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
            Api.SaleClientRequestModel
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

  displayName: 'SaleEdit',
})(SaleEditDisplay);

interface IParams {
  id: number;
}

interface IMatch {
  params: IParams;
}

interface SaleEditComponentProps {
  match: IMatch;
}

interface SaleEditComponentState {
  model?: SaleViewModel;
  loading: boolean;
  loaded: boolean;
  errorOccurred: boolean;
  errorMessage: string;
}

export default class SaleEditComponent extends React.Component<
  SaleEditComponentProps,
  SaleEditComponentState
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
          ApiRoutes.Sales +
          '/' +
          this.props.match.params.id,
        {
          headers: {
            'Content-Type': 'application/json',
          },
        }
      )
      .then(
        resp => {
          let response = resp.data as Api.SaleClientResponseModel;

          console.log(response);

          let mapper = new SaleMapper();

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
      return <SaleEdit model={this.state.model} />;
    } else {
      return null;
    }
  }
}


/*<Codenesium>
    <Hash>b788e7721fecd28b2cb2761358a81a00</Hash>
</Codenesium>*/