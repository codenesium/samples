import React, { Component, FormEvent } from 'react';
import axios from 'axios';
import { Constants, ApiRoutes, ClientRoutes } from '../../constants';
import * as Api from '../../api/models';
import ProductMapper from '../product/productMapper';
import ProductViewModel from '../product/productViewModel';
import { Form, Input, Button, Spin, Alert } from 'antd';
import { WrappedFormUtils } from 'antd/es/form/Form';
import ReactTable from 'react-table';

interface ProductTableComponentProps {
  productID: number;
  apiRoute: string;
  history: any;
  match: any;
}

interface ProductTableComponentState {
  loading: boolean;
  loaded: boolean;
  errorOccurred: boolean;
  errorMessage: string;
  filteredRecords: Array<ProductViewModel>;
}

export class ProductTableComponent extends React.Component<
  ProductTableComponentProps,
  ProductTableComponentState
> {
  state = {
    loading: false,
    loaded: true,
    errorOccurred: false,
    errorMessage: '',
    filteredRecords: [],
  };

  handleEditClick(e: any, row: ProductViewModel) {
    this.props.history.push(ClientRoutes.Products + '/edit/' + row.id);
  }

  handleDetailClick(e: any, row: ProductViewModel) {
    this.props.history.push(ClientRoutes.Products + '/' + row.id);
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
          let response = resp.data as Array<Api.ProductClientResponseModel>;

          console.log(response);

          let mapper = new ProductMapper();

          let products: Array<ProductViewModel> = [];

          response.forEach(x => {
            products.push(mapper.mapApiResponseToViewModel(x));
          });
          this.setState({
            ...this.state,
            filteredRecords: products,
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
    <Hash>b10934e26035f807881ab7038b97e534</Hash>
</Codenesium>*/