import React, { Component, FormEvent } from 'react';
import axios from 'axios';
import { Constants, ApiRoutes, ClientRoutes } from '../../constants';
import * as Api from '../../api/models';
import ErrorLogMapper from '../errorLog/errorLogMapper';
import ErrorLogViewModel from '../errorLog/errorLogViewModel';
import { Form, Input, Button, Spin, Alert } from 'antd';
import { WrappedFormUtils } from 'antd/es/form/Form';
import ReactTable from 'react-table';

interface ErrorLogTableComponentProps {
  errorLogID: number;
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
    this.props.history.push(ClientRoutes.ErrorLogs + '/edit/' + row.id);
  }

  handleDetailClick(e: any, row: ErrorLogViewModel) {
    this.props.history.push(ClientRoutes.ErrorLogs + '/' + row.id);
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
          let response = resp.data as Array<Api.ErrorLogClientResponseModel>;

          console.log(response);

          let mapper = new ErrorLogMapper();

          let errorLogs: Array<ErrorLogViewModel> = [];

          response.forEach(x => {
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
                Header: 'ErrorLogs',
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
    <Hash>84e923d5b60208a14901cc6bdd7ddbfc</Hash>
</Codenesium>*/