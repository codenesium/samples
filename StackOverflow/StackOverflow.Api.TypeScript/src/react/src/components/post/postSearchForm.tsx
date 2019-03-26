import React, { Component, ReactElement, ReactHTMLElement } from 'react';
import axios, { AxiosError, AxiosResponse } from 'axios';
import { Redirect } from 'react-router-dom';
import * as Api from '../../api/models';
import PostMapper from './postMapper';
import { Constants, ApiRoutes, ClientRoutes } from '../../constants';
import ReactTable from 'react-table';
import PostViewModel from './postViewModel';
import 'react-table/react-table.css';
import { Form, Button, Input, Row, Col, Alert, Spin } from 'antd';
import { WrappedFormUtils } from 'antd/es/form/Form';
import * as GlobalUtilities from '../../lib/globalUtilities';

interface PostSearchComponentProps {
  form: WrappedFormUtils;
  history: any;
  match: any;
}

interface PostSearchComponentState {
  records: Array<PostViewModel>;
  filteredRecords: Array<PostViewModel>;
  loading: boolean;
  loaded: boolean;
  errorOccurred: boolean;
  errorMessage: string;
  searchValue: string;
  deleteSubmitted: boolean;
  deleteSuccess: boolean;
  deleteResponse: string;
}

export default class PostSearchComponent extends React.Component<
  PostSearchComponentProps,
  PostSearchComponentState
> {
  state = {
    deleteSubmitted: false,
    deleteSuccess: false,
    deleteResponse: '',
    records: new Array<PostViewModel>(),
    filteredRecords: new Array<PostViewModel>(),
    searchValue: '',
    loading: false,
    loaded: true,
    errorOccurred: false,
    errorMessage: '',
  };

  componentDidMount() {
    this.loadRecords();
  }

  handleEditClick(e: any, row: PostViewModel) {
    this.props.history.push(ClientRoutes.Posts + '/edit/' + row.id);
  }

  handleDetailClick(e: any, row: PostViewModel) {
    this.props.history.push(ClientRoutes.Posts + '/' + row.id);
  }

  handleCreateClick(e: any) {
    this.props.history.push(ClientRoutes.Posts + '/create');
  }

  handleDeleteClick(e: any, row: Api.PostClientResponseModel) {
    axios
      .delete(Constants.ApiEndpoint + ApiRoutes.Posts + '/' + row.id, {
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
    let searchEndpoint = Constants.ApiEndpoint + ApiRoutes.Posts + '?limit=100';

    if (query) {
      searchEndpoint += '&query=' + query;
    }

    axios
      .get<Array<Api.PostClientResponseModel>>(searchEndpoint, {
        headers: GlobalUtilities.defaultHeaders(),
      })
      .then(response => {
        let viewModels: Array<PostViewModel> = [];
        let mapper = new PostMapper();

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
          records: new Array<PostViewModel>(),
          filteredRecords: new Array<PostViewModel>(),
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
                Header: 'Posts',
                columns: [
                  {
                    Header: 'Accepted Answer',
                    accessor: 'acceptedAnswerId',
                    Cell: props => {
                      return (
                        <span>{String(props.original.acceptedAnswerId)}</span>
                      );
                    },
                  },
                  {
                    Header: 'Answer Count',
                    accessor: 'answerCount',
                    Cell: props => {
                      return <span>{String(props.original.answerCount)}</span>;
                    },
                  },
                  {
                    Header: 'Body',
                    accessor: 'body',
                    Cell: props => {
                      return <span>{String(props.original.body)}</span>;
                    },
                  },
                  {
                    Header: 'Closed Date',
                    accessor: 'closedDate',
                    Cell: props => {
                      return <span>{String(props.original.closedDate)}</span>;
                    },
                  },
                  {
                    Header: 'Comment Count',
                    accessor: 'commentCount',
                    Cell: props => {
                      return <span>{String(props.original.commentCount)}</span>;
                    },
                  },
                  {
                    Header: 'Community Owned Date',
                    accessor: 'communityOwnedDate',
                    Cell: props => {
                      return (
                        <span>{String(props.original.communityOwnedDate)}</span>
                      );
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
                    Header: 'Favorite Count',
                    accessor: 'favoriteCount',
                    Cell: props => {
                      return (
                        <span>{String(props.original.favoriteCount)}</span>
                      );
                    },
                  },
                  {
                    Header: 'Last Activity Date',
                    accessor: 'lastActivityDate',
                    Cell: props => {
                      return (
                        <span>{String(props.original.lastActivityDate)}</span>
                      );
                    },
                  },
                  {
                    Header: 'Last Edit Date',
                    accessor: 'lastEditDate',
                    Cell: props => {
                      return <span>{String(props.original.lastEditDate)}</span>;
                    },
                  },
                  {
                    Header: 'Last Editor Display Name',
                    accessor: 'lastEditorDisplayName',
                    Cell: props => {
                      return (
                        <span>
                          {String(props.original.lastEditorDisplayName)}
                        </span>
                      );
                    },
                  },
                  {
                    Header: 'Last Editor User',
                    accessor: 'lastEditorUserId',
                    Cell: props => {
                      return (
                        <a
                          href=""
                          onClick={e => {
                            e.preventDefault();
                            this.props.history.push(
                              ClientRoutes.Users +
                                '/' +
                                props.original.lastEditorUserId
                            );
                          }}
                        >
                          {String(
                            props.original.lastEditorUserIdNavigation &&
                              props.original.lastEditorUserIdNavigation.toDisplay()
                          )}
                        </a>
                      );
                    },
                  },
                  {
                    Header: 'Owner User',
                    accessor: 'ownerUserId',
                    Cell: props => {
                      return (
                        <a
                          href=""
                          onClick={e => {
                            e.preventDefault();
                            this.props.history.push(
                              ClientRoutes.Users +
                                '/' +
                                props.original.ownerUserId
                            );
                          }}
                        >
                          {String(
                            props.original.ownerUserIdNavigation &&
                              props.original.ownerUserIdNavigation.toDisplay()
                          )}
                        </a>
                      );
                    },
                  },
                  {
                    Header: 'Parent',
                    accessor: 'parentId',
                    Cell: props => {
                      return (
                        <a
                          href=""
                          onClick={e => {
                            e.preventDefault();
                            this.props.history.push(
                              ClientRoutes.Posts + '/' + props.original.parentId
                            );
                          }}
                        >
                          {String(
                            props.original.parentIdNavigation &&
                              props.original.parentIdNavigation.toDisplay()
                          )}
                        </a>
                      );
                    },
                  },
                  {
                    Header: 'Post Type',
                    accessor: 'postTypeId',
                    Cell: props => {
                      return (
                        <a
                          href=""
                          onClick={e => {
                            e.preventDefault();
                            this.props.history.push(
                              ClientRoutes.PostTypes +
                                '/' +
                                props.original.postTypeId
                            );
                          }}
                        >
                          {String(
                            props.original.postTypeIdNavigation &&
                              props.original.postTypeIdNavigation.toDisplay()
                          )}
                        </a>
                      );
                    },
                  },
                  {
                    Header: 'Score',
                    accessor: 'score',
                    Cell: props => {
                      return <span>{String(props.original.score)}</span>;
                    },
                  },
                  {
                    Header: 'Tag',
                    accessor: 'tag',
                    Cell: props => {
                      return <span>{String(props.original.tag)}</span>;
                    },
                  },
                  {
                    Header: 'Title',
                    accessor: 'title',
                    Cell: props => {
                      return <span>{String(props.original.title)}</span>;
                    },
                  },
                  {
                    Header: 'View Count',
                    accessor: 'viewCount',
                    Cell: props => {
                      return <span>{String(props.original.viewCount)}</span>;
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
                              row.original as PostViewModel
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
                              row.original as PostViewModel
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
                              row.original as PostViewModel
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

export const WrappedPostSearchComponent = Form.create({ name: 'Post Search' })(
  PostSearchComponent
);


/*<Codenesium>
    <Hash>81555dbf3ea74e8d39d28eace287c30a</Hash>
</Codenesium>*/