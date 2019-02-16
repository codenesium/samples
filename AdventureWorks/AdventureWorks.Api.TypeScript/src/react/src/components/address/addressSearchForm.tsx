import React, { Component, ReactElement, ReactHTMLElement } from 'react';
import axios from 'axios';
import { Redirect } from 'react-router-dom';
import * as Api from '../../api/models';
import AddressMapper from './addressMapper';
import Constants from '../../constants';
import ReactTable from 'react-table';
import AddressViewModel from './addressViewModel';
import 'react-table/react-table.css';

interface AddressSearchComponentProps {
  history: any;
}

interface AddressSearchComponentState {
  records: Array<AddressViewModel>;
  filteredRecords: Array<AddressViewModel>;
  loading: boolean;
  loaded: boolean;
  errorOccurred: boolean;
  errorMessage: string;
  searchValue: string;
  deleteSubmitted: boolean;
  deleteSuccess: boolean;
  deleteResponse: string;
}

export default class AddressSearchComponent extends React.Component<
  AddressSearchComponentProps,
  AddressSearchComponentState
> {
  state = {
    deleteSubmitted: false,
    deleteSuccess: false,
    deleteResponse: '',
    records: new Array<Api.AddressClientResponseModel>(),
    filteredRecords: new Array<Api.AddressClientResponseModel>(),
    searchValue: '',
    loading: false,
    loaded: true,
    errorOccurred: false,
    errorMessage: '',
  };

  componentDidMount() {
    this.loadRecords();
  }

  handleEditClick(e: any, row: Api.AddressClientResponseModel) {
    this.props.history.push('/addresses/edit/' + row.addressID);
  }

  handleDetailClick(e: any, row: Api.AddressClientResponseModel) {
    this.props.history.push('/addresses/' + row.addressID);
  }

  handleCreateClick(e: any) {
    this.props.history.push('/addresses/create');
  }

  handleDeleteClick(e: any, row: Api.AddressClientResponseModel) {
    axios
      .delete(Constants.ApiUrl + 'addresses/' + row.addressID, {
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
    let searchEndpoint = Constants.ApiUrl + 'addresses' + '?limit=100';

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
          let response = resp.data as Array<Api.AddressClientResponseModel>;
          let viewModels: Array<AddressViewModel> = [];
          let mapper = new AddressMapper();

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
            records: new Array<AddressViewModel>(),
            filteredRecords: new Array<AddressViewModel>(),
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
                Header: 'Address',
                columns: [
                  {
                    Header: 'AddressID',
                    accessor: 'addressID',
                    Cell: props => {
                      return <span>{String(props.original.addressID)}</span>;
                    },
                  },
                  {
                    Header: 'AddressLine1',
                    accessor: 'addressLine1',
                    Cell: props => {
                      return <span>{String(props.original.addressLine1)}</span>;
                    },
                  },
                  {
                    Header: 'AddressLine2',
                    accessor: 'addressLine2',
                    Cell: props => {
                      return <span>{String(props.original.addressLine2)}</span>;
                    },
                  },
                  {
                    Header: 'City',
                    accessor: 'city',
                    Cell: props => {
                      return <span>{String(props.original.city)}</span>;
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
                    Header: 'PostalCode',
                    accessor: 'postalCode',
                    Cell: props => {
                      return <span>{String(props.original.postalCode)}</span>;
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
                    Header: 'StateProvinceID',
                    accessor: 'stateProvinceID',
                    Cell: props => {
                      return (
                        <span>{String(props.original.stateProvinceID)}</span>
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
                              row.original as Api.AddressClientResponseModel
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
                              row.original as Api.AddressClientResponseModel
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
                              row.original as Api.AddressClientResponseModel
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
    <Hash>cbe3b221e32d5a539d8de0f51a751d4d</Hash>
</Codenesium>*/