import React, { Component, FormEvent } from 'react';
import axios, { AxiosError, AxiosResponse } from 'axios';
import { Constants, ApiRoutes, ClientRoutes } from '../../constants';
import * as Api from '../../api/models';
import TransactionHistoryMapper from './transactionHistoryMapper';
import TransactionHistoryViewModel from './transactionHistoryViewModel';
import { Form, Input, Button, Spin, Alert } from 'antd';
import { WrappedFormUtils } from 'antd/es/form/Form';
import * as GlobalUtilities from '../../lib/globalUtilities';

interface TransactionHistoryDetailComponentProps {
  form: WrappedFormUtils;
  history: any;
  match: any;
}

interface TransactionHistoryDetailComponentState {
  model?: TransactionHistoryViewModel;
  loading: boolean;
  loaded: boolean;
  errorOccurred: boolean;
  errorMessage: string;
}

class TransactionHistoryDetailComponent extends React.Component<
  TransactionHistoryDetailComponentProps,
  TransactionHistoryDetailComponentState
> {
  state = {
    model: new TransactionHistoryViewModel(),
    loading: false,
    loaded: true,
    errorOccurred: false,
    errorMessage: '',
  };

  handleEditClick(e: any) {
    this.props.history.push(
      ClientRoutes.TransactionHistories +
        '/edit/' +
        this.state.model!.transactionID
    );
  }

  componentDidMount() {
    this.setState({ ...this.state, loading: true });

    axios
      .get<Api.TransactionHistoryClientResponseModel>(
        Constants.ApiEndpoint +
          ApiRoutes.TransactionHistories +
          '/' +
          this.props.match.params.id,
        {
          headers: GlobalUtilities.defaultHeaders(),
        }
      )
      .then(response => {
        GlobalUtilities.logInfo(response);

        let mapper = new TransactionHistoryMapper();

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
              <h3>Actual Cost</h3>
              <p>{String(this.state.model!.actualCost)}</p>
            </div>
            <div>
              <h3>Modified Date</h3>
              <p>{String(this.state.model!.modifiedDate)}</p>
            </div>
            <div style={{ marginBottom: '10px' }}>
              <h3>Product I D</h3>
              <p>
                {String(
                  this.state.model!.productIDNavigation &&
                    this.state.model!.productIDNavigation!.toDisplay()
                )}
              </p>
            </div>
            <div>
              <h3>Quantity</h3>
              <p>{String(this.state.model!.quantity)}</p>
            </div>
            <div>
              <h3>Reference Order I D</h3>
              <p>{String(this.state.model!.referenceOrderID)}</p>
            </div>
            <div>
              <h3>Reference Order Line I D</h3>
              <p>{String(this.state.model!.referenceOrderLineID)}</p>
            </div>
            <div>
              <h3>Transaction Date</h3>
              <p>{String(this.state.model!.transactionDate)}</p>
            </div>
            <div>
              <h3>Transaction Type</h3>
              <p>{String(this.state.model!.transactionType)}</p>
            </div>
          </div>
          {message}
        </div>
      );
    } else {
      return null;
    }
  }
}

export const WrappedTransactionHistoryDetailComponent = Form.create({
  name: 'TransactionHistory Detail',
})(TransactionHistoryDetailComponent);


/*<Codenesium>
    <Hash>ecc48c5dc894ed7e5923327af88d05b8</Hash>
</Codenesium>*/