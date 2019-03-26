import React, { Component, FormEvent } from 'react';
import axios, { AxiosError, AxiosResponse } from 'axios';
import { Constants, ApiRoutes, ClientRoutes } from '../../constants';
import * as Api from '../../api/models';
import VendorMapper from './vendorMapper';
import VendorViewModel from './vendorViewModel';
import { Form, Input, Button, Spin, Alert } from 'antd';
import { WrappedFormUtils } from 'antd/es/form/Form';
import * as GlobalUtilities from '../../lib/globalUtilities';
import { ProductVendorTableComponent } from '../shared/productVendorTable';
import { PurchaseOrderHeaderTableComponent } from '../shared/purchaseOrderHeaderTable';

interface VendorDetailComponentProps {
  form: WrappedFormUtils;
  history: any;
  match: any;
}

interface VendorDetailComponentState {
  model?: VendorViewModel;
  loading: boolean;
  loaded: boolean;
  errorOccurred: boolean;
  errorMessage: string;
}

class VendorDetailComponent extends React.Component<
  VendorDetailComponentProps,
  VendorDetailComponentState
> {
  state = {
    model: new VendorViewModel(),
    loading: false,
    loaded: true,
    errorOccurred: false,
    errorMessage: '',
  };

  handleEditClick(e: any) {
    this.props.history.push(
      ClientRoutes.Vendors + '/edit/' + this.state.model!.businessEntityID
    );
  }

  componentDidMount() {
    this.setState({ ...this.state, loading: true });

    axios
      .get<Api.VendorClientResponseModel>(
        Constants.ApiEndpoint +
          ApiRoutes.Vendors +
          '/' +
          this.props.match.params.id,
        {
          headers: GlobalUtilities.defaultHeaders(),
        }
      )
      .then(response => {
        GlobalUtilities.logInfo(response);

        let mapper = new VendorMapper();

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
              <h3>Active Flag</h3>
              <p>{String(this.state.model!.activeFlag)}</p>
            </div>
            <div>
              <h3>Credit Rating</h3>
              <p>{String(this.state.model!.creditRating)}</p>
            </div>
            <div>
              <h3>Modified Date</h3>
              <p>{String(this.state.model!.modifiedDate)}</p>
            </div>
            <div>
              <h3>Name</h3>
              <p>{String(this.state.model!.name)}</p>
            </div>
            <div>
              <h3>Preferred Vendor Status</h3>
              <p>{String(this.state.model!.preferredVendorStatu)}</p>
            </div>
            <div>
              <h3>Purchasing Web Service U R L</h3>
              <p>{String(this.state.model!.purchasingWebServiceURL)}</p>
            </div>
          </div>
          {message}
          <div>
            <h3>ProductVendors</h3>
            <ProductVendorTableComponent
              history={this.props.history}
              match={this.props.match}
              apiRoute={
                Constants.ApiEndpoint +
                ApiRoutes.Vendors +
                '/' +
                this.state.model!.businessEntityID +
                '/' +
                ApiRoutes.ProductVendors
              }
            />
          </div>
          <div>
            <h3>PurchaseOrderHeaders</h3>
            <PurchaseOrderHeaderTableComponent
              history={this.props.history}
              match={this.props.match}
              apiRoute={
                Constants.ApiEndpoint +
                ApiRoutes.Vendors +
                '/' +
                this.state.model!.businessEntityID +
                '/' +
                ApiRoutes.PurchaseOrderHeaders
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

export const WrappedVendorDetailComponent = Form.create({
  name: 'Vendor Detail',
})(VendorDetailComponent);


/*<Codenesium>
    <Hash>ed72fdcd1ca4f0d7bba9958b318da9ea</Hash>
</Codenesium>*/