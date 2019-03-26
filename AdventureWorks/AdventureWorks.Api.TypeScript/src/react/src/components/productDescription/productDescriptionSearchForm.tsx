import React, { Component, ReactElement, ReactHTMLElement } from 'react';
import axios, { AxiosError, AxiosResponse } from 'axios';
import { Redirect } from 'react-router-dom';
import * as Api from '../../api/models';
import ProductDescriptionMapper from './productDescriptionMapper';
import { Constants, ApiRoutes, ClientRoutes } from '../../constants';
import ReactTable from 'react-table';
import ProductDescriptionViewModel from './productDescriptionViewModel';
import 'react-table/react-table.css';
import { Form, Button, Input, Row, Col, Alert, Spin } from 'antd';
import { WrappedFormUtils } from 'antd/es/form/Form';
import * as GlobalUtilities from '../../lib/globalUtilities';

interface ProductDescriptionSearchComponentProps {
  form: WrappedFormUtils;
  history: any;
  match: any;
}

interface ProductDescriptionSearchComponentState {
  records: Array<ProductDescriptionViewModel>;
  filteredRecords: Array<ProductDescriptionViewModel>;
  loading: boolean;
  loaded: boolean;
  errorOccurred: boolean;
  errorMessage: string;
  searchValue: string;
  deleteSubmitted: boolean;
  deleteSuccess: boolean;
  deleteResponse: string;
}

export default class ProductDescriptionSearchComponent extends React.Component<
  ProductDescriptionSearchComponentProps,
  ProductDescriptionSearchComponentState
> {
  state = {
    deleteSubmitted: false,
    deleteSuccess: false,
    deleteResponse: '',
    records: new Array<ProductDescriptionViewModel>(),
    filteredRecords: new Array<ProductDescriptionViewModel>(),
    searchValue: '',
    loading: false,
    loaded: true,
    errorOccurred: false,
    errorMessage: '',
  };

  componentDidMount() {
    this.loadRecords();
  }

  handleEditClick(e: any, row: ProductDescriptionViewModel) {
    this.props.history.push(
      ClientRoutes.ProductDescriptions + '/edit/' + row.productDescriptionID
    );
  }

  handleDetailClick(e: any, row: ProductDescriptionViewModel) {
    this.props.history.push(
      ClientRoutes.ProductDescriptions + '/' + row.productDescriptionID
    );
  }

  handleCreateClick(e: any) {
    this.props.history.push(ClientRoutes.ProductDescriptions + '/create');
  }

  handleDeleteClick(e: any, row: Api.ProductDescriptionClientResponseModel) {
    axios
      .delete(
        Constants.ApiEndpoint +
          ApiRoutes.ProductDescriptions +
          '/' +
          row.productDescriptionID,
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
      Constants.ApiEndpoint + ApiRoutes.ProductDescriptions + '?limit=100';

    if (query) {
      searchEndpoint += '&query=' + query;
    }

    axios
      .get<Array<Api.ProductDescriptionClientResponseModel>>(searchEndpoint, {
        headers: GlobalUtilities.defaultHeaders(),
      })
      .then(response => {
        let viewModels: Array<ProductDescriptionViewModel> = [];
        let mapper = new ProductDescriptionMapper();

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
          records: new Array<ProductDescriptionViewModel>(),
          filteredRecords: new Array<ProductDescriptionViewModel>(),
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
                Header: 'Product Description',
                columns: [
                  {
                    Header: 'Description',
                    accessor: 'description',
                    Cell: props => {
                      return <span>{String(props.original.description)}</span>;
                    },
                  },
                  {
                    Header: 'Modified Date',
                    accessor: 'modifiedDate',
                    Cell: props => {
                      return <span>{String(props.original.modifiedDate)}</span>;
                    },
                  },
                  {
                    Header: 'Rowguid',
                    accessor: 'rowguid',
                    Cell: props => {
                      return <span>{String(props.original.rowguid)}</span>;
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
                              row.original as ProductDescriptionViewModel
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
                              row.original as ProductDescriptionViewModel
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
                              row.original as ProductDescriptionViewModel
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

export const WrappedProductDescriptionSearchComponent = Form.create({
  name: 'ProductDescription Search',
})(ProductDescriptionSearchComponent);


/*<Codenesium>
    <Hash>e74e3fd3a3de1137249bc940d9c5acf7</Hash>
</Codenesium>*/