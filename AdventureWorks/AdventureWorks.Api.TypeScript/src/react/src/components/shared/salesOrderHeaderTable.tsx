import React, { Component, FormEvent } from 'react';
import axios from 'axios';
import { Constants, ApiRoutes, ClientRoutes } from '../../constants';
import * as Api from '../../api/models';
import SalesOrderHeaderMapper from '../salesOrderHeader/salesOrderHeaderMapper';
import SalesOrderHeaderViewModel from '../salesOrderHeader/salesOrderHeaderViewModel';
import { Form, Input, Button, Spin, Alert } from 'antd';
import { WrappedFormUtils } from 'antd/es/form/Form';
import ReactTable from 'react-table';

interface SalesOrderHeaderTableComponentProps {
  salesOrderID: number;
  apiRoute: string;
  history: any;
  match: any;
}

interface SalesOrderHeaderTableComponentState {
  loading: boolean;
  loaded: boolean;
  errorOccurred: boolean;
  errorMessage: string;
  filteredRecords: Array<SalesOrderHeaderViewModel>;
}

export class SalesOrderHeaderTableComponent extends React.Component<
  SalesOrderHeaderTableComponentProps,
  SalesOrderHeaderTableComponentState
> {
  state = {
    loading: false,
    loaded: true,
    errorOccurred: false,
    errorMessage: '',
    filteredRecords: [],
  };

  handleEditClick(e: any, row: SalesOrderHeaderViewModel) {
    this.props.history.push(ClientRoutes.SalesOrderHeaders + '/edit/' + row.id);
  }

  handleDetailClick(e: any, row: SalesOrderHeaderViewModel) {
    this.props.history.push(ClientRoutes.SalesOrderHeaders + '/' + row.id);
  }

  componentDidMount() {
    this.setState({ ...this.state, loading: true });

    axios
      .get(this.props.apiRoute, {
        headers: {
          'Content-Type': 'application/json',
        },
      })
      .then(
        resp => {
          let response = resp.data as Array<
            Api.SalesOrderHeaderClientResponseModel
          >;

          console.log(response);

          let mapper = new SalesOrderHeaderMapper();

          let salesOrderHeaders: Array<SalesOrderHeaderViewModel> = [];

          response.forEach(x => {
            salesOrderHeaders.push(mapper.mapApiResponseToViewModel(x));
          });
          this.setState({
            ...this.state,
            filteredRecords: salesOrderHeaders,
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
                Header: 'SalesOrderHeaders',
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
                      return (
                        <a
                          href=""
                          onClick={e => {
                            e.preventDefault();
                            this.props.history.push(
                              ClientRoutes.CreditCards +
                                '/' +
                                props.original.creditCardID
                            );
                          }}
                        >
                          {String(
                            props.original.creditCardIDNavigation.toDisplay()
                          )}
                        </a>
                      );
                    },
                  },
                  {
                    Header: 'CurrencyRateID',
                    accessor: 'currencyRateID',
                    Cell: props => {
                      return (
                        <a
                          href=""
                          onClick={e => {
                            e.preventDefault();
                            this.props.history.push(
                              ClientRoutes.CurrencyRates +
                                '/' +
                                props.original.currencyRateID
                            );
                          }}
                        >
                          {String(
                            props.original.currencyRateIDNavigation.toDisplay()
                          )}
                        </a>
                      );
                    },
                  },
                  {
                    Header: 'CustomerID',
                    accessor: 'customerID',
                    Cell: props => {
                      return (
                        <a
                          href=""
                          onClick={e => {
                            e.preventDefault();
                            this.props.history.push(
                              ClientRoutes.Customers +
                                '/' +
                                props.original.customerID
                            );
                          }}
                        >
                          {String(
                            props.original.customerIDNavigation.toDisplay()
                          )}
                        </a>
                      );
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
                        <a
                          href=""
                          onClick={e => {
                            e.preventDefault();
                            this.props.history.push(
                              ClientRoutes.SalesPersons +
                                '/' +
                                props.original.salesPersonID
                            );
                          }}
                        >
                          {String(
                            props.original.salesPersonIDNavigation.toDisplay()
                          )}
                        </a>
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
                      return (
                        <a
                          href=""
                          onClick={e => {
                            e.preventDefault();
                            this.props.history.push(
                              ClientRoutes.SalesTerritories +
                                '/' +
                                props.original.territoryID
                            );
                          }}
                        >
                          {String(
                            props.original.territoryIDNavigation.toDisplay()
                          )}
                        </a>
                      );
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
                        <Button
                          type="primary"
                          onClick={(e: any) => {
                            this.handleDetailClick(
                              e,
                              row.original as SalesOrderHeaderViewModel
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
                              row.original as SalesOrderHeaderViewModel
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
    <Hash>6f55399156555a8c1cdcc161d6efc761</Hash>
</Codenesium>*/