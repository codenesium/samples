import React, { Component, FormEvent } from 'react';
import axios, { AxiosError, AxiosResponse } from 'axios';
import { Constants, ApiRoutes, ClientRoutes } from '../../constants';
import * as Api from '../../api/models';
import TeacherMapper from './teacherMapper';
import TeacherViewModel from './teacherViewModel';
import { Form, Input, Button, Spin, Alert } from 'antd';
import { WrappedFormUtils } from 'antd/es/form/Form';
import * as GlobalUtilities from '../../lib/globalUtilities';
import { EventTeacherTableComponent } from '../shared/eventTeacherTable';
import { RateTableComponent } from '../shared/rateTable';
import { TeacherTeacherSkillTableComponent } from '../shared/teacherTeacherSkillTable';

interface TeacherDetailComponentProps {
  form: WrappedFormUtils;
  history: any;
  match: any;
}

interface TeacherDetailComponentState {
  model?: TeacherViewModel;
  loading: boolean;
  loaded: boolean;
  errorOccurred: boolean;
  errorMessage: string;
}

class TeacherDetailComponent extends React.Component<
  TeacherDetailComponentProps,
  TeacherDetailComponentState
> {
  state = {
    model: new TeacherViewModel(),
    loading: false,
    loaded: true,
    errorOccurred: false,
    errorMessage: '',
  };

  handleEditClick(e: any) {
    this.props.history.push(
      ClientRoutes.Teachers + '/edit/' + this.state.model!.id
    );
  }

  componentDidMount() {
    this.setState({ ...this.state, loading: true });

    axios
      .get<Api.TeacherClientResponseModel>(
        Constants.ApiEndpoint +
          ApiRoutes.Teachers +
          '/' +
          this.props.match.params.id,
        {
          headers: GlobalUtilities.defaultHeaders(),
        }
      )
      .then(response => {
        GlobalUtilities.logInfo(response);

        let mapper = new TeacherMapper();

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
              <h3>Birthday</h3>
              <p>{String(this.state.model!.birthday)}</p>
            </div>
            <div>
              <h3>Email</h3>
              <p>{String(this.state.model!.email)}</p>
            </div>
            <div>
              <h3>First Name</h3>
              <p>{String(this.state.model!.firstName)}</p>
            </div>
            <div>
              <h3>Last Name</h3>
              <p>{String(this.state.model!.lastName)}</p>
            </div>
            <div>
              <h3>Phone</h3>
              <p>{String(this.state.model!.phone)}</p>
            </div>
            <div style={{ marginBottom: '10px' }}>
              <h3>User</h3>
              <p>
                {String(
                  this.state.model!.userIdNavigation &&
                    this.state.model!.userIdNavigation!.toDisplay()
                )}
              </p>
            </div>
          </div>
          {message}
          <div>
            <h3>EventTeachers</h3>
            <EventTeacherTableComponent
              history={this.props.history}
              match={this.props.match}
              apiRoute={
                Constants.ApiEndpoint +
                ApiRoutes.Teachers +
                '/' +
                this.state.model!.id +
                '/' +
                ApiRoutes.EventTeachers
              }
            />
          </div>
          <div>
            <h3>Rates</h3>
            <RateTableComponent
              history={this.props.history}
              match={this.props.match}
              apiRoute={
                Constants.ApiEndpoint +
                ApiRoutes.Teachers +
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
                ApiRoutes.Teachers +
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

export const WrappedTeacherDetailComponent = Form.create({
  name: 'Teacher Detail',
})(TeacherDetailComponent);


/*<Codenesium>
    <Hash>73653683dd1c79ed53a7919c863f29c9</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/