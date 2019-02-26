import React, { Component, FormEvent } from 'react';
import axios from 'axios';
import { ActionResponse, CreateResponse } from '../../api/apiObjects';
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
  TimePicker,
} from 'antd';
import { WrappedFormUtils } from 'antd/es/form/Form';
import { ToLowerCaseFirstLetter } from '../../lib/stringUtilities';
import { ProductSelectComponent } from '../shared/productSelect';

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
          if (error.response.data) {
            let errorResponse = error.response.data as ActionResponse;

            errorResponse.validationErrors.forEach(x => {
              this.props.form.setFields({
                [ToLowerCaseFirstLetter(x.propertyName)]: {
                  value: this.props.form.getFieldValue(
                    ToLowerCaseFirstLetter(x.propertyName)
                  ),
                  errors: [new Error(x.errorMessage)],
                },
              });
            });
          }
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
              rules: [{ max: 3850, message: 'Exceeds max length of 3850' }],
            })(<DatePicker format={'YYYY-MM-DD'} placeholder={'Comments'} />)}
          </Form.Item>

          <Form.Item>
            <label htmlFor="emailAddress">EmailAddress</label>
            <br />
            {getFieldDecorator('emailAddress', {
              rules: [
                { required: true, message: 'Required' },
                { max: 50, message: 'Exceeds max length of 50' },
              ],
            })(
              <DatePicker format={'YYYY-MM-DD'} placeholder={'EmailAddress'} />
            )}
          </Form.Item>

          <Form.Item>
            <label htmlFor="modifiedDate">ModifiedDate</label>
            <br />
            {getFieldDecorator('modifiedDate', {
              rules: [{ required: true, message: 'Required' }],
            })(
              <DatePicker format={'YYYY-MM-DD'} placeholder={'ModifiedDate'} />
            )}
          </Form.Item>

          <Form.Item>
            <label htmlFor="productID">ProductID</label>
            <br />
            {getFieldDecorator('productID', {
              rules: [{ required: true, message: 'Required' }],
            })(<DatePicker format={'YYYY-MM-DD'} placeholder={'ProductID'} />)}
          </Form.Item>

          <Form.Item>
            <label htmlFor="rating">Rating</label>
            <br />
            {getFieldDecorator('rating', {
              rules: [{ required: true, message: 'Required' }],
            })(<DatePicker format={'YYYY-MM-DD'} placeholder={'Rating'} />)}
          </Form.Item>

          <Form.Item>
            <label htmlFor="reviewDate">ReviewDate</label>
            <br />
            {getFieldDecorator('reviewDate', {
              rules: [{ required: true, message: 'Required' }],
            })(<DatePicker format={'YYYY-MM-DD'} placeholder={'ReviewDate'} />)}
          </Form.Item>

          <Form.Item>
            <label htmlFor="reviewerName">ReviewerName</label>
            <br />
            {getFieldDecorator('reviewerName', {
              rules: [
                { required: true, message: 'Required' },
                { max: 50, message: 'Exceeds max length of 50' },
              ],
            })(
              <DatePicker format={'YYYY-MM-DD'} placeholder={'ReviewerName'} />
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
    <Hash>06211f6763c6af98694f7709b2c221ac</Hash>
</Codenesium>*/