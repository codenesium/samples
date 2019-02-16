import React, { Component, ReactElement, ReactHTMLElement } from 'react';
import axios from 'axios';
import { Redirect } from 'react-router-dom';
import * as Api from '../../api/models';
import EmployeeMapper from './employeeMapper';
import Constants from '../../constants';
import ReactTable from 'react-table';
import EmployeeViewModel from './employeeViewModel';
import 'react-table/react-table.css';

interface EmployeeSearchComponentProps {
  history: any;
}

interface EmployeeSearchComponentState {
  records: Array<EmployeeViewModel>;
  filteredRecords: Array<EmployeeViewModel>;
  loading: boolean;
  loaded: boolean;
  errorOccurred: boolean;
  errorMessage: string;
  searchValue: string;
  deleteSubmitted: boolean;
  deleteSuccess: boolean;
  deleteResponse: string;
}

export default class EmployeeSearchComponent extends React.Component<
  EmployeeSearchComponentProps,
  EmployeeSearchComponentState
> {
  state = {
    deleteSubmitted: false,
    deleteSuccess: false,
    deleteResponse: '',
    records: new Array<Api.EmployeeClientResponseModel>(),
    filteredRecords: new Array<Api.EmployeeClientResponseModel>(),
    searchValue: '',
    loading: false,
    loaded: true,
    errorOccurred: false,
    errorMessage: '',
  };

  componentDidMount() {
    this.loadRecords();
  }

  handleEditClick(e: any, row: Api.EmployeeClientResponseModel) {
    this.props.history.push('/employees/edit/' + row.businessEntityID);
  }

  handleDetailClick(e: any, row: Api.EmployeeClientResponseModel) {
    this.props.history.push('/employees/' + row.businessEntityID);
  }

  handleCreateClick(e: any) {
    this.props.history.push('/employees/create');
  }

  handleDeleteClick(e: any, row: Api.EmployeeClientResponseModel) {
    axios
      .delete(Constants.ApiUrl + 'employees/' + row.businessEntityID, {
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
    let searchEndpoint = Constants.ApiUrl + 'employees' + '?limit=100';

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
          let response = resp.data as Array<Api.EmployeeClientResponseModel>;
          let viewModels: Array<EmployeeViewModel> = [];
          let mapper = new EmployeeMapper();

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
            records: new Array<EmployeeViewModel>(),
            filteredRecords: new Array<EmployeeViewModel>(),
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
                Header: 'Employee',
                columns: [
                  {
                    Header: 'BirthDate',
                    accessor: 'birthDate',
                    Cell: props => {
                      return <span>{String(props.original.birthDate)}</span>;
                    },
                  },
                  {
                    Header: 'BusinessEntityID',
                    accessor: 'businessEntityID',
                    Cell: props => {
                      return (
                        <span>{String(props.original.businessEntityID)}</span>
                      );
                    },
                  },
                  {
                    Header: 'CurrentFlag',
                    accessor: 'currentFlag',
                    Cell: props => {
                      return <span>{String(props.original.currentFlag)}</span>;
                    },
                  },
                  {
                    Header: 'Gender',
                    accessor: 'gender',
                    Cell: props => {
                      return <span>{String(props.original.gender)}</span>;
                    },
                  },
                  {
                    Header: 'HireDate',
                    accessor: 'hireDate',
                    Cell: props => {
                      return <span>{String(props.original.hireDate)}</span>;
                    },
                  },
                  {
                    Header: 'JobTitle',
                    accessor: 'jobTitle',
                    Cell: props => {
                      return <span>{String(props.original.jobTitle)}</span>;
                    },
                  },
                  {
                    Header: 'LoginID',
                    accessor: 'loginID',
                    Cell: props => {
                      return <span>{String(props.original.loginID)}</span>;
                    },
                  },
                  {
                    Header: 'MaritalStatus',
                    accessor: 'maritalStatu',
                    Cell: props => {
                      return <span>{String(props.original.maritalStatu)}</span>;
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
                    Header: 'NationalIDNumber',
                    accessor: 'nationalIDNumber',
                    Cell: props => {
                      return (
                        <span>{String(props.original.nationalIDNumber)}</span>
                      );
                    },
                  },
                  {
                    Header: 'OrganizationLevel',
                    accessor: 'organizationLevel',
                    Cell: props => {
                      return (
                        <span>{String(props.original.organizationLevel)}</span>
                      );
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
                    Header: 'SalariedFlag',
                    accessor: 'salariedFlag',
                    Cell: props => {
                      return <span>{String(props.original.salariedFlag)}</span>;
                    },
                  },
                  {
                    Header: 'SickLeaveHours',
                    accessor: 'sickLeaveHour',
                    Cell: props => {
                      return (
                        <span>{String(props.original.sickLeaveHour)}</span>
                      );
                    },
                  },
                  {
                    Header: 'VacationHours',
                    accessor: 'vacationHour',
                    Cell: props => {
                      return <span>{String(props.original.vacationHour)}</span>;
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
                              row.original as Api.EmployeeClientResponseModel
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
                              row.original as Api.EmployeeClientResponseModel
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
                              row.original as Api.EmployeeClientResponseModel
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
    <Hash>1dc060ec7cdddd561974cc74bf4024e5</Hash>
</Codenesium>*/