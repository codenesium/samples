import React, { Component } from 'react';
import axios from 'axios';
import * as Api from '../../api/models';
import { UpdateResponse } from '../../api/apiObjects';
import { Constants, ApiRoutes, ClientRoutes } from '../../constants';
import { FormikProps, FormikErrors, Field, withFormik } from 'formik';
import { LoadingForm } from '../../lib/components/loadingForm';
import { ErrorForm } from '../../lib/components/errorForm';
import TransactionHistoryArchiveMapper from './transactionHistoryArchiveMapper';
import TransactionHistoryArchiveViewModel from './transactionHistoryArchiveViewModel';

interface Props {
  history: any;
  model?: TransactionHistoryArchiveViewModel;
}

const TransactionHistoryArchiveDetailDisplay = (model: Props) => {
  return (
    <form role="form">
      <button
        className="btn btn-primary btn-sm align-middle float-right vertically-center"
        onClick={e => {
          model.history.push(
            ClientRoutes.TransactionHistoryArchives +
              '/edit/' +
              model.model!.transactionID
          );
        }}
      >
        <i className="fas fa-edit" />
      </button>
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
  history: any;
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
        Constants.ApiEndpoint +
          ApiRoutes.TransactionHistoryArchives +
          '/' +
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
      return <LoadingForm />;
    } else if (this.state.errorOccurred) {
      return <ErrorForm message={this.state.errorMessage} />;
    } else if (this.state.loaded) {
      return (
        <TransactionHistoryArchiveDetailDisplay
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
    <Hash>d48f2902f37008a8c6b60b8766a0bc57</Hash>
</Codenesium>*/