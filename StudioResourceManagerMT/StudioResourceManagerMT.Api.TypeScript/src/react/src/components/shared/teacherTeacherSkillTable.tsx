import React, { Component, FormEvent } from 'react';
import axios, { AxiosError, AxiosResponse } from 'axios';
import { Constants, ApiRoutes, ClientRoutes } from '../../constants';
import * as Api from '../../api/models';
import TeacherTeacherSkillMapper from '../teacherTeacherSkill/teacherTeacherSkillMapper';
import TeacherTeacherSkillViewModel from '../teacherTeacherSkill/teacherTeacherSkillViewModel';
import { Form, Input, Button, Spin, Alert } from 'antd';
import { WrappedFormUtils } from 'antd/es/form/Form';
import ReactTable from 'react-table';
import * as GlobalUtilities from '../../lib/globalUtilities';

interface TeacherTeacherSkillTableComponentProps {
  apiRoute: string;
  history: any;
  match: any;
}

interface TeacherTeacherSkillTableComponentState {
  loading: boolean;
  loaded: boolean;
  errorOccurred: boolean;
  errorMessage: string;
  filteredRecords: Array<TeacherTeacherSkillViewModel>;
}

export class TeacherTeacherSkillTableComponent extends React.Component<
  TeacherTeacherSkillTableComponentProps,
  TeacherTeacherSkillTableComponentState
> {
  state = {
    loading: false,
    loaded: true,
    errorOccurred: false,
    errorMessage: '',
    filteredRecords: [],
  };

  handleEditClick(e: any, row: TeacherTeacherSkillViewModel) {
    this.props.history.push(
      ClientRoutes.TeacherTeacherSkills + '/edit/' + row.teacherId
    );
  }

  handleDetailClick(e: any, row: TeacherTeacherSkillViewModel) {
    this.props.history.push(
      ClientRoutes.TeacherTeacherSkills + '/' + row.teacherId
    );
  }

  componentDidMount() {
    this.loadRecords();
  }

  loadRecords() {
    this.setState({ ...this.state, loading: true });

    axios
      .get<Array<Api.TeacherTeacherSkillClientResponseModel>>(
        this.props.apiRoute,
        {
          headers: GlobalUtilities.defaultHeaders(),
        }
      )
      .then(response => {
        GlobalUtilities.logInfo(response);

        let mapper = new TeacherTeacherSkillMapper();

        let teacherTeacherSkills: Array<TeacherTeacherSkillViewModel> = [];

        response.data.forEach(x => {
          teacherTeacherSkills.push(mapper.mapApiResponseToViewModel(x));
        });

        this.setState({
          ...this.state,
          filteredRecords: teacherTeacherSkills,
          loading: false,
          loaded: true,
          errorOccurred: false,
          errorMessage: '',
        });
      })
      .catch((error: AxiosError) => {
        GlobalUtilities.logError(error);

        if (error.response && error.response.status == 422) {
          this.setState({
            ...this.state,
            errorOccurred: false,
            errorMessage: '',
          });
        } else {
          this.setState({
            ...this.state,
            errorOccurred: true,
            errorMessage: 'Error Occurred',
          });
        }
      });
  }

  render() {
    let message: JSX.Element = <div />;
    if (this.state.errorOccurred) {
      message = <Alert message={this.state.errorMessage} type="error" />;
    }

    if (this.state.loading) {
      return <Spin size="large" />;
    } else if (this.state.errorOccurred) {
      return <Alert message={this.state.errorMessage} type="error" />;
    } else if (this.state.loaded) {
      return (
        <div>
          {message}
          <ReactTable
            data={this.state.filteredRecords}
            defaultPageSize={10}
            columns={[
              {
                Header: 'TeacherTeacherSkills',
                columns: [
                  {
                    Header: 'Teacher Skill',
                    accessor: 'teacherSkillId',
                    Cell: props => {
                      return (
                        <a
                          href=""
                          onClick={e => {
                            e.preventDefault();
                            this.props.history.push(
                              ClientRoutes.TeacherSkills +
                                '/' +
                                props.original.teacherSkillId
                            );
                          }}
                        >
                          {String(
                            props.original.teacherSkillIdNavigation &&
                              props.original.teacherSkillIdNavigation.toDisplay()
                          )}
                        </a>
                      );
                    },
                  },
                  {
                    Header: 'Actions',
                    minWidth: 150,
                    Cell: row => (
                      <div>
                        <Button
                          type="primary"
                          onClick={(e: any) => {
                            this.handleDetailClick(
                              e,
                              row.original as TeacherTeacherSkillViewModel
                            );
                          }}
                        >
                          <i className="fas fa-search" />
                        </Button>
                        &nbsp;
                        <Button
                          type="primary"
                          onClick={(e: any) => {
                            this.handleEditClick(
                              e,
                              row.original as TeacherTeacherSkillViewModel
                            );
                          }}
                        >
                          <i className="fas fa-edit" />
                        </Button>
                      </div>
                    ),
                  },
                ],
              },
            ]}
          />
        </div>
      );
    } else {
      return null;
    }
  }
}


/*<Codenesium>
    <Hash>44fba1725abdec2792f229fab62c643b</Hash>
</Codenesium>*/