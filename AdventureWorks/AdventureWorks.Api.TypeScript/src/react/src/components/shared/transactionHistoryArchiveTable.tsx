import React, { Component, FormEvent } from 'react';
import axios, { AxiosError, AxiosResponse } from 'axios';
import { Constants, ApiRoutes, ClientRoutes } from '../../constants';
import * as Api from '../../api/models';
import TransactionHistoryArchiveMapper from '../transactionHistoryArchive/transactionHistoryArchiveMapper';
import TransactionHistoryArchiveViewModel from '../transactionHistoryArchive/transactionHistoryArchiveViewModel';
import { Form, Input, Button, Spin, Alert } from 'antd';
import { WrappedFormUtils } from 'antd/es/form/Form';
import ReactTable from 'react-table';
import * as GlobalUtilities from '../../lib/globalUtilities';

interface TransactionHistoryArchiveTableComponentProps {
  apiRoute: string;
  history: any;
  match: any;
}

interface TransactionHistoryArchiveTableComponentState {
  loading: boolean;
  loaded: boolean;
  errorOccurred: boolean;
  errorMessage: string;
  filteredRecords: Array<TransactionHistoryArchiveViewModel>;
}

export class TransactionHistoryArchiveTableComponent extends React.Component<
  TransactionHistoryArchiveTableComponentProps,
  TransactionHistoryArchiveTableComponentState
> {
  state = {
    loading: false,
    loaded: true,
    errorOccurred: false,
    errorMessage: '',
    filteredRecords: [],
  };

  handleEditClick(e: any, row: TransactionHistoryArchiveViewModel) {
    this.props.history.push(
      ClientRoutes.TransactionHistoryArchives + '/edit/' + row.transactionID
    );
  }

  handleDetailClick(e: any, row: TransactionHistoryArchiveViewModel) {
    this.props.history.push(
      ClientRoutes.TransactionHistoryArchives + '/' + row.transactionID
    );
  }

  componentDidMount() {
    this.loadRecords();
  }

  loadRecords() {
    this.setState({ ...this.state, loading: true });

    axios
      .get<Array<Api.TransactionHistoryArchiveClientResponseModel>>(
        this.props.apiRoute,
        {
          headers: GlobalUtilities.defaultHeaders(),
        }
      )
      .then(response => {
        GlobalUtilities.logInfo(response);

        let mapper = new TransactionHistoryArchiveMapper();

        let transactionHistoryArchives: Array<
          TransactionHistoryArchiveViewModel
        > = [];

        response.data.forEach(x => {
          transactionHistoryArchives.push(mapper.mapApiResponseToViewModel(x));
        });

        this.setState({
          ...this.state,
          filteredRecords: transactionHistoryArchives,
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
                Header: 'TransactionHistoryArchives',
                columns: [
                  {
                    Header: 'Actual Cost',
                    accessor: 'actualCost',
                    Cell: props => {
                      return <span>{String(props.original.actualCost)}</span>;
                    },
                  },
                  {
                    Header: 'Modified Date',
                    accessor: 'modifiedDate',
                    Cell: props => {
                      return <span>{String(props.original.modifiedDate)}</span>;
                    },
                  },
                  {
                    Header: 'Product I D',
                    accessor: 'productID',
                    Cell: props => {
                      return <span>{String(props.original.productID)}</span>;
                    },
                  },
                  {
                    Header: 'Quantity',
                    accessor: 'quantity',
                    Cell: props => {
                      return <span>{String(props.original.quantity)}</span>;
                    },
                  },
                  {
                    Header: 'Reference Order I D',
                    accessor: 'referenceOrderID',
                    Cell: props => {
                      return (
                        <span>{String(props.original.referenceOrderID)}</span>
                      );
                    },
                  },
                  {
                    Header: 'Reference Order Line I D',
                    accessor: 'referenceOrderLineID',
                    Cell: props => {
                      return (
                        <span>
                          {String(props.original.referenceOrderLineID)}
                        </span>
                      );
                    },
                  },
                  {
                    Header: 'Transaction Date',
                    accessor: 'transactionDate',
                    Cell: props => {
                      return (
                        <span>{String(props.original.transactionDate)}</span>
                      );
                    },
                  },
                  {
                    Header: 'Transaction Type',
                    accessor: 'transactionType',
                    Cell: props => {
                      return (
                        <span>{String(props.original.transactionType)}</span>
                      );
                    },
                  },
                  {
                    Header: 'Actions',
                    minWidth: 150,
                    Cell: row => (
                      <div>
                        <Button
                          type="primary"
                          onClick={(e: any) => {
                            this.handleDetailClick(
                              e,
                              row.original as TransactionHistoryArchiveViewModel
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
                              row.original as TransactionHistoryArchiveViewModel
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
    <Hash>46f970ad8cccbc41cf536dbaa4fe17e3</Hash>
</Codenesium>*/