import React, { Component, FormEvent } from 'react';
import axios from 'axios';
import { Constants, ApiRoutes, ClientRoutes } from '../../constants';
import * as Api from '../../api/models';
import LinkLogMapper from '../linkLog/linkLogMapper';
import LinkLogViewModel from '../linkLog/linkLogViewModel';
import { Form, Input, Button, Spin, Alert } from 'antd';
import { WrappedFormUtils } from 'antd/es/form/Form';
import ReactTable from 'react-table';

interface LinkLogTableComponentProps {
  id: number;
  apiRoute: string;
  history: any;
  match: any;
}

interface LinkLogTableComponentState {
  loading: boolean;
  loaded: boolean;
  errorOccurred: boolean;
  errorMessage: string;
  filteredRecords: Array<LinkLogViewModel>;
}

export class LinkLogTableComponent extends React.Component<
  LinkLogTableComponentProps,
  LinkLogTableComponentState
> {
  state = {
    loading: false,
    loaded: true,
    errorOccurred: false,
    errorMessage: '',
    filteredRecords: [],
  };

  handleEditClick(e: any, row: LinkLogViewModel) {
    this.props.history.push(ClientRoutes.LinkLogs + '/edit/' + row.id);
  }

  handleDetailClick(e: any, row: LinkLogViewModel) {
    this.props.history.push(ClientRoutes.LinkLogs + '/' + row.id);
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
          let response = resp.data as Array<Api.LinkLogClientResponseModel>;

          console.log(response);

          let mapper = new LinkLogMapper();

          let linkLogs: Array<LinkLogViewModel> = [];

          response.forEach(x => {
            linkLogs.push(mapper.mapApiResponseToViewModel(x));
          });
          this.setState({
            ...this.state,
            filteredRecords: linkLogs,
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
                Header: 'LinkLogs',
                columns: [
                  {
                    Header: 'DateEntered',
                    accessor: 'dateEntered',
                    Cell: props => {
                      return <span>{String(props.original.dateEntered)}</span>;
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
                    Header: 'LinkId',
                    accessor: 'linkId',
                    Cell: props => {
                      return (
                        <a
                          href=""
                          onClick={e => {
                            e.preventDefault();
                            this.props.history.push(
                              ClientRoutes.Links + '/' + props.original.linkId
                            );
                          }}
                        >
                          {String(props.original.linkIdNavigation.toDisplay())}
                        </a>
                      );
                    },
                  },
                  {
                    Header: 'Log',
                    accessor: 'log',
                    Cell: props => {
                      return <span>{String(props.original.log)}</span>;
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
                              row.original as LinkLogViewModel
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
                              row.original as LinkLogViewModel
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
    <Hash>b36d43f1cfc53dffbb6bff25fa2fc555</Hash>
</Codenesium>*/