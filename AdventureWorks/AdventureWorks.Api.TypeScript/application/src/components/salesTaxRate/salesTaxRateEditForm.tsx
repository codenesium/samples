import React, { Component } from 'react';
import axios from 'axios';
import * as Api from '../../api/models';
import { UpdateResponse } from '../../api/ApiObjects';
import Constants from '../../constants';
import { FormikProps, FormikErrors, Field, withFormik } from 'formik';
import SalesTaxRateViewModel from './salesTaxRateViewModel';
import SalesTaxRateMapper from './salesTaxRateMapper';

interface Props {
  model?: SalesTaxRateViewModel;
}

const SalesTaxRateEditDisplay = (props: FormikProps<SalesTaxRateViewModel>) => {
  let status = props.status as UpdateResponse<
    Api.SalesTaxRateClientRequestModel
  >;

  let errorsForField = (name: string): string => {
    let response = '';
    if (
      props.touched[name as keyof SalesTaxRateViewModel] &&
      props.errors[name as keyof SalesTaxRateViewModel]
    ) {
      response += props.errors[name as keyof SalesTaxRateViewModel];
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
            errorExistForField('salesTaxRateID')
              ? 'col-sm-2 col-form-label is-invalid'
              : 'col-sm-2 col-form-label'
          }
        >
          SalesTaxRateID
        </label>
        <div className="col-sm-12">
          <Field
            type="datetime-local"
            name="salesTaxRateID"
            className={
              errorExistForField('salesTaxRateID')
                ? 'form-control is-invalid'
                : 'form-control'
            }
          />
          {errorExistForField('salesTaxRateID') && (
            <small className="text-danger">
              {errorsForField('salesTaxRateID')}
            </small>
          )}
        </div>
      </div>
      <div className="form-group row">
        <label
          htmlFor="name"
          className={
            errorExistForField('stateProvinceID')
              ? 'col-sm-2 col-form-label is-invalid'
              : 'col-sm-2 col-form-label'
          }
        >
          StateProvinceID
        </label>
        <div className="col-sm-12">
          <Field
            type="datetime-local"
            name="stateProvinceID"
            className={
              errorExistForField('stateProvinceID')
                ? 'form-control is-invalid'
                : 'form-control'
            }
          />
          {errorExistForField('stateProvinceID') && (
            <small className="text-danger">
              {errorsForField('stateProvinceID')}
            </small>
          )}
        </div>
      </div>
      <div className="form-group row">
        <label
          htmlFor="name"
          className={
            errorExistForField('taxRate')
              ? 'col-sm-2 col-form-label is-invalid'
              : 'col-sm-2 col-form-label'
          }
        >
          TaxRate
        </label>
        <div className="col-sm-12">
          <Field
            type="datetime-local"
            name="taxRate"
            className={
              errorExistForField('taxRate')
                ? 'form-control is-invalid'
                : 'form-control'
            }
          />
          {errorExistForField('taxRate') && (
            <small className="text-danger">{errorsForField('taxRate')}</small>
          )}
        </div>
      </div>
      <div className="form-group row">
        <label
          htmlFor="name"
          className={
            errorExistForField('taxType')
              ? 'col-sm-2 col-form-label is-invalid'
              : 'col-sm-2 col-form-label'
          }
        >
          TaxType
        </label>
        <div className="col-sm-12">
          <Field
            type="datetime-local"
            name="taxType"
            className={
              errorExistForField('taxType')
                ? 'form-control is-invalid'
                : 'form-control'
            }
          />
          {errorExistForField('taxType') && (
            <small className="text-danger">{errorsForField('taxType')}</small>
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

const SalesTaxRateUpdate = withFormik<Props, SalesTaxRateViewModel>({
  mapPropsToValues: props => {
    let response = new SalesTaxRateViewModel();
    response.setProperties(
      props.model!.modifiedDate,
      props.model!.name,
      props.model!.rowguid,
      props.model!.salesTaxRateID,
      props.model!.stateProvinceID,
      props.model!.taxRate,
      props.model!.taxType
    );
    return response;
  },

  // Custom sync validation
  validate: values => {
    let errors: FormikErrors<SalesTaxRateViewModel> = {};

    if (values.modifiedDate == undefined) {
      errors.modifiedDate = 'Required';
    }
    if (values.name == '') {
      errors.name = 'Required';
    }
    if (values.rowguid == undefined) {
      errors.rowguid = 'Required';
    }
    if (values.salesTaxRateID == 0) {
      errors.salesTaxRateID = 'Required';
    }
    if (values.stateProvinceID == 0) {
      errors.stateProvinceID = 'Required';
    }
    if (values.taxRate == 0) {
      errors.taxRate = 'Required';
    }
    if (values.taxType == 0) {
      errors.taxType = 'Required';
    }

    return errors;
  },
  handleSubmit: (values, actions) => {
    actions.setStatus(undefined);

    let mapper = new SalesTaxRateMapper();

    axios
      .put(
        Constants.ApiUrl + 'salestaxrates/' + values.salesTaxRateID,

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
            Api.SalesTaxRateClientRequestModel
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

  displayName: 'SalesTaxRateEdit',
})(SalesTaxRateEditDisplay);

interface IParams {
  salesTaxRateID: number;
}

interface IMatch {
  params: IParams;
}

interface SalesTaxRateEditComponentProps {
  match: IMatch;
}

interface SalesTaxRateEditComponentState {
  model?: SalesTaxRateViewModel;
  loading: boolean;
  loaded: boolean;
  errorOccurred: boolean;
  errorMessage: string;
}

export default class SalesTaxRateEditComponent extends React.Component<
  SalesTaxRateEditComponentProps,
  SalesTaxRateEditComponentState
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
        Constants.ApiUrl +
          'salestaxrates/' +
          this.props.match.params.salesTaxRateID,
        {
          headers: {
            'Content-Type': 'application/json',
          },
        }
      )
      .then(
        resp => {
          let response = resp.data as Api.SalesTaxRateClientResponseModel;

          console.log(response);

          let mapper = new SalesTaxRateMapper();

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
      return <div>loading</div>;
    } else if (this.state.loaded) {
      return <SalesTaxRateUpdate model={this.state.model} />;
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
    <Hash>8a299c5a176c1cd8a473fa98ee32beb3</Hash>
</Codenesium>*/