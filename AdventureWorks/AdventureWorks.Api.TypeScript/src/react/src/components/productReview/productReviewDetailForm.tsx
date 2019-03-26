import React, { Component, FormEvent } from 'react';
import axios, { AxiosError, AxiosResponse } from 'axios';
import { Constants, ApiRoutes, ClientRoutes } from '../../constants';
import * as Api from '../../api/models';
import ProductReviewMapper from './productReviewMapper';
import ProductReviewViewModel from './productReviewViewModel';
import { Form, Input, Button, Spin, Alert } from 'antd';
import { WrappedFormUtils } from 'antd/es/form/Form';
import * as GlobalUtilities from '../../lib/globalUtilities';

interface ProductReviewDetailComponentProps {
  form: WrappedFormUtils;
  history: any;
  match: any;
}

interface ProductReviewDetailComponentState {
  model?: ProductReviewViewModel;
  loading: boolean;
  loaded: boolean;
  errorOccurred: boolean;
  errorMessage: string;
}

class ProductReviewDetailComponent extends React.Component<
  ProductReviewDetailComponentProps,
  ProductReviewDetailComponentState
> {
  state = {
    model: new ProductReviewViewModel(),
    loading: false,
    loaded: true,
    errorOccurred: false,
    errorMessage: '',
  };

  handleEditClick(e: any) {
    this.props.history.push(
      ClientRoutes.ProductReviews + '/edit/' + this.state.model!.productReviewID
    );
  }

  componentDidMount() {
    this.setState({ ...this.state, loading: true });

    axios
      .get<Api.ProductReviewClientResponseModel>(
        Constants.ApiEndpoint +
          ApiRoutes.ProductReviews +
          '/' +
          this.props.match.params.id,
        {
          headers: GlobalUtilities.defaultHeaders(),
        }
      )
      .then(response => {
        GlobalUtilities.logInfo(response);

        let mapper = new ProductReviewMapper();

        this.setState({
          model: mapper.mapApiResponseToViewModel(response.data),
          loading: false,
          loaded: true,
          errorOccurred: false,
          errorMessage: '',
        });
      })
      .catch((error: AxiosError) => {
        GlobalUtilities.logError(error);

        if (error.response && error.response.status == 422) {
          this.setState({
            ...this.state,
            errorOccurred: false,
            errorMessage: '',
          });
        } else {
          this.setState({
            ...this.state,
            errorOccurred: true,
            errorMessage: 'Error Occurred',
          });
        }
      });
  }

  render() {
    let message: JSX.Element = <div />;
    if (this.state.errorOccurred) {
      message = <Alert message={this.state.errorMessage} type="error" />;
    }

    if (this.state.loading) {
      return <Spin size="large" />;
    } else if (this.state.loaded) {
      return (
        <div>
          <Button
            style={{ float: 'right' }}
            type="primary"
            onClick={(e: any) => {
              this.handleEditClick(e);
            }}
          >
            <i className="fas fa-edit" />
          </Button>
          <div>
            <div>
              <h3>Comments</h3>
              <p>{String(this.state.model!.comment)}</p>
            </div>
            <div>
              <h3>Email Address</h3>
              <p>{String(this.state.model!.emailAddress)}</p>
            </div>
            <div>
              <h3>Modified Date</h3>
              <p>{String(this.state.model!.modifiedDate)}</p>
            </div>
            <div style={{ marginBottom: '10px' }}>
              <h3>Product I D</h3>
              <p>
                {String(
                  this.state.model!.productIDNavigation &&
                    this.state.model!.productIDNavigation!.toDisplay()
                )}
              </p>
            </div>
            <div>
              <h3>Rating</h3>
              <p>{String(this.state.model!.rating)}</p>
            </div>
            <div>
              <h3>Review Date</h3>
              <p>{String(this.state.model!.reviewDate)}</p>
            </div>
            <div>
              <h3>Reviewer Name</h3>
              <p>{String(this.state.model!.reviewerName)}</p>
            </div>
          </div>
          {message}
        </div>
      );
    } else {
      return null;
    }
  }
}

export const WrappedProductReviewDetailComponent = Form.create({
  name: 'ProductReview Detail',
})(ProductReviewDetailComponent);


/*<Codenesium>
    <Hash>ad2faec0112a48867140c2251249eedc</Hash>
</Codenesium>*/