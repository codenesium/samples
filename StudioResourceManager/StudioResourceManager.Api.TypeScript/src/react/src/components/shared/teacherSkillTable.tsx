import React, { Component, FormEvent } from 'react';
import axios from 'axios';
import { Constants, ApiRoutes, ClientRoutes } from '../../constants';
import * as Api from '../../api/models';
import TeacherSkillMapper from '../teacherSkill/teacherSkillMapper';
import TeacherSkillViewModel from '../teacherSkill/teacherSkillViewModel';
import { Form, Input, Button, Spin, Alert } from 'antd';
import { WrappedFormUtils } from 'antd/es/form/Form';
import ReactTable from "react-table";

interface TeacherSkillTableComponentProps {
  id:number,
  apiRoute:string;
  history: any;
  match: any;
}

interface TeacherSkillTableComponentState {
  loading: boolean;
  loaded: boolean;
  errorOccurred: boolean;
  errorMessage: string;
  filteredRecords : Array<TeacherSkillViewModel>;
}

export class  TeacherSkillTableComponent extends React.Component<
TeacherSkillTableComponentProps,
TeacherSkillTableComponentState
> {
  state = {
    loading: false,
    loaded: true,
    errorOccurred: false,
    errorMessage: '',
    filteredRecords:[]
  };

handleEditClick(e:any, row: TeacherSkillViewModel) {
  this.props.history.push(ClientRoutes.TeacherSkills + '/edit/' + row.id);
}

 handleDetailClick(e:any, row: TeacherSkillViewModel) {
   this.props.history.push(ClientRoutes.TeacherSkills + '/' + row.id);
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
          let response = resp.data as Array<Api.TeacherSkillClientResponseModel>;

          console.log(response);

          let mapper = new TeacherSkillMapper();
          
          let teacherSkills:Array<TeacherSkillViewModel> = [];

          response.forEach(x =>
          {
              teacherSkills.push(mapper.mapApiResponseToViewModel(x));
          });
          this.setState({
            ...this.state,
            filteredRecords: teacherSkills,
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
                    Header: 'TeacherSkills',
                    columns: [
					  {
                      Header: 'Name',
                      accessor: 'name',
                      Cell: (props) => {
                      return <span>{String(props.original.name)}</span>;
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
                              row.original as TeacherSkillViewModel
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
                              row.original as TeacherSkillViewModel
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
    <Hash>d83c6e6a8f7e2132de90e8e1142998ec</Hash>
</Codenesium>*/