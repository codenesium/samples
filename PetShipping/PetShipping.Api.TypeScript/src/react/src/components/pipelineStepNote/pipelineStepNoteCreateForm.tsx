import React, { Component, FormEvent } from 'react';
import axios from 'axios';
import { ActionResponse, CreateResponse } from '../../api/apiObjects';
import { Constants, ApiRoutes, ClientRoutes } from '../../constants';
import * as Api from '../../api/models';
import PipelineStepNoteMapper from './pipelineStepNoteMapper';
import PipelineStepNoteViewModel from './pipelineStepNoteViewModel';
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
import { ToLowerCaseFirstLetter } from '../../lib/stringUtilities';
import { EmployeeSelectComponent } from '../shared/employeeSelect';
import { PipelineStepSelectComponent } from '../shared/pipelineStepSelect';

interface PipelineStepNoteCreateComponentProps {
  form: WrappedFormUtils;
  history: any;
  match: any;
}

interface PipelineStepNoteCreateComponentState {
  model?: PipelineStepNoteViewModel;
  loading: boolean;
  loaded: boolean;
  errorOccurred: boolean;
  errorMessage: string;
  submitted: boolean;
}

class PipelineStepNoteCreateComponent extends React.Component<
  PipelineStepNoteCreateComponentProps,
  PipelineStepNoteCreateComponentState
> {
  state = {
    model: new PipelineStepNoteViewModel(),
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
        let model = values as PipelineStepNoteViewModel;
        console.log('Received values of form: ', model);
        this.submit(model);
      }
    });
  };

  submit = (model: PipelineStepNoteViewModel) => {
    let mapper = new PipelineStepNoteMapper();
    axios
      .post(
        Constants.ApiEndpoint + ApiRoutes.PipelineStepNotes,
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
            Api.PipelineStepNoteClientRequestModel
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
          if (error.response.data) {
            let errorResponse = error.response.data as ActionResponse;

            errorResponse.validationErrors.forEach(x => {
              this.props.form.setFields({
                [ToLowerCaseFirstLetter(x.propertyName)]: {
                  value: this.props.form.getFieldValue(
                    ToLowerCaseFirstLetter(x.propertyName)
                  ),
                  errors: [new Error(x.errorMessage)],
                },
              });
            });
          }
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
            <label htmlFor="employeeId">employeeId</label>
            <br />
            {getFieldDecorator('employeeId', {
              rules: [{ required: true, message: 'Required' }],
            })(<Input placeholder={'employeeId'} />)}
          </Form.Item>

          <Form.Item>
            <label htmlFor="pipelineStepId">pipelineStepId</label>
            <br />
            {getFieldDecorator('pipelineStepId', {
              rules: [{ required: true, message: 'Required' }],
            })(<Input placeholder={'pipelineStepId'} />)}
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

export const WrappedPipelineStepNoteCreateComponent = Form.create({
  name: 'PipelineStepNote Create',
})(PipelineStepNoteCreateComponent);


/*<Codenesium>
    <Hash>d984596b8a6d14d9ad094412c37b79b4</Hash>
</Codenesium>*/