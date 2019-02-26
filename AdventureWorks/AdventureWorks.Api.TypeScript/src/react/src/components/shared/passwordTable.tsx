import React, { Component, FormEvent } from 'react';
import axios from 'axios';
import { Constants, ApiRoutes, ClientRoutes } from '../../constants';
import * as Api from '../../api/models';
import PasswordMapper from '../password/passwordMapper';
import PasswordViewModel from '../password/passwordViewModel';
import { Form, Input, Button, Spin, Alert } from 'antd';
import { WrappedFormUtils } from 'antd/es/form/Form';
import ReactTable from "react-table";

interface PasswordTableComponentProps {
  businessEntityID:number,
  apiRoute:string;
  history: any;
  match: any;
}

interface PasswordTableComponentState {
  loading: boolean;
  loaded: boolean;
  errorOccurred: boolean;
  errorMessage: string;
  filteredRecords : Array<PasswordViewModel>;
}

export class  PasswordTableComponent extends React.Component<
PasswordTableComponentProps,
PasswordTableComponentState
> {
  state = {
    loading: false,
    loaded: true,
    errorOccurred: false,
    errorMessage: '',
    filteredRecords:[]
  };

handleEditClick(e:any, row: PasswordViewModel) {
  this.props.history.push(ClientRoutes.Passwords + '/edit/' + row.id);
}

 handleDetailClick(e:any, row: PasswordViewModel) {
   this.props.history.push(ClientRoutes.Passwords + '/' + row.id);
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
          let response = resp.data as Array<Api.PasswordClientResponseModel>;

          console.log(response);

          let mapper = new PasswordMapper();
          
          let passwords:Array<PasswordViewModel> = [];

          response.forEach(x =>
          {
              passwords.push(mapper.mapApiResponseToViewModel(x));
          });
          this.setState({
            ...this.state,
            filteredRecords: passwords,
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
                    Header: 'Passwords',
                    columns: [
					  {
                      Header: 'BusinessEntityID',
                      accessor: 'businessEntityID',
                      Cell: (props) => {
                        return <a href='' onClick={(e) => { e.preventDefault(); this.props.history.push(ClientRoutes.People + '/' + props.original.businessEntityID); }}>
                          {String(
                            props.original.businessEntityIDNavigation.toDisplay()
                          )}
                        </a>
                      }           
                    },  {
                      Header: 'ModifiedDate',
                      accessor: 'modifiedDate',
                      Cell: (props) => {
                      return <span>{String(props.original.modifiedDate)}</span>;
                      }           
                    },  {
                      Header: 'PasswordHash',
                      accessor: 'passwordHash',
                      Cell: (props) => {
                      return <span>{String(props.original.passwordHash)}</span>;
                      }           
                    },  {
                      Header: 'PasswordSalt',
                      accessor: 'passwordSalt',
                      Cell: (props) => {
                      return <span>{String(props.original.passwordSalt)}</span>;
                      }           
                    },  {
                      Header: 'Rowguid',
                      accessor: 'rowguid',
                      Cell: (props) => {
                      return <span>{String(props.original.rowguid)}</span>;
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
                              row.original as PasswordViewModel
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
                              row.original as PasswordViewModel
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
    <Hash>8d54c82ac6e149cf366b646a3b8086ed</Hash>
</Codenesium>*/