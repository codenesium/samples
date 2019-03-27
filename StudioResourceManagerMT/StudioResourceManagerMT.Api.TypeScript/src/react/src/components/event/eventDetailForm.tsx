import React, { Component, FormEvent } from 'react';
import axios, { AxiosError, AxiosResponse } from 'axios';
import { Constants, ApiRoutes, ClientRoutes } from '../../constants';
import * as Api from '../../api/models';
import EventMapper from './eventMapper';
import EventViewModel from './eventViewModel';
import { Form, Input, Button, Spin, Alert } from 'antd';
import { WrappedFormUtils } from 'antd/es/form/Form';
import * as GlobalUtilities from '../../lib/globalUtilities';
import { EventStudentTableComponent } from '../shared/eventStudentTable';
import { EventTeacherTableComponent } from '../shared/eventTeacherTable';

interface EventDetailComponentProps {
  form: WrappedFormUtils;
  history: any;
  match: any;
}

interface EventDetailComponentState {
  model?: EventViewModel;
  loading: boolean;
  loaded: boolean;
  errorOccurred: boolean;
  errorMessage: string;
}

class EventDetailComponent extends React.Component<
  EventDetailComponentProps,
  EventDetailComponentState
> {
  state = {
    model: new EventViewModel(),
    loading: false,
    loaded: true,
    errorOccurred: false,
    errorMessage: '',
  };

  handleEditClick(e: any) {
    this.props.history.push(
      ClientRoutes.Events + '/edit/' + this.state.model!.id
    );
  }

  componentDidMount() {
    this.setState({ ...this.state, loading: true });

    axios
      .get<Api.EventClientResponseModel>(
        Constants.ApiEndpoint +
          ApiRoutes.Events +
          '/' +
          this.props.match.params.id,
        {
          headers: GlobalUtilities.defaultHeaders(),
        }
      )
      .then(response => {
        GlobalUtilities.logInfo(response);

        let mapper = new EventMapper();

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
              <h3>Actual End Date</h3>
              <p>{String(this.state.model!.actualEndDate)}</p>
            </div>
            <div>
              <h3>Actual Start Date</h3>
              <p>{String(this.state.model!.actualStartDate)}</p>
            </div>
            <div>
              <h3>Bill Amount</h3>
              <p>{String(this.state.model!.billAmount)}</p>
            </div>
            <div style={{ marginBottom: '10px' }}>
              <h3>Event Status</h3>
              <p>
                {String(
                  this.state.model!.eventStatusIdNavigation &&
                    this.state.model!.eventStatusIdNavigation!.toDisplay()
                )}
              </p>
            </div>
            <div>
              <h3>Scheduled End Date</h3>
              <p>{String(this.state.model!.scheduledEndDate)}</p>
            </div>
            <div>
              <h3>Scheduled Start Date</h3>
              <p>{String(this.state.model!.scheduledStartDate)}</p>
            </div>
            <div>
              <h3>Student Notes</h3>
              <p>{String(this.state.model!.studentNote)}</p>
            </div>
            <div>
              <h3>Teacher Notes</h3>
              <p>{String(this.state.model!.teacherNote)}</p>
            </div>
          </div>
          {message}
          <div>
            <h3>EventStudents</h3>
            <EventStudentTableComponent
              history={this.props.history}
              match={this.props.match}
              apiRoute={
                Constants.ApiEndpoint +
                ApiRoutes.Events +
                '/' +
                this.state.model!.id +
                '/' +
                ApiRoutes.EventStudents
              }
            />
          </div>
          <div>
            <h3>EventTeachers</h3>
            <EventTeacherTableComponent
              history={this.props.history}
              match={this.props.match}
              apiRoute={
                Constants.ApiEndpoint +
                ApiRoutes.Events +
                '/' +
                this.state.model!.id +
                '/' +
                ApiRoutes.EventTeachers
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

export const WrappedEventDetailComponent = Form.create({
  name: 'Event Detail',
})(EventDetailComponent);


/*<Codenesium>
    <Hash>f301c82b82f9aacc284e29459c1da8f5</Hash>
</Codenesium>*/