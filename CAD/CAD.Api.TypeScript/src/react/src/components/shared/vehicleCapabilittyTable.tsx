import React, { Component, FormEvent } from 'react';
import axios, { AxiosError, AxiosResponse } from 'axios';
import { Constants, ApiRoutes, ClientRoutes } from '../../constants';
import * as Api from '../../api/models';
import VehicleCapabilittyMapper from '../vehicleCapabilitty/vehicleCapabilittyMapper';
import VehicleCapabilittyViewModel from '../vehicleCapabilitty/vehicleCapabilittyViewModel';
import { Form, Input, Button, Spin, Alert } from 'antd';
import { WrappedFormUtils } from 'antd/es/form/Form';
import ReactTable from 'react-table';
import * as GlobalUtilities from '../../lib/globalUtilities';

interface VehicleCapabilittyTableComponentProps {
  apiRoute: string;
  history: any;
  match: any;
}

interface VehicleCapabilittyTableComponentState {
  loading: boolean;
  loaded: boolean;
  errorOccurred: boolean;
  errorMessage: string;
  filteredRecords: Array<VehicleCapabilittyViewModel>;
}

export class VehicleCapabilittyTableComponent extends React.Component<
  VehicleCapabilittyTableComponentProps,
  VehicleCapabilittyTableComponentState
> {
  state = {
    loading: false,
    loaded: true,
    errorOccurred: false,
    errorMessage: '',
    filteredRecords: [],
  };

  handleEditClick(e: any, row: VehicleCapabilittyViewModel) {
    this.props.history.push(
      ClientRoutes.VehicleCapabilities + '/edit/' + row.vehicleId
    );
  }

  handleDetailClick(e: any, row: VehicleCapabilittyViewModel) {
    this.props.history.push(
      ClientRoutes.VehicleCapabilities + '/' + row.vehicleId
    );
  }

  componentDidMount() {
    this.loadRecords();
  }

  loadRecords() {
    this.setState({ ...this.state, loading: true });

    axios
      .get<Array<Api.VehicleCapabilittyClientResponseModel>>(
        this.props.apiRoute,
        {
          headers: GlobalUtilities.defaultHeaders(),
        }
      )
      .then(response => {
        GlobalUtilities.logInfo(response);

        let mapper = new VehicleCapabilittyMapper();

        let vehicleCapabilities: Array<VehicleCapabilittyViewModel> = [];

        response.data.forEach(x => {
          vehicleCapabilities.push(mapper.mapApiResponseToViewModel(x));
        });

        this.setState({
          ...this.state,
          filteredRecords: vehicleCapabilities,
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
                Header: 'VehicleCapabilities',
                columns: [
                  {
                    Header: 'VehicleCapabilityId',
                    accessor: 'vehicleCapabilityId',
                    Cell: props => {
                      return (
                        <a
                          href=""
                          onClick={e => {
                            e.preventDefault();
                            this.props.history.push(
                              ClientRoutes.VehicleCapabilities +
                                '/' +
                                props.original.vehicleCapabilityId
                            );
                          }}
                        >
                          {String(
                            props.original.vehicleCapabilityIdNavigation &&
                              props.original.vehicleCapabilityIdNavigation.toDisplay()
                          )}
                        </a>
                      );
                    },
                  },
                  {
                    Header: 'VehicleId',
                    accessor: 'vehicleId',
                    Cell: props => {
                      return (
                        <a
                          href=""
                          onClick={e => {
                            e.preventDefault();
                            this.props.history.push(
                              ClientRoutes.Vehicles +
                                '/' +
                                props.original.vehicleId
                            );
                          }}
                        >
                          {String(
                            props.original.vehicleIdNavigation &&
                              props.original.vehicleIdNavigation.toDisplay()
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
                          type="primary"
                          onClick={(e: any) => {
                            this.handleDetailClick(
                              e,
                              row.original as VehicleCapabilittyViewModel
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
                              row.original as VehicleCapabilittyViewModel
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
    <Hash>882573edca41b6372f8ec1bda94b427c</Hash>
</Codenesium>*/