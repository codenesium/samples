import React, { Component, ReactElement, ReactHTMLElement } from 'react';
import axios from 'axios';
import { Redirect } from 'react-router-dom';
import * as Api from '../api/models';
import AdminMapper from '../mapping/adminMapper';
import Constants from '../constants';
import ReactTable from 'react-table';
import AdminViewModel from '../viewmodels/adminViewModel';
import 'react-table/react-table.css';

interface AdminSearchComponentProps {}

interface AdminSearchComponentState {
  records: Array<AdminViewModel>;
  filteredRecords: Array<AdminViewModel>;
  loading: boolean;
  loaded: boolean;
  errorOccurred: boolean;
  errorMessage: string;
  toUpdate: boolean;
  toUpdateId: number;
  toDetail: boolean;
  toDetailId: number;
  toCreate: boolean;
  searchValue: string;
  deleteSubmitted: boolean;
  deleteSuccess: boolean;
  deleteResponse: string;
}

export default class AdminSearchComponent extends React.Component<
  AdminSearchComponentProps,
  AdminSearchComponentState
> {
  state = {
    deleteSubmitted: false,
    deleteSuccess: false,
    deleteResponse: '',
    records: new Array<Api.AdminClientResponseModel>(),
    filteredRecords: new Array<Api.AdminClientResponseModel>(),
    searchValue: '',
    loading: false,
    loaded: true,
    toCreate: false,
    errorOccurred: false,
    errorMessage: '',
    toUpdate: false,
    toUpdateId: 0,
    toDetail: false,
    toDetailId: 0,
  };

  componentDidMount() {
    this.loadData();
  }

  loadData() {
    axios
      .get(Constants.ApiUrl + 'Admins', {
        headers: {
          'Content-Type': 'application/json',
        },
      })
      .then(
        resp => {
          let response = resp.data as Array<Api.AdminClientResponseModel>;

          let viewModels: Array<AdminViewModel> = [];
          let mapper = new AdminMapper();

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
          let response = error.response.data as Array<
            Api.AdminClientResponseModel
          >;
          this.setState({
            records: new Array<AdminViewModel>(),
            filteredRecords: new Array<AdminViewModel>(),
            loading: false,
            loaded: false,
            errorOccurred: true,
            errorMessage: 'Error from API',
          });
          console.log(response);
        }
      );
  }

  handleEditClick(e: any, row: Api.AdminClientResponseModel) {
    this.setState({ ...this.state, toUpdate: true, toUpdateId: row.id });
  }

  handleDetailClick(e: any, row: Api.AdminClientResponseModel) {
    this.setState({ ...this.state, toDetail: true, toDetailId: row.id });
  }

  handleCreateClick(e: any) {
    this.setState({ ...this.state, toCreate: true });
  }

  handleDeleteClick(e: any, row: Api.AdminClientResponseModel) {
    axios
      .delete(Constants.ApiUrl + 'admins/' + row.id, {
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
          this.loadData();
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
    /*console.log(e);
        let filtered = this.state.records.filter(x =>
            {
                //return x.name.startsWith(e.currentTarget.value) ||
                //x.publicId.startsWith(e.currentTarget.value);
                //console.log(Object.values(x));
                //let found = Object.values(x).startsWith(e.currentTarget.value);
                // return found;
            });
        this.setState({...this.state,filteredRecords:filtered, searchValue:e.currentTarget.value});
    */

    this.setState({ ...this.state, searchValue: e.currentTarget.value });
    axios
      .get(Constants.ApiUrl + 'Admins?q=' + e.currentTarget.value, {
        headers: {
          'Content-Type': 'application/json',
        },
      })
      .then(
        resp => {
          let response = resp.data as Array<Api.AdminClientResponseModel>;
          this.setState({
            records: response,
            filteredRecords: response,
            loading: false,
            loaded: true,
            errorOccurred: false,
            errorMessage: '',
          });
        },
        error => {
          let response = error.response.data as Array<
            Api.AdminClientResponseModel
          >;
          this.setState({
            records: new Array<Api.AdminClientResponseModel>(),
            filteredRecords: new Array<Api.AdminClientResponseModel>(),
            loading: false,
            loaded: false,
            errorOccurred: true,
            errorMessage: 'Error from API',
          });
          console.log(response);
        }
      );
  }

  filterGrid() {}

  render() {
    if (this.state.toCreate) {
      return <Redirect to={'/admins/create'} />;
    } else if (this.state.toUpdate) {
      return <Redirect to={'/admins/edit/' + this.state.toUpdateId} />;
    } else if (this.state.toDetail) {
      return <Redirect to={'/admins/' + this.state.toDetailId} />;
    } else if (this.state.loading) {
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
                  className="btn btn-primary btn-sm align-middle float-right vertically-center"
                  onClick={e => this.handleCreateClick(e)}
                >
                  Create
                </button>
              </div>
            </div>
          </form>
          <ReactTable
            data={this.state.filteredRecords}
            columns={[
              {
                Header: 'Admins',
                columns: [
                  {
                    Header: 'Birthday',
                    accessor: 'birthday',
                  },
                  {
                    Header: 'Email',
                    accessor: 'email',
                  },
                  {
                    Header: 'FirstName',
                    accessor: 'firstName',
                  },
                  {
                    Header: 'Id',
                    accessor: 'id',
                  },
                  {
                    Header: 'IsDeleted',
                    accessor: 'isDeleted',
                  },
                  {
                    Header: 'LastName',
                    accessor: 'lastName',
                  },
                  {
                    Header: 'Phone',
                    accessor: 'phone',
                  },
                  {
                    Header: 'TenantId',
                    accessor: 'tenantId',
                  },
                  {
                    Header: 'UserId',
                    accessor: 'userId',
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
                              row.original as Api.AdminClientResponseModel
                            );
                          }}
                        >
                          Detail
                        </button>
                        &nbsp;
                        <button
                          className="btn btn-primary btn-sm"
                          onClick={e => {
                            this.handleEditClick(
                              e,
                              row.original as Api.AdminClientResponseModel
                            );
                          }}
                        >
                          Edit
                        </button>
                        &nbsp;
                        <button
                          className="btn btn-danger btn-sm"
                          onClick={e => {
                            this.handleDeleteClick(
                              e,
                              row.original as Api.AdminClientResponseModel
                            );
                          }}
                        >
                          Delete
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
      return <div>{this.state.errorMessage}</div>;
    } else {
      return <div />;
    }
  }
}


/*<Codenesium>
    <Hash>b0c7d5cfd761d55ad9267f763a6023ad</Hash>
</Codenesium>*/