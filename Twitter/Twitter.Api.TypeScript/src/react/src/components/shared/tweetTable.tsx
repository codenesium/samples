import React, { Component, FormEvent } from 'react';
import axios from 'axios';
import { Constants, ApiRoutes, ClientRoutes } from '../../constants';
import * as Api from '../../api/models';
import TweetMapper from '../tweet/tweetMapper';
import TweetViewModel from '../tweet/tweetViewModel';
import { Form, Input, Button, Spin, Alert } from 'antd';
import { WrappedFormUtils } from 'antd/es/form/Form';
import ReactTable from "react-table";

interface TweetTableComponentProps {
  tweet_id:number,
  apiRoute:string;
  history: any;
  match: any;
}

interface TweetTableComponentState {
  loading: boolean;
  loaded: boolean;
  errorOccurred: boolean;
  errorMessage: string;
  filteredRecords : Array<TweetViewModel>;
}

export class  TweetTableComponent extends React.Component<
TweetTableComponentProps,
TweetTableComponentState
> {
  state = {
    loading: false,
    loaded: true,
    errorOccurred: false,
    errorMessage: '',
    filteredRecords:[]
  };

handleEditClick(e:any, row: TweetViewModel) {
  this.props.history.push(ClientRoutes.Tweets + '/edit/' + row.id);
}

 handleDetailClick(e:any, row: TweetViewModel) {
   this.props.history.push(ClientRoutes.Tweets + '/' + row.id);
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
          let response = resp.data as Array<Api.TweetClientResponseModel>;

          console.log(response);

          let mapper = new TweetMapper();
          
          let tweets:Array<TweetViewModel> = [];

          response.forEach(x =>
          {
              tweets.push(mapper.mapApiResponseToViewModel(x));
          });
          this.setState({
            ...this.state,
            filteredRecords: tweets,
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
    <Hash>df3d2e743363998189dc0280236f8162</Hash>
</Codenesium>*/