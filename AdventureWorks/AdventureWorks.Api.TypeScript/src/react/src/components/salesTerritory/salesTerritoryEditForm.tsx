import React, { Component } from 'react';
import axios from 'axios';
import * as Api from '../../api/models';
import { UpdateResponse } from '../../api/ApiObjects';
import Constants from '../../constants';
import { FormikProps, FormikErrors, Field, withFormik } from 'formik';
import SalesTerritoryViewModel from './salesTerritoryViewModel';
import SalesTerritoryMapper from './salesTerritoryMapper';

interface Props {
  model?: SalesTerritoryViewModel;
}

const SalesTerritoryEditDisplay = (
  props: FormikProps<SalesTerritoryViewModel>
) => {
  let status = props.status as UpdateResponse<
    Api.SalesTerritoryClientRequestModel
  >;

  let errorsForField = (name: string): string => {
    let response = '';
    if (
      props.touched[name as keyof SalesTerritoryViewModel] &&
      props.errors[name as keyof SalesTerritoryViewModel]
    ) {
      response += props.errors[name as keyof SalesTerritoryViewModel];
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
            errorExistForField('costLastYear')
              ? 'col-sm-2 col-form-label is-invalid'
              : 'col-sm-2 col-form-label'
          }
        >
          CostLastYear
        </label>
        <div className="col-sm-12">
          <Field
            type="datetime-local"
            name="costLastYear"
            className={
              errorExistForField('costLastYear')
                ? 'form-control is-invalid'
                : 'form-control'
            }
          />
          {errorExistForField('costLastYear') && (
            <small className="text-danger">
              {errorsForField('costLastYear')}
            </small>
          )}
        </div>
      </div>
      <div className="form-group row">
        <label
          htmlFor="name"
          className={
            errorExistForField('costYTD')
              ? 'col-sm-2 col-form-label is-invalid'
              : 'col-sm-2 col-form-label'
          }
        >
          CostYTD
        </label>
        <div className="col-sm-12">
          <Field
            type="datetime-local"
            name="costYTD"
            className={
              errorExistForField('costYTD')
                ? 'form-control is-invalid'
                : 'form-control'
            }
          />
          {errorExistForField('costYTD') && (
            <small className="text-danger">{errorsForField('costYTD')}</small>
          )}
        </div>
      </div>
      <div className="form-group row">
        <label
          htmlFor="name"
          className={
            errorExistForField('countryRegionCode')
              ? 'col-sm-2 col-form-label is-invalid'
              : 'col-sm-2 col-form-label'
          }
        >
          CountryRegionCode
        </label>
        <div className="col-sm-12">
          <Field
            type="datetime-local"
            name="countryRegionCode"
            className={
              errorExistForField('countryRegionCode')
                ? 'form-control is-invalid'
                : 'form-control'
            }
          />
          {errorExistForField('countryRegionCode') && (
            <small className="text-danger">
              {errorsForField('countryRegionCode')}
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

const SalesTerritoryUpdate = withFormik<Props, SalesTerritoryViewModel>({
  mapPropsToValues: props => {
    let response = new SalesTerritoryViewModel();
    response.setProperties(
      props.model!.costLastYear,
      props.model!.costYTD,
      props.model!.countryRegionCode,
      props.model!.modifiedDate,
      props.model!.name,
      props.model!.rowguid,
      props.model!.salesLastYear,
      props.model!.salesYTD,
      props.model!.territoryID
    );
    return response;
  },

  // Custom sync validation
  validate: values => {
    let errors: FormikErrors<SalesTerritoryViewModel> = {};

    if (values.costLastYear == 0) {
      errors.costLastYear = 'Required';
    }
    if (values.costYTD == 0) {
      errors.costYTD = 'Required';
    }
    if (values.countryRegionCode == '') {
      errors.countryRegionCode = 'Required';
    }
    if (values.modifiedDate == undefined) {
      errors.modifiedDate = 'Required';
    }
    if (values.name == '') {
      errors.name = 'Required';
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
    if (values.territoryID == 0) {
      errors.territoryID = 'Required';
    }

    return errors;
  },
  handleSubmit: (values, actions) => {
    actions.setStatus(undefined);

    let mapper = new SalesTerritoryMapper();

    axios
      .put(
        Constants.ApiUrl + 'salesterritories/' + values.territoryID,

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
            Api.SalesTerritoryClientRequestModel
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

  displayName: 'SalesTerritoryEdit',
})(SalesTerritoryEditDisplay);

interface IParams {
  territoryID: number;
}

interface IMatch {
  params: IParams;
}

interface SalesTerritoryEditComponentProps {
  match: IMatch;
}

interface SalesTerritoryEditComponentState {
  model?: SalesTerritoryViewModel;
  loading: boolean;
  loaded: boolean;
  errorOccurred: boolean;
  errorMessage: string;
}

export default class SalesTerritoryEditComponent extends React.Component<
  SalesTerritoryEditComponentProps,
  SalesTerritoryEditComponentState
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
          'salesterritories/' +
          this.props.match.params.territoryID,
        {
          headers: {
            'Content-Type': 'application/json',
          },
        }
      )
      .then(
        resp => {
          let response = resp.data as Api.SalesTerritoryClientResponseModel;

          console.log(response);

          let mapper = new SalesTerritoryMapper();

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
      return <SalesTerritoryUpdate model={this.state.model} />;
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
    <Hash>147a5ef3f46ca6563a02eb69c8f2105e</Hash>
</Codenesium>*/