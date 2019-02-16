import React, { Component, ReactElement, ReactHTMLElement } from 'react';
import axios from 'axios';
import { Redirect } from 'react-router-dom';
import * as Api from '../../api/models';
import PostMapper from './postMapper';
import { Constants, ApiRoutes, ClientRoutes } from '../../constants';
import { LoadingForm } from '../../lib/components/loadingForm'
import { ErrorForm } from '../../lib/components/errorForm'
import ReactTable from "react-table";
import PostViewModel from './postViewModel';
import "react-table/react-table.css";

interface PostSearchComponentProps
{
    history:any;
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

    handleEditClick(e:any, row:Api.PostClientResponseModel) {
         this.props.history.push(ClientRoutes.Posts + '/edit/' + row.id);
    }

    handleDetailClick(e:any, row:Api.PostClientResponseModel) {
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
		   this.setState({records:new Array<PostViewModel>(),filteredRecords:new Array<PostViewModel>(), loading:false, loaded:false, errorOccurred:true, errorMessage:'Error from API'});
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
                    Header: 'Post',
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
                      Header: 'Id',
                      accessor: 'id',
                      Cell: (props) => {
                      return <span>{String(props.original.id)}</span>;
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
                        Cell: row => (<div><button className="btn btn-sm" onClick={e => {this.handleDetailClick(e, row.original as Api.PostClientResponseModel)}} ><i className="fas fa-search"></i></button>
                        &nbsp;<button className="btn btn-primary btn-sm" onClick={e => {this.handleEditClick(e, row.original as Api.PostClientResponseModel)}} ><i className="fas fa-edit"></i></button>
                        &nbsp;<button className="btn btn-danger btn-sm" onClick={e => {this.handleDeleteClick(e, row.original as Api.PostClientResponseModel)}} ><i className="far fa-trash-alt"></i></button>
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
    <Hash>7b1b7c1430fda439411947f13f8a3245</Hash>
</Codenesium>*/