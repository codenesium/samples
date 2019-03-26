import React, { Component, FormEvent } from 'react';
import axios, { AxiosError, AxiosResponse } from 'axios';
import { Constants, ApiRoutes, ClientRoutes } from '../../constants';
import * as Api from '../../api/models';
import ProductMapper from '../product/productMapper';
import ProductViewModel from '../product/productViewModel';
import { Form, Input, Button, Spin, Alert } from 'antd';
import { WrappedFormUtils } from 'antd/es/form/Form';
import ReactTable from 'react-table';
import * as GlobalUtilities from '../../lib/globalUtilities';

interface ProductTableComponentProps {
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
    this.props.history.push(ClientRoutes.Products + '/edit/' + row.productID);
  }

  handleDetailClick(e: any, row: ProductViewModel) {
    this.props.history.push(ClientRoutes.Products + '/' + row.productID);
  }

  componentDidMount() {
    this.loadRecords();
  }

  loadRecords() {
    this.setState({ ...this.state, loading: true });

    axios
      .get<Array<Api.ProductClientResponseModel>>(this.props.apiRoute, {
        headers: GlobalUtilities.defaultHeaders(),
      })
      .then(response => {
        GlobalUtilities.logInfo(response);

        let mapper = new ProductMapper();

        let products: Array<ProductViewModel> = [];

        response.data.forEach(x => {
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
                Header: 'Products',
                columns: [
                  {
                    Header: 'Class',
                    accessor: 'reservedClass',
                    Cell: props => {
                      return (
                        <span>{String(props.original.reservedClass)}</span>
                      );
                    },
                  },
                  {
                    Header: 'Color',
                    accessor: 'color',
                    Cell: props => {
                      return <span>{String(props.original.color)}</span>;
                    },
                  },
                  {
                    Header: 'Days To Manufacture',
                    accessor: 'daysToManufacture',
                    Cell: props => {
                      return (
                        <span>{String(props.original.daysToManufacture)}</span>
                      );
                    },
                  },
                  {
                    Header: 'Discontinued Date',
                    accessor: 'discontinuedDate',
                    Cell: props => {
                      return (
                        <span>{String(props.original.discontinuedDate)}</span>
                      );
                    },
                  },
                  {
                    Header: 'Finished Goods Flag',
                    accessor: 'finishedGoodsFlag',
                    Cell: props => {
                      return (
                        <span>{String(props.original.finishedGoodsFlag)}</span>
                      );
                    },
                  },
                  {
                    Header: 'List Price',
                    accessor: 'listPrice',
                    Cell: props => {
                      return <span>{String(props.original.listPrice)}</span>;
                    },
                  },
                  {
                    Header: 'Make Flag',
                    accessor: 'makeFlag',
                    Cell: props => {
                      return <span>{String(props.original.makeFlag)}</span>;
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
                    Header: 'Name',
                    accessor: 'name',
                    Cell: props => {
                      return <span>{String(props.original.name)}</span>;
                    },
                  },
                  {
                    Header: 'Product Line',
                    accessor: 'productLine',
                    Cell: props => {
                      return <span>{String(props.original.productLine)}</span>;
                    },
                  },
                  {
                    Header: 'Product Model I D',
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
                            props.original.productModelIDNavigation &&
                              props.original.productModelIDNavigation.toDisplay()
                          )}
                        </a>
                      );
                    },
                  },
                  {
                    Header: 'Product Number',
                    accessor: 'productNumber',
                    Cell: props => {
                      return (
                        <span>{String(props.original.productNumber)}</span>
                      );
                    },
                  },
                  {
                    Header: 'Product Subcategory I D',
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
                            props.original.productSubcategoryIDNavigation &&
                              props.original.productSubcategoryIDNavigation.toDisplay()
                          )}
                        </a>
                      );
                    },
                  },
                  {
                    Header: 'Reorder Point',
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
                    Header: 'Safety Stock Level',
                    accessor: 'safetyStockLevel',
                    Cell: props => {
                      return (
                        <span>{String(props.original.safetyStockLevel)}</span>
                      );
                    },
                  },
                  {
                    Header: 'Sell End Date',
                    accessor: 'sellEndDate',
                    Cell: props => {
                      return <span>{String(props.original.sellEndDate)}</span>;
                    },
                  },
                  {
                    Header: 'Sell Start Date',
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
                    Header: 'Size Unit Measure Code',
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
                            props.original.sizeUnitMeasureCodeNavigation &&
                              props.original.sizeUnitMeasureCodeNavigation.toDisplay()
                          )}
                        </a>
                      );
                    },
                  },
                  {
                    Header: 'Standard Cost',
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
                    Header: 'Weight Unit Measure Code',
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
                            props.original.weightUnitMeasureCodeNavigation &&
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
    <Hash>7c72ab6da04a8f3cbf11729283f785e4</Hash>
</Codenesium>*/