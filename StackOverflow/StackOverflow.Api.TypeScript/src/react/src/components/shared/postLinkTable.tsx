import React, { Component, FormEvent } from 'react';
import axios from 'axios';
import { Constants, ApiRoutes, ClientRoutes } from '../../constants';
import * as Api from '../../api/models';
import PostLinkMapper from '../postLink/postLinkMapper';
import PostLinkViewModel from '../postLink/postLinkViewModel';
import { Form, Input, Button, Spin, Alert } from 'antd';
import { WrappedFormUtils } from 'antd/es/form/Form';
import ReactTable from "react-table";

interface PostLinkTableComponentProps {
  id:number,
  apiRoute:string;
  history: any;
  match: any;
}

interface PostLinkTableComponentState {
  loading: boolean;
  loaded: boolean;
  errorOccurred: boolean;
  errorMessage: string;
  filteredRecords : Array<PostLinkViewModel>;
}

export class  PostLinkTableComponent extends React.Component<
PostLinkTableComponentProps,
PostLinkTableComponentState
> {
  state = {
    loading: false,
    loaded: true,
    errorOccurred: false,
    errorMessage: '',
    filteredRecords:[]
  };

handleEditClick(e:any, row: PostLinkViewModel) {
  this.props.history.push(ClientRoutes.PostLinks + '/edit/' + row.id);
}

handleDetailClick(e:any, row: PostLinkViewModel) {
  this.props.history.push(ClientRoutes.PostLinks + '/' + row.id);
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
          let response = resp.data as Array<Api.PostLinkClientResponseModel>;

          console.log(response);

          let mapper = new PostLinkMapper();
          
          let postLinks:Array<PostLinkViewModel> = [];

          response.forEach(x =>
          {
              postLinks.push(mapper.mapApiResponseToViewModel(x));
          });
          this.setState({
            ...this.state,
            filteredRecords: postLinks,
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
                    Header: 'PostLinks',
                    columns: [
					  {
                      Header: 'CreationDate',
                      accessor: 'creationDate',
                      Cell: (props) => {
                      return <span>{String(props.original.creationDate)}</span>;
                      }           
                    },  {
                      Header: 'LinkTypeId',
                      accessor: 'linkTypeId',
                      Cell: (props) => {
                      return <span>{String(props.original.linkTypeId)}</span>;
                      }           
                    },  {
                      Header: 'PostId',
                      accessor: 'postId',
                      Cell: (props) => {
                      return <span>{String(props.original.postId)}</span>;
                      }           
                    },  {
                      Header: 'RelatedPostId',
                      accessor: 'relatedPostId',
                      Cell: (props) => {
                      return <span>{String(props.original.relatedPostId)}</span>;
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
                              row.original as PostLinkViewModel
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
                              row.original as PostLinkViewModel
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
    <Hash>47595fdd1141e3b2dec2331f1e6157f4</Hash>
</Codenesium>*/