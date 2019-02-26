import React, { Component, ReactElement, ReactHTMLElement } from 'react';
import axios from 'axios';
import { Redirect } from 'react-router-dom';
import * as Api from '../../api/models';
import TweetMapper from './tweetMapper';
import { Constants, ApiRoutes, ClientRoutes } from '../../constants';
import ReactTable from "react-table";
import TweetViewModel from './tweetViewModel';
import "react-table/react-table.css";
import { Form, Button, Input, Row, Col, Alert, Spin } from 'antd';
import { WrappedFormUtils } from 'antd/es/form/Form';

interface TweetSearchComponentProps
{
     form:WrappedFormUtils;
	 history:any;
	 match:any;
}

interface TweetSearchComponentState
{
    records:Array<TweetViewModel>;
    filteredRecords:Array<TweetViewModel>;
    loading:boolean;
    loaded:boolean;
    errorOccurred:boolean;
    errorMessage:string;
    searchValue:string;
    deleteSubmitted:boolean;
    deleteSuccess:boolean;
    deleteResponse:string;
}

export default class TweetSearchComponent extends React.Component<TweetSearchComponentProps, TweetSearchComponentState> {

    state = ({deleteSubmitted:false, deleteSuccess:false, deleteResponse:'', records:new Array<TweetViewModel>(), filteredRecords:new Array<TweetViewModel>(), searchValue:'', loading:false, loaded:true, errorOccurred:false, errorMessage:''});
    
    componentDidMount () {
        this.loadRecords();
    }

    handleEditClick(e:any, row:TweetViewModel) {
         this.props.history.push(ClientRoutes.Tweets + '/edit/' + row.tweetId);
    }

    handleDetailClick(e:any, row:TweetViewModel) {
         this.props.history.push(ClientRoutes.Tweets + '/' + row.tweetId);
    }

    handleCreateClick(e:any) {
        this.props.history.push(ClientRoutes.Tweets + '/create');
    }

    handleDeleteClick(e:any, row:Api.TweetClientResponseModel) {
        axios.delete(Constants.ApiEndpoint + ApiRoutes.Tweets + '/' + row.tweetId,
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
	   let searchEndpoint = Constants.ApiEndpoint + ApiRoutes.Tweets + '?limit=100';

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
		    let response = resp.data as Array<Api.TweetClientResponseModel>;
		    let viewModels : Array<TweetViewModel> = [];
			let mapper = new TweetMapper();

			response.forEach(x =>
			{
				viewModels.push(mapper.mapApiResponseToViewModel(x));
			})

            this.setState({records:viewModels, filteredRecords:viewModels, loading:false, loaded:true, errorOccurred:false, errorMessage:''});

	   }, error => {
		   console.log(error);
		   this.setState({records:new Array<TweetViewModel>(), filteredRecords:new Array<TweetViewModel>(), loading:false, loaded:true, errorOccurred:true, errorMessage:'Error from API'});
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
                    Header: 'Tweets',
                    columns: [
					  {
                      Header: 'Content',
                      accessor: 'content',
                      Cell: (props) => {
                      return <span>{String(props.original.content)}</span>;
                      }           
                    },  {
                      Header: 'Date',
                      accessor: 'date',
                      Cell: (props) => {
                      return <span>{String(props.original.date)}</span>;
                      }           
                    },  {
                      Header: 'Location_id',
                      accessor: 'locationId',
                      Cell: (props) => {
                        return <a href='' onClick={(e) => { e.preventDefault(); this.props.history.push(ClientRoutes.Locations + '/' + props.original.locationId); }}>
                          {String(
                            props.original.locationIdNavigation.toDisplay()
                          )}
                        </a>
                      }           
                    },  {
                      Header: 'Time',
                      accessor: 'time',
                      Cell: (props) => {
                      return <span>{String(props.original.time)}</span>;
                      }           
                    },  {
                      Header: 'User_user_id',
                      accessor: 'userUserId',
                      Cell: (props) => {
                        return <a href='' onClick={(e) => { e.preventDefault(); this.props.history.push(ClientRoutes.Users + '/' + props.original.userUserId); }}>
                          {String(
                            props.original.userUserIdNavigation.toDisplay()
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
                              row.original as TweetViewModel
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
                              row.original as TweetViewModel
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
                              row.original as TweetViewModel
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

export const WrappedTweetSearchComponent = Form.create({ name: 'Tweet Search' })(TweetSearchComponent);

/*<Codenesium>
    <Hash>e3bc97bdd48ad81fd80ef28bcb939d29</Hash>
</Codenesium>*/