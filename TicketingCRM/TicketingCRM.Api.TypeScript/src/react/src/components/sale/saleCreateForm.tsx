import React, { Component, FormEvent } from 'react';
import axios from 'axios';
import { CreateResponse } from '../../api/apiObjects';
import { LoadingForm } from '../../lib/components/loadingForm';
import { ErrorForm } from '../../lib/components/errorForm';
import { Constants, ApiRoutes, ClientRoutes } from '../../constants';
import * as Api from '../../api/models';
import SaleMapper from './saleMapper';
import SaleViewModel from './saleViewModel';
import { Form, Input, Button, Checkbox, InputNumber, DatePicker } from 'antd';
import { WrappedFormUtils } from 'antd/es/form/Form';
import { Alert } from 'antd';

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
      return <LoadingForm />;
    } else if (this.state.loaded) {
      return (
        <Form onSubmit={this.handleSubmit}>
          <Form.Item>
            <label htmlFor="ipAddress">ipAddress</label>
            <br />
            {getFieldDecorator('ipAddress', {
              rules: [],
            })(<Input placeholder={'ipAddress'} id={'ipAddress'} />)}
          </Form.Item>

          <Form.Item>
            <label htmlFor="note">notes</label>
            <br />
            {getFieldDecorator('note', {
              rules: [],
            })(<Input placeholder={'notes'} id={'note'} />)}
          </Form.Item>

          <Form.Item>
            <label htmlFor="saleDate">saleDate</label>
            <br />
            {getFieldDecorator('saleDate', {
              rules: [],
            })(<DatePicker placeholder={'saleDate'} id={'saleDate'} />)}
          </Form.Item>

          <Form.Item>
            <label htmlFor="transactionId">transactionId</label>
            <br />
            {getFieldDecorator('transactionId', {
              rules: [],
            })(<Input placeholder={'transactionId'} id={'transactionId'} />)}
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
    <Hash>27a6a2ac92baa75e22396c1e5b9d89e6</Hash>
</Codenesium>*/