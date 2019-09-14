import React, { Component, ReactElement, ReactHTMLElement } from 'react';
import axios, { AxiosError, AxiosResponse } from 'axios';
import { Redirect } from 'react-router-dom';
import * as Api from '../../api/models';
import LinkMapper from './linkMapper';
import { Constants, ApiRoutes, ClientRoutes } from '../../constants';
import ReactTable from 'react-table';
import LinkViewModel from './linkViewModel';
import 'react-table/react-table.css';
import { Form, Button, Input, Row, Col, Alert, Spin } from 'antd';
import { WrappedFormUtils } from 'antd/es/form/Form';
import * as GlobalUtilities from '../../lib/globalUtilities';

interface LinkSearchComponentProps {
  form: WrappedFormUtils;
  history: any;
  match: any;
}

interface LinkSearchComponentState {
  records: Array<LinkViewModel>;
  filteredRecords: Array<LinkViewModel>;
  loading: boolean;
  loaded: boolean;
  errorOccurred: boolean;
  errorMessage: string;
  searchValue: string;
  deleteSubmitted: boolean;
  deleteSuccess: boolean;
  deleteResponse: string;
}

export default class LinkSearchComponent extends React.Component<
  LinkSearchComponentProps,
  LinkSearchComponentState
> {
  state = {
    deleteSubmitted: false,
    deleteSuccess: false,
    deleteResponse: '',
    records: new Array<LinkViewModel>(),
    filteredRecords: new Array<LinkViewModel>(),
    searchValue: '',
    loading: false,
    loaded: true,
    errorOccurred: false,
    errorMessage: '',
  };

  componentDidMount() {
    this.loadRecords();
  }

  handleEditClick(e: any, row: LinkViewModel) {
    this.props.history.push(ClientRoutes.Links + '/edit/' + row.id);
  }

  handleDetailClick(e: any, row: LinkViewModel) {
    this.props.history.push(ClientRoutes.Links + '/' + row.id);
  }

  handleCreateClick(e: any) {
    this.props.history.push(ClientRoutes.Links + '/create');
  }

  handleDeleteClick(e: any, row: Api.LinkClientResponseModel) {
    axios
      .delete(Constants.ApiEndpoint + ApiRoutes.Links + '/' + row.id, {
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
    let searchEndpoint = Constants.ApiEndpoint + ApiRoutes.Links + '?limit=100';

    if (query) {
      searchEndpoint += '&query=' + query;
    }

    axios
      .get<Array<Api.LinkClientResponseModel>>(searchEndpoint, {
        headers: GlobalUtilities.defaultHeaders(),
      })
      .then(response => {
        let viewModels: Array<LinkViewModel> = [];
        let mapper = new LinkMapper();

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
          records: new Array<LinkViewModel>(),
          filteredRecords: new Array<LinkViewModel>(),
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
                Header: 'Link',
                columns: [
                  {
                    Header: 'Assigned Machine',
                    accessor: 'assignedMachineId',
                    Cell: props => {
                      return (
                        <a
                          href=""
                          onClick={e => {
                            e.preventDefault();
                            this.props.history.push(
                              ClientRoutes.Machines +
                                '/' +
                                props.original.assignedMachineId
                            );
                          }}
                        >
                          {String(
                            props.original.assignedMachineIdNavigation &&
                              props.original.assignedMachineIdNavigation.toDisplay()
                          )}
                        </a>
                      );
                    },
                  },
                  {
                    Header: 'Chain',
                    accessor: 'chainId',
                    Cell: props => {
                      return (
                        <a
                          href=""
                          onClick={e => {
                            e.preventDefault();
                            this.props.history.push(
                              ClientRoutes.Chains + '/' + props.original.chainId
                            );
                          }}
                        >
                          {String(
                            props.original.chainIdNavigation &&
                              props.original.chainIdNavigation.toDisplay()
                          )}
                        </a>
                      );
                    },
                  },
                  {
                    Header: 'Date Completed',
                    accessor: 'dateCompleted',
                    Cell: props => {
                      return (
                        <span>{String(props.original.dateCompleted)}</span>
                      );
                    },
                  },
                  {
                    Header: 'Date Started',
                    accessor: 'dateStarted',
                    Cell: props => {
                      return <span>{String(props.original.dateStarted)}</span>;
                    },
                  },
                  {
                    Header: 'Dynamic Parameters',
                    accessor: 'dynamicParameters',
                    Cell: props => {
                      return (
                        <span>{String(props.original.dynamicParameters)}</span>
                      );
                    },
                  },
                  {
                    Header: 'External',
                    accessor: 'externalId',
                    Cell: props => {
                      return <span>{String(props.original.externalId)}</span>;
                    },
                  },
                  {
                    Header: 'Link Status',
                    accessor: 'linkStatusId',
                    Cell: props => {
                      return (
                        <a
                          href=""
                          onClick={e => {
                            e.preventDefault();
                            this.props.history.push(
                              ClientRoutes.LinkStatus +
                                '/' +
                                props.original.linkStatusId
                            );
                          }}
                        >
                          {String(
                            props.original.linkStatusIdNavigation &&
                              props.original.linkStatusIdNavigation.toDisplay()
                          )}
                        </a>
                      );
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
                    Header: 'Order',
                    accessor: 'order',
                    Cell: props => {
                      return <span>{String(props.original.order)}</span>;
                    },
                  },
                  {
                    Header: 'Response',
                    accessor: 'response',
                    Cell: props => {
                      return <span>{String(props.original.response)}</span>;
                    },
                  },
                  {
                    Header: 'Static Parameters',
                    accessor: 'staticParameters',
                    Cell: props => {
                      return (
                        <span>{String(props.original.staticParameters)}</span>
                      );
                    },
                  },
                  {
                    Header: 'Timeout In Seconds',
                    accessor: 'timeoutInSeconds',
                    Cell: props => {
                      return (
                        <span>{String(props.original.timeoutInSeconds)}</span>
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
                              row.original as LinkViewModel
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
                              row.original as LinkViewModel
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
                              row.original as LinkViewModel
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

export const WrappedLinkSearchComponent = Form.create({ name: 'Link Search' })(
  LinkSearchComponent
);


/*<Codenesium>
    <Hash>b059dba86dfea39fbbbdc6cbaa7f1458</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/