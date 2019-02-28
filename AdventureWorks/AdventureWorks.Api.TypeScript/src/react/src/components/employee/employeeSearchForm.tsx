import React, { Component, ReactElement, ReactHTMLElement } from 'react';
import axios from 'axios';
import { Redirect } from 'react-router-dom';
import * as Api from '../../api/models';
import EmployeeMapper from './employeeMapper';
import { Constants, ApiRoutes, ClientRoutes } from '../../constants';
import ReactTable from 'react-table';
import EmployeeViewModel from './employeeViewModel';
import 'react-table/react-table.css';
import { Form, Button, Input, Row, Col, Alert, Spin } from 'antd';
import { WrappedFormUtils } from 'antd/es/form/Form';

interface EmployeeSearchComponentProps {
  form: WrappedFormUtils;
  history: any;
  match: any;
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
    records: new Array<EmployeeViewModel>(),
    filteredRecords: new Array<EmployeeViewModel>(),
    searchValue: '',
    loading: false,
    loaded: true,
    errorOccurred: false,
    errorMessage: '',
  };

  componentDidMount() {
    this.loadRecords();
  }

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

  handleCreateClick(e: any) {
    this.props.history.push(ClientRoutes.Employees + '/create');
  }

  handleDeleteClick(e: any, row: Api.EmployeeClientResponseModel) {
    axios
      .delete(
        Constants.ApiEndpoint +
          ApiRoutes.Employees +
          '/' +
          row.businessEntityID,
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
      Constants.ApiEndpoint + ApiRoutes.Employees + '?limit=100';

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
            loaded: true,
            errorOccurred: true,
            errorMessage: 'Error from API',
          });
        }
      );
  }

  filterGrid() {}

  render() {
    if (this.state.loading) {
      return <Spin size="large" />;
    } else if (this.state.errorOccurred) {
      return <Alert message={this.state.errorMessage} type="error" />;
    } else if (this.state.loaded) {
      let errorResponse: JSX.Element = <span />;

      if (this.state.deleteSubmitted) {
        if (this.state.deleteSuccess) {
          errorResponse = (
            <Alert
              message={this.state.deleteResponse}
              type="success"
              style={{ marginBottom: '25px' }}
            />
          );
        } else {
          errorResponse = (
            <Alert
              message={this.state.deleteResponse}
              type="error"
              style={{ marginBottom: '25px' }}
            />
          );
        }
      }

      return (
        <div>
          {errorResponse}
          <Row>
            <Col span={8} />
            <Col span={8}>
              <Input
                placeholder={'Search'}
                id={'search'}
                onChange={(e: any) => {
                  this.handleSearchChanged(e);
                }}
              />
            </Col>
            <Col span={8}>
              <Button
                style={{ float: 'right' }}
                type="primary"
                onClick={(e: any) => {
                  this.handleCreateClick(e);
                }}
              >
                +
              </Button>
            </Col>
          </Row>
          <br />
          <br />
          <ReactTable
            data={this.state.filteredRecords}
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
                        &nbsp;
                        <Button
                          type="danger"
                          onClick={(e: any) => {
                            this.handleDeleteClick(
                              e,
                              row.original as EmployeeViewModel
                            );
                          }}
                        >
                          <i className="far fa-trash-alt" />
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

export const WrappedEmployeeSearchComponent = Form.create({
  name: 'Employee Search',
})(EmployeeSearchComponent);


/*<Codenesium>
    <Hash>21c37f164e2b7d42b1cb400910f32432</Hash>
</Codenesium>*/