import React, { Component, FormEvent } from 'react';
import axios, { AxiosError, AxiosResponse } from 'axios';
import { Constants, ApiRoutes, ClientRoutes } from '../../constants';
import * as Api from '../../api/models';
import AWBuildVersionMapper from '../aWBuildVersion/aWBuildVersionMapper';
import AWBuildVersionViewModel from '../aWBuildVersion/aWBuildVersionViewModel';
import { Form, Input, Button, Spin, Alert } from 'antd';
import { WrappedFormUtils } from 'antd/es/form/Form';
import ReactTable from 'react-table';
import * as GlobalUtilities from '../../lib/globalUtilities';

interface AWBuildVersionTableComponentProps {
  apiRoute: string;
  history: any;
  match: any;
}

interface AWBuildVersionTableComponentState {
  loading: boolean;
  loaded: boolean;
  errorOccurred: boolean;
  errorMessage: string;
  filteredRecords: Array<AWBuildVersionViewModel>;
}

export class AWBuildVersionTableComponent extends React.Component<
  AWBuildVersionTableComponentProps,
  AWBuildVersionTableComponentState
> {
  state = {
    loading: false,
    loaded: true,
    errorOccurred: false,
    errorMessage: '',
    filteredRecords: [],
  };

  handleEditClick(e: any, row: AWBuildVersionViewModel) {
    this.props.history.push(
      ClientRoutes.AWBuildVersions + '/edit/' + row.systemInformationID
    );
  }

  handleDetailClick(e: any, row: AWBuildVersionViewModel) {
    this.props.history.push(
      ClientRoutes.AWBuildVersions + '/' + row.systemInformationID
    );
  }

  componentDidMount() {
    this.loadRecords();
  }

  loadRecords() {
    this.setState({ ...this.state, loading: true });

    axios
      .get<Array<Api.AWBuildVersionClientResponseModel>>(this.props.apiRoute, {
        headers: GlobalUtilities.defaultHeaders(),
      })
      .then(response => {
        GlobalUtilities.logInfo(response);

        let mapper = new AWBuildVersionMapper();

        let aWBuildVersions: Array<AWBuildVersionViewModel> = [];

        response.data.forEach(x => {
          aWBuildVersions.push(mapper.mapApiResponseToViewModel(x));
        });

        this.setState({
          ...this.state,
          filteredRecords: aWBuildVersions,
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
                Header: 'AWBuildVersions',
                columns: [
                  {
                    Header: 'Database  Version',
                    accessor: 'database_Version',
                    Cell: props => {
                      return (
                        <span>{String(props.original.database_Version)}</span>
                      );
                    },
                  },
                  {
                    Header: 'Modified Date',
                    accessor: 'modifiedDate',
                    Cell: props => {
                      return <span>{String(props.original.modifiedDate)}</span>;
                    },
                  },
                  {
                    Header: 'Version Date',
                    accessor: 'versionDate',
                    Cell: props => {
                      return <span>{String(props.original.versionDate)}</span>;
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
                              row.original as AWBuildVersionViewModel
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
                              row.original as AWBuildVersionViewModel
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
    <Hash>5b9ecca39c1e6b87811103e1a87a3092</Hash>
</Codenesium>*/