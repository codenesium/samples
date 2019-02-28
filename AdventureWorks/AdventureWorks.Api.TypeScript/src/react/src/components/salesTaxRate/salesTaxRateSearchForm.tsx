import React, { Component, ReactElement, ReactHTMLElement } from 'react';
import axios from 'axios';
import { Redirect } from 'react-router-dom';
import * as Api from '../../api/models';
import SalesTaxRateMapper from './salesTaxRateMapper';
import { Constants, ApiRoutes, ClientRoutes } from '../../constants';
import ReactTable from 'react-table';
import SalesTaxRateViewModel from './salesTaxRateViewModel';
import 'react-table/react-table.css';
import { Form, Button, Input, Row, Col, Alert, Spin } from 'antd';
import { WrappedFormUtils } from 'antd/es/form/Form';

interface SalesTaxRateSearchComponentProps {
  form: WrappedFormUtils;
  history: any;
  match: any;
}

interface SalesTaxRateSearchComponentState {
  records: Array<SalesTaxRateViewModel>;
  filteredRecords: Array<SalesTaxRateViewModel>;
  loading: boolean;
  loaded: boolean;
  errorOccurred: boolean;
  errorMessage: string;
  searchValue: string;
  deleteSubmitted: boolean;
  deleteSuccess: boolean;
  deleteResponse: string;
}

export default class SalesTaxRateSearchComponent extends React.Component<
  SalesTaxRateSearchComponentProps,
  SalesTaxRateSearchComponentState
> {
  state = {
    deleteSubmitted: false,
    deleteSuccess: false,
    deleteResponse: '',
    records: new Array<SalesTaxRateViewModel>(),
    filteredRecords: new Array<SalesTaxRateViewModel>(),
    searchValue: '',
    loading: false,
    loaded: true,
    errorOccurred: false,
    errorMessage: '',
  };

  componentDidMount() {
    this.loadRecords();
  }

  handleEditClick(e: any, row: SalesTaxRateViewModel) {
    this.props.history.push(
      ClientRoutes.SalesTaxRates + '/edit/' + row.salesTaxRateID
    );
  }

  handleDetailClick(e: any, row: SalesTaxRateViewModel) {
    this.props.history.push(
      ClientRoutes.SalesTaxRates + '/' + row.salesTaxRateID
    );
  }

  handleCreateClick(e: any) {
    this.props.history.push(ClientRoutes.SalesTaxRates + '/create');
  }

  handleDeleteClick(e: any, row: Api.SalesTaxRateClientResponseModel) {
    axios
      .delete(
        Constants.ApiEndpoint +
          ApiRoutes.SalesTaxRates +
          '/' +
          row.salesTaxRateID,
        {
          headers: {
            'Content-Type': 'application/json',
          },
        }
      )
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
      Constants.ApiEndpoint + ApiRoutes.SalesTaxRates + '?limit=100';

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
          let response = resp.data as Array<
            Api.SalesTaxRateClientResponseModel
          >;
          let viewModels: Array<SalesTaxRateViewModel> = [];
          let mapper = new SalesTaxRateMapper();

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
            records: new Array<SalesTaxRateViewModel>(),
            filteredRecords: new Array<SalesTaxRateViewModel>(),
            loading: false,
            loaded: true,
            errorOccurred: true,
            errorMessage: 'Error from API',
          });
        }
      );
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
                Header: 'SalesTaxRates',
                columns: [
                  {
                    Header: 'ModifiedDate',
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
                    Header: 'SalesTaxRateID',
                    accessor: 'salesTaxRateID',
                    Cell: props => {
                      return (
                        <span>{String(props.original.salesTaxRateID)}</span>
                      );
                    },
                  },
                  {
                    Header: 'StateProvinceID',
                    accessor: 'stateProvinceID',
                    Cell: props => {
                      return (
                        <span>{String(props.original.stateProvinceID)}</span>
                      );
                    },
                  },
                  {
                    Header: 'TaxRate',
                    accessor: 'taxRate',
                    Cell: props => {
                      return <span>{String(props.original.taxRate)}</span>;
                    },
                  },
                  {
                    Header: 'TaxType',
                    accessor: 'taxType',
                    Cell: props => {
                      return <span>{String(props.original.taxType)}</span>;
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
                              row.original as SalesTaxRateViewModel
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
                              row.original as SalesTaxRateViewModel
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
                              row.original as SalesTaxRateViewModel
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

export const WrappedSalesTaxRateSearchComponent = Form.create({
  name: 'SalesTaxRate Search',
})(SalesTaxRateSearchComponent);


/*<Codenesium>
    <Hash>685c8dfcf038a43d57bc45ec592028fd</Hash>
</Codenesium>*/