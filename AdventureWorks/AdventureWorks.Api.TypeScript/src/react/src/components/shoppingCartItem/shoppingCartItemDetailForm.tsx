import React, { Component } from 'react';
import axios from 'axios';
import * as Api from '../../api/models';
import { UpdateResponse } from '../../api/ApiObjects';
import Constants from '../../constants';
import { FormikProps, FormikErrors, Field, withFormik } from 'formik';
import ShoppingCartItemMapper from './shoppingCartItemMapper';
import ShoppingCartItemViewModel from './shoppingCartItemViewModel';

interface Props {
  model?: ShoppingCartItemViewModel;
}

const ShoppingCartItemDetailDisplay = (model: Props) => {
  return (
    <form role="form">
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
        Constants.ApiUrl +
          'shoppingcartitems/' +
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
      return <div>loading</div>;
    } else if (this.state.loaded) {
      return <ShoppingCartItemDetailDisplay model={this.state.model} />;
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
    <Hash>68f2474d1248b78f4ca725cccdaa0649</Hash>
</Codenesium>*/