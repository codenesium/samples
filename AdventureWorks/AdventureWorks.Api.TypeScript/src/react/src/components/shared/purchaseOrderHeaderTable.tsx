import React, { Component, FormEvent } from 'react';
import axios from 'axios';
import { Constants, ApiRoutes, ClientRoutes } from '../../constants';
import * as Api from '../../api/models';
import PurchaseOrderHeaderMapper from '../purchaseOrderHeader/purchaseOrderHeaderMapper';
import PurchaseOrderHeaderViewModel from '../purchaseOrderHeader/purchaseOrderHeaderViewModel';
import { Form, Input, Button, Spin, Alert } from 'antd';
import { WrappedFormUtils } from 'antd/es/form/Form';
import ReactTable from 'react-table';

interface PurchaseOrderHeaderTableComponentProps {
  purchaseOrderID: number;
  apiRoute: string;
  history: any;
  match: any;
}

interface PurchaseOrderHeaderTableComponentState {
  loading: boolean;
  loaded: boolean;
  errorOccurred: boolean;
  errorMessage: string;
  filteredRecords: Array<PurchaseOrderHeaderViewModel>;
}

export class PurchaseOrderHeaderTableComponent extends React.Component<
  PurchaseOrderHeaderTableComponentProps,
  PurchaseOrderHeaderTableComponentState
> {
  state = {
    loading: false,
    loaded: true,
    errorOccurred: false,
    errorMessage: '',
    filteredRecords: [],
  };

  handleEditClick(e: any, row: PurchaseOrderHeaderViewModel) {
    this.props.history.push(
      ClientRoutes.PurchaseOrderHeaders + '/edit/' + row.id
    );
  }

  handleDetailClick(e: any, row: PurchaseOrderHeaderViewModel) {
    this.props.history.push(ClientRoutes.PurchaseOrderHeaders + '/' + row.id);
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
          let response = resp.data as Array<
            Api.PurchaseOrderHeaderClientResponseModel
          >;

          console.log(response);

          let mapper = new PurchaseOrderHeaderMapper();

          let purchaseOrderHeaders: Array<PurchaseOrderHeaderViewModel> = [];

          response.forEach(x => {
            purchaseOrderHeaders.push(mapper.mapApiResponseToViewModel(x));
          });
          this.setState({
            ...this.state,
            filteredRecords: purchaseOrderHeaders,
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
                Header: 'PurchaseOrderHeaders',
                columns: [
                  {
                    Header: 'EmployeeID',
                    accessor: 'employeeID',
                    Cell: props => {
                      return <span>{String(props.original.employeeID)}</span>;
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
                    Header: 'OrderDate',
                    accessor: 'orderDate',
                    Cell: props => {
                      return <span>{String(props.original.orderDate)}</span>;
                    },
                  },
                  {
                    Header: 'PurchaseOrderID',
                    accessor: 'purchaseOrderID',
                    Cell: props => {
                      return (
                        <span>{String(props.original.purchaseOrderID)}</span>
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
                      return (
                        <a
                          href=""
                          onClick={e => {
                            e.preventDefault();
                            this.props.history.push(
                              ClientRoutes.ShipMethods +
                                '/' +
                                props.original.shipMethodID
                            );
                          }}
                        >
                          {String(
                            props.original.shipMethodIDNavigation.toDisplay()
                          )}
                        </a>
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
                    Header: 'TotalDue',
                    accessor: 'totalDue',
                    Cell: props => {
                      return <span>{String(props.original.totalDue)}</span>;
                    },
                  },
                  {
                    Header: 'VendorID',
                    accessor: 'vendorID',
                    Cell: props => {
                      return (
                        <a
                          href=""
                          onClick={e => {
                            e.preventDefault();
                            this.props.history.push(
                              ClientRoutes.Vendors +
                                '/' +
                                props.original.vendorID
                            );
                          }}
                        >
                          {String(
                            props.original.vendorIDNavigation.toDisplay()
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
                              row.original as PurchaseOrderHeaderViewModel
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
                              row.original as PurchaseOrderHeaderViewModel
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
    <Hash>2f07fb229963da1e16bc064ac73b51cd</Hash>
</Codenesium>*/