import React, { Component, FormEvent } from 'react';
import axios from 'axios';
import { Constants, ApiRoutes, ClientRoutes } from '../../constants';
import * as Api from '../../api/models';
import TagsMapper from '../tags/tagsMapper';
import TagsViewModel from '../tags/tagsViewModel';
import { Form, Input, Button, Spin, Alert } from 'antd';
import { WrappedFormUtils } from 'antd/es/form/Form';
import ReactTable from "react-table";

interface TagsTableComponentProps {
  id:number,
  apiRoute:string;
  history: any;
  match: any;
}

interface TagsTableComponentState {
  loading: boolean;
  loaded: boolean;
  errorOccurred: boolean;
  errorMessage: string;
  filteredRecords : Array<TagsViewModel>;
}

export class  TagsTableComponent extends React.Component<
TagsTableComponentProps,
TagsTableComponentState
> {
  state = {
    loading: false,
    loaded: true,
    errorOccurred: false,
    errorMessage: '',
    filteredRecords:[]
  };

handleEditClick(e:any, row: TagsViewModel) {
  this.props.history.push(ClientRoutes.Tags + '/edit/' + row.id);
}

 handleDetailClick(e:any, row: TagsViewModel) {
   this.props.history.push(ClientRoutes.Tags + '/' + row.id);
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
          let response = resp.data as Array<Api.TagsClientResponseModel>;

          console.log(response);

          let mapper = new TagsMapper();
          
          let tags:Array<TagsViewModel> = [];

          response.forEach(x =>
          {
              tags.push(mapper.mapApiResponseToViewModel(x));
          });
          this.setState({
            ...this.state,
            filteredRecords: tags,
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
                    Header: 'Tags',
                    columns: [
					  {
                      Header: 'Count',
                      accessor: 'count',
                      Cell: (props) => {
                      return <span>{String(props.original.count)}</span>;
                      }           
                    },  {
                      Header: 'Excerpt Post',
                      accessor: 'excerptPostId',
                      Cell: (props) => {
                        return <a href='' onClick={(e) => { e.preventDefault(); this.props.history.push(ClientRoutes.Posts + '/' + props.original.excerptPostId); }}>
                          {String(
                            props.original.excerptPostIdNavigation.toDisplay()
                          )}
                        </a>
                      }           
                    },  {
                      Header: 'Tag Name',
                      accessor: 'tagName',
                      Cell: (props) => {
                      return <span>{String(props.original.tagName)}</span>;
                      }           
                    },  {
                      Header: 'Wiki Post',
                      accessor: 'wikiPostId',
                      Cell: (props) => {
                        return <a href='' onClick={(e) => { e.preventDefault(); this.props.history.push(ClientRoutes.Posts + '/' + props.original.wikiPostId); }}>
                          {String(
                            props.original.wikiPostIdNavigation.toDisplay()
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
                              row.original as TagsViewModel
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
                              row.original as TagsViewModel
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
    <Hash>bf01eec11f636f8c7542b7a447f87a53</Hash>
</Codenesium>*/