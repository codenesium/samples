import React, { Component, ReactElement, ReactHTMLElement } from 'react';
import axios from 'axios';
import { Redirect } from 'react-router-dom';
import * as Api from '../../api/models';
import ErrorLogMapper from './errorLogMapper';
import Constants from '../../constants';
import ReactTable from 'react-table';
import ErrorLogViewModel from './errorLogViewModel';
import 'react-table/react-table.css';

interface ErrorLogSearchComponentProps {
  history: any;
}

interface ErrorLogSearchComponentState {
  records: Array<ErrorLogViewModel>;
  filteredRecords: Array<ErrorLogViewModel>;
  loading: boolean;
  loaded: boolean;
  errorOccurred: boolean;
  errorMessage: string;
  searchValue: string;
  deleteSubmitted: boolean;
  deleteSuccess: boolean;
  deleteResponse: string;
}

export default class ErrorLogSearchComponent extends React.Component<
  ErrorLogSearchComponentProps,
  ErrorLogSearchComponentState
> {
  state = {
    deleteSubmitted: false,
    deleteSuccess: false,
    deleteResponse: '',
    records: new Array<Api.ErrorLogClientResponseModel>(),
    filteredRecords: new Array<Api.ErrorLogClientResponseModel>(),
    searchValue: '',
    loading: false,
    loaded: true,
    errorOccurred: false,
    errorMessage: '',
  };

  componentDidMount() {
    this.loadRecords();
  }

  handleEditClick(e: any, row: Api.ErrorLogClientResponseModel) {
    this.props.history.push('/errorlogs/edit/' + row.errorLogID);
  }

  handleDetailClick(e: any, row: Api.ErrorLogClientResponseModel) {
    this.props.history.push('/errorlogs/' + row.errorLogID);
  }

  handleCreateClick(e: any) {
    this.props.history.push('/errorlogs/create');
  }

  handleDeleteClick(e: any, row: Api.ErrorLogClientResponseModel) {
    axios
      .delete(Constants.ApiUrl + 'errorlogs/' + row.errorLogID, {
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
    let searchEndpoint = Constants.ApiUrl + 'errorlogs' + '?limit=100';

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
          let response = resp.data as Array<Api.ErrorLogClientResponseModel>;
          let viewModels: Array<ErrorLogViewModel> = [];
          let mapper = new ErrorLogMapper();

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
            records: new Array<ErrorLogViewModel>(),
            filteredRecords: new Array<ErrorLogViewModel>(),
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
                Header: 'ErrorLog',
                columns: [
                  {
                    Header: 'ErrorLine',
                    accessor: 'errorLine',
                    Cell: props => {
                      return <span>{String(props.original.errorLine)}</span>;
                    },
                  },
                  {
                    Header: 'ErrorLogID',
                    accessor: 'errorLogID',
                    Cell: props => {
                      return <span>{String(props.original.errorLogID)}</span>;
                    },
                  },
                  {
                    Header: 'ErrorMessage',
                    accessor: 'errorMessage',
                    Cell: props => {
                      return <span>{String(props.original.errorMessage)}</span>;
                    },
                  },
                  {
                    Header: 'ErrorNumber',
                    accessor: 'errorNumber',
                    Cell: props => {
                      return <span>{String(props.original.errorNumber)}</span>;
                    },
                  },
                  {
                    Header: 'ErrorProcedure',
                    accessor: 'errorProcedure',
                    Cell: props => {
                      return (
                        <span>{String(props.original.errorProcedure)}</span>
                      );
                    },
                  },
                  {
                    Header: 'ErrorSeverity',
                    accessor: 'errorSeverity',
                    Cell: props => {
                      return (
                        <span>{String(props.original.errorSeverity)}</span>
                      );
                    },
                  },
                  {
                    Header: 'ErrorState',
                    accessor: 'errorState',
                    Cell: props => {
                      return <span>{String(props.original.errorState)}</span>;
                    },
                  },
                  {
                    Header: 'ErrorTime',
                    accessor: 'errorTime',
                    Cell: props => {
                      return <span>{String(props.original.errorTime)}</span>;
                    },
                  },
                  {
                    Header: 'UserName',
                    accessor: 'userName',
                    Cell: props => {
                      return <span>{String(props.original.userName)}</span>;
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
                              row.original as Api.ErrorLogClientResponseModel
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
                              row.original as Api.ErrorLogClientResponseModel
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
                              row.original as Api.ErrorLogClientResponseModel
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
    <Hash>ed05dcfa60e9a080a8412721fbd85a98</Hash>
</Codenesium>*/