import React, { Component, FormEvent } from 'react';
import axios, { AxiosError, AxiosResponse } from 'axios';
import { Constants, ApiRoutes, ClientRoutes } from '../../constants';
import * as Api from '../../api/models';
import PurchaseOrderHeaderMapper from '../purchaseOrderHeader/purchaseOrderHeaderMapper';
import PurchaseOrderHeaderViewModel from '../purchaseOrderHeader/purchaseOrderHeaderViewModel';
import { Form, Input, Button, Spin, Alert } from 'antd';
import { WrappedFormUtils } from 'antd/es/form/Form';
import ReactTable from 'react-table';
import * as GlobalUtilities from '../../lib/globalUtilities';

interface PurchaseOrderHeaderTableComponentProps {
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
      ClientRoutes.PurchaseOrderHeaders + '/edit/' + row.purchaseOrderID
    );
  }

  handleDetailClick(e: any, row: PurchaseOrderHeaderViewModel) {
    this.props.history.push(
      ClientRoutes.PurchaseOrderHeaders + '/' + row.purchaseOrderID
    );
  }

  componentDidMount() {
    this.loadRecords();
  }

  loadRecords() {
    this.setState({ ...this.state, loading: true });

    axios
      .get<Array<Api.PurchaseOrderHeaderClientResponseModel>>(
        this.props.apiRoute,
        {
          headers: GlobalUtilities.defaultHeaders(),
        }
      )
      .then(response => {
        GlobalUtilities.logInfo(response);

        let mapper = new PurchaseOrderHeaderMapper();

        let purchaseOrderHeaders: Array<PurchaseOrderHeaderViewModel> = [];

        response.data.forEach(x => {
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
                Header: 'PurchaseOrderHeaders',
                columns: [
                  {
                    Header: 'Employee I D',
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
                    Header: 'Modified Date',
                    accessor: 'modifiedDate',
                    Cell: props => {
                      return <span>{String(props.original.modifiedDate)}</span>;
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
                    Header: 'Revision Number',
                    accessor: 'revisionNumber',
                    Cell: props => {
                      return (
                        <span>{String(props.original.revisionNumber)}</span>
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
                            props.original.shipMethodIDNavigation &&
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
                    Header: 'Total Due',
                    accessor: 'totalDue',
                    Cell: props => {
                      return <span>{String(props.original.totalDue)}</span>;
                    },
                  },
                  {
                    Header: 'Vendor I D',
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
                            props.original.vendorIDNavigation &&
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
    <Hash>44cd9367970b19e9bfe1fe2875917560</Hash>
</Codenesium>*/