import React, { Component, FormEvent } from 'react';
import axios from 'axios';
import { Constants, ApiRoutes, ClientRoutes } from '../../constants';
import * as Api from '../../api/models';
import TeacherSkillMapper from './teacherSkillMapper';
import TeacherSkillViewModel from './teacherSkillViewModel';
import { Form, Input, Button, Spin, Alert } from 'antd';
import { WrappedFormUtils } from 'antd/es/form/Form';

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
      .get(
        Constants.ApiEndpoint +
          ApiRoutes.TeacherSkills +
          '/' +
          this.props.match.params.id,
        {
          headers: {
            'Content-Type': 'application/json',
          },
        }
      )
      .then(
        resp => {
          let response = resp.data as Api.TeacherSkillClientResponseModel;

          console.log(response);

          let mapper = new TeacherSkillMapper();

          this.setState({
            model: mapper.mapApiResponseToViewModel(response),
            loading: false,
            loaded: true,
            errorOccurred: false,
            errorMessage: '',
          });
        },
        error => {
          console.log(error);
          this.setState({
            model: undefined,
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
              <h3>id</h3>
              <p>{String(this.state.model!.id)}</p>
            </div>
            <div>
              <h3>name</h3>
              <p>{String(this.state.model!.name)}</p>
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

export const WrappedTeacherSkillDetailComponent = Form.create({
  name: 'TeacherSkill Detail',
})(TeacherSkillDetailComponent);


/*<Codenesium>
    <Hash>c03838986a8430fde75d943e17acbab5</Hash>
</Codenesium>*/