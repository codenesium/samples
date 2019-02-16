import React, { Component, ReactElement, ReactHTMLElement } from 'react';
import axios from 'axios';
import { Redirect } from 'react-router-dom';
import * as Api from '../api/models';
import FamilyMapper from '../mapping/familyMapper';
import Constants from '../constants'
import ReactTable from "react-table";
import FamilyViewModel from '../viewmodels/familyViewModel';
import "react-table/react-table.css";

interface FamilySearchComponentProps
{
}

interface FamilySearchComponentState
{
    records:Array<FamilyViewModel>;
    filteredRecords:Array<FamilyViewModel>;
    loading:boolean;
    loaded:boolean;
    errorOccurred:boolean;
    errorMessage:string;
    toUpdate:boolean;
    toUpdateId:number;
    toDetail:boolean;
    toDetailId:number;
    toCreate:boolean;
    searchValue:string;
    deleteSubmitted:boolean;
    deleteSuccess:boolean;
    deleteResponse:string;
}

export default class FamilySearchComponent extends React.Component<FamilySearchComponentProps, FamilySearchComponentState> {

    state = ({deleteSubmitted:false, deleteSuccess:false, deleteResponse:'', records:new Array<Api.FamilyClientResponseModel>(), filteredRecords:new Array<Api.FamilyClientResponseModel>(), searchValue:'', loading:false, loaded:true, toCreate:false, errorOccurred:false, errorMessage:'', toUpdate:false,toUpdateId:0, toDetail:false,toDetailId:0});
    
    componentDidMount () {
        this.loadData();
    }

    loadData () {
        axios.get(Constants.ApiUrl + 'Familys',
        {
            headers: {
                'Content-Type': 'application/json',
            }
        })
        .then(resp => {
            let response = resp.data as Array<Api.FamilyClientResponseModel>;

			let viewModels : Array<FamilyViewModel> = [];
			let mapper = new FamilyMapper();

			response.forEach(x =>
			{
				viewModels.push(mapper.mapApiResponseToViewModel(x));
			})

            this.setState({records:viewModels, filteredRecords:viewModels, loading:false, loaded:true, errorOccurred:false, errorMessage:''});

        }, error => {
            let response = error.response.data as Array<Api.FamilyClientResponseModel>;
            this.setState({records:new Array<FamilyViewModel>(),filteredRecords:new Array<FamilyViewModel>(), loading:false, loaded:false, errorOccurred:true, errorMessage:'Error from API'});
            console.log(response);
        })
    }

    handleEditClick(e:any, row:Api.FamilyClientResponseModel) {
        this.setState({...this.state,toUpdate:true,toUpdateId:row.id});
    }

    handleDetailClick(e:any, row:Api.FamilyClientResponseModel) {
        this.setState({...this.state,toDetail:true,toDetailId:row.id});
    }

    handleCreateClick(e:any) {
        this.setState({...this.state, toCreate:true});
    }

    handleDeleteClick(e:any, row:Api.FamilyClientResponseModel) {
        axios.delete(Constants.ApiUrl + 'families/' + row.id,
        {
            headers: {
                'Content-Type': 'application/json',
            }
        })
        .then(resp => {
            this.setState({...this.state,deleteResponse:'Record deleted',deleteSuccess:true, deleteSubmitted:true});
            this.loadData();
        }, error => {
            console.log(error);
            this.setState({...this.state,deleteResponse:'Error deleting record',deleteSuccess:false, deleteSubmitted:true});
        })
    }


    handleSearchChanged(e:React.FormEvent<HTMLInputElement>) {
        /*console.log(e);
        let filtered = this.state.records.filter(x =>
            {
                //return x.name.startsWith(e.currentTarget.value) ||
                //x.publicId.startsWith(e.currentTarget.value);
                //console.log(Object.values(x));
                //let found = Object.values(x).startsWith(e.currentTarget.value);
                // return found;
            });
        this.setState({...this.state,filteredRecords:filtered, searchValue:e.currentTarget.value});
    */

   this.setState({...this.state, searchValue:e.currentTarget.value});
   axios.get(Constants.ApiUrl + 'Families?q=' + e.currentTarget.value,
   {
       headers: {
           'Content-Type': 'application/json',
       }
   })
   .then(resp => {
       let response = resp.data as Array<Api.FamilyClientResponseModel>;
       this.setState({records:response, filteredRecords:response, loading:false, loaded:true, errorOccurred:false, errorMessage:''});

   }, error => {
       let response = error.response.data as Array<Api.FamilyClientResponseModel>;
       this.setState({records:new Array<Api.FamilyClientResponseModel>(),filteredRecords:new Array<Api.FamilyClientResponseModel>(), loading:false, loaded:false, errorOccurred:true, errorMessage:'Error from API'});
       console.log(response);
   })
    }

    filterGrid() {

    }
    
    render () {
        if(this.state.toCreate) {
            return <Redirect to={'/families/create'} />
        }
        else if(this.state.toUpdate) {
            return <Redirect to={'/families/edit/' + this.state.toUpdateId} />
        }
        else if(this.state.toDetail) {
            return <Redirect to={'/families/' + this.state.toDetailId} />
        }
        else if(this.state.loading) {
            return (<div>loading</div>);
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
                        <button className="btn btn-primary btn-sm align-middle float-right vertically-center" onClick={e => this.handleCreateClick(e)}>Create</button>
                    </div>
                </div>
            </form>
            <ReactTable 
                data={this.state.filteredRecords}
                columns={[{
                    Header: 'Familys',
                    columns: [
					  {
                      Header: 'Id',
                      accessor: 'id'
                    },  {
                      Header: 'IsDeleted',
                      accessor: 'isDeleted'
                    },  {
                      Header: 'Note',
                      accessor: 'note'
                    },  {
                      Header: 'PrimaryContactEmail',
                      accessor: 'primaryContactEmail'
                    },  {
                      Header: 'PrimaryContactFirstName',
                      accessor: 'primaryContactFirstName'
                    },  {
                      Header: 'PrimaryContactLastName',
                      accessor: 'primaryContactLastName'
                    },  {
                      Header: 'PrimaryContactPhone',
                      accessor: 'primaryContactPhone'
                    },  {
                      Header: 'TenantId',
                      accessor: 'tenantId'
                    },
                    {
                        Header: 'Actions',
                        Cell: row => (<div><button className="btn btn-sm" onClick={e => {this.handleDetailClick(e, row.original as Api.FamilyClientResponseModel)}} >Detail</button>
                        &nbsp;<button className="btn btn-primary btn-sm" onClick={e => {this.handleEditClick(e, row.original as Api.FamilyClientResponseModel)}} >Edit</button>
                        &nbsp;<button className="btn btn-danger btn-sm" onClick={e => {this.handleDeleteClick(e, row.original as Api.FamilyClientResponseModel)}} >Delete</button>
                        </div>)
                    }],
                    
                  }]} />
                  </div>);
        } 
        else if(this.state.errorOccurred) {
            return (<div>{this.state.errorMessage}</div>);
        }
        else {
            return (<div></div>);   
        }
    }
}

/*<Codenesium>
    <Hash>99122d0e75a424bcdf77d070899e74d8</Hash>
</Codenesium>*/