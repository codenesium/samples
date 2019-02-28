import React, { Component, FormEvent } from 'react';
import axios from 'axios';
import { Constants, ApiRoutes, ClientRoutes } from '../../constants';
import * as Api from '../../api/models';
import WorkOrderMapper from '../workOrder/workOrderMapper';
import WorkOrderViewModel from '../workOrder/workOrderViewModel';
import { Form, Input, Button, Spin, Alert } from 'antd';
import { WrappedFormUtils } from 'antd/es/form/Form';
import ReactTable from "react-table";

interface WorkOrderTableComponentProps {
  workOrderID:number,
  apiRoute:string;
  history: any;
  match: any;
}

interface WorkOrderTableComponentState {
  loading: boolean;
  loaded: boolean;
  errorOccurred: boolean;
  errorMessage: string;
  filteredRecords : Array<WorkOrderViewModel>;
}

export class  WorkOrderTableComponent extends React.Component<
WorkOrderTableComponentProps,
WorkOrderTableComponentState
> {
  state = {
    loading: false,
    loaded: true,
    errorOccurred: false,
    errorMessage: '',
    filteredRecords:[]
  };

handleEditClick(e:any, row: WorkOrderViewModel) {
  this.props.history.push(ClientRoutes.WorkOrders + '/edit/' + row.id);
}

 handleDetailClick(e:any, row: WorkOrderViewModel) {
   this.props.history.push(ClientRoutes.WorkOrders + '/' + row.id);
 }

  componentDidMount() {
	this.loadRecords();
  }

  loadRecords() {
    this.setState({ ...this.state, loading: true });

    axios
      .get(this.props.apiRoute,
        {
          headers: {
            'Content-Type': 'application/json',
          },
        }
      )
      .then(
        resp => {
          let response = resp.data as Array<Api.WorkOrderClientResponseModel>;

          console.log(response);

          let mapper = new WorkOrderMapper();
          
          let workOrders:Array<WorkOrderViewModel> = [];

          response.forEach(x =>
          {
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
    }
	else if (this.state.errorOccurred) {
	  return <Alert message={this.state.errorMessage} type='error' />;
	}
	 else if (this.state.loaded) {
      return (
	  <div>
		{message}
         <ReactTable 
                data={this.state.filteredRecords}
				defaultPageSize={10}
                columns={[{
                    Header: 'WorkOrders',
                    columns: [
					  {
                      Header: 'DueDate',
                      accessor: 'dueDate',
                      Cell: (props) => {
                      return <span>{String(props.original.dueDate)}</span>;
                      }           
                    },  {
                      Header: 'EndDate',
                      accessor: 'endDate',
                      Cell: (props) => {
                      return <span>{String(props.original.endDate)}</span>;
                      }           
                    },  {
                      Header: 'ModifiedDate',
                      accessor: 'modifiedDate',
                      Cell: (props) => {
                      return <span>{String(props.original.modifiedDate)}</span>;
                      }           
                    },  {
                      Header: 'OrderQty',
                      accessor: 'orderQty',
                      Cell: (props) => {
                      return <span>{String(props.original.orderQty)}</span>;
                      }           
                    },  {
                      Header: 'ProductID',
                      accessor: 'productID',
                      Cell: (props) => {
                        return <a href='' onClick={(e) => { e.preventDefault(); this.props.history.push(ClientRoutes.Products + '/' + props.original.productID); }}>
                          {String(
                            props.original.productIDNavigation.toDisplay()
                          )}
                        </a>
                      }           
                    },  {
                      Header: 'ScrappedQty',
                      accessor: 'scrappedQty',
                      Cell: (props) => {
                      return <span>{String(props.original.scrappedQty)}</span>;
                      }           
                    },  {
                      Header: 'ScrapReasonID',
                      accessor: 'scrapReasonID',
                      Cell: (props) => {
                        return <a href='' onClick={(e) => { e.preventDefault(); this.props.history.push(ClientRoutes.ScrapReasons + '/' + props.original.scrapReasonID); }}>
                          {String(
                            props.original.scrapReasonIDNavigation.toDisplay()
                          )}
                        </a>
                      }           
                    },  {
                      Header: 'StartDate',
                      accessor: 'startDate',
                      Cell: (props) => {
                      return <span>{String(props.original.startDate)}</span>;
                      }           
                    },  {
                      Header: 'StockedQty',
                      accessor: 'stockedQty',
                      Cell: (props) => {
                      return <span>{String(props.original.stockedQty)}</span>;
                      }           
                    },  {
                      Header: 'WorkOrderID',
                      accessor: 'workOrderID',
                      Cell: (props) => {
                      return <span>{String(props.original.workOrderID)}</span>;
                      }           
                    },
                    {
                        Header: 'Actions',
					    minWidth:150,
                        Cell: row => (<div>
					    <Button
                          type="primary" 
                          onClick={(e:any) => {
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
                          onClick={(e:any) => {
                            this.handleEditClick(
                              e,
                              row.original as WorkOrderViewModel
                            );
                          }}
                        >
                          <i className="fas fa-edit" />
                        </Button>
                        </div>)
                    }],
                    
                  }]} />
			</div>
      );
    } else {
      return null;
    }
  }
}

/*<Codenesium>
    <Hash>7cc62156aa3076f055797c9e269153fb</Hash>
</Codenesium>*/