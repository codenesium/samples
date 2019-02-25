import React, { Component, ReactElement, ReactHTMLElement } from 'react';
import axios from 'axios';
import { Redirect } from 'react-router-dom';
import * as Api from '../../api/models';
import DatabaseLogMapper from './databaseLogMapper';
import { Constants, ApiRoutes, ClientRoutes } from '../../constants';
import ReactTable from 'react-table';
import DatabaseLogViewModel from './databaseLogViewModel';
import 'react-table/react-table.css';
import { Form, Button, Input, Row, Col, Alert, Spin } from 'antd';
import { WrappedFormUtils } from 'antd/es/form/Form';

interface DatabaseLogSearchComponentProps {
  form: WrappedFormUtils;
  history: any;
  match: any;
}

interface DatabaseLogSearchComponentState {
  records: Array<DatabaseLogViewModel>;
  filteredRecords: Array<DatabaseLogViewModel>;
  loading: boolean;
  loaded: boolean;
  errorOccurred: boolean;
  errorMessage: string;
  searchValue: string;
  deleteSubmitted: boolean;
  deleteSuccess: boolean;
  deleteResponse: string;
}

export default class DatabaseLogSearchComponent extends React.Component<
  DatabaseLogSearchComponentProps,
  DatabaseLogSearchComponentState
> {
  state = {
    deleteSubmitted: false,
    deleteSuccess: false,
    deleteResponse: '',
    records: new Array<DatabaseLogViewModel>(),
    filteredRecords: new Array<DatabaseLogViewModel>(),
    searchValue: '',
    loading: false,
    loaded: true,
    errorOccurred: false,
    errorMessage: '',
  };

  componentDidMount() {
    this.loadRecords();
  }

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

  handleCreateClick(e: any) {
    this.props.history.push(ClientRoutes.DatabaseLogs + '/create');
  }

  handleDeleteClick(e: any, row: Api.DatabaseLogClientResponseModel) {
    axios
      .delete(
        Constants.ApiEndpoint +
          ApiRoutes.DatabaseLogs +
          '/' +
          row.databaseLogID,
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
      Constants.ApiEndpoint + ApiRoutes.DatabaseLogs + '?limit=100';

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
          let response = resp.data as Array<Api.DatabaseLogClientResponseModel>;
          let viewModels: Array<DatabaseLogViewModel> = [];
          let mapper = new DatabaseLogMapper();

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
            records: new Array<DatabaseLogViewModel>(),
            filteredRecords: new Array<DatabaseLogViewModel>(),
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
                Header: 'DatabaseLogs',
                columns: [
                  {
                    Header: 'DatabaseLogID',
                    accessor: 'databaseLogID',
                    Cell: props => {
                      return (
                        <span>{String(props.original.databaseLogID)}</span>
                      );
                    },
                  },
                  {
                    Header: 'DatabaseUser',
                    accessor: 'databaseUser',
                    Cell: props => {
                      return <span>{String(props.original.databaseUser)}</span>;
                    },
                  },
                  {
                    Header: 'PostTime',
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
                    Header: 'TSQL',
                    accessor: 'tsql',
                    Cell: props => {
                      return <span>{String(props.original.tsql)}</span>;
                    },
                  },
                  {
                    Header: 'XmlEvent',
                    accessor: 'xmlEvent',
                    Cell: props => {
                      return <span>{String(props.original.xmlEvent)}</span>;
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
                        &nbsp;
                        <Button
                          type="danger"
                          onClick={(e: any) => {
                            this.handleDeleteClick(
                              e,
                              row.original as DatabaseLogViewModel
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

export const WrappedDatabaseLogSearchComponent = Form.create({
  name: 'DatabaseLog Search',
})(DatabaseLogSearchComponent);


/*<Codenesium>
    <Hash>fe9ff6ed2a932afb808b12bd7a49cb83</Hash>
</Codenesium>*/