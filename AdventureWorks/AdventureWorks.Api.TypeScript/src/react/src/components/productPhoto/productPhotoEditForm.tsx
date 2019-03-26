import React, { Component, FormEvent } from 'react';
import axios, { AxiosError, AxiosResponse } from 'axios';
import { ActionResponse, CreateResponse } from '../../api/apiObjects';
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
  TimePicker,
} from 'antd';
import { WrappedFormUtils } from 'antd/es/form/Form';
import * as GlobalUtilities from '../../lib/globalUtilities';
interface ProductPhotoEditComponentProps {
  form: WrappedFormUtils;
  history: any;
  match: any;
}

interface ProductPhotoEditComponentState {
  model?: ProductPhotoViewModel;
  loading: boolean;
  loaded: boolean;
  errorOccurred: boolean;
  errorMessage: string;
  submitted: boolean;
  submitting: boolean;
}

class ProductPhotoEditComponent extends React.Component<
  ProductPhotoEditComponentProps,
  ProductPhotoEditComponentState
> {
  state = {
    model: new ProductPhotoViewModel(),
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
      .get<Api.ProductPhotoClientResponseModel>(
        Constants.ApiEndpoint +
          ApiRoutes.ProductPhotoes +
          '/' +
          this.props.match.params.id,
        {
          headers: GlobalUtilities.defaultHeaders(),
        }
      )
      .then(response => {
        GlobalUtilities.logInfo(response);

        let mapper = new ProductPhotoMapper();

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
        let model = values as ProductPhotoViewModel;
        this.submit(model);
      } else {
        this.setState({ ...this.state, submitting: false, submitted: false });
      }
    });
  };

  submit = (model: ProductPhotoViewModel) => {
    let mapper = new ProductPhotoMapper();
    axios
      .put<CreateResponse<Api.ProductPhotoClientRequestModel>>(
        Constants.ApiEndpoint +
          ApiRoutes.ProductPhotoes +
          '/' +
          this.state.model!.productPhotoID,
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
            <label htmlFor="largePhoto">Large Photo</label>
            <br />
            {getFieldDecorator('largePhoto', {
              rules: [],
            })(<Input placeholder={'Large Photo'} />)}
          </Form.Item>

          <Form.Item>
            <label htmlFor="largePhotoFileName">Large Photo File Name</label>
            <br />
            {getFieldDecorator('largePhotoFileName', {
              rules: [{ max: 50, message: 'Exceeds max length of 50' }],
            })(<Input placeholder={'Large Photo File Name'} />)}
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

          <Form.Item>
            <label htmlFor="thumbNailPhoto">Thumb Nail Photo</label>
            <br />
            {getFieldDecorator('thumbNailPhoto', {
              rules: [],
            })(<Input placeholder={'Thumb Nail Photo'} />)}
          </Form.Item>

          <Form.Item>
            <label htmlFor="thumbnailPhotoFileName">
              Thumbnail Photo File Name
            </label>
            <br />
            {getFieldDecorator('thumbnailPhotoFileName', {
              rules: [{ max: 50, message: 'Exceeds max length of 50' }],
            })(<Input placeholder={'Thumbnail Photo File Name'} />)}
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

export const WrappedProductPhotoEditComponent = Form.create({
  name: 'ProductPhoto Edit',
})(ProductPhotoEditComponent);


/*<Codenesium>
    <Hash>e96992cfda3c7e3797f84306d6aa5c9e</Hash>
</Codenesium>*/