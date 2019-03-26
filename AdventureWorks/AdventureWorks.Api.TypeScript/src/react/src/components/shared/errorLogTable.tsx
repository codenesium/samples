import React, { Component, FormEvent } from 'react';
import axios, { AxiosError, AxiosResponse } from 'axios';
import { Constants, ApiRoutes, ClientRoutes } from '../../constants';
import * as Api from '../../api/models';
import ErrorLogMapper from '../errorLog/errorLogMapper';
import ErrorLogViewModel from '../errorLog/errorLogViewModel';
import { Form, Input, Button, Spin, Alert } from 'antd';
import { WrappedFormUtils } from 'antd/es/form/Form';
import ReactTable from 'react-table';
import * as GlobalUtilities from '../../lib/globalUtilities';

interface ErrorLogTableComponentProps {
  apiRoute: string;
  history: any;
  match: any;
}

interface ErrorLogTableComponentState {
  loading: boolean;
  loaded: boolean;
  errorOccurred: boolean;
  errorMessage: string;
  filteredRecords: Array<ErrorLogViewModel>;
}

export class ErrorLogTableComponent extends React.Component<
  ErrorLogTableComponentProps,
  ErrorLogTableComponentState
> {
  state = {
    loading: false,
    loaded: true,
    errorOccurred: false,
    errorMessage: '',
    filteredRecords: [],
  };

  handleEditClick(e: any, row: ErrorLogViewModel) {
    this.props.history.push(ClientRoutes.ErrorLogs + '/edit/' + row.errorLogID);
  }

  handleDetailClick(e: any, row: ErrorLogViewModel) {
    this.props.history.push(ClientRoutes.ErrorLogs + '/' + row.errorLogID);
  }

  componentDidMount() {
    this.loadRecords();
  }

  loadRecords() {
    this.setState({ ...this.state, loading: true });

    axios
      .get<Array<Api.ErrorLogClientResponseModel>>(this.props.apiRoute, {
        headers: GlobalUtilities.defaultHeaders(),
      })
      .then(response => {
        GlobalUtilities.logInfo(response);

        let mapper = new ErrorLogMapper();

        let errorLogs: Array<ErrorLogViewModel> = [];

        response.data.forEach(x => {
          errorLogs.push(mapper.mapApiResponseToViewModel(x));
        });

        this.setState({
          ...this.state,
          filteredRecords: errorLogs,
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
                Header: 'ErrorLogs',
                columns: [
                  {
                    Header: 'Error Line',
                    accessor: 'errorLine',
                    Cell: props => {
                      return <span>{String(props.original.errorLine)}</span>;
                    },
                  },
                  {
                    Header: 'Error Message',
                    accessor: 'errorMessage',
                    Cell: props => {
                      return <span>{String(props.original.errorMessage)}</span>;
                    },
                  },
                  {
                    Header: 'Error Number',
                    accessor: 'errorNumber',
                    Cell: props => {
                      return <span>{String(props.original.errorNumber)}</span>;
                    },
                  },
                  {
                    Header: 'Error Procedure',
                    accessor: 'errorProcedure',
                    Cell: props => {
                      return (
                        <span>{String(props.original.errorProcedure)}</span>
                      );
                    },
                  },
                  {
                    Header: 'Error Severity',
                    accessor: 'errorSeverity',
                    Cell: props => {
                      return (
                        <span>{String(props.original.errorSeverity)}</span>
                      );
                    },
                  },
                  {
                    Header: 'Error State',
                    accessor: 'errorState',
                    Cell: props => {
                      return <span>{String(props.original.errorState)}</span>;
                    },
                  },
                  {
                    Header: 'Error Time',
                    accessor: 'errorTime',
                    Cell: props => {
                      return <span>{String(props.original.errorTime)}</span>;
                    },
                  },
                  {
                    Header: 'User Name',
                    accessor: 'userName',
                    Cell: props => {
                      return <span>{String(props.original.userName)}</span>;
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
                              row.original as ErrorLogViewModel
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
                              row.original as ErrorLogViewModel
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
    <Hash>c35858222d5db09cd703df67105ae01e</Hash>
</Codenesium>*/