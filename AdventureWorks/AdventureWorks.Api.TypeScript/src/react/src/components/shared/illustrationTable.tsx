import React, { Component, FormEvent } from 'react';
import axios from 'axios';
import { Constants, ApiRoutes, ClientRoutes } from '../../constants';
import * as Api from '../../api/models';
import IllustrationMapper from '../illustration/illustrationMapper';
import IllustrationViewModel from '../illustration/illustrationViewModel';
import { Form, Input, Button, Spin, Alert } from 'antd';
import { WrappedFormUtils } from 'antd/es/form/Form';
import ReactTable from 'react-table';

interface IllustrationTableComponentProps {
  illustrationID: number;
  apiRoute: string;
  history: any;
  match: any;
}

interface IllustrationTableComponentState {
  loading: boolean;
  loaded: boolean;
  errorOccurred: boolean;
  errorMessage: string;
  filteredRecords: Array<IllustrationViewModel>;
}

export class IllustrationTableComponent extends React.Component<
  IllustrationTableComponentProps,
  IllustrationTableComponentState
> {
  state = {
    loading: false,
    loaded: true,
    errorOccurred: false,
    errorMessage: '',
    filteredRecords: [],
  };

  handleEditClick(e: any, row: IllustrationViewModel) {
    this.props.history.push(ClientRoutes.Illustrations + '/edit/' + row.id);
  }

  handleDetailClick(e: any, row: IllustrationViewModel) {
    this.props.history.push(ClientRoutes.Illustrations + '/' + row.id);
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
            Api.IllustrationClientResponseModel
          >;

          console.log(response);

          let mapper = new IllustrationMapper();

          let illustrations: Array<IllustrationViewModel> = [];

          response.forEach(x => {
            illustrations.push(mapper.mapApiResponseToViewModel(x));
          });
          this.setState({
            ...this.state,
            filteredRecords: illustrations,
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
                Header: 'Illustrations',
                columns: [
                  {
                    Header: 'Diagram',
                    accessor: 'diagram',
                    Cell: props => {
                      return <span>{String(props.original.diagram)}</span>;
                    },
                  },
                  {
                    Header: 'IllustrationID',
                    accessor: 'illustrationID',
                    Cell: props => {
                      return (
                        <span>{String(props.original.illustrationID)}</span>
                      );
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
                    Header: 'Actions',
                    Cell: row => (
                      <div>
                        <Button
                          type="primary"
                          onClick={(e: any) => {
                            this.handleDetailClick(
                              e,
                              row.original as IllustrationViewModel
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
                              row.original as IllustrationViewModel
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
    <Hash>8e52c7a027801f7de50f2c6d1984f95e</Hash>
</Codenesium>*/