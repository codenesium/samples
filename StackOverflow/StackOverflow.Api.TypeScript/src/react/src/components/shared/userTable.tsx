import React, { Component, FormEvent } from 'react';
import axios from 'axios';
import { Constants, ApiRoutes, ClientRoutes } from '../../constants';
import * as Api from '../../api/models';
import UserMapper from '../user/userMapper';
import UserViewModel from '../user/userViewModel';
import { Form, Input, Button, Spin, Alert } from 'antd';
import { WrappedFormUtils } from 'antd/es/form/Form';
import ReactTable from "react-table";

interface UserTableComponentProps {
  id:number,
  apiRoute:string;
  history: any;
  match: any;
}

interface UserTableComponentState {
  loading: boolean;
  loaded: boolean;
  errorOccurred: boolean;
  errorMessage: string;
  filteredRecords : Array<UserViewModel>;
}

export class  UserTableComponent extends React.Component<
UserTableComponentProps,
UserTableComponentState
> {
  state = {
    loading: false,
    loaded: true,
    errorOccurred: false,
    errorMessage: '',
    filteredRecords:[]
  };

handleEditClick(e:any, row: UserViewModel) {
  this.props.history.push(ClientRoutes.Users + '/edit/' + row.id);
}

handleDetailClick(e:any, row: UserViewModel) {
  this.props.history.push(ClientRoutes.Users + '/' + row.id);
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
          let response = resp.data as Array<Api.UserClientResponseModel>;

          console.log(response);

          let mapper = new UserMapper();
          
          let users:Array<UserViewModel> = [];

          response.forEach(x =>
          {
              users.push(mapper.mapApiResponseToViewModel(x));
          });
          this.setState({
            ...this.state,
            filteredRecords: users,
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
                    Header: 'Users',
                    columns: [
					  {
                      Header: 'AboutMe',
                      accessor: 'aboutMe',
                      Cell: (props) => {
                      return <span>{String(props.original.aboutMe)}</span>;
                      }           
                    },  {
                      Header: 'AccountId',
                      accessor: 'accountId',
                      Cell: (props) => {
                      return <span>{String(props.original.accountId)}</span>;
                      }           
                    },  {
                      Header: 'Age',
                      accessor: 'age',
                      Cell: (props) => {
                      return <span>{String(props.original.age)}</span>;
                      }           
                    },  {
                      Header: 'CreationDate',
                      accessor: 'creationDate',
                      Cell: (props) => {
                      return <span>{String(props.original.creationDate)}</span>;
                      }           
                    },  {
                      Header: 'DisplayName',
                      accessor: 'displayName',
                      Cell: (props) => {
                      return <span>{String(props.original.displayName)}</span>;
                      }           
                    },  {
                      Header: 'DownVotes',
                      accessor: 'downVote',
                      Cell: (props) => {
                      return <span>{String(props.original.downVote)}</span>;
                      }           
                    },  {
                      Header: 'EmailHash',
                      accessor: 'emailHash',
                      Cell: (props) => {
                      return <span>{String(props.original.emailHash)}</span>;
                      }           
                    },  {
                      Header: 'LastAccessDate',
                      accessor: 'lastAccessDate',
                      Cell: (props) => {
                      return <span>{String(props.original.lastAccessDate)}</span>;
                      }           
                    },  {
                      Header: 'Location',
                      accessor: 'location',
                      Cell: (props) => {
                      return <span>{String(props.original.location)}</span>;
                      }           
                    },  {
                      Header: 'Reputation',
                      accessor: 'reputation',
                      Cell: (props) => {
                      return <span>{String(props.original.reputation)}</span>;
                      }           
                    },  {
                      Header: 'UpVotes',
                      accessor: 'upVote',
                      Cell: (props) => {
                      return <span>{String(props.original.upVote)}</span>;
                      }           
                    },  {
                      Header: 'Views',
                      accessor: 'view',
                      Cell: (props) => {
                      return <span>{String(props.original.view)}</span>;
                      }           
                    },  {
                      Header: 'WebsiteUrl',
                      accessor: 'websiteUrl',
                      Cell: (props) => {
                      return <span>{String(props.original.websiteUrl)}</span>;
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
                              row.original as UserViewModel
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
                              row.original as UserViewModel
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
    <Hash>cea183b9eb7a9692673c0a4adf733378</Hash>
</Codenesium>*/