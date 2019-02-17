import React, { Component, ReactElement, ReactHTMLElement } from 'react';
import axios from 'axios';
import { Redirect } from 'react-router-dom';
import * as Api from '../../api/models';
import SalesTerritoryMapper from './salesTerritoryMapper';
import { Constants, ApiRoutes, ClientRoutes } from '../../constants';
import { LoadingForm } from '../../lib/components/loadingForm';
import { ErrorForm } from '../../lib/components/errorForm';
import ReactTable from 'react-table';
import SalesTerritoryViewModel from './salesTerritoryViewModel';
import 'react-table/react-table.css';

interface SalesTerritorySearchComponentProps {
  history: any;
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

  handleEditClick(e: any, row: Api.SalesTerritoryClientResponseModel) {
    this.props.history.push(
      ClientRoutes.SalesTerritories + '/edit/' + row.territoryID
    );
  }

  handleDetailClick(e: any, row: Api.SalesTerritoryClientResponseModel) {
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
      Constants.ApiEndpoint + ApiRoutes.SalesTerritories + '?limit=100';

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
            Api.SalesTerritoryClientResponseModel
          >;
          let viewModels: Array<SalesTerritoryViewModel> = [];
          let mapper = new SalesTerritoryMapper();

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
            records: new Array<SalesTerritoryViewModel>(),
            filteredRecords: new Array<SalesTerritoryViewModel>(),
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
            <div className="alert alert-success">
              {this.state.deleteResponse}
            </div>
          );
        } else {
          errorResponse = (
            <div className="alert alert-danger">
              {this.state.deleteResponse}
            </div>
          );
        }
      }
      return (
        <div>
          {errorResponse}
          <form>
            <div className="form-group row">
              <div className="col-sm-4" />
              <div className="col-sm-4">
                <input
                  name="search"
                  className="form-control"
                  placeholder={'Search'}
                  value={this.state.searchValue}
                  onChange={e => this.handleSearchChanged(e)}
                />
              </div>
              <div className="col-sm-4">
                <button
                  className="btn btn-primary btn-sm align-middle float-right vertically-center search-create-button"
                  onClick={e => this.handleCreateClick(e)}
                >
                  <i className="fas fa-plus" />
                </button>
              </div>
            </div>
          </form>
          <ReactTable
            data={this.state.filteredRecords}
            columns={[
              {
                Header: 'SalesTerritory',
                columns: [
                  {
                    Header: 'CostLastYear',
                    accessor: 'costLastYear',
                    Cell: props => {
                      return <span>{String(props.original.costLastYear)}</span>;
                    },
                  },
                  {
                    Header: 'CostYTD',
                    accessor: 'costYTD',
                    Cell: props => {
                      return <span>{String(props.original.costYTD)}</span>;
                    },
                  },
                  {
                    Header: 'CountryRegionCode',
                    accessor: 'countryRegionCode',
                    Cell: props => {
                      return (
                        <span>{String(props.original.countryRegionCode)}</span>
                      );
                    },
                  },
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
                    Header: 'SalesLastYear',
                    accessor: 'salesLastYear',
                    Cell: props => {
                      return (
                        <span>{String(props.original.salesLastYear)}</span>
                      );
                    },
                  },
                  {
                    Header: 'SalesYTD',
                    accessor: 'salesYTD',
                    Cell: props => {
                      return <span>{String(props.original.salesYTD)}</span>;
                    },
                  },
                  {
                    Header: 'TerritoryID',
                    accessor: 'territoryID',
                    Cell: props => {
                      return <span>{String(props.original.territoryID)}</span>;
                    },
                  },
                  {
                    Header: 'Actions',
                    Cell: row => (
                      <div>
                        <button
                          className="btn btn-sm"
                          onClick={e => {
                            this.handleDetailClick(
                              e,
                              row.original as Api.SalesTerritoryClientResponseModel
                            );
                          }}
                        >
                          <i className="fas fa-search" />
                        </button>
                        &nbsp;
                        <button
                          className="btn btn-primary btn-sm"
                          onClick={e => {
                            this.handleEditClick(
                              e,
                              row.original as Api.SalesTerritoryClientResponseModel
                            );
                          }}
                        >
                          <i className="fas fa-edit" />
                        </button>
                        &nbsp;
                        <button
                          className="btn btn-danger btn-sm"
                          onClick={e => {
                            this.handleDeleteClick(
                              e,
                              row.original as Api.SalesTerritoryClientResponseModel
                            );
                          }}
                        >
                          <i className="far fa-trash-alt" />
                        </button>
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
    <Hash>f189cba8d5b9a0c2ee1bb228ca6c6b87</Hash>
</Codenesium>*/