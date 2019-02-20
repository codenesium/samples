import React, { Component, FormEvent } from 'react';
import axios from 'axios';
import { CreateResponse } from '../../api/apiObjects';
import { LoadingForm } from '../../lib/components/loadingForm';
import { ErrorForm } from '../../lib/components/errorForm';
import { Constants, ApiRoutes, ClientRoutes } from '../../constants';
import * as Api from '../../api/models';
import TeacherMapper from './teacherMapper';
import TeacherViewModel from './teacherViewModel';
import { Form, Input, Button, Checkbox, InputNumber, DatePicker } from 'antd';
import { WrappedFormUtils } from 'antd/es/form/Form';
import { Alert } from 'antd';

interface TeacherCreateComponentProps {
  form: WrappedFormUtils;
  history: any;
  match: any;
}

interface TeacherCreateComponentState {
  model?: TeacherViewModel;
  loading: boolean;
  loaded: boolean;
  errorOccurred: boolean;
  errorMessage: string;
  submitted: boolean;
}

class TeacherCreateComponent extends React.Component<
  TeacherCreateComponentProps,
  TeacherCreateComponentState
> {
  state = {
    model: new TeacherViewModel(),
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
        let model = values as TeacherViewModel;
        console.log('Received values of form: ', model);
        this.submit(model);
      }
    });
  };

  submit = (model: TeacherViewModel) => {
    let mapper = new TeacherMapper();
    axios
      .post(
        Constants.ApiEndpoint + ApiRoutes.Teachers,
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
            Api.TeacherClientRequestModel
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
            <label htmlFor="firstName">First Name</label>
            <br />
            {getFieldDecorator('firstName', {
              rules: [],
            })(<Input placeholder={'First Name'} id={'firstName'} />)}
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

export const WrappedTeacherCreateComponent = Form.create({
  name: 'Teacher Create',
})(TeacherCreateComponent);


/*<Codenesium>
    <Hash>db470abd62cadb2b2cf8fcedd353fa79</Hash>
</Codenesium>*/