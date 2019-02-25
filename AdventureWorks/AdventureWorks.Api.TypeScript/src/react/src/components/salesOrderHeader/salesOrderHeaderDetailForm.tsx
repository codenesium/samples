import React, { Component, FormEvent } from 'react';
import axios from 'axios';
import { Constants, ApiRoutes, ClientRoutes } from '../../constants';
import * as Api from '../../api/models';
import SalesOrderHeaderMapper from './salesOrderHeaderMapper';
import SalesOrderHeaderViewModel from './salesOrderHeaderViewModel';
import { Form, Input, Button, Spin, Alert } from 'antd';
import { WrappedFormUtils } from 'antd/es/form/Form';
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
      .get(
        Constants.ApiEndpoint +
          ApiRoutes.SalesOrderHeaders +
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
          let response = resp.data as Api.SalesOrderHeaderClientResponseModel;

          console.log(response);

          let mapper = new SalesOrderHeaderMapper();

          this.setState({
            model: mapper.mapApiResponseToViewModel(response),
            loading: false,
            loaded: true,
            errorOccurred: false,
            errorMessage: '',
          });
        },
        error => {
          console.log(error);
          this.setState({
            model: undefined,
            loading: false,
            loaded: true,
            errorOccurred: true,
            errorMessage: 'Error from API',
          });
        }
      );
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
              <h3>AccountNumber</h3>
              <p>{String(this.state.model!.accountNumber)}</p>
            </div>
            <div>
              <h3>BillToAddressID</h3>
              <p>{String(this.state.model!.billToAddressID)}</p>
            </div>
            <div>
              <h3>Comment</h3>
              <p>{String(this.state.model!.comment)}</p>
            </div>
            <div>
              <h3>CreditCardApprovalCode</h3>
              <p>{String(this.state.model!.creditCardApprovalCode)}</p>
            </div>
            <div style={{ marginBottom: '10px' }}>
              <h3>CreditCardID</h3>
              <p>
                {String(this.state.model!.creditCardIDNavigation!.toDisplay())}
              </p>
            </div>
            <div style={{ marginBottom: '10px' }}>
              <h3>CurrencyRateID</h3>
              <p>
                {String(
                  this.state.model!.currencyRateIDNavigation!.toDisplay()
                )}
              </p>
            </div>
            <div style={{ marginBottom: '10px' }}>
              <h3>CustomerID</h3>
              <p>
                {String(this.state.model!.customerIDNavigation!.toDisplay())}
              </p>
            </div>
            <div>
              <h3>DueDate</h3>
              <p>{String(this.state.model!.dueDate)}</p>
            </div>
            <div>
              <h3>Freight</h3>
              <p>{String(this.state.model!.freight)}</p>
            </div>
            <div>
              <h3>ModifiedDate</h3>
              <p>{String(this.state.model!.modifiedDate)}</p>
            </div>
            <div>
              <h3>OnlineOrderFlag</h3>
              <p>{String(this.state.model!.onlineOrderFlag)}</p>
            </div>
            <div>
              <h3>OrderDate</h3>
              <p>{String(this.state.model!.orderDate)}</p>
            </div>
            <div>
              <h3>PurchaseOrderNumber</h3>
              <p>{String(this.state.model!.purchaseOrderNumber)}</p>
            </div>
            <div>
              <h3>RevisionNumber</h3>
              <p>{String(this.state.model!.revisionNumber)}</p>
            </div>
            <div>
              <h3>rowguid</h3>
              <p>{String(this.state.model!.rowguid)}</p>
            </div>
            <div>
              <h3>SalesOrderID</h3>
              <p>{String(this.state.model!.salesOrderID)}</p>
            </div>
            <div>
              <h3>SalesOrderNumber</h3>
              <p>{String(this.state.model!.salesOrderNumber)}</p>
            </div>
            <div style={{ marginBottom: '10px' }}>
              <h3>SalesPersonID</h3>
              <p>
                {String(this.state.model!.salesPersonIDNavigation!.toDisplay())}
              </p>
            </div>
            <div>
              <h3>ShipDate</h3>
              <p>{String(this.state.model!.shipDate)}</p>
            </div>
            <div>
              <h3>ShipMethodID</h3>
              <p>{String(this.state.model!.shipMethodID)}</p>
            </div>
            <div>
              <h3>ShipToAddressID</h3>
              <p>{String(this.state.model!.shipToAddressID)}</p>
            </div>
            <div>
              <h3>Status</h3>
              <p>{String(this.state.model!.status)}</p>
            </div>
            <div>
              <h3>SubTotal</h3>
              <p>{String(this.state.model!.subTotal)}</p>
            </div>
            <div>
              <h3>TaxAmt</h3>
              <p>{String(this.state.model!.taxAmt)}</p>
            </div>
            <div style={{ marginBottom: '10px' }}>
              <h3>TerritoryID</h3>
              <p>
                {String(this.state.model!.territoryIDNavigation!.toDisplay())}
              </p>
            </div>
            <div>
              <h3>TotalDue</h3>
              <p>{String(this.state.model!.totalDue)}</p>
            </div>
          </div>
          {message}
          <div>
            <h3>SalesOrderDetails</h3>
            <SalesOrderDetailTableComponent
              salesOrderID={this.state.model!.salesOrderID}
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
              salesOrderID={this.state.model!.salesOrderID}
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
    <Hash>5777030bb1fa868d9bdcc4906920d8e2</Hash>
</Codenesium>*/