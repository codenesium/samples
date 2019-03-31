import React, { Component, FormEvent } from 'react';
import axios, { AxiosError, AxiosResponse } from 'axios';
import { Constants, ApiRoutes, ClientRoutes } from '../../constants';
import * as Api from '../../api/models';
import LinkMapper from '../link/linkMapper';
import LinkViewModel from '../link/linkViewModel';
import { Form, Input, Button, Spin, Alert } from 'antd';
import { WrappedFormUtils } from 'antd/es/form/Form';
import ReactTable from 'react-table';
import * as GlobalUtilities from '../../lib/globalUtilities';

interface LinkTableComponentProps {
  apiRoute: string;
  history: any;
  match: any;
}

interface LinkTableComponentState {
  loading: boolean;
  loaded: boolean;
  errorOccurred: boolean;
  errorMessage: string;
  filteredRecords: Array<LinkViewModel>;
}

export class LinkTableComponent extends React.Component<
  LinkTableComponentProps,
  LinkTableComponentState
> {
  state = {
    loading: false,
    loaded: true,
    errorOccurred: false,
    errorMessage: '',
    filteredRecords: [],
  };

  handleEditClick(e: any, row: LinkViewModel) {
    this.props.history.push(ClientRoutes.Links + '/edit/' + row.id);
  }

  handleDetailClick(e: any, row: LinkViewModel) {
    this.props.history.push(ClientRoutes.Links + '/' + row.id);
  }

  componentDidMount() {
    this.loadRecords();
  }

  loadRecords() {
    this.setState({ ...this.state, loading: true });

    axios
      .get<Array<Api.LinkClientResponseModel>>(this.props.apiRoute, {
        headers: GlobalUtilities.defaultHeaders(),
      })
      .then(response => {
        GlobalUtilities.logInfo(response);

        let mapper = new LinkMapper();

        let links: Array<LinkViewModel> = [];

        response.data.forEach(x => {
          links.push(mapper.mapApiResponseToViewModel(x));
        });

        this.setState({
          ...this.state,
          filteredRecords: links,
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
                Header: 'Links',
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
                          htmlType="button"
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
                          htmlType="button"
                          onClick={(e: any) => {
                            this.handleEditClick(
                              e,
                              row.original as LinkViewModel
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
    <Hash>44bdfde6a8e86e4fdc449be4f82f8421</Hash>
</Codenesium>*/