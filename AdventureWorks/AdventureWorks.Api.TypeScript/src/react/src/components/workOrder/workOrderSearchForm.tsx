import React, { Component, ReactElement, ReactHTMLElement } from 'react';
import axios from 'axios';
import { Redirect } from 'react-router-dom';
import * as Api from '../../api/models';
import WorkOrderMapper from './workOrderMapper';
import { Constants, ApiRoutes, ClientRoutes } from '../../constants';
import { LoadingForm } from '../../lib/components/loadingForm'
import { ErrorForm } from '../../lib/components/errorForm'
import ReactTable from "react-table";
import WorkOrderViewModel from './workOrderViewModel';
import "react-table/react-table.css";

interface WorkOrderSearchComponentProps
{
    history:any;
}

interface WorkOrderSearchComponentState
{
    records:Array<WorkOrderViewModel>;
    filteredRecords:Array<WorkOrderViewModel>;
    loading:boolean;
    loaded:boolean;
    errorOccurred:boolean;
    errorMessage:string;
    searchValue:string;
    deleteSubmitted:boolean;
    deleteSuccess:boolean;
    deleteResponse:string;
}

export default class WorkOrderSearchComponent extends React.Component<WorkOrderSearchComponentProps, WorkOrderSearchComponentState> {

    state = ({deleteSubmitted:false, deleteSuccess:false, deleteResponse:'', records:new Array<WorkOrderViewModel>(), filteredRecords:new Array<WorkOrderViewModel>(), searchValue:'', loading:false, loaded:true, errorOccurred:false, errorMessage:''});
    
    componentDidMount () {
        this.loadRecords();
    }

    handleEditClick(e:any, row:Api.WorkOrderClientResponseModel) {
         this.props.history.push(ClientRoutes.WorkOrders + '/edit/' + row.workOrderID);
    }

    handleDetailClick(e:any, row:Api.WorkOrderClientResponseModel) {
         this.props.history.push(ClientRoutes.WorkOrders + '/' + row.workOrderID);
    }

    handleCreateClick(e:any) {
        this.props.history.push(ClientRoutes.WorkOrders + '/create');
    }

    handleDeleteClick(e:any, row:Api.WorkOrderClientResponseModel) {
        axios.delete(Constants.ApiEndpoint + ApiRoutes.WorkOrders + '/' + row.workOrderID,
        {
            headers: {
                'Content-Type': 'application/json',
            }
        })
        .then(resp => {
            this.setState({...this.state, deleteResponse:'Record deleted', deleteSuccess:true, deleteSubmitted:true});
            this.loadRecords(this.state.searchValue);
        }, error => {
            console.log(error);
            this.setState({...this.state, deleteResponse:'Error deleting record', deleteSuccess:false, deleteSubmitted:true});
        })
    }

   handleSearchChanged(e:React.FormEvent<HTMLInputElement>) {
		this.loadRecords(e.currentTarget.value);
   }
   
   loadRecords(query:string = '') {
	   this.setState({...this.state, searchValue:query});
	   let searchEndpoint = Constants.ApiEndpoint + ApiRoutes.WorkOrders + '?limit=100';

	   if(query)
	   {
		   searchEndpoint += '&query=' +  query;
	   }

	   axios.get(searchEndpoint,
	   {
		   headers: {
			   'Content-Type': 'application/json',
		   }
	   })
	   .then(resp => {
		    let response = resp.data as Array<Api.WorkOrderClientResponseModel>;
		    let viewModels : Array<WorkOrderViewModel> = [];
			let mapper = new WorkOrderMapper();

			response.forEach(x =>
			{
				viewModels.push(mapper.mapApiResponseToViewModel(x));
			})

            this.setState({records:viewModels, filteredRecords:viewModels, loading:false, loaded:true, errorOccurred:false, errorMessage:''});

	   }, error => {
		   console.log(error);
		   this.setState({records:new Array<WorkOrderViewModel>(),filteredRecords:new Array<WorkOrderViewModel>(), loading:false, loaded:false, errorOccurred:true, errorMessage:'Error from API'});
	   })
    }

    filterGrid() {

    }
    
    render () {
        if(this.state.loading) {
            return <LoadingForm />;
        } 
		else if(this.state.errorOccurred) {
            return <ErrorForm message={this.state.errorMessage} />;
        }
        else if(this.state.loaded) {

            let errorResponse:JSX.Element = <span></span>;

            if(this.state.deleteSubmitted){
                if(this.state.deleteSuccess){
                    errorResponse =<div className="alert alert-success">{this.state.deleteResponse}</div>   
                }
                else {
                    errorResponse = <div className="alert alert-danger">{this.state.deleteResponse}</div>   
                }
            }
            return (
            <div>
                { 
                    errorResponse
                }
            <form>
                <div className="form-group row">
                    <div className="col-sm-4">
                    </div>
                    <div className="col-sm-4">
                        <input name="search" className="form-control" placeholder={"Search"} value={this.state.searchValue} onChange={e => this.handleSearchChanged(e)}/>
                    </div>
                    <div className="col-sm-4">
                        <button className="btn btn-primary btn-sm align-middle float-right vertically-center search-create-button" onClick={e => this.handleCreateClick(e)}><i className="fas fa-plus"></i></button>
                    </div>
                </div>
            </form>
            <ReactTable 
                data={this.state.filteredRecords}
                columns={[{
                    Header: 'WorkOrder',
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
                      return <span>{String(props.original.productID)}</span>;
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
                      return <span>{String(props.original.scrapReasonID)}</span>;
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
                        Cell: row => (<div><button className="btn btn-sm" onClick={e => {this.handleDetailClick(e, row.original as Api.WorkOrderClientResponseModel)}} ><i className="fas fa-search"></i></button>
                        &nbsp;<button className="btn btn-primary btn-sm" onClick={e => {this.handleEditClick(e, row.original as Api.WorkOrderClientResponseModel)}} ><i className="fas fa-edit"></i></button>
                        &nbsp;<button className="btn btn-danger btn-sm" onClick={e => {this.handleDeleteClick(e, row.original as Api.WorkOrderClientResponseModel)}} ><i className="far fa-trash-alt"></i></button>
                        </div>)
                    }],
                    
                  }]} />
                  </div>);
        } 
		else {
		  return null;
		}
    }
}

/*<Codenesium>
    <Hash>2531c5480818d3e5fd296ebb3c38b5f1</Hash>
</Codenesium>*/