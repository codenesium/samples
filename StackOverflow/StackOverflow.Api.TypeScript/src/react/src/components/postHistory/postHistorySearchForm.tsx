import React, { Component, ReactElement, ReactHTMLElement } from 'react';
import axios from 'axios';
import { Redirect } from 'react-router-dom';
import * as Api from '../../api/models';
import PostHistoryMapper from './postHistoryMapper';
import { Constants, ApiRoutes, ClientRoutes } from '../../constants';
import ReactTable from 'react-table';
import PostHistoryViewModel from './postHistoryViewModel';
import 'react-table/react-table.css';
import { Form, Button, Input, Row, Col, Alert, Spin } from 'antd';
import { WrappedFormUtils } from 'antd/es/form/Form';

interface PostHistorySearchComponentProps {
  form: WrappedFormUtils;
  history: any;
  match: any;
}

interface PostHistorySearchComponentState {
  records: Array<PostHistoryViewModel>;
  filteredRecords: Array<PostHistoryViewModel>;
  loading: boolean;
  loaded: boolean;
  errorOccurred: boolean;
  errorMessage: string;
  searchValue: string;
  deleteSubmitted: boolean;
  deleteSuccess: boolean;
  deleteResponse: string;
}

export default class PostHistorySearchComponent extends React.Component<
  PostHistorySearchComponentProps,
  PostHistorySearchComponentState
> {
  state = {
    deleteSubmitted: false,
    deleteSuccess: false,
    deleteResponse: '',
    records: new Array<PostHistoryViewModel>(),
    filteredRecords: new Array<PostHistoryViewModel>(),
    searchValue: '',
    loading: false,
    loaded: true,
    errorOccurred: false,
    errorMessage: '',
  };

  componentDidMount() {
    this.loadRecords();
  }

  handleEditClick(e: any, row: Api.PostHistoryClientResponseModel) {
    this.props.history.push(ClientRoutes.PostHistories + '/edit/' + row.id);
  }

  handleDetailClick(e: any, row: Api.PostHistoryClientResponseModel) {
    this.props.history.push(ClientRoutes.PostHistories + '/' + row.id);
  }

  handleCreateClick(e: any) {
    this.props.history.push(ClientRoutes.PostHistories + '/create');
  }

  handleDeleteClick(e: any, row: Api.PostHistoryClientResponseModel) {
    axios
      .delete(Constants.ApiEndpoint + ApiRoutes.PostHistories + '/' + row.id, {
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
      Constants.ApiEndpoint + ApiRoutes.PostHistories + '?limit=100';

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
          let response = resp.data as Array<Api.PostHistoryClientResponseModel>;
          let viewModels: Array<PostHistoryViewModel> = [];
          let mapper = new PostHistoryMapper();

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
            records: new Array<PostHistoryViewModel>(),
            filteredRecords: new Array<PostHistoryViewModel>(),
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
                Header: 'PostHistory',
                columns: [
                  {
                    Header: 'Comment',
                    accessor: 'comment',
                    Cell: props => {
                      return <span>{String(props.original.comment)}</span>;
                    },
                  },
                  {
                    Header: 'CreationDate',
                    accessor: 'creationDate',
                    Cell: props => {
                      return <span>{String(props.original.creationDate)}</span>;
                    },
                  },
                  {
                    Header: 'PostHistoryTypeId',
                    accessor: 'postHistoryTypeId',
                    Cell: props => {
                      return (
                        <span>{String(props.original.postHistoryTypeId)}</span>
                      );
                    },
                  },
                  {
                    Header: 'PostId',
                    accessor: 'postId',
                    Cell: props => {
                      return <span>{String(props.original.postId)}</span>;
                    },
                  },
                  {
                    Header: 'RevisionGUID',
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
                    Header: 'UserDisplayName',
                    accessor: 'userDisplayName',
                    Cell: props => {
                      return (
                        <span>{String(props.original.userDisplayName)}</span>
                      );
                    },
                  },
                  {
                    Header: 'UserId',
                    accessor: 'userId',
                    Cell: props => {
                      return <span>{String(props.original.userId)}</span>;
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
                              row.original as Api.PostHistoryClientResponseModel
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
                              row.original as Api.PostHistoryClientResponseModel
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
                              row.original as Api.PostHistoryClientResponseModel
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

export const WrappedPostHistorySearchComponent = Form.create({
  name: 'PostHistory Search',
})(PostHistorySearchComponent);


/*<Codenesium>
    <Hash>c9f6fc0abaf9e0ac0844de05dd8b3bdf</Hash>
</Codenesium>*/