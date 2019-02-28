import React, { Component, FormEvent } from 'react';
import axios from 'axios';
import { Constants, ApiRoutes, ClientRoutes } from '../../constants';
import * as Api from '../../api/models';
import PipelineStepNoteMapper from '../pipelineStepNote/pipelineStepNoteMapper';
import PipelineStepNoteViewModel from '../pipelineStepNote/pipelineStepNoteViewModel';
import { Form, Input, Button, Spin, Alert } from 'antd';
import { WrappedFormUtils } from 'antd/es/form/Form';
import ReactTable from 'react-table';

interface PipelineStepNoteTableComponentProps {
  id: number;
  apiRoute: string;
  history: any;
  match: any;
}

interface PipelineStepNoteTableComponentState {
  loading: boolean;
  loaded: boolean;
  errorOccurred: boolean;
  errorMessage: string;
  filteredRecords: Array<PipelineStepNoteViewModel>;
}

export class PipelineStepNoteTableComponent extends React.Component<
  PipelineStepNoteTableComponentProps,
  PipelineStepNoteTableComponentState
> {
  state = {
    loading: false,
    loaded: true,
    errorOccurred: false,
    errorMessage: '',
    filteredRecords: [],
  };

  handleEditClick(e: any, row: PipelineStepNoteViewModel) {
    this.props.history.push(ClientRoutes.PipelineStepNotes + '/edit/' + row.id);
  }

  handleDetailClick(e: any, row: PipelineStepNoteViewModel) {
    this.props.history.push(ClientRoutes.PipelineStepNotes + '/' + row.id);
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
            Api.PipelineStepNoteClientResponseModel
          >;

          console.log(response);

          let mapper = new PipelineStepNoteMapper();

          let pipelineStepNotes: Array<PipelineStepNoteViewModel> = [];

          response.forEach(x => {
            pipelineStepNotes.push(mapper.mapApiResponseToViewModel(x));
          });
          this.setState({
            ...this.state,
            filteredRecords: pipelineStepNotes,
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
                Header: 'PipelineStepNotes',
                columns: [
                  {
                    Header: 'EmployeeId',
                    accessor: 'employeeId',
                    Cell: props => {
                      return (
                        <a
                          href=""
                          onClick={e => {
                            e.preventDefault();
                            this.props.history.push(
                              ClientRoutes.Employees +
                                '/' +
                                props.original.employeeId
                            );
                          }}
                        >
                          {String(
                            props.original.employeeIdNavigation.toDisplay()
                          )}
                        </a>
                      );
                    },
                  },
                  {
                    Header: 'PipelineStepId',
                    accessor: 'pipelineStepId',
                    Cell: props => {
                      return (
                        <a
                          href=""
                          onClick={e => {
                            e.preventDefault();
                            this.props.history.push(
                              ClientRoutes.PipelineSteps +
                                '/' +
                                props.original.pipelineStepId
                            );
                          }}
                        >
                          {String(
                            props.original.pipelineStepIdNavigation.toDisplay()
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
                              row.original as PipelineStepNoteViewModel
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
                              row.original as PipelineStepNoteViewModel
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
    <Hash>d099fd5598e459caaea305bddd86d613</Hash>
</Codenesium>*/