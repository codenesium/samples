import React, { Component, FormEvent } from 'react';
import axios, { AxiosError, AxiosResponse } from 'axios';
import { Constants, ApiRoutes, ClientRoutes } from '../../constants';
import * as Api from '../../api/models';
import FileMapper from '../file/fileMapper';
import FileViewModel from '../file/fileViewModel';
import { Form, Input, Button, Spin, Alert } from 'antd';
import { WrappedFormUtils } from 'antd/es/form/Form';
import ReactTable from 'react-table';
import * as GlobalUtilities from '../../lib/globalUtilities';

interface FileTableComponentProps {
  apiRoute: string;
  history: any;
  match: any;
}

interface FileTableComponentState {
  loading: boolean;
  loaded: boolean;
  errorOccurred: boolean;
  errorMessage: string;
  filteredRecords: Array<FileViewModel>;
}

export class FileTableComponent extends React.Component<
  FileTableComponentProps,
  FileTableComponentState
> {
  state = {
    loading: false,
    loaded: true,
    errorOccurred: false,
    errorMessage: '',
    filteredRecords: [],
  };

  handleEditClick(e: any, row: FileViewModel) {
    this.props.history.push(ClientRoutes.Files + '/edit/' + row.id);
  }

  handleDetailClick(e: any, row: FileViewModel) {
    this.props.history.push(ClientRoutes.Files + '/' + row.id);
  }

  componentDidMount() {
    this.loadRecords();
  }

  loadRecords() {
    this.setState({ ...this.state, loading: true });

    axios
      .get<Array<Api.FileClientResponseModel>>(this.props.apiRoute, {
        headers: GlobalUtilities.defaultHeaders(),
      })
      .then(response => {
        GlobalUtilities.logInfo(response);

        let mapper = new FileMapper();

        let files: Array<FileViewModel> = [];

        response.data.forEach(x => {
          files.push(mapper.mapApiResponseToViewModel(x));
        });

        this.setState({
          ...this.state,
          filteredRecords: files,
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
                Header: 'Files',
                columns: [
                  {
                    Header: 'BucketId',
                    accessor: 'bucketId',
                    Cell: props => {
                      return (
                        <a
                          href=""
                          onClick={e => {
                            e.preventDefault();
                            this.props.history.push(
                              ClientRoutes.Buckets +
                                '/' +
                                props.original.bucketId
                            );
                          }}
                        >
                          {String(
                            props.original.bucketIdNavigation &&
                              props.original.bucketIdNavigation.toDisplay()
                          )}
                        </a>
                      );
                    },
                  },
                  {
                    Header: 'DateCreated',
                    accessor: 'dateCreated',
                    Cell: props => {
                      return <span>{String(props.original.dateCreated)}</span>;
                    },
                  },
                  {
                    Header: 'Description',
                    accessor: 'description',
                    Cell: props => {
                      return <span>{String(props.original.description)}</span>;
                    },
                  },
                  {
                    Header: 'Expiration',
                    accessor: 'expiration',
                    Cell: props => {
                      return <span>{String(props.original.expiration)}</span>;
                    },
                  },
                  {
                    Header: 'Extension',
                    accessor: 'extension',
                    Cell: props => {
                      return <span>{String(props.original.extension)}</span>;
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
                    Header: 'FileSizeInByte',
                    accessor: 'fileSizeInByte',
                    Cell: props => {
                      return (
                        <span>{String(props.original.fileSizeInByte)}</span>
                      );
                    },
                  },
                  {
                    Header: 'FileTypeId',
                    accessor: 'fileTypeId',
                    Cell: props => {
                      return (
                        <a
                          href=""
                          onClick={e => {
                            e.preventDefault();
                            this.props.history.push(
                              ClientRoutes.FileTypes +
                                '/' +
                                props.original.fileTypeId
                            );
                          }}
                        >
                          {String(
                            props.original.fileTypeIdNavigation &&
                              props.original.fileTypeIdNavigation.toDisplay()
                          )}
                        </a>
                      );
                    },
                  },
                  {
                    Header: 'Location',
                    accessor: 'location',
                    Cell: props => {
                      return <span>{String(props.original.location)}</span>;
                    },
                  },
                  {
                    Header: 'PrivateKey',
                    accessor: 'privateKey',
                    Cell: props => {
                      return <span>{String(props.original.privateKey)}</span>;
                    },
                  },
                  {
                    Header: 'PublicKey',
                    accessor: 'publicKey',
                    Cell: props => {
                      return <span>{String(props.original.publicKey)}</span>;
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
                              row.original as FileViewModel
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
                              row.original as FileViewModel
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
    <Hash>7535fa4b0a18e2187faf1a102d134bf0</Hash>
</Codenesium>*/