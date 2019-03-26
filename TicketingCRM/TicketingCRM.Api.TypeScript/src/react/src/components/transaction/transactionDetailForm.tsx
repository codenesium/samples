import React, { Component, FormEvent } from 'react';
import axios, { AxiosError, AxiosResponse } from 'axios';
import { Constants, ApiRoutes, ClientRoutes } from '../../constants';
import * as Api from '../../api/models';
import TransactionMapper from './transactionMapper';
import TransactionViewModel from './transactionViewModel';
import { Form, Input, Button, Spin, Alert } from 'antd';
import { WrappedFormUtils } from 'antd/es/form/Form';
import * as GlobalUtilities from '../../lib/globalUtilities';
import { SaleTableComponent } from '../shared/saleTable';

interface TransactionDetailComponentProps {
  form: WrappedFormUtils;
  history: any;
  match: any;
}

interface TransactionDetailComponentState {
  model?: TransactionViewModel;
  loading: boolean;
  loaded: boolean;
  errorOccurred: boolean;
  errorMessage: string;
}

class TransactionDetailComponent extends React.Component<
  TransactionDetailComponentProps,
  TransactionDetailComponentState
> {
  state = {
    model: new TransactionViewModel(),
    loading: false,
    loaded: true,
    errorOccurred: false,
    errorMessage: '',
  };

  handleEditClick(e: any) {
    this.props.history.push(
      ClientRoutes.Transactions + '/edit/' + this.state.model!.id
    );
  }

  componentDidMount() {
    this.setState({ ...this.state, loading: true });

    axios
      .get<Api.TransactionClientResponseModel>(
        Constants.ApiEndpoint +
          ApiRoutes.Transactions +
          '/' +
          this.props.match.params.id,
        {
          headers: GlobalUtilities.defaultHeaders(),
        }
      )
      .then(response => {
        GlobalUtilities.logInfo(response);

        let mapper = new TransactionMapper();

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
              <h3>Amount</h3>
              <p>{String(this.state.model!.amount)}</p>
            </div>
            <div>
              <h3>Gateway Confirmation Number</h3>
              <p>{String(this.state.model!.gatewayConfirmationNumber)}</p>
            </div>
            <div style={{ marginBottom: '10px' }}>
              <h3>Transaction Status</h3>
              <p>
                {String(
                  this.state.model!.transactionStatusIdNavigation &&
                    this.state.model!.transactionStatusIdNavigation!.toDisplay()
                )}
              </p>
            </div>
          </div>
          {message}
          <div>
            <h3>Sales</h3>
            <SaleTableComponent
              history={this.props.history}
              match={this.props.match}
              apiRoute={
                Constants.ApiEndpoint +
                ApiRoutes.Transactions +
                '/' +
                this.state.model!.id +
                '/' +
                ApiRoutes.Sales
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

export const WrappedTransactionDetailComponent = Form.create({
  name: 'Transaction Detail',
})(TransactionDetailComponent);


/*<Codenesium>
    <Hash>b16edcd1b0c1b0e9d1512c8bd8529ab4</Hash>
</Codenesium>*/