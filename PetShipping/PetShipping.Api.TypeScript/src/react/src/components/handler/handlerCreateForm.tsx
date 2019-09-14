import React, { Component, FormEvent } from 'react';
import axios, { AxiosError, AxiosResponse } from 'axios';
import { ActionResponse, CreateResponse } from '../../api/apiObjects';
import { Constants, ApiRoutes, ClientRoutes } from '../../constants';
import * as Api from '../../api/models';
import HandlerMapper from './handlerMapper';
import HandlerViewModel from './handlerViewModel';
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

interface HandlerCreateComponentProps {
  form: WrappedFormUtils;
  history: any;
  match: any;
}

interface HandlerCreateComponentState {
  model?: HandlerViewModel;
  loading: boolean;
  loaded: boolean;
  errorOccurred: boolean;
  errorMessage: string;
  submitted: boolean;
  submitting: boolean;
}

class HandlerCreateComponent extends React.Component<
  HandlerCreateComponentProps,
  HandlerCreateComponentState
> {
  state = {
    model: new HandlerViewModel(),
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
        let model = values as HandlerViewModel;
        this.submit(model);
      } else {
        this.setState({ ...this.state, submitting: false, submitted: false });
      }
    });
  };

  submit = (model: HandlerViewModel) => {
    let mapper = new HandlerMapper();
    axios
      .post<CreateResponse<Api.HandlerClientRequestModel>>(
        Constants.ApiEndpoint + ApiRoutes.Handlers,
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
            <label htmlFor="countryId">Country (required)</label>
            <br />
            {getFieldDecorator('countryId', {
              rules: [{ required: true, message: 'Required' }],
            })(<InputNumber placeholder={'Country'} />)}
          </Form.Item>

          <Form.Item>
            <label htmlFor="email">Email (required)</label>
            <br />
            {getFieldDecorator('email', {
              rules: [
                { required: true, message: 'Required' },
                { max: 128, message: 'Exceeds max length of 128' },
              ],
            })(<Input placeholder={'Email'} />)}
          </Form.Item>

          <Form.Item>
            <label htmlFor="firstName">First Name (required)</label>
            <br />
            {getFieldDecorator('firstName', {
              rules: [
                { required: true, message: 'Required' },
                { max: 128, message: 'Exceeds max length of 128' },
              ],
            })(<Input placeholder={'First Name'} />)}
          </Form.Item>

          <Form.Item>
            <label htmlFor="lastName">Last Name (required)</label>
            <br />
            {getFieldDecorator('lastName', {
              rules: [
                { required: true, message: 'Required' },
                { max: 128, message: 'Exceeds max length of 128' },
              ],
            })(<Input placeholder={'Last Name'} />)}
          </Form.Item>

          <Form.Item>
            <label htmlFor="phone">Phone (required)</label>
            <br />
            {getFieldDecorator('phone', {
              rules: [
                { required: true, message: 'Required' },
                { max: 10, message: 'Exceeds max length of 10' },
              ],
            })(<Input placeholder={'Phone'} />)}
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

export const WrappedHandlerCreateComponent = Form.create({
  name: 'Handler Create',
})(HandlerCreateComponent);


/*<Codenesium>
    <Hash>73ecd8b31e537f3d12be701f152cdd32</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/