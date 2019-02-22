import React, { Component, FormEvent } from 'react';
import axios from 'axios';
import { CreateResponse } from '../../api/apiObjects';
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

interface SalesOrderHeaderCreateComponentProps {
  form: WrappedFormUtils;
  history: any;
  match: any;
}

interface SalesOrderHeaderCreateComponentState {
  model?: SalesOrderHeaderViewModel;
  loading: boolean;
  loaded: boolean;
  errorOccurred: boolean;
  errorMessage: string;
  submitted: boolean;
}

class SalesOrderHeaderCreateComponent extends React.Component<
  SalesOrderHeaderCreateComponentProps,
  SalesOrderHeaderCreateComponentState
> {
  state = {
    model: new SalesOrderHeaderViewModel(),
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
        let model = values as SalesOrderHeaderViewModel;
        console.log('Received values of form: ', model);
        this.submit(model);
      }
    });
  };

  submit = (model: SalesOrderHeaderViewModel) => {
    let mapper = new SalesOrderHeaderMapper();
    axios
      .post(
        Constants.ApiEndpoint + ApiRoutes.SalesOrderHeaders,
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
            Api.SalesOrderHeaderClientRequestModel
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
              rules: [{ max: 15, message: 'Exceeds max length of 15' }],
            })(
              <DatePicker format={'YYYY-MM-DD'} placeholder={'AccountNumber'} />
            )}
          </Form.Item>

          <Form.Item>
            <label htmlFor="billToAddressID">BillToAddressID</label>
            <br />
            {getFieldDecorator('billToAddressID', {
              rules: [{ required: true, message: 'Required' }],
            })(
              <DatePicker
                format={'YYYY-MM-DD'}
                placeholder={'BillToAddressID'}
              />
            )}
          </Form.Item>

          <Form.Item>
            <label htmlFor="comment">Comment</label>
            <br />
            {getFieldDecorator('comment', {
              rules: [{ max: 128, message: 'Exceeds max length of 128' }],
            })(<DatePicker format={'YYYY-MM-DD'} placeholder={'Comment'} />)}
          </Form.Item>

          <Form.Item>
            <label htmlFor="creditCardApprovalCode">
              CreditCardApprovalCode
            </label>
            <br />
            {getFieldDecorator('creditCardApprovalCode', {
              rules: [{ max: 15, message: 'Exceeds max length of 15' }],
            })(
              <DatePicker
                format={'YYYY-MM-DD'}
                placeholder={'CreditCardApprovalCode'}
              />
            )}
          </Form.Item>

          <Form.Item>
            <label htmlFor="creditCardID">CreditCardID</label>
            <br />
            {getFieldDecorator('creditCardID', {
              rules: [],
            })(
              <DatePicker format={'YYYY-MM-DD'} placeholder={'CreditCardID'} />
            )}
          </Form.Item>

          <Form.Item>
            <label htmlFor="currencyRateID">CurrencyRateID</label>
            <br />
            {getFieldDecorator('currencyRateID', {
              rules: [],
            })(
              <DatePicker
                format={'YYYY-MM-DD'}
                placeholder={'CurrencyRateID'}
              />
            )}
          </Form.Item>

          <Form.Item>
            <label htmlFor="customerID">CustomerID</label>
            <br />
            {getFieldDecorator('customerID', {
              rules: [{ required: true, message: 'Required' }],
            })(<DatePicker format={'YYYY-MM-DD'} placeholder={'CustomerID'} />)}
          </Form.Item>

          <Form.Item>
            <label htmlFor="dueDate">DueDate</label>
            <br />
            {getFieldDecorator('dueDate', {
              rules: [{ required: true, message: 'Required' }],
            })(<DatePicker format={'YYYY-MM-DD'} placeholder={'DueDate'} />)}
          </Form.Item>

          <Form.Item>
            <label htmlFor="freight">Freight</label>
            <br />
            {getFieldDecorator('freight', {
              rules: [{ required: true, message: 'Required' }],
            })(<DatePicker format={'YYYY-MM-DD'} placeholder={'Freight'} />)}
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
            <label htmlFor="onlineOrderFlag">OnlineOrderFlag</label>
            <br />
            {getFieldDecorator('onlineOrderFlag', {
              rules: [{ required: true, message: 'Required' }],
            })(
              <DatePicker
                format={'YYYY-MM-DD'}
                placeholder={'OnlineOrderFlag'}
              />
            )}
          </Form.Item>

          <Form.Item>
            <label htmlFor="orderDate">OrderDate</label>
            <br />
            {getFieldDecorator('orderDate', {
              rules: [{ required: true, message: 'Required' }],
            })(<DatePicker format={'YYYY-MM-DD'} placeholder={'OrderDate'} />)}
          </Form.Item>

          <Form.Item>
            <label htmlFor="purchaseOrderNumber">PurchaseOrderNumber</label>
            <br />
            {getFieldDecorator('purchaseOrderNumber', {
              rules: [{ max: 25, message: 'Exceeds max length of 25' }],
            })(
              <DatePicker
                format={'YYYY-MM-DD'}
                placeholder={'PurchaseOrderNumber'}
              />
            )}
          </Form.Item>

          <Form.Item>
            <label htmlFor="revisionNumber">RevisionNumber</label>
            <br />
            {getFieldDecorator('revisionNumber', {
              rules: [{ required: true, message: 'Required' }],
            })(
              <DatePicker
                format={'YYYY-MM-DD'}
                placeholder={'RevisionNumber'}
              />
            )}
          </Form.Item>

          <Form.Item>
            <label htmlFor="rowguid">rowguid</label>
            <br />
            {getFieldDecorator('rowguid', {
              rules: [{ required: true, message: 'Required' }],
            })(<DatePicker format={'YYYY-MM-DD'} placeholder={'rowguid'} />)}
          </Form.Item>

          <Form.Item>
            <label htmlFor="salesOrderNumber">SalesOrderNumber</label>
            <br />
            {getFieldDecorator('salesOrderNumber', {
              rules: [
                { required: true, message: 'Required' },
                { max: 25, message: 'Exceeds max length of 25' },
              ],
            })(
              <DatePicker
                format={'YYYY-MM-DD'}
                placeholder={'SalesOrderNumber'}
              />
            )}
          </Form.Item>

          <Form.Item>
            <label htmlFor="salesPersonID">SalesPersonID</label>
            <br />
            {getFieldDecorator('salesPersonID', {
              rules: [],
            })(
              <DatePicker format={'YYYY-MM-DD'} placeholder={'SalesPersonID'} />
            )}
          </Form.Item>

          <Form.Item>
            <label htmlFor="shipDate">ShipDate</label>
            <br />
            {getFieldDecorator('shipDate', {
              rules: [],
            })(<DatePicker format={'YYYY-MM-DD'} placeholder={'ShipDate'} />)}
          </Form.Item>

          <Form.Item>
            <label htmlFor="shipMethodID">ShipMethodID</label>
            <br />
            {getFieldDecorator('shipMethodID', {
              rules: [{ required: true, message: 'Required' }],
            })(
              <DatePicker format={'YYYY-MM-DD'} placeholder={'ShipMethodID'} />
            )}
          </Form.Item>

          <Form.Item>
            <label htmlFor="shipToAddressID">ShipToAddressID</label>
            <br />
            {getFieldDecorator('shipToAddressID', {
              rules: [{ required: true, message: 'Required' }],
            })(
              <DatePicker
                format={'YYYY-MM-DD'}
                placeholder={'ShipToAddressID'}
              />
            )}
          </Form.Item>

          <Form.Item>
            <label htmlFor="status">Status</label>
            <br />
            {getFieldDecorator('status', {
              rules: [{ required: true, message: 'Required' }],
            })(<DatePicker format={'YYYY-MM-DD'} placeholder={'Status'} />)}
          </Form.Item>

          <Form.Item>
            <label htmlFor="subTotal">SubTotal</label>
            <br />
            {getFieldDecorator('subTotal', {
              rules: [{ required: true, message: 'Required' }],
            })(<DatePicker format={'YYYY-MM-DD'} placeholder={'SubTotal'} />)}
          </Form.Item>

          <Form.Item>
            <label htmlFor="taxAmt">TaxAmt</label>
            <br />
            {getFieldDecorator('taxAmt', {
              rules: [{ required: true, message: 'Required' }],
            })(<DatePicker format={'YYYY-MM-DD'} placeholder={'TaxAmt'} />)}
          </Form.Item>

          <Form.Item>
            <label htmlFor="territoryID">TerritoryID</label>
            <br />
            {getFieldDecorator('territoryID', {
              rules: [],
            })(
              <DatePicker format={'YYYY-MM-DD'} placeholder={'TerritoryID'} />
            )}
          </Form.Item>

          <Form.Item>
            <label htmlFor="totalDue">TotalDue</label>
            <br />
            {getFieldDecorator('totalDue', {
              rules: [{ required: true, message: 'Required' }],
            })(<DatePicker format={'YYYY-MM-DD'} placeholder={'TotalDue'} />)}
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

export const WrappedSalesOrderHeaderCreateComponent = Form.create({
  name: 'SalesOrderHeader Create',
})(SalesOrderHeaderCreateComponent);


/*<Codenesium>
    <Hash>64a2a9d527cba218e0687f58c2942851</Hash>
</Codenesium>*/