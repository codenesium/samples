import React, { Component, ReactElement, ReactHTMLElement } from 'react';
import axios from 'axios';
import { Redirect } from 'react-router-dom';
import * as Api from '../../api/models';
import AWBuildVersionMapper from './aWBuildVersionMapper';
import Constants from '../../constants';
import ReactTable from 'react-table';
import AWBuildVersionViewModel from './aWBuildVersionViewModel';
import 'react-table/react-table.css';

interface AWBuildVersionSearchComponentProps {
  history: any;
}

interface AWBuildVersionSearchComponentState {
  records: Array<AWBuildVersionViewModel>;
  filteredRecords: Array<AWBuildVersionViewModel>;
  loading: boolean;
  loaded: boolean;
  errorOccurred: boolean;
  errorMessage: string;
  searchValue: string;
  deleteSubmitted: boolean;
  deleteSuccess: boolean;
  deleteResponse: string;
}

export default class AWBuildVersionSearchComponent extends React.Component<
  AWBuildVersionSearchComponentProps,
  AWBuildVersionSearchComponentState
> {
  state = {
    deleteSubmitted: false,
    deleteSuccess: false,
    deleteResponse: '',
    records: new Array<Api.AWBuildVersionClientResponseModel>(),
    filteredRecords: new Array<Api.AWBuildVersionClientResponseModel>(),
    searchValue: '',
    loading: false,
    loaded: true,
    errorOccurred: false,
    errorMessage: '',
  };

  componentDidMount() {
    this.loadRecords();
  }

  handleEditClick(e: any, row: Api.AWBuildVersionClientResponseModel) {
    this.props.history.push('/awbuildversions/edit/' + row.systemInformationID);
  }

  handleDetailClick(e: any, row: Api.AWBuildVersionClientResponseModel) {
    this.props.history.push('/awbuildversions/' + row.systemInformationID);
  }

  handleCreateClick(e: any) {
    this.props.history.push('/awbuildversions/create');
  }

  handleDeleteClick(e: any, row: Api.AWBuildVersionClientResponseModel) {
    axios
      .delete(Constants.ApiUrl + 'awbuildversions/' + row.systemInformationID, {
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
    let searchEndpoint = Constants.ApiUrl + 'awbuildversions' + '?limit=100';

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
            Api.AWBuildVersionClientResponseModel
          >;
          let viewModels: Array<AWBuildVersionViewModel> = [];
          let mapper = new AWBuildVersionMapper();

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
            records: new Array<AWBuildVersionViewModel>(),
            filteredRecords: new Array<AWBuildVersionViewModel>(),
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
                Header: 'AWBuildVersion',
                columns: [
                  {
                    Header: 'Database Version',
                    accessor: 'database_Version',
                    Cell: props => {
                      return (
                        <span>{String(props.original.database_Version)}</span>
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
                    Header: 'SystemInformationID',
                    accessor: 'systemInformationID',
                    Cell: props => {
                      return (
                        <span>
                          {String(props.original.systemInformationID)}
                        </span>
                      );
                    },
                  },
                  {
                    Header: 'VersionDate',
                    accessor: 'versionDate',
                    Cell: props => {
                      return <span>{String(props.original.versionDate)}</span>;
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
                              row.original as Api.AWBuildVersionClientResponseModel
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
                              row.original as Api.AWBuildVersionClientResponseModel
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
                              row.original as Api.AWBuildVersionClientResponseModel
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
    <Hash>9e12dc90917e28d68e947896fc250b01</Hash>
</Codenesium>*/