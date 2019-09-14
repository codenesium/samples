import React, { Component, FormEvent } from 'react';
import axios, { AxiosError, AxiosResponse } from 'axios';
import { Constants, ApiRoutes, ClientRoutes } from '../../constants';
import * as Api from '../../api/models';
import CallMapper from '../call/callMapper';
import CallViewModel from '../call/callViewModel';
import { Form, Input, Button, Spin, Alert } from 'antd';
import { WrappedFormUtils } from 'antd/es/form/Form';
import ReactTable from 'react-table';
import * as GlobalUtilities from '../../lib/globalUtilities';

interface CallTableComponentProps {
  apiRoute: string;
  history: any;
  match: any;
}

interface CallTableComponentState {
  loading: boolean;
  loaded: boolean;
  errorOccurred: boolean;
  errorMessage: string;
  filteredRecords: Array<CallViewModel>;
}

export class CallTableComponent extends React.Component<
  CallTableComponentProps,
  CallTableComponentState
> {
  state = {
    loading: false,
    loaded: true,
    errorOccurred: false,
    errorMessage: '',
    filteredRecords: [],
  };

  handleEditClick(e: any, row: CallViewModel) {
    this.props.history.push(ClientRoutes.Calls + '/edit/' + row.id);
  }

  handleDetailClick(e: any, row: CallViewModel) {
    this.props.history.push(ClientRoutes.Calls + '/' + row.id);
  }

  componentDidMount() {
    this.loadRecords();
  }

  loadRecords() {
    this.setState({ ...this.state, loading: true });

    axios
      .get<Array<Api.CallClientResponseModel>>(this.props.apiRoute, {
        headers: GlobalUtilities.defaultHeaders(),
      })
      .then(response => {
        GlobalUtilities.logInfo(response);

        let mapper = new CallMapper();

        let calls: Array<CallViewModel> = [];

        response.data.forEach(x => {
          calls.push(mapper.mapApiResponseToViewModel(x));
        });

        this.setState({
          ...this.state,
          filteredRecords: calls,
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
                Header: 'Calls',
                columns: [
                  {
                    Header: 'Address',
                    accessor: 'addressId',
                    Cell: props => {
                      return (
                        <a
                          href=""
                          onClick={e => {
                            e.preventDefault();
                            this.props.history.push(
                              ClientRoutes.Addresses +
                                '/' +
                                props.original.addressId
                            );
                          }}
                        >
                          {String(
                            props.original.addressIdNavigation &&
                              props.original.addressIdNavigation.toDisplay()
                          )}
                        </a>
                      );
                    },
                  },
                  {
                    Header: 'Call Disposition',
                    accessor: 'callDispositionId',
                    Cell: props => {
                      return (
                        <a
                          href=""
                          onClick={e => {
                            e.preventDefault();
                            this.props.history.push(
                              ClientRoutes.CallDispositions +
                                '/' +
                                props.original.callDispositionId
                            );
                          }}
                        >
                          {String(
                            props.original.callDispositionIdNavigation &&
                              props.original.callDispositionIdNavigation.toDisplay()
                          )}
                        </a>
                      );
                    },
                  },
                  {
                    Header: 'Call Status',
                    accessor: 'callStatusId',
                    Cell: props => {
                      return (
                        <a
                          href=""
                          onClick={e => {
                            e.preventDefault();
                            this.props.history.push(
                              ClientRoutes.CallStatus +
                                '/' +
                                props.original.callStatusId
                            );
                          }}
                        >
                          {String(
                            props.original.callStatusIdNavigation &&
                              props.original.callStatusIdNavigation.toDisplay()
                          )}
                        </a>
                      );
                    },
                  },
                  {
                    Header: 'Call String',
                    accessor: 'callString',
                    Cell: props => {
                      return <span>{String(props.original.callString)}</span>;
                    },
                  },
                  {
                    Header: 'Call Type',
                    accessor: 'callTypeId',
                    Cell: props => {
                      return (
                        <a
                          href=""
                          onClick={e => {
                            e.preventDefault();
                            this.props.history.push(
                              ClientRoutes.CallTypes +
                                '/' +
                                props.original.callTypeId
                            );
                          }}
                        >
                          {String(
                            props.original.callTypeIdNavigation &&
                              props.original.callTypeIdNavigation.toDisplay()
                          )}
                        </a>
                      );
                    },
                  },
                  {
                    Header: 'Date Cleared',
                    accessor: 'dateCleared',
                    Cell: props => {
                      return <span>{String(props.original.dateCleared)}</span>;
                    },
                  },
                  {
                    Header: 'Date Created',
                    accessor: 'dateCreated',
                    Cell: props => {
                      return <span>{String(props.original.dateCreated)}</span>;
                    },
                  },
                  {
                    Header: 'Date Dispatched',
                    accessor: 'dateDispatched',
                    Cell: props => {
                      return (
                        <span>{String(props.original.dateDispatched)}</span>
                      );
                    },
                  },
                  {
                    Header: 'Quick Call Number',
                    accessor: 'quickCallNumber',
                    Cell: props => {
                      return (
                        <span>{String(props.original.quickCallNumber)}</span>
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
                              row.original as CallViewModel
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
                              row.original as CallViewModel
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
    <Hash>3bd2fabd272814b4532b52de8f8f8c54</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/