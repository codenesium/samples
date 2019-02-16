import React, { Component } from 'react';
import axios from 'axios';
import * as Api from '../../api/models';
import { UpdateResponse } from '../../api/ApiObjects';
import Constants from '../../constants';
import { FormikProps, FormikErrors, Field, withFormik } from 'formik';
import CurrencyRateMapper from './currencyRateMapper';
import CurrencyRateViewModel from './currencyRateViewModel';

interface Props {
  model?: CurrencyRateViewModel;
}

const CurrencyRateDetailDisplay = (model: Props) => {
  return (
    <form role="form">
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
        <div className="col-sm-12">{String(model.model!.fromCurrencyCode)}</div>
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
        <div className="col-sm-12">{String(model.model!.toCurrencyCode)}</div>
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
      return <div>loading</div>;
    } else if (this.state.loaded) {
      return <CurrencyRateDetailDisplay model={this.state.model} />;
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
    <Hash>b554278d73143bb54794b12270373a1f</Hash>
</Codenesium>*/