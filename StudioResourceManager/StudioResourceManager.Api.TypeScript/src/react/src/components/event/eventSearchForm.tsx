import React, { Component, ReactElement, ReactHTMLElement } from 'react';
import axios, { AxiosError, AxiosResponse } from 'axios';
import { Redirect } from 'react-router-dom';
import * as Api from '../../api/models';
import EventMapper from './eventMapper';
import { Constants, ApiRoutes, ClientRoutes } from '../../constants';
import ReactTable from 'react-table';
import EventViewModel from './eventViewModel';
import 'react-table/react-table.css';
import { Form, Button, Input, Row, Col, Alert, Spin } from 'antd';
import { WrappedFormUtils } from 'antd/es/form/Form';
import * as GlobalUtilities from '../../lib/globalUtilities';

interface EventSearchComponentProps {
  form: WrappedFormUtils;
  history: any;
  match: any;
}

interface EventSearchComponentState {
  records: Array<EventViewModel>;
  filteredRecords: Array<EventViewModel>;
  loading: boolean;
  loaded: boolean;
  errorOccurred: boolean;
  errorMessage: string;
  searchValue: string;
  deleteSubmitted: boolean;
  deleteSuccess: boolean;
  deleteResponse: string;
}

export default class EventSearchComponent extends React.Component<
  EventSearchComponentProps,
  EventSearchComponentState
> {
  state = {
    deleteSubmitted: false,
    deleteSuccess: false,
    deleteResponse: '',
    records: new Array<EventViewModel>(),
    filteredRecords: new Array<EventViewModel>(),
    searchValue: '',
    loading: false,
    loaded: true,
    errorOccurred: false,
    errorMessage: '',
  };

  componentDidMount() {
    this.loadRecords();
  }

  handleEditClick(e: any, row: EventViewModel) {
    this.props.history.push(ClientRoutes.Events + '/edit/' + row.id);
  }

  handleDetailClick(e: any, row: EventViewModel) {
    this.props.history.push(ClientRoutes.Events + '/' + row.id);
  }

  handleCreateClick(e: any) {
    this.props.history.push(ClientRoutes.Events + '/create');
  }

  handleDeleteClick(e: any, row: Api.EventClientResponseModel) {
    axios
      .delete(Constants.ApiEndpoint + ApiRoutes.Events + '/' + row.id, {
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
    let searchEndpoint =
      Constants.ApiEndpoint + ApiRoutes.Events + '?limit=100';

    if (query) {
      searchEndpoint += '&query=' + query;
    }

    axios
      .get<Array<Api.EventClientResponseModel>>(searchEndpoint, {
        headers: GlobalUtilities.defaultHeaders(),
      })
      .then(response => {
        let viewModels: Array<EventViewModel> = [];
        let mapper = new EventMapper();

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
          records: new Array<EventViewModel>(),
          filteredRecords: new Array<EventViewModel>(),
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
                Header: 'Events',
                columns: [
                  {
                    Header: 'Actual End Date',
                    accessor: 'actualEndDate',
                    Cell: props => {
                      return (
                        <span>{String(props.original.actualEndDate)}</span>
                      );
                    },
                  },
                  {
                    Header: 'Actual Start Date',
                    accessor: 'actualStartDate',
                    Cell: props => {
                      return (
                        <span>{String(props.original.actualStartDate)}</span>
                      );
                    },
                  },
                  {
                    Header: 'Bill Amount',
                    accessor: 'billAmount',
                    Cell: props => {
                      return <span>{String(props.original.billAmount)}</span>;
                    },
                  },
                  {
                    Header: 'Event Status',
                    accessor: 'eventStatusId',
                    Cell: props => {
                      return (
                        <a
                          href=""
                          onClick={e => {
                            e.preventDefault();
                            this.props.history.push(
                              ClientRoutes.EventStatus +
                                '/' +
                                props.original.eventStatusId
                            );
                          }}
                        >
                          {String(
                            props.original.eventStatusIdNavigation &&
                              props.original.eventStatusIdNavigation.toDisplay()
                          )}
                        </a>
                      );
                    },
                  },
                  {
                    Header: 'Scheduled End Date',
                    accessor: 'scheduledEndDate',
                    Cell: props => {
                      return (
                        <span>{String(props.original.scheduledEndDate)}</span>
                      );
                    },
                  },
                  {
                    Header: 'Scheduled Start Date',
                    accessor: 'scheduledStartDate',
                    Cell: props => {
                      return (
                        <span>{String(props.original.scheduledStartDate)}</span>
                      );
                    },
                  },
                  {
                    Header: 'Student Note',
                    accessor: 'studentNote',
                    Cell: props => {
                      return <span>{String(props.original.studentNote)}</span>;
                    },
                  },
                  {
                    Header: 'Teacher Note',
                    accessor: 'teacherNote',
                    Cell: props => {
                      return <span>{String(props.original.teacherNote)}</span>;
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
                              row.original as EventViewModel
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
                              row.original as EventViewModel
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
                              row.original as EventViewModel
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

export const WrappedEventSearchComponent = Form.create({
  name: 'Event Search',
})(EventSearchComponent);


/*<Codenesium>
    <Hash>49adbe20a23eb36adc242e1ac2f0783e</Hash>
</Codenesium>*/