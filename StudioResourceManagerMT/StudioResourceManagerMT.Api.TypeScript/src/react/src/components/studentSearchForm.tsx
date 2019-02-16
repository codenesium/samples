import React, { Component, ReactElement, ReactHTMLElement } from 'react';
import axios from 'axios';
import { Redirect } from 'react-router-dom';
import * as Api from '../api/models';
import StudentMapper from '../mapping/studentMapper';
import Constants from '../constants'
import ReactTable from "react-table";
import StudentViewModel from '../viewmodels/studentViewModel';
import "react-table/react-table.css";

interface StudentSearchComponentProps
{
}

interface StudentSearchComponentState
{
    records:Array<StudentViewModel>;
    filteredRecords:Array<StudentViewModel>;
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

export default class StudentSearchComponent extends React.Component<StudentSearchComponentProps, StudentSearchComponentState> {

    state = ({deleteSubmitted:false, deleteSuccess:false, deleteResponse:'', records:new Array<Api.StudentClientResponseModel>(), filteredRecords:new Array<Api.StudentClientResponseModel>(), searchValue:'', loading:false, loaded:true, toCreate:false, errorOccurred:false, errorMessage:'', toUpdate:false,toUpdateId:0, toDetail:false,toDetailId:0});
    
    componentDidMount () {
        this.loadData();
    }

    loadData () {
        axios.get(Constants.ApiUrl + 'Students',
        {
            headers: {
                'Content-Type': 'application/json',
            }
        })
        .then(resp => {
            let response = resp.data as Array<Api.StudentClientResponseModel>;

			let viewModels : Array<StudentViewModel> = [];
			let mapper = new StudentMapper();

			response.forEach(x =>
			{
				viewModels.push(mapper.mapApiResponseToViewModel(x));
			})

            this.setState({records:viewModels, filteredRecords:viewModels, loading:false, loaded:true, errorOccurred:false, errorMessage:''});

        }, error => {
            let response = error.response.data as Array<Api.StudentClientResponseModel>;
            this.setState({records:new Array<StudentViewModel>(),filteredRecords:new Array<StudentViewModel>(), loading:false, loaded:false, errorOccurred:true, errorMessage:'Error from API'});
            console.log(response);
        })
    }

    handleEditClick(e:any, row:Api.StudentClientResponseModel) {
        this.setState({...this.state,toUpdate:true,toUpdateId:row.id});
    }

    handleDetailClick(e:any, row:Api.StudentClientResponseModel) {
        this.setState({...this.state,toDetail:true,toDetailId:row.id});
    }

    handleCreateClick(e:any) {
        this.setState({...this.state, toCreate:true});
    }

    handleDeleteClick(e:any, row:Api.StudentClientResponseModel) {
        axios.delete(Constants.ApiUrl + 'students/' + row.id,
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
   axios.get(Constants.ApiUrl + 'Students?q=' + e.currentTarget.value,
   {
       headers: {
           'Content-Type': 'application/json',
       }
   })
   .then(resp => {
       let response = resp.data as Array<Api.StudentClientResponseModel>;
       this.setState({records:response, filteredRecords:response, loading:false, loaded:true, errorOccurred:false, errorMessage:''});

   }, error => {
       let response = error.response.data as Array<Api.StudentClientResponseModel>;
       this.setState({records:new Array<Api.StudentClientResponseModel>(),filteredRecords:new Array<Api.StudentClientResponseModel>(), loading:false, loaded:false, errorOccurred:true, errorMessage:'Error from API'});
       console.log(response);
   })
    }

    filterGrid() {

    }
    
    render () {
        if(this.state.toCreate) {
            return <Redirect to={'/students/create'} />
        }
        else if(this.state.toUpdate) {
            return <Redirect to={'/students/edit/' + this.state.toUpdateId} />
        }
        else if(this.state.toDetail) {
            return <Redirect to={'/students/' + this.state.toDetailId} />
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
                    Header: 'Students',
                    columns: [
					  {
                      Header: 'Birthday',
                      accessor: 'birthday'
                    },  {
                      Header: 'Email',
                      accessor: 'email'
                    },  {
                      Header: 'EmailRemindersEnabled',
                      accessor: 'emailRemindersEnabled'
                    },  {
                      Header: 'FamilyId',
                      accessor: 'familyId'
                    },  {
                      Header: 'FirstName',
                      accessor: 'firstName'
                    },  {
                      Header: 'Id',
                      accessor: 'id'
                    },  {
                      Header: 'IsAdult',
                      accessor: 'isAdult'
                    },  {
                      Header: 'IsDeleted',
                      accessor: 'isDeleted'
                    },  {
                      Header: 'LastName',
                      accessor: 'lastName'
                    },  {
                      Header: 'Phone',
                      accessor: 'phone'
                    },  {
                      Header: 'SmsRemindersEnabled',
                      accessor: 'smsRemindersEnabled'
                    },  {
                      Header: 'TenantId',
                      accessor: 'tenantId'
                    },  {
                      Header: 'UserId',
                      accessor: 'userId'
                    },
                    {
                        Header: 'Actions',
                        Cell: row => (<div><button className="btn btn-sm" onClick={e => {this.handleDetailClick(e, row.original as Api.StudentClientResponseModel)}} >Detail</button>
                        &nbsp;<button className="btn btn-primary btn-sm" onClick={e => {this.handleEditClick(e, row.original as Api.StudentClientResponseModel)}} >Edit</button>
                        &nbsp;<button className="btn btn-danger btn-sm" onClick={e => {this.handleDeleteClick(e, row.original as Api.StudentClientResponseModel)}} >Delete</button>
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
    <Hash>ea6dca7e1009717451af3b5718d8db76</Hash>
</Codenesium>*/