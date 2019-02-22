import React, { Component, FormEvent } from 'react';
import axios from 'axios';
import { Constants, ApiRoutes, ClientRoutes } from '../../constants';
import * as Api from '../../api/models';
import TransactionMapper from './transactionMapper';
import TransactionViewModel from './transactionViewModel';
import { Form, Input, Button, Spin, Alert } from 'antd';
import { WrappedFormUtils } from 'antd/es/form/Form';
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
      .get(
        Constants.ApiEndpoint +
          ApiRoutes.Transactions +
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
          let response = resp.data as Api.TransactionClientResponseModel;

          console.log(response);

          let mapper = new TransactionMapper();

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
              <h3>amount</h3>
              <p>{String(this.state.model!.amount)}</p>
            </div>
            <div>
              <h3>gatewayConfirmationNumber</h3>
              <p>{String(this.state.model!.gatewayConfirmationNumber)}</p>
            </div>
            <div style={{ marginBottom: '10px' }}>
              <h3>transactionStatusId</h3>
              <p>
                {String(
                  this.state.model!.transactionStatusIdNavigation!.toDisplay()
                )}
              </p>
            </div>
          </div>
          {message}
          <div>
            <h3>Sales</h3>
            <SaleTableComponent
              id={this.state.model!.id}
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
    <Hash>640c84e3d4658c258668323698d5257e</Hash>
</Codenesium>*/