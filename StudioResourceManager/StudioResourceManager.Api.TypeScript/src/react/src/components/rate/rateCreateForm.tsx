import React, { Component, FormEvent } from 'react';
import axios from 'axios';
import { CreateResponse } from '../../api/apiObjects';
import { Constants, ApiRoutes, ClientRoutes } from '../../constants';
import * as Api from '../../api/models';
import RateMapper from './rateMapper';
import RateViewModel from './rateViewModel';
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

interface RateCreateComponentProps {
  form: WrappedFormUtils;
  history: any;
  match: any;
}

interface RateCreateComponentState {
  model?: RateViewModel;
  loading: boolean;
  loaded: boolean;
  errorOccurred: boolean;
  errorMessage: string;
  submitted: boolean;
}

class RateCreateComponent extends React.Component<
  RateCreateComponentProps,
  RateCreateComponentState
> {
  state = {
    model: new RateViewModel(),
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
        let model = values as RateViewModel;
        console.log('Received values of form: ', model);
        this.submit(model);
      }
    });
  };

  submit = (model: RateViewModel) => {
    let mapper = new RateMapper();
    axios
      .post(
        Constants.ApiEndpoint + ApiRoutes.Rates,
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
            Api.RateClientRequestModel
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
            <label htmlFor="amountPerMinute">Amount Per Minute</label>
            <br />
            {getFieldDecorator('amountPerMinute', {
              rules: [
                { required: true, message: 'Required' },
                { whitespace: true, message: 'Required' },
              ],
            })(<InputNumber placeholder={'Amount Per Minute'} />)}
          </Form.Item>

          <Form.Item>
            <label htmlFor="teacherId">teacherId</label>
            <br />
            {getFieldDecorator('teacherId', {
              rules: [
                { required: true, message: 'Required' },
                { whitespace: true, message: 'Required' },
              ],
            })(<InputNumber placeholder={'teacherId'} />)}
          </Form.Item>

          <Form.Item>
            <label htmlFor="teacherSkillId">teacherSkillId</label>
            <br />
            {getFieldDecorator('teacherSkillId', {
              rules: [
                { required: true, message: 'Required' },
                { whitespace: true, message: 'Required' },
              ],
            })(<InputNumber placeholder={'teacherSkillId'} />)}
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

export const WrappedRateCreateComponent = Form.create({ name: 'Rate Create' })(
  RateCreateComponent
);


/*<Codenesium>
    <Hash>7d6175570b51b5f8a2f849da45b283f8</Hash>
</Codenesium>*/