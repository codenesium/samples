import React, { Component, FormEvent } from 'react';
import axios from 'axios';
import { Constants, ApiRoutes, ClientRoutes } from '../../constants';
import * as Api from '../../api/models';
import PostMapper from '../post/postMapper';
import PostViewModel from '../post/postViewModel';
import { Form, Input, Button, Spin, Alert } from 'antd';
import { WrappedFormUtils } from 'antd/es/form/Form';
import ReactTable from "react-table";

interface PostTableComponentProps {
  id:number,
  apiRoute:string;
  history: any;
  match: any;
}

interface PostTableComponentState {
  loading: boolean;
  loaded: boolean;
  errorOccurred: boolean;
  errorMessage: string;
  filteredRecords : Array<PostViewModel>;
}

export class  PostTableComponent extends React.Component<
PostTableComponentProps,
PostTableComponentState
> {
  state = {
    loading: false,
    loaded: true,
    errorOccurred: false,
    errorMessage: '',
    filteredRecords:[]
  };

handleEditClick(e:any, row: PostViewModel) {
  this.props.history.push(ClientRoutes.Posts + '/edit/' + row.id);
}

handleDetailClick(e:any, row: PostViewModel) {
  this.props.history.push(ClientRoutes.Posts + '/' + row.id);
}

  componentDidMount() {
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
          let response = resp.data as Array<Api.PostClientResponseModel>;

          console.log(response);

          let mapper = new PostMapper();
          
          let posts:Array<PostViewModel> = [];

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
    <Hash>a97a97bf372a7ecc40290fa03de53032</Hash>
</Codenesium>*/