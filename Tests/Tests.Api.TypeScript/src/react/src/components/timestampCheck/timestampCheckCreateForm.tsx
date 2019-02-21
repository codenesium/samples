import React, { Component, FormEvent } from 'react';
import axios from 'axios';
import { CreateResponse } from '../../api/apiObjects';
import { Constants, ApiRoutes, ClientRoutes } from '../../constants';
import * as Api from '../../api/models';
import TimestampCheckMapper from './timestampCheckMapper';
import TimestampCheckViewModel from './timestampCheckViewModel';
import {
  Form,
  Input,
  Button,
  Switch,
  InputNumber,
  DatePicker,
  Spin,
  Alert,
} from 'antd';
import { WrappedFormUtils } from 'antd/es/form/Form';

interface TimestampCheckCreateComponentProps {
  form: WrappedFormUtils;
  history: any;
  match: any;
}

interface TimestampCheckCreateComponentState {
  model?: TimestampCheckViewModel;
  loading: boolean;
  loaded: boolean;
  errorOccurred: boolean;
  errorMessage: string;
  submitted: boolean;
}

class TimestampCheckCreateComponent extends React.Component<
  TimestampCheckCreateComponentProps,
  TimestampCheckCreateComponentState
> {
  state = {
    model: new TimestampCheckViewModel(),
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
        let model = values as TimestampCheckViewModel;
        console.log('Received values of form: ', model);
        this.submit(model);
      }
    });
  };

  submit = (model: TimestampCheckViewModel) => {
    let mapper = new TimestampCheckMapper();
    axios
      .post(
        Constants.ApiEndpoint + ApiRoutes.TimestampChecks,
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
            Api.TimestampCheckClientRequestModel
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
            <label htmlFor="name">Name</label>
            <br />
            {getFieldDecorator('name', {
              rules: [],
            })(<Input placeholder={'Name'} id={'name'} />)}
          </Form.Item>

          <Form.Item>
            <label htmlFor="timestamp">Timestamp</label>
            <br />
            {getFieldDecorator('timestamp', {
              rules: [],
            })(<Input placeholder={'Timestamp'} id={'timestamp'} />)}
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

export const WrappedTimestampCheckCreateComponent = Form.create({
  name: 'TimestampCheck Create',
})(TimestampCheckCreateComponent);


/*<Codenesium>
    <Hash>e415ffbc29d6c34c1f7e928ee132ad39</Hash>
</Codenesium>*/