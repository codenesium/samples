import React, { Component, FormEvent } from 'react';
import axios, { AxiosError, AxiosResponse } from 'axios';
import { Constants, ApiRoutes, ClientRoutes } from '../../constants';
import * as Api from '../../api/models';
import OfficerCapabilitiesMapper from '../officerCapabilities/officerCapabilitiesMapper';
import OfficerCapabilitiesViewModel from '../officerCapabilities/officerCapabilitiesViewModel';
import { Form, Input, Button, Spin, Alert } from 'antd';
import { WrappedFormUtils } from 'antd/es/form/Form';
import ReactTable from 'react-table';
import * as GlobalUtilities from '../../lib/globalUtilities';

interface OfficerCapabilitiesTableComponentProps {
  apiRoute: string;
  history: any;
  match: any;
}

interface OfficerCapabilitiesTableComponentState {
  loading: boolean;
  loaded: boolean;
  errorOccurred: boolean;
  errorMessage: string;
  filteredRecords: Array<OfficerCapabilitiesViewModel>;
}

export class OfficerCapabilitiesTableComponent extends React.Component<
  OfficerCapabilitiesTableComponentProps,
  OfficerCapabilitiesTableComponentState
> {
  state = {
    loading: false,
    loaded: true,
    errorOccurred: false,
    errorMessage: '',
    filteredRecords: [],
  };

  handleEditClick(e: any, row: OfficerCapabilitiesViewModel) {
    this.props.history.push(
      ClientRoutes.OfficerCapabilities + '/edit/' + row.id
    );
  }

  handleDetailClick(e: any, row: OfficerCapabilitiesViewModel) {
    this.props.history.push(ClientRoutes.OfficerCapabilities + '/' + row.id);
  }

  componentDidMount() {
    this.loadRecords();
  }

  loadRecords() {
    this.setState({ ...this.state, loading: true });

    axios
      .get<Array<Api.OfficerCapabilitiesClientResponseModel>>(
        this.props.apiRoute,
        {
          headers: GlobalUtilities.defaultHeaders(),
        }
      )
      .then(response => {
        GlobalUtilities.logInfo(response);

        let mapper = new OfficerCapabilitiesMapper();

        let officerCapabilities: Array<OfficerCapabilitiesViewModel> = [];

        response.data.forEach(x => {
          officerCapabilities.push(mapper.mapApiResponseToViewModel(x));
        });

        this.setState({
          ...this.state,
          filteredRecords: officerCapabilities,
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
                Header: 'OfficerCapabilities',
                columns: [
                  {
                    Header: 'Capability',
                    accessor: 'capabilityId',
                    Cell: props => {
                      return (
                        <a
                          href=""
                          onClick={e => {
                            e.preventDefault();
                            this.props.history.push(
                              ClientRoutes.OffCapabilities +
                                '/' +
                                props.original.capabilityId
                            );
                          }}
                        >
                          {String(
                            props.original.capabilityIdNavigation &&
                              props.original.capabilityIdNavigation.toDisplay()
                          )}
                        </a>
                      );
                    },
                  },
                  {
                    Header: 'Officer',
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
                            props.original.officerIdNavigation &&
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
                          htmlType="button"
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
                          htmlType="button"
                          onClick={(e: any) => {
                            this.handleEditClick(
                              e,
                              row.original as OfficerCapabilitiesViewModel
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
    <Hash>54704ff6a5d9d98bfbd1428f94cc56ec</Hash>
</Codenesium>*/