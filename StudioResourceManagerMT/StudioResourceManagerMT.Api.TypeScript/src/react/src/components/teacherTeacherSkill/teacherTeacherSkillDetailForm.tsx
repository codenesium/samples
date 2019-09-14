import React, { Component, FormEvent } from 'react';
import axios, { AxiosError, AxiosResponse } from 'axios';
import { Constants, ApiRoutes, ClientRoutes } from '../../constants';
import * as Api from '../../api/models';
import TeacherTeacherSkillMapper from './teacherTeacherSkillMapper';
import TeacherTeacherSkillViewModel from './teacherTeacherSkillViewModel';
import { Form, Input, Button, Spin, Alert } from 'antd';
import { WrappedFormUtils } from 'antd/es/form/Form';
import * as GlobalUtilities from '../../lib/globalUtilities';

interface TeacherTeacherSkillDetailComponentProps {
  form: WrappedFormUtils;
  history: any;
  match: any;
}

interface TeacherTeacherSkillDetailComponentState {
  model?: TeacherTeacherSkillViewModel;
  loading: boolean;
  loaded: boolean;
  errorOccurred: boolean;
  errorMessage: string;
}

class TeacherTeacherSkillDetailComponent extends React.Component<
  TeacherTeacherSkillDetailComponentProps,
  TeacherTeacherSkillDetailComponentState
> {
  state = {
    model: new TeacherTeacherSkillViewModel(),
    loading: false,
    loaded: true,
    errorOccurred: false,
    errorMessage: '',
  };

  handleEditClick(e: any) {
    this.props.history.push(
      ClientRoutes.TeacherTeacherSkills + '/edit/' + this.state.model!.id
    );
  }

  componentDidMount() {
    this.setState({ ...this.state, loading: true });

    axios
      .get<Api.TeacherTeacherSkillClientResponseModel>(
        Constants.ApiEndpoint +
          ApiRoutes.TeacherTeacherSkills +
          '/' +
          this.props.match.params.id,
        {
          headers: GlobalUtilities.defaultHeaders(),
        }
      )
      .then(response => {
        GlobalUtilities.logInfo(response);

        let mapper = new TeacherTeacherSkillMapper();

        this.setState({
          model: mapper.mapApiResponseToViewModel(response.data),
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
    } else if (this.state.loaded) {
      return (
        <div>
          <Button
            style={{ float: 'right' }}
            type="primary"
            onClick={(e: any) => {
              this.handleEditClick(e);
            }}
          >
            <i className="fas fa-edit" />
          </Button>
          <div>
            <div style={{ marginBottom: '10px' }}>
              <h3>Teacher</h3>
              <p>
                {String(
                  this.state.model!.teacherIdNavigation &&
                    this.state.model!.teacherIdNavigation!.toDisplay()
                )}
              </p>
            </div>
            <div style={{ marginBottom: '10px' }}>
              <h3>Teacher Skill</h3>
              <p>
                {String(
                  this.state.model!.teacherSkillIdNavigation &&
                    this.state.model!.teacherSkillIdNavigation!.toDisplay()
                )}
              </p>
            </div>
          </div>
          {message}
        </div>
      );
    } else {
      return null;
    }
  }
}

export const WrappedTeacherTeacherSkillDetailComponent = Form.create({
  name: 'TeacherTeacherSkill Detail',
})(TeacherTeacherSkillDetailComponent);


/*<Codenesium>
    <Hash>b48381a629d1357a42f3ef390a6cb828</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/