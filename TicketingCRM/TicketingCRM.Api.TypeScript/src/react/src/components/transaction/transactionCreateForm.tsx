import React, { Component, FormEvent } from 'react';
import axios from 'axios';
import { CreateResponse } from '../../api/apiObjects';
import { LoadingForm } from '../../lib/components/loadingForm';
import { ErrorForm } from '../../lib/components/errorForm';
import { Constants, ApiRoutes, ClientRoutes } from '../../constants';
import * as Api from '../../api/models';
import TransactionMapper from './transactionMapper';
import TransactionViewModel from './transactionViewModel';
import { Form, Input, Button, Checkbox, InputNumber, DatePicker } from 'antd';
import { WrappedFormUtils } from 'antd/es/form/Form';
import { Alert } from 'antd';

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
      return <LoadingForm />;
    } else if (this.state.loaded) {
      return (
        <Form onSubmit={this.handleSubmit}>
          <Form.Item>
            <label htmlFor="amount">amount</label>
            <br />
            {getFieldDecorator('amount', {
              rules: [],
            })(<InputNumber placeholder={'amount'} id={'amount'} />)}
          </Form.Item>

          <Form.Item>
            <label htmlFor="gatewayConfirmationNumber">
              gatewayConfirmationNumber
            </label>
            <br />
            {getFieldDecorator('gatewayConfirmationNumber', {
              rules: [],
            })(
              <Input
                placeholder={'gatewayConfirmationNumber'}
                id={'gatewayConfirmationNumber'}
              />
            )}
          </Form.Item>

          <Form.Item>
            <label htmlFor="transactionStatusId">transactionStatusId</label>
            <br />
            {getFieldDecorator('transactionStatusId', {
              rules: [],
            })(
              <Input
                placeholder={'transactionStatusId'}
                id={'transactionStatusId'}
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

export const WrappedTransactionCreateComponent = Form.create({
  name: 'Transaction Create',
})(TransactionCreateComponent);


/*<Codenesium>
    <Hash>b4b8449331c8e1cc40d1e28a5fae9f12</Hash>
</Codenesium>*/