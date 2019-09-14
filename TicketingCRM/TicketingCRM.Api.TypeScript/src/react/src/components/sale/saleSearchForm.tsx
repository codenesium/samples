import React, { Component, ReactElement, ReactHTMLElement } from 'react';
import axios, { AxiosError, AxiosResponse } from 'axios';
import { Redirect } from 'react-router-dom';
import * as Api from '../../api/models';
import SaleMapper from './saleMapper';
import { Constants, ApiRoutes, ClientRoutes } from '../../constants';
import ReactTable from 'react-table';
import SaleViewModel from './saleViewModel';
import 'react-table/react-table.css';
import { Form, Button, Input, Row, Col, Alert, Spin } from 'antd';
import { WrappedFormUtils } from 'antd/es/form/Form';
import * as GlobalUtilities from '../../lib/globalUtilities';

interface SaleSearchComponentProps {
  form: WrappedFormUtils;
  history: any;
  match: any;
}

interface SaleSearchComponentState {
  records: Array<SaleViewModel>;
  filteredRecords: Array<SaleViewModel>;
  loading: boolean;
  loaded: boolean;
  errorOccurred: boolean;
  errorMessage: string;
  searchValue: string;
  deleteSubmitted: boolean;
  deleteSuccess: boolean;
  deleteResponse: string;
}

export default class SaleSearchComponent extends React.Component<
  SaleSearchComponentProps,
  SaleSearchComponentState
> {
  state = {
    deleteSubmitted: false,
    deleteSuccess: false,
    deleteResponse: '',
    records: new Array<SaleViewModel>(),
    filteredRecords: new Array<SaleViewModel>(),
    searchValue: '',
    loading: false,
    loaded: true,
    errorOccurred: false,
    errorMessage: '',
  };

  componentDidMount() {
    this.loadRecords();
  }

  handleEditClick(e: any, row: SaleViewModel) {
    this.props.history.push(ClientRoutes.Sales + '/edit/' + row.id);
  }

  handleDetailClick(e: any, row: SaleViewModel) {
    this.props.history.push(ClientRoutes.Sales + '/' + row.id);
  }

  handleCreateClick(e: any) {
    this.props.history.push(ClientRoutes.Sales + '/create');
  }

  handleDeleteClick(e: any, row: Api.SaleClientResponseModel) {
    axios
      .delete(Constants.ApiEndpoint + ApiRoutes.Sales + '/' + row.id, {
        headers: GlobalUtilities.defaultHeaders(),
      })
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
    let searchEndpoint = Constants.ApiEndpoint + ApiRoutes.Sales + '?limit=100';

    if (query) {
      searchEndpoint += '&query=' + query;
    }

    axios
      .get<Array<Api.SaleClientResponseModel>>(searchEndpoint, {
        headers: GlobalUtilities.defaultHeaders(),
      })
      .then(response => {
        let viewModels: Array<SaleViewModel> = [];
        let mapper = new SaleMapper();

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
          records: new Array<SaleViewModel>(),
          filteredRecords: new Array<SaleViewModel>(),
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
                Header: 'Sale',
                columns: [
                  {
                    Header: 'Ip Address',
                    accessor: 'ipAddress',
                    Cell: props => {
                      return <span>{String(props.original.ipAddress)}</span>;
                    },
                  },
                  {
                    Header: 'Notes',
                    accessor: 'notes',
                    Cell: props => {
                      return <span>{String(props.original.notes)}</span>;
                    },
                  },
                  {
                    Header: 'Sale Date',
                    accessor: 'saleDate',
                    Cell: props => {
                      return <span>{String(props.original.saleDate)}</span>;
                    },
                  },
                  {
                    Header: 'Transaction',
                    accessor: 'transactionId',
                    Cell: props => {
                      return (
                        <a
                          href=""
                          onClick={e => {
                            e.preventDefault();
                            this.props.history.push(
                              ClientRoutes.Transactions +
                                '/' +
                                props.original.transactionId
                            );
                          }}
                        >
                          {String(
                            props.original.transactionIdNavigation &&
                              props.original.transactionIdNavigation.toDisplay()
                          )}
                        </a>
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
                              row.original as SaleViewModel
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
                              row.original as SaleViewModel
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
                              row.original as SaleViewModel
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

export const WrappedSaleSearchComponent = Form.create({ name: 'Sale Search' })(
  SaleSearchComponent
);


/*<Codenesium>
    <Hash>80bbd6b9a3657c5d1f6d820c31e9d3be</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/