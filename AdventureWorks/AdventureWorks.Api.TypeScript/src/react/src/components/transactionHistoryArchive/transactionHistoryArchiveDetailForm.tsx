import React, { Component, FormEvent } from 'react';
import axios from 'axios';
import { Constants, ApiRoutes, ClientRoutes } from '../../constants';
import * as Api from '../../api/models';
import TransactionHistoryArchiveMapper from './transactionHistoryArchiveMapper';
import TransactionHistoryArchiveViewModel from './transactionHistoryArchiveViewModel';
import { Form, Input, Button, Spin, Alert } from 'antd';
import { WrappedFormUtils } from 'antd/es/form/Form';

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
      .get(
        Constants.ApiEndpoint +
          ApiRoutes.TransactionHistoryArchives +
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
          let response = resp.data as Api.TransactionHistoryArchiveClientResponseModel;

          console.log(response);

          let mapper = new TransactionHistoryArchiveMapper();

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
            <div>
              <h3>ProductID</h3>
              <p>{String(this.state.model!.productID)}</p>
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

export const WrappedTransactionHistoryArchiveDetailComponent = Form.create({
  name: 'TransactionHistoryArchive Detail',
})(TransactionHistoryArchiveDetailComponent);


/*<Codenesium>
    <Hash>ee636c59f6ba99733e19384619199273</Hash>
</Codenesium>*/