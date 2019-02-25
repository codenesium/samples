import React, { Component, FormEvent } from 'react';
import axios from 'axios';
import { Constants, ApiRoutes, ClientRoutes } from '../../constants';
import * as Api from '../../api/models';
import SalesTaxRateMapper from '../salesTaxRate/salesTaxRateMapper';
import SalesTaxRateViewModel from '../salesTaxRate/salesTaxRateViewModel';
import { Form, Input, Button, Spin, Alert } from 'antd';
import { WrappedFormUtils } from 'antd/es/form/Form';
import ReactTable from 'react-table';

interface SalesTaxRateTableComponentProps {
  salesTaxRateID: number;
  apiRoute: string;
  history: any;
  match: any;
}

interface SalesTaxRateTableComponentState {
  loading: boolean;
  loaded: boolean;
  errorOccurred: boolean;
  errorMessage: string;
  filteredRecords: Array<SalesTaxRateViewModel>;
}

export class SalesTaxRateTableComponent extends React.Component<
  SalesTaxRateTableComponentProps,
  SalesTaxRateTableComponentState
> {
  state = {
    loading: false,
    loaded: true,
    errorOccurred: false,
    errorMessage: '',
    filteredRecords: [],
  };

  handleEditClick(e: any, row: SalesTaxRateViewModel) {
    this.props.history.push(ClientRoutes.SalesTaxRates + '/edit/' + row.id);
  }

  handleDetailClick(e: any, row: SalesTaxRateViewModel) {
    this.props.history.push(ClientRoutes.SalesTaxRates + '/' + row.id);
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
          let response = resp.data as Array<
            Api.SalesTaxRateClientResponseModel
          >;

          console.log(response);

          let mapper = new SalesTaxRateMapper();

          let salesTaxRates: Array<SalesTaxRateViewModel> = [];

          response.forEach(x => {
            salesTaxRates.push(mapper.mapApiResponseToViewModel(x));
          });
          this.setState({
            ...this.state,
            filteredRecords: salesTaxRates,
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
    <Hash>7794b578e9b576ac8ab5e83a97a2ce08</Hash>
</Codenesium>*/