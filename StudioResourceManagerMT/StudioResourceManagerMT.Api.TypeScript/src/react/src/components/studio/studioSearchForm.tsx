import React, { Component, ReactElement, ReactHTMLElement } from 'react';
import axios from 'axios';
import { Redirect } from 'react-router-dom';
import * as Api from '../../api/models';
import StudioMapper from './studioMapper';
import { Constants, ApiRoutes, ClientRoutes } from '../../constants';
import { LoadingForm } from '../../lib/components/loadingForm'
import { ErrorForm } from '../../lib/components/errorForm'
import ReactTable from "react-table";
import StudioViewModel from './studioViewModel';
import "react-table/react-table.css";

interface StudioSearchComponentProps
{
    history:any;
}

interface StudioSearchComponentState
{
    records:Array<StudioViewModel>;
    filteredRecords:Array<StudioViewModel>;
    loading:boolean;
    loaded:boolean;
    errorOccurred:boolean;
    errorMessage:string;
    searchValue:string;
    deleteSubmitted:boolean;
    deleteSuccess:boolean;
    deleteResponse:string;
}

export default class StudioSearchComponent extends React.Component<StudioSearchComponentProps, StudioSearchComponentState> {

    state = ({deleteSubmitted:false, deleteSuccess:false, deleteResponse:'', records:new Array<StudioViewModel>(), filteredRecords:new Array<StudioViewModel>(), searchValue:'', loading:false, loaded:true, errorOccurred:false, errorMessage:''});
    
    componentDidMount () {
        this.loadRecords();
    }

    handleEditClick(e:any, row:Api.StudioClientResponseModel) {
         this.props.history.push(ClientRoutes.Studios + '/edit/' + row.id);
    }

    handleDetailClick(e:any, row:Api.StudioClientResponseModel) {
         this.props.history.push(ClientRoutes.Studios + '/' + row.id);
    }

    handleCreateClick(e:any) {
        this.props.history.push(ClientRoutes.Studios + '/create');
    }

    handleDeleteClick(e:any, row:Api.StudioClientResponseModel) {
        axios.delete(Constants.ApiEndpoint + ApiRoutes.Studios + '/' + row.id,
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
	   let searchEndpoint = Constants.ApiEndpoint + ApiRoutes.Studios + '?limit=100';

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
		    let response = resp.data as Array<Api.StudioClientResponseModel>;
		    let viewModels : Array<StudioViewModel> = [];
			let mapper = new StudioMapper();

			response.forEach(x =>
			{
				viewModels.push(mapper.mapApiResponseToViewModel(x));
			})

            this.setState({records:viewModels, filteredRecords:viewModels, loading:false, loaded:true, errorOccurred:false, errorMessage:''});

	   }, error => {
		   console.log(error);
		   this.setState({records:new Array<StudioViewModel>(),filteredRecords:new Array<StudioViewModel>(), loading:false, loaded:false, errorOccurred:true, errorMessage:'Error from API'});
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
                    Header: 'Studio',
                    columns: [
					  {
                      Header: 'Address1',
                      accessor: 'address1',
                      Cell: (props) => {
                      return <span>{String(props.original.address1)}</span>;
                      }           
                    },  {
                      Header: 'Address2',
                      accessor: 'address2',
                      Cell: (props) => {
                      return <span>{String(props.original.address2)}</span>;
                      }           
                    },  {
                      Header: 'City',
                      accessor: 'city',
                      Cell: (props) => {
                      return <span>{String(props.original.city)}</span>;
                      }           
                    },  {
                      Header: 'Id',
                      accessor: 'id',
                      Cell: (props) => {
                      return <span>{String(props.original.id)}</span>;
                      }           
                    },  {
                      Header: 'Name',
                      accessor: 'name',
                      Cell: (props) => {
                      return <span>{String(props.original.name)}</span>;
                      }           
                    },  {
                      Header: 'Province',
                      accessor: 'province',
                      Cell: (props) => {
                      return <span>{String(props.original.province)}</span>;
                      }           
                    },  {
                      Header: 'Website',
                      accessor: 'website',
                      Cell: (props) => {
                      return <span>{String(props.original.website)}</span>;
                      }           
                    },  {
                      Header: 'Zip',
                      accessor: 'zip',
                      Cell: (props) => {
                      return <span>{String(props.original.zip)}</span>;
                      }           
                    },
                    {
                        Header: 'Actions',
                        Cell: row => (<div><button className="btn btn-sm" onClick={e => {this.handleDetailClick(e, row.original as Api.StudioClientResponseModel)}} ><i className="fas fa-search"></i></button>
                        &nbsp;<button className="btn btn-primary btn-sm" onClick={e => {this.handleEditClick(e, row.original as Api.StudioClientResponseModel)}} ><i className="fas fa-edit"></i></button>
                        &nbsp;<button className="btn btn-danger btn-sm" onClick={e => {this.handleDeleteClick(e, row.original as Api.StudioClientResponseModel)}} ><i className="far fa-trash-alt"></i></button>
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
    <Hash>e53f67c88b13c63965d8c376a10a19f8</Hash>
</Codenesium>*/