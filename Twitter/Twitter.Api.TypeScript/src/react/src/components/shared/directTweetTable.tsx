import React, { Component, FormEvent } from 'react';
import axios, { AxiosError, AxiosResponse } from 'axios';
import { Constants, ApiRoutes, ClientRoutes } from '../../constants';
import * as Api from '../../api/models';
import DirectTweetMapper from '../directTweet/directTweetMapper';
import DirectTweetViewModel from '../directTweet/directTweetViewModel';
import { Form, Input, Button, Spin, Alert } from 'antd';
import { WrappedFormUtils } from 'antd/es/form/Form';
import ReactTable from 'react-table';
import * as GlobalUtilities from '../../lib/globalUtilities';

interface DirectTweetTableComponentProps {
  apiRoute: string;
  history: any;
  match: any;
}

interface DirectTweetTableComponentState {
  loading: boolean;
  loaded: boolean;
  errorOccurred: boolean;
  errorMessage: string;
  filteredRecords: Array<DirectTweetViewModel>;
}

export class DirectTweetTableComponent extends React.Component<
  DirectTweetTableComponentProps,
  DirectTweetTableComponentState
> {
  state = {
    loading: false,
    loaded: true,
    errorOccurred: false,
    errorMessage: '',
    filteredRecords: [],
  };

  handleEditClick(e: any, row: DirectTweetViewModel) {
    this.props.history.push(ClientRoutes.DirectTweets + '/edit/' + row.tweetId);
  }

  handleDetailClick(e: any, row: DirectTweetViewModel) {
    this.props.history.push(ClientRoutes.DirectTweets + '/' + row.tweetId);
  }

  componentDidMount() {
    this.loadRecords();
  }

  loadRecords() {
    this.setState({ ...this.state, loading: true });

    axios
      .get<Array<Api.DirectTweetClientResponseModel>>(this.props.apiRoute, {
        headers: GlobalUtilities.defaultHeaders(),
      })
      .then(response => {
        GlobalUtilities.logInfo(response);

        let mapper = new DirectTweetMapper();

        let directTweets: Array<DirectTweetViewModel> = [];

        response.data.forEach(x => {
          directTweets.push(mapper.mapApiResponseToViewModel(x));
        });

        this.setState({
          ...this.state,
          filteredRecords: directTweets,
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
                Header: 'DirectTweets',
                columns: [
                  {
                    Header: 'Content',
                    accessor: 'content',
                    Cell: props => {
                      return <span>{String(props.original.content)}</span>;
                    },
                  },
                  {
                    Header: 'Date',
                    accessor: 'date',
                    Cell: props => {
                      return <span>{String(props.original.date)}</span>;
                    },
                  },
                  {
                    Header: 'Tagged_user_id',
                    accessor: 'taggedUserId',
                    Cell: props => {
                      return (
                        <a
                          href=""
                          onClick={e => {
                            e.preventDefault();
                            this.props.history.push(
                              ClientRoutes.Users +
                                '/' +
                                props.original.taggedUserId
                            );
                          }}
                        >
                          {String(
                            props.original.taggedUserIdNavigation &&
                              props.original.taggedUserIdNavigation.toDisplay()
                          )}
                        </a>
                      );
                    },
                  },
                  {
                    Header: 'Time',
                    accessor: 'time',
                    Cell: props => {
                      return <span>{String(props.original.time)}</span>;
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
                              row.original as DirectTweetViewModel
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
                              row.original as DirectTweetViewModel
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
    <Hash>b49513181c9e7cad935f768b547c06e0</Hash>
</Codenesium>*/