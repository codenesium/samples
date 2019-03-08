import React, { Component, FormEvent } from 'react';
import axios from 'axios';
import { Constants, ApiRoutes, ClientRoutes } from '../../constants';
import * as Api from '../../api/models';
import PostsMapper from '../posts/postsMapper';
import PostsViewModel from '../posts/postsViewModel';
import { Form, Input, Button, Spin, Alert } from 'antd';
import { WrappedFormUtils } from 'antd/es/form/Form';
import ReactTable from "react-table";

interface PostsTableComponentProps {
  id:number,
  apiRoute:string;
  history: any;
  match: any;
}

interface PostsTableComponentState {
  loading: boolean;
  loaded: boolean;
  errorOccurred: boolean;
  errorMessage: string;
  filteredRecords : Array<PostsViewModel>;
}

export class  PostsTableComponent extends React.Component<
PostsTableComponentProps,
PostsTableComponentState
> {
  state = {
    loading: false,
    loaded: true,
    errorOccurred: false,
    errorMessage: '',
    filteredRecords:[]
  };

handleEditClick(e:any, row: PostsViewModel) {
  this.props.history.push(ClientRoutes.Posts + '/edit/' + row.id);
}

 handleDetailClick(e:any, row: PostsViewModel) {
   this.props.history.push(ClientRoutes.Posts + '/' + row.id);
 }

  componentDidMount() {
	this.loadRecords();
  }

  loadRecords() {
    this.setState({ ...this.state, loading: true });

    axios
      .get(this.props.apiRoute,
        {
          headers: {
            'Content-Type': 'application/json',
          },
        }
      )
      .then(
        resp => {
          let response = resp.data as Array<Api.PostsClientResponseModel>;

          console.log(response);

          let mapper = new PostsMapper();
          
          let posts:Array<PostsViewModel> = [];

          response.forEach(x =>
          {
              posts.push(mapper.mapApiResponseToViewModel(x));
          });
          this.setState({
            ...this.state,
            filteredRecords: posts,
            loading: false,
            loaded: true,
            errorOccurred: false,
            errorMessage: '',
          });
        },
        error => {
          console.log(error);
          this.setState({
            ...this.state,
            loading: false,
            loaded: false,
            errorOccurred: true,
            errorMessage: 'Error from API',
          });
        }
      );
  }

  render() {
    
	let message: JSX.Element = <div />;
    if (this.state.errorOccurred) {
      message = <Alert message={this.state.errorMessage} type="error" />;
    }

    if (this.state.loading) {
       return <Spin size="large" />;
    }
	else if (this.state.errorOccurred) {
	  return <Alert message={this.state.errorMessage} type='error' />;
	}
	 else if (this.state.loaded) {
      return (
	  <div>
		{message}
         <ReactTable 
                data={this.state.filteredRecords}
				defaultPageSize={10}
                columns={[{
                    Header: 'Posts',
                    columns: [
					  {
                      Header: 'Accepted Answer',
                      accessor: 'acceptedAnswerId',
                      Cell: (props) => {
                      return <span>{String(props.original.acceptedAnswerId)}</span>;
                      }           
                    },  {
                      Header: 'Answer Count',
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
                      Header: 'Closed Date',
                      accessor: 'closedDate',
                      Cell: (props) => {
                      return <span>{String(props.original.closedDate)}</span>;
                      }           
                    },  {
                      Header: 'Comment Count',
                      accessor: 'commentCount',
                      Cell: (props) => {
                      return <span>{String(props.original.commentCount)}</span>;
                      }           
                    },  {
                      Header: 'Community Owned Date',
                      accessor: 'communityOwnedDate',
                      Cell: (props) => {
                      return <span>{String(props.original.communityOwnedDate)}</span>;
                      }           
                    },  {
                      Header: 'Creation Date',
                      accessor: 'creationDate',
                      Cell: (props) => {
                      return <span>{String(props.original.creationDate)}</span>;
                      }           
                    },  {
                      Header: 'Favorite Count',
                      accessor: 'favoriteCount',
                      Cell: (props) => {
                      return <span>{String(props.original.favoriteCount)}</span>;
                      }           
                    },  {
                      Header: 'Last Activity Date',
                      accessor: 'lastActivityDate',
                      Cell: (props) => {
                      return <span>{String(props.original.lastActivityDate)}</span>;
                      }           
                    },  {
                      Header: 'Last Edit Date',
                      accessor: 'lastEditDate',
                      Cell: (props) => {
                      return <span>{String(props.original.lastEditDate)}</span>;
                      }           
                    },  {
                      Header: 'Last Editor Display Name',
                      accessor: 'lastEditorDisplayName',
                      Cell: (props) => {
                      return <span>{String(props.original.lastEditorDisplayName)}</span>;
                      }           
                    },  {
                      Header: 'Last Editor User',
                      accessor: 'lastEditorUserId',
                      Cell: (props) => {
                        return <a href='' onClick={(e) => { e.preventDefault(); this.props.history.push(ClientRoutes.Users + '/' + props.original.lastEditorUserId); }}>
                          {String(
                            props.original.lastEditorUserIdNavigation.toDisplay()
                          )}
                        </a>
                      }           
                    },  {
                      Header: 'Owner User',
                      accessor: 'ownerUserId',
                      Cell: (props) => {
                        return <a href='' onClick={(e) => { e.preventDefault(); this.props.history.push(ClientRoutes.Users + '/' + props.original.ownerUserId); }}>
                          {String(
                            props.original.ownerUserIdNavigation.toDisplay()
                          )}
                        </a>
                      }           
                    },  {
                      Header: 'Parent',
                      accessor: 'parentId',
                      Cell: (props) => {
                        return <a href='' onClick={(e) => { e.preventDefault(); this.props.history.push(ClientRoutes.Posts + '/' + props.original.parentId); }}>
                          {String(
                            props.original.parentIdNavigation.toDisplay()
                          )}
                        </a>
                      }           
                    },  {
                      Header: 'Post Type',
                      accessor: 'postTypeId',
                      Cell: (props) => {
                        return <a href='' onClick={(e) => { e.preventDefault(); this.props.history.push(ClientRoutes.PostTypes + '/' + props.original.postTypeId); }}>
                          {String(
                            props.original.postTypeIdNavigation.toDisplay()
                          )}
                        </a>
                      }           
                    },  {
                      Header: 'Score',
                      accessor: 'score',
                      Cell: (props) => {
                      return <span>{String(props.original.score)}</span>;
                      }           
                    },  {
                      Header: 'Tag',
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
                      Header: 'View Count',
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
                              row.original as PostsViewModel
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
                              row.original as PostsViewModel
                            );
                          }}
                        >
                          <i className="fas fa-edit" />
                        </Button>
                        </div>)
                    }],
                    
                  }]} />
			</div>
      );
    } else {
      return null;
    }
  }
}

/*<Codenesium>
    <Hash>2297be909cdecb2005e9d6ae3ebef99f</Hash>
</Codenesium>*/