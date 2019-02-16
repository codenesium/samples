import React, { Component, ReactElement, ReactHTMLElement } from 'react';
import axios from 'axios';
import { Redirect } from 'react-router-dom';
import * as Api from '../../api/models';
import SalesTaxRateMapper from './salesTaxRateMapper';
import Constants from '../../constants';
import ReactTable from 'react-table';
import SalesTaxRateViewModel from './salesTaxRateViewModel';
import 'react-table/react-table.css';

interface SalesTaxRateSearchComponentProps {
  history: any;
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
    records: new Array<Api.SalesTaxRateClientResponseModel>(),
    filteredRecords: new Array<Api.SalesTaxRateClientResponseModel>(),
    searchValue: '',
    loading: false,
    loaded: true,
    errorOccurred: false,
    errorMessage: '',
  };

  componentDidMount() {
    this.loadRecords();
  }

  handleEditClick(e: any, row: Api.SalesTaxRateClientResponseModel) {
    this.props.history.push('/salestaxrates/edit/' + row.salesTaxRateID);
  }

  handleDetailClick(e: any, row: Api.SalesTaxRateClientResponseModel) {
    this.props.history.push('/salestaxrates/' + row.salesTaxRateID);
  }

  handleCreateClick(e: any) {
    this.props.history.push('/salestaxrates/create');
  }

  handleDeleteClick(e: any, row: Api.SalesTaxRateClientResponseModel) {
    axios
      .delete(Constants.ApiUrl + 'salestaxrates/' + row.salesTaxRateID, {
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
    let searchEndpoint = Constants.ApiUrl + 'salestaxrates' + '?limit=100';

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
      return <div>loading</div>;
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
                Header: 'SalesTaxRate',
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
                        <button
                          className="btn btn-sm"
                          onClick={e => {
                            this.handleDetailClick(
                              e,
                              row.original as Api.SalesTaxRateClientResponseModel
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
                              row.original as Api.SalesTaxRateClientResponseModel
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
                              row.original as Api.SalesTaxRateClientResponseModel
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
    } else if (this.state.errorOccurred) {
      return (
        <div className="alert alert-danger">{this.state.errorMessage}</div>
      );
    } else {
      return <div />;
    }
  }
}


/*<Codenesium>
    <Hash>f5897ddc549a8e4a8a74aac77ecba8ff</Hash>
</Codenesium>*/