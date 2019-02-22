import React, { Component, FormEvent } from 'react';
import axios from 'axios';
import { Constants, ApiRoutes, ClientRoutes } from '../../constants';
import * as Api from '../../api/models';
import StudentMapper from './studentMapper';
import StudentViewModel from './studentViewModel';
import { Form, Input, Button, Spin, Alert } from 'antd';
import { WrappedFormUtils } from 'antd/es/form/Form';

interface StudentDetailComponentProps {
  form: WrappedFormUtils;
  history: any;
  match: any;
}

interface StudentDetailComponentState {
  model?: StudentViewModel;
  loading: boolean;
  loaded: boolean;
  errorOccurred: boolean;
  errorMessage: string;
}

class StudentDetailComponent extends React.Component<
  StudentDetailComponentProps,
  StudentDetailComponentState
> {
  state = {
    model: new StudentViewModel(),
    loading: false,
    loaded: true,
    errorOccurred: false,
    errorMessage: '',
  };

  handleEditClick(e: any) {
    this.props.history.push(
      ClientRoutes.Students + '/edit/' + this.state.model!.id
    );
  }

  componentDidMount() {
    this.setState({ ...this.state, loading: true });

    axios
      .get(
        Constants.ApiEndpoint +
          ApiRoutes.Students +
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
          let response = resp.data as Api.StudentClientResponseModel;

          console.log(response);

          let mapper = new StudentMapper();

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
            loaded: true,
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
              <h3>birthday</h3>
              <p>{String(this.state.model!.birthday)}</p>
            </div>
            <div>
              <h3>email</h3>
              <p>{String(this.state.model!.email)}</p>
            </div>
            <div>
              <h3>emailRemindersEnabled</h3>
              <p>{String(this.state.model!.emailRemindersEnabled)}</p>
            </div>
            <div>
              <h3>familyId</h3>
              <p>{String(this.state.model!.familyId)}</p>
            </div>
            <div>
              <h3>firstName</h3>
              <p>{String(this.state.model!.firstName)}</p>
            </div>
            <div>
              <h3>id</h3>
              <p>{String(this.state.model!.id)}</p>
            </div>
            <div>
              <h3>isAdult</h3>
              <p>{String(this.state.model!.isAdult)}</p>
            </div>
            <div>
              <h3>lastName</h3>
              <p>{String(this.state.model!.lastName)}</p>
            </div>
            <div>
              <h3>phone</h3>
              <p>{String(this.state.model!.phone)}</p>
            </div>
            <div>
              <h3>smsRemindersEnabled</h3>
              <p>{String(this.state.model!.smsRemindersEnabled)}</p>
            </div>
            <div>
              <h3>userId</h3>
              <p>{String(this.state.model!.userId)}</p>
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

export const WrappedStudentDetailComponent = Form.create({
  name: 'Student Detail',
})(StudentDetailComponent);


/*<Codenesium>
    <Hash>33456aa5413c45c090702914ee04756f</Hash>
</Codenesium>*/