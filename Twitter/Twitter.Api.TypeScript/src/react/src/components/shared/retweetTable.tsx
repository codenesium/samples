import React, { Component, FormEvent } from 'react';
import axios from 'axios';
import { Constants, ApiRoutes, ClientRoutes } from '../../constants';
import * as Api from '../../api/models';
import RetweetMapper from '../retweet/retweetMapper';
import RetweetViewModel from '../retweet/retweetViewModel';
import { Form, Input, Button, Spin, Alert } from 'antd';
import { WrappedFormUtils } from 'antd/es/form/Form';
import ReactTable from "react-table";

interface RetweetTableComponentProps {
  id:number,
  apiRoute:string;
  history: any;
  match: any;
}

interface RetweetTableComponentState {
  loading: boolean;
  loaded: boolean;
  errorOccurred: boolean;
  errorMessage: string;
  filteredRecords : Array<RetweetViewModel>;
}

export class  RetweetTableComponent extends React.Component<
RetweetTableComponentProps,
RetweetTableComponentState
> {
  state = {
    loading: false,
    loaded: true,
    errorOccurred: false,
    errorMessage: '',
    filteredRecords:[]
  };

handleEditClick(e:any, row: RetweetViewModel) {
  this.props.history.push(ClientRoutes.Retweets + '/edit/' + row.id);
}

 handleDetailClick(e:any, row: RetweetViewModel) {
   this.props.history.push(ClientRoutes.Retweets + '/' + row.id);
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
          let response = resp.data as Array<Api.RetweetClientResponseModel>;

          console.log(response);

          let mapper = new RetweetMapper();
          
          let retweets:Array<RetweetViewModel> = [];

          response.forEach(x =>
          {
              retweets.push(mapper.mapApiResponseToViewModel(x));
          });
          this.setState({
            ...this.state,
            filteredRecords: retweets,
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
                    Header: 'Retweets',
                    columns: [
					  {
                      Header: 'Date',
                      accessor: 'date',
                      Cell: (props) => {
                      return <span>{String(props.original.date)}</span>;
                      }           
                    },  {
                      Header: 'Retwitter_user_id',
                      accessor: 'retwitterUserId',
                      Cell: (props) => {
                        return <a href='' onClick={(e) => { e.preventDefault(); this.props.history.push(ClientRoutes.Users + '/' + props.original.retwitterUserId); }}>
                          {String(
                            props.original.retwitterUserIdNavigation.toDisplay()
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
                      Header: 'Tweet_tweet_id',
                      accessor: 'tweetTweetId',
                      Cell: (props) => {
                        return <a href='' onClick={(e) => { e.preventDefault(); this.props.history.push(ClientRoutes.Tweets + '/' + props.original.tweetTweetId); }}>
                          {String(
                            props.original.tweetTweetIdNavigation.toDisplay()
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
                              row.original as RetweetViewModel
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
                              row.original as RetweetViewModel
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
    <Hash>d4c9e5c475b1e67b265bb343843a5b3f</Hash>
</Codenesium>*/