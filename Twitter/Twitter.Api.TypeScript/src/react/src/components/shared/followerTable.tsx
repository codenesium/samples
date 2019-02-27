import React, { Component, FormEvent } from 'react';
import axios from 'axios';
import { Constants, ApiRoutes, ClientRoutes } from '../../constants';
import * as Api from '../../api/models';
import FollowerMapper from '../follower/followerMapper';
import FollowerViewModel from '../follower/followerViewModel';
import { Form, Input, Button, Spin, Alert } from 'antd';
import { WrappedFormUtils } from 'antd/es/form/Form';
import ReactTable from 'react-table';

interface FollowerTableComponentProps {
  id: number;
  apiRoute: string;
  history: any;
  match: any;
}

interface FollowerTableComponentState {
  loading: boolean;
  loaded: boolean;
  errorOccurred: boolean;
  errorMessage: string;
  filteredRecords: Array<FollowerViewModel>;
}

export class FollowerTableComponent extends React.Component<
  FollowerTableComponentProps,
  FollowerTableComponentState
> {
  state = {
    loading: false,
    loaded: true,
    errorOccurred: false,
    errorMessage: '',
    filteredRecords: [],
  };

  handleEditClick(e: any, row: FollowerViewModel) {
    this.props.history.push(ClientRoutes.Followers + '/edit/' + row.id);
  }

  handleDetailClick(e: any, row: FollowerViewModel) {
    this.props.history.push(ClientRoutes.Followers + '/' + row.id);
  }

  componentDidMount() {
    this.loadRecords();
  }

  loadRecords() {
    this.setState({ ...this.state, loading: true });

    axios
      .get(this.props.apiRoute, {
        headers: {
          'Content-Type': 'application/json',
        },
      })
      .then(
        resp => {
          let response = resp.data as Array<Api.FollowerClientResponseModel>;

          console.log(response);

          let mapper = new FollowerMapper();

          let followers: Array<FollowerViewModel> = [];

          response.forEach(x => {
            followers.push(mapper.mapApiResponseToViewModel(x));
          });
          this.setState({
            ...this.state,
            filteredRecords: followers,
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
                Header: 'Followers',
                columns: [
                  {
                    Header: 'Blocked',
                    accessor: 'blocked',
                    Cell: props => {
                      return <span>{String(props.original.blocked)}</span>;
                    },
                  },
                  {
                    Header: 'Date_followed',
                    accessor: 'dateFollowed',
                    Cell: props => {
                      return <span>{String(props.original.dateFollowed)}</span>;
                    },
                  },
                  {
                    Header: 'Follow_request_status',
                    accessor: 'followRequestStatu',
                    Cell: props => {
                      return (
                        <span>{String(props.original.followRequestStatu)}</span>
                      );
                    },
                  },
                  {
                    Header: 'Followed_user_id',
                    accessor: 'followedUserId',
                    Cell: props => {
                      return (
                        <a
                          href=""
                          onClick={e => {
                            e.preventDefault();
                            this.props.history.push(
                              ClientRoutes.Users +
                                '/' +
                                props.original.followedUserId
                            );
                          }}
                        >
                          {String(
                            props.original.followedUserIdNavigation.toDisplay()
                          )}
                        </a>
                      );
                    },
                  },
                  {
                    Header: 'Following_user_id',
                    accessor: 'followingUserId',
                    Cell: props => {
                      return (
                        <a
                          href=""
                          onClick={e => {
                            e.preventDefault();
                            this.props.history.push(
                              ClientRoutes.Users +
                                '/' +
                                props.original.followingUserId
                            );
                          }}
                        >
                          {String(
                            props.original.followingUserIdNavigation.toDisplay()
                          )}
                        </a>
                      );
                    },
                  },
                  {
                    Header: 'Muted',
                    accessor: 'muted',
                    Cell: props => {
                      return <span>{String(props.original.muted)}</span>;
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
                              row.original as FollowerViewModel
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
                              row.original as FollowerViewModel
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
    <Hash>f7d478f439f2dbd2c85de6df12d55961</Hash>
</Codenesium>*/