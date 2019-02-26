import React, { Component, FormEvent } from 'react';
import axios from 'axios';
import { Constants, ApiRoutes, ClientRoutes } from '../../constants';
import * as Api from '../../api/models';
import FileMapper from '../file/fileMapper';
import FileViewModel from '../file/fileViewModel';
import { Form, Input, Button, Spin, Alert } from 'antd';
import { WrappedFormUtils } from 'antd/es/form/Form';
import ReactTable from 'react-table';

interface FileTableComponentProps {
  id: number;
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
      .get(this.props.apiRoute, {
        headers: {
          'Content-Type': 'application/json',
        },
      })
      .then(
        resp => {
          let response = resp.data as Array<Api.FileClientResponseModel>;

          console.log(response);

          let mapper = new FileMapper();

          let files: Array<FileViewModel> = [];

          response.forEach(x => {
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
                          type="primary"
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
                          type="primary"
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
    <Hash>cfc37d71a794d128f84958f0785b40fc</Hash>
</Codenesium>*/