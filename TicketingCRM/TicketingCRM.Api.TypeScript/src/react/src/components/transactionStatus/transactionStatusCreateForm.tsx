import React, { Component, FormEvent } from 'react';
import axios from 'axios';
import { CreateResponse } from '../../api/apiObjects';
import { LoadingForm } from '../../lib/components/loadingForm';
import { ErrorForm } from '../../lib/components/errorForm';
import { Constants, ApiRoutes, ClientRoutes } from '../../constants';
import * as Api from '../../api/models';
import TransactionStatusMapper from './transactionStatusMapper';
import TransactionStatusViewModel from './transactionStatusViewModel';
import { Form, Input, Button, Checkbox, InputNumber, DatePicker } from 'antd';
import { WrappedFormUtils } from 'antd/es/form/Form';
import { Alert } from 'antd';

interface TransactionStatusCreateComponentProps {
  form: WrappedFormUtils;
  history: any;
  match: any;
}

interface TransactionStatusCreateComponentState {
  model?: TransactionStatusViewModel;
  loading: boolean;
  loaded: boolean;
  errorOccurred: boolean;
  errorMessage: string;
  submitted: boolean;
}

class TransactionStatusCreateComponent extends React.Component<
  TransactionStatusCreateComponentProps,
  TransactionStatusCreateComponentState
> {
  state = {
    model: new TransactionStatusViewModel(),
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
        let model = values as TransactionStatusViewModel;
        console.log('Received values of form: ', model);
        this.submit(model);
      }
    });
  };

  submit = (model: TransactionStatusViewModel) => {
    let mapper = new TransactionStatusMapper();
    axios
      .post(
        Constants.ApiEndpoint + ApiRoutes.TransactionStatus,
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
            Api.TransactionStatusClientRequestModel
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
            <label htmlFor="name">name</label>
            <br />
            {getFieldDecorator('name', {
              rules: [],
            })(<Input placeholder={'name'} id={'name'} />)}
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

export const WrappedTransactionStatusCreateComponent = Form.create({
  name: 'TransactionStatus Create',
})(TransactionStatusCreateComponent);


/*<Codenesium>
    <Hash>6bb78e550531191d22d9f84d81290f6a</Hash>
</Codenesium>*/