import React, { Component } from 'react';
import axios from 'axios';
import * as Api from '../../api/models';
import { UpdateResponse } from '../../api/apiObjects';
import { Constants, ApiRoutes, ClientRoutes } from '../../constants';
import { FormikProps, FormikErrors, Field, withFormik } from 'formik';
import { LoadingForm } from '../../lib/components/loadingForm';
import { ErrorForm } from '../../lib/components/errorForm';
import ProductSubcategoryMapper from './productSubcategoryMapper';
import ProductSubcategoryViewModel from './productSubcategoryViewModel';

interface Props {
  history: any;
  model?: ProductSubcategoryViewModel;
}

const ProductSubcategoryDetailDisplay = (model: Props) => {
  return (
    <form role="form">
      <button
        className="btn btn-primary btn-sm align-middle float-right vertically-center"
        onClick={e => {
          model.history.push(
            ClientRoutes.ProductSubcategories +
              '/edit/' +
              model.model!.productSubcategoryID
          );
        }}
      >
        <i className="fas fa-edit" />
      </button>
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
  history: any;
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
        Constants.ApiEndpoint +
          ApiRoutes.ProductSubcategories +
          '/' +
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
      return <LoadingForm />;
    } else if (this.state.errorOccurred) {
      return <ErrorForm message={this.state.errorMessage} />;
    } else if (this.state.loaded) {
      return (
        <ProductSubcategoryDetailDisplay
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
    <Hash>dab9d1ce85cb42d4dc95b38919c603ed</Hash>
</Codenesium>*/