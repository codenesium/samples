import React, { Component, FormEvent } from 'react';
import axios, { AxiosError, AxiosResponse } from 'axios';
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
import * as GlobalUtilities from '../../lib/globalUtilities';
import { ProductSelectComponent } from '../shared/productSelect';
interface ProductReviewEditComponentProps {
  form: WrappedFormUtils;
  history: any;
  match: any;
}

interface ProductReviewEditComponentState {
  model?: ProductReviewViewModel;
  loading: boolean;
  loaded: boolean;
  errorOccurred: boolean;
  errorMessage: string;
  submitted: boolean;
  submitting: boolean;
}

class ProductReviewEditComponent extends React.Component<
  ProductReviewEditComponentProps,
  ProductReviewEditComponentState
> {
  state = {
    model: new ProductReviewViewModel(),
    loading: false,
    loaded: true,
    errorOccurred: false,
    errorMessage: '',
    submitted: false,
    submitting: false,
  };

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

        this.props.form.setFieldsValue(
          mapper.mapApiResponseToViewModel(response.data)
        );
      })
      .catch((error: AxiosError) => {
        GlobalUtilities.logError(error);

        if (error.response && error.response.status == 422) {
          this.setState({
            ...this.state,
            submitted: true,
            submitting: false,
            errorOccurred: false,
            errorMessage: '',
          });
        } else {
          this.setState({
            ...this.state,
            submitted: true,
            submitting: false,
            errorOccurred: true,
            errorMessage: 'Error Occurred',
          });
        }
      });
  }

  handleSubmit = (e: FormEvent<HTMLFormElement>) => {
    e.preventDefault();
    this.setState({ ...this.state, submitting: true, submitted: false });
    this.props.form.validateFields((err: any, values: any) => {
      if (!err) {
        let model = values as ProductReviewViewModel;
        this.submit(model);
      } else {
        this.setState({ ...this.state, submitting: false, submitted: false });
      }
    });
  };

  submit = (model: ProductReviewViewModel) => {
    let mapper = new ProductReviewMapper();
    axios
      .put<CreateResponse<Api.ProductReviewClientRequestModel>>(
        Constants.ApiEndpoint +
          ApiRoutes.ProductReviews +
          '/' +
          this.state.model!.productReviewID,
        mapper.mapViewModelToApiRequest(model),
        {
          headers: GlobalUtilities.defaultHeaders(),
        }
      )
      .then(response => {
        GlobalUtilities.logInfo(response);
        this.setState({
          ...this.state,
          submitted: true,
          submitting: false,
          model: mapper.mapApiResponseToViewModel(response.data.record!),
          errorOccurred: false,
          errorMessage: '',
        });
      })
      .catch((error: AxiosError) => {
        GlobalUtilities.logError(error);

        if (error.response && error.response.status == 422) {
          let errorResponse = error.response.data as ActionResponse;
          errorResponse.validationErrors.forEach(x => {
            this.props.form.setFields({
              [GlobalUtilities.toLowerCaseFirstLetter(x.propertyName)]: {
                value: this.props.form.getFieldValue(
                  GlobalUtilities.toLowerCaseFirstLetter(x.propertyName)
                ),
                errors: [new Error(x.errorMessage)],
              },
            });
          });
          this.setState({
            ...this.state,
            submitted: true,
            submitting: false,
            errorOccurred: false,
            errorMessage: '',
          });
        } else {
          this.setState({
            ...this.state,
            submitted: true,
            submitting: false,
            errorOccurred: true,
            errorMessage: 'Error Occurred',
          });
        }
      });
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
            })(<Input placeholder={'Comments'} />)}
          </Form.Item>

          <Form.Item>
            <label htmlFor="emailAddress">Email Address</label>
            <br />
            {getFieldDecorator('emailAddress', {
              rules: [
                { required: true, message: 'Required' },
                { max: 50, message: 'Exceeds max length of 50' },
              ],
            })(<Input placeholder={'Email Address'} />)}
          </Form.Item>

          <Form.Item>
            <label htmlFor="modifiedDate">Modified Date</label>
            <br />
            {getFieldDecorator('modifiedDate', {
              rules: [{ required: true, message: 'Required' }],
            })(
              <DatePicker format={'YYYY-MM-DD'} placeholder={'Modified Date'} />
            )}
          </Form.Item>

          <ProductSelectComponent
            apiRoute={Constants.ApiEndpoint + ApiRoutes.Products}
            getFieldDecorator={this.props.form.getFieldDecorator}
            propertyName="productID"
            required={true}
            selectedValue={this.state.model!.productID}
          />

          <Form.Item>
            <label htmlFor="rating">Rating</label>
            <br />
            {getFieldDecorator('rating', {
              rules: [{ required: true, message: 'Required' }],
            })(<InputNumber placeholder={'Rating'} />)}
          </Form.Item>

          <Form.Item>
            <label htmlFor="reviewDate">Review Date</label>
            <br />
            {getFieldDecorator('reviewDate', {
              rules: [{ required: true, message: 'Required' }],
            })(
              <DatePicker format={'YYYY-MM-DD'} placeholder={'Review Date'} />
            )}
          </Form.Item>

          <Form.Item>
            <label htmlFor="reviewerName">Reviewer Name</label>
            <br />
            {getFieldDecorator('reviewerName', {
              rules: [
                { required: true, message: 'Required' },
                { max: 50, message: 'Exceeds max length of 50' },
              ],
            })(<Input placeholder={'Reviewer Name'} />)}
          </Form.Item>

          <Form.Item>
            <Button
              type="primary"
              htmlType="submit"
              loading={this.state.submitting}
            >
              {this.state.submitting ? 'Submitting...' : 'Submit'}
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

export const WrappedProductReviewEditComponent = Form.create({
  name: 'ProductReview Edit',
})(ProductReviewEditComponent);


/*<Codenesium>
    <Hash>079bae2ae403c4629de0b44bf42d22e0</Hash>
</Codenesium>*/