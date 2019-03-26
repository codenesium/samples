import React, { Component, FormEvent } from 'react';
import axios, { AxiosError, AxiosResponse } from 'axios';
import { Constants, ApiRoutes, ClientRoutes } from '../../constants';
import * as Api from '../../api/models';
import SalesOrderHeaderMapper from './salesOrderHeaderMapper';
import SalesOrderHeaderViewModel from './salesOrderHeaderViewModel';
import { Form, Input, Button, Spin, Alert } from 'antd';
import { WrappedFormUtils } from 'antd/es/form/Form';
import * as GlobalUtilities from '../../lib/globalUtilities';
import { SalesOrderDetailTableComponent } from '../shared/salesOrderDetailTable';
import { SalesOrderHeaderSalesReasonTableComponent } from '../shared/salesOrderHeaderSalesReasonTable';

interface SalesOrderHeaderDetailComponentProps {
  form: WrappedFormUtils;
  history: any;
  match: any;
}

interface SalesOrderHeaderDetailComponentState {
  model?: SalesOrderHeaderViewModel;
  loading: boolean;
  loaded: boolean;
  errorOccurred: boolean;
  errorMessage: string;
}

class SalesOrderHeaderDetailComponent extends React.Component<
  SalesOrderHeaderDetailComponentProps,
  SalesOrderHeaderDetailComponentState
> {
  state = {
    model: new SalesOrderHeaderViewModel(),
    loading: false,
    loaded: true,
    errorOccurred: false,
    errorMessage: '',
  };

  handleEditClick(e: any) {
    this.props.history.push(
      ClientRoutes.SalesOrderHeaders + '/edit/' + this.state.model!.salesOrderID
    );
  }

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
      })
      .catch((error: AxiosError) => {
        GlobalUtilities.logError(error);

        if (error.response && error.response.status == 422) {
          this.setState({
            ...this.state,
            errorOccurred: false,
            errorMessage: '',
          });
        } else {
          this.setState({
            ...this.state,
            errorOccurred: true,
            errorMessage: 'Error Occurred',
          });
        }
      });
  }

  render() {
    let message: JSX.Element = <div />;
    if (this.state.errorOccurred) {
      message = <Alert message={this.state.errorMessage} type="error" />;
    }

    if (this.state.loading) {
      return <Spin size="large" />;
    } else if (this.state.loaded) {
      return (
        <div>
          <Button
            style={{ float: 'right' }}
            type="primary"
            onClick={(e: any) => {
              this.handleEditClick(e);
            }}
          >
            <i className="fas fa-edit" />
          </Button>
          <div>
            <div>
              <h3>Account Number</h3>
              <p>{String(this.state.model!.accountNumber)}</p>
            </div>
            <div>
              <h3>Bill To Address I D</h3>
              <p>{String(this.state.model!.billToAddressID)}</p>
            </div>
            <div>
              <h3>Comment</h3>
              <p>{String(this.state.model!.comment)}</p>
            </div>
            <div>
              <h3>Credit Card Approval Code</h3>
              <p>{String(this.state.model!.creditCardApprovalCode)}</p>
            </div>
            <div style={{ marginBottom: '10px' }}>
              <h3>Credit Card I D</h3>
              <p>
                {String(
                  this.state.model!.creditCardIDNavigation &&
                    this.state.model!.creditCardIDNavigation!.toDisplay()
                )}
              </p>
            </div>
            <div style={{ marginBottom: '10px' }}>
              <h3>Currency Rate I D</h3>
              <p>
                {String(
                  this.state.model!.currencyRateIDNavigation &&
                    this.state.model!.currencyRateIDNavigation!.toDisplay()
                )}
              </p>
            </div>
            <div style={{ marginBottom: '10px' }}>
              <h3>Customer I D</h3>
              <p>
                {String(
                  this.state.model!.customerIDNavigation &&
                    this.state.model!.customerIDNavigation!.toDisplay()
                )}
              </p>
            </div>
            <div>
              <h3>Due Date</h3>
              <p>{String(this.state.model!.dueDate)}</p>
            </div>
            <div>
              <h3>Freight</h3>
              <p>{String(this.state.model!.freight)}</p>
            </div>
            <div>
              <h3>Modified Date</h3>
              <p>{String(this.state.model!.modifiedDate)}</p>
            </div>
            <div>
              <h3>Online Order Flag</h3>
              <p>{String(this.state.model!.onlineOrderFlag)}</p>
            </div>
            <div>
              <h3>Order Date</h3>
              <p>{String(this.state.model!.orderDate)}</p>
            </div>
            <div>
              <h3>Purchase Order Number</h3>
              <p>{String(this.state.model!.purchaseOrderNumber)}</p>
            </div>
            <div>
              <h3>Revision Number</h3>
              <p>{String(this.state.model!.revisionNumber)}</p>
            </div>
            <div>
              <h3>Rowguid</h3>
              <p>{String(this.state.model!.rowguid)}</p>
            </div>
            <div>
              <h3>Sales Order Number</h3>
              <p>{String(this.state.model!.salesOrderNumber)}</p>
            </div>
            <div style={{ marginBottom: '10px' }}>
              <h3>Sales Person I D</h3>
              <p>
                {String(
                  this.state.model!.salesPersonIDNavigation &&
                    this.state.model!.salesPersonIDNavigation!.toDisplay()
                )}
              </p>
            </div>
            <div>
              <h3>Ship Date</h3>
              <p>{String(this.state.model!.shipDate)}</p>
            </div>
            <div>
              <h3>Ship Method I D</h3>
              <p>{String(this.state.model!.shipMethodID)}</p>
            </div>
            <div>
              <h3>Ship To Address I D</h3>
              <p>{String(this.state.model!.shipToAddressID)}</p>
            </div>
            <div>
              <h3>Status</h3>
              <p>{String(this.state.model!.status)}</p>
            </div>
            <div>
              <h3>Sub Total</h3>
              <p>{String(this.state.model!.subTotal)}</p>
            </div>
            <div>
              <h3>Tax Amt</h3>
              <p>{String(this.state.model!.taxAmt)}</p>
            </div>
            <div style={{ marginBottom: '10px' }}>
              <h3>Territory I D</h3>
              <p>
                {String(
                  this.state.model!.territoryIDNavigation &&
                    this.state.model!.territoryIDNavigation!.toDisplay()
                )}
              </p>
            </div>
            <div>
              <h3>Total Due</h3>
              <p>{String(this.state.model!.totalDue)}</p>
            </div>
          </div>
          {message}
          <div>
            <h3>SalesOrderDetails</h3>
            <SalesOrderDetailTableComponent
              history={this.props.history}
              match={this.props.match}
              apiRoute={
                Constants.ApiEndpoint +
                ApiRoutes.SalesOrderHeaders +
                '/' +
                this.state.model!.salesOrderID +
                '/' +
                ApiRoutes.SalesOrderDetails
              }
            />
          </div>
          <div>
            <h3>SalesOrderHeaderSalesReasons</h3>
            <SalesOrderHeaderSalesReasonTableComponent
              history={this.props.history}
              match={this.props.match}
              apiRoute={
                Constants.ApiEndpoint +
                ApiRoutes.SalesOrderHeaders +
                '/' +
                this.state.model!.salesOrderID +
                '/' +
                ApiRoutes.SalesOrderHeaderSalesReasons
              }
            />
          </div>
        </div>
      );
    } else {
      return null;
    }
  }
}

export const WrappedSalesOrderHeaderDetailComponent = Form.create({
  name: 'SalesOrderHeader Detail',
})(SalesOrderHeaderDetailComponent);


/*<Codenesium>
    <Hash>6afe5a4bfb03cae3771c90222f5ce088</Hash>
</Codenesium>*/