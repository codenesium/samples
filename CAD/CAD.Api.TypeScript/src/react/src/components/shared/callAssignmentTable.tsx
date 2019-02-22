import React, { Component, FormEvent } from 'react';
import axios from 'axios';
import { Constants, ApiRoutes, ClientRoutes } from '../../constants';
import * as Api from '../../api/models';
import CallAssignmentMapper from '../callAssignment/callAssignmentMapper';
import CallAssignmentViewModel from '../callAssignment/callAssignmentViewModel';
import { Form, Input, Button, Spin, Alert } from 'antd';
import { WrappedFormUtils } from 'antd/es/form/Form';
import ReactTable from 'react-table';

interface CallAssignmentTableComponentProps {
  id: number;
  apiRoute: string;
  history: any;
  match: any;
}

interface CallAssignmentTableComponentState {
  loading: boolean;
  loaded: boolean;
  errorOccurred: boolean;
  errorMessage: string;
  filteredRecords: Array<CallAssignmentViewModel>;
}

export class CallAssignmentTableComponent extends React.Component<
  CallAssignmentTableComponentProps,
  CallAssignmentTableComponentState
> {
  state = {
    loading: false,
    loaded: true,
    errorOccurred: false,
    errorMessage: '',
    filteredRecords: [],
  };

  handleEditClick(e: any, row: CallAssignmentViewModel) {
    this.props.history.push(ClientRoutes.CallAssignments + '/edit/' + row.id);
  }

  handleDetailClick(e: any, row: CallAssignmentViewModel) {
    this.props.history.push(ClientRoutes.CallAssignments + '/' + row.id);
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
            Api.CallAssignmentClientResponseModel
          >;

          console.log(response);

          let mapper = new CallAssignmentMapper();

          let callAssignments: Array<CallAssignmentViewModel> = [];

          response.forEach(x => {
            callAssignments.push(mapper.mapApiResponseToViewModel(x));
          });
          this.setState({
            ...this.state,
            filteredRecords: callAssignments,
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
                Header: 'CallAssignments',
                columns: [
                  {
                    Header: 'CallId',
                    accessor: 'callId',
                    Cell: props => {
                      return (
                        <a
                          href=""
                          onClick={e => {
                            e.preventDefault();
                            this.props.history.push(
                              ClientRoutes.Calls + '/' + props.original.callId
                            );
                          }}
                        >
                          {String(props.original.callIdNavigation.toDisplay())}
                        </a>
                      );
                    },
                  },
                  {
                    Header: 'UnitId',
                    accessor: 'unitId',
                    Cell: props => {
                      return (
                        <a
                          href=""
                          onClick={e => {
                            e.preventDefault();
                            this.props.history.push(
                              ClientRoutes.Units + '/' + props.original.unitId
                            );
                          }}
                        >
                          {String(props.original.unitIdNavigation.toDisplay())}
                        </a>
                      );
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
                              row.original as CallAssignmentViewModel
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
                              row.original as CallAssignmentViewModel
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
    <Hash>d9cb21ce86922db2e95383a2e5ceb154</Hash>
</Codenesium>*/