import React, { Component, FormEvent } from 'react';
import axios, { AxiosError, AxiosResponse } from 'axios';
import { ActionResponse, CreateResponse } from '../../api/apiObjects';
import { Constants, ApiRoutes, ClientRoutes } from '../../constants';
import * as Api from '../../api/models';
import SalesOrderHeaderMapper from './salesOrderHeaderMapper';
import SalesOrderHeaderViewModel from './salesOrderHeaderViewModel';
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
import { CreditCardSelectComponent } from '../shared/creditCardSelect';
import { CurrencyRateSelectComponent } from '../shared/currencyRateSelect';
import { CustomerSelectComponent } from '../shared/customerSelect';
import { SalesPersonSelectComponent } from '../shared/salesPersonSelect';
import { SalesTerritorySelectComponent } from '../shared/salesTerritorySelect';
interface SalesOrderHeaderEditComponentProps {
  form: WrappedFormUtils;
  history: any;
  match: any;
}

interface SalesOrderHeaderEditComponentState {
  model?: SalesOrderHeaderViewModel;
  loading: boolean;
  loaded: boolean;
  errorOccurred: boolean;
  errorMessage: string;
  submitted: boolean;
  submitting: boolean;
}

class SalesOrderHeaderEditComponent extends React.Component<
  SalesOrderHeaderEditComponentProps,
  SalesOrderHeaderEditComponentState
> {
  state = {
    model: new SalesOrderHeaderViewModel(),
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
      .get<Api.SalesOrderHeaderClientResponseModel>(
        Constants.ApiEndpoint +
          ApiRoutes.SalesOrderHeaders +
          '/' +
          this.props.match.params.id,
        {
          headers: GlobalUtilities.defaultHeaders(),
        }
      )
      .then(response => {
        GlobalUtilities.logInfo(response);

        let mapper = new SalesOrderHeaderMapper();

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
        let model = values as SalesOrderHeaderViewModel;
        this.submit(model);
      } else {
        this.setState({ ...this.state, submitting: false, submitted: false });
      }
    });
  };

  submit = (model: SalesOrderHeaderViewModel) => {
    let mapper = new SalesOrderHeaderMapper();
    axios
      .put<CreateResponse<Api.SalesOrderHeaderClientRequestModel>>(
        Constants.ApiEndpoint +
          ApiRoutes.SalesOrderHeaders +
          '/' +
          this.state.model!.salesOrderID,
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
            <label htmlFor="accountNumber">Account Number</label>
            <br />
            {getFieldDecorator('accountNumber', {
              rules: [{ max: 15, message: 'Exceeds max length of 15' }],
            })(<Input placeholder={'Account Number'} />)}
          </Form.Item>

          <Form.Item>
            <label htmlFor="billToAddressID">Bill To Address I D</label>
            <br />
            {getFieldDecorator('billToAddressID', {
              rules: [{ required: true, message: 'Required' }],
            })(<InputNumber placeholder={'Bill To Address I D'} />)}
          </Form.Item>

          <Form.Item>
            <label htmlFor="comment">Comment</label>
            <br />
            {getFieldDecorator('comment', {
              rules: [{ max: 128, message: 'Exceeds max length of 128' }],
            })(<Input placeholder={'Comment'} />)}
          </Form.Item>

          <Form.Item>
            <label htmlFor="creditCardApprovalCode">
              Credit Card Approval Code
            </label>
            <br />
            {getFieldDecorator('creditCardApprovalCode', {
              rules: [{ max: 15, message: 'Exceeds max length of 15' }],
            })(<Input placeholder={'Credit Card Approval Code'} />)}
          </Form.Item>

          <CreditCardSelectComponent
            apiRoute={Constants.ApiEndpoint + ApiRoutes.CreditCards}
            getFieldDecorator={this.props.form.getFieldDecorator}
            propertyName="creditCardID"
            required={false}
            selectedValue={this.state.model!.creditCardID}
          />

          <CurrencyRateSelectComponent
            apiRoute={Constants.ApiEndpoint + ApiRoutes.CurrencyRates}
            getFieldDecorator={this.props.form.getFieldDecorator}
            propertyName="currencyRateID"
            required={false}
            selectedValue={this.state.model!.currencyRateID}
          />

          <CustomerSelectComponent
            apiRoute={Constants.ApiEndpoint + ApiRoutes.Customers}
            getFieldDecorator={this.props.form.getFieldDecorator}
            propertyName="customerID"
            required={true}
            selectedValue={this.state.model!.customerID}
          />

          <Form.Item>
            <label htmlFor="dueDate">Due Date</label>
            <br />
            {getFieldDecorator('dueDate', {
              rules: [{ required: true, message: 'Required' }],
            })(<DatePicker format={'YYYY-MM-DD'} placeholder={'Due Date'} />)}
          </Form.Item>

          <Form.Item>
            <label htmlFor="freight">Freight</label>
            <br />
            {getFieldDecorator('freight', {
              rules: [{ required: true, message: 'Required' }],
            })(<InputNumber placeholder={'Freight'} />)}
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
            <label htmlFor="onlineOrderFlag">Online Order Flag</label>
            <br />
            {getFieldDecorator('onlineOrderFlag', {
              rules: [],
              valuePropName: 'checked',
            })(<Switch />)}
          </Form.Item>

          <Form.Item>
            <label htmlFor="orderDate">Order Date</label>
            <br />
            {getFieldDecorator('orderDate', {
              rules: [{ required: true, message: 'Required' }],
            })(<DatePicker format={'YYYY-MM-DD'} placeholder={'Order Date'} />)}
          </Form.Item>

          <Form.Item>
            <label htmlFor="purchaseOrderNumber">Purchase Order Number</label>
            <br />
            {getFieldDecorator('purchaseOrderNumber', {
              rules: [{ max: 25, message: 'Exceeds max length of 25' }],
            })(<Input placeholder={'Purchase Order Number'} />)}
          </Form.Item>

          <Form.Item>
            <label htmlFor="revisionNumber">Revision Number</label>
            <br />
            {getFieldDecorator('revisionNumber', {
              rules: [{ required: true, message: 'Required' }],
            })(<InputNumber placeholder={'Revision Number'} />)}
          </Form.Item>

          <Form.Item>
            <label htmlFor="rowguid">Rowguid</label>
            <br />
            {getFieldDecorator('rowguid', {
              rules: [{ required: true, message: 'Required' }],
            })(<Input placeholder={'Rowguid'} />)}
          </Form.Item>

          <Form.Item>
            <label htmlFor="salesOrderNumber">Sales Order Number</label>
            <br />
            {getFieldDecorator('salesOrderNumber', {
              rules: [
                { required: true, message: 'Required' },
                { max: 25, message: 'Exceeds max length of 25' },
              ],
            })(<Input placeholder={'Sales Order Number'} />)}
          </Form.Item>

          <SalesPersonSelectComponent
            apiRoute={Constants.ApiEndpoint + ApiRoutes.SalesPersons}
            getFieldDecorator={this.props.form.getFieldDecorator}
            propertyName="salesPersonID"
            required={false}
            selectedValue={this.state.model!.salesPersonID}
          />

          <Form.Item>
            <label htmlFor="shipDate">Ship Date</label>
            <br />
            {getFieldDecorator('shipDate', {
              rules: [],
            })(<DatePicker format={'YYYY-MM-DD'} placeholder={'Ship Date'} />)}
          </Form.Item>

          <Form.Item>
            <label htmlFor="shipMethodID">Ship Method I D</label>
            <br />
            {getFieldDecorator('shipMethodID', {
              rules: [{ required: true, message: 'Required' }],
            })(<InputNumber placeholder={'Ship Method I D'} />)}
          </Form.Item>

          <Form.Item>
            <label htmlFor="shipToAddressID">Ship To Address I D</label>
            <br />
            {getFieldDecorator('shipToAddressID', {
              rules: [{ required: true, message: 'Required' }],
            })(<InputNumber placeholder={'Ship To Address I D'} />)}
          </Form.Item>

          <Form.Item>
            <label htmlFor="status">Status</label>
            <br />
            {getFieldDecorator('status', {
              rules: [{ required: true, message: 'Required' }],
            })(<InputNumber placeholder={'Status'} />)}
          </Form.Item>

          <Form.Item>
            <label htmlFor="subTotal">Sub Total</label>
            <br />
            {getFieldDecorator('subTotal', {
              rules: [{ required: true, message: 'Required' }],
            })(<InputNumber placeholder={'Sub Total'} />)}
          </Form.Item>

          <Form.Item>
            <label htmlFor="taxAmt">Tax Amt</label>
            <br />
            {getFieldDecorator('taxAmt', {
              rules: [{ required: true, message: 'Required' }],
            })(<InputNumber placeholder={'Tax Amt'} />)}
          </Form.Item>

          <SalesTerritorySelectComponent
            apiRoute={Constants.ApiEndpoint + ApiRoutes.SalesTerritories}
            getFieldDecorator={this.props.form.getFieldDecorator}
            propertyName="territoryID"
            required={false}
            selectedValue={this.state.model!.territoryID}
          />

          <Form.Item>
            <label htmlFor="totalDue">Total Due</label>
            <br />
            {getFieldDecorator('totalDue', {
              rules: [{ required: true, message: 'Required' }],
            })(<InputNumber placeholder={'Total Due'} />)}
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

export const WrappedSalesOrderHeaderEditComponent = Form.create({
  name: 'SalesOrderHeader Edit',
})(SalesOrderHeaderEditComponent);


/*<Codenesium>
    <Hash>5cc257707624e1fc6137489ef8ac2af3</Hash>
</Codenesium>*/