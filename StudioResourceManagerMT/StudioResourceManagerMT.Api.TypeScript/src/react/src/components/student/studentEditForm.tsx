import React, { Component, FormEvent } from 'react';
import axios, { AxiosError, AxiosResponse } from 'axios';
import { ActionResponse, CreateResponse } from '../../api/apiObjects';
import { Constants, ApiRoutes, ClientRoutes } from '../../constants';
import * as Api from '../../api/models';
import StudentMapper from './studentMapper';
import StudentViewModel from './studentViewModel';
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
import { FamilySelectComponent } from '../shared/familySelect';
import { UserSelectComponent } from '../shared/userSelect';
interface StudentEditComponentProps {
  form: WrappedFormUtils;
  history: any;
  match: any;
}

interface StudentEditComponentState {
  model?: StudentViewModel;
  loading: boolean;
  loaded: boolean;
  errorOccurred: boolean;
  errorMessage: string;
  submitted: boolean;
  submitting: boolean;
}

class StudentEditComponent extends React.Component<
  StudentEditComponentProps,
  StudentEditComponentState
> {
  state = {
    model: new StudentViewModel(),
    loading: false,
    loaded: true,
    errorOccurred: false,
    errorMessage: '',
    submitted: false,
    submitting: false,
  };

  componentDidMount() {
    this.setState({ ...this.state, loading: true });

    axios
      .get<Api.StudentClientResponseModel>(
        Constants.ApiEndpoint +
          ApiRoutes.Students +
          '/' +
          this.props.match.params.id,
        {
          headers: GlobalUtilities.defaultHeaders(),
        }
      )
      .then(response => {
        GlobalUtilities.logInfo(response);

        let mapper = new StudentMapper();

        this.setState({
          model: mapper.mapApiResponseToViewModel(response.data),
          loading: false,
          loaded: true,
          errorOccurred: false,
          errorMessage: '',
        });

        this.props.form.setFieldsValue(
          mapper.mapApiResponseToViewModel(response.data)
        );
      })
      .catch((error: AxiosError) => {
        GlobalUtilities.logError(error);

        if (error.response && error.response.status == 422) {
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
  }

  handleSubmit = (e: FormEvent<HTMLFormElement>) => {
    e.preventDefault();
    this.setState({ ...this.state, submitting: true, submitted: false });
    this.props.form.validateFields((err: any, values: any) => {
      if (!err) {
        let model = values as StudentViewModel;
        this.submit(model);
      } else {
        this.setState({ ...this.state, submitting: false, submitted: false });
      }
    });
  };

  submit = (model: StudentViewModel) => {
    let mapper = new StudentMapper();
    axios
      .put<CreateResponse<Api.StudentClientRequestModel>>(
        Constants.ApiEndpoint + ApiRoutes.Students + '/' + this.state.model!.id,
        mapper.mapViewModelToApiRequest(model),
        {
          headers: GlobalUtilities.defaultHeaders(),
        }
      )
      .then(response => {
        GlobalUtilities.logInfo(response);
        this.setState({
          ...this.state,
          submitted: true,
          submitting: false,
          model: mapper.mapApiResponseToViewModel(response.data.record!),
          errorOccurred: false,
          errorMessage: '',
        });
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
          <Form.Item>
            <label htmlFor="birthday">Birthday (required)</label>
            <br />
            {getFieldDecorator('birthday', {
              rules: [{ required: true, message: 'Required' }],
            })(<DatePicker format={'YYYY-MM-DD'} placeholder={'Birthday'} />)}
          </Form.Item>

          <Form.Item>
            <label htmlFor="email">Email (required)</label>
            <br />
            {getFieldDecorator('email', {
              rules: [
                { required: true, message: 'Required' },
                { max: 128, message: 'Exceeds max length of 128' },
              ],
            })(<Input placeholder={'Email'} />)}
          </Form.Item>

          <Form.Item>
            <label htmlFor="emailRemindersEnabled">
              Email Reminders Enabled (required)
            </label>
            <br />
            {getFieldDecorator('emailRemindersEnabled', {
              rules: [],
              valuePropName: 'checked',
            })(<Switch />)}
          </Form.Item>

          <FamilySelectComponent
            apiRoute={Constants.ApiEndpoint + ApiRoutes.Families}
            getFieldDecorator={this.props.form.getFieldDecorator}
            propertyName="familyId"
            required={true}
            selectedValue={this.state.model!.familyId}
          />

          <Form.Item>
            <label htmlFor="firstName">First Name (required)</label>
            <br />
            {getFieldDecorator('firstName', {
              rules: [
                { required: true, message: 'Required' },
                { max: 128, message: 'Exceeds max length of 128' },
              ],
            })(<Input placeholder={'First Name'} />)}
          </Form.Item>

          <Form.Item>
            <label htmlFor="isAdult">Is Adult (required)</label>
            <br />
            {getFieldDecorator('isAdult', {
              rules: [],
              valuePropName: 'checked',
            })(<Switch />)}
          </Form.Item>

          <Form.Item>
            <label htmlFor="lastName">Last Name (required)</label>
            <br />
            {getFieldDecorator('lastName', {
              rules: [
                { required: true, message: 'Required' },
                { max: 128, message: 'Exceeds max length of 128' },
              ],
            })(<Input placeholder={'Last Name'} />)}
          </Form.Item>

          <Form.Item>
            <label htmlFor="phone">Phone (required)</label>
            <br />
            {getFieldDecorator('phone', {
              rules: [
                { required: true, message: 'Required' },
                { max: 128, message: 'Exceeds max length of 128' },
              ],
            })(<Input placeholder={'Phone'} />)}
          </Form.Item>

          <Form.Item>
            <label htmlFor="smsRemindersEnabled">
              Sms Reminders Enabled (required)
            </label>
            <br />
            {getFieldDecorator('smsRemindersEnabled', {
              rules: [],
              valuePropName: 'checked',
            })(<Switch />)}
          </Form.Item>

          <UserSelectComponent
            apiRoute={Constants.ApiEndpoint + ApiRoutes.Users}
            getFieldDecorator={this.props.form.getFieldDecorator}
            propertyName="userId"
            required={true}
            selectedValue={this.state.model!.userId}
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

export const WrappedStudentEditComponent = Form.create({
  name: 'Student Edit',
})(StudentEditComponent);


/*<Codenesium>
    <Hash>982769de101831e10fd5d196773d91ca</Hash>
</Codenesium>*/