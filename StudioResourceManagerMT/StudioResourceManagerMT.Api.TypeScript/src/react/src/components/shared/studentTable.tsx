import React, { Component, FormEvent } from 'react';
import axios from 'axios';
import { Constants, ApiRoutes, ClientRoutes } from '../../constants';
import * as Api from '../../api/models';
import StudentMapper from '../student/studentMapper';
import StudentViewModel from '../student/studentViewModel';
import { Form, Input, Button, Spin, Alert } from 'antd';
import { WrappedFormUtils } from 'antd/es/form/Form';
import ReactTable from "react-table";

interface StudentTableComponentProps {
  id:number,
  apiRoute:string;
  history: any;
  match: any;
}

interface StudentTableComponentState {
  loading: boolean;
  loaded: boolean;
  errorOccurred: boolean;
  errorMessage: string;
  filteredRecords : Array<StudentViewModel>;
}

export class  StudentTableComponent extends React.Component<
StudentTableComponentProps,
StudentTableComponentState
> {
  state = {
    loading: false,
    loaded: true,
    errorOccurred: false,
    errorMessage: '',
    filteredRecords:[]
  };

handleEditClick(e:any, row: StudentViewModel) {
  this.props.history.push(ClientRoutes.Students + '/edit/' + row.id);
}

handleDetailClick(e:any, row: StudentViewModel) {
  this.props.history.push(ClientRoutes.Students + '/' + row.id);
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
          let response = resp.data as Array<Api.StudentClientResponseModel>;

          console.log(response);

          let mapper = new StudentMapper();
          
          let students:Array<StudentViewModel> = [];

          response.forEach(x =>
          {
              students.push(mapper.mapApiResponseToViewModel(x));
          });
          this.setState({
            ...this.state,
            filteredRecords: students,
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
    <Hash>b7af9ef1dd01d12b8a32715ee0af3ee1</Hash>
</Codenesium>*/