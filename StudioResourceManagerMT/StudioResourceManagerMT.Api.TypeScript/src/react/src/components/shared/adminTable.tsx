import React, { Component, FormEvent } from 'react';
import axios from 'axios';
import { Constants, ApiRoutes, ClientRoutes } from '../../constants';
import * as Api from '../../api/models';
import AdminMapper from '../admin/adminMapper';
import AdminViewModel from '../admin/adminViewModel';
import { Form, Input, Button, Spin, Alert } from 'antd';
import { WrappedFormUtils } from 'antd/es/form/Form';
import ReactTable from 'react-table';

interface AdminTableComponentProps {
  id: number;
  apiRoute: string;
  history: any;
  match: any;
}

interface AdminTableComponentState {
  loading: boolean;
  loaded: boolean;
  errorOccurred: boolean;
  errorMessage: string;
  filteredRecords: Array<AdminViewModel>;
}

export class AdminTableComponent extends React.Component<
  AdminTableComponentProps,
  AdminTableComponentState
> {
  state = {
    loading: false,
    loaded: true,
    errorOccurred: false,
    errorMessage: '',
    filteredRecords: [],
  };

  handleEditClick(e: any, row: AdminViewModel) {
    this.props.history.push(ClientRoutes.Admins + '/edit/' + row.id);
  }

  handleDetailClick(e: any, row: AdminViewModel) {
    this.props.history.push(ClientRoutes.Admins + '/' + row.id);
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
          let response = resp.data as Array<Api.AdminClientResponseModel>;

          console.log(response);

          let mapper = new AdminMapper();

          let admins: Array<AdminViewModel> = [];

          response.forEach(x => {
            admins.push(mapper.mapApiResponseToViewModel(x));
          });
          this.setState({
            ...this.state,
            filteredRecords: admins,
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
                Header: 'Admins',
                columns: [
                  {
                    Header: 'Birthday',
                    accessor: 'birthday',
                    Cell: props => {
                      return <span>{String(props.original.birthday)}</span>;
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
                    Header: 'FirstName',
                    accessor: 'firstName',
                    Cell: props => {
                      return <span>{String(props.original.firstName)}</span>;
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
                    Header: 'LastName',
                    accessor: 'lastName',
                    Cell: props => {
                      return <span>{String(props.original.lastName)}</span>;
                    },
                  },
                  {
                    Header: 'Phone',
                    accessor: 'phone',
                    Cell: props => {
                      return <span>{String(props.original.phone)}</span>;
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
                              row.original as AdminViewModel
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
                              row.original as AdminViewModel
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
    <Hash>d58d20c480a8dc21b18906b6c80d1ec2</Hash>
</Codenesium>*/