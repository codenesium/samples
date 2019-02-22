import React, { Component, ReactElement, ReactHTMLElement } from 'react';
import axios from 'axios';
import { Redirect } from 'react-router-dom';
import * as Api from '../../api/models';
import StudentMapper from './studentMapper';
import { Constants, ApiRoutes, ClientRoutes } from '../../constants';
import ReactTable from "react-table";
import StudentViewModel from './studentViewModel';
import "react-table/react-table.css";
import { Form, Button, Input, Row, Col, Alert, Spin } from 'antd';
import { WrappedFormUtils } from 'antd/es/form/Form';

interface StudentSearchComponentProps
{
     form:WrappedFormUtils;
	 history:any;
	 match:any;
}

interface StudentSearchComponentState
{
    records:Array<StudentViewModel>;
    filteredRecords:Array<StudentViewModel>;
    loading:boolean;
    loaded:boolean;
    errorOccurred:boolean;
    errorMessage:string;
    searchValue:string;
    deleteSubmitted:boolean;
    deleteSuccess:boolean;
    deleteResponse:string;
}

export default class StudentSearchComponent extends React.Component<StudentSearchComponentProps, StudentSearchComponentState> {

    state = ({deleteSubmitted:false, deleteSuccess:false, deleteResponse:'', records:new Array<StudentViewModel>(), filteredRecords:new Array<StudentViewModel>(), searchValue:'', loading:false, loaded:true, errorOccurred:false, errorMessage:''});
    
    componentDidMount () {
        this.loadRecords();
    }

    handleEditClick(e:any, row:StudentViewModel) {
         this.props.history.push(ClientRoutes.Students + '/edit/' + row.id);
    }

    handleDetailClick(e:any, row:StudentViewModel) {
         this.props.history.push(ClientRoutes.Students + '/' + row.id);
    }

    handleCreateClick(e:any) {
        this.props.history.push(ClientRoutes.Students + '/create');
    }

    handleDeleteClick(e:any, row:Api.StudentClientResponseModel) {
        axios.delete(Constants.ApiEndpoint + ApiRoutes.Students + '/' + row.id,
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
	   let searchEndpoint = Constants.ApiEndpoint + ApiRoutes.Students + '?limit=100';

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
		    let response = resp.data as Array<Api.StudentClientResponseModel>;
		    let viewModels : Array<StudentViewModel> = [];
			let mapper = new StudentMapper();

			response.forEach(x =>
			{
				viewModels.push(mapper.mapApiResponseToViewModel(x));
			})

            this.setState({records:viewModels, filteredRecords:viewModels, loading:false, loaded:true, errorOccurred:false, errorMessage:''});

	   }, error => {
		   console.log(error);
		   this.setState({records:new Array<StudentViewModel>(), filteredRecords:new Array<StudentViewModel>(), loading:false, loaded:true, errorOccurred:true, errorMessage:'Error from API'});
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
                    Header: 'Students',
                    columns: [
					  {
                      Header: 'Birthday',
                      accessor: 'birthday',
                      Cell: (props) => {
                      return <span>{String(props.original.birthday)}</span>;
                      }           
                    },  {
                      Header: 'Email',
                      accessor: 'email',
                      Cell: (props) => {
                      return <span>{String(props.original.email)}</span>;
                      }           
                    },  {
                      Header: 'EmailRemindersEnabled',
                      accessor: 'emailRemindersEnabled',
                      Cell: (props) => {
                      return <span>{String(props.original.emailRemindersEnabled)}</span>;
                      }           
                    },  {
                      Header: 'FamilyId',
                      accessor: 'familyId',
                      Cell: (props) => {
                      return <span>{String(props.original.familyId)}</span>;
                      }           
                    },  {
                      Header: 'FirstName',
                      accessor: 'firstName',
                      Cell: (props) => {
                      return <span>{String(props.original.firstName)}</span>;
                      }           
                    },  {
                      Header: 'Id',
                      accessor: 'id',
                      Cell: (props) => {
                      return <span>{String(props.original.id)}</span>;
                      }           
                    },  {
                      Header: 'IsAdult',
                      accessor: 'isAdult',
                      Cell: (props) => {
                      return <span>{String(props.original.isAdult)}</span>;
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
                      Header: 'SmsRemindersEnabled',
                      accessor: 'smsRemindersEnabled',
                      Cell: (props) => {
                      return <span>{String(props.original.smsRemindersEnabled)}</span>;
                      }           
                    },  {
                      Header: 'UserId',
                      accessor: 'userId',
                      Cell: (props) => {
                      return <span>{String(props.original.userId)}</span>;
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
                              row.original as StudentViewModel
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
                              row.original as StudentViewModel
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
                              row.original as StudentViewModel
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

export const WrappedStudentSearchComponent = Form.create({ name: 'Student Search' })(StudentSearchComponent);

/*<Codenesium>
    <Hash>827de245e95546323c2540854216065e</Hash>
</Codenesium>*/