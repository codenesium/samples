import React, { Component } from 'react';
import axios from 'axios';
import * as Api from '../../api/models';
import { UpdateResponse } from '../../api/ApiObjects';
import Constants from '../../constants';
import { FormikProps, FormikErrors, Field, withFormik } from 'formik';
import CreditCardMapper from './creditCardMapper';
import CreditCardViewModel from './creditCardViewModel';

interface Props {
  model?: CreditCardViewModel;
}

const CreditCardDetailDisplay = (model: Props) => {
  return (
    <form role="form">
      <div className="form-group row">
        <label htmlFor="cardNumber" className={'col-sm-2 col-form-label'}>
          CardNumber
        </label>
        <div className="col-sm-12">{String(model.model!.cardNumber)}</div>
      </div>

      <div className="form-group row">
        <label htmlFor="cardType" className={'col-sm-2 col-form-label'}>
          CardType
        </label>
        <div className="col-sm-12">{String(model.model!.cardType)}</div>
      </div>

      <div className="form-group row">
        <label htmlFor="creditCardID" className={'col-sm-2 col-form-label'}>
          CreditCardID
        </label>
        <div className="col-sm-12">{String(model.model!.creditCardID)}</div>
      </div>

      <div className="form-group row">
        <label htmlFor="expMonth" className={'col-sm-2 col-form-label'}>
          ExpMonth
        </label>
        <div className="col-sm-12">{String(model.model!.expMonth)}</div>
      </div>

      <div className="form-group row">
        <label htmlFor="expYear" className={'col-sm-2 col-form-label'}>
          ExpYear
        </label>
        <div className="col-sm-12">{String(model.model!.expYear)}</div>
      </div>

      <div className="form-group row">
        <label htmlFor="modifiedDate" className={'col-sm-2 col-form-label'}>
          ModifiedDate
        </label>
        <div className="col-sm-12">{String(model.model!.modifiedDate)}</div>
      </div>
    </form>
  );
};

interface IParams {
  creditCardID: number;
}

interface IMatch {
  params: IParams;
}

interface CreditCardDetailComponentProps {
  match: IMatch;
}

interface CreditCardDetailComponentState {
  model?: CreditCardViewModel;
  loading: boolean;
  loaded: boolean;
  errorOccurred: boolean;
  errorMessage: string;
}

export default class CreditCardDetailComponent extends React.Component<
  CreditCardDetailComponentProps,
  CreditCardDetailComponentState
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
          'creditcards/' +
          this.props.match.params.creditCardID,
        {
          headers: {
            'Content-Type': 'application/json',
          },
        }
      )
      .then(
        resp => {
          let response = resp.data as Api.CreditCardClientResponseModel;

          let mapper = new CreditCardMapper();

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
      return <CreditCardDetailDisplay model={this.state.model} />;
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
    <Hash>707114eac627ca8e91e0b052898e3c72</Hash>
</Codenesium>*/