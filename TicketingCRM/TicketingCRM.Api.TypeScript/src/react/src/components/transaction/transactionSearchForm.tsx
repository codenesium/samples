import React, { Component, ReactElement, ReactHTMLElement } from 'react';
import axios from 'axios';
import { Redirect } from 'react-router-dom';
import * as Api from '../../api/models';
import TransactionMapper from './transactionMapper';
import { Constants, ApiRoutes, ClientRoutes } from '../../constants';
import { LoadingForm } from '../../lib/components/loadingForm'
import { ErrorForm } from '../../lib/components/errorForm'
import ReactTable from "react-table";
import TransactionViewModel from './transactionViewModel';
import "react-table/react-table.css";

interface TransactionSearchComponentProps
{
    history:any;
}

interface TransactionSearchComponentState
{
    records:Array<TransactionViewModel>;
    filteredRecords:Array<TransactionViewModel>;
    loading:boolean;
    loaded:boolean;
    errorOccurred:boolean;
    errorMessage:string;
    searchValue:string;
    deleteSubmitted:boolean;
    deleteSuccess:boolean;
    deleteResponse:string;
}

export default class TransactionSearchComponent extends React.Component<TransactionSearchComponentProps, TransactionSearchComponentState> {

    state = ({deleteSubmitted:false, deleteSuccess:false, deleteResponse:'', records:new Array<TransactionViewModel>(), filteredRecords:new Array<TransactionViewModel>(), searchValue:'', loading:false, loaded:true, errorOccurred:false, errorMessage:''});
    
    componentDidMount () {
        this.loadRecords();
    }

    handleEditClick(e:any, row:Api.TransactionClientResponseModel) {
         this.props.history.push(ClientRoutes.Transactions + '/edit/' + row.id);
    }

    handleDetailClick(e:any, row:Api.TransactionClientResponseModel) {
         this.props.history.push(ClientRoutes.Transactions + '/' + row.id);
    }

    handleCreateClick(e:any) {
        this.props.history.push(ClientRoutes.Transactions + '/create');
    }

    handleDeleteClick(e:any, row:Api.TransactionClientResponseModel) {
        axios.delete(Constants.ApiEndpoint + ApiRoutes.Transactions + '/' + row.id,
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
	   let searchEndpoint = Constants.ApiEndpoint + ApiRoutes.Transactions + '?limit=100';

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
		    let response = resp.data as Array<Api.TransactionClientResponseModel>;
		    let viewModels : Array<TransactionViewModel> = [];
			let mapper = new TransactionMapper();

			response.forEach(x =>
			{
				viewModels.push(mapper.mapApiResponseToViewModel(x));
			})

            this.setState({records:viewModels, filteredRecords:viewModels, loading:false, loaded:true, errorOccurred:false, errorMessage:''});

	   }, error => {
		   console.log(error);
		   this.setState({records:new Array<TransactionViewModel>(),filteredRecords:new Array<TransactionViewModel>(), loading:false, loaded:false, errorOccurred:true, errorMessage:'Error from API'});
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
                    Header: 'Transaction',
                    columns: [
					  {
                      Header: 'Amount',
                      accessor: 'amount',
                      Cell: (props) => {
                      return <span>{String(props.original.amount)}</span>;
                      }           
                    },  {
                      Header: 'GatewayConfirmationNumber',
                      accessor: 'gatewayConfirmationNumber',
                      Cell: (props) => {
                      return <span>{String(props.original.gatewayConfirmationNumber)}</span>;
                      }           
                    },  {
                      Header: 'TransactionStatusId',
                      accessor: 'transactionStatusId',
                      Cell: (props) => {
                        return <a href='' onClick={(e) => { e.preventDefault(); this.props.history.push(ClientRoutes.TransactionStatus + '/' + props.original.transactionStatusId); }}>
                          {String(
                            props.original.transactionStatusIdNavigation.toDisplay()
                          )}
                        </a>
                      }           
                    },
                    {
                        Header: 'Actions',
                        Cell: row => (<div><button className="btn btn-sm" onClick={e => {this.handleDetailClick(e, row.original as Api.TransactionClientResponseModel)}} ><i className="fas fa-search"></i></button>
                        &nbsp;<button className="btn btn-primary btn-sm" onClick={e => {this.handleEditClick(e, row.original as Api.TransactionClientResponseModel)}} ><i className="fas fa-edit"></i></button>
                        &nbsp;<button className="btn btn-danger btn-sm" onClick={e => {this.handleDeleteClick(e, row.original as Api.TransactionClientResponseModel)}} ><i className="far fa-trash-alt"></i></button>
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
    <Hash>4c89bf3af47a5c144c95a0edf958f732</Hash>
</Codenesium>*/