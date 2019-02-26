import React, { Component, FormEvent } from 'react';
import axios from 'axios';
import { CreateResponse } from '../../api/apiObjects';
import { Constants, ApiRoutes, ClientRoutes } from '../../constants';
import * as Api from '../../api/models';
import TransactionMapper from './transactionMapper';
import TransactionViewModel from './transactionViewModel';
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
import { TransactionStatusSelectComponent } from '../shared/transactionStatusSelect';

interface TransactionCreateComponentProps {
  form: WrappedFormUtils;
  history: any;
  match: any;
}

interface TransactionCreateComponentState {
  model?: TransactionViewModel;
  loading: boolean;
  loaded: boolean;
  errorOccurred: boolean;
  errorMessage: string;
  submitted: boolean;
}

class TransactionCreateComponent extends React.Component<
  TransactionCreateComponentProps,
  TransactionCreateComponentState
> {
  state = {
    model: new TransactionViewModel(),
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
        let model = values as TransactionViewModel;
        console.log('Received values of form: ', model);
        this.submit(model);
      }
    });
  };

  submit = (model: TransactionViewModel) => {
    let mapper = new TransactionMapper();
    axios
      .post(
        Constants.ApiEndpoint + ApiRoutes.Transactions,
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
            Api.TransactionClientRequestModel
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
              rules: [{ required: true, message: 'Required' }],
            })(<InputNumber placeholder={'amount'} />)}
          </Form.Item>

          <Form.Item>
            <label htmlFor="gatewayConfirmationNumber">
              gatewayConfirmationNumber
            </label>
            <br />
            {getFieldDecorator('gatewayConfirmationNumber', {
              rules: [
                { required: true, message: 'Required' },
                { max: 1, message: 'Exceeds max length of 1' },
              ],
            })(<Input placeholder={'gatewayConfirmationNumber'} />)}
          </Form.Item>

          <Form.Item>
            <label htmlFor="transactionStatusId">transactionStatusId</label>
            <br />
            {getFieldDecorator('transactionStatusId', {
              rules: [{ required: true, message: 'Required' }],
            })(<Input placeholder={'transactionStatusId'} />)}
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

export const WrappedTransactionCreateComponent = Form.create({
  name: 'Transaction Create',
})(TransactionCreateComponent);


/*<Codenesium>
    <Hash>34f7fdcf17612f37684242f38b72a707</Hash>
</Codenesium>*/