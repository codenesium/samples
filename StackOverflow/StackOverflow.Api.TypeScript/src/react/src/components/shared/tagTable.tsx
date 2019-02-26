import React, { Component, FormEvent } from 'react';
import axios from 'axios';
import { Constants, ApiRoutes, ClientRoutes } from '../../constants';
import * as Api from '../../api/models';
import TagMapper from '../tag/tagMapper';
import TagViewModel from '../tag/tagViewModel';
import { Form, Input, Button, Spin, Alert } from 'antd';
import { WrappedFormUtils } from 'antd/es/form/Form';
import ReactTable from 'react-table';

interface TagTableComponentProps {
  id: number;
  apiRoute: string;
  history: any;
  match: any;
}

interface TagTableComponentState {
  loading: boolean;
  loaded: boolean;
  errorOccurred: boolean;
  errorMessage: string;
  filteredRecords: Array<TagViewModel>;
}

export class TagTableComponent extends React.Component<
  TagTableComponentProps,
  TagTableComponentState
> {
  state = {
    loading: false,
    loaded: true,
    errorOccurred: false,
    errorMessage: '',
    filteredRecords: [],
  };

  handleEditClick(e: any, row: TagViewModel) {
    this.props.history.push(ClientRoutes.Tags + '/edit/' + row.id);
  }

  handleDetailClick(e: any, row: TagViewModel) {
    this.props.history.push(ClientRoutes.Tags + '/' + row.id);
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
          let response = resp.data as Array<Api.TagClientResponseModel>;

          console.log(response);

          let mapper = new TagMapper();

          let tags: Array<TagViewModel> = [];

          response.forEach(x => {
            tags.push(mapper.mapApiResponseToViewModel(x));
          });
          this.setState({
            ...this.state,
            filteredRecords: tags,
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
                Header: 'Tags',
                columns: [
                  {
                    Header: 'Count',
                    accessor: 'count',
                    Cell: props => {
                      return <span>{String(props.original.count)}</span>;
                    },
                  },
                  {
                    Header: 'ExcerptPostId',
                    accessor: 'excerptPostId',
                    Cell: props => {
                      return (
                        <span>{String(props.original.excerptPostId)}</span>
                      );
                    },
                  },
                  {
                    Header: 'TagName',
                    accessor: 'tagName',
                    Cell: props => {
                      return <span>{String(props.original.tagName)}</span>;
                    },
                  },
                  {
                    Header: 'WikiPostId',
                    accessor: 'wikiPostId',
                    Cell: props => {
                      return <span>{String(props.original.wikiPostId)}</span>;
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
                              row.original as TagViewModel
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
                              row.original as TagViewModel
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
    <Hash>c7122ea83d32767135f30e89557dbca2</Hash>
</Codenesium>*/