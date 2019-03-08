import React, { Component, ReactElement, ReactHTMLElement } from 'react';
import axios from 'axios';
import { Redirect } from 'react-router-dom';
import * as Api from '../../api/models';
import UsersMapper from './usersMapper';
import { Constants, ApiRoutes, ClientRoutes } from '../../constants';
import ReactTable from "react-table";
import UsersViewModel from './usersViewModel';
import "react-table/react-table.css";
import { Form, Button, Input, Row, Col, Alert, Spin } from 'antd';
import { WrappedFormUtils } from 'antd/es/form/Form';

interface UsersSearchComponentProps
{
     form:WrappedFormUtils;
	 history:any;
	 match:any;
}

interface UsersSearchComponentState
{
    records:Array<UsersViewModel>;
    filteredRecords:Array<UsersViewModel>;
    loading:boolean;
    loaded:boolean;
    errorOccurred:boolean;
    errorMessage:string;
    searchValue:string;
    deleteSubmitted:boolean;
    deleteSuccess:boolean;
    deleteResponse:string;
}

export default class UsersSearchComponent extends React.Component<UsersSearchComponentProps, UsersSearchComponentState> {

    state = ({deleteSubmitted:false, deleteSuccess:false, deleteResponse:'', records:new Array<UsersViewModel>(), filteredRecords:new Array<UsersViewModel>(), searchValue:'', loading:false, loaded:true, errorOccurred:false, errorMessage:''});
    
    componentDidMount () {
        this.loadRecords();
    }

    handleEditClick(e:any, row:UsersViewModel) {
         this.props.history.push(ClientRoutes.Users + '/edit/' + row.id);
    }

    handleDetailClick(e:any, row:UsersViewModel) {
         this.props.history.push(ClientRoutes.Users + '/' + row.id);
    }

    handleCreateClick(e:any) {
        this.props.history.push(ClientRoutes.Users + '/create');
    }

    handleDeleteClick(e:any, row:Api.UsersClientResponseModel) {
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
		    let response = resp.data as Array<Api.UsersClientResponseModel>;
		    let viewModels : Array<UsersViewModel> = [];
			let mapper = new UsersMapper();

			response.forEach(x =>
			{
				viewModels.push(mapper.mapApiResponseToViewModel(x));
			})

            this.setState({records:viewModels, filteredRecords:viewModels, loading:false, loaded:true, errorOccurred:false, errorMessage:''});

	   }, error => {
		   console.log(error);
		   this.setState({records:new Array<UsersViewModel>(), filteredRecords:new Array<UsersViewModel>(), loading:false, loaded:true, errorOccurred:true, errorMessage:'Error from API'});
	   })
    }

    filterGrid() {

    }
    
    render () {
        if(this.state.loading) {
            return <Spin size="large" />;
        } 
		else if(this.state.errorOccurred) {
            return <Alert message={this.state.errorMessage} type="error" />
        }
        else if(this.state.loaded) {

            let errorResponse:JSX.Element = <span></span>;

            if (this.state.deleteSubmitted) {
				if (this.state.deleteSuccess) {
				  errorResponse = (
					<Alert message={this.state.deleteResponse} type="success" style={{marginBottom:"25px"}} />
				  );
				} else {
				  errorResponse = (
					<Alert message={this.state.deleteResponse} type="error" style={{marginBottom:"25px"}} />
				  );
				}
			}
            
			return (
            <div>
            {errorResponse}
            <Row>
				<Col span={8}></Col>
				<Col span={8}>   
				   <Input 
					placeholder={"Search"} 
					id={"search"} 
					onChange={(e:any) => {
					  this.handleSearchChanged(e)
				   }}/>
				</Col>
				<Col span={8}>  
				  <Button 
				  style={{'float':'right'}}
				  type="primary" 
				  onClick={(e:any) => {
                        this.handleCreateClick(e)
						}}
				  >
				  +
				  </Button>
				</Col>
			</Row>
			<br />
			<br />
            <ReactTable 
                data={this.state.filteredRecords}
                columns={[{
                    Header: 'Users',
                    columns: [
					  {
                      Header: 'About Me',
                      accessor: 'aboutMe',
                      Cell: (props) => {
                      return <span>{String(props.original.aboutMe)}</span>;
                      }           
                    },  {
                      Header: 'Account',
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
                      Header: 'Creation Date',
                      accessor: 'creationDate',
                      Cell: (props) => {
                      return <span>{String(props.original.creationDate)}</span>;
                      }           
                    },  {
                      Header: 'Display Name',
                      accessor: 'displayName',
                      Cell: (props) => {
                      return <span>{String(props.original.displayName)}</span>;
                      }           
                    },  {
                      Header: 'Down Vote',
                      accessor: 'downVote',
                      Cell: (props) => {
                      return <span>{String(props.original.downVote)}</span>;
                      }           
                    },  {
                      Header: 'Email Hash',
                      accessor: 'emailHash',
                      Cell: (props) => {
                      return <span>{String(props.original.emailHash)}</span>;
                      }           
                    },  {
                      Header: 'Last Access Date',
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
                      Header: 'Up Vote',
                      accessor: 'upVote',
                      Cell: (props) => {
                      return <span>{String(props.original.upVote)}</span>;
                      }           
                    },  {
                      Header: 'View',
                      accessor: 'view',
                      Cell: (props) => {
                      return <span>{String(props.original.view)}</span>;
                      }           
                    },  {
                      Header: 'Website Url',
                      accessor: 'websiteUrl',
                      Cell: (props) => {
                      return <span>{String(props.original.websiteUrl)}</span>;
                      }           
                    },
                    {
                        Header: 'Actions',
					    minWidth:150,
                        Cell: row => (<div>
					    <Button
                          type="primary" 
                          onClick={(e:any) => {
                            this.handleDetailClick(
                              e,
                              row.original as UsersViewModel
                            );
                          }}
                        >
                          <i className="fas fa-search" />
                        </Button>
                        &nbsp;
                        <Button
                          type="primary" 
                          onClick={(e:any) => {
                            this.handleEditClick(
                              e,
                              row.original as UsersViewModel
                            );
                          }}
                        >
                          <i className="fas fa-edit" />
                        </Button>
                        &nbsp;
                        <Button
                          type="danger" 
                          onClick={(e:any) => {
                            this.handleDeleteClick(
                              e,
                              row.original as UsersViewModel
                            );
                          }}
                        >
                          <i className="far fa-trash-alt" />
                        </Button>

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

export const WrappedUsersSearchComponent = Form.create({ name: 'Users Search' })(UsersSearchComponent);

/*<Codenesium>
    <Hash>3e4beb2680da5f3617f1bebcf382e44a</Hash>
</Codenesium>*/