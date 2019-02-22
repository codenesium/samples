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

interface TransactionEditComponentProps {
  form: WrappedFormUtils;
  history: any;
  match: any;
}

interface TransactionEditComponentState {
  model?: TransactionViewModel;
  loading: boolean;
  loaded: boolean;
  errorOccurred: boolean;
  errorMessage: string;
  submitted: boolean;
}

class TransactionEditComponent extends React.Component<
  TransactionEditComponentProps,
  TransactionEditComponentState
> {
  state = {
    model: new TransactionViewModel(),
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
          ApiRoutes.Transactions +
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
          let response = resp.data as Api.TransactionClientResponseModel;

          console.log(response);

          let mapper = new TransactionMapper();

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
        let model = values as TransactionViewModel;
        console.log('Received values of form: ', model);
        this.submit(model);
      }
    });
  };

  submit = (model: TransactionViewModel) => {
    let mapper = new TransactionMapper();
    axios
      .put(
        Constants.ApiEndpoint +
          ApiRoutes.Transactions +
          '/' +
          this.state.model!.id,
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

export const WrappedTransactionEditComponent = Form.create({
  name: 'Transaction Edit',
})(TransactionEditComponent);


/*<Codenesium>
    <Hash>9ccb90c6cdbbe02a7ad22078eb44e4cf</Hash>
</Codenesium>*/