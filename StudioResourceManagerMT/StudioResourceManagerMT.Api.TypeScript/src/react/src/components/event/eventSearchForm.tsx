import React, { Component, ReactElement, ReactHTMLElement } from 'react';
import axios from 'axios';
import { Redirect } from 'react-router-dom';
import * as Api from '../../api/models';
import EventMapper from './eventMapper';
import { Constants, ApiRoutes, ClientRoutes } from '../../constants';
import { LoadingForm } from '../../lib/components/loadingForm';
import { ErrorForm } from '../../lib/components/errorForm';
import ReactTable from 'react-table';
import EventViewModel from './eventViewModel';
import 'react-table/react-table.css';

interface EventSearchComponentProps {
  history: any;
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

  handleEditClick(e: any, row: Api.EventClientResponseModel) {
    this.props.history.push(ClientRoutes.Events + '/edit/' + row.id);
  }

  handleDetailClick(e: any, row: Api.EventClientResponseModel) {
    this.props.history.push(ClientRoutes.Events + '/' + row.id);
  }

  handleCreateClick(e: any) {
    this.props.history.push(ClientRoutes.Events + '/create');
  }

  handleDeleteClick(e: any, row: Api.EventClientResponseModel) {
    axios
      .delete(Constants.ApiEndpoint + ApiRoutes.Events + '/' + row.id, {
        headers: {
          'Content-Type': 'application/json',
        },
      })
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
      Constants.ApiEndpoint + ApiRoutes.Events + '?limit=100';

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
          let response = resp.data as Array<Api.EventClientResponseModel>;
          let viewModels: Array<EventViewModel> = [];
          let mapper = new EventMapper();

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
            records: new Array<EventViewModel>(),
            filteredRecords: new Array<EventViewModel>(),
            loading: false,
            loaded: false,
            errorOccurred: true,
            errorMessage: 'Error from API',
          });
        }
      );
  }

  filterGrid() {}

  render() {
    if (this.state.loading) {
      return <LoadingForm />;
    } else if (this.state.errorOccurred) {
      return <ErrorForm message={this.state.errorMessage} />;
    } else if (this.state.loaded) {
      let errorResponse: JSX.Element = <span />;

      if (this.state.deleteSubmitted) {
        if (this.state.deleteSuccess) {
          errorResponse = (
            <div className="alert alert-success">
              {this.state.deleteResponse}
            </div>
          );
        } else {
          errorResponse = (
            <div className="alert alert-danger">
              {this.state.deleteResponse}
            </div>
          );
        }
      }
      return (
        <div>
          {errorResponse}
          <form>
            <div className="form-group row">
              <div className="col-sm-4" />
              <div className="col-sm-4">
                <input
                  name="search"
                  className="form-control"
                  placeholder={'Search'}
                  value={this.state.searchValue}
                  onChange={e => this.handleSearchChanged(e)}
                />
              </div>
              <div className="col-sm-4">
                <button
                  className="btn btn-primary btn-sm align-middle float-right vertically-center search-create-button"
                  onClick={e => this.handleCreateClick(e)}
                >
                  <i className="fas fa-plus" />
                </button>
              </div>
            </div>
          </form>
          <ReactTable
            data={this.state.filteredRecords}
            columns={[
              {
                Header: 'Event',
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
                            props.original.eventStatusIdNavigation.toDisplay()
                          )}
                        </a>
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
                        <button
                          className="btn btn-sm"
                          onClick={e => {
                            this.handleDetailClick(
                              e,
                              row.original as Api.EventClientResponseModel
                            );
                          }}
                        >
                          <i className="fas fa-search" />
                        </button>
                        &nbsp;
                        <button
                          className="btn btn-primary btn-sm"
                          onClick={e => {
                            this.handleEditClick(
                              e,
                              row.original as Api.EventClientResponseModel
                            );
                          }}
                        >
                          <i className="fas fa-edit" />
                        </button>
                        &nbsp;
                        <button
                          className="btn btn-danger btn-sm"
                          onClick={e => {
                            this.handleDeleteClick(
                              e,
                              row.original as Api.EventClientResponseModel
                            );
                          }}
                        >
                          <i className="far fa-trash-alt" />
                        </button>
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
    <Hash>a6d74a14af96ba7fcd20f934fa4cc42f</Hash>
</Codenesium>*/