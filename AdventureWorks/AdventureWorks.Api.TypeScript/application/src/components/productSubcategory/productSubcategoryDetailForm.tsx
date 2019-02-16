import React, { Component } from 'react';
import axios from 'axios';
import * as Api from '../../api/models';
import { UpdateResponse } from '../../api/ApiObjects';
import Constants from '../../constants';
import { FormikProps, FormikErrors, Field, withFormik } from 'formik';
import ProductSubcategoryMapper from './productSubcategoryMapper';
import ProductSubcategoryViewModel from './productSubcategoryViewModel';

interface Props {
  model?: ProductSubcategoryViewModel;
}

const ProductSubcategoryDetailDisplay = (model: Props) => {
  return (
    <form role="form">
      <div className="form-group row">
        <label htmlFor="modifiedDate" className={'col-sm-2 col-form-label'}>
          ModifiedDate
        </label>
        <div className="col-sm-12">{String(model.model!.modifiedDate)}</div>
      </div>

      <div className="form-group row">
        <label htmlFor="name" className={'col-sm-2 col-form-label'}>
          Name
        </label>
        <div className="col-sm-12">{String(model.model!.name)}</div>
      </div>

      <div className="form-group row">
        <label
          htmlFor="productCategoryID"
          className={'col-sm-2 col-form-label'}
        >
          ProductCategoryID
        </label>
        <div className="col-sm-12">
          {String(model.model!.productCategoryID)}
        </div>
      </div>

      <div className="form-group row">
        <label
          htmlFor="productSubcategoryID"
          className={'col-sm-2 col-form-label'}
        >
          ProductSubcategoryID
        </label>
        <div className="col-sm-12">
          {String(model.model!.productSubcategoryID)}
        </div>
      </div>

      <div className="form-group row">
        <label htmlFor="rowguid" className={'col-sm-2 col-form-label'}>
          Rowguid
        </label>
        <div className="col-sm-12">{String(model.model!.rowguid)}</div>
      </div>
    </form>
  );
};

interface IParams {
  productSubcategoryID: number;
}

interface IMatch {
  params: IParams;
}

interface ProductSubcategoryDetailComponentProps {
  match: IMatch;
}

interface ProductSubcategoryDetailComponentState {
  model?: ProductSubcategoryViewModel;
  loading: boolean;
  loaded: boolean;
  errorOccurred: boolean;
  errorMessage: string;
}

export default class ProductSubcategoryDetailComponent extends React.Component<
  ProductSubcategoryDetailComponentProps,
  ProductSubcategoryDetailComponentState
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
          'productsubcategories/' +
          this.props.match.params.productSubcategoryID,
        {
          headers: {
            'Content-Type': 'application/json',
          },
        }
      )
      .then(
        resp => {
          let response = resp.data as Api.ProductSubcategoryClientResponseModel;

          let mapper = new ProductSubcategoryMapper();

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
      return <ProductSubcategoryDetailDisplay model={this.state.model} />;
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
    <Hash>7e1db596c8abf0b228f924af59547197</Hash>
</Codenesium>*/