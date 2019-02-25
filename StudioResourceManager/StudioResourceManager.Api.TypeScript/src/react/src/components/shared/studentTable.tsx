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
                      Header: 'Email Reminders Enabled',
                      accessor: 'emailRemindersEnabled',
                      Cell: (props) => {
                      return <span>{String(props.original.emailRemindersEnabled)}</span>;
                      }           
                    },  {
                      Header: 'FamilyId',
                      accessor: 'familyId',
                      Cell: (props) => {
                        return <a href='' onClick={(e) => { e.preventDefault(); this.props.history.push(ClientRoutes.Families + '/' + props.original.familyId); }}>
                          {String(
                            props.original.familyIdNavigation.toDisplay()
                          )}
                        </a>
                      }           
                    },  {
                      Header: 'First Name',
                      accessor: 'firstName',
                      Cell: (props) => {
                      return <span>{String(props.original.firstName)}</span>;
                      }           
                    },  {
                      Header: 'Is Adult',
                      accessor: 'isAdult',
                      Cell: (props) => {
                      return <span>{String(props.original.isAdult)}</span>;
                      }           
                    },  {
                      Header: 'Last Name',
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
                      Header: 'SMS Reminders Enabled',
                      accessor: 'smsRemindersEnabled',
                      Cell: (props) => {
                      return <span>{String(props.original.smsRemindersEnabled)}</span>;
                      }           
                    },  {
                      Header: 'UserId',
                      accessor: 'userId',
                      Cell: (props) => {
                        return <a href='' onClick={(e) => { e.preventDefault(); this.props.history.push(ClientRoutes.Users + '/' + props.original.userId); }}>
                          {String(
                            props.original.userIdNavigation.toDisplay()
                          )}
                        </a>
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
    <Hash>4d966b7db8cee79aed2bc75d7b6965b6</Hash>
</Codenesium>*/