import React, { Component, FormEvent } from 'react';
import axios from 'axios';
import { Constants, ApiRoutes, ClientRoutes } from '../../constants';
import * as Api from '../../api/models';
import TransactionMapper from '../transaction/transactionMapper';
import TransactionViewModel from '../transaction/transactionViewModel';
import { Form, Input, Button, Spin, Alert } from 'antd';
import { WrappedFormUtils } from 'antd/es/form/Form';
import ReactTable from 'react-table';

interface TransactionTableComponentProps {
  id: number;
  apiRoute: string;
  history: any;
  match: any;
}

interface TransactionTableComponentState {
  loading: boolean;
  loaded: boolean;
  errorOccurred: boolean;
  errorMessage: string;
  filteredRecords: Array<TransactionViewModel>;
}

export class TransactionTableComponent extends React.Component<
  TransactionTableComponentProps,
  TransactionTableComponentState
> {
  state = {
    loading: false,
    loaded: true,
    errorOccurred: false,
    errorMessage: '',
    filteredRecords: [],
  };

  handleEditClick(e: any, row: TransactionViewModel) {
    this.props.history.push(ClientRoutes.Transactions + '/edit/' + row.id);
  }

  handleDetailClick(e: any, row: TransactionViewModel) {
    this.props.history.push(ClientRoutes.Transactions + '/' + row.id);
  }

  componentDidMount() {
    this.setState({ ...this.state, loading: true });

    axios
      .get(this.props.apiRoute, {
        headers: {
          'Content-Type': 'application/json',
        },
      })
      .then(
        resp => {
          let response = resp.data as Array<Api.TransactionClientResponseModel>;

          console.log(response);

          let mapper = new TransactionMapper();

          let transactions: Array<TransactionViewModel> = [];

          response.forEach(x => {
            transactions.push(mapper.mapApiResponseToViewModel(x));
          });
          this.setState({
            ...this.state,
            filteredRecords: transactions,
            loading: false,
            loaded: true,
            errorOccurred: false,
            errorMessage: '',
          });
        },
        error => {
          console.log(error);
          this.setState({
            ...this.state,
            loading: false,
            loaded: false,
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
    } else if (this.state.errorOccurred) {
      return <Alert message={this.state.errorMessage} type="error" />;
    } else if (this.state.loaded) {
      return (
        <div>
          {message}
          <ReactTable
            data={this.state.filteredRecords}
            defaultPageSize={10}
            columns={[
              {
                Header: 'Transactions',
                columns: [
                  {
                    Header: 'Amount',
                    accessor: 'amount',
                    Cell: props => {
                      return <span>{String(props.original.amount)}</span>;
                    },
                  },
                  {
                    Header: 'GatewayConfirmationNumber',
                    accessor: 'gatewayConfirmationNumber',
                    Cell: props => {
                      return (
                        <span>
                          {String(props.original.gatewayConfirmationNumber)}
                        </span>
                      );
                    },
                  },
                  {
                    Header: 'TransactionStatusId',
                    accessor: 'transactionStatusId',
                    Cell: props => {
                      return (
                        <a
                          href=""
                          onClick={e => {
                            e.preventDefault();
                            this.props.history.push(
                              ClientRoutes.TransactionStatus +
                                '/' +
                                props.original.transactionStatusId
                            );
                          }}
                        >
                          {String(
                            props.original.transactionStatusIdNavigation.toDisplay()
                          )}
                        </a>
                      );
                    },
                  },
                  {
                    Header: 'Actions',
                    Cell: row => (
                      <div>
                        <Button
                          type="primary"
                          onClick={(e: any) => {
                            this.handleDetailClick(
                              e,
                              row.original as TransactionViewModel
                            );
                          }}
                        >
                          <i className="fas fa-search" />
                        </Button>
                        &nbsp;
                        <Button
                          type="primary"
                          onClick={(e: any) => {
                            this.handleEditClick(
                              e,
                              row.original as TransactionViewModel
                            );
                          }}
                        >
                          <i className="fas fa-edit" />
                        </Button>
                      </div>
                    ),
                  },
                ],
              },
            ]}
          />
        </div>
      );
    } else {
      return null;
    }
  }
}


/*<Codenesium>
    <Hash>fc92df24a42e2d35e0cf1fab36d0006e</Hash>
</Codenesium>*/