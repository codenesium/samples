import React, { Component, ReactElement, ReactHTMLElement } from 'react';
import axios from 'axios';
import { Redirect } from 'react-router-dom';
import * as Api from '../../api/models';
import TransactionMapper from './transactionMapper';
import { Constants, ApiRoutes, ClientRoutes } from '../../constants';
import { LoadingForm } from '../../lib/components/loadingForm';
import { ErrorForm } from '../../lib/components/errorForm';
import ReactTable from 'react-table';
import TransactionViewModel from './transactionViewModel';
import 'react-table/react-table.css';
import { Form, Button, Input, Row, Col, Alert } from 'antd';
import { WrappedFormUtils } from 'antd/es/form/Form';

interface TransactionSearchComponentProps {
  form: WrappedFormUtils;
  history: any;
  match: any;
}

interface TransactionSearchComponentState {
  records: Array<TransactionViewModel>;
  filteredRecords: Array<TransactionViewModel>;
  loading: boolean;
  loaded: boolean;
  errorOccurred: boolean;
  errorMessage: string;
  searchValue: string;
  deleteSubmitted: boolean;
  deleteSuccess: boolean;
  deleteResponse: string;
}

export default class TransactionSearchComponent extends React.Component<
  TransactionSearchComponentProps,
  TransactionSearchComponentState
> {
  state = {
    deleteSubmitted: false,
    deleteSuccess: false,
    deleteResponse: '',
    records: new Array<TransactionViewModel>(),
    filteredRecords: new Array<TransactionViewModel>(),
    searchValue: '',
    loading: false,
    loaded: true,
    errorOccurred: false,
    errorMessage: '',
  };

  componentDidMount() {
    this.loadRecords();
  }

  handleEditClick(e: any, row: Api.TransactionClientResponseModel) {
    this.props.history.push(ClientRoutes.Transactions + '/edit/' + row.id);
  }

  handleDetailClick(e: any, row: Api.TransactionClientResponseModel) {
    this.props.history.push(ClientRoutes.Transactions + '/' + row.id);
  }

  handleCreateClick(e: any) {
    this.props.history.push(ClientRoutes.Transactions + '/create');
  }

  handleDeleteClick(e: any, row: Api.TransactionClientResponseModel) {
    axios
      .delete(Constants.ApiEndpoint + ApiRoutes.Transactions + '/' + row.id, {
        headers: {
          'Content-Type': 'application/json',
        },
      })
      .then(
        resp => {
          this.setState({
            ...this.state,
            deleteResponse: 'Record deleted',
            deleteSuccess: true,
            deleteSubmitted: true,
          });
          this.loadRecords(this.state.searchValue);
        },
        error => {
          console.log(error);
          this.setState({
            ...this.state,
            deleteResponse: 'Error deleting record',
            deleteSuccess: false,
            deleteSubmitted: true,
          });
        }
      );
  }

  handleSearchChanged(e: React.FormEvent<HTMLInputElement>) {
    this.loadRecords(e.currentTarget.value);
  }

  loadRecords(query: string = '') {
    this.setState({ ...this.state, searchValue: query });
    let searchEndpoint =
      Constants.ApiEndpoint + ApiRoutes.Transactions + '?limit=100';

    if (query) {
      searchEndpoint += '&query=' + query;
    }

    axios
      .get(searchEndpoint, {
        headers: {
          'Content-Type': 'application/json',
        },
      })
      .then(
        resp => {
          let response = resp.data as Array<Api.TransactionClientResponseModel>;
          let viewModels: Array<TransactionViewModel> = [];
          let mapper = new TransactionMapper();

          response.forEach(x => {
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
        },
        error => {
          console.log(error);
          this.setState({
            records: new Array<TransactionViewModel>(),
            filteredRecords: new Array<TransactionViewModel>(),
            loading: false,
            loaded: false,
            errorOccurred: true,
            errorMessage: 'Error from API',
          });
        }
      );
  }

  filterGrid() {}

  render() {
    if (this.state.loading) {
      return <LoadingForm />;
    } else if (this.state.errorOccurred) {
      return <ErrorForm message={this.state.errorMessage} />;
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
                Header: 'Transaction',
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
                              row.original as Api.TransactionClientResponseModel
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
                              row.original as Api.TransactionClientResponseModel
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
                              row.original as Api.TransactionClientResponseModel
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

export const WrappedTransactionSearchComponent = Form.create({
  name: 'Transaction Search',
})(TransactionSearchComponent);


/*<Codenesium>
    <Hash>995cc34ea1ddee2200fb9e14082371c1</Hash>
</Codenesium>*/