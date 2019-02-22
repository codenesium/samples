import React, { Component, FormEvent } from 'react';
import axios from 'axios';
import { CreateResponse } from '../../api/apiObjects';
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
  };

  handleSubmit = (e: FormEvent<HTMLFormElement>) => {
    e.preventDefault();
    this.props.form.validateFields((err: any, values: any) => {
      if (!err) {
        let model = values as PipelineStepStepRequirementViewModel;
        console.log('Received values of form: ', model);
        this.submit(model);
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
            <label htmlFor="detail">details</label>
            <br />
            {getFieldDecorator('detail', {
              rules: [
                { required: true, message: 'Required' },
                { whitespace: true, message: 'Required' },
              ],
            })(<DatePicker format={'YYYY-MM-DD'} placeholder={'details'} />)}
          </Form.Item>

          <Form.Item>
            <label htmlFor="pipelineStepId">pipelineStepId</label>
            <br />
            {getFieldDecorator('pipelineStepId', {
              rules: [
                { required: true, message: 'Required' },
                { whitespace: true, message: 'Required' },
              ],
            })(
              <DatePicker
                format={'YYYY-MM-DD'}
                placeholder={'pipelineStepId'}
              />
            )}
          </Form.Item>

          <Form.Item>
            <label htmlFor="requirementMet">requirementMet</label>
            <br />
            {getFieldDecorator('requirementMet', {
              rules: [
                { required: true, message: 'Required' },
                { whitespace: true, message: 'Required' },
              ],
            })(
              <DatePicker
                format={'YYYY-MM-DD'}
                placeholder={'requirementMet'}
              />
            )}
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

export const WrappedPipelineStepStepRequirementCreateComponent = Form.create({
  name: 'PipelineStepStepRequirement Create',
})(PipelineStepStepRequirementCreateComponent);


/*<Codenesium>
    <Hash>a3da9a61d9d99ba244aca3a10223654d</Hash>
</Codenesium>*/