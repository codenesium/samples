import React, { Component, FormEvent } from 'react';
import axios, { AxiosError, AxiosResponse } from 'axios';
import { Constants, ApiRoutes, ClientRoutes } from '../../constants';
import * as Api from '../../api/models';
import VehicleCapabilitiesMapper from '../vehicleCapabilities/vehicleCapabilitiesMapper';
import VehicleCapabilitiesViewModel from '../vehicleCapabilities/vehicleCapabilitiesViewModel';
import { Form, Input, Button, Spin, Alert } from 'antd';
import { WrappedFormUtils } from 'antd/es/form/Form';
import ReactTable from 'react-table';
import * as GlobalUtilities from '../../lib/globalUtilities';

interface VehicleCapabilitiesTableComponentProps {
  apiRoute: string;
  history: any;
  match: any;
}

interface VehicleCapabilitiesTableComponentState {
  loading: boolean;
  loaded: boolean;
  errorOccurred: boolean;
  errorMessage: string;
  filteredRecords: Array<VehicleCapabilitiesViewModel>;
}

export class VehicleCapabilitiesTableComponent extends React.Component<
  VehicleCapabilitiesTableComponentProps,
  VehicleCapabilitiesTableComponentState
> {
  state = {
    loading: false,
    loaded: true,
    errorOccurred: false,
    errorMessage: '',
    filteredRecords: [],
  };

  handleEditClick(e: any, row: VehicleCapabilitiesViewModel) {
    this.props.history.push(
      ClientRoutes.VehicleCapabilities + '/edit/' + row.id
    );
  }

  handleDetailClick(e: any, row: VehicleCapabilitiesViewModel) {
    this.props.history.push(ClientRoutes.VehicleCapabilities + '/' + row.id);
  }

  componentDidMount() {
    this.loadRecords();
  }

  loadRecords() {
    this.setState({ ...this.state, loading: true });

    axios
      .get<Array<Api.VehicleCapabilitiesClientResponseModel>>(
        this.props.apiRoute,
        {
          headers: GlobalUtilities.defaultHeaders(),
        }
      )
      .then(response => {
        GlobalUtilities.logInfo(response);

        let mapper = new VehicleCapabilitiesMapper();

        let vehicleCapabilities: Array<VehicleCapabilitiesViewModel> = [];

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
                    Header: 'Vehicle Capability',
                    accessor: 'vehicleCapabilityId',
                    Cell: props => {
                      return (
                        <a
                          href=""
                          onClick={e => {
                            e.preventDefault();
                            this.props.history.push(
                              ClientRoutes.VehCapabilities +
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
                    Header: 'Vehicle',
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
                          htmlType="button"
                          onClick={(e: any) => {
                            this.handleDetailClick(
                              e,
                              row.original as VehicleCapabilitiesViewModel
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
                              row.original as VehicleCapabilitiesViewModel
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
    <Hash>97bed22f932dcb81933d8010d43c2513</Hash>
</Codenesium>*/