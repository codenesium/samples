import React, { Component, ReactElement, ReactHTMLElement } from 'react';
import axios, { AxiosError, AxiosResponse } from 'axios';
import { Redirect } from 'react-router-dom';
import * as Api from '../../api/models';
import WorkOrderMapper from './workOrderMapper';
import { Constants, ApiRoutes, ClientRoutes } from '../../constants';
import ReactTable from 'react-table';
import WorkOrderViewModel from './workOrderViewModel';
import 'react-table/react-table.css';
import { Form, Button, Input, Row, Col, Alert, Spin } from 'antd';
import { WrappedFormUtils } from 'antd/es/form/Form';
import * as GlobalUtilities from '../../lib/globalUtilities';

interface WorkOrderSearchComponentProps {
  form: WrappedFormUtils;
  history: any;
  match: any;
}

interface WorkOrderSearchComponentState {
  records: Array<WorkOrderViewModel>;
  filteredRecords: Array<WorkOrderViewModel>;
  loading: boolean;
  loaded: boolean;
  errorOccurred: boolean;
  errorMessage: string;
  searchValue: string;
  deleteSubmitted: boolean;
  deleteSuccess: boolean;
  deleteResponse: string;
}

export default class WorkOrderSearchComponent extends React.Component<
  WorkOrderSearchComponentProps,
  WorkOrderSearchComponentState
> {
  state = {
    deleteSubmitted: false,
    deleteSuccess: false,
    deleteResponse: '',
    records: new Array<WorkOrderViewModel>(),
    filteredRecords: new Array<WorkOrderViewModel>(),
    searchValue: '',
    loading: false,
    loaded: true,
    errorOccurred: false,
    errorMessage: '',
  };

  componentDidMount() {
    this.loadRecords();
  }

  handleEditClick(e: any, row: WorkOrderViewModel) {
    this.props.history.push(
      ClientRoutes.WorkOrders + '/edit/' + row.workOrderID
    );
  }

  handleDetailClick(e: any, row: WorkOrderViewModel) {
    this.props.history.push(ClientRoutes.WorkOrders + '/' + row.workOrderID);
  }

  handleCreateClick(e: any) {
    this.props.history.push(ClientRoutes.WorkOrders + '/create');
  }

  handleDeleteClick(e: any, row: Api.WorkOrderClientResponseModel) {
    axios
      .delete(
        Constants.ApiEndpoint + ApiRoutes.WorkOrders + '/' + row.workOrderID,
        {
          headers: GlobalUtilities.defaultHeaders(),
        }
      )
      .then(resp => {
        this.setState({
          ...this.state,
          deleteResponse: 'Record deleted',
          deleteSuccess: true,
          deleteSubmitted: true,
        });
        this.loadRecords(this.state.searchValue);
      })
      .catch((error: AxiosError) => {
        GlobalUtilities.logError(error);
        this.setState({
          ...this.state,
          deleteResponse: 'Error deleting record',
          deleteSuccess: false,
          deleteSubmitted: true,
        });
      });
  }

  handleSearchChanged(e: React.FormEvent<HTMLInputElement>) {
    this.loadRecords(e.currentTarget.value);
  }

  loadRecords(query: string = '') {
    this.setState({ ...this.state, searchValue: query });
    let searchEndpoint =
      Constants.ApiEndpoint + ApiRoutes.WorkOrders + '?limit=100';

    if (query) {
      searchEndpoint += '&query=' + query;
    }

    axios
      .get<Array<Api.WorkOrderClientResponseModel>>(searchEndpoint, {
        headers: GlobalUtilities.defaultHeaders(),
      })
      .then(response => {
        let viewModels: Array<WorkOrderViewModel> = [];
        let mapper = new WorkOrderMapper();

        response.data.forEach(x => {
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
      })
      .catch((error: AxiosError) => {
        GlobalUtilities.logError(error);
        this.setState({
          records: new Array<WorkOrderViewModel>(),
          filteredRecords: new Array<WorkOrderViewModel>(),
          loading: false,
          loaded: true,
          errorOccurred: true,
          errorMessage: 'Error from API',
        });
      });
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
                Header: 'Work Order',
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
                        &nbsp;
                        <Button
                          type="danger"
                          onClick={(e: any) => {
                            this.handleDeleteClick(
                              e,
                              row.original as WorkOrderViewModel
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

export const WrappedWorkOrderSearchComponent = Form.create({
  name: 'WorkOrder Search',
})(WorkOrderSearchComponent);


/*<Codenesium>
    <Hash>bc4f2e8228bf859bfc9668805f2fb6b1</Hash>
</Codenesium>*/