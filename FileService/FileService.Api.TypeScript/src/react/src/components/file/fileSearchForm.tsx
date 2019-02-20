import React, { Component, ReactElement, ReactHTMLElement } from 'react';
import axios from 'axios';
import { Redirect } from 'react-router-dom';
import * as Api from '../../api/models';
import FileMapper from './fileMapper';
import { Constants, ApiRoutes, ClientRoutes } from '../../constants';
import { LoadingForm } from '../../lib/components/loadingForm';
import { ErrorForm } from '../../lib/components/errorForm';
import ReactTable from 'react-table';
import FileViewModel from './fileViewModel';
import 'react-table/react-table.css';
import { Form, Button, Input, Row, Col, Alert } from 'antd';
import { WrappedFormUtils } from 'antd/es/form/Form';

interface FileSearchComponentProps {
  form: WrappedFormUtils;
  history: any;
  match: any;
}

interface FileSearchComponentState {
  records: Array<FileViewModel>;
  filteredRecords: Array<FileViewModel>;
  loading: boolean;
  loaded: boolean;
  errorOccurred: boolean;
  errorMessage: string;
  searchValue: string;
  deleteSubmitted: boolean;
  deleteSuccess: boolean;
  deleteResponse: string;
}

export default class FileSearchComponent extends React.Component<
  FileSearchComponentProps,
  FileSearchComponentState
> {
  state = {
    deleteSubmitted: false,
    deleteSuccess: false,
    deleteResponse: '',
    records: new Array<FileViewModel>(),
    filteredRecords: new Array<FileViewModel>(),
    searchValue: '',
    loading: false,
    loaded: true,
    errorOccurred: false,
    errorMessage: '',
  };

  componentDidMount() {
    this.loadRecords();
  }

  handleEditClick(e: any, row: Api.FileClientResponseModel) {
    this.props.history.push(ClientRoutes.Files + '/edit/' + row.id);
  }

  handleDetailClick(e: any, row: Api.FileClientResponseModel) {
    this.props.history.push(ClientRoutes.Files + '/' + row.id);
  }

  handleCreateClick(e: any) {
    this.props.history.push(ClientRoutes.Files + '/create');
  }

  handleDeleteClick(e: any, row: Api.FileClientResponseModel) {
    axios
      .delete(Constants.ApiEndpoint + ApiRoutes.Files + '/' + row.id, {
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
    let searchEndpoint = Constants.ApiEndpoint + ApiRoutes.Files + '?limit=100';

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
          let response = resp.data as Array<Api.FileClientResponseModel>;
          let viewModels: Array<FileViewModel> = [];
          let mapper = new FileMapper();

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
            records: new Array<FileViewModel>(),
            filteredRecords: new Array<FileViewModel>(),
            loading: false,
            loaded: false,
            errorOccurred: true,
            errorMessage: 'Error from API',
          });
        }
      );
  }

  filterGrid() {}

  render() {
    if (this.state.loading) {
      return <LoadingForm />;
    } else if (this.state.errorOccurred) {
      return <ErrorForm message={this.state.errorMessage} />;
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
                Header: 'File',
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
                    Cell: row => (
                      <div>
                        <Button
                          type="primary"
                          onClick={(e: any) => {
                            this.handleDetailClick(
                              e,
                              row.original as Api.FileClientResponseModel
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
                              row.original as Api.FileClientResponseModel
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
                              row.original as Api.FileClientResponseModel
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

export const WrappedFileSearchComponent = Form.create({ name: 'File Search' })(
  FileSearchComponent
);


/*<Codenesium>
    <Hash>2360c516ae425749ca94bcd0d7ad65a1</Hash>
</Codenesium>*/