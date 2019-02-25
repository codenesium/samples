import React, { Component, FormEvent } from 'react';
import axios from 'axios';
import { Constants, ApiRoutes, ClientRoutes } from '../../constants';
import * as Api from '../../api/models';
import EmployeeMapper from '../employee/employeeMapper';
import EmployeeViewModel from '../employee/employeeViewModel';
import { Form, Input, Button, Spin, Alert } from 'antd';
import { WrappedFormUtils } from 'antd/es/form/Form';
import ReactTable from 'react-table';

interface EmployeeTableComponentProps {
  businessEntityID: number;
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
    this.props.history.push(ClientRoutes.Employees + '/edit/' + row.id);
  }

  handleDetailClick(e: any, row: EmployeeViewModel) {
    this.props.history.push(ClientRoutes.Employees + '/' + row.id);
  }

  componentDidMount() {
    this.setState({ ...this.state, loading: true });

    axios
      .get(this.props.apiRoute, {
        headers: {
          'Content-Type': 'application/json',
        },
      })
      .then(
        resp => {
          let response = resp.data as Array<Api.EmployeeClientResponseModel>;

          console.log(response);

          let mapper = new EmployeeMapper();

          let employees: Array<EmployeeViewModel> = [];

          response.forEach(x => {
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
        },
        error => {
          console.log(error);
          this.setState({
            ...this.state,
            loading: false,
            loaded: false,
            errorOccurred: true,
            errorMessage: 'Error from API',
          });
        }
      );
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
    <Hash>e0fe1d56ecedb26c2aec3b818077b070</Hash>
</Codenesium>*/