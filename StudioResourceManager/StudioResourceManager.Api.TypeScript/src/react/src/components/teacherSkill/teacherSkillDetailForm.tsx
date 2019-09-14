import React, { Component, FormEvent } from 'react';
import axios, { AxiosError, AxiosResponse } from 'axios';
import { Constants, ApiRoutes, ClientRoutes } from '../../constants';
import * as Api from '../../api/models';
import TeacherSkillMapper from './teacherSkillMapper';
import TeacherSkillViewModel from './teacherSkillViewModel';
import { Form, Input, Button, Spin, Alert } from 'antd';
import { WrappedFormUtils } from 'antd/es/form/Form';
import * as GlobalUtilities from '../../lib/globalUtilities';
import { RateTableComponent } from '../shared/rateTable';
import { TeacherTeacherSkillTableComponent } from '../shared/teacherTeacherSkillTable';

interface TeacherSkillDetailComponentProps {
  form: WrappedFormUtils;
  history: any;
  match: any;
}

interface TeacherSkillDetailComponentState {
  model?: TeacherSkillViewModel;
  loading: boolean;
  loaded: boolean;
  errorOccurred: boolean;
  errorMessage: string;
}

class TeacherSkillDetailComponent extends React.Component<
  TeacherSkillDetailComponentProps,
  TeacherSkillDetailComponentState
> {
  state = {
    model: new TeacherSkillViewModel(),
    loading: false,
    loaded: true,
    errorOccurred: false,
    errorMessage: '',
  };

  handleEditClick(e: any) {
    this.props.history.push(
      ClientRoutes.TeacherSkills + '/edit/' + this.state.model!.id
    );
  }

  componentDidMount() {
    this.setState({ ...this.state, loading: true });

    axios
      .get<Api.TeacherSkillClientResponseModel>(
        Constants.ApiEndpoint +
          ApiRoutes.TeacherSkills +
          '/' +
          this.props.match.params.id,
        {
          headers: GlobalUtilities.defaultHeaders(),
        }
      )
      .then(response => {
        GlobalUtilities.logInfo(response);

        let mapper = new TeacherSkillMapper();

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
            <div>
              <h3>Name</h3>
              <p>{String(this.state.model!.name)}</p>
            </div>
          </div>
          {message}
          <div>
            <h3>Rates</h3>
            <RateTableComponent
              history={this.props.history}
              match={this.props.match}
              apiRoute={
                Constants.ApiEndpoint +
                ApiRoutes.TeacherSkills +
                '/' +
                this.state.model!.id +
                '/' +
                ApiRoutes.Rates
              }
            />
          </div>
          <div>
            <h3>TeacherTeacherSkills</h3>
            <TeacherTeacherSkillTableComponent
              history={this.props.history}
              match={this.props.match}
              apiRoute={
                Constants.ApiEndpoint +
                ApiRoutes.TeacherSkills +
                '/' +
                this.state.model!.id +
                '/' +
                ApiRoutes.TeacherTeacherSkills
              }
            />
          </div>
        </div>
      );
    } else {
      return null;
    }
  }
}

export const WrappedTeacherSkillDetailComponent = Form.create({
  name: 'TeacherSkill Detail',
})(TeacherSkillDetailComponent);


/*<Codenesium>
    <Hash>46609d3f1804827bd35c341e5f9419e0</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/