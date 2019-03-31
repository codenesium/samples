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
    this.props.history.push(ClientRoutes.Users + '/edit/' + row.userId);
  }

  handleDetailClick(e: any, row: UserViewModel) {
    this.props.history.push(ClientRoutes.Users + '/' + row.userId);
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
                    Header: 'Bio_img_url',
                    accessor: 'bioImgUrl',
                    Cell: props => {
                      return <span>{String(props.original.bioImgUrl)}</span>;
                    },
                  },
                  {
                    Header: 'Birthday',
                    accessor: 'birthday',
                    Cell: props => {
                      return <span>{String(props.original.birthday)}</span>;
                    },
                  },
                  {
                    Header: 'Content_description',
                    accessor: 'contentDescription',
                    Cell: props => {
                      return (
                        <span>{String(props.original.contentDescription)}</span>
                      );
                    },
                  },
                  {
                    Header: 'Email',
                    accessor: 'email',
                    Cell: props => {
                      return <span>{String(props.original.email)}</span>;
                    },
                  },
                  {
                    Header: 'Full_name',
                    accessor: 'fullName',
                    Cell: props => {
                      return <span>{String(props.original.fullName)}</span>;
                    },
                  },
                  {
                    Header: 'Header_img_url',
                    accessor: 'headerImgUrl',
                    Cell: props => {
                      return <span>{String(props.original.headerImgUrl)}</span>;
                    },
                  },
                  {
                    Header: 'Interest',
                    accessor: 'interest',
                    Cell: props => {
                      return <span>{String(props.original.interest)}</span>;
                    },
                  },
                  {
                    Header: 'Location_location_id',
                    accessor: 'locationLocationId',
                    Cell: props => {
                      return (
                        <a
                          href=""
                          onClick={e => {
                            e.preventDefault();
                            this.props.history.push(
                              ClientRoutes.Locations +
                                '/' +
                                props.original.locationLocationId
                            );
                          }}
                        >
                          {String(
                            props.original.locationLocationIdNavigation &&
                              props.original.locationLocationIdNavigation.toDisplay()
                          )}
                        </a>
                      );
                    },
                  },
                  {
                    Header: 'Password',
                    accessor: 'password',
                    Cell: props => {
                      return <span>{String(props.original.password)}</span>;
                    },
                  },
                  {
                    Header: 'Phone_number',
                    accessor: 'phoneNumber',
                    Cell: props => {
                      return <span>{String(props.original.phoneNumber)}</span>;
                    },
                  },
                  {
                    Header: 'Privacy',
                    accessor: 'privacy',
                    Cell: props => {
                      return <span>{String(props.original.privacy)}</span>;
                    },
                  },
                  {
                    Header: 'Username',
                    accessor: 'username',
                    Cell: props => {
                      return <span>{String(props.original.username)}</span>;
                    },
                  },
                  {
                    Header: 'Website',
                    accessor: 'website',
                    Cell: props => {
                      return <span>{String(props.original.website)}</span>;
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
    <Hash>67b9842b30a09b62bee115745b6a1d33</Hash>
</Codenesium>*/