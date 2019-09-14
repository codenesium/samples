import React, { Component, ReactElement, ReactHTMLElement } from 'react';
import axios, { AxiosError, AxiosResponse } from 'axios';
import { Redirect } from 'react-router-dom';
import * as Api from '../../api/models';
import VenueMapper from './venueMapper';
import { Constants, ApiRoutes, ClientRoutes } from '../../constants';
import ReactTable from 'react-table';
import VenueViewModel from './venueViewModel';
import 'react-table/react-table.css';
import { Form, Button, Input, Row, Col, Alert, Spin } from 'antd';
import { WrappedFormUtils } from 'antd/es/form/Form';
import * as GlobalUtilities from '../../lib/globalUtilities';

interface VenueSearchComponentProps {
  form: WrappedFormUtils;
  history: any;
  match: any;
}

interface VenueSearchComponentState {
  records: Array<VenueViewModel>;
  filteredRecords: Array<VenueViewModel>;
  loading: boolean;
  loaded: boolean;
  errorOccurred: boolean;
  errorMessage: string;
  searchValue: string;
  deleteSubmitted: boolean;
  deleteSuccess: boolean;
  deleteResponse: string;
}

export default class VenueSearchComponent extends React.Component<
  VenueSearchComponentProps,
  VenueSearchComponentState
> {
  state = {
    deleteSubmitted: false,
    deleteSuccess: false,
    deleteResponse: '',
    records: new Array<VenueViewModel>(),
    filteredRecords: new Array<VenueViewModel>(),
    searchValue: '',
    loading: false,
    loaded: true,
    errorOccurred: false,
    errorMessage: '',
  };

  componentDidMount() {
    this.loadRecords();
  }

  handleEditClick(e: any, row: VenueViewModel) {
    this.props.history.push(ClientRoutes.Venues + '/edit/' + row.id);
  }

  handleDetailClick(e: any, row: VenueViewModel) {
    this.props.history.push(ClientRoutes.Venues + '/' + row.id);
  }

  handleCreateClick(e: any) {
    this.props.history.push(ClientRoutes.Venues + '/create');
  }

  handleDeleteClick(e: any, row: Api.VenueClientResponseModel) {
    axios
      .delete(Constants.ApiEndpoint + ApiRoutes.Venues + '/' + row.id, {
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
      Constants.ApiEndpoint + ApiRoutes.Venues + '?limit=100';

    if (query) {
      searchEndpoint += '&query=' + query;
    }

    axios
      .get<Array<Api.VenueClientResponseModel>>(searchEndpoint, {
        headers: GlobalUtilities.defaultHeaders(),
      })
      .then(response => {
        let viewModels: Array<VenueViewModel> = [];
        let mapper = new VenueMapper();

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
          records: new Array<VenueViewModel>(),
          filteredRecords: new Array<VenueViewModel>(),
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
                Header: 'Venue',
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
                    Header: 'Admin',
                    accessor: 'adminId',
                    Cell: props => {
                      return (
                        <a
                          href=""
                          onClick={e => {
                            e.preventDefault();
                            this.props.history.push(
                              ClientRoutes.Admins + '/' + props.original.adminId
                            );
                          }}
                        >
                          {String(
                            props.original.adminIdNavigation &&
                              props.original.adminIdNavigation.toDisplay()
                          )}
                        </a>
                      );
                    },
                  },
                  {
                    Header: 'Email',
                    accessor: 'email',
                    Cell: props => {
                      return <span>{String(props.original.email)}</span>;
                    },
                  },
                  {
                    Header: 'Facebook',
                    accessor: 'facebook',
                    Cell: props => {
                      return <span>{String(props.original.facebook)}</span>;
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
                    Header: 'Phone',
                    accessor: 'phone',
                    Cell: props => {
                      return <span>{String(props.original.phone)}</span>;
                    },
                  },
                  {
                    Header: 'Province',
                    accessor: 'provinceId',
                    Cell: props => {
                      return (
                        <a
                          href=""
                          onClick={e => {
                            e.preventDefault();
                            this.props.history.push(
                              ClientRoutes.Provinces +
                                '/' +
                                props.original.provinceId
                            );
                          }}
                        >
                          {String(
                            props.original.provinceIdNavigation &&
                              props.original.provinceIdNavigation.toDisplay()
                          )}
                        </a>
                      );
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
                    Header: 'Actions',
                    minWidth: 150,
                    Cell: row => (
                      <div>
                        <Button
                          type="primary"
                          onClick={(e: any) => {
                            this.handleDetailClick(
                              e,
                              row.original as VenueViewModel
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
                              row.original as VenueViewModel
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
                              row.original as VenueViewModel
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

export const WrappedVenueSearchComponent = Form.create({
  name: 'Venue Search',
})(VenueSearchComponent);


/*<Codenesium>
    <Hash>e47b41c2ddf55f67aaf497bafff45889</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/