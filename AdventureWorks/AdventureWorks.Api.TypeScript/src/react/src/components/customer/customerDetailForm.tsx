import React, { Component, FormEvent } from 'react';
import axios, { AxiosError, AxiosResponse } from 'axios';
import { Constants, ApiRoutes, ClientRoutes } from '../../constants';
import * as Api from '../../api/models';
import CustomerMapper from './customerMapper';
import CustomerViewModel from './customerViewModel';
import { Form, Input, Button, Spin, Alert } from 'antd';
import { WrappedFormUtils } from 'antd/es/form/Form';
import * as GlobalUtilities from '../../lib/globalUtilities';
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
      .get<Api.CustomerClientResponseModel>(
        Constants.ApiEndpoint +
          ApiRoutes.Customers +
          '/' +
          this.props.match.params.id,
        {
          headers: GlobalUtilities.defaultHeaders(),
        }
      )
      .then(response => {
        GlobalUtilities.logInfo(response);

        let mapper = new CustomerMapper();

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
              <h3>Modified Date</h3>
              <p>{String(this.state.model!.modifiedDate)}</p>
            </div>
            <div>
              <h3>Person I D</h3>
              <p>{String(this.state.model!.personID)}</p>
            </div>
            <div>
              <h3>Rowguid</h3>
              <p>{String(this.state.model!.rowguid)}</p>
            </div>
            <div style={{ marginBottom: '10px' }}>
              <h3>Store I D</h3>
              <p>
                {String(
                  this.state.model!.storeIDNavigation &&
                    this.state.model!.storeIDNavigation!.toDisplay()
                )}
              </p>
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
          </div>
          {message}
          <div>
            <h3>SalesOrderHeaders</h3>
            <SalesOrderHeaderTableComponent
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
    <Hash>8025ac5e6bef4f2e39df92050a10daaa</Hash>
</Codenesium>*/