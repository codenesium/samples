import React, { Component, FormEvent } from 'react';
import axios, { AxiosError, AxiosResponse } from 'axios';
import { Constants, ApiRoutes, ClientRoutes } from '../../constants';
import * as Api from '../../api/models';
import EventMapper from '../event/eventMapper';
import EventViewModel from '../event/eventViewModel';
import { Form, Input, Button, Spin, Alert } from 'antd';
import { WrappedFormUtils } from 'antd/es/form/Form';
import ReactTable from 'react-table';
import * as GlobalUtilities from '../../lib/globalUtilities';

interface EventTableComponentProps {
  apiRoute: string;
  history: any;
  match: any;
}

interface EventTableComponentState {
  loading: boolean;
  loaded: boolean;
  errorOccurred: boolean;
  errorMessage: string;
  filteredRecords: Array<EventViewModel>;
}

export class EventTableComponent extends React.Component<
  EventTableComponentProps,
  EventTableComponentState
> {
  state = {
    loading: false,
    loaded: true,
    errorOccurred: false,
    errorMessage: '',
    filteredRecords: [],
  };

  handleEditClick(e: any, row: EventViewModel) {
    this.props.history.push(ClientRoutes.Events + '/edit/' + row.id);
  }

  handleDetailClick(e: any, row: EventViewModel) {
    this.props.history.push(ClientRoutes.Events + '/' + row.id);
  }

  componentDidMount() {
    this.loadRecords();
  }

  loadRecords() {
    this.setState({ ...this.state, loading: true });

    axios
      .get<Array<Api.EventClientResponseModel>>(this.props.apiRoute, {
        headers: GlobalUtilities.defaultHeaders(),
      })
      .then(response => {
        GlobalUtilities.logInfo(response);

        let mapper = new EventMapper();

        let events: Array<EventViewModel> = [];

        response.data.forEach(x => {
          events.push(mapper.mapApiResponseToViewModel(x));
        });

        this.setState({
          ...this.state,
          filteredRecords: events,
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
                    Header: 'Student Notes',
                    accessor: 'studentNotes',
                    Cell: props => {
                      return <span>{String(props.original.studentNotes)}</span>;
                    },
                  },
                  {
                    Header: 'Teacher Notes',
                    accessor: 'teacherNotes',
                    Cell: props => {
                      return <span>{String(props.original.teacherNotes)}</span>;
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
                              row.original as EventViewModel
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
                              row.original as EventViewModel
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
    <Hash>6742407cd5d22f69fbee8b3c59d043f0</Hash>
</Codenesium>*/