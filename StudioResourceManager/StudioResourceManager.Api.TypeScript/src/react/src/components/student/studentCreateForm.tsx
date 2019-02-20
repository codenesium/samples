import React, { Component, FormEvent } from 'react';
import axios from 'axios';
import { CreateResponse } from '../../api/apiObjects';
import { LoadingForm } from '../../lib/components/loadingForm';
import { ErrorForm } from '../../lib/components/errorForm';
import { Constants, ApiRoutes, ClientRoutes } from '../../constants';
import * as Api from '../../api/models';
import StudentMapper from './studentMapper';
import StudentViewModel from './studentViewModel';
import { Form, Input, Button, Checkbox, InputNumber, DatePicker } from 'antd';
import { WrappedFormUtils } from 'antd/es/form/Form';
import { Alert } from 'antd';

interface StudentCreateComponentProps {
  form: WrappedFormUtils;
  history: any;
  match: any;
}

interface StudentCreateComponentState {
  model?: StudentViewModel;
  loading: boolean;
  loaded: boolean;
  errorOccurred: boolean;
  errorMessage: string;
  submitted: boolean;
}

class StudentCreateComponent extends React.Component<
  StudentCreateComponentProps,
  StudentCreateComponentState
> {
  state = {
    model: new StudentViewModel(),
    loading: false,
    loaded: true,
    errorOccurred: false,
    errorMessage: '',
    submitted: false,
  };

  handleSubmit = (e: FormEvent<HTMLFormElement>) => {
    e.preventDefault();
    this.props.form.validateFields((err: any, values: any) => {
      if (!err) {
        let model = values as StudentViewModel;
        console.log('Received values of form: ', model);
        this.submit(model);
      }
    });
  };

  submit = (model: StudentViewModel) => {
    let mapper = new StudentMapper();
    axios
      .post(
        Constants.ApiEndpoint + ApiRoutes.Students,
        mapper.mapViewModelToApiRequest(model),
        {
          headers: {
            'Content-Type': 'application/json',
          },
        }
      )
      .then(
        resp => {
          let response = resp.data as CreateResponse<
            Api.StudentClientRequestModel
          >;
          this.setState({
            ...this.state,
            submitted: true,
            model: mapper.mapApiResponseToViewModel(response.record!),
            errorOccurred: false,
            errorMessage: '',
          });
          console.log(response);
        },
        error => {
          console.log(error);
          this.setState({
            ...this.state,
            submitted: true,
            errorOccurred: true,
            errorMessage: 'Error from API',
          });
        }
      );
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
      return <LoadingForm />;
    } else if (this.state.loaded) {
      return (
        <Form onSubmit={this.handleSubmit}>
          <Form.Item>
            <label htmlFor="birthday">birthday</label>
            <br />
            {getFieldDecorator('birthday', {
              rules: [],
            })(<DatePicker placeholder={'birthday'} id={'birthday'} />)}
          </Form.Item>

          <Form.Item>
            <label htmlFor="email">email</label>
            <br />
            {getFieldDecorator('email', {
              rules: [],
            })(<Input placeholder={'email'} id={'email'} />)}
          </Form.Item>

          <Form.Item>
            <label htmlFor="emailRemindersEnabled">
              Email Reminders Enabled
            </label>
            <br />
            {getFieldDecorator('emailRemindersEnabled', {
              rules: [],
            })(<Checkbox />)}
          </Form.Item>

          <Form.Item>
            <label htmlFor="familyId">familyId</label>
            <br />
            {getFieldDecorator('familyId', {
              rules: [],
            })(<InputNumber placeholder={'familyId'} id={'familyId'} />)}
          </Form.Item>

          <Form.Item>
            <label htmlFor="firstName">First Name</label>
            <br />
            {getFieldDecorator('firstName', {
              rules: [],
            })(<Input placeholder={'First Name'} id={'firstName'} />)}
          </Form.Item>

          <Form.Item>
            <label htmlFor="isAdult">Is Adult</label>
            <br />
            {getFieldDecorator('isAdult', {
              rules: [],
            })(<Checkbox />)}
          </Form.Item>

          <Form.Item>
            <label htmlFor="lastName">Last Name</label>
            <br />
            {getFieldDecorator('lastName', {
              rules: [],
            })(<Input placeholder={'Last Name'} id={'lastName'} />)}
          </Form.Item>

          <Form.Item>
            <label htmlFor="phone">phone</label>
            <br />
            {getFieldDecorator('phone', {
              rules: [],
            })(<InputNumber placeholder={'phone'} id={'phone'} />)}
          </Form.Item>

          <Form.Item>
            <label htmlFor="smsRemindersEnabled">SMS Reminders Enabled</label>
            <br />
            {getFieldDecorator('smsRemindersEnabled', {
              rules: [],
            })(<Checkbox />)}
          </Form.Item>

          <Form.Item>
            <label htmlFor="userId">userId</label>
            <br />
            {getFieldDecorator('userId', {
              rules: [],
            })(<InputNumber placeholder={'userId'} id={'userId'} />)}
          </Form.Item>

          <Form.Item>
            <Button type="primary" htmlType="submit">
              Submit
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

export const WrappedStudentCreateComponent = Form.create({
  name: 'Student Create',
})(StudentCreateComponent);


/*<Codenesium>
    <Hash>e70d7e628c61171e39891d8951ea420f</Hash>
</Codenesium>*/