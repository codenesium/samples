import React, { Component, FormEvent } from 'react';
import axios from 'axios';
import { CreateResponse } from '../../api/apiObjects';
import { Constants, ApiRoutes, ClientRoutes } from '../../constants';
import * as Api from '../../api/models';
import CallAssignmentMapper from './callAssignmentMapper';
import CallAssignmentViewModel from './callAssignmentViewModel';
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
import { CallSelectComponent } from '../shared/callSelect';
import { UnitSelectComponent } from '../shared/unitSelect';

interface CallAssignmentCreateComponentProps {
  form: WrappedFormUtils;
  history: any;
  match: any;
}

interface CallAssignmentCreateComponentState {
  model?: CallAssignmentViewModel;
  loading: boolean;
  loaded: boolean;
  errorOccurred: boolean;
  errorMessage: string;
  submitted: boolean;
}

class CallAssignmentCreateComponent extends React.Component<
  CallAssignmentCreateComponentProps,
  CallAssignmentCreateComponentState
> {
  state = {
    model: new CallAssignmentViewModel(),
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
        let model = values as CallAssignmentViewModel;
        console.log('Received values of form: ', model);
        this.submit(model);
      }
    });
  };

  submit = (model: CallAssignmentViewModel) => {
    let mapper = new CallAssignmentMapper();
    axios
      .post(
        Constants.ApiEndpoint + ApiRoutes.CallAssignments,
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
            Api.CallAssignmentClientRequestModel
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
      return <Spin size="large" />;
    } else if (this.state.loaded) {
      return (
        <Form onSubmit={this.handleSubmit}>
          <Form.Item>
            <label htmlFor="callId">callId</label>
            <br />
            {getFieldDecorator('callId', {
              rules: [{ required: true, message: 'Required' }],
            })(<Input placeholder={'callId'} />)}
          </Form.Item>

          <Form.Item>
            <label htmlFor="unitId">unitId</label>
            <br />
            {getFieldDecorator('unitId', {
              rules: [{ required: true, message: 'Required' }],
            })(<Input placeholder={'unitId'} />)}
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

export const WrappedCallAssignmentCreateComponent = Form.create({
  name: 'CallAssignment Create',
})(CallAssignmentCreateComponent);


/*<Codenesium>
    <Hash>c15d7124b6da430dec1f1eee582fc258</Hash>
</Codenesium>*/