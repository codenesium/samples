import React, { Component, FormEvent } from 'react';
import axios from 'axios';
import { CreateResponse } from '../../api/apiObjects';
import { Constants, ApiRoutes, ClientRoutes } from '../../constants';
import * as Api from '../../api/models';
import ProductReviewMapper from './productReviewMapper';
import ProductReviewViewModel from './productReviewViewModel';
import {
  Form,
  Input,
  Button,
  Switch,
  InputNumber,
  DatePicker,
  Spin,
  Alert,
} from 'antd';
import { WrappedFormUtils } from 'antd/es/form/Form';

interface ProductReviewCreateComponentProps {
  form: WrappedFormUtils;
  history: any;
  match: any;
}

interface ProductReviewCreateComponentState {
  model?: ProductReviewViewModel;
  loading: boolean;
  loaded: boolean;
  errorOccurred: boolean;
  errorMessage: string;
  submitted: boolean;
}

class ProductReviewCreateComponent extends React.Component<
  ProductReviewCreateComponentProps,
  ProductReviewCreateComponentState
> {
  state = {
    model: new ProductReviewViewModel(),
    loading: false,
    loaded: true,
    errorOccurred: false,
    errorMessage: '',
    submitted: false,
  };

  handleSubmit = (e: FormEvent<HTMLFormElement>) => {
    e.preventDefault();
    this.props.form.validateFields((err: any, values: any) => {
      if (!err) {
        let model = values as ProductReviewViewModel;
        console.log('Received values of form: ', model);
        this.submit(model);
      }
    });
  };

  submit = (model: ProductReviewViewModel) => {
    let mapper = new ProductReviewMapper();
    axios
      .post(
        Constants.ApiEndpoint + ApiRoutes.ProductReviews,
        mapper.mapViewModelToApiRequest(model),
        {
          headers: {
            'Content-Type': 'application/json',
          },
        }
      )
      .then(
        resp => {
          let response = resp.data as CreateResponse<
            Api.ProductReviewClientRequestModel
          >;
          this.setState({
            ...this.state,
            submitted: true,
            model: mapper.mapApiResponseToViewModel(response.record!),
            errorOccurred: false,
            errorMessage: '',
          });
          console.log(response);
        },
        error => {
          console.log(error);
          this.setState({
            ...this.state,
            submitted: true,
            errorOccurred: true,
            errorMessage: 'Error from API',
          });
        }
      );
  };

  render() {
    const {
      getFieldDecorator,
      getFieldsError,
      getFieldError,
      isFieldTouched,
    } = this.props.form;

    let message: JSX.Element = <div />;
    if (this.state.submitted) {
      if (this.state.errorOccurred) {
        message = <Alert message={this.state.errorMessage} type="error" />;
      } else {
        message = <Alert message="Submitted" type="success" />;
      }
    }

    if (this.state.loading) {
      return <Spin size="large" />;
    } else if (this.state.loaded) {
      return (
        <Form onSubmit={this.handleSubmit}>
          <Form.Item>
            <label htmlFor="comment">Comments</label>
            <br />
            {getFieldDecorator('comment', {
              rules: [],
            })(
              <DatePicker
                format={'YYYY-MM-DD'}
                placeholder={'Comments'}
                id={'comment'}
              />
            )}
          </Form.Item>

          <Form.Item>
            <label htmlFor="emailAddress">EmailAddress</label>
            <br />
            {getFieldDecorator('emailAddress', {
              rules: [],
            })(
              <DatePicker
                format={'YYYY-MM-DD'}
                placeholder={'EmailAddress'}
                id={'emailAddress'}
              />
            )}
          </Form.Item>

          <Form.Item>
            <label htmlFor="modifiedDate">ModifiedDate</label>
            <br />
            {getFieldDecorator('modifiedDate', {
              rules: [],
            })(
              <DatePicker
                format={'YYYY-MM-DD'}
                placeholder={'ModifiedDate'}
                id={'modifiedDate'}
              />
            )}
          </Form.Item>

          <Form.Item>
            <label htmlFor="productID">ProductID</label>
            <br />
            {getFieldDecorator('productID', {
              rules: [],
            })(
              <DatePicker
                format={'YYYY-MM-DD'}
                placeholder={'ProductID'}
                id={'productID'}
              />
            )}
          </Form.Item>

          <Form.Item>
            <label htmlFor="rating">Rating</label>
            <br />
            {getFieldDecorator('rating', {
              rules: [],
            })(
              <DatePicker
                format={'YYYY-MM-DD'}
                placeholder={'Rating'}
                id={'rating'}
              />
            )}
          </Form.Item>

          <Form.Item>
            <label htmlFor="reviewDate">ReviewDate</label>
            <br />
            {getFieldDecorator('reviewDate', {
              rules: [],
            })(
              <DatePicker
                format={'YYYY-MM-DD'}
                placeholder={'ReviewDate'}
                id={'reviewDate'}
              />
            )}
          </Form.Item>

          <Form.Item>
            <label htmlFor="reviewerName">ReviewerName</label>
            <br />
            {getFieldDecorator('reviewerName', {
              rules: [],
            })(
              <DatePicker
                format={'YYYY-MM-DD'}
                placeholder={'ReviewerName'}
                id={'reviewerName'}
              />
            )}
          </Form.Item>

          <Form.Item>
            <Button type="primary" htmlType="submit">
              Submit
            </Button>
          </Form.Item>
          {message}
        </Form>
      );
    } else {
      return null;
    }
  }
}

export const WrappedProductReviewCreateComponent = Form.create({
  name: 'ProductReview Create',
})(ProductReviewCreateComponent);


/*<Codenesium>
    <Hash>2428e88fe02b23cf7bed9f8ca650f22c</Hash>
</Codenesium>*/