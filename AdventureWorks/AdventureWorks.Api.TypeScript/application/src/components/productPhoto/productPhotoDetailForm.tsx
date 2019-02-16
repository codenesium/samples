import React, { Component } from 'react';
import axios from 'axios';
import * as Api from '../../api/models';
import { UpdateResponse } from '../../api/ApiObjects';
import Constants from '../../constants';
import { FormikProps, FormikErrors, Field, withFormik } from 'formik';
import ProductPhotoMapper from './productPhotoMapper';
import ProductPhotoViewModel from './productPhotoViewModel';

interface Props {
  model?: ProductPhotoViewModel;
}

const ProductPhotoDetailDisplay = (model: Props) => {
  return (
    <form role="form">
      <div className="form-group row">
        <label htmlFor="largePhoto" className={'col-sm-2 col-form-label'}>
          LargePhoto
        </label>
        <div className="col-sm-12">{String(model.model!.largePhoto)}</div>
      </div>

      <div className="form-group row">
        <label
          htmlFor="largePhotoFileName"
          className={'col-sm-2 col-form-label'}
        >
          LargePhotoFileName
        </label>
        <div className="col-sm-12">
          {String(model.model!.largePhotoFileName)}
        </div>
      </div>

      <div className="form-group row">
        <label htmlFor="modifiedDate" className={'col-sm-2 col-form-label'}>
          ModifiedDate
        </label>
        <div className="col-sm-12">{String(model.model!.modifiedDate)}</div>
      </div>

      <div className="form-group row">
        <label htmlFor="productPhotoID" className={'col-sm-2 col-form-label'}>
          ProductPhotoID
        </label>
        <div className="col-sm-12">{String(model.model!.productPhotoID)}</div>
      </div>

      <div className="form-group row">
        <label htmlFor="thumbNailPhoto" className={'col-sm-2 col-form-label'}>
          ThumbNailPhoto
        </label>
        <div className="col-sm-12">{String(model.model!.thumbNailPhoto)}</div>
      </div>

      <div className="form-group row">
        <label
          htmlFor="thumbnailPhotoFileName"
          className={'col-sm-2 col-form-label'}
        >
          ThumbnailPhotoFileName
        </label>
        <div className="col-sm-12">
          {String(model.model!.thumbnailPhotoFileName)}
        </div>
      </div>
    </form>
  );
};

interface IParams {
  productPhotoID: number;
}

interface IMatch {
  params: IParams;
}

interface ProductPhotoDetailComponentProps {
  match: IMatch;
}

interface ProductPhotoDetailComponentState {
  model?: ProductPhotoViewModel;
  loading: boolean;
  loaded: boolean;
  errorOccurred: boolean;
  errorMessage: string;
}

export default class ProductPhotoDetailComponent extends React.Component<
  ProductPhotoDetailComponentProps,
  ProductPhotoDetailComponentState
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
          'productphotoes/' +
          this.props.match.params.productPhotoID,
        {
          headers: {
            'Content-Type': 'application/json',
          },
        }
      )
      .then(
        resp => {
          let response = resp.data as Api.ProductPhotoClientResponseModel;

          let mapper = new ProductPhotoMapper();

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
      return <ProductPhotoDetailDisplay model={this.state.model} />;
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
    <Hash>0e784b39d906c0814fdded4aa170f541</Hash>
</Codenesium>*/