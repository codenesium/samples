import React, { Component } from 'react';
import axios from 'axios';
import * as Api from '../../api/models';
import { UpdateResponse } from '../../api/ApiObjects';
import Constants from '../../constants';
import { FormikProps, FormikErrors, Field, withFormik } from 'formik';
import ProductModelMapper from './productModelMapper';
import ProductModelViewModel from './productModelViewModel';

interface Props {
  model?: ProductModelViewModel;
}

const ProductModelDetailDisplay = (model: Props) => {
  return (
    <form role="form">
      <div className="form-group row">
        <label
          htmlFor="catalogDescription"
          className={'col-sm-2 col-form-label'}
        >
          CatalogDescription
        </label>
        <div className="col-sm-12">
          {String(model.model!.catalogDescription)}
        </div>
      </div>

      <div className="form-group row">
        <label htmlFor="instruction" className={'col-sm-2 col-form-label'}>
          Instructions
        </label>
        <div className="col-sm-12">{String(model.model!.instruction)}</div>
      </div>

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
        <label htmlFor="productModelID" className={'col-sm-2 col-form-label'}>
          ProductModelID
        </label>
        <div className="col-sm-12">{String(model.model!.productModelID)}</div>
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
  productModelID: number;
}

interface IMatch {
  params: IParams;
}

interface ProductModelDetailComponentProps {
  match: IMatch;
}

interface ProductModelDetailComponentState {
  model?: ProductModelViewModel;
  loading: boolean;
  loaded: boolean;
  errorOccurred: boolean;
  errorMessage: string;
}

export default class ProductModelDetailComponent extends React.Component<
  ProductModelDetailComponentProps,
  ProductModelDetailComponentState
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
          'productmodels/' +
          this.props.match.params.productModelID,
        {
          headers: {
            'Content-Type': 'application/json',
          },
        }
      )
      .then(
        resp => {
          let response = resp.data as Api.ProductModelClientResponseModel;

          let mapper = new ProductModelMapper();

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
      return <ProductModelDetailDisplay model={this.state.model} />;
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
    <Hash>49bd2d41c8a87605cd248511af8cae7e</Hash>
</Codenesium>*/