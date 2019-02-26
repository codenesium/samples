import React, { Component, FormEvent } from 'react';
import axios from 'axios';
import { Constants, ApiRoutes, ClientRoutes } from '../../constants';
import * as Api from '../../api/models';
import CallPersonMapper from '../callPerson/callPersonMapper';
import CallPersonViewModel from '../callPerson/callPersonViewModel';
import { Form, Input, Button, Spin, Alert } from 'antd';
import { WrappedFormUtils } from 'antd/es/form/Form';
import ReactTable from 'react-table';

interface CallPersonTableComponentProps {
  id: number;
  apiRoute: string;
  history: any;
  match: any;
}

interface CallPersonTableComponentState {
  loading: boolean;
  loaded: boolean;
  errorOccurred: boolean;
  errorMessage: string;
  filteredRecords: Array<CallPersonViewModel>;
}

export class CallPersonTableComponent extends React.Component<
  CallPersonTableComponentProps,
  CallPersonTableComponentState
> {
  state = {
    loading: false,
    loaded: true,
    errorOccurred: false,
    errorMessage: '',
    filteredRecords: [],
  };

  handleEditClick(e: any, row: CallPersonViewModel) {
    this.props.history.push(ClientRoutes.CallPersons + '/edit/' + row.id);
  }

  handleDetailClick(e: any, row: CallPersonViewModel) {
    this.props.history.push(ClientRoutes.CallPersons + '/' + row.id);
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
          let response = resp.data as Array<Api.CallPersonClientResponseModel>;

          console.log(response);

          let mapper = new CallPersonMapper();

          let callPersons: Array<CallPersonViewModel> = [];

          response.forEach(x => {
            callPersons.push(mapper.mapApiResponseToViewModel(x));
          });
          this.setState({
            ...this.state,
            filteredRecords: callPersons,
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
                Header: 'CallPersons',
                columns: [
                  {
                    Header: 'Note',
                    accessor: 'note',
                    Cell: props => {
                      return <span>{String(props.original.note)}</span>;
                    },
                  },
                  {
                    Header: 'PersonId',
                    accessor: 'personId',
                    Cell: props => {
                      return (
                        <a
                          href=""
                          onClick={e => {
                            e.preventDefault();
                            this.props.history.push(
                              ClientRoutes.People +
                                '/' +
                                props.original.personId
                            );
                          }}
                        >
                          {String(
                            props.original.personIdNavigation.toDisplay()
                          )}
                        </a>
                      );
                    },
                  },
                  {
                    Header: 'PersonTypeId',
                    accessor: 'personTypeId',
                    Cell: props => {
                      return (
                        <a
                          href=""
                          onClick={e => {
                            e.preventDefault();
                            this.props.history.push(
                              ClientRoutes.PersonTypes +
                                '/' +
                                props.original.personTypeId
                            );
                          }}
                        >
                          {String(
                            props.original.personTypeIdNavigation.toDisplay()
                          )}
                        </a>
                      );
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
                              row.original as CallPersonViewModel
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
                              row.original as CallPersonViewModel
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
    <Hash>bb7ceb7234f7577f6a0eccf1721059d1</Hash>
</Codenesium>*/