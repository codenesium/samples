import React, { Component, ReactElement, ReactHTMLElement } from 'react';
import axios, { AxiosError, AxiosResponse } from 'axios';
import { Redirect } from 'react-router-dom';
import * as Api from '../../api/models';
import CallMapper from './callMapper';
import { Constants, ApiRoutes, ClientRoutes } from '../../constants';
import ReactTable from 'react-table';
import CallViewModel from './callViewModel';
import 'react-table/react-table.css';
import { Form, Button, Input, Row, Col, Alert, Spin } from 'antd';
import { WrappedFormUtils } from 'antd/es/form/Form';
import * as GlobalUtilities from '../../lib/globalUtilities';

interface CallSearchComponentProps {
  form: WrappedFormUtils;
  history: any;
  match: any;
}

interface CallSearchComponentState {
  records: Array<CallViewModel>;
  filteredRecords: Array<CallViewModel>;
  loading: boolean;
  loaded: boolean;
  errorOccurred: boolean;
  errorMessage: string;
  searchValue: string;
  deleteSubmitted: boolean;
  deleteSuccess: boolean;
  deleteResponse: string;
}

export default class CallSearchComponent extends React.Component<
  CallSearchComponentProps,
  CallSearchComponentState
> {
  state = {
    deleteSubmitted: false,
    deleteSuccess: false,
    deleteResponse: '',
    records: new Array<CallViewModel>(),
    filteredRecords: new Array<CallViewModel>(),
    searchValue: '',
    loading: false,
    loaded: true,
    errorOccurred: false,
    errorMessage: '',
  };

  componentDidMount() {
    this.loadRecords();
  }

  handleEditClick(e: any, row: CallViewModel) {
    this.props.history.push(ClientRoutes.Calls + '/edit/' + row.id);
  }

  handleDetailClick(e: any, row: CallViewModel) {
    this.props.history.push(ClientRoutes.Calls + '/' + row.id);
  }

  handleCreateClick(e: any) {
    this.props.history.push(ClientRoutes.Calls + '/create');
  }

  handleDeleteClick(e: any, row: Api.CallClientResponseModel) {
    axios
      .delete(Constants.ApiEndpoint + ApiRoutes.Calls + '/' + row.id, {
        headers: GlobalUtilities.defaultHeaders(),
      })
      .then(resp => {
        this.setState({
          ...this.state,
          deleteResponse: 'Record deleted',
          deleteSuccess: true,
          deleteSubmitted: true,
        });
        this.loadRecords(this.state.searchValue);
      })
      .catch((error: AxiosError) => {
        GlobalUtilities.logError(error);
        this.setState({
          ...this.state,
          deleteResponse: 'Error deleting record',
          deleteSuccess: false,
          deleteSubmitted: true,
        });
      });
  }

  handleSearchChanged(e: React.FormEvent<HTMLInputElement>) {
    this.loadRecords(e.currentTarget.value);
  }

  loadRecords(query: string = '') {
    this.setState({ ...this.state, searchValue: query });
    let searchEndpoint = Constants.ApiEndpoint + ApiRoutes.Calls + '?limit=100';

    if (query) {
      searchEndpoint += '&query=' + query;
    }

    axios
      .get<Array<Api.CallClientResponseModel>>(searchEndpoint, {
        headers: GlobalUtilities.defaultHeaders(),
      })
      .then(response => {
        let viewModels: Array<CallViewModel> = [];
        let mapper = new CallMapper();

        response.data.forEach(x => {
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
      })
      .catch((error: AxiosError) => {
        GlobalUtilities.logError(error);
        this.setState({
          records: new Array<CallViewModel>(),
          filteredRecords: new Array<CallViewModel>(),
          loading: false,
          loaded: true,
          errorOccurred: true,
          errorMessage: 'Error from API',
        });
      });
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
                Header: 'Call',
                columns: [
                  {
                    Header: 'Address',
                    accessor: 'addressId',
                    Cell: props => {
                      return (
                        <a
                          href=""
                          onClick={e => {
                            e.preventDefault();
                            this.props.history.push(
                              ClientRoutes.Addresses +
                                '/' +
                                props.original.addressId
                            );
                          }}
                        >
                          {String(
                            props.original.addressIdNavigation &&
                              props.original.addressIdNavigation.toDisplay()
                          )}
                        </a>
                      );
                    },
                  },
                  {
                    Header: 'Call Disposition',
                    accessor: 'callDispositionId',
                    Cell: props => {
                      return (
                        <a
                          href=""
                          onClick={e => {
                            e.preventDefault();
                            this.props.history.push(
                              ClientRoutes.CallDispositions +
                                '/' +
                                props.original.callDispositionId
                            );
                          }}
                        >
                          {String(
                            props.original.callDispositionIdNavigation &&
                              props.original.callDispositionIdNavigation.toDisplay()
                          )}
                        </a>
                      );
                    },
                  },
                  {
                    Header: 'Call Status',
                    accessor: 'callStatusId',
                    Cell: props => {
                      return (
                        <a
                          href=""
                          onClick={e => {
                            e.preventDefault();
                            this.props.history.push(
                              ClientRoutes.CallStatus +
                                '/' +
                                props.original.callStatusId
                            );
                          }}
                        >
                          {String(
                            props.original.callStatusIdNavigation &&
                              props.original.callStatusIdNavigation.toDisplay()
                          )}
                        </a>
                      );
                    },
                  },
                  {
                    Header: 'Call String',
                    accessor: 'callString',
                    Cell: props => {
                      return <span>{String(props.original.callString)}</span>;
                    },
                  },
                  {
                    Header: 'Call Type',
                    accessor: 'callTypeId',
                    Cell: props => {
                      return (
                        <a
                          href=""
                          onClick={e => {
                            e.preventDefault();
                            this.props.history.push(
                              ClientRoutes.CallTypes +
                                '/' +
                                props.original.callTypeId
                            );
                          }}
                        >
                          {String(
                            props.original.callTypeIdNavigation &&
                              props.original.callTypeIdNavigation.toDisplay()
                          )}
                        </a>
                      );
                    },
                  },
                  {
                    Header: 'Date Cleared',
                    accessor: 'dateCleared',
                    Cell: props => {
                      return <span>{String(props.original.dateCleared)}</span>;
                    },
                  },
                  {
                    Header: 'Date Created',
                    accessor: 'dateCreated',
                    Cell: props => {
                      return <span>{String(props.original.dateCreated)}</span>;
                    },
                  },
                  {
                    Header: 'Date Dispatched',
                    accessor: 'dateDispatched',
                    Cell: props => {
                      return (
                        <span>{String(props.original.dateDispatched)}</span>
                      );
                    },
                  },
                  {
                    Header: 'Quick Call Number',
                    accessor: 'quickCallNumber',
                    Cell: props => {
                      return (
                        <span>{String(props.original.quickCallNumber)}</span>
                      );
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
                              row.original as CallViewModel
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
                              row.original as CallViewModel
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
                              row.original as CallViewModel
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

export const WrappedCallSearchComponent = Form.create({ name: 'Call Search' })(
  CallSearchComponent
);


/*<Codenesium>
    <Hash>e81cb40b906d471695d2f06a169f18f9</Hash>
</Codenesium>*/