import React, { Component, FormEvent } from 'react';
import axios from 'axios';
import { CreateResponse } from '../../api/apiObjects';
import { Constants, ApiRoutes, ClientRoutes } from '../../constants';
import * as Api from '../../api/models';
import SaleMapper from './saleMapper';
import SaleViewModel from './saleViewModel';
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

interface SaleCreateComponentProps {
  form: WrappedFormUtils;
  history: any;
  match: any;
}

interface SaleCreateComponentState {
  model?: SaleViewModel;
  loading: boolean;
  loaded: boolean;
  errorOccurred: boolean;
  errorMessage: string;
  submitted: boolean;
}

class SaleCreateComponent extends React.Component<
  SaleCreateComponentProps,
  SaleCreateComponentState
> {
  state = {
    model: new SaleViewModel(),
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
        let model = values as SaleViewModel;
        console.log('Received values of form: ', model);
        this.submit(model);
      }
    });
  };

  submit = (model: SaleViewModel) => {
    let mapper = new SaleMapper();
    axios
      .post(
        Constants.ApiEndpoint + ApiRoutes.Sales,
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
            Api.SaleClientRequestModel
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
            <label htmlFor="amount">amount</label>
            <br />
            {getFieldDecorator('amount', {
              rules: [],
            })(<Input placeholder={'amount'} id={'amount'} />)}
          </Form.Item>

          <Form.Item>
            <label htmlFor="firstName">firstName</label>
            <br />
            {getFieldDecorator('firstName', {
              rules: [],
            })(<Input placeholder={'firstName'} id={'firstName'} />)}
          </Form.Item>

          <Form.Item>
            <label htmlFor="lastName">lastName</label>
            <br />
            {getFieldDecorator('lastName', {
              rules: [],
            })(<Input placeholder={'lastName'} id={'lastName'} />)}
          </Form.Item>

          <Form.Item>
            <label htmlFor="paymentTypeId">paymentTypeId</label>
            <br />
            {getFieldDecorator('paymentTypeId', {
              rules: [],
            })(<Input placeholder={'paymentTypeId'} id={'paymentTypeId'} />)}
          </Form.Item>

          <Form.Item>
            <label htmlFor="petId">petId</label>
            <br />
            {getFieldDecorator('petId', {
              rules: [],
            })(<Input placeholder={'petId'} id={'petId'} />)}
          </Form.Item>

          <Form.Item>
            <label htmlFor="phone">phone</label>
            <br />
            {getFieldDecorator('phone', {
              rules: [],
            })(<Input placeholder={'phone'} id={'phone'} />)}
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

export const WrappedSaleCreateComponent = Form.create({ name: 'Sale Create' })(
  SaleCreateComponent
);


/*<Codenesium>
    <Hash>3666ea9e8c0f82122852b1d03dc4a343</Hash>
</Codenesium>*/