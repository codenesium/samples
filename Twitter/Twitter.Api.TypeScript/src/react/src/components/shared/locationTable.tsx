import React, { Component, FormEvent } from 'react';
import axios, { AxiosError, AxiosResponse } from 'axios';
import { Constants, ApiRoutes, ClientRoutes } from '../../constants';
import * as Api from '../../api/models';
import LocationMapper from '../location/locationMapper';
import LocationViewModel from '../location/locationViewModel';
import { Form, Input, Button, Spin, Alert } from 'antd';
import { WrappedFormUtils } from 'antd/es/form/Form';
import ReactTable from 'react-table';
import * as GlobalUtilities from '../../lib/globalUtilities';

interface LocationTableComponentProps {
  apiRoute: string;
  history: any;
  match: any;
}

interface LocationTableComponentState {
  loading: boolean;
  loaded: boolean;
  errorOccurred: boolean;
  errorMessage: string;
  filteredRecords: Array<LocationViewModel>;
}

export class LocationTableComponent extends React.Component<
  LocationTableComponentProps,
  LocationTableComponentState
> {
  state = {
    loading: false,
    loaded: true,
    errorOccurred: false,
    errorMessage: '',
    filteredRecords: [],
  };

  handleEditClick(e: any, row: LocationViewModel) {
    this.props.history.push(ClientRoutes.Locations + '/edit/' + row.locationId);
  }

  handleDetailClick(e: any, row: LocationViewModel) {
    this.props.history.push(ClientRoutes.Locations + '/' + row.locationId);
  }

  componentDidMount() {
    this.loadRecords();
  }

  loadRecords() {
    this.setState({ ...this.state, loading: true });

    axios
      .get<Array<Api.LocationClientResponseModel>>(this.props.apiRoute, {
        headers: GlobalUtilities.defaultHeaders(),
      })
      .then(response => {
        GlobalUtilities.logInfo(response);

        let mapper = new LocationMapper();

        let locations: Array<LocationViewModel> = [];

        response.data.forEach(x => {
          locations.push(mapper.mapApiResponseToViewModel(x));
        });

        this.setState({
          ...this.state,
          filteredRecords: locations,
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
                Header: 'Locations',
                columns: [
                  {
                    Header: 'Gps_lat',
                    accessor: 'gpsLat',
                    Cell: props => {
                      return <span>{String(props.original.gpsLat)}</span>;
                    },
                  },
                  {
                    Header: 'Gps_long',
                    accessor: 'gpsLong',
                    Cell: props => {
                      return <span>{String(props.original.gpsLong)}</span>;
                    },
                  },
                  {
                    Header: 'Location_name',
                    accessor: 'locationName',
                    Cell: props => {
                      return <span>{String(props.original.locationName)}</span>;
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
                              row.original as LocationViewModel
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
                              row.original as LocationViewModel
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
    <Hash>c2359f44fb25d73ed2f9d94787708960</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/