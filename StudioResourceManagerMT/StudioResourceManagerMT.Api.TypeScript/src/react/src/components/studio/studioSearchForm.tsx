import React, { Component, ReactElement, ReactHTMLElement } from 'react';
import axios from 'axios';
import { Redirect } from 'react-router-dom';
import * as Api from '../../api/models';
import StudioMapper from './studioMapper';
import { Constants, ApiRoutes, ClientRoutes } from '../../constants';
import ReactTable from 'react-table';
import StudioViewModel from './studioViewModel';
import 'react-table/react-table.css';
import { Form, Button, Input, Row, Col, Alert, Spin } from 'antd';
import { WrappedFormUtils } from 'antd/es/form/Form';

interface StudioSearchComponentProps {
  form: WrappedFormUtils;
  history: any;
  match: any;
}

interface StudioSearchComponentState {
  records: Array<StudioViewModel>;
  filteredRecords: Array<StudioViewModel>;
  loading: boolean;
  loaded: boolean;
  errorOccurred: boolean;
  errorMessage: string;
  searchValue: string;
  deleteSubmitted: boolean;
  deleteSuccess: boolean;
  deleteResponse: string;
}

export default class StudioSearchComponent extends React.Component<
  StudioSearchComponentProps,
  StudioSearchComponentState
> {
  state = {
    deleteSubmitted: false,
    deleteSuccess: false,
    deleteResponse: '',
    records: new Array<StudioViewModel>(),
    filteredRecords: new Array<StudioViewModel>(),
    searchValue: '',
    loading: false,
    loaded: true,
    errorOccurred: false,
    errorMessage: '',
  };

  componentDidMount() {
    this.loadRecords();
  }

  handleEditClick(e: any, row: StudioViewModel) {
    this.props.history.push(ClientRoutes.Studios + '/edit/' + row.id);
  }

  handleDetailClick(e: any, row: StudioViewModel) {
    this.props.history.push(ClientRoutes.Studios + '/' + row.id);
  }

  handleCreateClick(e: any) {
    this.props.history.push(ClientRoutes.Studios + '/create');
  }

  handleDeleteClick(e: any, row: Api.StudioClientResponseModel) {
    axios
      .delete(Constants.ApiEndpoint + ApiRoutes.Studios + '/' + row.id, {
        headers: {
          'Content-Type': 'application/json',
        },
      })
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
      Constants.ApiEndpoint + ApiRoutes.Studios + '?limit=100';

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
          let response = resp.data as Array<Api.StudioClientResponseModel>;
          let viewModels: Array<StudioViewModel> = [];
          let mapper = new StudioMapper();

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
            records: new Array<StudioViewModel>(),
            filteredRecords: new Array<StudioViewModel>(),
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
                Header: 'Studios',
                columns: [
                  {
                    Header: 'Address1',
                    accessor: 'address1',
                    Cell: props => {
                      return <span>{String(props.original.address1)}</span>;
                    },
                  },
                  {
                    Header: 'Address2',
                    accessor: 'address2',
                    Cell: props => {
                      return <span>{String(props.original.address2)}</span>;
                    },
                  },
                  {
                    Header: 'City',
                    accessor: 'city',
                    Cell: props => {
                      return <span>{String(props.original.city)}</span>;
                    },
                  },
                  {
                    Header: 'Id',
                    accessor: 'id',
                    Cell: props => {
                      return <span>{String(props.original.id)}</span>;
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
                    Header: 'Province',
                    accessor: 'province',
                    Cell: props => {
                      return <span>{String(props.original.province)}</span>;
                    },
                  },
                  {
                    Header: 'Website',
                    accessor: 'website',
                    Cell: props => {
                      return <span>{String(props.original.website)}</span>;
                    },
                  },
                  {
                    Header: 'Zip',
                    accessor: 'zip',
                    Cell: props => {
                      return <span>{String(props.original.zip)}</span>;
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
                              row.original as StudioViewModel
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
                              row.original as StudioViewModel
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
                              row.original as StudioViewModel
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

export const WrappedStudioSearchComponent = Form.create({
  name: 'Studio Search',
})(StudioSearchComponent);


/*<Codenesium>
    <Hash>6de50bb2eeae7a81cbe54980de2edf60</Hash>
</Codenesium>*/