import React, { Component, FormEvent } from 'react';
import axios, { AxiosError, AxiosResponse } from 'axios';
import { ActionResponse, CreateResponse } from '../../api/apiObjects';
import { Constants, ApiRoutes, ClientRoutes } from '../../constants';
import * as Api from '../../api/models';
import TransactionHistoryMapper from './transactionHistoryMapper';
import TransactionHistoryViewModel from './transactionHistoryViewModel';
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
import { ProductSelectComponent } from '../shared/productSelect';
interface TransactionHistoryEditComponentProps {
  form: WrappedFormUtils;
  history: any;
  match: any;
}

interface TransactionHistoryEditComponentState {
  model?: TransactionHistoryViewModel;
  loading: boolean;
  loaded: boolean;
  errorOccurred: boolean;
  errorMessage: string;
  submitted: boolean;
  submitting: boolean;
}

class TransactionHistoryEditComponent extends React.Component<
  TransactionHistoryEditComponentProps,
  TransactionHistoryEditComponentState
> {
  state = {
    model: new TransactionHistoryViewModel(),
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
      .get<Api.TransactionHistoryClientResponseModel>(
        Constants.ApiEndpoint +
          ApiRoutes.TransactionHistories +
          '/' +
          this.props.match.params.id,
        {
          headers: GlobalUtilities.defaultHeaders(),
        }
      )
      .then(response => {
        GlobalUtilities.logInfo(response);

        let mapper = new TransactionHistoryMapper();

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
        let model = values as TransactionHistoryViewModel;
        this.submit(model);
      } else {
        this.setState({ ...this.state, submitting: false, submitted: false });
      }
    });
  };

  submit = (model: TransactionHistoryViewModel) => {
    let mapper = new TransactionHistoryMapper();
    axios
      .put<CreateResponse<Api.TransactionHistoryClientRequestModel>>(
        Constants.ApiEndpoint +
          ApiRoutes.TransactionHistories +
          '/' +
          this.state.model!.transactionID,
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
            <label htmlFor="actualCost">Actual Cost</label>
            <br />
            {getFieldDecorator('actualCost', {
              rules: [{ required: true, message: 'Required' }],
            })(<InputNumber placeholder={'Actual Cost'} />)}
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

          <ProductSelectComponent
            apiRoute={Constants.ApiEndpoint + ApiRoutes.Products}
            getFieldDecorator={this.props.form.getFieldDecorator}
            propertyName="productID"
            required={true}
            selectedValue={this.state.model!.productID}
          />

          <Form.Item>
            <label htmlFor="quantity">Quantity</label>
            <br />
            {getFieldDecorator('quantity', {
              rules: [{ required: true, message: 'Required' }],
            })(<InputNumber placeholder={'Quantity'} />)}
          </Form.Item>

          <Form.Item>
            <label htmlFor="referenceOrderID">Reference Order I D</label>
            <br />
            {getFieldDecorator('referenceOrderID', {
              rules: [{ required: true, message: 'Required' }],
            })(<InputNumber placeholder={'Reference Order I D'} />)}
          </Form.Item>

          <Form.Item>
            <label htmlFor="referenceOrderLineID">
              Reference Order Line I D
            </label>
            <br />
            {getFieldDecorator('referenceOrderLineID', {
              rules: [{ required: true, message: 'Required' }],
            })(<InputNumber placeholder={'Reference Order Line I D'} />)}
          </Form.Item>

          <Form.Item>
            <label htmlFor="transactionDate">Transaction Date</label>
            <br />
            {getFieldDecorator('transactionDate', {
              rules: [{ required: true, message: 'Required' }],
            })(
              <DatePicker
                format={'YYYY-MM-DD'}
                placeholder={'Transaction Date'}
              />
            )}
          </Form.Item>

          <Form.Item>
            <label htmlFor="transactionType">Transaction Type</label>
            <br />
            {getFieldDecorator('transactionType', {
              rules: [
                { required: true, message: 'Required' },
                { max: 1, message: 'Exceeds max length of 1' },
              ],
            })(<Input placeholder={'Transaction Type'} />)}
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

export const WrappedTransactionHistoryEditComponent = Form.create({
  name: 'TransactionHistory Edit',
})(TransactionHistoryEditComponent);


/*<Codenesium>
    <Hash>860ff86fb383d2dc3df70ffeebdfe701</Hash>
</Codenesium>*/