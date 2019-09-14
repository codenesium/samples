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
    this.props.history.push(ClientRoutes.Employees + '/edit/' + row.id);
  }

  handleDetailClick(e: any, row: EmployeeViewModel) {
    this.props.history.push(ClientRoutes.Employees + '/' + row.id);
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
                    Header: 'First Name',
                    accessor: 'firstName',
                    Cell: props => {
                      return <span>{String(props.original.firstName)}</span>;
                    },
                  },
                  {
                    Header: 'Is Sales Person',
                    accessor: 'isSalesPerson',
                    Cell: props => {
                      return (
                        <span>{String(props.original.isSalesPerson)}</span>
                      );
                    },
                  },
                  {
                    Header: 'Is Shipper',
                    accessor: 'isShipper',
                    Cell: props => {
                      return <span>{String(props.original.isShipper)}</span>;
                    },
                  },
                  {
                    Header: 'Last Name',
                    accessor: 'lastName',
                    Cell: props => {
                      return <span>{String(props.original.lastName)}</span>;
                    },
                  },
                  {
                    Header: 'Actions',
                    minWidth: 150,
                    Cell: row => (
                      <div>
                        <Button
                          htmlType="button"
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
                          htmlType="button"
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
    <Hash>dd6041105744a47632c18db97c0d4c4c</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/