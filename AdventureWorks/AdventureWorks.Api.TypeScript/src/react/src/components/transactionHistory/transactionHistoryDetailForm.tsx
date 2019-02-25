import React, { Component, FormEvent } from 'react';
import axios from 'axios';
import { Constants, ApiRoutes, ClientRoutes } from '../../constants';
import * as Api from '../../api/models';
import TransactionHistoryMapper from './transactionHistoryMapper';
import TransactionHistoryViewModel from './transactionHistoryViewModel';
import { Form, Input, Button, Spin, Alert } from 'antd';
import { WrappedFormUtils } from 'antd/es/form/Form';

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
      .get(
        Constants.ApiEndpoint +
          ApiRoutes.TransactionHistories +
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
          let response = resp.data as Api.TransactionHistoryClientResponseModel;

          console.log(response);

          let mapper = new TransactionHistoryMapper();

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
              <h3>ActualCost</h3>
              <p>{String(this.state.model!.actualCost)}</p>
            </div>
            <div>
              <h3>ModifiedDate</h3>
              <p>{String(this.state.model!.modifiedDate)}</p>
            </div>
            <div style={{ marginBottom: '10px' }}>
              <h3>ProductID</h3>
              <p>
                {String(this.state.model!.productIDNavigation!.toDisplay())}
              </p>
            </div>
            <div>
              <h3>Quantity</h3>
              <p>{String(this.state.model!.quantity)}</p>
            </div>
            <div>
              <h3>ReferenceOrderID</h3>
              <p>{String(this.state.model!.referenceOrderID)}</p>
            </div>
            <div>
              <h3>ReferenceOrderLineID</h3>
              <p>{String(this.state.model!.referenceOrderLineID)}</p>
            </div>
            <div>
              <h3>TransactionDate</h3>
              <p>{String(this.state.model!.transactionDate)}</p>
            </div>
            <div>
              <h3>TransactionID</h3>
              <p>{String(this.state.model!.transactionID)}</p>
            </div>
            <div>
              <h3>TransactionType</h3>
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
    <Hash>c37aff626c3dc42cfb300978c808a064</Hash>
</Codenesium>*/