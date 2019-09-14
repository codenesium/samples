import React, { Component, FormEvent } from 'react';
import axios, { AxiosError, AxiosResponse } from 'axios';
import { Constants, ApiRoutes, ClientRoutes } from '../../constants';
import * as Api from '../../api/models';
import TransactionStatusMapper from './transactionStatusMapper';
import TransactionStatusViewModel from './transactionStatusViewModel';
import { Form, Input, Button, Spin, Alert } from 'antd';
import { WrappedFormUtils } from 'antd/es/form/Form';
import * as GlobalUtilities from '../../lib/globalUtilities';
import { TransactionTableComponent } from '../shared/transactionTable';

interface TransactionStatusDetailComponentProps {
  form: WrappedFormUtils;
  history: any;
  match: any;
}

interface TransactionStatusDetailComponentState {
  model?: TransactionStatusViewModel;
  loading: boolean;
  loaded: boolean;
  errorOccurred: boolean;
  errorMessage: string;
}

class TransactionStatusDetailComponent extends React.Component<
  TransactionStatusDetailComponentProps,
  TransactionStatusDetailComponentState
> {
  state = {
    model: new TransactionStatusViewModel(),
    loading: false,
    loaded: true,
    errorOccurred: false,
    errorMessage: '',
  };

  handleEditClick(e: any) {
    this.props.history.push(
      ClientRoutes.TransactionStatus + '/edit/' + this.state.model!.id
    );
  }

  componentDidMount() {
    this.setState({ ...this.state, loading: true });

    axios
      .get<Api.TransactionStatusClientResponseModel>(
        Constants.ApiEndpoint +
          ApiRoutes.TransactionStatus +
          '/' +
          this.props.match.params.id,
        {
          headers: GlobalUtilities.defaultHeaders(),
        }
      )
      .then(response => {
        GlobalUtilities.logInfo(response);

        let mapper = new TransactionStatusMapper();

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
              <h3>Name</h3>
              <p>{String(this.state.model!.name)}</p>
            </div>
          </div>
          {message}
          <div>
            <h3>Transactions</h3>
            <TransactionTableComponent
              history={this.props.history}
              match={this.props.match}
              apiRoute={
                Constants.ApiEndpoint +
                ApiRoutes.TransactionStatus +
                '/' +
                this.state.model!.id +
                '/' +
                ApiRoutes.Transactions
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

export const WrappedTransactionStatusDetailComponent = Form.create({
  name: 'TransactionStatus Detail',
})(TransactionStatusDetailComponent);


/*<Codenesium>
    <Hash>22a0a70b8b493a88bdc108b8bd404977</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/