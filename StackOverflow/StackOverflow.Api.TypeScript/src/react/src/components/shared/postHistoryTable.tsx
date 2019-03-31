import React, { Component, FormEvent } from 'react';
import axios, { AxiosError, AxiosResponse } from 'axios';
import { Constants, ApiRoutes, ClientRoutes } from '../../constants';
import * as Api from '../../api/models';
import PostHistoryMapper from '../postHistory/postHistoryMapper';
import PostHistoryViewModel from '../postHistory/postHistoryViewModel';
import { Form, Input, Button, Spin, Alert } from 'antd';
import { WrappedFormUtils } from 'antd/es/form/Form';
import ReactTable from 'react-table';
import * as GlobalUtilities from '../../lib/globalUtilities';

interface PostHistoryTableComponentProps {
  apiRoute: string;
  history: any;
  match: any;
}

interface PostHistoryTableComponentState {
  loading: boolean;
  loaded: boolean;
  errorOccurred: boolean;
  errorMessage: string;
  filteredRecords: Array<PostHistoryViewModel>;
}

export class PostHistoryTableComponent extends React.Component<
  PostHistoryTableComponentProps,
  PostHistoryTableComponentState
> {
  state = {
    loading: false,
    loaded: true,
    errorOccurred: false,
    errorMessage: '',
    filteredRecords: [],
  };

  handleEditClick(e: any, row: PostHistoryViewModel) {
    this.props.history.push(ClientRoutes.PostHistories + '/edit/' + row.id);
  }

  handleDetailClick(e: any, row: PostHistoryViewModel) {
    this.props.history.push(ClientRoutes.PostHistories + '/' + row.id);
  }

  componentDidMount() {
    this.loadRecords();
  }

  loadRecords() {
    this.setState({ ...this.state, loading: true });

    axios
      .get<Array<Api.PostHistoryClientResponseModel>>(this.props.apiRoute, {
        headers: GlobalUtilities.defaultHeaders(),
      })
      .then(response => {
        GlobalUtilities.logInfo(response);

        let mapper = new PostHistoryMapper();

        let postHistories: Array<PostHistoryViewModel> = [];

        response.data.forEach(x => {
          postHistories.push(mapper.mapApiResponseToViewModel(x));
        });

        this.setState({
          ...this.state,
          filteredRecords: postHistories,
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
                Header: 'PostHistories',
                columns: [
                  {
                    Header: 'Comment',
                    accessor: 'comment',
                    Cell: props => {
                      return <span>{String(props.original.comment)}</span>;
                    },
                  },
                  {
                    Header: 'Creation Date',
                    accessor: 'creationDate',
                    Cell: props => {
                      return <span>{String(props.original.creationDate)}</span>;
                    },
                  },
                  {
                    Header: 'Post History Type',
                    accessor: 'postHistoryTypeId',
                    Cell: props => {
                      return (
                        <a
                          href=""
                          onClick={e => {
                            e.preventDefault();
                            this.props.history.push(
                              ClientRoutes.PostHistoryTypes +
                                '/' +
                                props.original.postHistoryTypeId
                            );
                          }}
                        >
                          {String(
                            props.original.postHistoryTypeIdNavigation &&
                              props.original.postHistoryTypeIdNavigation.toDisplay()
                          )}
                        </a>
                      );
                    },
                  },
                  {
                    Header: 'Post',
                    accessor: 'postId',
                    Cell: props => {
                      return (
                        <a
                          href=""
                          onClick={e => {
                            e.preventDefault();
                            this.props.history.push(
                              ClientRoutes.Posts + '/' + props.original.postId
                            );
                          }}
                        >
                          {String(
                            props.original.postIdNavigation &&
                              props.original.postIdNavigation.toDisplay()
                          )}
                        </a>
                      );
                    },
                  },
                  {
                    Header: 'Revision GUID',
                    accessor: 'revisionGUID',
                    Cell: props => {
                      return <span>{String(props.original.revisionGUID)}</span>;
                    },
                  },
                  {
                    Header: 'Text',
                    accessor: 'text',
                    Cell: props => {
                      return <span>{String(props.original.text)}</span>;
                    },
                  },
                  {
                    Header: 'User Display Name',
                    accessor: 'userDisplayName',
                    Cell: props => {
                      return (
                        <span>{String(props.original.userDisplayName)}</span>
                      );
                    },
                  },
                  {
                    Header: 'User',
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
                          {String(
                            props.original.userIdNavigation &&
                              props.original.userIdNavigation.toDisplay()
                          )}
                        </a>
                      );
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
                              row.original as PostHistoryViewModel
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
                              row.original as PostHistoryViewModel
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
    <Hash>3304ea97cbe76a16a06079a4f3914cc2</Hash>
</Codenesium>*/