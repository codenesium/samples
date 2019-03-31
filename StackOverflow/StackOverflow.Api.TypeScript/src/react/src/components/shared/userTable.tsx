import React, { Component, FormEvent } from 'react';
import axios, { AxiosError, AxiosResponse } from 'axios';
import { Constants, ApiRoutes, ClientRoutes } from '../../constants';
import * as Api from '../../api/models';
import UserMapper from '../user/userMapper';
import UserViewModel from '../user/userViewModel';
import { Form, Input, Button, Spin, Alert } from 'antd';
import { WrappedFormUtils } from 'antd/es/form/Form';
import ReactTable from 'react-table';
import * as GlobalUtilities from '../../lib/globalUtilities';

interface UserTableComponentProps {
  apiRoute: string;
  history: any;
  match: any;
}

interface UserTableComponentState {
  loading: boolean;
  loaded: boolean;
  errorOccurred: boolean;
  errorMessage: string;
  filteredRecords: Array<UserViewModel>;
}

export class UserTableComponent extends React.Component<
  UserTableComponentProps,
  UserTableComponentState
> {
  state = {
    loading: false,
    loaded: true,
    errorOccurred: false,
    errorMessage: '',
    filteredRecords: [],
  };

  handleEditClick(e: any, row: UserViewModel) {
    this.props.history.push(ClientRoutes.Users + '/edit/' + row.id);
  }

  handleDetailClick(e: any, row: UserViewModel) {
    this.props.history.push(ClientRoutes.Users + '/' + row.id);
  }

  componentDidMount() {
    this.loadRecords();
  }

  loadRecords() {
    this.setState({ ...this.state, loading: true });

    axios
      .get<Array<Api.UserClientResponseModel>>(this.props.apiRoute, {
        headers: GlobalUtilities.defaultHeaders(),
      })
      .then(response => {
        GlobalUtilities.logInfo(response);

        let mapper = new UserMapper();

        let users: Array<UserViewModel> = [];

        response.data.forEach(x => {
          users.push(mapper.mapApiResponseToViewModel(x));
        });

        this.setState({
          ...this.state,
          filteredRecords: users,
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
                Header: 'Users',
                columns: [
                  {
                    Header: 'About Me',
                    accessor: 'aboutMe',
                    Cell: props => {
                      return <span>{String(props.original.aboutMe)}</span>;
                    },
                  },
                  {
                    Header: 'Account',
                    accessor: 'accountId',
                    Cell: props => {
                      return <span>{String(props.original.accountId)}</span>;
                    },
                  },
                  {
                    Header: 'Age',
                    accessor: 'age',
                    Cell: props => {
                      return <span>{String(props.original.age)}</span>;
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
                    Header: 'Display Name',
                    accessor: 'displayName',
                    Cell: props => {
                      return <span>{String(props.original.displayName)}</span>;
                    },
                  },
                  {
                    Header: 'Down Vote',
                    accessor: 'downVote',
                    Cell: props => {
                      return <span>{String(props.original.downVote)}</span>;
                    },
                  },
                  {
                    Header: 'Email Hash',
                    accessor: 'emailHash',
                    Cell: props => {
                      return <span>{String(props.original.emailHash)}</span>;
                    },
                  },
                  {
                    Header: 'Last Access Date',
                    accessor: 'lastAccessDate',
                    Cell: props => {
                      return (
                        <span>{String(props.original.lastAccessDate)}</span>
                      );
                    },
                  },
                  {
                    Header: 'Location',
                    accessor: 'location',
                    Cell: props => {
                      return <span>{String(props.original.location)}</span>;
                    },
                  },
                  {
                    Header: 'Reputation',
                    accessor: 'reputation',
                    Cell: props => {
                      return <span>{String(props.original.reputation)}</span>;
                    },
                  },
                  {
                    Header: 'Up Vote',
                    accessor: 'upVote',
                    Cell: props => {
                      return <span>{String(props.original.upVote)}</span>;
                    },
                  },
                  {
                    Header: 'View',
                    accessor: 'view',
                    Cell: props => {
                      return <span>{String(props.original.view)}</span>;
                    },
                  },
                  {
                    Header: 'Website Url',
                    accessor: 'websiteUrl',
                    Cell: props => {
                      return <span>{String(props.original.websiteUrl)}</span>;
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
                              row.original as UserViewModel
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
                              row.original as UserViewModel
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
    <Hash>f11db49b34ea0cf6c7693e0cd0110820</Hash>
</Codenesium>*/