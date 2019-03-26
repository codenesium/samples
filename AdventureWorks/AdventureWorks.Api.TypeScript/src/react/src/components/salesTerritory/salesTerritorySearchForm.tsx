import React, { Component, ReactElement, ReactHTMLElement } from 'react';
import axios, { AxiosError, AxiosResponse } from 'axios';
import { Redirect } from 'react-router-dom';
import * as Api from '../../api/models';
import SalesTerritoryMapper from './salesTerritoryMapper';
import { Constants, ApiRoutes, ClientRoutes } from '../../constants';
import ReactTable from 'react-table';
import SalesTerritoryViewModel from './salesTerritoryViewModel';
import 'react-table/react-table.css';
import { Form, Button, Input, Row, Col, Alert, Spin } from 'antd';
import { WrappedFormUtils } from 'antd/es/form/Form';
import * as GlobalUtilities from '../../lib/globalUtilities';

interface SalesTerritorySearchComponentProps {
  form: WrappedFormUtils;
  history: any;
  match: any;
}

interface SalesTerritorySearchComponentState {
  records: Array<SalesTerritoryViewModel>;
  filteredRecords: Array<SalesTerritoryViewModel>;
  loading: boolean;
  loaded: boolean;
  errorOccurred: boolean;
  errorMessage: string;
  searchValue: string;
  deleteSubmitted: boolean;
  deleteSuccess: boolean;
  deleteResponse: string;
}

export default class SalesTerritorySearchComponent extends React.Component<
  SalesTerritorySearchComponentProps,
  SalesTerritorySearchComponentState
> {
  state = {
    deleteSubmitted: false,
    deleteSuccess: false,
    deleteResponse: '',
    records: new Array<SalesTerritoryViewModel>(),
    filteredRecords: new Array<SalesTerritoryViewModel>(),
    searchValue: '',
    loading: false,
    loaded: true,
    errorOccurred: false,
    errorMessage: '',
  };

  componentDidMount() {
    this.loadRecords();
  }

  handleEditClick(e: any, row: SalesTerritoryViewModel) {
    this.props.history.push(
      ClientRoutes.SalesTerritories + '/edit/' + row.territoryID
    );
  }

  handleDetailClick(e: any, row: SalesTerritoryViewModel) {
    this.props.history.push(
      ClientRoutes.SalesTerritories + '/' + row.territoryID
    );
  }

  handleCreateClick(e: any) {
    this.props.history.push(ClientRoutes.SalesTerritories + '/create');
  }

  handleDeleteClick(e: any, row: Api.SalesTerritoryClientResponseModel) {
    axios
      .delete(
        Constants.ApiEndpoint +
          ApiRoutes.SalesTerritories +
          '/' +
          row.territoryID,
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
      Constants.ApiEndpoint + ApiRoutes.SalesTerritories + '?limit=100';

    if (query) {
      searchEndpoint += '&query=' + query;
    }

    axios
      .get<Array<Api.SalesTerritoryClientResponseModel>>(searchEndpoint, {
        headers: GlobalUtilities.defaultHeaders(),
      })
      .then(response => {
        let viewModels: Array<SalesTerritoryViewModel> = [];
        let mapper = new SalesTerritoryMapper();

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
          records: new Array<SalesTerritoryViewModel>(),
          filteredRecords: new Array<SalesTerritoryViewModel>(),
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
                Header: 'Sales Territory',
                columns: [
                  {
                    Header: 'Cost Last Year',
                    accessor: 'costLastYear',
                    Cell: props => {
                      return <span>{String(props.original.costLastYear)}</span>;
                    },
                  },
                  {
                    Header: 'Cost Y T D',
                    accessor: 'costYTD',
                    Cell: props => {
                      return <span>{String(props.original.costYTD)}</span>;
                    },
                  },
                  {
                    Header: 'Country Region Code',
                    accessor: 'countryRegionCode',
                    Cell: props => {
                      return (
                        <span>{String(props.original.countryRegionCode)}</span>
                      );
                    },
                  },
                  {
                    Header: 'Group',
                    accessor: 'reservedGroup',
                    Cell: props => {
                      return (
                        <span>{String(props.original.reservedGroup)}</span>
                      );
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
                    Header: 'Name',
                    accessor: 'name',
                    Cell: props => {
                      return <span>{String(props.original.name)}</span>;
                    },
                  },
                  {
                    Header: 'Rowguid',
                    accessor: 'rowguid',
                    Cell: props => {
                      return <span>{String(props.original.rowguid)}</span>;
                    },
                  },
                  {
                    Header: 'Sales Last Year',
                    accessor: 'salesLastYear',
                    Cell: props => {
                      return (
                        <span>{String(props.original.salesLastYear)}</span>
                      );
                    },
                  },
                  {
                    Header: 'Sales Y T D',
                    accessor: 'salesYTD',
                    Cell: props => {
                      return <span>{String(props.original.salesYTD)}</span>;
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
                              row.original as SalesTerritoryViewModel
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
                              row.original as SalesTerritoryViewModel
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
                              row.original as SalesTerritoryViewModel
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

export const WrappedSalesTerritorySearchComponent = Form.create({
  name: 'SalesTerritory Search',
})(SalesTerritorySearchComponent);


/*<Codenesium>
    <Hash>3c604b36357178ff405222821599b551</Hash>
</Codenesium>*/