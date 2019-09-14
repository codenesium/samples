import React, { Component, ReactElement, ReactHTMLElement } from 'react';
import axios, { AxiosError, AxiosResponse } from 'axios';
import { Redirect } from 'react-router-dom';
import * as Api from '../../api/models';
import UserMapper from './userMapper';
import { Constants, ApiRoutes, ClientRoutes } from '../../constants';
import ReactTable from 'react-table';
import UserViewModel from './userViewModel';
import 'react-table/react-table.css';
import { Form, Button, Input, Row, Col, Alert, Spin } from 'antd';
import { WrappedFormUtils } from 'antd/es/form/Form';
import * as GlobalUtilities from '../../lib/globalUtilities';

interface UserSearchComponentProps {
  form: WrappedFormUtils;
  history: any;
  match: any;
}

interface UserSearchComponentState {
  records: Array<UserViewModel>;
  filteredRecords: Array<UserViewModel>;
  loading: boolean;
  loaded: boolean;
  errorOccurred: boolean;
  errorMessage: string;
  searchValue: string;
  deleteSubmitted: boolean;
  deleteSuccess: boolean;
  deleteResponse: string;
}

export default class UserSearchComponent extends React.Component<
  UserSearchComponentProps,
  UserSearchComponentState
> {
  state = {
    deleteSubmitted: false,
    deleteSuccess: false,
    deleteResponse: '',
    records: new Array<UserViewModel>(),
    filteredRecords: new Array<UserViewModel>(),
    searchValue: '',
    loading: false,
    loaded: true,
    errorOccurred: false,
    errorMessage: '',
  };

  componentDidMount() {
    this.loadRecords();
  }

  handleEditClick(e: any, row: UserViewModel) {
    this.props.history.push(ClientRoutes.Users + '/edit/' + row.userId);
  }

  handleDetailClick(e: any, row: UserViewModel) {
    this.props.history.push(ClientRoutes.Users + '/' + row.userId);
  }

  handleCreateClick(e: any) {
    this.props.history.push(ClientRoutes.Users + '/create');
  }

  handleDeleteClick(e: any, row: Api.UserClientResponseModel) {
    axios
      .delete(Constants.ApiEndpoint + ApiRoutes.Users + '/' + row.userId, {
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
    let searchEndpoint = Constants.ApiEndpoint + ApiRoutes.Users + '?limit=100';

    if (query) {
      searchEndpoint += '&query=' + query;
    }

    axios
      .get<Array<Api.UserClientResponseModel>>(searchEndpoint, {
        headers: GlobalUtilities.defaultHeaders(),
      })
      .then(response => {
        let viewModels: Array<UserViewModel> = [];
        let mapper = new UserMapper();

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
          records: new Array<UserViewModel>(),
          filteredRecords: new Array<UserViewModel>(),
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
                          type="primary"
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
                          type="primary"
                          onClick={(e: any) => {
                            this.handleEditClick(
                              e,
                              row.original as UserViewModel
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
                              row.original as UserViewModel
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

export const WrappedUserSearchComponent = Form.create({ name: 'User Search' })(
  UserSearchComponent
);


/*<Codenesium>
    <Hash>7d648dd34de22620de67e33b930f679b</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/