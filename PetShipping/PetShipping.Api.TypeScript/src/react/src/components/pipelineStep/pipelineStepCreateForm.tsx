import React, { Component, FormEvent } from 'react';
import axios, { AxiosError, AxiosResponse } from 'axios';
import { ActionResponse, CreateResponse } from '../../api/apiObjects';
import { Constants, ApiRoutes, ClientRoutes } from '../../constants';
import * as Api from '../../api/models';
import PipelineStepMapper from './pipelineStepMapper';
import PipelineStepViewModel from './pipelineStepViewModel';
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
import { PipelineStepStatusSelectComponent } from '../shared/pipelineStepStatusSelect';
import { EmployeeSelectComponent } from '../shared/employeeSelect';

interface PipelineStepCreateComponentProps {
  form: WrappedFormUtils;
  history: any;
  match: any;
}

interface PipelineStepCreateComponentState {
  model?: PipelineStepViewModel;
  loading: boolean;
  loaded: boolean;
  errorOccurred: boolean;
  errorMessage: string;
  submitted: boolean;
  submitting: boolean;
}

class PipelineStepCreateComponent extends React.Component<
  PipelineStepCreateComponentProps,
  PipelineStepCreateComponentState
> {
  state = {
    model: new PipelineStepViewModel(),
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
        let model = values as PipelineStepViewModel;
        this.submit(model);
      } else {
        this.setState({ ...this.state, submitting: false, submitted: false });
      }
    });
  };

  submit = (model: PipelineStepViewModel) => {
    let mapper = new PipelineStepMapper();
    axios
      .post<CreateResponse<Api.PipelineStepClientRequestModel>>(
        Constants.ApiEndpoint + ApiRoutes.PipelineSteps,
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
          <Form.Item>
            <label htmlFor="name">Name (required)</label>
            <br />
            {getFieldDecorator('name', {
              rules: [
                { required: true, message: 'Required' },
                { max: 128, message: 'Exceeds max length of 128' },
              ],
            })(<Input placeholder={'Name'} />)}
          </Form.Item>

          <PipelineStepStatusSelectComponent
            apiRoute={Constants.ApiEndpoint + ApiRoutes.PipelineStepStatus}
            getFieldDecorator={this.props.form.getFieldDecorator}
            propertyName="pipelineStepStatusId"
            required={true}
            selectedValue={this.state.model!.pipelineStepStatusId}
          />

          <EmployeeSelectComponent
            apiRoute={Constants.ApiEndpoint + ApiRoutes.Employees}
            getFieldDecorator={this.props.form.getFieldDecorator}
            propertyName="shipperId"
            required={true}
            selectedValue={this.state.model!.shipperId}
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

export const WrappedPipelineStepCreateComponent = Form.create({
  name: 'PipelineStep Create',
})(PipelineStepCreateComponent);


/*<Codenesium>
    <Hash>21b19c996c1a0bbff7dbfaf6c6259512</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/