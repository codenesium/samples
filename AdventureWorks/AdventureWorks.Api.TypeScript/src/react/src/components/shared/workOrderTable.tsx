import React, { Component, FormEvent } from 'react';
import axios, { AxiosError, AxiosResponse } from 'axios';
import { Constants, ApiRoutes, ClientRoutes } from '../../constants';
import * as Api from '../../api/models';
import WorkOrderMapper from '../workOrder/workOrderMapper';
import WorkOrderViewModel from '../workOrder/workOrderViewModel';
import { Form, Input, Button, Spin, Alert } from 'antd';
import { WrappedFormUtils } from 'antd/es/form/Form';
import ReactTable from 'react-table';
import * as GlobalUtilities from '../../lib/globalUtilities';

interface WorkOrderTableComponentProps {
  apiRoute: string;
  history: any;
  match: any;
}

interface WorkOrderTableComponentState {
  loading: boolean;
  loaded: boolean;
  errorOccurred: boolean;
  errorMessage: string;
  filteredRecords: Array<WorkOrderViewModel>;
}

export class WorkOrderTableComponent extends React.Component<
  WorkOrderTableComponentProps,
  WorkOrderTableComponentState
> {
  state = {
    loading: false,
    loaded: true,
    errorOccurred: false,
    errorMessage: '',
    filteredRecords: [],
  };

  handleEditClick(e: any, row: WorkOrderViewModel) {
    this.props.history.push(
      ClientRoutes.WorkOrders + '/edit/' + row.workOrderID
    );
  }

  handleDetailClick(e: any, row: WorkOrderViewModel) {
    this.props.history.push(ClientRoutes.WorkOrders + '/' + row.workOrderID);
  }

  componentDidMount() {
    this.loadRecords();
  }

  loadRecords() {
    this.setState({ ...this.state, loading: true });

    axios
      .get<Array<Api.WorkOrderClientResponseModel>>(this.props.apiRoute, {
        headers: GlobalUtilities.defaultHeaders(),
      })
      .then(response => {
        GlobalUtilities.logInfo(response);

        let mapper = new WorkOrderMapper();

        let workOrders: Array<WorkOrderViewModel> = [];

        response.data.forEach(x => {
          workOrders.push(mapper.mapApiResponseToViewModel(x));
        });

        this.setState({
          ...this.state,
          filteredRecords: workOrders,
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
                Header: 'WorkOrders',
                columns: [
                  {
                    Header: 'Due Date',
                    accessor: 'dueDate',
                    Cell: props => {
                      return <span>{String(props.original.dueDate)}</span>;
                    },
                  },
                  {
                    Header: 'End Date',
                    accessor: 'endDate',
                    Cell: props => {
                      return <span>{String(props.original.endDate)}</span>;
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
                    Header: 'Order Qty',
                    accessor: 'orderQty',
                    Cell: props => {
                      return <span>{String(props.original.orderQty)}</span>;
                    },
                  },
                  {
                    Header: 'Product I D',
                    accessor: 'productID',
                    Cell: props => {
                      return (
                        <a
                          href=""
                          onClick={e => {
                            e.preventDefault();
                            this.props.history.push(
                              ClientRoutes.Products +
                                '/' +
                                props.original.productID
                            );
                          }}
                        >
                          {String(
                            props.original.productIDNavigation &&
                              props.original.productIDNavigation.toDisplay()
                          )}
                        </a>
                      );
                    },
                  },
                  {
                    Header: 'Scrapped Qty',
                    accessor: 'scrappedQty',
                    Cell: props => {
                      return <span>{String(props.original.scrappedQty)}</span>;
                    },
                  },
                  {
                    Header: 'Scrap Reason I D',
                    accessor: 'scrapReasonID',
                    Cell: props => {
                      return (
                        <a
                          href=""
                          onClick={e => {
                            e.preventDefault();
                            this.props.history.push(
                              ClientRoutes.ScrapReasons +
                                '/' +
                                props.original.scrapReasonID
                            );
                          }}
                        >
                          {String(
                            props.original.scrapReasonIDNavigation &&
                              props.original.scrapReasonIDNavigation.toDisplay()
                          )}
                        </a>
                      );
                    },
                  },
                  {
                    Header: 'Start Date',
                    accessor: 'startDate',
                    Cell: props => {
                      return <span>{String(props.original.startDate)}</span>;
                    },
                  },
                  {
                    Header: 'Stocked Qty',
                    accessor: 'stockedQty',
                    Cell: props => {
                      return <span>{String(props.original.stockedQty)}</span>;
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
                              row.original as WorkOrderViewModel
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
                              row.original as WorkOrderViewModel
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
    <Hash>7474f12a78565116924adc4cabac5dd2</Hash>
</Codenesium>*/