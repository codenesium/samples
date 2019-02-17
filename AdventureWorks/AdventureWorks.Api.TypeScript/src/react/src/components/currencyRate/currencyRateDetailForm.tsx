import React, { Component } from 'react';
import axios from 'axios';
import * as Api from '../../api/models';
import { UpdateResponse } from '../../api/apiObjects';
import { Constants, ApiRoutes, ClientRoutes } from '../../constants';
import { FormikProps, FormikErrors, Field, withFormik } from 'formik';
import { LoadingForm } from '../../lib/components/loadingForm';
import { ErrorForm } from '../../lib/components/errorForm';
import CurrencyRateMapper from './currencyRateMapper';
import CurrencyRateViewModel from './currencyRateViewModel';

interface Props {
  history: any;
  model?: CurrencyRateViewModel;
}

const CurrencyRateDetailDisplay = (model: Props) => {
  return (
    <form role="form">
      <button
        className="btn btn-primary btn-sm align-middle float-right vertically-center"
        onClick={e => {
          model.history.push(
            ClientRoutes.CurrencyRates + '/edit/' + model.model!.currencyRateID
          );
        }}
      >
        <i className="fas fa-edit" />
      </button>
      <div className="form-group row">
        <label htmlFor="averageRate" className={'col-sm-2 col-form-label'}>
          AverageRate
        </label>
        <div className="col-sm-12">{String(model.model!.averageRate)}</div>
      </div>
      <div className="form-group row">
        <label htmlFor="currencyRateDate" className={'col-sm-2 col-form-label'}>
          CurrencyRateDate
        </label>
        <div className="col-sm-12">{String(model.model!.currencyRateDate)}</div>
      </div>
      <div className="form-group row">
        <label htmlFor="currencyRateID" className={'col-sm-2 col-form-label'}>
          CurrencyRateID
        </label>
        <div className="col-sm-12">{String(model.model!.currencyRateID)}</div>
      </div>
      <div className="form-group row">
        <label htmlFor="endOfDayRate" className={'col-sm-2 col-form-label'}>
          EndOfDayRate
        </label>
        <div className="col-sm-12">{String(model.model!.endOfDayRate)}</div>
      </div>
      <div className="form-group row">
        <label htmlFor="fromCurrencyCode" className={'col-sm-2 col-form-label'}>
          FromCurrencyCode
        </label>
        <div className="col-sm-12">
          {model.model!.fromCurrencyCodeNavigation!.toDisplay()}
        </div>
      </div>
      <div className="form-group row">
        <label htmlFor="modifiedDate" className={'col-sm-2 col-form-label'}>
          ModifiedDate
        </label>
        <div className="col-sm-12">{String(model.model!.modifiedDate)}</div>
      </div>
      <div className="form-group row">
        <label htmlFor="toCurrencyCode" className={'col-sm-2 col-form-label'}>
          ToCurrencyCode
        </label>
        <div className="col-sm-12">
          {model.model!.toCurrencyCodeNavigation!.toDisplay()}
        </div>
      </div>
    </form>
  );
};

interface IParams {
  currencyRateID: number;
}

interface IMatch {
  params: IParams;
}

interface CurrencyRateDetailComponentProps {
  match: IMatch;
  history: any;
}

interface CurrencyRateDetailComponentState {
  model?: CurrencyRateViewModel;
  loading: boolean;
  loaded: boolean;
  errorOccurred: boolean;
  errorMessage: string;
}

export default class CurrencyRateDetailComponent extends React.Component<
  CurrencyRateDetailComponentProps,
  CurrencyRateDetailComponentState
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
          ApiRoutes.CurrencyRates +
          '/' +
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

          let mapper = new CurrencyRateMapper();

          console.log(response);

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
      return (
        <CurrencyRateDetailDisplay
          history={this.props.history}
          model={this.state.model}
        />
      );
    } else {
      return null;
    }
  }
}


/*<Codenesium>
    <Hash>3dc32657d77d60a467678d231cac51dc</Hash>
</Codenesium>*/