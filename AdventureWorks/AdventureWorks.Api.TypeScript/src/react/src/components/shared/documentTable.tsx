import React, { Component, FormEvent } from 'react';
import axios, { AxiosError, AxiosResponse } from 'axios';
import { Constants, ApiRoutes, ClientRoutes } from '../../constants';
import * as Api from '../../api/models';
import DocumentMapper from '../document/documentMapper';
import DocumentViewModel from '../document/documentViewModel';
import { Form, Input, Button, Spin, Alert } from 'antd';
import { WrappedFormUtils } from 'antd/es/form/Form';
import ReactTable from 'react-table';
import * as GlobalUtilities from '../../lib/globalUtilities';

interface DocumentTableComponentProps {
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
    this.props.history.push(ClientRoutes.Documents + '/edit/' + row.rowguid);
  }

  handleDetailClick(e: any, row: DocumentViewModel) {
    this.props.history.push(ClientRoutes.Documents + '/' + row.rowguid);
  }

  componentDidMount() {
    this.loadRecords();
  }

  loadRecords() {
    this.setState({ ...this.state, loading: true });

    axios
      .get<Array<Api.DocumentClientResponseModel>>(this.props.apiRoute, {
        headers: GlobalUtilities.defaultHeaders(),
      })
      .then(response => {
        GlobalUtilities.logInfo(response);

        let mapper = new DocumentMapper();

        let documents: Array<DocumentViewModel> = [];

        response.data.forEach(x => {
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
                Header: 'Documents',
                columns: [
                  {
                    Header: 'Change Number',
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
                    Header: 'Document Level',
                    accessor: 'documentLevel',
                    Cell: props => {
                      return (
                        <span>{String(props.original.documentLevel)}</span>
                      );
                    },
                  },
                  {
                    Header: 'Document Summary',
                    accessor: 'documentSummary',
                    Cell: props => {
                      return (
                        <span>{String(props.original.documentSummary)}</span>
                      );
                    },
                  },
                  {
                    Header: 'File Extension',
                    accessor: 'fileExtension',
                    Cell: props => {
                      return (
                        <span>{String(props.original.fileExtension)}</span>
                      );
                    },
                  },
                  {
                    Header: 'File Name',
                    accessor: 'fileName',
                    Cell: props => {
                      return <span>{String(props.original.fileName)}</span>;
                    },
                  },
                  {
                    Header: 'Folder Flag',
                    accessor: 'folderFlag',
                    Cell: props => {
                      return <span>{String(props.original.folderFlag)}</span>;
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
    <Hash>fa6fac58f4668077fee5cee05eb2dce9</Hash>
</Codenesium>*/