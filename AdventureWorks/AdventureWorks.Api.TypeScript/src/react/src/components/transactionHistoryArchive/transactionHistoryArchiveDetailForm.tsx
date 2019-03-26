import React, { Component, FormEvent } from 'react';
import axios, { AxiosError, AxiosResponse } from 'axios';
import { Constants, ApiRoutes, ClientRoutes } from '../../constants';
import * as Api from '../../api/models';
import TransactionHistoryArchiveMapper from './transactionHistoryArchiveMapper';
import TransactionHistoryArchiveViewModel from './transactionHistoryArchiveViewModel';
import { Form, Input, Button, Spin, Alert } from 'antd';
import { WrappedFormUtils } from 'antd/es/form/Form';
import * as GlobalUtilities from '../../lib/globalUtilities';

interface TransactionHistoryArchiveDetailComponentProps {
  form: WrappedFormUtils;
  history: any;
  match: any;
}

interface TransactionHistoryArchiveDetailComponentState {
  model?: TransactionHistoryArchiveViewModel;
  loading: boolean;
  loaded: boolean;
  errorOccurred: boolean;
  errorMessage: string;
}

class TransactionHistoryArchiveDetailComponent extends React.Component<
  TransactionHistoryArchiveDetailComponentProps,
  TransactionHistoryArchiveDetailComponentState
> {
  state = {
    model: new TransactionHistoryArchiveViewModel(),
    loading: false,
    loaded: true,
    errorOccurred: false,
    errorMessage: '',
  };

  handleEditClick(e: any) {
    this.props.history.push(
      ClientRoutes.TransactionHistoryArchives +
        '/edit/' +
        this.state.model!.transactionID
    );
  }

  componentDidMount() {
    this.setState({ ...this.state, loading: true });

    axios
      .get<Api.TransactionHistoryArchiveClientResponseModel>(
        Constants.ApiEndpoint +
          ApiRoutes.TransactionHistoryArchives +
          '/' +
          this.props.match.params.id,
        {
          headers: GlobalUtilities.defaultHeaders(),
        }
      )
      .then(response => {
        GlobalUtilities.logInfo(response);

        let mapper = new TransactionHistoryArchiveMapper();

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
            <div>
              <h3>Product I D</h3>
              <p>{String(this.state.model!.productID)}</p>
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

export const WrappedTransactionHistoryArchiveDetailComponent = Form.create({
  name: 'TransactionHistoryArchive Detail',
})(TransactionHistoryArchiveDetailComponent);


/*<Codenesium>
    <Hash>cba36aa60450db41cc6068c2b3cba154</Hash>
</Codenesium>*/