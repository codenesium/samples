import React, { Component, FormEvent } from 'react';
import axios from 'axios';
import { Constants, ApiRoutes, ClientRoutes } from '../../constants';
import * as Api from '../../api/models';
import UsersMapper from '../users/usersMapper';
import UsersViewModel from '../users/usersViewModel';
import { Form, Input, Button, Spin, Alert } from 'antd';
import { WrappedFormUtils } from 'antd/es/form/Form';
import ReactTable from "react-table";

interface UsersTableComponentProps {
  id:number,
  apiRoute:string;
  history: any;
  match: any;
}

interface UsersTableComponentState {
  loading: boolean;
  loaded: boolean;
  errorOccurred: boolean;
  errorMessage: string;
  filteredRecords : Array<UsersViewModel>;
}

export class  UsersTableComponent extends React.Component<
UsersTableComponentProps,
UsersTableComponentState
> {
  state = {
    loading: false,
    loaded: true,
    errorOccurred: false,
    errorMessage: '',
    filteredRecords:[]
  };

handleEditClick(e:any, row: UsersViewModel) {
  this.props.history.push(ClientRoutes.Users + '/edit/' + row.id);
}

 handleDetailClick(e:any, row: UsersViewModel) {
   this.props.history.push(ClientRoutes.Users + '/' + row.id);
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
          let response = resp.data as Array<Api.UsersClientResponseModel>;

          console.log(response);

          let mapper = new UsersMapper();
          
          let users:Array<UsersViewModel> = [];

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
                      Header: 'About Me',
                      accessor: 'aboutMe',
                      Cell: (props) => {
                      return <span>{String(props.original.aboutMe)}</span>;
                      }           
                    },  {
                      Header: 'Account',
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
                      Header: 'Creation Date',
                      accessor: 'creationDate',
                      Cell: (props) => {
                      return <span>{String(props.original.creationDate)}</span>;
                      }           
                    },  {
                      Header: 'Display Name',
                      accessor: 'displayName',
                      Cell: (props) => {
                      return <span>{String(props.original.displayName)}</span>;
                      }           
                    },  {
                      Header: 'Down Vote',
                      accessor: 'downVote',
                      Cell: (props) => {
                      return <span>{String(props.original.downVote)}</span>;
                      }           
                    },  {
                      Header: 'Email Hash',
                      accessor: 'emailHash',
                      Cell: (props) => {
                      return <span>{String(props.original.emailHash)}</span>;
                      }           
                    },  {
                      Header: 'Last Access Date',
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
                      Header: 'Up Vote',
                      accessor: 'upVote',
                      Cell: (props) => {
                      return <span>{String(props.original.upVote)}</span>;
                      }           
                    },  {
                      Header: 'View',
                      accessor: 'view',
                      Cell: (props) => {
                      return <span>{String(props.original.view)}</span>;
                      }           
                    },  {
                      Header: 'Website Url',
                      accessor: 'websiteUrl',
                      Cell: (props) => {
                      return <span>{String(props.original.websiteUrl)}</span>;
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
                              row.original as UsersViewModel
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
                              row.original as UsersViewModel
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
    <Hash>977d2f1f63f0264bbdf496eb1ad37d4f</Hash>
</Codenesium>*/