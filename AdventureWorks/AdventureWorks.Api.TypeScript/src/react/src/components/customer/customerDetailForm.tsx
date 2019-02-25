import React, { Component, FormEvent } from 'react';
import axios from 'axios';
import { Constants, ApiRoutes, ClientRoutes } from '../../constants';
import * as Api from '../../api/models';
import CustomerMapper from './customerMapper';
import CustomerViewModel from './customerViewModel';
import { Form, Input, Button, Spin, Alert } from 'antd';
import { WrappedFormUtils } from 'antd/es/form/Form';
import { SalesOrderHeaderTableComponent } from '../shared/salesOrderHeaderTable';

interface CustomerDetailComponentProps {
  form: WrappedFormUtils;
  history: any;
  match: any;
}

interface CustomerDetailComponentState {
  model?: CustomerViewModel;
  loading: boolean;
  loaded: boolean;
  errorOccurred: boolean;
  errorMessage: string;
}

class CustomerDetailComponent extends React.Component<
  CustomerDetailComponentProps,
  CustomerDetailComponentState
> {
  state = {
    model: new CustomerViewModel(),
    loading: false,
    loaded: true,
    errorOccurred: false,
    errorMessage: '',
  };

  handleEditClick(e: any) {
    this.props.history.push(
      ClientRoutes.Customers + '/edit/' + this.state.model!.customerID
    );
  }

  componentDidMount() {
    this.setState({ ...this.state, loading: true });

    axios
      .get(
        Constants.ApiEndpoint +
          ApiRoutes.Customers +
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
          let response = resp.data as Api.CustomerClientResponseModel;

          console.log(response);

          let mapper = new CustomerMapper();

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
              <h3>CustomerID</h3>
              <p>{String(this.state.model!.customerID)}</p>
            </div>
            <div>
              <h3>ModifiedDate</h3>
              <p>{String(this.state.model!.modifiedDate)}</p>
            </div>
            <div>
              <h3>PersonID</h3>
              <p>{String(this.state.model!.personID)}</p>
            </div>
            <div>
              <h3>rowguid</h3>
              <p>{String(this.state.model!.rowguid)}</p>
            </div>
            <div style={{ marginBottom: '10px' }}>
              <h3>StoreID</h3>
              <p>{String(this.state.model!.storeIDNavigation!.toDisplay())}</p>
            </div>
            <div style={{ marginBottom: '10px' }}>
              <h3>TerritoryID</h3>
              <p>
                {String(this.state.model!.territoryIDNavigation!.toDisplay())}
              </p>
            </div>
          </div>
          {message}
          <div>
            <h3>SalesOrderHeaders</h3>
            <SalesOrderHeaderTableComponent
              salesOrderID={this.state.model!.salesOrderID}
              history={this.props.history}
              match={this.props.match}
              apiRoute={
                Constants.ApiEndpoint +
                ApiRoutes.Customers +
                '/' +
                this.state.model!.customerID +
                '/' +
                ApiRoutes.SalesOrderHeaders
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

export const WrappedCustomerDetailComponent = Form.create({
  name: 'Customer Detail',
})(CustomerDetailComponent);


/*<Codenesium>
    <Hash>4e3b28ba681903257ad65cf7d9209255</Hash>
</Codenesium>*/