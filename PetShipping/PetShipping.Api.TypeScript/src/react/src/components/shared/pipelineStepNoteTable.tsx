import React, { Component, FormEvent } from 'react';
import axios, { AxiosError, AxiosResponse } from 'axios';
import { Constants, ApiRoutes, ClientRoutes } from '../../constants';
import * as Api from '../../api/models';
import PipelineStepNoteMapper from '../pipelineStepNote/pipelineStepNoteMapper';
import PipelineStepNoteViewModel from '../pipelineStepNote/pipelineStepNoteViewModel';
import { Form, Input, Button, Spin, Alert } from 'antd';
import { WrappedFormUtils } from 'antd/es/form/Form';
import ReactTable from 'react-table';
import * as GlobalUtilities from '../../lib/globalUtilities';

interface PipelineStepNoteTableComponentProps {
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
      .get<Array<Api.PipelineStepNoteClientResponseModel>>(
        this.props.apiRoute,
        {
          headers: GlobalUtilities.defaultHeaders(),
        }
      )
      .then(response => {
        GlobalUtilities.logInfo(response);

        let mapper = new PipelineStepNoteMapper();

        let pipelineStepNotes: Array<PipelineStepNoteViewModel> = [];

        response.data.forEach(x => {
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
                Header: 'PipelineStepNotes',
                columns: [
                  {
                    Header: 'Employee',
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
                            props.original.employeeIdNavigation &&
                              props.original.employeeIdNavigation.toDisplay()
                          )}
                        </a>
                      );
                    },
                  },
                  {
                    Header: 'Note',
                    accessor: 'note',
                    Cell: props => {
                      return <span>{String(props.original.note)}</span>;
                    },
                  },
                  {
                    Header: 'Pipeline Step',
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
                            props.original.pipelineStepIdNavigation &&
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
                          htmlType="button"
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
                          htmlType="button"
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
    <Hash>a53176e52ce3c5f0ac081e3ec90c4376</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/