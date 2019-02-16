import React, { Component } from 'react';
import axios from 'axios';
import * as Api from '../../api/models';
import { UpdateResponse } from '../../api/ApiObjects';
import Constants from '../../constants';
import { FormikProps, FormikErrors, Field, withFormik } from 'formik';
import CurrencyRateViewModel from './currencyRateViewModel';
import CurrencyRateMapper from './currencyRateMapper';

interface Props {
  model?: CurrencyRateViewModel;
}

const CurrencyRateEditDisplay = (props: FormikProps<CurrencyRateViewModel>) => {
  let status = props.status as UpdateResponse<
    Api.CurrencyRateClientRequestModel
  >;

  let errorsForField = (name: string): string => {
    let response = '';
    if (
      props.touched[name as keyof CurrencyRateViewModel] &&
      props.errors[name as keyof CurrencyRateViewModel]
    ) {
      response += props.errors[name as keyof CurrencyRateViewModel];
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
            errorExistForField('averageRate')
              ? 'col-sm-2 col-form-label is-invalid'
              : 'col-sm-2 col-form-label'
          }
        >
          AverageRate
        </label>
        <div className="col-sm-12">
          <Field
            type="datetime-local"
            name="averageRate"
            className={
              errorExistForField('averageRate')
                ? 'form-control is-invalid'
                : 'form-control'
            }
          />
          {errorExistForField('averageRate') && (
            <small className="text-danger">
              {errorsForField('averageRate')}
            </small>
          )}
        </div>
      </div>
      <div className="form-group row">
        <label
          htmlFor="name"
          className={
            errorExistForField('currencyRateDate')
              ? 'col-sm-2 col-form-label is-invalid'
              : 'col-sm-2 col-form-label'
          }
        >
          CurrencyRateDate
        </label>
        <div className="col-sm-12">
          <Field
            type="datetime-local"
            name="currencyRateDate"
            className={
              errorExistForField('currencyRateDate')
                ? 'form-control is-invalid'
                : 'form-control'
            }
          />
          {errorExistForField('currencyRateDate') && (
            <small className="text-danger">
              {errorsForField('currencyRateDate')}
            </small>
          )}
        </div>
      </div>
      <div className="form-group row">
        <label
          htmlFor="name"
          className={
            errorExistForField('currencyRateID')
              ? 'col-sm-2 col-form-label is-invalid'
              : 'col-sm-2 col-form-label'
          }
        >
          CurrencyRateID
        </label>
        <div className="col-sm-12">
          <Field
            type="datetime-local"
            name="currencyRateID"
            className={
              errorExistForField('currencyRateID')
                ? 'form-control is-invalid'
                : 'form-control'
            }
          />
          {errorExistForField('currencyRateID') && (
            <small className="text-danger">
              {errorsForField('currencyRateID')}
            </small>
          )}
        </div>
      </div>
      <div className="form-group row">
        <label
          htmlFor="name"
          className={
            errorExistForField('endOfDayRate')
              ? 'col-sm-2 col-form-label is-invalid'
              : 'col-sm-2 col-form-label'
          }
        >
          EndOfDayRate
        </label>
        <div className="col-sm-12">
          <Field
            type="datetime-local"
            name="endOfDayRate"
            className={
              errorExistForField('endOfDayRate')
                ? 'form-control is-invalid'
                : 'form-control'
            }
          />
          {errorExistForField('endOfDayRate') && (
            <small className="text-danger">
              {errorsForField('endOfDayRate')}
            </small>
          )}
        </div>
      </div>
      <div className="form-group row">
        <label
          htmlFor="name"
          className={
            errorExistForField('fromCurrencyCode')
              ? 'col-sm-2 col-form-label is-invalid'
              : 'col-sm-2 col-form-label'
          }
        >
          FromCurrencyCode
        </label>
        <div className="col-sm-12">
          <Field
            type="datetime-local"
            name="fromCurrencyCode"
            className={
              errorExistForField('fromCurrencyCode')
                ? 'form-control is-invalid'
                : 'form-control'
            }
          />
          {errorExistForField('fromCurrencyCode') && (
            <small className="text-danger">
              {errorsForField('fromCurrencyCode')}
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
            errorExistForField('toCurrencyCode')
              ? 'col-sm-2 col-form-label is-invalid'
              : 'col-sm-2 col-form-label'
          }
        >
          ToCurrencyCode
        </label>
        <div className="col-sm-12">
          <Field
            type="datetime-local"
            name="toCurrencyCode"
            className={
              errorExistForField('toCurrencyCode')
                ? 'form-control is-invalid'
                : 'form-control'
            }
          />
          {errorExistForField('toCurrencyCode') && (
            <small className="text-danger">
              {errorsForField('toCurrencyCode')}
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

const CurrencyRateUpdate = withFormik<Props, CurrencyRateViewModel>({
  mapPropsToValues: props => {
    let response = new CurrencyRateViewModel();
    response.setProperties(
      props.model!.averageRate,
      props.model!.currencyRateDate,
      props.model!.currencyRateID,
      props.model!.endOfDayRate,
      props.model!.fromCurrencyCode,
      props.model!.modifiedDate,
      props.model!.toCurrencyCode
    );
    return response;
  },

  // Custom sync validation
  validate: values => {
    let errors: FormikErrors<CurrencyRateViewModel> = {};

    if (values.averageRate == 0) {
      errors.averageRate = 'Required';
    }
    if (values.currencyRateDate == undefined) {
      errors.currencyRateDate = 'Required';
    }
    if (values.currencyRateID == 0) {
      errors.currencyRateID = 'Required';
    }
    if (values.endOfDayRate == 0) {
      errors.endOfDayRate = 'Required';
    }
    if (values.fromCurrencyCode == '') {
      errors.fromCurrencyCode = 'Required';
    }
    if (values.modifiedDate == undefined) {
      errors.modifiedDate = 'Required';
    }
    if (values.toCurrencyCode == '') {
      errors.toCurrencyCode = 'Required';
    }

    return errors;
  },
  handleSubmit: (values, actions) => {
    actions.setStatus(undefined);

    let mapper = new CurrencyRateMapper();

    axios
      .put(
        Constants.ApiUrl + 'currencyrates/' + values.currencyRateID,

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
            Api.CurrencyRateClientRequestModel
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

  displayName: 'CurrencyRateEdit',
})(CurrencyRateEditDisplay);

interface IParams {
  currencyRateID: number;
}

interface IMatch {
  params: IParams;
}

interface CurrencyRateEditComponentProps {
  match: IMatch;
}

interface CurrencyRateEditComponentState {
  model?: CurrencyRateViewModel;
  loading: boolean;
  loaded: boolean;
  errorOccurred: boolean;
  errorMessage: string;
}

export default class CurrencyRateEditComponent extends React.Component<
  CurrencyRateEditComponentProps,
  CurrencyRateEditComponentState
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
          'currencyrates/' +
          this.props.match.params.currencyRateID,
        {
          headers: {
            'Content-Type': 'application/json',
          },
        }
      )
      .then(
        resp => {
          let response = resp.data as Api.CurrencyRateClientResponseModel;

          console.log(response);

          let mapper = new CurrencyRateMapper();

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
      return <CurrencyRateUpdate model={this.state.model} />;
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
    <Hash>b37991c37f34e782a1312b6e66acdde0</Hash>
</Codenesium>*/