import React, { Component, ReactElement, ReactHTMLElement } from 'react';
import axios from 'axios';
import { Redirect } from 'react-router-dom';
import * as Api from '../../api/models';
import ProductMapper from './productMapper';
import Constants from '../../constants';
import ReactTable from 'react-table';
import ProductViewModel from './productViewModel';
import 'react-table/react-table.css';

interface ProductSearchComponentProps {
  history: any;
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
    records: new Array<Api.ProductClientResponseModel>(),
    filteredRecords: new Array<Api.ProductClientResponseModel>(),
    searchValue: '',
    loading: false,
    loaded: true,
    errorOccurred: false,
    errorMessage: '',
  };

  componentDidMount() {
    this.loadRecords();
  }

  handleEditClick(e: any, row: Api.ProductClientResponseModel) {
    this.props.history.push('/products/edit/' + row.productID);
  }

  handleDetailClick(e: any, row: Api.ProductClientResponseModel) {
    this.props.history.push('/products/' + row.productID);
  }

  handleCreateClick(e: any) {
    this.props.history.push('/products/create');
  }

  handleDeleteClick(e: any, row: Api.ProductClientResponseModel) {
    axios
      .delete(Constants.ApiUrl + 'products/' + row.productID, {
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
    let searchEndpoint = Constants.ApiUrl + 'products' + '?limit=100';

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
            loaded: false,
            errorOccurred: true,
            errorMessage: 'Error from API',
          });
        }
      );
  }

  filterGrid() {}

  render() {
    if (this.state.loading) {
      return <div>loading</div>;
    } else if (this.state.loaded) {
      let errorResponse: JSX.Element = <span />;

      if (this.state.deleteSubmitted) {
        if (this.state.deleteSuccess) {
          errorResponse = (
            <div className="alert alert-success">
              {this.state.deleteResponse}
            </div>
          );
        } else {
          errorResponse = (
            <div className="alert alert-danger">
              {this.state.deleteResponse}
            </div>
          );
        }
      }
      return (
        <div>
          {errorResponse}
          <form>
            <div className="form-group row">
              <div className="col-sm-4" />
              <div className="col-sm-4">
                <input
                  name="search"
                  className="form-control"
                  placeholder={'Search'}
                  value={this.state.searchValue}
                  onChange={e => this.handleSearchChanged(e)}
                />
              </div>
              <div className="col-sm-4">
                <button
                  className="btn btn-primary btn-sm align-middle float-right vertically-center search-create-button"
                  onClick={e => this.handleCreateClick(e)}
                >
                  <i className="fas fa-plus" />
                </button>
              </div>
            </div>
          </form>
          <ReactTable
            data={this.state.filteredRecords}
            columns={[
              {
                Header: 'Product',
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
                        <span>{String(props.original.productModelID)}</span>
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
                        <span>
                          {String(props.original.productSubcategoryID)}
                        </span>
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
                        <span>
                          {String(props.original.sizeUnitMeasureCode)}
                        </span>
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
                        <span>
                          {String(props.original.weightUnitMeasureCode)}
                        </span>
                      );
                    },
                  },
                  {
                    Header: 'Actions',
                    Cell: row => (
                      <div>
                        <button
                          className="btn btn-sm"
                          onClick={e => {
                            this.handleDetailClick(
                              e,
                              row.original as Api.ProductClientResponseModel
                            );
                          }}
                        >
                          <i className="fas fa-search" />
                        </button>
                        &nbsp;
                        <button
                          className="btn btn-primary btn-sm"
                          onClick={e => {
                            this.handleEditClick(
                              e,
                              row.original as Api.ProductClientResponseModel
                            );
                          }}
                        >
                          <i className="fas fa-edit" />
                        </button>
                        &nbsp;
                        <button
                          className="btn btn-danger btn-sm"
                          onClick={e => {
                            this.handleDeleteClick(
                              e,
                              row.original as Api.ProductClientResponseModel
                            );
                          }}
                        >
                          <i className="far fa-trash-alt" />
                        </button>
                      </div>
                    ),
                  },
                ],
              },
            ]}
          />
        </div>
      );
    } else if (this.state.errorOccurred) {
      return (
        <div className="alert alert-danger">{this.state.errorMessage}</div>
      );
    } else {
      return <div />;
    }
  }
}


/*<Codenesium>
    <Hash>6aec6ce760c6e4c390c7b3a5d826653c</Hash>
</Codenesium>*/