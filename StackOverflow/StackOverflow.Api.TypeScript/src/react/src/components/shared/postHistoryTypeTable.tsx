import React, { Component, FormEvent } from 'react';
import axios from 'axios';
import { Constants, ApiRoutes, ClientRoutes } from '../../constants';
import * as Api from '../../api/models';
import PostHistoryTypeMapper from '../postHistoryType/postHistoryTypeMapper';
import PostHistoryTypeViewModel from '../postHistoryType/postHistoryTypeViewModel';
import { Form, Input, Button, Spin, Alert } from 'antd';
import { WrappedFormUtils } from 'antd/es/form/Form';
import ReactTable from 'react-table';

interface PostHistoryTypeTableComponentProps {
  id: number;
  apiRoute: string;
  history: any;
  match: any;
}

interface PostHistoryTypeTableComponentState {
  loading: boolean;
  loaded: boolean;
  errorOccurred: boolean;
  errorMessage: string;
  filteredRecords: Array<PostHistoryTypeViewModel>;
}

export class PostHistoryTypeTableComponent extends React.Component<
  PostHistoryTypeTableComponentProps,
  PostHistoryTypeTableComponentState
> {
  state = {
    loading: false,
    loaded: true,
    errorOccurred: false,
    errorMessage: '',
    filteredRecords: [],
  };

  handleEditClick(e: any, row: PostHistoryTypeViewModel) {
    this.props.history.push(ClientRoutes.PostHistoryTypes + '/edit/' + row.id);
  }

  handleDetailClick(e: any, row: PostHistoryTypeViewModel) {
    this.props.history.push(ClientRoutes.PostHistoryTypes + '/' + row.id);
  }

  componentDidMount() {
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
            Api.PostHistoryTypeClientResponseModel
          >;

          console.log(response);

          let mapper = new PostHistoryTypeMapper();

          let postHistoryTypes: Array<PostHistoryTypeViewModel> = [];

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
                    Header: 'Type',
                    accessor: 'rwType',
                    Cell: props => {
                      return <span>{String(props.original.rwType)}</span>;
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
                              row.original as PostHistoryTypeViewModel
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
                              row.original as PostHistoryTypeViewModel
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
    <Hash>a0f9fd090ed1f77fc8410b5e50f61e6a</Hash>
</Codenesium>*/