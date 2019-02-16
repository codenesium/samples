import React, { Component } from 'react';
import axios from 'axios';
import * as Api from '../../api/models';
import { UpdateResponse } from '../../api/ApiObjects';
import Constants from '../../constants';
import { FormikProps, FormikErrors, Field, withFormik } from 'formik';
import TransactionHistoryArchiveMapper from './transactionHistoryArchiveMapper';
import TransactionHistoryArchiveViewModel from './transactionHistoryArchiveViewModel';

interface Props {
  model?: TransactionHistoryArchiveViewModel;
}

const TransactionHistoryArchiveDetailDisplay = (model: Props) => {
  return (
    <form role="form">
      <div className="form-group row">
        <label htmlFor="actualCost" className={'col-sm-2 col-form-label'}>
          ActualCost
        </label>
        <div className="col-sm-12">{String(model.model!.actualCost)}</div>
      </div>

      <div className="form-group row">
        <label htmlFor="modifiedDate" className={'col-sm-2 col-form-label'}>
          ModifiedDate
        </label>
        <div className="col-sm-12">{String(model.model!.modifiedDate)}</div>
      </div>

      <div className="form-group row">
        <label htmlFor="productID" className={'col-sm-2 col-form-label'}>
          ProductID
        </label>
        <div className="col-sm-12">{String(model.model!.productID)}</div>
      </div>

      <div className="form-group row">
        <label htmlFor="quantity" className={'col-sm-2 col-form-label'}>
          Quantity
        </label>
        <div className="col-sm-12">{String(model.model!.quantity)}</div>
      </div>

      <div className="form-group row">
        <label htmlFor="referenceOrderID" className={'col-sm-2 col-form-label'}>
          ReferenceOrderID
        </label>
        <div className="col-sm-12">{String(model.model!.referenceOrderID)}</div>
      </div>

      <div className="form-group row">
        <label
          htmlFor="referenceOrderLineID"
          className={'col-sm-2 col-form-label'}
        >
          ReferenceOrderLineID
        </label>
        <div className="col-sm-12">
          {String(model.model!.referenceOrderLineID)}
        </div>
      </div>

      <div className="form-group row">
        <label htmlFor="transactionDate" className={'col-sm-2 col-form-label'}>
          TransactionDate
        </label>
        <div className="col-sm-12">{String(model.model!.transactionDate)}</div>
      </div>

      <div className="form-group row">
        <label htmlFor="transactionID" className={'col-sm-2 col-form-label'}>
          TransactionID
        </label>
        <div className="col-sm-12">{String(model.model!.transactionID)}</div>
      </div>

      <div className="form-group row">
        <label htmlFor="transactionType" className={'col-sm-2 col-form-label'}>
          TransactionType
        </label>
        <div className="col-sm-12">{String(model.model!.transactionType)}</div>
      </div>
    </form>
  );
};

interface IParams {
  transactionID: number;
}

interface IMatch {
  params: IParams;
}

interface TransactionHistoryArchiveDetailComponentProps {
  match: IMatch;
}

interface TransactionHistoryArchiveDetailComponentState {
  model?: TransactionHistoryArchiveViewModel;
  loading: boolean;
  loaded: boolean;
  errorOccurred: boolean;
  errorMessage: string;
}

export default class TransactionHistoryArchiveDetailComponent extends React.Component<
  TransactionHistoryArchiveDetailComponentProps,
  TransactionHistoryArchiveDetailComponentState
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
          'transactionhistoryarchives/' +
          this.props.match.params.transactionID,
        {
          headers: {
            'Content-Type': 'application/json',
          },
        }
      )
      .then(
        resp => {
          let response = resp.data as Api.TransactionHistoryArchiveClientResponseModel;

          let mapper = new TransactionHistoryArchiveMapper();

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
      return (
        <TransactionHistoryArchiveDetailDisplay model={this.state.model} />
      );
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
    <Hash>7e435cb189c43ffbc2ca130692252a26</Hash>
</Codenesium>*/