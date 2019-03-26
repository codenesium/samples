import React, { Component, FormEvent } from 'react';
import axios, { AxiosError, AxiosResponse } from 'axios';
import { Constants, ApiRoutes, ClientRoutes } from '../../constants';
import * as Api from '../../api/models';
import SalesTerritoryMapper from '../salesTerritory/salesTerritoryMapper';
import SalesTerritoryViewModel from '../salesTerritory/salesTerritoryViewModel';
import { Form, Input, Button, Spin, Alert } from 'antd';
import { WrappedFormUtils } from 'antd/es/form/Form';
import ReactTable from 'react-table';
import * as GlobalUtilities from '../../lib/globalUtilities';

interface SalesTerritoryTableComponentProps {
  apiRoute: string;
  history: any;
  match: any;
}

interface SalesTerritoryTableComponentState {
  loading: boolean;
  loaded: boolean;
  errorOccurred: boolean;
  errorMessage: string;
  filteredRecords: Array<SalesTerritoryViewModel>;
}

export class SalesTerritoryTableComponent extends React.Component<
  SalesTerritoryTableComponentProps,
  SalesTerritoryTableComponentState
> {
  state = {
    loading: false,
    loaded: true,
    errorOccurred: false,
    errorMessage: '',
    filteredRecords: [],
  };

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

  componentDidMount() {
    this.loadRecords();
  }

  loadRecords() {
    this.setState({ ...this.state, loading: true });

    axios
      .get<Array<Api.SalesTerritoryClientResponseModel>>(this.props.apiRoute, {
        headers: GlobalUtilities.defaultHeaders(),
      })
      .then(response => {
        GlobalUtilities.logInfo(response);

        let mapper = new SalesTerritoryMapper();

        let salesTerritories: Array<SalesTerritoryViewModel> = [];

        response.data.forEach(x => {
          salesTerritories.push(mapper.mapApiResponseToViewModel(x));
        });

        this.setState({
          ...this.state,
          filteredRecords: salesTerritories,
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
                Header: 'SalesTerritories',
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
    <Hash>389547db7c4a23c61963a8e5c72c859a</Hash>
</Codenesium>*/