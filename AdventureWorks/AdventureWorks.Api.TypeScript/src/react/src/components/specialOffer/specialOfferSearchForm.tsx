import React, { Component, ReactElement, ReactHTMLElement } from 'react';
import axios from 'axios';
import { Redirect } from 'react-router-dom';
import * as Api from '../../api/models';
import SpecialOfferMapper from './specialOfferMapper';
import { Constants, ApiRoutes, ClientRoutes } from '../../constants';
import { LoadingForm } from '../../lib/components/loadingForm'
import { ErrorForm } from '../../lib/components/errorForm'
import ReactTable from "react-table";
import SpecialOfferViewModel from './specialOfferViewModel';
import "react-table/react-table.css";

interface SpecialOfferSearchComponentProps
{
    history:any;
}

interface SpecialOfferSearchComponentState
{
    records:Array<SpecialOfferViewModel>;
    filteredRecords:Array<SpecialOfferViewModel>;
    loading:boolean;
    loaded:boolean;
    errorOccurred:boolean;
    errorMessage:string;
    searchValue:string;
    deleteSubmitted:boolean;
    deleteSuccess:boolean;
    deleteResponse:string;
}

export default class SpecialOfferSearchComponent extends React.Component<SpecialOfferSearchComponentProps, SpecialOfferSearchComponentState> {

    state = ({deleteSubmitted:false, deleteSuccess:false, deleteResponse:'', records:new Array<SpecialOfferViewModel>(), filteredRecords:new Array<SpecialOfferViewModel>(), searchValue:'', loading:false, loaded:true, errorOccurred:false, errorMessage:''});
    
    componentDidMount () {
        this.loadRecords();
    }

    handleEditClick(e:any, row:Api.SpecialOfferClientResponseModel) {
         this.props.history.push(ClientRoutes.SpecialOffers + '/edit/' + row.specialOfferID);
    }

    handleDetailClick(e:any, row:Api.SpecialOfferClientResponseModel) {
         this.props.history.push(ClientRoutes.SpecialOffers + '/' + row.specialOfferID);
    }

    handleCreateClick(e:any) {
        this.props.history.push(ClientRoutes.SpecialOffers + '/create');
    }

    handleDeleteClick(e:any, row:Api.SpecialOfferClientResponseModel) {
        axios.delete(Constants.ApiEndpoint + ApiRoutes.SpecialOffers + '/' + row.specialOfferID,
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
	   let searchEndpoint = Constants.ApiEndpoint + ApiRoutes.SpecialOffers + '?limit=100';

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
		    let response = resp.data as Array<Api.SpecialOfferClientResponseModel>;
		    let viewModels : Array<SpecialOfferViewModel> = [];
			let mapper = new SpecialOfferMapper();

			response.forEach(x =>
			{
				viewModels.push(mapper.mapApiResponseToViewModel(x));
			})

            this.setState({records:viewModels, filteredRecords:viewModels, loading:false, loaded:true, errorOccurred:false, errorMessage:''});

	   }, error => {
		   console.log(error);
		   this.setState({records:new Array<SpecialOfferViewModel>(),filteredRecords:new Array<SpecialOfferViewModel>(), loading:false, loaded:false, errorOccurred:true, errorMessage:'Error from API'});
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
                    Header: 'SpecialOffer',
                    columns: [
					  {
                      Header: 'Category',
                      accessor: 'category',
                      Cell: (props) => {
                      return <span>{String(props.original.category)}</span>;
                      }           
                    },  {
                      Header: 'Description',
                      accessor: 'description',
                      Cell: (props) => {
                      return <span>{String(props.original.description)}</span>;
                      }           
                    },  {
                      Header: 'DiscountPct',
                      accessor: 'discountPct',
                      Cell: (props) => {
                      return <span>{String(props.original.discountPct)}</span>;
                      }           
                    },  {
                      Header: 'EndDate',
                      accessor: 'endDate',
                      Cell: (props) => {
                      return <span>{String(props.original.endDate)}</span>;
                      }           
                    },  {
                      Header: 'MaxQty',
                      accessor: 'maxQty',
                      Cell: (props) => {
                      return <span>{String(props.original.maxQty)}</span>;
                      }           
                    },  {
                      Header: 'MinQty',
                      accessor: 'minQty',
                      Cell: (props) => {
                      return <span>{String(props.original.minQty)}</span>;
                      }           
                    },  {
                      Header: 'ModifiedDate',
                      accessor: 'modifiedDate',
                      Cell: (props) => {
                      return <span>{String(props.original.modifiedDate)}</span>;
                      }           
                    },  {
                      Header: 'Rowguid',
                      accessor: 'rowguid',
                      Cell: (props) => {
                      return <span>{String(props.original.rowguid)}</span>;
                      }           
                    },  {
                      Header: 'SpecialOfferID',
                      accessor: 'specialOfferID',
                      Cell: (props) => {
                      return <span>{String(props.original.specialOfferID)}</span>;
                      }           
                    },  {
                      Header: 'StartDate',
                      accessor: 'startDate',
                      Cell: (props) => {
                      return <span>{String(props.original.startDate)}</span>;
                      }           
                    },
                    {
                        Header: 'Actions',
                        Cell: row => (<div><button className="btn btn-sm" onClick={e => {this.handleDetailClick(e, row.original as Api.SpecialOfferClientResponseModel)}} ><i className="fas fa-search"></i></button>
                        &nbsp;<button className="btn btn-primary btn-sm" onClick={e => {this.handleEditClick(e, row.original as Api.SpecialOfferClientResponseModel)}} ><i className="fas fa-edit"></i></button>
                        &nbsp;<button className="btn btn-danger btn-sm" onClick={e => {this.handleDeleteClick(e, row.original as Api.SpecialOfferClientResponseModel)}} ><i className="far fa-trash-alt"></i></button>
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
    <Hash>e08a7fb102578719cfed408d7fd3b4bd</Hash>
</Codenesium>*/