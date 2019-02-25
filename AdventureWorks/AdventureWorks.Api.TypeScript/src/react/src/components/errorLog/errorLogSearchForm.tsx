import React, { Component, ReactElement, ReactHTMLElement } from 'react';
import axios from 'axios';
import { Redirect } from 'react-router-dom';
import * as Api from '../../api/models';
import ErrorLogMapper from './errorLogMapper';
import { Constants, ApiRoutes, ClientRoutes } from '../../constants';
import ReactTable from 'react-table';
import ErrorLogViewModel from './errorLogViewModel';
import 'react-table/react-table.css';
import { Form, Button, Input, Row, Col, Alert, Spin } from 'antd';
import { WrappedFormUtils } from 'antd/es/form/Form';

interface ErrorLogSearchComponentProps {
  form: WrappedFormUtils;
  history: any;
  match: any;
}

interface ErrorLogSearchComponentState {
  records: Array<ErrorLogViewModel>;
  filteredRecords: Array<ErrorLogViewModel>;
  loading: boolean;
  loaded: boolean;
  errorOccurred: boolean;
  errorMessage: string;
  searchValue: string;
  deleteSubmitted: boolean;
  deleteSuccess: boolean;
  deleteResponse: string;
}

export default class ErrorLogSearchComponent extends React.Component<
  ErrorLogSearchComponentProps,
  ErrorLogSearchComponentState
> {
  state = {
    deleteSubmitted: false,
    deleteSuccess: false,
    deleteResponse: '',
    records: new Array<ErrorLogViewModel>(),
    filteredRecords: new Array<ErrorLogViewModel>(),
    searchValue: '',
    loading: false,
    loaded: true,
    errorOccurred: false,
    errorMessage: '',
  };

  componentDidMount() {
    this.loadRecords();
  }

  handleEditClick(e: any, row: ErrorLogViewModel) {
    this.props.history.push(ClientRoutes.ErrorLogs + '/edit/' + row.errorLogID);
  }

  handleDetailClick(e: any, row: ErrorLogViewModel) {
    this.props.history.push(ClientRoutes.ErrorLogs + '/' + row.errorLogID);
  }

  handleCreateClick(e: any) {
    this.props.history.push(ClientRoutes.ErrorLogs + '/create');
  }

  handleDeleteClick(e: any, row: Api.ErrorLogClientResponseModel) {
    axios
      .delete(
        Constants.ApiEndpoint + ApiRoutes.ErrorLogs + '/' + row.errorLogID,
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
      Constants.ApiEndpoint + ApiRoutes.ErrorLogs + '?limit=100';

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
          let response = resp.data as Array<Api.ErrorLogClientResponseModel>;
          let viewModels: Array<ErrorLogViewModel> = [];
          let mapper = new ErrorLogMapper();

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
            records: new Array<ErrorLogViewModel>(),
            filteredRecords: new Array<ErrorLogViewModel>(),
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
                        &nbsp;
                        <Button
                          type="danger"
                          onClick={(e: any) => {
                            this.handleDeleteClick(
                              e,
                              row.original as ErrorLogViewModel
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

export const WrappedErrorLogSearchComponent = Form.create({
  name: 'ErrorLog Search',
})(ErrorLogSearchComponent);


/*<Codenesium>
    <Hash>68e99c8b72bc367c35b633fed40c6c45</Hash>
</Codenesium>*/