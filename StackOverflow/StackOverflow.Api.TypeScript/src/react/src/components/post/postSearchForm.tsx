import React, { Component, ReactElement, ReactHTMLElement } from 'react';
import axios from 'axios';
import { Redirect } from 'react-router-dom';
import * as Api from '../../api/models';
import PostMapper from './postMapper';
import { Constants, ApiRoutes, ClientRoutes } from '../../constants';
import ReactTable from "react-table";
import PostViewModel from './postViewModel';
import "react-table/react-table.css";
import { Form, Button, Input, Row, Col, Alert, Spin } from 'antd';
import { WrappedFormUtils } from 'antd/es/form/Form';

interface PostSearchComponentProps
{
     form:WrappedFormUtils;
	 history:any;
	 match:any;
}

interface PostSearchComponentState
{
    records:Array<PostViewModel>;
    filteredRecords:Array<PostViewModel>;
    loading:boolean;
    loaded:boolean;
    errorOccurred:boolean;
    errorMessage:string;
    searchValue:string;
    deleteSubmitted:boolean;
    deleteSuccess:boolean;
    deleteResponse:string;
}

export default class PostSearchComponent extends React.Component<PostSearchComponentProps, PostSearchComponentState> {

    state = ({deleteSubmitted:false, deleteSuccess:false, deleteResponse:'', records:new Array<PostViewModel>(), filteredRecords:new Array<PostViewModel>(), searchValue:'', loading:false, loaded:true, errorOccurred:false, errorMessage:''});
    
    componentDidMount () {
        this.loadRecords();
    }

    handleEditClick(e:any, row:PostViewModel) {
         this.props.history.push(ClientRoutes.Posts + '/edit/' + row.id);
    }

    handleDetailClick(e:any, row:PostViewModel) {
         this.props.history.push(ClientRoutes.Posts + '/' + row.id);
    }

    handleCreateClick(e:any) {
        this.props.history.push(ClientRoutes.Posts + '/create');
    }

    handleDeleteClick(e:any, row:Api.PostClientResponseModel) {
        axios.delete(Constants.ApiEndpoint + ApiRoutes.Posts + '/' + row.id,
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
	   let searchEndpoint = Constants.ApiEndpoint + ApiRoutes.Posts + '?limit=100';

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
		    let response = resp.data as Array<Api.PostClientResponseModel>;
		    let viewModels : Array<PostViewModel> = [];
			let mapper = new PostMapper();

			response.forEach(x =>
			{
				viewModels.push(mapper.mapApiResponseToViewModel(x));
			})

            this.setState({records:viewModels, filteredRecords:viewModels, loading:false, loaded:true, errorOccurred:false, errorMessage:''});

	   }, error => {
		   console.log(error);
		   this.setState({records:new Array<PostViewModel>(), filteredRecords:new Array<PostViewModel>(), loading:false, loaded:true, errorOccurred:true, errorMessage:'Error from API'});
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
                    Header: 'Posts',
                    columns: [
					  {
                      Header: 'AcceptedAnswerId',
                      accessor: 'acceptedAnswerId',
                      Cell: (props) => {
                      return <span>{String(props.original.acceptedAnswerId)}</span>;
                      }           
                    },  {
                      Header: 'AnswerCount',
                      accessor: 'answerCount',
                      Cell: (props) => {
                      return <span>{String(props.original.answerCount)}</span>;
                      }           
                    },  {
                      Header: 'Body',
                      accessor: 'body',
                      Cell: (props) => {
                      return <span>{String(props.original.body)}</span>;
                      }           
                    },  {
                      Header: 'ClosedDate',
                      accessor: 'closedDate',
                      Cell: (props) => {
                      return <span>{String(props.original.closedDate)}</span>;
                      }           
                    },  {
                      Header: 'CommentCount',
                      accessor: 'commentCount',
                      Cell: (props) => {
                      return <span>{String(props.original.commentCount)}</span>;
                      }           
                    },  {
                      Header: 'CommunityOwnedDate',
                      accessor: 'communityOwnedDate',
                      Cell: (props) => {
                      return <span>{String(props.original.communityOwnedDate)}</span>;
                      }           
                    },  {
                      Header: 'CreationDate',
                      accessor: 'creationDate',
                      Cell: (props) => {
                      return <span>{String(props.original.creationDate)}</span>;
                      }           
                    },  {
                      Header: 'FavoriteCount',
                      accessor: 'favoriteCount',
                      Cell: (props) => {
                      return <span>{String(props.original.favoriteCount)}</span>;
                      }           
                    },  {
                      Header: 'LastActivityDate',
                      accessor: 'lastActivityDate',
                      Cell: (props) => {
                      return <span>{String(props.original.lastActivityDate)}</span>;
                      }           
                    },  {
                      Header: 'LastEditDate',
                      accessor: 'lastEditDate',
                      Cell: (props) => {
                      return <span>{String(props.original.lastEditDate)}</span>;
                      }           
                    },  {
                      Header: 'LastEditorDisplayName',
                      accessor: 'lastEditorDisplayName',
                      Cell: (props) => {
                      return <span>{String(props.original.lastEditorDisplayName)}</span>;
                      }           
                    },  {
                      Header: 'LastEditorUserId',
                      accessor: 'lastEditorUserId',
                      Cell: (props) => {
                      return <span>{String(props.original.lastEditorUserId)}</span>;
                      }           
                    },  {
                      Header: 'OwnerUserId',
                      accessor: 'ownerUserId',
                      Cell: (props) => {
                      return <span>{String(props.original.ownerUserId)}</span>;
                      }           
                    },  {
                      Header: 'ParentId',
                      accessor: 'parentId',
                      Cell: (props) => {
                      return <span>{String(props.original.parentId)}</span>;
                      }           
                    },  {
                      Header: 'PostTypeId',
                      accessor: 'postTypeId',
                      Cell: (props) => {
                      return <span>{String(props.original.postTypeId)}</span>;
                      }           
                    },  {
                      Header: 'Score',
                      accessor: 'score',
                      Cell: (props) => {
                      return <span>{String(props.original.score)}</span>;
                      }           
                    },  {
                      Header: 'Tags',
                      accessor: 'tag',
                      Cell: (props) => {
                      return <span>{String(props.original.tag)}</span>;
                      }           
                    },  {
                      Header: 'Title',
                      accessor: 'title',
                      Cell: (props) => {
                      return <span>{String(props.original.title)}</span>;
                      }           
                    },  {
                      Header: 'ViewCount',
                      accessor: 'viewCount',
                      Cell: (props) => {
                      return <span>{String(props.original.viewCount)}</span>;
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
                              row.original as PostViewModel
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
                              row.original as PostViewModel
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
                              row.original as PostViewModel
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

export const WrappedPostSearchComponent = Form.create({ name: 'Post Search' })(PostSearchComponent);

/*<Codenesium>
    <Hash>252a538966922ea9ad4888426b1f9eb3</Hash>
</Codenesium>*/