import React, { Component, FormEvent } from 'react';
import axios from 'axios';
import { Constants, ApiRoutes, ClientRoutes } from '../../constants';
import * as Api from '../../api/models';
import DocumentMapper from '../document/documentMapper';
import DocumentViewModel from '../document/documentViewModel';
import { Form, Input, Button, Spin, Alert } from 'antd';
import { WrappedFormUtils } from 'antd/es/form/Form';
import ReactTable from 'react-table';

interface DocumentTableComponentProps {
  rowguid: any;
  apiRoute: string;
  history: any;
  match: any;
}

interface DocumentTableComponentState {
  loading: boolean;
  loaded: boolean;
  errorOccurred: boolean;
  errorMessage: string;
  filteredRecords: Array<DocumentViewModel>;
}

export class DocumentTableComponent extends React.Component<
  DocumentTableComponentProps,
  DocumentTableComponentState
> {
  state = {
    loading: false,
    loaded: true,
    errorOccurred: false,
    errorMessage: '',
    filteredRecords: [],
  };

  handleEditClick(e: any, row: DocumentViewModel) {
    this.props.history.push(ClientRoutes.Documents + '/edit/' + row.id);
  }

  handleDetailClick(e: any, row: DocumentViewModel) {
    this.props.history.push(ClientRoutes.Documents + '/' + row.id);
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
          let response = resp.data as Array<Api.DocumentClientResponseModel>;

          console.log(response);

          let mapper = new DocumentMapper();

          let documents: Array<DocumentViewModel> = [];

          response.forEach(x => {
            documents.push(mapper.mapApiResponseToViewModel(x));
          });
          this.setState({
            ...this.state,
            filteredRecords: documents,
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
                    minWidth: 150,
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
    <Hash>47b011065bf8fa5f4692e98b65ce251c</Hash>
</Codenesium>*/