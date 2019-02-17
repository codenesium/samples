import React, { Component, ReactElement, ReactHTMLElement } from 'react';
import axios from 'axios';
import { Redirect } from 'react-router-dom';
import * as Api from '../../api/models';
import StateProvinceMapper from './stateProvinceMapper';
import { Constants, ApiRoutes, ClientRoutes } from '../../constants';
import { LoadingForm } from '../../lib/components/loadingForm'
import { ErrorForm } from '../../lib/components/errorForm'
import ReactTable from "react-table";
import StateProvinceViewModel from './stateProvinceViewModel';
import "react-table/react-table.css";

interface StateProvinceSearchComponentProps
{
    history:any;
}

interface StateProvinceSearchComponentState
{
    records:Array<StateProvinceViewModel>;
    filteredRecords:Array<StateProvinceViewModel>;
    loading:boolean;
    loaded:boolean;
    errorOccurred:boolean;
    errorMessage:string;
    searchValue:string;
    deleteSubmitted:boolean;
    deleteSuccess:boolean;
    deleteResponse:string;
}

export default class StateProvinceSearchComponent extends React.Component<StateProvinceSearchComponentProps, StateProvinceSearchComponentState> {

    state = ({deleteSubmitted:false, deleteSuccess:false, deleteResponse:'', records:new Array<StateProvinceViewModel>(), filteredRecords:new Array<StateProvinceViewModel>(), searchValue:'', loading:false, loaded:true, errorOccurred:false, errorMessage:''});
    
    componentDidMount () {
        this.loadRecords();
    }

    handleEditClick(e:any, row:Api.StateProvinceClientResponseModel) {
         this.props.history.push(ClientRoutes.StateProvinces + '/edit/' + row.stateProvinceID);
    }

    handleDetailClick(e:any, row:Api.StateProvinceClientResponseModel) {
         this.props.history.push(ClientRoutes.StateProvinces + '/' + row.stateProvinceID);
    }

    handleCreateClick(e:any) {
        this.props.history.push(ClientRoutes.StateProvinces + '/create');
    }

    handleDeleteClick(e:any, row:Api.StateProvinceClientResponseModel) {
        axios.delete(Constants.ApiEndpoint + ApiRoutes.StateProvinces + '/' + row.stateProvinceID,
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
	   let searchEndpoint = Constants.ApiEndpoint + ApiRoutes.StateProvinces + '?limit=100';

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
		    let response = resp.data as Array<Api.StateProvinceClientResponseModel>;
		    let viewModels : Array<StateProvinceViewModel> = [];
			let mapper = new StateProvinceMapper();

			response.forEach(x =>
			{
				viewModels.push(mapper.mapApiResponseToViewModel(x));
			})

            this.setState({records:viewModels, filteredRecords:viewModels, loading:false, loaded:true, errorOccurred:false, errorMessage:''});

	   }, error => {
		   console.log(error);
		   this.setState({records:new Array<StateProvinceViewModel>(),filteredRecords:new Array<StateProvinceViewModel>(), loading:false, loaded:false, errorOccurred:true, errorMessage:'Error from API'});
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
                    Header: 'StateProvince',
                    columns: [
					  {
                      Header: 'CountryRegionCode',
                      accessor: 'countryRegionCode',
                      Cell: (props) => {
                      return <span>{String(props.original.countryRegionCode)}</span>;
                      }           
                    },  {
                      Header: 'IsOnlyStateProvinceFlag',
                      accessor: 'isOnlyStateProvinceFlag',
                      Cell: (props) => {
                      return <span>{String(props.original.isOnlyStateProvinceFlag)}</span>;
                      }           
                    },  {
                      Header: 'ModifiedDate',
                      accessor: 'modifiedDate',
                      Cell: (props) => {
                      return <span>{String(props.original.modifiedDate)}</span>;
                      }           
                    },  {
                      Header: 'Name',
                      accessor: 'name',
                      Cell: (props) => {
                      return <span>{String(props.original.name)}</span>;
                      }           
                    },  {
                      Header: 'Rowguid',
                      accessor: 'rowguid',
                      Cell: (props) => {
                      return <span>{String(props.original.rowguid)}</span>;
                      }           
                    },  {
                      Header: 'StateProvinceCode',
                      accessor: 'stateProvinceCode',
                      Cell: (props) => {
                      return <span>{String(props.original.stateProvinceCode)}</span>;
                      }           
                    },  {
                      Header: 'StateProvinceID',
                      accessor: 'stateProvinceID',
                      Cell: (props) => {
                      return <span>{String(props.original.stateProvinceID)}</span>;
                      }           
                    },  {
                      Header: 'TerritoryID',
                      accessor: 'territoryID',
                      Cell: (props) => {
                      return <span>{String(props.original.territoryID)}</span>;
                      }           
                    },
                    {
                        Header: 'Actions',
                        Cell: row => (<div><button className="btn btn-sm" onClick={e => {this.handleDetailClick(e, row.original as Api.StateProvinceClientResponseModel)}} ><i className="fas fa-search"></i></button>
                        &nbsp;<button className="btn btn-primary btn-sm" onClick={e => {this.handleEditClick(e, row.original as Api.StateProvinceClientResponseModel)}} ><i className="fas fa-edit"></i></button>
                        &nbsp;<button className="btn btn-danger btn-sm" onClick={e => {this.handleDeleteClick(e, row.original as Api.StateProvinceClientResponseModel)}} ><i className="far fa-trash-alt"></i></button>
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
    <Hash>f36cc5d83abb19580b4acdef8dadaa19</Hash>
</Codenesium>*/