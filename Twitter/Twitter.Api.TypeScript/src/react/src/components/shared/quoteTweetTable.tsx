import React, { Component, FormEvent } from 'react';
import axios from 'axios';
import { Constants, ApiRoutes, ClientRoutes } from '../../constants';
import * as Api from '../../api/models';
import QuoteTweetMapper from '../quoteTweet/quoteTweetMapper';
import QuoteTweetViewModel from '../quoteTweet/quoteTweetViewModel';
import { Form, Input, Button, Spin, Alert } from 'antd';
import { WrappedFormUtils } from 'antd/es/form/Form';
import ReactTable from 'react-table';

interface QuoteTweetTableComponentProps {
  quote_tweet_id: number;
  apiRoute: string;
  history: any;
  match: any;
}

interface QuoteTweetTableComponentState {
  loading: boolean;
  loaded: boolean;
  errorOccurred: boolean;
  errorMessage: string;
  filteredRecords: Array<QuoteTweetViewModel>;
}

export class QuoteTweetTableComponent extends React.Component<
  QuoteTweetTableComponentProps,
  QuoteTweetTableComponentState
> {
  state = {
    loading: false,
    loaded: true,
    errorOccurred: false,
    errorMessage: '',
    filteredRecords: [],
  };

  handleEditClick(e: any, row: QuoteTweetViewModel) {
    this.props.history.push(ClientRoutes.QuoteTweets + '/edit/' + row.id);
  }

  handleDetailClick(e: any, row: QuoteTweetViewModel) {
    this.props.history.push(ClientRoutes.QuoteTweets + '/' + row.id);
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
          let response = resp.data as Array<Api.QuoteTweetClientResponseModel>;

          console.log(response);

          let mapper = new QuoteTweetMapper();

          let quoteTweets: Array<QuoteTweetViewModel> = [];

          response.forEach(x => {
            quoteTweets.push(mapper.mapApiResponseToViewModel(x));
          });
          this.setState({
            ...this.state,
            filteredRecords: quoteTweets,
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
                Header: 'QuoteTweets',
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
                    Header: 'Retweeter_user_id',
                    accessor: 'retweeterUserId',
                    Cell: props => {
                      return (
                        <a
                          href=""
                          onClick={e => {
                            e.preventDefault();
                            this.props.history.push(
                              ClientRoutes.Users +
                                '/' +
                                props.original.retweeterUserId
                            );
                          }}
                        >
                          {String(
                            props.original.retweeterUserIdNavigation.toDisplay()
                          )}
                        </a>
                      );
                    },
                  },
                  {
                    Header: 'Source_tweet_id',
                    accessor: 'sourceTweetId',
                    Cell: props => {
                      return (
                        <a
                          href=""
                          onClick={e => {
                            e.preventDefault();
                            this.props.history.push(
                              ClientRoutes.Tweets +
                                '/' +
                                props.original.sourceTweetId
                            );
                          }}
                        >
                          {String(
                            props.original.sourceTweetIdNavigation.toDisplay()
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
                    Cell: row => (
                      <div>
                        <Button
                          type="primary"
                          onClick={(e: any) => {
                            this.handleDetailClick(
                              e,
                              row.original as QuoteTweetViewModel
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
                              row.original as QuoteTweetViewModel
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
    <Hash>dd51bab77609867b5c66bad608dded47</Hash>
</Codenesium>*/