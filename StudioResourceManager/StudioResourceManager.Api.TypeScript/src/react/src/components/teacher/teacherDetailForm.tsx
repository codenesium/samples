import React, { Component, FormEvent } from 'react';
import axios from 'axios';
import { LoadingForm } from '../../lib/components/loadingForm';
import { Constants, ApiRoutes, ClientRoutes } from '../../constants';
import * as Api from '../../api/models';
import TeacherMapper from './teacherMapper';
import TeacherViewModel from './teacherViewModel';
import { Form, Input, Button } from 'antd';
import { WrappedFormUtils } from 'antd/es/form/Form';
import { Alert } from 'antd';

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
      .get(
        Constants.ApiEndpoint +
          ApiRoutes.Teachers +
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
          let response = resp.data as Api.TeacherClientResponseModel;

          console.log(response);

          let mapper = new TeacherMapper();

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
      return <LoadingForm />;
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
              <div>birthday</div>
              <div>{this.state.model!.birthday}</div>
            </div>
            <div>
              <div>email</div>
              <div>{this.state.model!.email}</div>
            </div>
            <div>
              <div>firstName</div>
              <div>{this.state.model!.firstName}</div>
            </div>
            <div>
              <div>lastName</div>
              <div>{this.state.model!.lastName}</div>
            </div>
            <div>
              <div>phone</div>
              <div>{this.state.model!.phone}</div>
            </div>
            <div style={{ marginBottom: '10px' }}>
              <h3>userId</h3>
              <div>{this.state.model!.userIdNavigation!.toDisplay()}</div>
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

export const WrappedTeacherDetailComponent = Form.create({
  name: 'Teacher Detail',
})(TeacherDetailComponent);


/*<Codenesium>
    <Hash>e5ea5cc16ce645d78e8b1ac9cbd42118</Hash>
</Codenesium>*/