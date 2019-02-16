import React, { Component } from 'react';
import axios from 'axios';
import * as Api from '../../api/models';
import { UpdateResponse } from '../../api/ApiObjects';
import Constants from '../../constants';
import { FormikProps, FormikErrors, Field, withFormik } from 'formik';
import ProductReviewMapper from './productReviewMapper';
import ProductReviewViewModel from './productReviewViewModel';

interface Props {
  model?: ProductReviewViewModel;
}

const ProductReviewDetailDisplay = (model: Props) => {
  return (
    <form role="form">
      <div className="form-group row">
        <label htmlFor="comment" className={'col-sm-2 col-form-label'}>
          Comments
        </label>
        <div className="col-sm-12">{String(model.model!.comment)}</div>
      </div>

      <div className="form-group row">
        <label htmlFor="emailAddress" className={'col-sm-2 col-form-label'}>
          EmailAddress
        </label>
        <div className="col-sm-12">{String(model.model!.emailAddress)}</div>
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
        <label htmlFor="productReviewID" className={'col-sm-2 col-form-label'}>
          ProductReviewID
        </label>
        <div className="col-sm-12">{String(model.model!.productReviewID)}</div>
      </div>

      <div className="form-group row">
        <label htmlFor="rating" className={'col-sm-2 col-form-label'}>
          Rating
        </label>
        <div className="col-sm-12">{String(model.model!.rating)}</div>
      </div>

      <div className="form-group row">
        <label htmlFor="reviewDate" className={'col-sm-2 col-form-label'}>
          ReviewDate
        </label>
        <div className="col-sm-12">{String(model.model!.reviewDate)}</div>
      </div>

      <div className="form-group row">
        <label htmlFor="reviewerName" className={'col-sm-2 col-form-label'}>
          ReviewerName
        </label>
        <div className="col-sm-12">{String(model.model!.reviewerName)}</div>
      </div>
    </form>
  );
};

interface IParams {
  productReviewID: number;
}

interface IMatch {
  params: IParams;
}

interface ProductReviewDetailComponentProps {
  match: IMatch;
}

interface ProductReviewDetailComponentState {
  model?: ProductReviewViewModel;
  loading: boolean;
  loaded: boolean;
  errorOccurred: boolean;
  errorMessage: string;
}

export default class ProductReviewDetailComponent extends React.Component<
  ProductReviewDetailComponentProps,
  ProductReviewDetailComponentState
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
          'productreviews/' +
          this.props.match.params.productReviewID,
        {
          headers: {
            'Content-Type': 'application/json',
          },
        }
      )
      .then(
        resp => {
          let response = resp.data as Api.ProductReviewClientResponseModel;

          let mapper = new ProductReviewMapper();

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
      return <ProductReviewDetailDisplay model={this.state.model} />;
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
    <Hash>20acbdc6eed4425aa758012f007827d1</Hash>
</Codenesium>*/