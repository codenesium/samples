import React, { Component } from 'react';
import axios from 'axios';
import * as Api from '../../api/models';
import { UpdateResponse } from '../../api/ApiObjects';
import Constants from '../../constants';
import { FormikProps, FormikErrors, Field, withFormik } from 'formik';
import ProductMapper from './productMapper';
import ProductViewModel from './productViewModel';

interface Props {
  model?: ProductViewModel;
}

const ProductDetailDisplay = (model: Props) => {
  return (
    <form role="form">
      <div className="form-group row">
        <label htmlFor="color" className={'col-sm-2 col-form-label'}>
          Color
        </label>
        <div className="col-sm-12">{String(model.model!.color)}</div>
      </div>

      <div className="form-group row">
        <label
          htmlFor="daysToManufacture"
          className={'col-sm-2 col-form-label'}
        >
          DaysToManufacture
        </label>
        <div className="col-sm-12">
          {String(model.model!.daysToManufacture)}
        </div>
      </div>

      <div className="form-group row">
        <label htmlFor="discontinuedDate" className={'col-sm-2 col-form-label'}>
          DiscontinuedDate
        </label>
        <div className="col-sm-12">{String(model.model!.discontinuedDate)}</div>
      </div>

      <div className="form-group row">
        <label
          htmlFor="finishedGoodsFlag"
          className={'col-sm-2 col-form-label'}
        >
          FinishedGoodsFlag
        </label>
        <div className="col-sm-12">
          {String(model.model!.finishedGoodsFlag)}
        </div>
      </div>

      <div className="form-group row">
        <label htmlFor="listPrice" className={'col-sm-2 col-form-label'}>
          ListPrice
        </label>
        <div className="col-sm-12">{String(model.model!.listPrice)}</div>
      </div>

      <div className="form-group row">
        <label htmlFor="makeFlag" className={'col-sm-2 col-form-label'}>
          MakeFlag
        </label>
        <div className="col-sm-12">{String(model.model!.makeFlag)}</div>
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
        <label htmlFor="productID" className={'col-sm-2 col-form-label'}>
          ProductID
        </label>
        <div className="col-sm-12">{String(model.model!.productID)}</div>
      </div>

      <div className="form-group row">
        <label htmlFor="productLine" className={'col-sm-2 col-form-label'}>
          ProductLine
        </label>
        <div className="col-sm-12">{String(model.model!.productLine)}</div>
      </div>

      <div className="form-group row">
        <label htmlFor="productModelID" className={'col-sm-2 col-form-label'}>
          ProductModelID
        </label>
        <div className="col-sm-12">{String(model.model!.productModelID)}</div>
      </div>

      <div className="form-group row">
        <label htmlFor="productNumber" className={'col-sm-2 col-form-label'}>
          ProductNumber
        </label>
        <div className="col-sm-12">{String(model.model!.productNumber)}</div>
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
        <label htmlFor="reorderPoint" className={'col-sm-2 col-form-label'}>
          ReorderPoint
        </label>
        <div className="col-sm-12">{String(model.model!.reorderPoint)}</div>
      </div>

      <div className="form-group row">
        <label htmlFor="rowguid" className={'col-sm-2 col-form-label'}>
          Rowguid
        </label>
        <div className="col-sm-12">{String(model.model!.rowguid)}</div>
      </div>

      <div className="form-group row">
        <label htmlFor="safetyStockLevel" className={'col-sm-2 col-form-label'}>
          SafetyStockLevel
        </label>
        <div className="col-sm-12">{String(model.model!.safetyStockLevel)}</div>
      </div>

      <div className="form-group row">
        <label htmlFor="sellEndDate" className={'col-sm-2 col-form-label'}>
          SellEndDate
        </label>
        <div className="col-sm-12">{String(model.model!.sellEndDate)}</div>
      </div>

      <div className="form-group row">
        <label htmlFor="sellStartDate" className={'col-sm-2 col-form-label'}>
          SellStartDate
        </label>
        <div className="col-sm-12">{String(model.model!.sellStartDate)}</div>
      </div>

      <div className="form-group row">
        <label htmlFor="size" className={'col-sm-2 col-form-label'}>
          Size
        </label>
        <div className="col-sm-12">{String(model.model!.size)}</div>
      </div>

      <div className="form-group row">
        <label
          htmlFor="sizeUnitMeasureCode"
          className={'col-sm-2 col-form-label'}
        >
          SizeUnitMeasureCode
        </label>
        <div className="col-sm-12">
          {String(model.model!.sizeUnitMeasureCode)}
        </div>
      </div>

      <div className="form-group row">
        <label htmlFor="standardCost" className={'col-sm-2 col-form-label'}>
          StandardCost
        </label>
        <div className="col-sm-12">{String(model.model!.standardCost)}</div>
      </div>

      <div className="form-group row">
        <label htmlFor="style" className={'col-sm-2 col-form-label'}>
          Style
        </label>
        <div className="col-sm-12">{String(model.model!.style)}</div>
      </div>

      <div className="form-group row">
        <label htmlFor="weight" className={'col-sm-2 col-form-label'}>
          Weight
        </label>
        <div className="col-sm-12">{String(model.model!.weight)}</div>
      </div>

      <div className="form-group row">
        <label
          htmlFor="weightUnitMeasureCode"
          className={'col-sm-2 col-form-label'}
        >
          WeightUnitMeasureCode
        </label>
        <div className="col-sm-12">
          {String(model.model!.weightUnitMeasureCode)}
        </div>
      </div>
    </form>
  );
};

interface IParams {
  productID: number;
}

interface IMatch {
  params: IParams;
}

interface ProductDetailComponentProps {
  match: IMatch;
}

interface ProductDetailComponentState {
  model?: ProductViewModel;
  loading: boolean;
  loaded: boolean;
  errorOccurred: boolean;
  errorMessage: string;
}

export default class ProductDetailComponent extends React.Component<
  ProductDetailComponentProps,
  ProductDetailComponentState
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
      .get(Constants.ApiUrl + 'products/' + this.props.match.params.productID, {
        headers: {
          'Content-Type': 'application/json',
        },
      })
      .then(
        resp => {
          let response = resp.data as Api.ProductClientResponseModel;

          let mapper = new ProductMapper();

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
      return <ProductDetailDisplay model={this.state.model} />;
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
    <Hash>21bcb49182c62e81012fe05b800d4627</Hash>
</Codenesium>*/