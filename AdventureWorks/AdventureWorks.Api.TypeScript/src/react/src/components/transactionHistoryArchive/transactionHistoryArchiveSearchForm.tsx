import React, { Component, ReactElement, ReactHTMLElement } from 'react';
import axios from 'axios';
import { Redirect } from 'react-router-dom';
import * as Api from '../../api/models';
import TransactionHistoryArchiveMapper from './transactionHistoryArchiveMapper';
import { Constants, ApiRoutes, ClientRoutes } from '../../constants';
import { LoadingForm } from '../../lib/components/loadingForm'
import { ErrorForm } from '../../lib/components/errorForm'
import ReactTable from "react-table";
import TransactionHistoryArchiveViewModel from './transactionHistoryArchiveViewModel';
import "react-table/react-table.css";

interface TransactionHistoryArchiveSearchComponentProps
{
    history:any;
}

interface TransactionHistoryArchiveSearchComponentState
{
    records:Array<TransactionHistoryArchiveViewModel>;
    filteredRecords:Array<TransactionHistoryArchiveViewModel>;
    loading:boolean;
    loaded:boolean;
    errorOccurred:boolean;
    errorMessage:string;
    searchValue:string;
    deleteSubmitted:boolean;
    deleteSuccess:boolean;
    deleteResponse:string;
}

export default class TransactionHistoryArchiveSearchComponent extends React.Component<TransactionHistoryArchiveSearchComponentProps, TransactionHistoryArchiveSearchComponentState> {

    state = ({deleteSubmitted:false, deleteSuccess:false, deleteResponse:'', records:new Array<TransactionHistoryArchiveViewModel>(), filteredRecords:new Array<TransactionHistoryArchiveViewModel>(), searchValue:'', loading:false, loaded:true, errorOccurred:false, errorMessage:''});
    
    componentDidMount () {
        this.loadRecords();
    }

    handleEditClick(e:any, row:Api.TransactionHistoryArchiveClientResponseModel) {
         this.props.history.push(ClientRoutes.TransactionHistoryArchives + '/edit/' + row.transactionID);
    }

    handleDetailClick(e:any, row:Api.TransactionHistoryArchiveClientResponseModel) {
         this.props.history.push(ClientRoutes.TransactionHistoryArchives + '/' + row.transactionID);
    }

    handleCreateClick(e:any) {
        this.props.history.push(ClientRoutes.TransactionHistoryArchives + '/create');
    }

    handleDeleteClick(e:any, row:Api.TransactionHistoryArchiveClientResponseModel) {
        axios.delete(Constants.ApiEndpoint + ApiRoutes.TransactionHistoryArchives + '/' + row.transactionID,
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
	   let searchEndpoint = Constants.ApiEndpoint + ApiRoutes.TransactionHistoryArchives + '?limit=100';

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
		    let response = resp.data as Array<Api.TransactionHistoryArchiveClientResponseModel>;
		    let viewModels : Array<TransactionHistoryArchiveViewModel> = [];
			let mapper = new TransactionHistoryArchiveMapper();

			response.forEach(x =>
			{
				viewModels.push(mapper.mapApiResponseToViewModel(x));
			})

            this.setState({records:viewModels, filteredRecords:viewModels, loading:false, loaded:true, errorOccurred:false, errorMessage:''});

	   }, error => {
		   console.log(error);
		   this.setState({records:new Array<TransactionHistoryArchiveViewModel>(),filteredRecords:new Array<TransactionHistoryArchiveViewModel>(), loading:false, loaded:false, errorOccurred:true, errorMessage:'Error from API'});
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
                    Header: 'TransactionHistoryArchive',
                    columns: [
					  {
                      Header: 'ActualCost',
                      accessor: 'actualCost',
                      Cell: (props) => {
                      return <span>{String(props.original.actualCost)}</span>;
                      }           
                    },  {
                      Header: 'ModifiedDate',
                      accessor: 'modifiedDate',
                      Cell: (props) => {
                      return <span>{String(props.original.modifiedDate)}</span>;
                      }           
                    },  {
                      Header: 'ProductID',
                      accessor: 'productID',
                      Cell: (props) => {
                      return <span>{String(props.original.productID)}</span>;
                      }           
                    },  {
                      Header: 'Quantity',
                      accessor: 'quantity',
                      Cell: (props) => {
                      return <span>{String(props.original.quantity)}</span>;
                      }           
                    },  {
                      Header: 'ReferenceOrderID',
                      accessor: 'referenceOrderID',
                      Cell: (props) => {
                      return <span>{String(props.original.referenceOrderID)}</span>;
                      }           
                    },  {
                      Header: 'ReferenceOrderLineID',
                      accessor: 'referenceOrderLineID',
                      Cell: (props) => {
                      return <span>{String(props.original.referenceOrderLineID)}</span>;
                      }           
                    },  {
                      Header: 'TransactionDate',
                      accessor: 'transactionDate',
                      Cell: (props) => {
                      return <span>{String(props.original.transactionDate)}</span>;
                      }           
                    },  {
                      Header: 'TransactionID',
                      accessor: 'transactionID',
                      Cell: (props) => {
                      return <span>{String(props.original.transactionID)}</span>;
                      }           
                    },  {
                      Header: 'TransactionType',
                      accessor: 'transactionType',
                      Cell: (props) => {
                      return <span>{String(props.original.transactionType)}</span>;
                      }           
                    },
                    {
                        Header: 'Actions',
                        Cell: row => (<div><button className="btn btn-sm" onClick={e => {this.handleDetailClick(e, row.original as Api.TransactionHistoryArchiveClientResponseModel)}} ><i className="fas fa-search"></i></button>
                        &nbsp;<button className="btn btn-primary btn-sm" onClick={e => {this.handleEditClick(e, row.original as Api.TransactionHistoryArchiveClientResponseModel)}} ><i className="fas fa-edit"></i></button>
                        &nbsp;<button className="btn btn-danger btn-sm" onClick={e => {this.handleDeleteClick(e, row.original as Api.TransactionHistoryArchiveClientResponseModel)}} ><i className="far fa-trash-alt"></i></button>
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
    <Hash>b36822a93e0f065665cbb71854700aa3</Hash>
</Codenesium>*/