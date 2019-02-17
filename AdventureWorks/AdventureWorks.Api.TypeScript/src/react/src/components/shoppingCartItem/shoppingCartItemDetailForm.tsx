import React, { Component } from 'react';
import axios from 'axios';
import * as Api from '../../api/models';
import { UpdateResponse } from '../../api/apiObjects';
import { Constants, ApiRoutes, ClientRoutes } from '../../constants';
import { FormikProps, FormikErrors, Field, withFormik } from 'formik';
import { LoadingForm } from '../../lib/components/loadingForm';
import { ErrorForm } from '../../lib/components/errorForm';
import ShoppingCartItemMapper from './shoppingCartItemMapper';
import ShoppingCartItemViewModel from './shoppingCartItemViewModel';

interface Props {
  history: any;
  model?: ShoppingCartItemViewModel;
}

const ShoppingCartItemDetailDisplay = (model: Props) => {
  return (
    <form role="form">
      <button
        className="btn btn-primary btn-sm align-middle float-right vertically-center"
        onClick={e => {
          model.history.push(
            ClientRoutes.ShoppingCartItems +
              '/edit/' +
              model.model!.shoppingCartItemID
          );
        }}
      >
        <i className="fas fa-edit" />
      </button>
      <div className="form-group row">
        <label htmlFor="dateCreated" className={'col-sm-2 col-form-label'}>
          DateCreated
        </label>
        <div className="col-sm-12">{String(model.model!.dateCreated)}</div>
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
        <label htmlFor="shoppingCartID" className={'col-sm-2 col-form-label'}>
          ShoppingCartID
        </label>
        <div className="col-sm-12">{String(model.model!.shoppingCartID)}</div>
      </div>
      <div className="form-group row">
        <label
          htmlFor="shoppingCartItemID"
          className={'col-sm-2 col-form-label'}
        >
          ShoppingCartItemID
        </label>
        <div className="col-sm-12">
          {String(model.model!.shoppingCartItemID)}
        </div>
      </div>
    </form>
  );
};

interface IParams {
  shoppingCartItemID: number;
}

interface IMatch {
  params: IParams;
}

interface ShoppingCartItemDetailComponentProps {
  match: IMatch;
  history: any;
}

interface ShoppingCartItemDetailComponentState {
  model?: ShoppingCartItemViewModel;
  loading: boolean;
  loaded: boolean;
  errorOccurred: boolean;
  errorMessage: string;
}

export default class ShoppingCartItemDetailComponent extends React.Component<
  ShoppingCartItemDetailComponentProps,
  ShoppingCartItemDetailComponentState
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
          ApiRoutes.ShoppingCartItems +
          '/' +
          this.props.match.params.shoppingCartItemID,
        {
          headers: {
            'Content-Type': 'application/json',
          },
        }
      )
      .then(
        resp => {
          let response = resp.data as Api.ShoppingCartItemClientResponseModel;

          let mapper = new ShoppingCartItemMapper();

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
        <ShoppingCartItemDetailDisplay
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
    <Hash>a0431c45450c2db65725aeba38a02259</Hash>
</Codenesium>*/