import React, { Component, FormEvent } from 'react';
import axios from 'axios';
import { Constants, ApiRoutes, ClientRoutes } from '../../constants';
import * as Api from '../../api/models';
import PersonMapper from '../person/personMapper';
import PersonViewModel from '../person/personViewModel';
import { Form, Input, Button, Spin, Alert } from 'antd';
import { WrappedFormUtils } from 'antd/es/form/Form';
import ReactTable from "react-table";

interface PersonTableComponentProps {
  id:number,
  apiRoute:string;
  history: any;
  match: any;
}

interface PersonTableComponentState {
  loading: boolean;
  loaded: boolean;
  errorOccurred: boolean;
  errorMessage: string;
  filteredRecords : Array<PersonViewModel>;
}

export class  PersonTableComponent extends React.Component<
PersonTableComponentProps,
PersonTableComponentState
> {
  state = {
    loading: false,
    loaded: true,
    errorOccurred: false,
    errorMessage: '',
    filteredRecords:[]
  };

handleEditClick(e:any, row: PersonViewModel) {
  this.props.history.push(ClientRoutes.People + '/edit/' + row.id);
}

 handleDetailClick(e:any, row: PersonViewModel) {
   this.props.history.push(ClientRoutes.People + '/' + row.id);
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
          let response = resp.data as Array<Api.PersonClientResponseModel>;

          console.log(response);

          let mapper = new PersonMapper();
          
          let people:Array<PersonViewModel> = [];

          response.forEach(x =>
          {
              people.push(mapper.mapApiResponseToViewModel(x));
          });
          this.setState({
            ...this.state,
            filteredRecords: people,
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
                    Header: 'People',
                    columns: [
					  {
                      Header: 'FirstName',
                      accessor: 'firstName',
                      Cell: (props) => {
                      return <span>{String(props.original.firstName)}</span>;
                      }           
                    },  {
                      Header: 'LastName',
                      accessor: 'lastName',
                      Cell: (props) => {
                      return <span>{String(props.original.lastName)}</span>;
                      }           
                    },  {
                      Header: 'Phone',
                      accessor: 'phone',
                      Cell: (props) => {
                      return <span>{String(props.original.phone)}</span>;
                      }           
                    },  {
                      Header: 'Ssn',
                      accessor: 'ssn',
                      Cell: (props) => {
                      return <span>{String(props.original.ssn)}</span>;
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
                              row.original as PersonViewModel
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
                              row.original as PersonViewModel
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
    <Hash>0a30caf45070c5d4a273e7ed198eb05f</Hash>
</Codenesium>*/