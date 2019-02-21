import React, { Component, FormEvent } from 'react';
import axios from 'axios';
import { CreateResponse } from '../../api/apiObjects';
import { Constants, ApiRoutes, ClientRoutes } from '../../constants';
import * as Api from '../../api/models';
import ProductPhotoMapper from './productPhotoMapper';
import ProductPhotoViewModel from './productPhotoViewModel';
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

interface ProductPhotoCreateComponentProps {
  form: WrappedFormUtils;
  history: any;
  match: any;
}

interface ProductPhotoCreateComponentState {
  model?: ProductPhotoViewModel;
  loading: boolean;
  loaded: boolean;
  errorOccurred: boolean;
  errorMessage: string;
  submitted: boolean;
}

class ProductPhotoCreateComponent extends React.Component<
  ProductPhotoCreateComponentProps,
  ProductPhotoCreateComponentState
> {
  state = {
    model: new ProductPhotoViewModel(),
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
        let model = values as ProductPhotoViewModel;
        console.log('Received values of form: ', model);
        this.submit(model);
      }
    });
  };

  submit = (model: ProductPhotoViewModel) => {
    let mapper = new ProductPhotoMapper();
    axios
      .post(
        Constants.ApiEndpoint + ApiRoutes.ProductPhotoes,
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
            Api.ProductPhotoClientRequestModel
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
            <label htmlFor="largePhoto">LargePhoto</label>
            <br />
            {getFieldDecorator('largePhoto', {
              rules: [],
            })(
              <DatePicker
                format={'YYYY-MM-DD'}
                placeholder={'LargePhoto'}
                id={'largePhoto'}
              />
            )}
          </Form.Item>

          <Form.Item>
            <label htmlFor="largePhotoFileName">LargePhotoFileName</label>
            <br />
            {getFieldDecorator('largePhotoFileName', {
              rules: [],
            })(
              <DatePicker
                format={'YYYY-MM-DD'}
                placeholder={'LargePhotoFileName'}
                id={'largePhotoFileName'}
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
            <label htmlFor="thumbNailPhoto">ThumbNailPhoto</label>
            <br />
            {getFieldDecorator('thumbNailPhoto', {
              rules: [],
            })(
              <DatePicker
                format={'YYYY-MM-DD'}
                placeholder={'ThumbNailPhoto'}
                id={'thumbNailPhoto'}
              />
            )}
          </Form.Item>

          <Form.Item>
            <label htmlFor="thumbnailPhotoFileName">
              ThumbnailPhotoFileName
            </label>
            <br />
            {getFieldDecorator('thumbnailPhotoFileName', {
              rules: [],
            })(
              <DatePicker
                format={'YYYY-MM-DD'}
                placeholder={'ThumbnailPhotoFileName'}
                id={'thumbnailPhotoFileName'}
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

export const WrappedProductPhotoCreateComponent = Form.create({
  name: 'ProductPhoto Create',
})(ProductPhotoCreateComponent);


/*<Codenesium>
    <Hash>56ca4f494ce68391af759b6f0ba80b31</Hash>
</Codenesium>*/