import React, { Component, FormEvent } from 'react';
import axios, { AxiosError, AxiosResponse } from 'axios';
import { ActionResponse, CreateResponse } from '../../api/apiObjects';
import { Constants, ApiRoutes, ClientRoutes } from '../../constants';
import * as Api from '../../api/models';
import ProductDescriptionMapper from './productDescriptionMapper';
import ProductDescriptionViewModel from './productDescriptionViewModel';
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

interface ProductDescriptionCreateComponentProps {
  form: WrappedFormUtils;
  history: any;
  match: any;
}

interface ProductDescriptionCreateComponentState {
  model?: ProductDescriptionViewModel;
  loading: boolean;
  loaded: boolean;
  errorOccurred: boolean;
  errorMessage: string;
  submitted: boolean;
  submitting: boolean;
}

class ProductDescriptionCreateComponent extends React.Component<
  ProductDescriptionCreateComponentProps,
  ProductDescriptionCreateComponentState
> {
  state = {
    model: new ProductDescriptionViewModel(),
    loading: false,
    loaded: true,
    errorOccurred: false,
    errorMessage: '',
    submitted: false,
    submitting: false,
  };

  handleSubmit = (e: FormEvent<HTMLFormElement>) => {
    e.preventDefault();
    this.setState({ ...this.state, submitting: true, submitted: false });
    this.props.form.validateFields((err: any, values: any) => {
      if (!err) {
        let model = values as ProductDescriptionViewModel;
        this.submit(model);
      } else {
        this.setState({ ...this.state, submitting: false, submitted: false });
      }
    });
  };

  submit = (model: ProductDescriptionViewModel) => {
    let mapper = new ProductDescriptionMapper();
    axios
      .post<CreateResponse<Api.ProductDescriptionClientRequestModel>>(
        Constants.ApiEndpoint + ApiRoutes.ProductDescriptions,
        mapper.mapViewModelToApiRequest(model),
        {
          headers: GlobalUtilities.defaultHeaders(),
        }
      )
      .then(response => {
        this.setState({
          ...this.state,
          submitted: true,
          submitting: false,
          model: mapper.mapApiResponseToViewModel(response.data.record!),
          errorOccurred: false,
          errorMessage: '',
        });
        GlobalUtilities.logInfo(response);
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
            <label htmlFor="description">Description</label>
            <br />
            {getFieldDecorator('description', {
              rules: [
                { required: true, message: 'Required' },
                { max: 400, message: 'Exceeds max length of 400' },
              ],
            })(<Input placeholder={'Description'} />)}
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
            <label htmlFor="rowguid">Rowguid</label>
            <br />
            {getFieldDecorator('rowguid', {
              rules: [{ required: true, message: 'Required' }],
            })(<Input placeholder={'Rowguid'} />)}
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

export const WrappedProductDescriptionCreateComponent = Form.create({
  name: 'ProductDescription Create',
})(ProductDescriptionCreateComponent);


/*<Codenesium>
    <Hash>9bb3be7b5fd75bde9f2755f5c3133fb7</Hash>
</Codenesium>*/