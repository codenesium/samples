import React, { Component, ReactElement, ReactHTMLElement } from 'react';
import axios, { AxiosError, AxiosResponse } from 'axios';
import { Redirect } from 'react-router-dom';
import * as Api from '../../api/models';
import AirTransportMapper from './airTransportMapper';
import { Constants, ApiRoutes, ClientRoutes } from '../../constants';
import ReactTable from 'react-table';
import AirTransportViewModel from './airTransportViewModel';
import 'react-table/react-table.css';
import { Form, Button, Input, Row, Col, Alert, Spin } from 'antd';
import { WrappedFormUtils } from 'antd/es/form/Form';
import * as GlobalUtilities from '../../lib/globalUtilities';

interface AirTransportSearchComponentProps {
  form: WrappedFormUtils;
  history: any;
  match: any;
}

interface AirTransportSearchComponentState {
  records: Array<AirTransportViewModel>;
  filteredRecords: Array<AirTransportViewModel>;
  loading: boolean;
  loaded: boolean;
  errorOccurred: boolean;
  errorMessage: string;
  searchValue: string;
  deleteSubmitted: boolean;
  deleteSuccess: boolean;
  deleteResponse: string;
}

export default class AirTransportSearchComponent extends React.Component<
  AirTransportSearchComponentProps,
  AirTransportSearchComponentState
> {
  state = {
    deleteSubmitted: false,
    deleteSuccess: false,
    deleteResponse: '',
    records: new Array<AirTransportViewModel>(),
    filteredRecords: new Array<AirTransportViewModel>(),
    searchValue: '',
    loading: false,
    loaded: true,
    errorOccurred: false,
    errorMessage: '',
  };

  componentDidMount() {
    this.loadRecords();
  }

  handleEditClick(e: any, row: AirTransportViewModel) {
    this.props.history.push(ClientRoutes.AirTransports + '/edit/' + row.id);
  }

  handleDetailClick(e: any, row: AirTransportViewModel) {
    this.props.history.push(ClientRoutes.AirTransports + '/' + row.id);
  }

  handleCreateClick(e: any) {
    this.props.history.push(ClientRoutes.AirTransports + '/create');
  }

  handleDeleteClick(e: any, row: Api.AirTransportClientResponseModel) {
    axios
      .delete(Constants.ApiEndpoint + ApiRoutes.AirTransports + '/' + row.id, {
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
    let searchEndpoint =
      Constants.ApiEndpoint + ApiRoutes.AirTransports + '?limit=100';

    if (query) {
      searchEndpoint += '&query=' + query;
    }

    axios
      .get<Array<Api.AirTransportClientResponseModel>>(searchEndpoint, {
        headers: GlobalUtilities.defaultHeaders(),
      })
      .then(response => {
        let viewModels: Array<AirTransportViewModel> = [];
        let mapper = new AirTransportMapper();

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
          records: new Array<AirTransportViewModel>(),
          filteredRecords: new Array<AirTransportViewModel>(),
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
                Header: 'Air Transport',
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
                          type="primary"
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
                          type="primary"
                          onClick={(e: any) => {
                            this.handleEditClick(
                              e,
                              row.original as AirTransportViewModel
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
                              row.original as AirTransportViewModel
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

export const WrappedAirTransportSearchComponent = Form.create({
  name: 'AirTransport Search',
})(AirTransportSearchComponent);


/*<Codenesium>
    <Hash>1a8e5b83e4546e6e4e17f1740254f600</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/