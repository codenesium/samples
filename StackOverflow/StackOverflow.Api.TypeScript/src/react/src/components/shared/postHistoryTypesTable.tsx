import React, { Component, FormEvent } from 'react';
import axios from 'axios';
import { Constants, ApiRoutes, ClientRoutes } from '../../constants';
import * as Api from '../../api/models';
import PostHistoryTypesMapper from '../postHistoryTypes/postHistoryTypesMapper';
import PostHistoryTypesViewModel from '../postHistoryTypes/postHistoryTypesViewModel';
import { Form, Input, Button, Spin, Alert } from 'antd';
import { WrappedFormUtils } from 'antd/es/form/Form';
import ReactTable from 'react-table';

interface PostHistoryTypesTableComponentProps {
  id: number;
  apiRoute: string;
  history: any;
  match: any;
}

interface PostHistoryTypesTableComponentState {
  loading: boolean;
  loaded: boolean;
  errorOccurred: boolean;
  errorMessage: string;
  filteredRecords: Array<PostHistoryTypesViewModel>;
}

export class PostHistoryTypesTableComponent extends React.Component<
  PostHistoryTypesTableComponentProps,
  PostHistoryTypesTableComponentState
> {
  state = {
    loading: false,
    loaded: true,
    errorOccurred: false,
    errorMessage: '',
    filteredRecords: [],
  };

  handleEditClick(e: any, row: PostHistoryTypesViewModel) {
    this.props.history.push(ClientRoutes.PostHistoryTypes + '/edit/' + row.id);
  }

  handleDetailClick(e: any, row: PostHistoryTypesViewModel) {
    this.props.history.push(ClientRoutes.PostHistoryTypes + '/' + row.id);
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
          let response = resp.data as Array<
            Api.PostHistoryTypesClientResponseModel
          >;

          console.log(response);

          let mapper = new PostHistoryTypesMapper();

          let postHistoryTypes: Array<PostHistoryTypesViewModel> = [];

          response.forEach(x => {
            postHistoryTypes.push(mapper.mapApiResponseToViewModel(x));
          });
          this.setState({
            ...this.state,
            filteredRecords: postHistoryTypes,
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
                Header: 'PostHistoryTypes',
                columns: [
                  {
                    Header: 'Rw Type',
                    accessor: 'rwType',
                    Cell: props => {
                      return <span>{String(props.original.rwType)}</span>;
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
                              row.original as PostHistoryTypesViewModel
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
                              row.original as PostHistoryTypesViewModel
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
    <Hash>0af103e501134fff656d969e6ea829cf</Hash>
</Codenesium>*/