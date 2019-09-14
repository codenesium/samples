import React, { Component, ReactElement, ReactHTMLElement } from 'react';
import axios, { AxiosError, AxiosResponse } from 'axios';
import { Redirect } from 'react-router-dom';
import * as Api from '../../api/models';
import PetMapper from './petMapper';
import { Constants, ApiRoutes, ClientRoutes } from '../../constants';
import ReactTable from 'react-table';
import PetViewModel from './petViewModel';
import 'react-table/react-table.css';
import { Form, Button, Input, Row, Col, Alert, Spin } from 'antd';
import { WrappedFormUtils } from 'antd/es/form/Form';
import * as GlobalUtilities from '../../lib/globalUtilities';

interface PetSearchComponentProps {
  form: WrappedFormUtils;
  history: any;
  match: any;
}

interface PetSearchComponentState {
  records: Array<PetViewModel>;
  filteredRecords: Array<PetViewModel>;
  loading: boolean;
  loaded: boolean;
  errorOccurred: boolean;
  errorMessage: string;
  searchValue: string;
  deleteSubmitted: boolean;
  deleteSuccess: boolean;
  deleteResponse: string;
}

export default class PetSearchComponent extends React.Component<
  PetSearchComponentProps,
  PetSearchComponentState
> {
  state = {
    deleteSubmitted: false,
    deleteSuccess: false,
    deleteResponse: '',
    records: new Array<PetViewModel>(),
    filteredRecords: new Array<PetViewModel>(),
    searchValue: '',
    loading: false,
    loaded: true,
    errorOccurred: false,
    errorMessage: '',
  };

  componentDidMount() {
    this.loadRecords();
  }

  handleEditClick(e: any, row: PetViewModel) {
    this.props.history.push(ClientRoutes.Pets + '/edit/' + row.id);
  }

  handleDetailClick(e: any, row: PetViewModel) {
    this.props.history.push(ClientRoutes.Pets + '/' + row.id);
  }

  handleCreateClick(e: any) {
    this.props.history.push(ClientRoutes.Pets + '/create');
  }

  handleDeleteClick(e: any, row: Api.PetClientResponseModel) {
    axios
      .delete(Constants.ApiEndpoint + ApiRoutes.Pets + '/' + row.id, {
        headers: GlobalUtilities.defaultHeaders(),
      })
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
    let searchEndpoint = Constants.ApiEndpoint + ApiRoutes.Pets + '?limit=100';

    if (query) {
      searchEndpoint += '&query=' + query;
    }

    axios
      .get<Array<Api.PetClientResponseModel>>(searchEndpoint, {
        headers: GlobalUtilities.defaultHeaders(),
      })
      .then(response => {
        let viewModels: Array<PetViewModel> = [];
        let mapper = new PetMapper();

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
          records: new Array<PetViewModel>(),
          filteredRecords: new Array<PetViewModel>(),
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
                Header: 'Pet',
                columns: [
                  {
                    Header: 'Breed',
                    accessor: 'breedId',
                    Cell: props => {
                      return (
                        <a
                          href=""
                          onClick={e => {
                            e.preventDefault();
                            this.props.history.push(
                              ClientRoutes.Breeds + '/' + props.original.breedId
                            );
                          }}
                        >
                          {String(
                            props.original.breedIdNavigation &&
                              props.original.breedIdNavigation.toDisplay()
                          )}
                        </a>
                      );
                    },
                  },
                  {
                    Header: 'Client',
                    accessor: 'clientId',
                    Cell: props => {
                      return <span>{String(props.original.clientId)}</span>;
                    },
                  },
                  {
                    Header: 'Name',
                    accessor: 'name',
                    Cell: props => {
                      return <span>{String(props.original.name)}</span>;
                    },
                  },
                  {
                    Header: 'Weight',
                    accessor: 'weight',
                    Cell: props => {
                      return <span>{String(props.original.weight)}</span>;
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
                              row.original as PetViewModel
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
                              row.original as PetViewModel
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
                              row.original as PetViewModel
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

export const WrappedPetSearchComponent = Form.create({ name: 'Pet Search' })(
  PetSearchComponent
);


/*<Codenesium>
    <Hash>953b3b38eccd091f57a963e2b0bdbb5e</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/