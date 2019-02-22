import React, { Component, FormEvent } from 'react';
import axios from 'axios';
import { Constants, ApiRoutes, ClientRoutes } from '../../constants';
import * as Api from '../../api/models';
import LinkMapper from '../link/linkMapper';
import LinkViewModel from '../link/linkViewModel';
import { Form, Input, Button, Spin, Alert } from 'antd';
import { WrappedFormUtils } from 'antd/es/form/Form';
import ReactTable from 'react-table';

interface LinkTableComponentProps {
  id: number;
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
    this.setState({ ...this.state, loading: true });

    axios
      .get(this.props.apiRoute, {
        headers: {
          'Content-Type': 'application/json',
        },
      })
      .then(
        resp => {
          let response = resp.data as Array<Api.LinkClientResponseModel>;

          console.log(response);

          let mapper = new LinkMapper();

          let links: Array<LinkViewModel> = [];

          response.forEach(x => {
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
                Header: 'Links',
                columns: [
                  {
                    Header: 'AssignedMachineId',
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
                            props.original.assignedMachineIdNavigation.toDisplay()
                          )}
                        </a>
                      );
                    },
                  },
                  {
                    Header: 'ChainId',
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
                          {String(props.original.chainIdNavigation.toDisplay())}
                        </a>
                      );
                    },
                  },
                  {
                    Header: 'DateCompleted',
                    accessor: 'dateCompleted',
                    Cell: props => {
                      return (
                        <span>{String(props.original.dateCompleted)}</span>
                      );
                    },
                  },
                  {
                    Header: 'DateStarted',
                    accessor: 'dateStarted',
                    Cell: props => {
                      return <span>{String(props.original.dateStarted)}</span>;
                    },
                  },
                  {
                    Header: 'DynamicParameter',
                    accessor: 'dynamicParameter',
                    Cell: props => {
                      return (
                        <span>{String(props.original.dynamicParameter)}</span>
                      );
                    },
                  },
                  {
                    Header: 'ExternalId',
                    accessor: 'externalId',
                    Cell: props => {
                      return <span>{String(props.original.externalId)}</span>;
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
                    Header: 'LinkStatusId',
                    accessor: 'linkStatusId',
                    Cell: props => {
                      return (
                        <a
                          href=""
                          onClick={e => {
                            e.preventDefault();
                            this.props.history.push(
                              ClientRoutes.LinkStatuses +
                                '/' +
                                props.original.linkStatusId
                            );
                          }}
                        >
                          {String(
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
                    Header: 'StaticParameter',
                    accessor: 'staticParameter',
                    Cell: props => {
                      return (
                        <span>{String(props.original.staticParameter)}</span>
                      );
                    },
                  },
                  {
                    Header: 'TimeoutInSecond',
                    accessor: 'timeoutInSecond',
                    Cell: props => {
                      return (
                        <span>{String(props.original.timeoutInSecond)}</span>
                      );
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
    <Hash>4d13864277b1c5970ba057d5b1c6bd22</Hash>
</Codenesium>*/