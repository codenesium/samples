import React, { Component, ReactElement, ReactHTMLElement } from 'react';
import axios from 'axios';
import { Redirect } from 'react-router-dom';
import * as Api from '../../api/models';
import UserMapper from './userMapper';
import { Constants, ApiRoutes, ClientRoutes } from '../../constants';
import { LoadingForm } from '../../lib/components/loadingForm'
import { ErrorForm } from '../../lib/components/errorForm'
import ReactTable from "react-table";
import UserViewModel from './userViewModel';
import "react-table/react-table.css";

interface UserSearchComponentProps
{
    history:any;
}

interface UserSearchComponentState
{
    records:Array<UserViewModel>;
    filteredRecords:Array<UserViewModel>;
    loading:boolean;
    loaded:boolean;
    errorOccurred:boolean;
    errorMessage:string;
    searchValue:string;
    deleteSubmitted:boolean;
    deleteSuccess:boolean;
    deleteResponse:string;
}

export default class UserSearchComponent extends React.Component<UserSearchComponentProps, UserSearchComponentState> {

    state = ({deleteSubmitted:false, deleteSuccess:false, deleteResponse:'', records:new Array<UserViewModel>(), filteredRecords:new Array<UserViewModel>(), searchValue:'', loading:false, loaded:true, errorOccurred:false, errorMessage:''});
    
    componentDidMount () {
        this.loadRecords();
    }

    handleEditClick(e:any, row:Api.UserClientResponseModel) {
         this.props.history.push(ClientRoutes.Users + '/edit/' + row.id);
    }

    handleDetailClick(e:any, row:Api.UserClientResponseModel) {
         this.props.history.push(ClientRoutes.Users + '/' + row.id);
    }

    handleCreateClick(e:any) {
        this.props.history.push(ClientRoutes.Users + '/create');
    }

    handleDeleteClick(e:any, row:Api.UserClientResponseModel) {
        axios.delete(Constants.ApiEndpoint + ApiRoutes.Users + '/' + row.id,
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
	   let searchEndpoint = Constants.ApiEndpoint + ApiRoutes.Users + '?limit=100';

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
		    let response = resp.data as Array<Api.UserClientResponseModel>;
		    let viewModels : Array<UserViewModel> = [];
			let mapper = new UserMapper();

			response.forEach(x =>
			{
				viewModels.push(mapper.mapApiResponseToViewModel(x));
			})

            this.setState({records:viewModels, filteredRecords:viewModels, loading:false, loaded:true, errorOccurred:false, errorMessage:''});

	   }, error => {
		   console.log(error);
		   this.setState({records:new Array<UserViewModel>(),filteredRecords:new Array<UserViewModel>(), loading:false, loaded:false, errorOccurred:true, errorMessage:'Error from API'});
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
                    Header: 'User',
                    columns: [
					  {
                      Header: 'AboutMe',
                      accessor: 'aboutMe',
                      Cell: (props) => {
                      return <span>{String(props.original.aboutMe)}</span>;
                      }           
                    },  {
                      Header: 'AccountId',
                      accessor: 'accountId',
                      Cell: (props) => {
                      return <span>{String(props.original.accountId)}</span>;
                      }           
                    },  {
                      Header: 'Age',
                      accessor: 'age',
                      Cell: (props) => {
                      return <span>{String(props.original.age)}</span>;
                      }           
                    },  {
                      Header: 'CreationDate',
                      accessor: 'creationDate',
                      Cell: (props) => {
                      return <span>{String(props.original.creationDate)}</span>;
                      }           
                    },  {
                      Header: 'DisplayName',
                      accessor: 'displayName',
                      Cell: (props) => {
                      return <span>{String(props.original.displayName)}</span>;
                      }           
                    },  {
                      Header: 'DownVotes',
                      accessor: 'downVote',
                      Cell: (props) => {
                      return <span>{String(props.original.downVote)}</span>;
                      }           
                    },  {
                      Header: 'EmailHash',
                      accessor: 'emailHash',
                      Cell: (props) => {
                      return <span>{String(props.original.emailHash)}</span>;
                      }           
                    },  {
                      Header: 'Id',
                      accessor: 'id',
                      Cell: (props) => {
                      return <span>{String(props.original.id)}</span>;
                      }           
                    },  {
                      Header: 'LastAccessDate',
                      accessor: 'lastAccessDate',
                      Cell: (props) => {
                      return <span>{String(props.original.lastAccessDate)}</span>;
                      }           
                    },  {
                      Header: 'Location',
                      accessor: 'location',
                      Cell: (props) => {
                      return <span>{String(props.original.location)}</span>;
                      }           
                    },  {
                      Header: 'Reputation',
                      accessor: 'reputation',
                      Cell: (props) => {
                      return <span>{String(props.original.reputation)}</span>;
                      }           
                    },  {
                      Header: 'UpVotes',
                      accessor: 'upVote',
                      Cell: (props) => {
                      return <span>{String(props.original.upVote)}</span>;
                      }           
                    },  {
                      Header: 'Views',
                      accessor: 'view',
                      Cell: (props) => {
                      return <span>{String(props.original.view)}</span>;
                      }           
                    },  {
                      Header: 'WebsiteUrl',
                      accessor: 'websiteUrl',
                      Cell: (props) => {
                      return <span>{String(props.original.websiteUrl)}</span>;
                      }           
                    },
                    {
                        Header: 'Actions',
                        Cell: row => (<div><button className="btn btn-sm" onClick={e => {this.handleDetailClick(e, row.original as Api.UserClientResponseModel)}} ><i className="fas fa-search"></i></button>
                        &nbsp;<button className="btn btn-primary btn-sm" onClick={e => {this.handleEditClick(e, row.original as Api.UserClientResponseModel)}} ><i className="fas fa-edit"></i></button>
                        &nbsp;<button className="btn btn-danger btn-sm" onClick={e => {this.handleDeleteClick(e, row.original as Api.UserClientResponseModel)}} ><i className="far fa-trash-alt"></i></button>
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
    <Hash>11df9a8dc23f1d0d13cee2845c1c788f</Hash>
</Codenesium>*/