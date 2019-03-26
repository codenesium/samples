import React, { Component, FormEvent } from 'react';
import axios, { AxiosError, AxiosResponse } from 'axios';
import { Constants, ApiRoutes, ClientRoutes } from '../../constants';
import * as Api from '../../api/models';
import EmployeeMapper from '../employee/employeeMapper';
import EmployeeViewModel from '../employee/employeeViewModel';
import { Form, Input, Button, Spin, Alert } from 'antd';
import { WrappedFormUtils } from 'antd/es/form/Form';
import ReactTable from 'react-table';
import * as GlobalUtilities from '../../lib/globalUtilities';

interface EmployeeTableComponentProps {
  apiRoute: string;
  history: any;
  match: any;
}

interface EmployeeTableComponentState {
  loading: boolean;
  loaded: boolean;
  errorOccurred: boolean;
  errorMessage: string;
  filteredRecords: Array<EmployeeViewModel>;
}

export class EmployeeTableComponent extends React.Component<
  EmployeeTableComponentProps,
  EmployeeTableComponentState
> {
  state = {
    loading: false,
    loaded: true,
    errorOccurred: false,
    errorMessage: '',
    filteredRecords: [],
  };

  handleEditClick(e: any, row: EmployeeViewModel) {
    this.props.history.push(
      ClientRoutes.Employees + '/edit/' + row.businessEntityID
    );
  }

  handleDetailClick(e: any, row: EmployeeViewModel) {
    this.props.history.push(
      ClientRoutes.Employees + '/' + row.businessEntityID
    );
  }

  componentDidMount() {
    this.loadRecords();
  }

  loadRecords() {
    this.setState({ ...this.state, loading: true });

    axios
      .get<Array<Api.EmployeeClientResponseModel>>(this.props.apiRoute, {
        headers: GlobalUtilities.defaultHeaders(),
      })
      .then(response => {
        GlobalUtilities.logInfo(response);

        let mapper = new EmployeeMapper();

        let employees: Array<EmployeeViewModel> = [];

        response.data.forEach(x => {
          employees.push(mapper.mapApiResponseToViewModel(x));
        });

        this.setState({
          ...this.state,
          filteredRecords: employees,
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
                Header: 'Employees',
                columns: [
                  {
                    Header: 'Birth Date',
                    accessor: 'birthDate',
                    Cell: props => {
                      return <span>{String(props.original.birthDate)}</span>;
                    },
                  },
                  {
                    Header: 'Current Flag',
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
                    Header: 'Hire Date',
                    accessor: 'hireDate',
                    Cell: props => {
                      return <span>{String(props.original.hireDate)}</span>;
                    },
                  },
                  {
                    Header: 'Job Title',
                    accessor: 'jobTitle',
                    Cell: props => {
                      return <span>{String(props.original.jobTitle)}</span>;
                    },
                  },
                  {
                    Header: 'Login I D',
                    accessor: 'loginID',
                    Cell: props => {
                      return <span>{String(props.original.loginID)}</span>;
                    },
                  },
                  {
                    Header: 'Marital Status',
                    accessor: 'maritalStatu',
                    Cell: props => {
                      return <span>{String(props.original.maritalStatu)}</span>;
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
                    Header: 'National I D Number',
                    accessor: 'nationalIDNumber',
                    Cell: props => {
                      return (
                        <span>{String(props.original.nationalIDNumber)}</span>
                      );
                    },
                  },
                  {
                    Header: 'Organization Level',
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
                    Header: 'Salaried Flag',
                    accessor: 'salariedFlag',
                    Cell: props => {
                      return <span>{String(props.original.salariedFlag)}</span>;
                    },
                  },
                  {
                    Header: 'Sick Leave Hours',
                    accessor: 'sickLeaveHour',
                    Cell: props => {
                      return (
                        <span>{String(props.original.sickLeaveHour)}</span>
                      );
                    },
                  },
                  {
                    Header: 'Vacation Hours',
                    accessor: 'vacationHour',
                    Cell: props => {
                      return <span>{String(props.original.vacationHour)}</span>;
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
                              row.original as EmployeeViewModel
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
                              row.original as EmployeeViewModel
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
    <Hash>894fc213a40afcdfc48a5c3afac0d0dc</Hash>
</Codenesium>*/