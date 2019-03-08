import React, { Component, ReactElement, ReactHTMLElement } from 'react';
import axios from 'axios';
import { Redirect } from 'react-router-dom';
import * as Api from '../../api/models';
import PostHistoryMapper from './postHistoryMapper';
import { Constants, ApiRoutes, ClientRoutes } from '../../constants';
import ReactTable from "react-table";
import PostHistoryViewModel from './postHistoryViewModel';
import "react-table/react-table.css";
import { Form, Button, Input, Row, Col, Alert, Spin } from 'antd';
import { WrappedFormUtils } from 'antd/es/form/Form';

interface PostHistorySearchComponentProps
{
     form:WrappedFormUtils;
	 history:any;
	 match:any;
}

interface PostHistorySearchComponentState
{
    records:Array<PostHistoryViewModel>;
    filteredRecords:Array<PostHistoryViewModel>;
    loading:boolean;
    loaded:boolean;
    errorOccurred:boolean;
    errorMessage:string;
    searchValue:string;
    deleteSubmitted:boolean;
    deleteSuccess:boolean;
    deleteResponse:string;
}

export default class PostHistorySearchComponent extends React.Component<PostHistorySearchComponentProps, PostHistorySearchComponentState> {

    state = ({deleteSubmitted:false, deleteSuccess:false, deleteResponse:'', records:new Array<PostHistoryViewModel>(), filteredRecords:new Array<PostHistoryViewModel>(), searchValue:'', loading:false, loaded:true, errorOccurred:false, errorMessage:''});
    
    componentDidMount () {
        this.loadRecords();
    }

    handleEditClick(e:any, row:PostHistoryViewModel) {
         this.props.history.push(ClientRoutes.PostHistory + '/edit/' + row.id);
    }

    handleDetailClick(e:any, row:PostHistoryViewModel) {
         this.props.history.push(ClientRoutes.PostHistory + '/' + row.id);
    }

    handleCreateClick(e:any) {
        this.props.history.push(ClientRoutes.PostHistory + '/create');
    }

    handleDeleteClick(e:any, row:Api.PostHistoryClientResponseModel) {
        axios.delete(Constants.ApiEndpoint + ApiRoutes.PostHistory + '/' + row.id,
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
	   let searchEndpoint = Constants.ApiEndpoint + ApiRoutes.PostHistory + '?limit=100';

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
		    let response = resp.data as Array<Api.PostHistoryClientResponseModel>;
		    let viewModels : Array<PostHistoryViewModel> = [];
			let mapper = new PostHistoryMapper();

			response.forEach(x =>
			{
				viewModels.push(mapper.mapApiResponseToViewModel(x));
			})

            this.setState({records:viewModels, filteredRecords:viewModels, loading:false, loaded:true, errorOccurred:false, errorMessage:''});

	   }, error => {
		   console.log(error);
		   this.setState({records:new Array<PostHistoryViewModel>(), filteredRecords:new Array<PostHistoryViewModel>(), loading:false, loaded:true, errorOccurred:true, errorMessage:'Error from API'});
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
                    Header: 'Post History',
                    columns: [
					  {
                      Header: 'Comment',
                      accessor: 'comment',
                      Cell: (props) => {
                      return <span>{String(props.original.comment)}</span>;
                      }           
                    },  {
                      Header: 'Creation Date',
                      accessor: 'creationDate',
                      Cell: (props) => {
                      return <span>{String(props.original.creationDate)}</span>;
                      }           
                    },  {
                      Header: 'Post History Type',
                      accessor: 'postHistoryTypeId',
                      Cell: (props) => {
                        return <a href='' onClick={(e) => { e.preventDefault(); this.props.history.push(ClientRoutes.PostHistoryTypes + '/' + props.original.postHistoryTypeId); }}>
                          {String(
                            props.original.postHistoryTypeIdNavigation.toDisplay()
                          )}
                        </a>
                      }           
                    },  {
                      Header: 'Post',
                      accessor: 'postId',
                      Cell: (props) => {
                        return <a href='' onClick={(e) => { e.preventDefault(); this.props.history.push(ClientRoutes.Posts + '/' + props.original.postId); }}>
                          {String(
                            props.original.postIdNavigation.toDisplay()
                          )}
                        </a>
                      }           
                    },  {
                      Header: 'Revision GUID',
                      accessor: 'revisionGUID',
                      Cell: (props) => {
                      return <span>{String(props.original.revisionGUID)}</span>;
                      }           
                    },  {
                      Header: 'Text',
                      accessor: 'text',
                      Cell: (props) => {
                      return <span>{String(props.original.text)}</span>;
                      }           
                    },  {
                      Header: 'User Display Name',
                      accessor: 'userDisplayName',
                      Cell: (props) => {
                      return <span>{String(props.original.userDisplayName)}</span>;
                      }           
                    },  {
                      Header: 'User',
                      accessor: 'userId',
                      Cell: (props) => {
                        return <a href='' onClick={(e) => { e.preventDefault(); this.props.history.push(ClientRoutes.Users + '/' + props.original.userId); }}>
                          {String(
                            props.original.userIdNavigation.toDisplay()
                          )}
                        </a>
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
                              row.original as PostHistoryViewModel
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
                              row.original as PostHistoryViewModel
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
                              row.original as PostHistoryViewModel
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

export const WrappedPostHistorySearchComponent = Form.create({ name: 'PostHistory Search' })(PostHistorySearchComponent);

/*<Codenesium>
    <Hash>a8ad43c0a55219d1f4e3740c765fdf2f</Hash>
</Codenesium>*/