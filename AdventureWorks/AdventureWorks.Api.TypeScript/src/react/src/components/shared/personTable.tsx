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
  businessEntityID:number,
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
                      Header: 'AdditionalContactInfo',
                      accessor: 'additionalContactInfo',
                      Cell: (props) => {
                      return <span>{String(props.original.additionalContactInfo)}</span>;
                      }           
                    },  {
                      Header: 'BusinessEntityID',
                      accessor: 'businessEntityID',
                      Cell: (props) => {
                        return <a href='' onClick={(e) => { e.preventDefault(); this.props.history.push(ClientRoutes.BusinessEntities + '/' + props.original.businessEntityID); }}>
                          {String(
                            props.original.businessEntityIDNavigation.toDisplay()
                          )}
                        </a>
                      }           
                    },  {
                      Header: 'Demographics',
                      accessor: 'demographic',
                      Cell: (props) => {
                      return <span>{String(props.original.demographic)}</span>;
                      }           
                    },  {
                      Header: 'EmailPromotion',
                      accessor: 'emailPromotion',
                      Cell: (props) => {
                      return <span>{String(props.original.emailPromotion)}</span>;
                      }           
                    },  {
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
                      Header: 'MiddleName',
                      accessor: 'middleName',
                      Cell: (props) => {
                      return <span>{String(props.original.middleName)}</span>;
                      }           
                    },  {
                      Header: 'ModifiedDate',
                      accessor: 'modifiedDate',
                      Cell: (props) => {
                      return <span>{String(props.original.modifiedDate)}</span>;
                      }           
                    },  {
                      Header: 'NameStyle',
                      accessor: 'nameStyle',
                      Cell: (props) => {
                      return <span>{String(props.original.nameStyle)}</span>;
                      }           
                    },  {
                      Header: 'PersonType',
                      accessor: 'personType',
                      Cell: (props) => {
                      return <span>{String(props.original.personType)}</span>;
                      }           
                    },  {
                      Header: 'Rowguid',
                      accessor: 'rowguid',
                      Cell: (props) => {
                      return <span>{String(props.original.rowguid)}</span>;
                      }           
                    },  {
                      Header: 'Suffix',
                      accessor: 'suffix',
                      Cell: (props) => {
                      return <span>{String(props.original.suffix)}</span>;
                      }           
                    },  {
                      Header: 'Title',
                      accessor: 'title',
                      Cell: (props) => {
                      return <span>{String(props.original.title)}</span>;
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
    <Hash>b1cdec7888b7ffae698bf8e31292d4a0</Hash>
</Codenesium>*/