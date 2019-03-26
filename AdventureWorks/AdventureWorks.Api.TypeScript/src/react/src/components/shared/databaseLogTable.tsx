import React, { Component, FormEvent } from 'react';
import axios, { AxiosError, AxiosResponse } from 'axios';
import { Constants, ApiRoutes, ClientRoutes } from '../../constants';
import * as Api from '../../api/models';
import DatabaseLogMapper from '../databaseLog/databaseLogMapper';
import DatabaseLogViewModel from '../databaseLog/databaseLogViewModel';
import { Form, Input, Button, Spin, Alert } from 'antd';
import { WrappedFormUtils } from 'antd/es/form/Form';
import ReactTable from 'react-table';
import * as GlobalUtilities from '../../lib/globalUtilities';

interface DatabaseLogTableComponentProps {
  apiRoute: string;
  history: any;
  match: any;
}

interface DatabaseLogTableComponentState {
  loading: boolean;
  loaded: boolean;
  errorOccurred: boolean;
  errorMessage: string;
  filteredRecords: Array<DatabaseLogViewModel>;
}

export class DatabaseLogTableComponent extends React.Component<
  DatabaseLogTableComponentProps,
  DatabaseLogTableComponentState
> {
  state = {
    loading: false,
    loaded: true,
    errorOccurred: false,
    errorMessage: '',
    filteredRecords: [],
  };

  handleEditClick(e: any, row: DatabaseLogViewModel) {
    this.props.history.push(
      ClientRoutes.DatabaseLogs + '/edit/' + row.databaseLogID
    );
  }

  handleDetailClick(e: any, row: DatabaseLogViewModel) {
    this.props.history.push(
      ClientRoutes.DatabaseLogs + '/' + row.databaseLogID
    );
  }

  componentDidMount() {
    this.loadRecords();
  }

  loadRecords() {
    this.setState({ ...this.state, loading: true });

    axios
      .get<Array<Api.DatabaseLogClientResponseModel>>(this.props.apiRoute, {
        headers: GlobalUtilities.defaultHeaders(),
      })
      .then(response => {
        GlobalUtilities.logInfo(response);

        let mapper = new DatabaseLogMapper();

        let databaseLogs: Array<DatabaseLogViewModel> = [];

        response.data.forEach(x => {
          databaseLogs.push(mapper.mapApiResponseToViewModel(x));
        });

        this.setState({
          ...this.state,
          filteredRecords: databaseLogs,
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
                Header: 'DatabaseLogs',
                columns: [
                  {
                    Header: 'Database User',
                    accessor: 'databaseUser',
                    Cell: props => {
                      return <span>{String(props.original.databaseUser)}</span>;
                    },
                  },
                  {
                    Header: 'Event',
                    accessor: 'reservedEvent',
                    Cell: props => {
                      return (
                        <span>{String(props.original.reservedEvent)}</span>
                      );
                    },
                  },
                  {
                    Header: 'Object',
                    accessor: 'reservedObject',
                    Cell: props => {
                      return (
                        <span>{String(props.original.reservedObject)}</span>
                      );
                    },
                  },
                  {
                    Header: 'Post Time',
                    accessor: 'postTime',
                    Cell: props => {
                      return <span>{String(props.original.postTime)}</span>;
                    },
                  },
                  {
                    Header: 'Schema',
                    accessor: 'schema',
                    Cell: props => {
                      return <span>{String(props.original.schema)}</span>;
                    },
                  },
                  {
                    Header: 'T S Q L',
                    accessor: 'tsql',
                    Cell: props => {
                      return <span>{String(props.original.tsql)}</span>;
                    },
                  },
                  {
                    Header: 'Xml Event',
                    accessor: 'xmlEvent',
                    Cell: props => {
                      return <span>{String(props.original.xmlEvent)}</span>;
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
                              row.original as DatabaseLogViewModel
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
                              row.original as DatabaseLogViewModel
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
    <Hash>d7b11bdd78f61b3c94acb5609b7f9aa5</Hash>
</Codenesium>*/