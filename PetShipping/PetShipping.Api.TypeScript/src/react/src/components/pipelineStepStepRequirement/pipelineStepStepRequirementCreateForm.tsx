import React, { Component, FormEvent } from 'react';
import axios from 'axios';
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
import { ToLowerCaseFirstLetter } from '../../lib/stringUtilities';
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
        console.log('Received values of form: ', model);
        this.submit(model);
      } else {
        this.setState({ ...this.state, submitting: false, submitted: false });
      }
    });
  };

  submit = (model: PipelineStepStepRequirementViewModel) => {
    let mapper = new PipelineStepStepRequirementMapper();
    axios
      .post(
        Constants.ApiEndpoint + ApiRoutes.PipelineStepStepRequirements,
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
            Api.PipelineStepStepRequirementClientRequestModel
          >;
          this.setState({
            ...this.state,
            submitted: true,
            submitting: false,
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
            submitting: false,
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
            <label htmlFor="detail">details</label>
            <br />
            {getFieldDecorator('detail', {
              rules: [{ required: true, message: 'Required' }],
            })(<Input placeholder={'details'} />)}
          </Form.Item>

          <Form.Item>
            <label htmlFor="pipelineStepId">pipelineStepId</label>
            <br />
            {getFieldDecorator('pipelineStepId', {
              rules: [{ required: true, message: 'Required' }],
            })(<Input placeholder={'pipelineStepId'} />)}
          </Form.Item>

          <Form.Item>
            <label htmlFor="requirementMet">requirementMet</label>
            <br />
            {getFieldDecorator('requirementMet', {
              rules: [{ required: true, message: 'Required' }],
            })(<Input placeholder={'requirementMet'} />)}
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
    <Hash>9877ef03caf5e1a3ef2bf3dc8dcb5ee6</Hash>
</Codenesium>*/