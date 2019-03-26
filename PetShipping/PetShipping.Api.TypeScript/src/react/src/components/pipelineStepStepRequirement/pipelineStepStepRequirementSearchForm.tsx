import React, { Component, ReactElement, ReactHTMLElement } from 'react';
import axios, { AxiosError, AxiosResponse } from 'axios';
import { Redirect } from 'react-router-dom';
import * as Api from '../../api/models';
import PipelineStepStepRequirementMapper from './pipelineStepStepRequirementMapper';
import { Constants, ApiRoutes, ClientRoutes } from '../../constants';
import ReactTable from 'react-table';
import PipelineStepStepRequirementViewModel from './pipelineStepStepRequirementViewModel';
import 'react-table/react-table.css';
import { Form, Button, Input, Row, Col, Alert, Spin } from 'antd';
import { WrappedFormUtils } from 'antd/es/form/Form';
import * as GlobalUtilities from '../../lib/globalUtilities';

interface PipelineStepStepRequirementSearchComponentProps {
  form: WrappedFormUtils;
  history: any;
  match: any;
}

interface PipelineStepStepRequirementSearchComponentState {
  records: Array<PipelineStepStepRequirementViewModel>;
  filteredRecords: Array<PipelineStepStepRequirementViewModel>;
  loading: boolean;
  loaded: boolean;
  errorOccurred: boolean;
  errorMessage: string;
  searchValue: string;
  deleteSubmitted: boolean;
  deleteSuccess: boolean;
  deleteResponse: string;
}

export default class PipelineStepStepRequirementSearchComponent extends React.Component<
  PipelineStepStepRequirementSearchComponentProps,
  PipelineStepStepRequirementSearchComponentState
> {
  state = {
    deleteSubmitted: false,
    deleteSuccess: false,
    deleteResponse: '',
    records: new Array<PipelineStepStepRequirementViewModel>(),
    filteredRecords: new Array<PipelineStepStepRequirementViewModel>(),
    searchValue: '',
    loading: false,
    loaded: true,
    errorOccurred: false,
    errorMessage: '',
  };

  componentDidMount() {
    this.loadRecords();
  }

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

  handleCreateClick(e: any) {
    this.props.history.push(
      ClientRoutes.PipelineStepStepRequirements + '/create'
    );
  }

  handleDeleteClick(
    e: any,
    row: Api.PipelineStepStepRequirementClientResponseModel
  ) {
    axios
      .delete(
        Constants.ApiEndpoint +
          ApiRoutes.PipelineStepStepRequirements +
          '/' +
          row.id,
        {
          headers: GlobalUtilities.defaultHeaders(),
        }
      )
      .then(resp => {
        this.setState({
          ...this.state,
          deleteResponse: 'Record deleted',
          deleteSuccess: true,
          deleteSubmitted: true,
        });
        this.loadRecords(this.state.searchValue);
      })
      .catch((error: AxiosError) => {
        GlobalUtilities.logError(error);
        this.setState({
          ...this.state,
          deleteResponse: 'Error deleting record',
          deleteSuccess: false,
          deleteSubmitted: true,
        });
      });
  }

  handleSearchChanged(e: React.FormEvent<HTMLInputElement>) {
    this.loadRecords(e.currentTarget.value);
  }

  loadRecords(query: string = '') {
    this.setState({ ...this.state, searchValue: query });
    let searchEndpoint =
      Constants.ApiEndpoint +
      ApiRoutes.PipelineStepStepRequirements +
      '?limit=100';

    if (query) {
      searchEndpoint += '&query=' + query;
    }

    axios
      .get<Array<Api.PipelineStepStepRequirementClientResponseModel>>(
        searchEndpoint,
        {
          headers: GlobalUtilities.defaultHeaders(),
        }
      )
      .then(response => {
        let viewModels: Array<PipelineStepStepRequirementViewModel> = [];
        let mapper = new PipelineStepStepRequirementMapper();

        response.data.forEach(x => {
          viewModels.push(mapper.mapApiResponseToViewModel(x));
        });

        this.setState({
          records: viewModels,
          filteredRecords: viewModels,
          loading: false,
          loaded: true,
          errorOccurred: false,
          errorMessage: '',
        });
      })
      .catch((error: AxiosError) => {
        GlobalUtilities.logError(error);
        this.setState({
          records: new Array<PipelineStepStepRequirementViewModel>(),
          filteredRecords: new Array<PipelineStepStepRequirementViewModel>(),
          loading: false,
          loaded: true,
          errorOccurred: true,
          errorMessage: 'Error from API',
        });
      });
  }

  filterGrid() {}

  render() {
    if (this.state.loading) {
      return <Spin size="large" />;
    } else if (this.state.errorOccurred) {
      return <Alert message={this.state.errorMessage} type="error" />;
    } else if (this.state.loaded) {
      let errorResponse: JSX.Element = <span />;

      if (this.state.deleteSubmitted) {
        if (this.state.deleteSuccess) {
          errorResponse = (
            <Alert
              message={this.state.deleteResponse}
              type="success"
              style={{ marginBottom: '25px' }}
            />
          );
        } else {
          errorResponse = (
            <Alert
              message={this.state.deleteResponse}
              type="error"
              style={{ marginBottom: '25px' }}
            />
          );
        }
      }

      return (
        <div>
          {errorResponse}
          <Row>
            <Col span={8} />
            <Col span={8}>
              <Input
                placeholder={'Search'}
                id={'search'}
                onChange={(e: any) => {
                  this.handleSearchChanged(e);
                }}
              />
            </Col>
            <Col span={8}>
              <Button
                style={{ float: 'right' }}
                type="primary"
                onClick={(e: any) => {
                  this.handleCreateClick(e);
                }}
              >
                +
              </Button>
            </Col>
          </Row>
          <br />
          <br />
          <ReactTable
            data={this.state.filteredRecords}
            columns={[
              {
                Header: 'PipelineStepStepRequirements',
                columns: [
                  {
                    Header: 'Details',
                    accessor: 'detail',
                    Cell: props => {
                      return <span>{String(props.original.detail)}</span>;
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
                            props.original.pipelineStepIdNavigation &&
                              props.original.pipelineStepIdNavigation.toDisplay()
                          )}
                        </a>
                      );
                    },
                  },
                  {
                    Header: 'RequirementMet',
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
                        &nbsp;
                        <Button
                          type="danger"
                          onClick={(e: any) => {
                            this.handleDeleteClick(
                              e,
                              row.original as PipelineStepStepRequirementViewModel
                            );
                          }}
                        >
                          <i className="far fa-trash-alt" />
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

export const WrappedPipelineStepStepRequirementSearchComponent = Form.create({
  name: 'PipelineStepStepRequirement Search',
})(PipelineStepStepRequirementSearchComponent);


/*<Codenesium>
    <Hash>6ca7881db058c9c88e99dee19dd9e650</Hash>
</Codenesium>*/