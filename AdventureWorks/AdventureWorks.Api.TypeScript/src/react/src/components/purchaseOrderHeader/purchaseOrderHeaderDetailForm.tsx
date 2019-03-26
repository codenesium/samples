import React, { Component, FormEvent } from 'react';
import axios, { AxiosError, AxiosResponse } from 'axios';
import { Constants, ApiRoutes, ClientRoutes } from '../../constants';
import * as Api from '../../api/models';
import PurchaseOrderHeaderMapper from './purchaseOrderHeaderMapper';
import PurchaseOrderHeaderViewModel from './purchaseOrderHeaderViewModel';
import { Form, Input, Button, Spin, Alert } from 'antd';
import { WrappedFormUtils } from 'antd/es/form/Form';
import * as GlobalUtilities from '../../lib/globalUtilities';
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
      .get<Api.PurchaseOrderHeaderClientResponseModel>(
        Constants.ApiEndpoint +
          ApiRoutes.PurchaseOrderHeaders +
          '/' +
          this.props.match.params.id,
        {
          headers: GlobalUtilities.defaultHeaders(),
        }
      )
      .then(response => {
        GlobalUtilities.logInfo(response);

        let mapper = new PurchaseOrderHeaderMapper();

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
              <h3>Employee I D</h3>
              <p>{String(this.state.model!.employeeID)}</p>
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
              <h3>Order Date</h3>
              <p>{String(this.state.model!.orderDate)}</p>
            </div>
            <div>
              <h3>Revision Number</h3>
              <p>{String(this.state.model!.revisionNumber)}</p>
            </div>
            <div>
              <h3>Ship Date</h3>
              <p>{String(this.state.model!.shipDate)}</p>
            </div>
            <div style={{ marginBottom: '10px' }}>
              <h3>Ship Method I D</h3>
              <p>
                {String(
                  this.state.model!.shipMethodIDNavigation &&
                    this.state.model!.shipMethodIDNavigation!.toDisplay()
                )}
              </p>
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
            <div>
              <h3>Total Due</h3>
              <p>{String(this.state.model!.totalDue)}</p>
            </div>
            <div style={{ marginBottom: '10px' }}>
              <h3>Vendor I D</h3>
              <p>
                {String(
                  this.state.model!.vendorIDNavigation &&
                    this.state.model!.vendorIDNavigation!.toDisplay()
                )}
              </p>
            </div>
          </div>
          {message}
          <div>
            <h3>PurchaseOrderDetails</h3>
            <PurchaseOrderDetailTableComponent
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
    <Hash>31b7786a84be60891d31cb4fcee751ba</Hash>
</Codenesium>*/