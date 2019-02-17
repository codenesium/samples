import React, { Component } from 'react';
import axios from 'axios';
import * as Api from '../../api/models';
import { UpdateResponse } from '../../api/apiObjects';
import { Constants, ApiRoutes, ClientRoutes } from '../../constants';
import { FormikProps, FormikErrors, Field, withFormik } from 'formik';
import { LoadingForm } from '../../lib/components/loadingForm';
import { ErrorForm } from '../../lib/components/errorForm';
import ProductReviewMapper from './productReviewMapper';
import ProductReviewViewModel from './productReviewViewModel';

interface Props {
  history: any;
  model?: ProductReviewViewModel;
}

const ProductReviewDetailDisplay = (model: Props) => {
  return (
    <form role="form">
      <button
        className="btn btn-primary btn-sm align-middle float-right vertically-center"
        onClick={e => {
          model.history.push(
            ClientRoutes.ProductReviews +
              '/edit/' +
              model.model!.productReviewID
          );
        }}
      >
        <i className="fas fa-edit" />
      </button>
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
  history: any;
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
        Constants.ApiEndpoint +
          ApiRoutes.ProductReviews +
          '/' +
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
      return <LoadingForm />;
    } else if (this.state.errorOccurred) {
      return <ErrorForm message={this.state.errorMessage} />;
    } else if (this.state.loaded) {
      return (
        <ProductReviewDetailDisplay
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
    <Hash>2db66c6192b243502c24716d6c9e05eb</Hash>
</Codenesium>*/