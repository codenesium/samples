import React, { Component, FormEvent } from 'react';
import axios, { AxiosError, AxiosResponse } from 'axios';
import { Constants, ApiRoutes, ClientRoutes } from '../../constants';
import * as Api from '../../api/models';
import AirTransportMapper from '../airTransport/airTransportMapper';
import AirTransportViewModel from '../airTransport/airTransportViewModel';
import { Form, Input, Button, Spin, Alert } from 'antd';
import { WrappedFormUtils } from 'antd/es/form/Form';
import ReactTable from 'react-table';
import * as GlobalUtilities from '../../lib/globalUtilities';

interface AirTransportTableComponentProps {
  apiRoute: string;
  history: any;
  match: any;
}

interface AirTransportTableComponentState {
  loading: boolean;
  loaded: boolean;
  errorOccurred: boolean;
  errorMessage: string;
  filteredRecords: Array<AirTransportViewModel>;
}

export class AirTransportTableComponent extends React.Component<
  AirTransportTableComponentProps,
  AirTransportTableComponentState
> {
  state = {
    loading: false,
    loaded: true,
    errorOccurred: false,
    errorMessage: '',
    filteredRecords: [],
  };

  handleEditClick(e: any, row: AirTransportViewModel) {
    this.props.history.push(ClientRoutes.AirTransports + '/edit/' + row.id);
  }

  handleDetailClick(e: any, row: AirTransportViewModel) {
    this.props.history.push(ClientRoutes.AirTransports + '/' + row.id);
  }

  componentDidMount() {
    this.loadRecords();
  }

  loadRecords() {
    this.setState({ ...this.state, loading: true });

    axios
      .get<Array<Api.AirTransportClientResponseModel>>(this.props.apiRoute, {
        headers: GlobalUtilities.defaultHeaders(),
      })
      .then(response => {
        GlobalUtilities.logInfo(response);

        let mapper = new AirTransportMapper();

        let airTransports: Array<AirTransportViewModel> = [];

        response.data.forEach(x => {
          airTransports.push(mapper.mapApiResponseToViewModel(x));
        });

        this.setState({
          ...this.state,
          filteredRecords: airTransports,
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
                Header: 'AirTransports',
                columns: [
                  {
                    Header: 'Airline',
                    accessor: 'airlineId',
                    Cell: props => {
                      return <span>{String(props.original.airlineId)}</span>;
                    },
                  },
                  {
                    Header: 'Flight Number',
                    accessor: 'flightNumber',
                    Cell: props => {
                      return <span>{String(props.original.flightNumber)}</span>;
                    },
                  },
                  {
                    Header: 'Handler',
                    accessor: 'handlerId',
                    Cell: props => {
                      return (
                        <a
                          href=""
                          onClick={e => {
                            e.preventDefault();
                            this.props.history.push(
                              ClientRoutes.Handlers +
                                '/' +
                                props.original.handlerId
                            );
                          }}
                        >
                          {String(
                            props.original.handlerIdNavigation &&
                              props.original.handlerIdNavigation.toDisplay()
                          )}
                        </a>
                      );
                    },
                  },
                  {
                    Header: 'Land Date',
                    accessor: 'landDate',
                    Cell: props => {
                      return <span>{String(props.original.landDate)}</span>;
                    },
                  },
                  {
                    Header: 'Pipeline Step',
                    accessor: 'pipelineStepId',
                    Cell: props => {
                      return (
                        <span>{String(props.original.pipelineStepId)}</span>
                      );
                    },
                  },
                  {
                    Header: 'Takeoff Date',
                    accessor: 'takeoffDate',
                    Cell: props => {
                      return <span>{String(props.original.takeoffDate)}</span>;
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
                              row.original as AirTransportViewModel
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
                              row.original as AirTransportViewModel
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
    <Hash>945690771d1b37409d059618eedc2ad5</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/