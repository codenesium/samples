import React, { Component, ReactElement, ReactHTMLElement } from 'react';
import axios from 'axios';
import { Redirect } from 'react-router-dom';
import * as Api from '../../api/models';
import OfficerCapabilitiesMapper from './officerCapabilitiesMapper';
import { Constants, ApiRoutes, ClientRoutes } from '../../constants';
import ReactTable from 'react-table';
import OfficerCapabilitiesViewModel from './officerCapabilitiesViewModel';
import 'react-table/react-table.css';
import { Form, Button, Input, Row, Col, Alert, Spin } from 'antd';
import { WrappedFormUtils } from 'antd/es/form/Form';

interface OfficerCapabilitiesSearchComponentProps {
  form: WrappedFormUtils;
  history: any;
  match: any;
}

interface OfficerCapabilitiesSearchComponentState {
  records: Array<OfficerCapabilitiesViewModel>;
  filteredRecords: Array<OfficerCapabilitiesViewModel>;
  loading: boolean;
  loaded: boolean;
  errorOccurred: boolean;
  errorMessage: string;
  searchValue: string;
  deleteSubmitted: boolean;
  deleteSuccess: boolean;
  deleteResponse: string;
}

export default class OfficerCapabilitiesSearchComponent extends React.Component<
  OfficerCapabilitiesSearchComponentProps,
  OfficerCapabilitiesSearchComponentState
> {
  state = {
    deleteSubmitted: false,
    deleteSuccess: false,
    deleteResponse: '',
    records: new Array<OfficerCapabilitiesViewModel>(),
    filteredRecords: new Array<OfficerCapabilitiesViewModel>(),
    searchValue: '',
    loading: false,
    loaded: true,
    errorOccurred: false,
    errorMessage: '',
  };

  componentDidMount() {
    this.loadRecords();
  }

  handleEditClick(e: any, row: OfficerCapabilitiesViewModel) {
    this.props.history.push(
      ClientRoutes.OfficerCapabilities + '/edit/' + row.capabilityId
    );
  }

  handleDetailClick(e: any, row: OfficerCapabilitiesViewModel) {
    this.props.history.push(
      ClientRoutes.OfficerCapabilities + '/' + row.capabilityId
    );
  }

  handleCreateClick(e: any) {
    this.props.history.push(ClientRoutes.OfficerCapabilities + '/create');
  }

  handleDeleteClick(e: any, row: Api.OfficerCapabilitiesClientResponseModel) {
    axios
      .delete(
        Constants.ApiEndpoint +
          ApiRoutes.OfficerCapabilities +
          '/' +
          row.capabilityId,
        {
          headers: {
            'Content-Type': 'application/json',
          },
        }
      )
      .then(
        resp => {
          this.setState({
            ...this.state,
            deleteResponse: 'Record deleted',
            deleteSuccess: true,
            deleteSubmitted: true,
          });
          this.loadRecords(this.state.searchValue);
        },
        error => {
          console.log(error);
          this.setState({
            ...this.state,
            deleteResponse: 'Error deleting record',
            deleteSuccess: false,
            deleteSubmitted: true,
          });
        }
      );
  }

  handleSearchChanged(e: React.FormEvent<HTMLInputElement>) {
    this.loadRecords(e.currentTarget.value);
  }

  loadRecords(query: string = '') {
    this.setState({ ...this.state, searchValue: query });
    let searchEndpoint =
      Constants.ApiEndpoint + ApiRoutes.OfficerCapabilities + '?limit=100';

    if (query) {
      searchEndpoint += '&query=' + query;
    }

    axios
      .get(searchEndpoint, {
        headers: {
          'Content-Type': 'application/json',
        },
      })
      .then(
        resp => {
          let response = resp.data as Array<
            Api.OfficerCapabilitiesClientResponseModel
          >;
          let viewModels: Array<OfficerCapabilitiesViewModel> = [];
          let mapper = new OfficerCapabilitiesMapper();

          response.forEach(x => {
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
        },
        error => {
          console.log(error);
          this.setState({
            records: new Array<OfficerCapabilitiesViewModel>(),
            filteredRecords: new Array<OfficerCapabilitiesViewModel>(),
            loading: false,
            loaded: true,
            errorOccurred: true,
            errorMessage: 'Error from API',
          });
        }
      );
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
                Header: 'OfficerCapabilities',
                columns: [
                  {
                    Header: 'CapabilityId',
                    accessor: 'capabilityId',
                    Cell: props => {
                      return (
                        <a
                          href=""
                          onClick={e => {
                            e.preventDefault();
                            this.props.history.push(
                              ClientRoutes.OfficerCapabilities +
                                '/' +
                                props.original.capabilityId
                            );
                          }}
                        >
                          {String(
                            props.original.capabilityIdNavigation.toDisplay()
                          )}
                        </a>
                      );
                    },
                  },
                  {
                    Header: 'OfficerId',
                    accessor: 'officerId',
                    Cell: props => {
                      return (
                        <a
                          href=""
                          onClick={e => {
                            e.preventDefault();
                            this.props.history.push(
                              ClientRoutes.Officers +
                                '/' +
                                props.original.officerId
                            );
                          }}
                        >
                          {String(
                            props.original.officerIdNavigation.toDisplay()
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
                              row.original as OfficerCapabilitiesViewModel
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
                              row.original as OfficerCapabilitiesViewModel
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
                              row.original as OfficerCapabilitiesViewModel
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

export const WrappedOfficerCapabilitiesSearchComponent = Form.create({
  name: 'OfficerCapabilities Search',
})(OfficerCapabilitiesSearchComponent);


/*<Codenesium>
    <Hash>156e5281292915bd198002aaf31c3d79</Hash>
</Codenesium>*/