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
         this.props.history.push(ClientRoutes.Users + '/edit/' + row.userId);
    }

    handleDetailClick(e:any, row:Api.UserClientResponseModel) {
         this.props.history.push(ClientRoutes.Users + '/' + row.userId);
    }

    handleCreateClick(e:any) {
        this.props.history.push(ClientRoutes.Users + '/create');
    }

    handleDeleteClick(e:any, row:Api.UserClientResponseModel) {
        axios.delete(Constants.ApiEndpoint + ApiRoutes.Users + '/' + row.userId,
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
                      Header: 'Bio_img_url',
                      accessor: 'bioImgUrl',
                      Cell: (props) => {
                      return <span>{String(props.original.bioImgUrl)}</span>;
                      }           
                    },  {
                      Header: 'Birthday',
                      accessor: 'birthday',
                      Cell: (props) => {
                      return <span>{String(props.original.birthday)}</span>;
                      }           
                    },  {
                      Header: 'Content_description',
                      accessor: 'contentDescription',
                      Cell: (props) => {
                      return <span>{String(props.original.contentDescription)}</span>;
                      }           
                    },  {
                      Header: 'Email',
                      accessor: 'email',
                      Cell: (props) => {
                      return <span>{String(props.original.email)}</span>;
                      }           
                    },  {
                      Header: 'Full_name',
                      accessor: 'fullName',
                      Cell: (props) => {
                      return <span>{String(props.original.fullName)}</span>;
                      }           
                    },  {
                      Header: 'Header_img_url',
                      accessor: 'headerImgUrl',
                      Cell: (props) => {
                      return <span>{String(props.original.headerImgUrl)}</span>;
                      }           
                    },  {
                      Header: 'Interest',
                      accessor: 'interest',
                      Cell: (props) => {
                      return <span>{String(props.original.interest)}</span>;
                      }           
                    },  {
                      Header: 'Location_location_id',
                      accessor: 'locationLocationId',
                      Cell: (props) => {
                        return <a href='' onClick={(e) => { e.preventDefault(); this.props.history.push(ClientRoutes.Locations + '/' + props.original.locationLocationId); }}>
                          {String(
                            props.original.locationLocationIdNavigation.toDisplay()
                          )}
                        </a>
                      }           
                    },  {
                      Header: 'Password',
                      accessor: 'password',
                      Cell: (props) => {
                      return <span>{String(props.original.password)}</span>;
                      }           
                    },  {
                      Header: 'Phone_number',
                      accessor: 'phoneNumber',
                      Cell: (props) => {
                      return <span>{String(props.original.phoneNumber)}</span>;
                      }           
                    },  {
                      Header: 'Privacy',
                      accessor: 'privacy',
                      Cell: (props) => {
                      return <span>{String(props.original.privacy)}</span>;
                      }           
                    },  {
                      Header: 'Username',
                      accessor: 'username',
                      Cell: (props) => {
                      return <span>{String(props.original.username)}</span>;
                      }           
                    },  {
                      Header: 'Website',
                      accessor: 'website',
                      Cell: (props) => {
                      return <span>{String(props.original.website)}</span>;
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
    <Hash>aacc35139c18211e19d061ba964c02f8</Hash>
</Codenesium>*/