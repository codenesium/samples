import React, { Component, FormEvent } from 'react';
import axios, { AxiosError, AxiosResponse } from 'axios';
import { Constants, ApiRoutes, ClientRoutes } from '../../constants';
import * as Api from '../../api/models';
import PipelineStepStepRequirementMapper from '../pipelineStepStepRequirement/pipelineStepStepRequirementMapper';
import PipelineStepStepRequirementViewModel from '../pipelineStepStepRequirement/pipelineStepStepRequirementViewModel';
import { Form, Input, Button, Spin, Alert } from 'antd';
import { WrappedFormUtils } from 'antd/es/form/Form';
import ReactTable from 'react-table';
import * as GlobalUtilities from '../../lib/globalUtilities';

interface PipelineStepStepRequirementTableComponentProps {
  apiRoute: string;
  history: any;
  match: any;
}

interface PipelineStepStepRequirementTableComponentState {
  loading: boolean;
  loaded: boolean;
  errorOccurred: boolean;
  errorMessage: string;
  filteredRecords: Array<PipelineStepStepRequirementViewModel>;
}

export class PipelineStepStepRequirementTableComponent extends React.Component<
  PipelineStepStepRequirementTableComponentProps,
  PipelineStepStepRequirementTableComponentState
> {
  state = {
    loading: false,
    loaded: true,
    errorOccurred: false,
    errorMessage: '',
    filteredRecords: [],
  };

  handleEditClick(e: any, row: PipelineStepStepRequirementViewModel) {
    this.props.history.push(
      ClientRoutes.PipelineStepStepRequirements + '/edit/' + row.id
    );
  }

  handleDetailClick(e: any, row: PipelineStepStepRequirementViewModel) {
    this.props.history.push(
      ClientRoutes.PipelineStepStepRequirements + '/' + row.id
    );
  }

  componentDidMount() {
    this.loadRecords();
  }

  loadRecords() {
    this.setState({ ...this.state, loading: true });

    axios
      .get<Array<Api.PipelineStepStepRequirementClientResponseModel>>(
        this.props.apiRoute,
        {
          headers: GlobalUtilities.defaultHeaders(),
        }
      )
      .then(response => {
        GlobalUtilities.logInfo(response);

        let mapper = new PipelineStepStepRequirementMapper();

        let pipelineStepStepRequirements: Array<
          PipelineStepStepRequirementViewModel
        > = [];

        response.data.forEach(x => {
          pipelineStepStepRequirements.push(
            mapper.mapApiResponseToViewModel(x)
          );
        });

        this.setState({
          ...this.state,
          filteredRecords: pipelineStepStepRequirements,
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
                Header: 'PipelineStepStepRequirements',
                columns: [
                  {
                    Header: 'Details',
                    accessor: 'details',
                    Cell: props => {
                      return <span>{String(props.original.details)}</span>;
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
                    Header: 'Requirement Met',
                    accessor: 'requirementMet',
                    Cell: props => {
                      return (
                        <span>{String(props.original.requirementMet)}</span>
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
                              row.original as PipelineStepStepRequirementViewModel
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
                              row.original as PipelineStepStepRequirementViewModel
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
    <Hash>64679798732f7df3a2c892f7cb1d6d97</Hash>
</Codenesium>*/