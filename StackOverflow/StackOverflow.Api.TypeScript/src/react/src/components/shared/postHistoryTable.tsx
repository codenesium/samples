import React, { Component, FormEvent } from 'react';
import axios from 'axios';
import { Constants, ApiRoutes, ClientRoutes } from '../../constants';
import * as Api from '../../api/models';
import PostHistoryMapper from '../postHistory/postHistoryMapper';
import PostHistoryViewModel from '../postHistory/postHistoryViewModel';
import { Form, Input, Button, Spin, Alert } from 'antd';
import { WrappedFormUtils } from 'antd/es/form/Form';
import ReactTable from "react-table";

interface PostHistoryTableComponentProps {
  id:number,
  apiRoute:string;
  history: any;
  match: any;
}

interface PostHistoryTableComponentState {
  loading: boolean;
  loaded: boolean;
  errorOccurred: boolean;
  errorMessage: string;
  filteredRecords : Array<PostHistoryViewModel>;
}

export class  PostHistoryTableComponent extends React.Component<
PostHistoryTableComponentProps,
PostHistoryTableComponentState
> {
  state = {
    loading: false,
    loaded: true,
    errorOccurred: false,
    errorMessage: '',
    filteredRecords:[]
  };

handleEditClick(e:any, row: PostHistoryViewModel) {
  this.props.history.push(ClientRoutes.PostHistories + '/edit/' + row.id);
}

handleDetailClick(e:any, row: PostHistoryViewModel) {
  this.props.history.push(ClientRoutes.PostHistories + '/' + row.id);
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
          let response = resp.data as Array<Api.PostHistoryClientResponseModel>;

          console.log(response);

          let mapper = new PostHistoryMapper();
          
          let postHistories:Array<PostHistoryViewModel> = [];

          response.forEach(x =>
          {
              postHistories.push(mapper.mapApiResponseToViewModel(x));
          });
          this.setState({
            ...this.state,
            filteredRecords: postHistories,
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
                    Header: 'PostHistories',
                    columns: [
					  {
                      Header: 'Comment',
                      accessor: 'comment',
                      Cell: (props) => {
                      return <span>{String(props.original.comment)}</span>;
                      }           
                    },  {
                      Header: 'CreationDate',
                      accessor: 'creationDate',
                      Cell: (props) => {
                      return <span>{String(props.original.creationDate)}</span>;
                      }           
                    },  {
                      Header: 'PostHistoryTypeId',
                      accessor: 'postHistoryTypeId',
                      Cell: (props) => {
                      return <span>{String(props.original.postHistoryTypeId)}</span>;
                      }           
                    },  {
                      Header: 'PostId',
                      accessor: 'postId',
                      Cell: (props) => {
                      return <span>{String(props.original.postId)}</span>;
                      }           
                    },  {
                      Header: 'RevisionGUID',
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
                      Header: 'UserDisplayName',
                      accessor: 'userDisplayName',
                      Cell: (props) => {
                      return <span>{String(props.original.userDisplayName)}</span>;
                      }           
                    },  {
                      Header: 'UserId',
                      accessor: 'userId',
                      Cell: (props) => {
                      return <span>{String(props.original.userId)}</span>;
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
    <Hash>7c6dbf0d614fcd7431f09d77f5db12f5</Hash>
</Codenesium>*/