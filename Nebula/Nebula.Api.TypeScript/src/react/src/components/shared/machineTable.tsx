import React, { Component, FormEvent } from 'react';
import axios from 'axios';
import { Constants, ApiRoutes, ClientRoutes } from '../../constants';
import * as Api from '../../api/models';
import MachineMapper from '../machine/machineMapper';
import MachineViewModel from '../machine/machineViewModel';
import { Form, Input, Button, Spin, Alert } from 'antd';
import { WrappedFormUtils } from 'antd/es/form/Form';
import ReactTable from 'react-table';

interface MachineTableComponentProps {
  id: number;
  apiRoute: string;
  history: any;
  match: any;
}

interface MachineTableComponentState {
  loading: boolean;
  loaded: boolean;
  errorOccurred: boolean;
  errorMessage: string;
  filteredRecords: Array<MachineViewModel>;
}

export class MachineTableComponent extends React.Component<
  MachineTableComponentProps,
  MachineTableComponentState
> {
  state = {
    loading: false,
    loaded: true,
    errorOccurred: false,
    errorMessage: '',
    filteredRecords: [],
  };

  handleEditClick(e: any, row: MachineViewModel) {
    this.props.history.push(ClientRoutes.Machines + '/edit/' + row.id);
  }

  handleDetailClick(e: any, row: MachineViewModel) {
    this.props.history.push(ClientRoutes.Machines + '/' + row.id);
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
          let response = resp.data as Array<Api.MachineClientResponseModel>;

          console.log(response);

          let mapper = new MachineMapper();

          let machines: Array<MachineViewModel> = [];

          response.forEach(x => {
            machines.push(mapper.mapApiResponseToViewModel(x));
          });
          this.setState({
            ...this.state,
            filteredRecords: machines,
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
                Header: 'Machines',
                columns: [
                  {
                    Header: 'Description',
                    accessor: 'description',
                    Cell: props => {
                      return <span>{String(props.original.description)}</span>;
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
                    Header: 'JwtKey',
                    accessor: 'jwtKey',
                    Cell: props => {
                      return <span>{String(props.original.jwtKey)}</span>;
                    },
                  },
                  {
                    Header: 'LastIpAddress',
                    accessor: 'lastIpAddress',
                    Cell: props => {
                      return (
                        <span>{String(props.original.lastIpAddress)}</span>
                      );
                    },
                  },
                  {
                    Header: 'MachineGuid',
                    accessor: 'machineGuid',
                    Cell: props => {
                      return <span>{String(props.original.machineGuid)}</span>;
                    },
                  },
                  {
                    Header: 'Name',
                    accessor: 'name',
                    Cell: props => {
                      return <span>{String(props.original.name)}</span>;
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
                              row.original as MachineViewModel
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
                              row.original as MachineViewModel
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
    <Hash>7eaf9da2af785568baf9212f21d23a90</Hash>
</Codenesium>*/