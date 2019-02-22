import React, { Component, FormEvent } from 'react';
import axios from 'axios';
import { CreateResponse } from '../../api/apiObjects';
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

interface PipelineStepNoteEditComponentProps {
  form: WrappedFormUtils;
  history: any;
  match: any;
}

interface PipelineStepNoteEditComponentState {
  model?: PipelineStepNoteViewModel;
  loading: boolean;
  loaded: boolean;
  errorOccurred: boolean;
  errorMessage: string;
  submitted: boolean;
}

class PipelineStepNoteEditComponent extends React.Component<
  PipelineStepNoteEditComponentProps,
  PipelineStepNoteEditComponentState
> {
  state = {
    model: new PipelineStepNoteViewModel(),
    loading: false,
    loaded: true,
    errorOccurred: false,
    errorMessage: '',
    submitted: false,
  };

  componentDidMount() {
    this.setState({ ...this.state, loading: true });

    axios
      .get(
        Constants.ApiEndpoint +
          ApiRoutes.PipelineStepNotes +
          '/' +
          this.props.match.params.id,
        {
          headers: {
            'Content-Type': 'application/json',
          },
        }
      )
      .then(
        resp => {
          let response = resp.data as Api.PipelineStepNoteClientResponseModel;

          console.log(response);

          let mapper = new PipelineStepNoteMapper();

          this.setState({
            model: mapper.mapApiResponseToViewModel(response),
            loading: false,
            loaded: true,
            errorOccurred: false,
            errorMessage: '',
          });

          this.props.form.setFieldsValue(
            mapper.mapApiResponseToViewModel(response)
          );
        },
        error => {
          console.log(error);
          this.setState({
            model: undefined,
            loading: false,
            loaded: false,
            errorOccurred: true,
            errorMessage: 'Error from API',
          });
        }
      );
  }

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
      .put(
        Constants.ApiEndpoint +
          ApiRoutes.PipelineStepNotes +
          '/' +
          this.state.model!.id,
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
            })(<DatePicker format={'YYYY-MM-DD'} placeholder={'employeeId'} />)}
          </Form.Item>

          <Form.Item>
            <label htmlFor="note">note</label>
            <br />
            {getFieldDecorator('note', {
              rules: [{ required: true, message: 'Required' }],
            })(<DatePicker format={'YYYY-MM-DD'} placeholder={'note'} />)}
          </Form.Item>

          <Form.Item>
            <label htmlFor="pipelineStepId">pipelineStepId</label>
            <br />
            {getFieldDecorator('pipelineStepId', {
              rules: [{ required: true, message: 'Required' }],
            })(
              <DatePicker
                format={'YYYY-MM-DD'}
                placeholder={'pipelineStepId'}
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

export const WrappedPipelineStepNoteEditComponent = Form.create({
  name: 'PipelineStepNote Edit',
})(PipelineStepNoteEditComponent);


/*<Codenesium>
    <Hash>5f60d92cdfc258bb83336af2120055a2</Hash>
</Codenesium>*/