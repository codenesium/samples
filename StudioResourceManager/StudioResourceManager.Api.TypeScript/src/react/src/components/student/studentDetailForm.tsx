import React, { Component, FormEvent } from 'react';
import axios from 'axios';
import { LoadingForm } from '../../lib/components/loadingForm';
import { Constants, ApiRoutes, ClientRoutes } from '../../constants';
import * as Api from '../../api/models';
import StudentMapper from './studentMapper';
import StudentViewModel from './studentViewModel';
import { Form, Input, Button } from 'antd';
import { WrappedFormUtils } from 'antd/es/form/Form';
import { Alert } from 'antd';

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
              <div>emailRemindersEnabled</div>
              <div>{this.state.model!.emailRemindersEnabled}</div>
            </div>
            <div style={{ marginBottom: '10px' }}>
              <h3>familyId</h3>
              <div>{this.state.model!.familyIdNavigation!.toDisplay()}</div>
            </div>
            <div>
              <div>firstName</div>
              <div>{this.state.model!.firstName}</div>
            </div>
            <div>
              <div>isAdult</div>
              <div>{this.state.model!.isAdult}</div>
            </div>
            <div>
              <div>lastName</div>
              <div>{this.state.model!.lastName}</div>
            </div>
            <div>
              <div>phone</div>
              <div>{this.state.model!.phone}</div>
            </div>
            <div>
              <div>smsRemindersEnabled</div>
              <div>{this.state.model!.smsRemindersEnabled}</div>
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

export const WrappedStudentDetailComponent = Form.create({
  name: 'Student Detail',
})(StudentDetailComponent);


/*<Codenesium>
    <Hash>26bea170f3912a9e8e5f3787e04bd563</Hash>
</Codenesium>*/