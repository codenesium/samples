import React, { Component, FormEvent } from 'react';
import axios from 'axios';
import { Constants, ApiRoutes, ClientRoutes } from '../../constants';
import * as Api from '../../api/models';
import LocationMapper from '../location/locationMapper';
import LocationViewModel from '../location/locationViewModel';
import { Form, Input, Button, Spin, Alert } from 'antd';
import { WrappedFormUtils } from 'antd/es/form/Form';
import ReactTable from 'react-table';

interface LocationTableComponentProps {
  location_id: number;
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
    this.props.history.push(ClientRoutes.Locations + '/edit/' + row.id);
  }

  handleDetailClick(e: any, row: LocationViewModel) {
    this.props.history.push(ClientRoutes.Locations + '/' + row.id);
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
          let response = resp.data as Array<Api.LocationClientResponseModel>;

          console.log(response);

          let mapper = new LocationMapper();

          let locations: Array<LocationViewModel> = [];

          response.forEach(x => {
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
                    Cell: row => (
                      <div>
                        <Button
                          type="primary"
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
                          type="primary"
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
    <Hash>a075b8fa55d51e5208108716e08d62a7</Hash>
</Codenesium>*/