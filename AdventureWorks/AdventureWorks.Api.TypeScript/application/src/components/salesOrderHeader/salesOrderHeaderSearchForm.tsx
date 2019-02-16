import React, { Component, ReactElement, ReactHTMLElement } from 'react';
import axios from 'axios';
import { Redirect } from 'react-router-dom';
import * as Api from '../../api/models';
import SalesOrderHeaderMapper from './salesOrderHeaderMapper';
import Constants from '../../constants';
import ReactTable from 'react-table';
import SalesOrderHeaderViewModel from './salesOrderHeaderViewModel';
import 'react-table/react-table.css';

interface SalesOrderHeaderSearchComponentProps {
  history: any;
}

interface SalesOrderHeaderSearchComponentState {
  records: Array<SalesOrderHeaderViewModel>;
  filteredRecords: Array<SalesOrderHeaderViewModel>;
  loading: boolean;
  loaded: boolean;
  errorOccurred: boolean;
  errorMessage: string;
  searchValue: string;
  deleteSubmitted: boolean;
  deleteSuccess: boolean;
  deleteResponse: string;
}

export default class SalesOrderHeaderSearchComponent extends React.Component<
  SalesOrderHeaderSearchComponentProps,
  SalesOrderHeaderSearchComponentState
> {
  state = {
    deleteSubmitted: false,
    deleteSuccess: false,
    deleteResponse: '',
    records: new Array<Api.SalesOrderHeaderClientResponseModel>(),
    filteredRecords: new Array<Api.SalesOrderHeaderClientResponseModel>(),
    searchValue: '',
    loading: false,
    loaded: true,
    errorOccurred: false,
    errorMessage: '',
  };

  componentDidMount() {
    this.loadRecords();
  }

  handleEditClick(e: any, row: Api.SalesOrderHeaderClientResponseModel) {
    this.props.history.push('/salesorderheaders/edit/' + row.salesOrderID);
  }

  handleDetailClick(e: any, row: Api.SalesOrderHeaderClientResponseModel) {
    this.props.history.push('/salesorderheaders/' + row.salesOrderID);
  }

  handleCreateClick(e: any) {
    this.props.history.push('/salesorderheaders/create');
  }

  handleDeleteClick(e: any, row: Api.SalesOrderHeaderClientResponseModel) {
    axios
      .delete(Constants.ApiUrl + 'salesorderheaders/' + row.salesOrderID, {
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
    let searchEndpoint = Constants.ApiUrl + 'salesorderheaders' + '?limit=100';

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
          let response = resp.data as Array<
            Api.SalesOrderHeaderClientResponseModel
          >;
          let viewModels: Array<SalesOrderHeaderViewModel> = [];
          let mapper = new SalesOrderHeaderMapper();

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
            records: new Array<SalesOrderHeaderViewModel>(),
            filteredRecords: new Array<SalesOrderHeaderViewModel>(),
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
                Header: 'SalesOrderHeader',
                columns: [
                  {
                    Header: 'AccountNumber',
                    accessor: 'accountNumber',
                    Cell: props => {
                      return (
                        <span>{String(props.original.accountNumber)}</span>
                      );
                    },
                  },
                  {
                    Header: 'BillToAddressID',
                    accessor: 'billToAddressID',
                    Cell: props => {
                      return (
                        <span>{String(props.original.billToAddressID)}</span>
                      );
                    },
                  },
                  {
                    Header: 'Comment',
                    accessor: 'comment',
                    Cell: props => {
                      return <span>{String(props.original.comment)}</span>;
                    },
                  },
                  {
                    Header: 'CreditCardApprovalCode',
                    accessor: 'creditCardApprovalCode',
                    Cell: props => {
                      return (
                        <span>
                          {String(props.original.creditCardApprovalCode)}
                        </span>
                      );
                    },
                  },
                  {
                    Header: 'CreditCardID',
                    accessor: 'creditCardID',
                    Cell: props => {
                      return <span>{String(props.original.creditCardID)}</span>;
                    },
                  },
                  {
                    Header: 'CurrencyRateID',
                    accessor: 'currencyRateID',
                    Cell: props => {
                      return (
                        <span>{String(props.original.currencyRateID)}</span>
                      );
                    },
                  },
                  {
                    Header: 'CustomerID',
                    accessor: 'customerID',
                    Cell: props => {
                      return <span>{String(props.original.customerID)}</span>;
                    },
                  },
                  {
                    Header: 'DueDate',
                    accessor: 'dueDate',
                    Cell: props => {
                      return <span>{String(props.original.dueDate)}</span>;
                    },
                  },
                  {
                    Header: 'Freight',
                    accessor: 'freight',
                    Cell: props => {
                      return <span>{String(props.original.freight)}</span>;
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
                    Header: 'OnlineOrderFlag',
                    accessor: 'onlineOrderFlag',
                    Cell: props => {
                      return (
                        <span>{String(props.original.onlineOrderFlag)}</span>
                      );
                    },
                  },
                  {
                    Header: 'OrderDate',
                    accessor: 'orderDate',
                    Cell: props => {
                      return <span>{String(props.original.orderDate)}</span>;
                    },
                  },
                  {
                    Header: 'PurchaseOrderNumber',
                    accessor: 'purchaseOrderNumber',
                    Cell: props => {
                      return (
                        <span>
                          {String(props.original.purchaseOrderNumber)}
                        </span>
                      );
                    },
                  },
                  {
                    Header: 'RevisionNumber',
                    accessor: 'revisionNumber',
                    Cell: props => {
                      return (
                        <span>{String(props.original.revisionNumber)}</span>
                      );
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
                    Header: 'SalesOrderID',
                    accessor: 'salesOrderID',
                    Cell: props => {
                      return <span>{String(props.original.salesOrderID)}</span>;
                    },
                  },
                  {
                    Header: 'SalesOrderNumber',
                    accessor: 'salesOrderNumber',
                    Cell: props => {
                      return (
                        <span>{String(props.original.salesOrderNumber)}</span>
                      );
                    },
                  },
                  {
                    Header: 'SalesPersonID',
                    accessor: 'salesPersonID',
                    Cell: props => {
                      return (
                        <span>{String(props.original.salesPersonID)}</span>
                      );
                    },
                  },
                  {
                    Header: 'ShipDate',
                    accessor: 'shipDate',
                    Cell: props => {
                      return <span>{String(props.original.shipDate)}</span>;
                    },
                  },
                  {
                    Header: 'ShipMethodID',
                    accessor: 'shipMethodID',
                    Cell: props => {
                      return <span>{String(props.original.shipMethodID)}</span>;
                    },
                  },
                  {
                    Header: 'ShipToAddressID',
                    accessor: 'shipToAddressID',
                    Cell: props => {
                      return (
                        <span>{String(props.original.shipToAddressID)}</span>
                      );
                    },
                  },
                  {
                    Header: 'Status',
                    accessor: 'status',
                    Cell: props => {
                      return <span>{String(props.original.status)}</span>;
                    },
                  },
                  {
                    Header: 'SubTotal',
                    accessor: 'subTotal',
                    Cell: props => {
                      return <span>{String(props.original.subTotal)}</span>;
                    },
                  },
                  {
                    Header: 'TaxAmt',
                    accessor: 'taxAmt',
                    Cell: props => {
                      return <span>{String(props.original.taxAmt)}</span>;
                    },
                  },
                  {
                    Header: 'TerritoryID',
                    accessor: 'territoryID',
                    Cell: props => {
                      return <span>{String(props.original.territoryID)}</span>;
                    },
                  },
                  {
                    Header: 'TotalDue',
                    accessor: 'totalDue',
                    Cell: props => {
                      return <span>{String(props.original.totalDue)}</span>;
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
                              row.original as Api.SalesOrderHeaderClientResponseModel
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
                              row.original as Api.SalesOrderHeaderClientResponseModel
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
                              row.original as Api.SalesOrderHeaderClientResponseModel
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
    <Hash>f623e24b019aea2cd7abb0d39e867132</Hash>
</Codenesium>*/