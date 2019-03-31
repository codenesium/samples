import React, { Component, FormEvent } from 'react';
import axios, { AxiosError, AxiosResponse } from 'axios';
import { ActionResponse, CreateResponse } from '../../api/apiObjects';
import { Constants, ApiRoutes, ClientRoutes } from '../../constants';
import * as Api from '../../api/models';
import EventTeacherMapper from './eventTeacherMapper';
import EventTeacherViewModel from './eventTeacherViewModel';
import {
  Form,
  Input,
  Button,
  Switch,
  InputNumber,
  DatePicker,
  Spin,
  Alert,
  TimePicker,
} from 'antd';
import { WrappedFormUtils } from 'antd/es/form/Form';
import * as GlobalUtilities from '../../lib/globalUtilities';
import { EventSelectComponent } from '../shared/eventSelect';
import { TeacherSelectComponent } from '../shared/teacherSelect';

interface EventTeacherCreateComponentProps {
  form: WrappedFormUtils;
  history: any;
  match: any;
}

interface EventTeacherCreateComponentState {
  model?: EventTeacherViewModel;
  loading: boolean;
  loaded: boolean;
  errorOccurred: boolean;
  errorMessage: string;
  submitted: boolean;
  submitting: boolean;
}

class EventTeacherCreateComponent extends React.Component<
  EventTeacherCreateComponentProps,
  EventTeacherCreateComponentState
> {
  state = {
    model: new EventTeacherViewModel(),
    loading: false,
    loaded: true,
    errorOccurred: false,
    errorMessage: '',
    submitted: false,
    submitting: false,
  };

  handleSubmit = (e: FormEvent<HTMLFormElement>) => {
    e.preventDefault();
    this.setState({ ...this.state, submitting: true, submitted: false });
    this.props.form.validateFields((err: any, values: any) => {
      if (!err) {
        let model = values as EventTeacherViewModel;
        this.submit(model);
      } else {
        this.setState({ ...this.state, submitting: false, submitted: false });
      }
    });
  };

  submit = (model: EventTeacherViewModel) => {
    let mapper = new EventTeacherMapper();
    axios
      .post<CreateResponse<Api.EventTeacherClientRequestModel>>(
        Constants.ApiEndpoint + ApiRoutes.EventTeachers,
        mapper.mapViewModelToApiRequest(model),
        {
          headers: GlobalUtilities.defaultHeaders(),
        }
      )
      .then(response => {
        this.setState({
          ...this.state,
          submitted: true,
          submitting: false,
          model: mapper.mapApiResponseToViewModel(response.data.record!),
          errorOccurred: false,
          errorMessage: '',
        });
        GlobalUtilities.logInfo(response);
      })
      .catch((error: AxiosError) => {
        GlobalUtilities.logError(error);

        if (error.response && error.response.status == 422) {
          let errorResponse = error.response.data as ActionResponse;
          errorResponse.validationErrors.forEach(x => {
            this.props.form.setFields({
              [GlobalUtilities.toLowerCaseFirstLetter(x.propertyName)]: {
                value: this.props.form.getFieldValue(
                  GlobalUtilities.toLowerCaseFirstLetter(x.propertyName)
                ),
                errors: [new Error(x.errorMessage)],
              },
            });
          });
          this.setState({
            ...this.state,
            submitted: true,
            submitting: false,
            errorOccurred: false,
            errorMessage: '',
          });
        } else {
          this.setState({
            ...this.state,
            submitted: true,
            submitting: false,
            errorOccurred: true,
            errorMessage: 'Error Occurred',
          });
        }
      });
  };

  render() {
    const {
      getFieldDecorator,
      getFieldsError,
      getFieldError,
      isFieldTouched,
    } = this.props.form;

    let message: JSX.Element = <div />;
    if (this.state.submitted) {
      if (this.state.errorOccurred) {
        message = <Alert message={this.state.errorMessage} type="error" />;
      } else {
        message = <Alert message="Submitted" type="success" />;
      }
    }

    if (this.state.loading) {
      return <Spin size="large" />;
    } else if (this.state.loaded) {
      return (
        <Form onSubmit={this.handleSubmit}>
          <EventSelectComponent
            apiRoute={Constants.ApiEndpoint + ApiRoutes.Events}
            getFieldDecorator={this.props.form.getFieldDecorator}
            propertyName="eventId"
            required={true}
            selectedValue={this.state.model!.eventId}
          />

          <TeacherSelectComponent
            apiRoute={Constants.ApiEndpoint + ApiRoutes.Teachers}
            getFieldDecorator={this.props.form.getFieldDecorator}
            propertyName="teacherId"
            required={true}
            selectedValue={this.state.model!.teacherId}
          />

          <Form.Item>
            <Button
              type="primary"
              htmlType="submit"
              loading={this.state.submitting}
            >
              {this.state.submitting ? 'Submitting...' : 'Submit'}
            </Button>
          </Form.Item>
          {message}
        </Form>
      );
    } else {
      return null;
    }
  }
}

export const WrappedEventTeacherCreateComponent = Form.create({
  name: 'EventTeacher Create',
})(EventTeacherCreateComponent);


/*<Codenesium>
    <Hash>b7111c7d48ba9f53e38c533f143c26fb</Hash>
</Codenesium>*/