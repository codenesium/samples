import React, { Component, FormEvent } from 'react';
import axios from 'axios';
import { Constants, ApiRoutes, ClientRoutes } from '../../constants';
import * as Api from '../../api/models';
import EventMapper from '../event/eventMapper';
import EventViewModel from '../event/eventViewModel';
import { Form, Input, Button, Spin, Alert } from 'antd';
import { WrappedFormUtils } from 'antd/es/form/Form';
import ReactTable from 'react-table';

interface EventTableComponentProps {
  id: number;
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
    this.setState({ ...this.state, loading: true });

    axios
      .get(this.props.apiRoute, {
        headers: {
          'Content-Type': 'application/json',
        },
      })
      .then(
        resp => {
          let response = resp.data as Array<Api.EventClientResponseModel>;

          console.log(response);

          let mapper = new EventMapper();

          let events: Array<EventViewModel> = [];

          response.forEach(x => {
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
                Header: 'Events',
                columns: [
                  {
                    Header: 'ActualEndDate',
                    accessor: 'actualEndDate',
                    Cell: props => {
                      return (
                        <span>{String(props.original.actualEndDate)}</span>
                      );
                    },
                  },
                  {
                    Header: 'ActualStartDate',
                    accessor: 'actualStartDate',
                    Cell: props => {
                      return (
                        <span>{String(props.original.actualStartDate)}</span>
                      );
                    },
                  },
                  {
                    Header: 'BillAmount',
                    accessor: 'billAmount',
                    Cell: props => {
                      return <span>{String(props.original.billAmount)}</span>;
                    },
                  },
                  {
                    Header: 'EventStatusId',
                    accessor: 'eventStatusId',
                    Cell: props => {
                      return (
                        <span>{String(props.original.eventStatusId)}</span>
                      );
                    },
                  },
                  {
                    Header: 'Id',
                    accessor: 'id',
                    Cell: props => {
                      return <span>{String(props.original.id)}</span>;
                    },
                  },
                  {
                    Header: 'ScheduledEndDate',
                    accessor: 'scheduledEndDate',
                    Cell: props => {
                      return (
                        <span>{String(props.original.scheduledEndDate)}</span>
                      );
                    },
                  },
                  {
                    Header: 'ScheduledStartDate',
                    accessor: 'scheduledStartDate',
                    Cell: props => {
                      return (
                        <span>{String(props.original.scheduledStartDate)}</span>
                      );
                    },
                  },
                  {
                    Header: 'StudentNotes',
                    accessor: 'studentNote',
                    Cell: props => {
                      return <span>{String(props.original.studentNote)}</span>;
                    },
                  },
                  {
                    Header: 'TeacherNotes',
                    accessor: 'teacherNote',
                    Cell: props => {
                      return <span>{String(props.original.teacherNote)}</span>;
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
    <Hash>d93682088172d14f27896e75bfcc900d</Hash>
</Codenesium>*/