import React, { Component, FormEvent } from 'react';
import axios, { AxiosError, AxiosResponse } from 'axios';
import { Constants, ApiRoutes, ClientRoutes } from '../../constants';
import * as Api from '../../api/models';
import SalesOrderHeaderMapper from '../salesOrderHeader/salesOrderHeaderMapper';
import SalesOrderHeaderViewModel from '../salesOrderHeader/salesOrderHeaderViewModel';
import { Form, Input, Button, Spin, Alert } from 'antd';
import { WrappedFormUtils } from 'antd/es/form/Form';
import ReactTable from 'react-table';
import * as GlobalUtilities from '../../lib/globalUtilities';

interface SalesOrderHeaderTableComponentProps {
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
    this.props.history.push(
      ClientRoutes.SalesOrderHeaders + '/edit/' + row.salesOrderID
    );
  }

  handleDetailClick(e: any, row: SalesOrderHeaderViewModel) {
    this.props.history.push(
      ClientRoutes.SalesOrderHeaders + '/' + row.salesOrderID
    );
  }

  componentDidMount() {
    this.loadRecords();
  }

  loadRecords() {
    this.setState({ ...this.state, loading: true });

    axios
      .get<Array<Api.SalesOrderHeaderClientResponseModel>>(
        this.props.apiRoute,
        {
          headers: GlobalUtilities.defaultHeaders(),
        }
      )
      .then(response => {
        GlobalUtilities.logInfo(response);

        let mapper = new SalesOrderHeaderMapper();

        let salesOrderHeaders: Array<SalesOrderHeaderViewModel> = [];

        response.data.forEach(x => {
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
                Header: 'SalesOrderHeaders',
                columns: [
                  {
                    Header: 'Account Number',
                    accessor: 'accountNumber',
                    Cell: props => {
                      return (
                        <span>{String(props.original.accountNumber)}</span>
                      );
                    },
                  },
                  {
                    Header: 'Bill To Address I D',
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
                    Header: 'Credit Card Approval Code',
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
                    Header: 'Credit Card I D',
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
                            props.original.creditCardIDNavigation &&
                              props.original.creditCardIDNavigation.toDisplay()
                          )}
                        </a>
                      );
                    },
                  },
                  {
                    Header: 'Currency Rate I D',
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
                            props.original.currencyRateIDNavigation &&
                              props.original.currencyRateIDNavigation.toDisplay()
                          )}
                        </a>
                      );
                    },
                  },
                  {
                    Header: 'Customer I D',
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
                            props.original.customerIDNavigation &&
                              props.original.customerIDNavigation.toDisplay()
                          )}
                        </a>
                      );
                    },
                  },
                  {
                    Header: 'Due Date',
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
                    Header: 'Modified Date',
                    accessor: 'modifiedDate',
                    Cell: props => {
                      return <span>{String(props.original.modifiedDate)}</span>;
                    },
                  },
                  {
                    Header: 'Online Order Flag',
                    accessor: 'onlineOrderFlag',
                    Cell: props => {
                      return (
                        <span>{String(props.original.onlineOrderFlag)}</span>
                      );
                    },
                  },
                  {
                    Header: 'Order Date',
                    accessor: 'orderDate',
                    Cell: props => {
                      return <span>{String(props.original.orderDate)}</span>;
                    },
                  },
                  {
                    Header: 'Purchase Order Number',
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
                    Header: 'Revision Number',
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
                    Header: 'Sales Order Number',
                    accessor: 'salesOrderNumber',
                    Cell: props => {
                      return (
                        <span>{String(props.original.salesOrderNumber)}</span>
                      );
                    },
                  },
                  {
                    Header: 'Sales Person I D',
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
                            props.original.salesPersonIDNavigation &&
                              props.original.salesPersonIDNavigation.toDisplay()
                          )}
                        </a>
                      );
                    },
                  },
                  {
                    Header: 'Ship Date',
                    accessor: 'shipDate',
                    Cell: props => {
                      return <span>{String(props.original.shipDate)}</span>;
                    },
                  },
                  {
                    Header: 'Ship Method I D',
                    accessor: 'shipMethodID',
                    Cell: props => {
                      return <span>{String(props.original.shipMethodID)}</span>;
                    },
                  },
                  {
                    Header: 'Ship To Address I D',
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
                    Header: 'Sub Total',
                    accessor: 'subTotal',
                    Cell: props => {
                      return <span>{String(props.original.subTotal)}</span>;
                    },
                  },
                  {
                    Header: 'Tax Amt',
                    accessor: 'taxAmt',
                    Cell: props => {
                      return <span>{String(props.original.taxAmt)}</span>;
                    },
                  },
                  {
                    Header: 'Territory I D',
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
                            props.original.territoryIDNavigation &&
                              props.original.territoryIDNavigation.toDisplay()
                          )}
                        </a>
                      );
                    },
                  },
                  {
                    Header: 'Total Due',
                    accessor: 'totalDue',
                    Cell: props => {
                      return <span>{String(props.original.totalDue)}</span>;
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
    <Hash>56cd39ae397fd1cf8bae160c6e0aef80</Hash>
</Codenesium>*/