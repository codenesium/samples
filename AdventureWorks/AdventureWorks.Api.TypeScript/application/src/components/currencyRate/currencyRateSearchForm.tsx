import React, { Component, ReactElement, ReactHTMLElement } from 'react';
import axios from 'axios';
import { Redirect } from 'react-router-dom';
import * as Api from '../../api/models';
import CurrencyRateMapper from './currencyRateMapper';
import Constants from '../../constants';
import ReactTable from 'react-table';
import CurrencyRateViewModel from './currencyRateViewModel';
import 'react-table/react-table.css';

interface CurrencyRateSearchComponentProps {
  history: any;
}

interface CurrencyRateSearchComponentState {
  records: Array<CurrencyRateViewModel>;
  filteredRecords: Array<CurrencyRateViewModel>;
  loading: boolean;
  loaded: boolean;
  errorOccurred: boolean;
  errorMessage: string;
  searchValue: string;
  deleteSubmitted: boolean;
  deleteSuccess: boolean;
  deleteResponse: string;
}

export default class CurrencyRateSearchComponent extends React.Component<
  CurrencyRateSearchComponentProps,
  CurrencyRateSearchComponentState
> {
  state = {
    deleteSubmitted: false,
    deleteSuccess: false,
    deleteResponse: '',
    records: new Array<Api.CurrencyRateClientResponseModel>(),
    filteredRecords: new Array<Api.CurrencyRateClientResponseModel>(),
    searchValue: '',
    loading: false,
    loaded: true,
    errorOccurred: false,
    errorMessage: '',
  };

  componentDidMount() {
    this.loadRecords();
  }

  handleEditClick(e: any, row: Api.CurrencyRateClientResponseModel) {
    this.props.history.push('/currencyrates/edit/' + row.currencyRateID);
  }

  handleDetailClick(e: any, row: Api.CurrencyRateClientResponseModel) {
    this.props.history.push('/currencyrates/' + row.currencyRateID);
  }

  handleCreateClick(e: any) {
    this.props.history.push('/currencyrates/create');
  }

  handleDeleteClick(e: any, row: Api.CurrencyRateClientResponseModel) {
    axios
      .delete(Constants.ApiUrl + 'currencyrates/' + row.currencyRateID, {
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
    let searchEndpoint = Constants.ApiUrl + 'currencyrates' + '?limit=100';

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
            Api.CurrencyRateClientResponseModel
          >;
          let viewModels: Array<CurrencyRateViewModel> = [];
          let mapper = new CurrencyRateMapper();

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
            records: new Array<CurrencyRateViewModel>(),
            filteredRecords: new Array<CurrencyRateViewModel>(),
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
                Header: 'CurrencyRate',
                columns: [
                  {
                    Header: 'AverageRate',
                    accessor: 'averageRate',
                    Cell: props => {
                      return <span>{String(props.original.averageRate)}</span>;
                    },
                  },
                  {
                    Header: 'CurrencyRateDate',
                    accessor: 'currencyRateDate',
                    Cell: props => {
                      return (
                        <span>{String(props.original.currencyRateDate)}</span>
                      );
                    },
                  },
                  {
                    Header: 'CurrencyRateID',
                    accessor: 'currencyRateID',
                    Cell: props => {
                      return (
                        <span>{String(props.original.currencyRateID)}</span>
                      );
                    },
                  },
                  {
                    Header: 'EndOfDayRate',
                    accessor: 'endOfDayRate',
                    Cell: props => {
                      return <span>{String(props.original.endOfDayRate)}</span>;
                    },
                  },
                  {
                    Header: 'FromCurrencyCode',
                    accessor: 'fromCurrencyCode',
                    Cell: props => {
                      return (
                        <span>{String(props.original.fromCurrencyCode)}</span>
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
                    Header: 'ToCurrencyCode',
                    accessor: 'toCurrencyCode',
                    Cell: props => {
                      return (
                        <span>{String(props.original.toCurrencyCode)}</span>
                      );
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
                              row.original as Api.CurrencyRateClientResponseModel
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
                              row.original as Api.CurrencyRateClientResponseModel
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
                              row.original as Api.CurrencyRateClientResponseModel
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
    <Hash>5155bb74b6f5372c4dc99f86901a99fd</Hash>
</Codenesium>*/