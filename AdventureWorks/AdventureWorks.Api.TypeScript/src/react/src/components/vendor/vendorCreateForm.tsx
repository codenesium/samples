import React, { Component, FormEvent } from 'react';
import axios from 'axios';
import { CreateResponse } from '../../api/apiObjects';
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

interface VendorCreateComponentProps {
  form: WrappedFormUtils;
  history: any;
  match: any;
}

interface VendorCreateComponentState {
  model?: VendorViewModel;
  loading: boolean;
  loaded: boolean;
  errorOccurred: boolean;
  errorMessage: string;
  submitted: boolean;
}

class VendorCreateComponent extends React.Component<
  VendorCreateComponentProps,
  VendorCreateComponentState
> {
  state = {
    model: new VendorViewModel(),
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
        let model = values as VendorViewModel;
        console.log('Received values of form: ', model);
        this.submit(model);
      }
    });
  };

  submit = (model: VendorViewModel) => {
    let mapper = new VendorMapper();
    axios
      .post(
        Constants.ApiEndpoint + ApiRoutes.Vendors,
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

export const WrappedVendorCreateComponent = Form.create({
  name: 'Vendor Create',
})(VendorCreateComponent);


/*<Codenesium>
    <Hash>a4852a8e9204a5a9dac075ace017311c</Hash>
</Codenesium>*/