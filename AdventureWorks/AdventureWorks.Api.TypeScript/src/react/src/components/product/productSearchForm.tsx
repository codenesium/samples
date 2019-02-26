import React, { Component, ReactElement, ReactHTMLElement } from 'react';
import axios from 'axios';
import { Redirect } from 'react-router-dom';
import * as Api from '../../api/models';
import ProductMapper from './productMapper';
import { Constants, ApiRoutes, ClientRoutes } from '../../constants';
import ReactTable from 'react-table';
import ProductViewModel from './productViewModel';
import 'react-table/react-table.css';
import { Form, Button, Input, Row, Col, Alert, Spin } from 'antd';
import { WrappedFormUtils } from 'antd/es/form/Form';

interface ProductSearchComponentProps {
  form: WrappedFormUtils;
  history: any;
  match: any;
}

interface ProductSearchComponentState {
  records: Array<ProductViewModel>;
  filteredRecords: Array<ProductViewModel>;
  loading: boolean;
  loaded: boolean;
  errorOccurred: boolean;
  errorMessage: string;
  searchValue: string;
  deleteSubmitted: boolean;
  deleteSuccess: boolean;
  deleteResponse: string;
}

export default class ProductSearchComponent extends React.Component<
  ProductSearchComponentProps,
  ProductSearchComponentState
> {
  state = {
    deleteSubmitted: false,
    deleteSuccess: false,
    deleteResponse: '',
    records: new Array<ProductViewModel>(),
    filteredRecords: new Array<ProductViewModel>(),
    searchValue: '',
    loading: false,
    loaded: true,
    errorOccurred: false,
    errorMessage: '',
  };

  componentDidMount() {
    this.loadRecords();
  }

  handleEditClick(e: any, row: ProductViewModel) {
    this.props.history.push(ClientRoutes.Products + '/edit/' + row.productID);
  }

  handleDetailClick(e: any, row: ProductViewModel) {
    this.props.history.push(ClientRoutes.Products + '/' + row.productID);
  }

  handleCreateClick(e: any) {
    this.props.history.push(ClientRoutes.Products + '/create');
  }

  handleDeleteClick(e: any, row: Api.ProductClientResponseModel) {
    axios
      .delete(
        Constants.ApiEndpoint + ApiRoutes.Products + '/' + row.productID,
        {
          headers: {
            'Content-Type': 'application/json',
          },
        }
      )
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
    let searchEndpoint =
      Constants.ApiEndpoint + ApiRoutes.Products + '?limit=100';

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
          let response = resp.data as Array<Api.ProductClientResponseModel>;
          let viewModels: Array<ProductViewModel> = [];
          let mapper = new ProductMapper();

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
            records: new Array<ProductViewModel>(),
            filteredRecords: new Array<ProductViewModel>(),
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
                Header: 'Products',
                columns: [
                  {
                    Header: 'Color',
                    accessor: 'color',
                    Cell: props => {
                      return <span>{String(props.original.color)}</span>;
                    },
                  },
                  {
                    Header: 'DaysToManufacture',
                    accessor: 'daysToManufacture',
                    Cell: props => {
                      return (
                        <span>{String(props.original.daysToManufacture)}</span>
                      );
                    },
                  },
                  {
                    Header: 'DiscontinuedDate',
                    accessor: 'discontinuedDate',
                    Cell: props => {
                      return (
                        <span>{String(props.original.discontinuedDate)}</span>
                      );
                    },
                  },
                  {
                    Header: 'FinishedGoodsFlag',
                    accessor: 'finishedGoodsFlag',
                    Cell: props => {
                      return (
                        <span>{String(props.original.finishedGoodsFlag)}</span>
                      );
                    },
                  },
                  {
                    Header: 'ListPrice',
                    accessor: 'listPrice',
                    Cell: props => {
                      return <span>{String(props.original.listPrice)}</span>;
                    },
                  },
                  {
                    Header: 'MakeFlag',
                    accessor: 'makeFlag',
                    Cell: props => {
                      return <span>{String(props.original.makeFlag)}</span>;
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
                    Header: 'Name',
                    accessor: 'name',
                    Cell: props => {
                      return <span>{String(props.original.name)}</span>;
                    },
                  },
                  {
                    Header: 'ProductID',
                    accessor: 'productID',
                    Cell: props => {
                      return <span>{String(props.original.productID)}</span>;
                    },
                  },
                  {
                    Header: 'ProductLine',
                    accessor: 'productLine',
                    Cell: props => {
                      return <span>{String(props.original.productLine)}</span>;
                    },
                  },
                  {
                    Header: 'ProductModelID',
                    accessor: 'productModelID',
                    Cell: props => {
                      return (
                        <a
                          href=""
                          onClick={e => {
                            e.preventDefault();
                            this.props.history.push(
                              ClientRoutes.ProductModels +
                                '/' +
                                props.original.productModelID
                            );
                          }}
                        >
                          {String(
                            props.original.productModelIDNavigation.toDisplay()
                          )}
                        </a>
                      );
                    },
                  },
                  {
                    Header: 'ProductNumber',
                    accessor: 'productNumber',
                    Cell: props => {
                      return (
                        <span>{String(props.original.productNumber)}</span>
                      );
                    },
                  },
                  {
                    Header: 'ProductSubcategoryID',
                    accessor: 'productSubcategoryID',
                    Cell: props => {
                      return (
                        <a
                          href=""
                          onClick={e => {
                            e.preventDefault();
                            this.props.history.push(
                              ClientRoutes.ProductSubcategories +
                                '/' +
                                props.original.productSubcategoryID
                            );
                          }}
                        >
                          {String(
                            props.original.productSubcategoryIDNavigation.toDisplay()
                          )}
                        </a>
                      );
                    },
                  },
                  {
                    Header: 'ReorderPoint',
                    accessor: 'reorderPoint',
                    Cell: props => {
                      return <span>{String(props.original.reorderPoint)}</span>;
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
                    Header: 'SafetyStockLevel',
                    accessor: 'safetyStockLevel',
                    Cell: props => {
                      return (
                        <span>{String(props.original.safetyStockLevel)}</span>
                      );
                    },
                  },
                  {
                    Header: 'SellEndDate',
                    accessor: 'sellEndDate',
                    Cell: props => {
                      return <span>{String(props.original.sellEndDate)}</span>;
                    },
                  },
                  {
                    Header: 'SellStartDate',
                    accessor: 'sellStartDate',
                    Cell: props => {
                      return (
                        <span>{String(props.original.sellStartDate)}</span>
                      );
                    },
                  },
                  {
                    Header: 'Size',
                    accessor: 'size',
                    Cell: props => {
                      return <span>{String(props.original.size)}</span>;
                    },
                  },
                  {
                    Header: 'SizeUnitMeasureCode',
                    accessor: 'sizeUnitMeasureCode',
                    Cell: props => {
                      return (
                        <a
                          href=""
                          onClick={e => {
                            e.preventDefault();
                            this.props.history.push(
                              ClientRoutes.UnitMeasures +
                                '/' +
                                props.original.sizeUnitMeasureCode
                            );
                          }}
                        >
                          {String(
                            props.original.sizeUnitMeasureCodeNavigation.toDisplay()
                          )}
                        </a>
                      );
                    },
                  },
                  {
                    Header: 'StandardCost',
                    accessor: 'standardCost',
                    Cell: props => {
                      return <span>{String(props.original.standardCost)}</span>;
                    },
                  },
                  {
                    Header: 'Style',
                    accessor: 'style',
                    Cell: props => {
                      return <span>{String(props.original.style)}</span>;
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
                    Header: 'WeightUnitMeasureCode',
                    accessor: 'weightUnitMeasureCode',
                    Cell: props => {
                      return (
                        <a
                          href=""
                          onClick={e => {
                            e.preventDefault();
                            this.props.history.push(
                              ClientRoutes.UnitMeasures +
                                '/' +
                                props.original.weightUnitMeasureCode
                            );
                          }}
                        >
                          {String(
                            props.original.weightUnitMeasureCodeNavigation.toDisplay()
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
                              row.original as ProductViewModel
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
                              row.original as ProductViewModel
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
                              row.original as ProductViewModel
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

export const WrappedProductSearchComponent = Form.create({
  name: 'Product Search',
})(ProductSearchComponent);


/*<Codenesium>
    <Hash>e07fe089a872337297f742d017e50750</Hash>
</Codenesium>*/