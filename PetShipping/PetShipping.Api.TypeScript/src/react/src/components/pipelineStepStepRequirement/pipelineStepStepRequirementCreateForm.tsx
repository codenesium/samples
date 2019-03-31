import React, { Component, FormEvent } from 'react';
import axios, { AxiosError, AxiosResponse } from 'axios';
import { ActionResponse, CreateResponse } from '../../api/apiObjects';
import { Constants, ApiRoutes, ClientRoutes } from '../../constants';
import * as Api from '../../api/models';
import PipelineStepStepRequirementMapper from './pipelineStepStepRequirementMapper';
import PipelineStepStepRequirementViewModel from './pipelineStepStepRequirementViewModel';
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
import { PipelineStepSelectComponent } from '../shared/pipelineStepSelect';

interface PipelineStepStepRequirementCreateComponentProps {
  form: WrappedFormUtils;
  history: any;
  match: any;
}

interface PipelineStepStepRequirementCreateComponentState {
  model?: PipelineStepStepRequirementViewModel;
  loading: boolean;
  loaded: boolean;
  errorOccurred: boolean;
  errorMessage: string;
  submitted: boolean;
  submitting: boolean;
}

class PipelineStepStepRequirementCreateComponent extends React.Component<
  PipelineStepStepRequirementCreateComponentProps,
  PipelineStepStepRequirementCreateComponentState
> {
  state = {
    model: new PipelineStepStepRequirementViewModel(),
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
        let model = values as PipelineStepStepRequirementViewModel;
        this.submit(model);
      } else {
        this.setState({ ...this.state, submitting: false, submitted: false });
      }
    });
  };

  submit = (model: PipelineStepStepRequirementViewModel) => {
    let mapper = new PipelineStepStepRequirementMapper();
    axios
      .post<CreateResponse<Api.PipelineStepStepRequirementClientRequestModel>>(
        Constants.ApiEndpoint + ApiRoutes.PipelineStepStepRequirements,
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
            <label htmlFor="details">Details (required)</label>
            <br />
            {getFieldDecorator('details', {
              rules: [{ required: true, message: 'Required' }],
            })(<Input placeholder={'Details'} />)}
          </Form.Item>

          <PipelineStepSelectComponent
            apiRoute={Constants.ApiEndpoint + ApiRoutes.PipelineSteps}
            getFieldDecorator={this.props.form.getFieldDecorator}
            propertyName="pipelineStepId"
            required={true}
            selectedValue={this.state.model!.pipelineStepId}
          />

          <Form.Item>
            <label htmlFor="requirementMet">Requirement Met (required)</label>
            <br />
            {getFieldDecorator('requirementMet', {
              rules: [],
              valuePropName: 'checked',
            })(<Switch />)}
          </Form.Item>

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

export const WrappedPipelineStepStepRequirementCreateComponent = Form.create({
  name: 'PipelineStepStepRequirement Create',
})(PipelineStepStepRequirementCreateComponent);


/*<Codenesium>
    <Hash>266ca42b9424eb730e30562367c04ef7</Hash>
</Codenesium>*/