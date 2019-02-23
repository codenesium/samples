import React, { Component, FormEvent } from 'react';
import axios from 'axios';
import { CreateResponse } from '../../api/apiObjects';
import { Constants, ApiRoutes, ClientRoutes } from '../../constants';
import * as Api from '../../api/models';
import SelfReferenceMapper from './selfReferenceMapper';
import SelfReferenceViewModel from './selfReferenceViewModel';
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

interface SelfReferenceEditComponentProps {
  form: WrappedFormUtils;
  history: any;
  match: any;
}

interface SelfReferenceEditComponentState {
  model?: SelfReferenceViewModel;
  loading: boolean;
  loaded: boolean;
  errorOccurred: boolean;
  errorMessage: string;
  submitted: boolean;
}

class SelfReferenceEditComponent extends React.Component<
  SelfReferenceEditComponentProps,
  SelfReferenceEditComponentState
> {
  state = {
    model: new SelfReferenceViewModel(),
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
          ApiRoutes.SelfReferences +
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
          let response = resp.data as Api.SelfReferenceClientResponseModel;

          console.log(response);

          let mapper = new SelfReferenceMapper();

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
        let model = values as SelfReferenceViewModel;
        console.log('Received values of form: ', model);
        this.submit(model);
      }
    });
  };

  submit = (model: SelfReferenceViewModel) => {
    let mapper = new SelfReferenceMapper();
    axios
      .put(
        Constants.ApiEndpoint +
          ApiRoutes.SelfReferences +
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
            Api.SelfReferenceClientRequestModel
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
            <label htmlFor="selfReferenceId">SelfReferenceId</label>
            <br />
            {getFieldDecorator('selfReferenceId', {
              rules: [],
            })(<Input placeholder={'SelfReferenceId'} />)}
          </Form.Item>

          <Form.Item>
            <label htmlFor="selfReferenceId2">SelfReferenceId2</label>
            <br />
            {getFieldDecorator('selfReferenceId2', {
              rules: [],
            })(<Input placeholder={'SelfReferenceId2'} />)}
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

export const WrappedSelfReferenceEditComponent = Form.create({
  name: 'SelfReference Edit',
})(SelfReferenceEditComponent);


/*<Codenesium>
    <Hash>504cbd7903e254b688b0a176f824ee9e</Hash>
</Codenesium>*/