import React, { Component, ReactElement, ReactHTMLElement } from 'react';
import axios from 'axios';
import { Redirect } from 'react-router-dom';
import * as Api from '../../api/models';
import PenMapper from './penMapper';
import { Constants, ApiRoutes, ClientRoutes } from '../../constants';
import ReactTable from 'react-table';
import PenViewModel from './penViewModel';
import 'react-table/react-table.css';
import { Form, Button, Input, Row, Col, Alert, Spin } from 'antd';
import { WrappedFormUtils } from 'antd/es/form/Form';

interface PenSearchComponentProps {
  form: WrappedFormUtils;
  history: any;
  match: any;
}

interface PenSearchComponentState {
  records: Array<PenViewModel>;
  filteredRecords: Array<PenViewModel>;
  loading: boolean;
  loaded: boolean;
  errorOccurred: boolean;
  errorMessage: string;
  searchValue: string;
  deleteSubmitted: boolean;
  deleteSuccess: boolean;
  deleteResponse: string;
}

export default class PenSearchComponent extends React.Component<
  PenSearchComponentProps,
  PenSearchComponentState
> {
  state = {
    deleteSubmitted: false,
    deleteSuccess: false,
    deleteResponse: '',
    records: new Array<PenViewModel>(),
    filteredRecords: new Array<PenViewModel>(),
    searchValue: '',
    loading: false,
    loaded: true,
    errorOccurred: false,
    errorMessage: '',
  };

  componentDidMount() {
    this.loadRecords();
  }

  handleEditClick(e: any, row: PenViewModel) {
    this.props.history.push(ClientRoutes.Pens + '/edit/' + row.id);
  }

  handleDetailClick(e: any, row: PenViewModel) {
    this.props.history.push(ClientRoutes.Pens + '/' + row.id);
  }

  handleCreateClick(e: any) {
    this.props.history.push(ClientRoutes.Pens + '/create');
  }

  handleDeleteClick(e: any, row: Api.PenClientResponseModel) {
    axios
      .delete(Constants.ApiEndpoint + ApiRoutes.Pens + '/' + row.id, {
        headers: {
          'Content-Type': 'application/json',
        },
      })
      .then(
        resp => {
          this.setState({
            ...this.state,
            deleteResponse: 'Record deleted',
            deleteSuccess: true,
            deleteSubmitted: true,
          });
          this.loadRecords(this.state.searchValue);
        },
        error => {
          console.log(error);
          this.setState({
            ...this.state,
            deleteResponse: 'Error deleting record',
            deleteSuccess: false,
            deleteSubmitted: true,
          });
        }
      );
  }

  handleSearchChanged(e: React.FormEvent<HTMLInputElement>) {
    this.loadRecords(e.currentTarget.value);
  }

  loadRecords(query: string = '') {
    this.setState({ ...this.state, searchValue: query });
    let searchEndpoint = Constants.ApiEndpoint + ApiRoutes.Pens + '?limit=100';

    if (query) {
      searchEndpoint += '&query=' + query;
    }

    axios
      .get(searchEndpoint, {
        headers: {
          'Content-Type': 'application/json',
        },
      })
      .then(
        resp => {
          let response = resp.data as Array<Api.PenClientResponseModel>;
          let viewModels: Array<PenViewModel> = [];
          let mapper = new PenMapper();

          response.forEach(x => {
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
        },
        error => {
          console.log(error);
          this.setState({
            records: new Array<PenViewModel>(),
            filteredRecords: new Array<PenViewModel>(),
            loading: false,
            loaded: true,
            errorOccurred: true,
            errorMessage: 'Error from API',
          });
        }
      );
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
                Header: 'Pens',
                columns: [
                  {
                    Header: 'Name',
                    accessor: 'name',
                    Cell: props => {
                      return <span>{String(props.original.name)}</span>;
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
                              row.original as PenViewModel
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
                              row.original as PenViewModel
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
                              row.original as PenViewModel
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

export const WrappedPenSearchComponent = Form.create({ name: 'Pen Search' })(
  PenSearchComponent
);


/*<Codenesium>
    <Hash>aa31bf245dcd73ac6ffd906d1f09ab2c</Hash>
</Codenesium>*/