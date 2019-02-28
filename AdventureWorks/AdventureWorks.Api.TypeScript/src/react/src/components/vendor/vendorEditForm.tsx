import React, { Component, FormEvent } from 'react';
import axios from 'axios';
import { ActionResponse, CreateResponse } from '../../api/apiObjects';
import { Constants, ApiRoutes, ClientRoutes } from '../../constants';
import * as Api from '../../api/models';
import VendorMapper from './vendorMapper';
import VendorViewModel from './vendorViewModel';
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
interface VendorEditComponentProps {
  form: WrappedFormUtils;
  history: any;
  match: any;
}

interface VendorEditComponentState {
  model?: VendorViewModel;
  loading: boolean;
  loaded: boolean;
  errorOccurred: boolean;
  errorMessage: string;
  submitted: boolean;
}

class VendorEditComponent extends React.Component<
  VendorEditComponentProps,
  VendorEditComponentState
> {
  state = {
    model: new VendorViewModel(),
    loading: false,
    loaded: true,
    errorOccurred: false,
    errorMessage: '',
    submitted: false,
  };

  componentDidMount() {
    this.setState({ ...this.state, loading: true });

    axios
      .get(
        Constants.ApiEndpoint +
          ApiRoutes.Vendors +
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
          let response = resp.data as Api.VendorClientResponseModel;

          console.log(response);

          let mapper = new VendorMapper();

          this.setState({
            model: mapper.mapApiResponseToViewModel(response),
            loading: false,
            loaded: true,
            errorOccurred: false,
            errorMessage: '',
          });

          this.props.form.setFieldsValue(
            mapper.mapApiResponseToViewModel(response)
          );
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

  handleSubmit = (e: FormEvent<HTMLFormElement>) => {
    e.preventDefault();
    this.props.form.validateFields((err: any, values: any) => {
      if (!err) {
        let model = values as VendorViewModel;
        console.log('Received values of form: ', model);
        this.submit(model);
      }
    });
  };

  submit = (model: VendorViewModel) => {
    let mapper = new VendorMapper();
    axios
      .put(
        Constants.ApiEndpoint +
          ApiRoutes.Vendors +
          '/' +
          this.state.model!.businessEntityID,
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
            Api.VendorClientRequestModel
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
          let errorResponse = error.response.data as ActionResponse;
          if (error.response.data) {
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
            <label htmlFor="accountNumber">AccountNumber</label>
            <br />
            {getFieldDecorator('accountNumber', {
              rules: [
                { required: true, message: 'Required' },
                { max: 15, message: 'Exceeds max length of 15' },
              ],
            })(
              <DatePicker format={'YYYY-MM-DD'} placeholder={'AccountNumber'} />
            )}
          </Form.Item>

          <Form.Item>
            <label htmlFor="activeFlag">ActiveFlag</label>
            <br />
            {getFieldDecorator('activeFlag', {
              rules: [{ required: true, message: 'Required' }],
            })(<DatePicker format={'YYYY-MM-DD'} placeholder={'ActiveFlag'} />)}
          </Form.Item>

          <Form.Item>
            <label htmlFor="creditRating">CreditRating</label>
            <br />
            {getFieldDecorator('creditRating', {
              rules: [{ required: true, message: 'Required' }],
            })(
              <DatePicker format={'YYYY-MM-DD'} placeholder={'CreditRating'} />
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
            <label htmlFor="name">Name</label>
            <br />
            {getFieldDecorator('name', {
              rules: [
                { required: true, message: 'Required' },
                { max: 50, message: 'Exceeds max length of 50' },
              ],
            })(<DatePicker format={'YYYY-MM-DD'} placeholder={'Name'} />)}
          </Form.Item>

          <Form.Item>
            <label htmlFor="preferredVendorStatu">PreferredVendorStatus</label>
            <br />
            {getFieldDecorator('preferredVendorStatu', {
              rules: [{ required: true, message: 'Required' }],
            })(
              <DatePicker
                format={'YYYY-MM-DD'}
                placeholder={'PreferredVendorStatus'}
              />
            )}
          </Form.Item>

          <Form.Item>
            <label htmlFor="purchasingWebServiceURL">
              PurchasingWebServiceURL
            </label>
            <br />
            {getFieldDecorator('purchasingWebServiceURL', {
              rules: [{ max: 1024, message: 'Exceeds max length of 1024' }],
            })(
              <DatePicker
                format={'YYYY-MM-DD'}
                placeholder={'PurchasingWebServiceURL'}
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

export const WrappedVendorEditComponent = Form.create({ name: 'Vendor Edit' })(
  VendorEditComponent
);


/*<Codenesium>
    <Hash>57192dab14b3d9183ba629bf0e48727a</Hash>
</Codenesium>*/