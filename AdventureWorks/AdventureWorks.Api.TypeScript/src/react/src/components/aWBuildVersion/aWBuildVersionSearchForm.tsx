import React, { Component, ReactElement, ReactHTMLElement } from 'react';
import axios from 'axios';
import { Redirect } from 'react-router-dom';
import * as Api from '../../api/models';
import AWBuildVersionMapper from './aWBuildVersionMapper';
import { Constants, ApiRoutes, ClientRoutes } from '../../constants';
import ReactTable from 'react-table';
import AWBuildVersionViewModel from './aWBuildVersionViewModel';
import 'react-table/react-table.css';
import { Form, Button, Input, Row, Col, Alert, Spin } from 'antd';
import { WrappedFormUtils } from 'antd/es/form/Form';

interface AWBuildVersionSearchComponentProps {
  form: WrappedFormUtils;
  history: any;
  match: any;
}

interface AWBuildVersionSearchComponentState {
  records: Array<AWBuildVersionViewModel>;
  filteredRecords: Array<AWBuildVersionViewModel>;
  loading: boolean;
  loaded: boolean;
  errorOccurred: boolean;
  errorMessage: string;
  searchValue: string;
  deleteSubmitted: boolean;
  deleteSuccess: boolean;
  deleteResponse: string;
}

export default class AWBuildVersionSearchComponent extends React.Component<
  AWBuildVersionSearchComponentProps,
  AWBuildVersionSearchComponentState
> {
  state = {
    deleteSubmitted: false,
    deleteSuccess: false,
    deleteResponse: '',
    records: new Array<AWBuildVersionViewModel>(),
    filteredRecords: new Array<AWBuildVersionViewModel>(),
    searchValue: '',
    loading: false,
    loaded: true,
    errorOccurred: false,
    errorMessage: '',
  };

  componentDidMount() {
    this.loadRecords();
  }

  handleEditClick(e: any, row: Api.AWBuildVersionClientResponseModel) {
    this.props.history.push(
      ClientRoutes.AWBuildVersions + '/edit/' + row.systemInformationID
    );
  }

  handleDetailClick(e: any, row: Api.AWBuildVersionClientResponseModel) {
    this.props.history.push(
      ClientRoutes.AWBuildVersions + '/' + row.systemInformationID
    );
  }

  handleCreateClick(e: any) {
    this.props.history.push(ClientRoutes.AWBuildVersions + '/create');
  }

  handleDeleteClick(e: any, row: Api.AWBuildVersionClientResponseModel) {
    axios
      .delete(
        Constants.ApiEndpoint +
          ApiRoutes.AWBuildVersions +
          '/' +
          row.systemInformationID,
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
      Constants.ApiEndpoint + ApiRoutes.AWBuildVersions + '?limit=100';

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
            Api.AWBuildVersionClientResponseModel
          >;
          let viewModels: Array<AWBuildVersionViewModel> = [];
          let mapper = new AWBuildVersionMapper();

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
            records: new Array<AWBuildVersionViewModel>(),
            filteredRecords: new Array<AWBuildVersionViewModel>(),
            loading: false,
            loaded: false,
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
                Header: 'AWBuildVersion',
                columns: [
                  {
                    Header: 'Database Version',
                    accessor: 'database_Version',
                    Cell: props => {
                      return (
                        <span>{String(props.original.database_Version)}</span>
                      );
                    },
                  },
                  {
                    Header: 'ModifiedDate',
                    accessor: 'modifiedDate',
                    Cell: props => {
                      return <span>{String(props.original.modifiedDate)}</span>;
                    },
                  },
                  {
                    Header: 'SystemInformationID',
                    accessor: 'systemInformationID',
                    Cell: props => {
                      return (
                        <span>
                          {String(props.original.systemInformationID)}
                        </span>
                      );
                    },
                  },
                  {
                    Header: 'VersionDate',
                    accessor: 'versionDate',
                    Cell: props => {
                      return <span>{String(props.original.versionDate)}</span>;
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
                              row.original as Api.AWBuildVersionClientResponseModel
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
                              row.original as Api.AWBuildVersionClientResponseModel
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
                              row.original as Api.AWBuildVersionClientResponseModel
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

export const WrappedAWBuildVersionSearchComponent = Form.create({
  name: 'AWBuildVersion Search',
})(AWBuildVersionSearchComponent);


/*<Codenesium>
    <Hash>e3e128efef929ed001583d8c354b9b3c</Hash>
</Codenesium>*/