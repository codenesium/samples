import React, { Component, FormEvent } from 'react';
import axios from 'axios';
import { Constants, ApiRoutes, ClientRoutes } from '../../constants';
import * as Api from '../../api/models';
import PurchaseOrderHeaderMapper from './purchaseOrderHeaderMapper';
import PurchaseOrderHeaderViewModel from './purchaseOrderHeaderViewModel';
import { Form, Input, Button, Spin, Alert } from 'antd';
import { WrappedFormUtils } from 'antd/es/form/Form';
import { PurchaseOrderDetailTableComponent } from '../shared/purchaseOrderDetailTable';

interface PurchaseOrderHeaderDetailComponentProps {
  form: WrappedFormUtils;
  history: any;
  match: any;
}

interface PurchaseOrderHeaderDetailComponentState {
  model?: PurchaseOrderHeaderViewModel;
  loading: boolean;
  loaded: boolean;
  errorOccurred: boolean;
  errorMessage: string;
}

class PurchaseOrderHeaderDetailComponent extends React.Component<
  PurchaseOrderHeaderDetailComponentProps,
  PurchaseOrderHeaderDetailComponentState
> {
  state = {
    model: new PurchaseOrderHeaderViewModel(),
    loading: false,
    loaded: true,
    errorOccurred: false,
    errorMessage: '',
  };

  handleEditClick(e: any) {
    this.props.history.push(
      ClientRoutes.PurchaseOrderHeaders +
        '/edit/' +
        this.state.model!.purchaseOrderID
    );
  }

  componentDidMount() {
    this.setState({ ...this.state, loading: true });

    axios
      .get(
        Constants.ApiEndpoint +
          ApiRoutes.PurchaseOrderHeaders +
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
          let response = resp.data as Api.PurchaseOrderHeaderClientResponseModel;

          console.log(response);

          let mapper = new PurchaseOrderHeaderMapper();

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
              <h3>EmployeeID</h3>
              <p>{String(this.state.model!.employeeID)}</p>
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
              <h3>OrderDate</h3>
              <p>{String(this.state.model!.orderDate)}</p>
            </div>
            <div>
              <h3>PurchaseOrderID</h3>
              <p>{String(this.state.model!.purchaseOrderID)}</p>
            </div>
            <div>
              <h3>RevisionNumber</h3>
              <p>{String(this.state.model!.revisionNumber)}</p>
            </div>
            <div>
              <h3>ShipDate</h3>
              <p>{String(this.state.model!.shipDate)}</p>
            </div>
            <div style={{ marginBottom: '10px' }}>
              <h3>ShipMethodID</h3>
              <p>
                {String(this.state.model!.shipMethodIDNavigation!.toDisplay())}
              </p>
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
            <div>
              <h3>TotalDue</h3>
              <p>{String(this.state.model!.totalDue)}</p>
            </div>
            <div style={{ marginBottom: '10px' }}>
              <h3>VendorID</h3>
              <p>{String(this.state.model!.vendorIDNavigation!.toDisplay())}</p>
            </div>
          </div>
          {message}
          <div>
            <h3>PurchaseOrderDetails</h3>
            <PurchaseOrderDetailTableComponent
              purchaseOrderID={this.state.model!.purchaseOrderID}
              history={this.props.history}
              match={this.props.match}
              apiRoute={
                Constants.ApiEndpoint +
                ApiRoutes.PurchaseOrderHeaders +
                '/' +
                this.state.model!.purchaseOrderID +
                '/' +
                ApiRoutes.PurchaseOrderDetails
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

export const WrappedPurchaseOrderHeaderDetailComponent = Form.create({
  name: 'PurchaseOrderHeader Detail',
})(PurchaseOrderHeaderDetailComponent);


/*<Codenesium>
    <Hash>e38eebc03f100bd44357542453138a79</Hash>
</Codenesium>*/