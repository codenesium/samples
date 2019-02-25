import React, { Component, FormEvent } from 'react';
import axios from 'axios';
import { Constants, ApiRoutes, ClientRoutes } from '../../constants';
import * as Api from '../../api/models';
import ProductReviewMapper from './productReviewMapper';
import ProductReviewViewModel from './productReviewViewModel';
import { Form, Input, Button, Spin, Alert } from 'antd';
import { WrappedFormUtils } from 'antd/es/form/Form';

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
      .get(
        Constants.ApiEndpoint +
          ApiRoutes.ProductReviews +
          '/' +
          this.props.match.params.id,
        {
          headers: {
            'Content-Type': 'application/json',
          },
        }
      )
      .then(
        resp => {
          let response = resp.data as Api.ProductReviewClientResponseModel;

          console.log(response);

          let mapper = new ProductReviewMapper();

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
            loaded: true,
            errorOccurred: true,
            errorMessage: 'Error from API',
          });
        }
      );
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
              <h3>EmailAddress</h3>
              <p>{String(this.state.model!.emailAddress)}</p>
            </div>
            <div>
              <h3>ModifiedDate</h3>
              <p>{String(this.state.model!.modifiedDate)}</p>
            </div>
            <div style={{ marginBottom: '10px' }}>
              <h3>ProductID</h3>
              <p>
                {String(this.state.model!.productIDNavigation!.toDisplay())}
              </p>
            </div>
            <div>
              <h3>ProductReviewID</h3>
              <p>{String(this.state.model!.productReviewID)}</p>
            </div>
            <div>
              <h3>Rating</h3>
              <p>{String(this.state.model!.rating)}</p>
            </div>
            <div>
              <h3>ReviewDate</h3>
              <p>{String(this.state.model!.reviewDate)}</p>
            </div>
            <div>
              <h3>ReviewerName</h3>
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
    <Hash>2a53d4efa5f3ad4b64a8aeb42edcadc8</Hash>
</Codenesium>*/