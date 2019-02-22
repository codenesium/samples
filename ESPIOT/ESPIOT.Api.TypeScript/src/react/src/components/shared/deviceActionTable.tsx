import React, { Component, FormEvent } from 'react';
import axios from 'axios';
import { Constants, ApiRoutes, ClientRoutes } from '../../constants';
import * as Api from '../../api/models';
import DeviceActionMapper from '../deviceAction/deviceActionMapper';
import DeviceActionViewModel from '../deviceAction/deviceActionViewModel';
import { Form, Input, Button, Spin, Alert } from 'antd';
import { WrappedFormUtils } from 'antd/es/form/Form';
import ReactTable from 'react-table';

interface DeviceActionTableComponentProps {
  id: number;
  apiRoute: string;
  history: any;
  match: any;
}

interface DeviceActionTableComponentState {
  loading: boolean;
  loaded: boolean;
  errorOccurred: boolean;
  errorMessage: string;
  filteredRecords: Array<DeviceActionViewModel>;
}

export class DeviceActionTableComponent extends React.Component<
  DeviceActionTableComponentProps,
  DeviceActionTableComponentState
> {
  state = {
    loading: false,
    loaded: true,
    errorOccurred: false,
    errorMessage: '',
    filteredRecords: [],
  };

  handleEditClick(e: any, row: DeviceActionViewModel) {
    this.props.history.push(ClientRoutes.DeviceActions + '/edit/' + row.id);
  }

  handleDetailClick(e: any, row: DeviceActionViewModel) {
    this.props.history.push(ClientRoutes.DeviceActions + '/' + row.id);
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
          let response = resp.data as Array<
            Api.DeviceActionClientResponseModel
          >;

          console.log(response);

          let mapper = new DeviceActionMapper();

          let deviceActions: Array<DeviceActionViewModel> = [];

          response.forEach(x => {
            deviceActions.push(mapper.mapApiResponseToViewModel(x));
          });
          this.setState({
            ...this.state,
            filteredRecords: deviceActions,
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
                Header: 'DeviceActions',
                columns: [
                  {
                    Header: 'Action',
                    accessor: 'action',
                    Cell: props => {
                      return <span>{String(props.original.action)}</span>;
                    },
                  },
                  {
                    Header: 'Device',
                    accessor: 'deviceId',
                    Cell: props => {
                      return (
                        <a
                          href=""
                          onClick={e => {
                            e.preventDefault();
                            this.props.history.push(
                              ClientRoutes.Devices +
                                '/' +
                                props.original.deviceId
                            );
                          }}
                        >
                          {String(
                            props.original.deviceIdNavigation.toDisplay()
                          )}
                        </a>
                      );
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
                              row.original as DeviceActionViewModel
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
                              row.original as DeviceActionViewModel
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
    <Hash>fe6f2eb6e1e32da73529a8a9959ea5c0</Hash>
</Codenesium>*/