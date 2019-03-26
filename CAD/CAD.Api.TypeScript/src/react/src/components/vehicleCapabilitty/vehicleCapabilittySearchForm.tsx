import React, { Component, ReactElement, ReactHTMLElement } from 'react';
import axios, { AxiosError, AxiosResponse } from 'axios';
import { Redirect } from 'react-router-dom';
import * as Api from '../../api/models';
import VehicleCapabilittyMapper from './vehicleCapabilittyMapper';
import { Constants, ApiRoutes, ClientRoutes } from '../../constants';
import ReactTable from 'react-table';
import VehicleCapabilittyViewModel from './vehicleCapabilittyViewModel';
import 'react-table/react-table.css';
import { Form, Button, Input, Row, Col, Alert, Spin } from 'antd';
import { WrappedFormUtils } from 'antd/es/form/Form';
import * as GlobalUtilities from '../../lib/globalUtilities';

interface VehicleCapabilittySearchComponentProps {
  form: WrappedFormUtils;
  history: any;
  match: any;
}

interface VehicleCapabilittySearchComponentState {
  records: Array<VehicleCapabilittyViewModel>;
  filteredRecords: Array<VehicleCapabilittyViewModel>;
  loading: boolean;
  loaded: boolean;
  errorOccurred: boolean;
  errorMessage: string;
  searchValue: string;
  deleteSubmitted: boolean;
  deleteSuccess: boolean;
  deleteResponse: string;
}

export default class VehicleCapabilittySearchComponent extends React.Component<
  VehicleCapabilittySearchComponentProps,
  VehicleCapabilittySearchComponentState
> {
  state = {
    deleteSubmitted: false,
    deleteSuccess: false,
    deleteResponse: '',
    records: new Array<VehicleCapabilittyViewModel>(),
    filteredRecords: new Array<VehicleCapabilittyViewModel>(),
    searchValue: '',
    loading: false,
    loaded: true,
    errorOccurred: false,
    errorMessage: '',
  };

  componentDidMount() {
    this.loadRecords();
  }

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

  handleCreateClick(e: any) {
    this.props.history.push(ClientRoutes.VehicleCapabilities + '/create');
  }

  handleDeleteClick(e: any, row: Api.VehicleCapabilittyClientResponseModel) {
    axios
      .delete(
        Constants.ApiEndpoint +
          ApiRoutes.VehicleCapabilities +
          '/' +
          row.vehicleId,
        {
          headers: GlobalUtilities.defaultHeaders(),
        }
      )
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
      Constants.ApiEndpoint + ApiRoutes.VehicleCapabilities + '?limit=100';

    if (query) {
      searchEndpoint += '&query=' + query;
    }

    axios
      .get<Array<Api.VehicleCapabilittyClientResponseModel>>(searchEndpoint, {
        headers: GlobalUtilities.defaultHeaders(),
      })
      .then(response => {
        let viewModels: Array<VehicleCapabilittyViewModel> = [];
        let mapper = new VehicleCapabilittyMapper();

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
          records: new Array<VehicleCapabilittyViewModel>(),
          filteredRecords: new Array<VehicleCapabilittyViewModel>(),
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
                        &nbsp;
                        <Button
                          type="danger"
                          onClick={(e: any) => {
                            this.handleDeleteClick(
                              e,
                              row.original as VehicleCapabilittyViewModel
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

export const WrappedVehicleCapabilittySearchComponent = Form.create({
  name: 'VehicleCapabilitty Search',
})(VehicleCapabilittySearchComponent);


/*<Codenesium>
    <Hash>c75b82b4855910253fcc8a5c24c93b7a</Hash>
</Codenesium>*/