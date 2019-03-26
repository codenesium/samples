import React, { Component, ReactElement, ReactHTMLElement } from 'react';
import axios, { AxiosError, AxiosResponse } from 'axios';
import { Redirect } from 'react-router-dom';
import * as Api from '../../api/models';
import TransactionHistoryArchiveMapper from './transactionHistoryArchiveMapper';
import { Constants, ApiRoutes, ClientRoutes } from '../../constants';
import ReactTable from 'react-table';
import TransactionHistoryArchiveViewModel from './transactionHistoryArchiveViewModel';
import 'react-table/react-table.css';
import { Form, Button, Input, Row, Col, Alert, Spin } from 'antd';
import { WrappedFormUtils } from 'antd/es/form/Form';
import * as GlobalUtilities from '../../lib/globalUtilities';

interface TransactionHistoryArchiveSearchComponentProps {
  form: WrappedFormUtils;
  history: any;
  match: any;
}

interface TransactionHistoryArchiveSearchComponentState {
  records: Array<TransactionHistoryArchiveViewModel>;
  filteredRecords: Array<TransactionHistoryArchiveViewModel>;
  loading: boolean;
  loaded: boolean;
  errorOccurred: boolean;
  errorMessage: string;
  searchValue: string;
  deleteSubmitted: boolean;
  deleteSuccess: boolean;
  deleteResponse: string;
}

export default class TransactionHistoryArchiveSearchComponent extends React.Component<
  TransactionHistoryArchiveSearchComponentProps,
  TransactionHistoryArchiveSearchComponentState
> {
  state = {
    deleteSubmitted: false,
    deleteSuccess: false,
    deleteResponse: '',
    records: new Array<TransactionHistoryArchiveViewModel>(),
    filteredRecords: new Array<TransactionHistoryArchiveViewModel>(),
    searchValue: '',
    loading: false,
    loaded: true,
    errorOccurred: false,
    errorMessage: '',
  };

  componentDidMount() {
    this.loadRecords();
  }

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

  handleCreateClick(e: any) {
    this.props.history.push(
      ClientRoutes.TransactionHistoryArchives + '/create'
    );
  }

  handleDeleteClick(
    e: any,
    row: Api.TransactionHistoryArchiveClientResponseModel
  ) {
    axios
      .delete(
        Constants.ApiEndpoint +
          ApiRoutes.TransactionHistoryArchives +
          '/' +
          row.transactionID,
        {
          headers: GlobalUtilities.defaultHeaders(),
        }
      )
      .then(resp => {
        this.setState({
          ...this.state,
          deleteResponse: 'Record deleted',
          deleteSuccess: true,
          deleteSubmitted: true,
        });
        this.loadRecords(this.state.searchValue);
      })
      .catch((error: AxiosError) => {
        GlobalUtilities.logError(error);
        this.setState({
          ...this.state,
          deleteResponse: 'Error deleting record',
          deleteSuccess: false,
          deleteSubmitted: true,
        });
      });
  }

  handleSearchChanged(e: React.FormEvent<HTMLInputElement>) {
    this.loadRecords(e.currentTarget.value);
  }

  loadRecords(query: string = '') {
    this.setState({ ...this.state, searchValue: query });
    let searchEndpoint =
      Constants.ApiEndpoint +
      ApiRoutes.TransactionHistoryArchives +
      '?limit=100';

    if (query) {
      searchEndpoint += '&query=' + query;
    }

    axios
      .get<Array<Api.TransactionHistoryArchiveClientResponseModel>>(
        searchEndpoint,
        {
          headers: GlobalUtilities.defaultHeaders(),
        }
      )
      .then(response => {
        let viewModels: Array<TransactionHistoryArchiveViewModel> = [];
        let mapper = new TransactionHistoryArchiveMapper();

        response.data.forEach(x => {
          viewModels.push(mapper.mapApiResponseToViewModel(x));
        });

        this.setState({
          records: viewModels,
          filteredRecords: viewModels,
          loading: false,
          loaded: true,
          errorOccurred: false,
          errorMessage: '',
        });
      })
      .catch((error: AxiosError) => {
        GlobalUtilities.logError(error);
        this.setState({
          records: new Array<TransactionHistoryArchiveViewModel>(),
          filteredRecords: new Array<TransactionHistoryArchiveViewModel>(),
          loading: false,
          loaded: true,
          errorOccurred: true,
          errorMessage: 'Error from API',
        });
      });
  }

  filterGrid() {}

  render() {
    if (this.state.loading) {
      return <Spin size="large" />;
    } else if (this.state.errorOccurred) {
      return <Alert message={this.state.errorMessage} type="error" />;
    } else if (this.state.loaded) {
      let errorResponse: JSX.Element = <span />;

      if (this.state.deleteSubmitted) {
        if (this.state.deleteSuccess) {
          errorResponse = (
            <Alert
              message={this.state.deleteResponse}
              type="success"
              style={{ marginBottom: '25px' }}
            />
          );
        } else {
          errorResponse = (
            <Alert
              message={this.state.deleteResponse}
              type="error"
              style={{ marginBottom: '25px' }}
            />
          );
        }
      }

      return (
        <div>
          {errorResponse}
          <Row>
            <Col span={8} />
            <Col span={8}>
              <Input
                placeholder={'Search'}
                id={'search'}
                onChange={(e: any) => {
                  this.handleSearchChanged(e);
                }}
              />
            </Col>
            <Col span={8}>
              <Button
                style={{ float: 'right' }}
                type="primary"
                onClick={(e: any) => {
                  this.handleCreateClick(e);
                }}
              >
                +
              </Button>
            </Col>
          </Row>
          <br />
          <br />
          <ReactTable
            data={this.state.filteredRecords}
            columns={[
              {
                Header: 'Transaction History Archive',
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
                        &nbsp;
                        <Button
                          type="danger"
                          onClick={(e: any) => {
                            this.handleDeleteClick(
                              e,
                              row.original as TransactionHistoryArchiveViewModel
                            );
                          }}
                        >
                          <i className="far fa-trash-alt" />
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

export const WrappedTransactionHistoryArchiveSearchComponent = Form.create({
  name: 'TransactionHistoryArchive Search',
})(TransactionHistoryArchiveSearchComponent);


/*<Codenesium>
    <Hash>9be33f9ad1d18a4a8e46f59feaf4046b</Hash>
</Codenesium>*/