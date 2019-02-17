import React, { Component, ReactElement, ReactHTMLElement } from 'react';
import axios from 'axios';
import { Redirect } from 'react-router-dom';
import * as Api from '../../api/models';
import MessengerMapper from './messengerMapper';
import { Constants, ApiRoutes, ClientRoutes } from '../../constants';
import { LoadingForm } from '../../lib/components/loadingForm';
import { ErrorForm } from '../../lib/components/errorForm';
import ReactTable from 'react-table';
import MessengerViewModel from './messengerViewModel';
import 'react-table/react-table.css';

interface MessengerSearchComponentProps {
  history: any;
}

interface MessengerSearchComponentState {
  records: Array<MessengerViewModel>;
  filteredRecords: Array<MessengerViewModel>;
  loading: boolean;
  loaded: boolean;
  errorOccurred: boolean;
  errorMessage: string;
  searchValue: string;
  deleteSubmitted: boolean;
  deleteSuccess: boolean;
  deleteResponse: string;
}

export default class MessengerSearchComponent extends React.Component<
  MessengerSearchComponentProps,
  MessengerSearchComponentState
> {
  state = {
    deleteSubmitted: false,
    deleteSuccess: false,
    deleteResponse: '',
    records: new Array<MessengerViewModel>(),
    filteredRecords: new Array<MessengerViewModel>(),
    searchValue: '',
    loading: false,
    loaded: true,
    errorOccurred: false,
    errorMessage: '',
  };

  componentDidMount() {
    this.loadRecords();
  }

  handleEditClick(e: any, row: Api.MessengerClientResponseModel) {
    this.props.history.push(ClientRoutes.Messengers + '/edit/' + row.id);
  }

  handleDetailClick(e: any, row: Api.MessengerClientResponseModel) {
    this.props.history.push(ClientRoutes.Messengers + '/' + row.id);
  }

  handleCreateClick(e: any) {
    this.props.history.push(ClientRoutes.Messengers + '/create');
  }

  handleDeleteClick(e: any, row: Api.MessengerClientResponseModel) {
    axios
      .delete(Constants.ApiEndpoint + ApiRoutes.Messengers + '/' + row.id, {
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
      Constants.ApiEndpoint + ApiRoutes.Messengers + '?limit=100';

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
          let response = resp.data as Array<Api.MessengerClientResponseModel>;
          let viewModels: Array<MessengerViewModel> = [];
          let mapper = new MessengerMapper();

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
            records: new Array<MessengerViewModel>(),
            filteredRecords: new Array<MessengerViewModel>(),
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
                Header: 'Messenger',
                columns: [
                  {
                    Header: 'Date',
                    accessor: 'date',
                    Cell: props => {
                      return <span>{String(props.original.date)}</span>;
                    },
                  },
                  {
                    Header: 'From_user_id',
                    accessor: 'fromUserId',
                    Cell: props => {
                      return <span>{String(props.original.fromUserId)}</span>;
                    },
                  },
                  {
                    Header: 'Message_id',
                    accessor: 'messageId',
                    Cell: props => {
                      return (
                        <a
                          href=""
                          onClick={e => {
                            e.preventDefault();
                            this.props.history.push(
                              ClientRoutes.Messages +
                                '/' +
                                props.original.messageId
                            );
                          }}
                        >
                          {String(
                            props.original.messageIdNavigation.toDisplay()
                          )}
                        </a>
                      );
                    },
                  },
                  {
                    Header: 'Time',
                    accessor: 'time',
                    Cell: props => {
                      return <span>{String(props.original.time)}</span>;
                    },
                  },
                  {
                    Header: 'To_user_id',
                    accessor: 'toUserId',
                    Cell: props => {
                      return (
                        <a
                          href=""
                          onClick={e => {
                            e.preventDefault();
                            this.props.history.push(
                              ClientRoutes.Users + '/' + props.original.toUserId
                            );
                          }}
                        >
                          {String(
                            props.original.toUserIdNavigation.toDisplay()
                          )}
                        </a>
                      );
                    },
                  },
                  {
                    Header: 'User_id',
                    accessor: 'userId',
                    Cell: props => {
                      return (
                        <a
                          href=""
                          onClick={e => {
                            e.preventDefault();
                            this.props.history.push(
                              ClientRoutes.Users + '/' + props.original.userId
                            );
                          }}
                        >
                          {String(props.original.userIdNavigation.toDisplay())}
                        </a>
                      );
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
                              row.original as Api.MessengerClientResponseModel
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
                              row.original as Api.MessengerClientResponseModel
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
                              row.original as Api.MessengerClientResponseModel
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
    <Hash>b2d83b01afc2d7f4a87b73dcfb9c0c6c</Hash>
</Codenesium>*/