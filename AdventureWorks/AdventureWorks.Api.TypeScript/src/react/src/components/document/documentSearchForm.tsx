import React, { Component, ReactElement, ReactHTMLElement } from 'react';
import axios from 'axios';
import { Redirect } from 'react-router-dom';
import * as Api from '../../api/models';
import DocumentMapper from './documentMapper';
import { Constants, ApiRoutes, ClientRoutes } from '../../constants';
import ReactTable from 'react-table';
import DocumentViewModel from './documentViewModel';
import 'react-table/react-table.css';
import { Form, Button, Input, Row, Col, Alert, Spin } from 'antd';
import { WrappedFormUtils } from 'antd/es/form/Form';

interface DocumentSearchComponentProps {
  form: WrappedFormUtils;
  history: any;
  match: any;
}

interface DocumentSearchComponentState {
  records: Array<DocumentViewModel>;
  filteredRecords: Array<DocumentViewModel>;
  loading: boolean;
  loaded: boolean;
  errorOccurred: boolean;
  errorMessage: string;
  searchValue: string;
  deleteSubmitted: boolean;
  deleteSuccess: boolean;
  deleteResponse: string;
}

export default class DocumentSearchComponent extends React.Component<
  DocumentSearchComponentProps,
  DocumentSearchComponentState
> {
  state = {
    deleteSubmitted: false,
    deleteSuccess: false,
    deleteResponse: '',
    records: new Array<DocumentViewModel>(),
    filteredRecords: new Array<DocumentViewModel>(),
    searchValue: '',
    loading: false,
    loaded: true,
    errorOccurred: false,
    errorMessage: '',
  };

  componentDidMount() {
    this.loadRecords();
  }

  handleEditClick(e: any, row: DocumentViewModel) {
    this.props.history.push(ClientRoutes.Documents + '/edit/' + row.rowguid);
  }

  handleDetailClick(e: any, row: DocumentViewModel) {
    this.props.history.push(ClientRoutes.Documents + '/' + row.rowguid);
  }

  handleCreateClick(e: any) {
    this.props.history.push(ClientRoutes.Documents + '/create');
  }

  handleDeleteClick(e: any, row: Api.DocumentClientResponseModel) {
    axios
      .delete(Constants.ApiEndpoint + ApiRoutes.Documents + '/' + row.rowguid, {
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
    let searchEndpoint =
      Constants.ApiEndpoint + ApiRoutes.Documents + '?limit=100';

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
          let response = resp.data as Array<Api.DocumentClientResponseModel>;
          let viewModels: Array<DocumentViewModel> = [];
          let mapper = new DocumentMapper();

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
            records: new Array<DocumentViewModel>(),
            filteredRecords: new Array<DocumentViewModel>(),
            loading: false,
            loaded: true,
            errorOccurred: true,
            errorMessage: 'Error from API',
          });
        }
      );
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
                Header: 'Documents',
                columns: [
                  {
                    Header: 'ChangeNumber',
                    accessor: 'changeNumber',
                    Cell: props => {
                      return <span>{String(props.original.changeNumber)}</span>;
                    },
                  },
                  {
                    Header: 'Document',
                    accessor: 'document1',
                    Cell: props => {
                      return <span>{String(props.original.document1)}</span>;
                    },
                  },
                  {
                    Header: 'DocumentLevel',
                    accessor: 'documentLevel',
                    Cell: props => {
                      return (
                        <span>{String(props.original.documentLevel)}</span>
                      );
                    },
                  },
                  {
                    Header: 'DocumentSummary',
                    accessor: 'documentSummary',
                    Cell: props => {
                      return (
                        <span>{String(props.original.documentSummary)}</span>
                      );
                    },
                  },
                  {
                    Header: 'FileExtension',
                    accessor: 'fileExtension',
                    Cell: props => {
                      return (
                        <span>{String(props.original.fileExtension)}</span>
                      );
                    },
                  },
                  {
                    Header: 'FileName',
                    accessor: 'fileName',
                    Cell: props => {
                      return <span>{String(props.original.fileName)}</span>;
                    },
                  },
                  {
                    Header: 'FolderFlag',
                    accessor: 'folderFlag',
                    Cell: props => {
                      return <span>{String(props.original.folderFlag)}</span>;
                    },
                  },
                  {
                    Header: 'ModifiedDate',
                    accessor: 'modifiedDate',
                    Cell: props => {
                      return <span>{String(props.original.modifiedDate)}</span>;
                    },
                  },
                  {
                    Header: 'Owner',
                    accessor: 'owner',
                    Cell: props => {
                      return <span>{String(props.original.owner)}</span>;
                    },
                  },
                  {
                    Header: 'Revision',
                    accessor: 'revision',
                    Cell: props => {
                      return <span>{String(props.original.revision)}</span>;
                    },
                  },
                  {
                    Header: 'Rowguid',
                    accessor: 'rowguid',
                    Cell: props => {
                      return <span>{String(props.original.rowguid)}</span>;
                    },
                  },
                  {
                    Header: 'Status',
                    accessor: 'status',
                    Cell: props => {
                      return <span>{String(props.original.status)}</span>;
                    },
                  },
                  {
                    Header: 'Title',
                    accessor: 'title',
                    Cell: props => {
                      return <span>{String(props.original.title)}</span>;
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
                              row.original as DocumentViewModel
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
                              row.original as DocumentViewModel
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
                              row.original as DocumentViewModel
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

export const WrappedDocumentSearchComponent = Form.create({
  name: 'Document Search',
})(DocumentSearchComponent);


/*<Codenesium>
    <Hash>a2144594e6b2d7ce697b06758b777d2e</Hash>
</Codenesium>*/