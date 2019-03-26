import React, { Component, FormEvent } from 'react';
import axios, { AxiosError, AxiosResponse } from 'axios';
import { ActionResponse, CreateResponse } from '../../api/apiObjects';
import { Constants, ApiRoutes, ClientRoutes } from '../../constants';
import * as Api from '../../api/models';
import LinkMapper from './linkMapper';
import LinkViewModel from './linkViewModel';
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
import { MachineSelectComponent } from '../shared/machineSelect';
import { ChainSelectComponent } from '../shared/chainSelect';
import { LinkStatusSelectComponent } from '../shared/linkStatusSelect';

interface LinkCreateComponentProps {
  form: WrappedFormUtils;
  history: any;
  match: any;
}

interface LinkCreateComponentState {
  model?: LinkViewModel;
  loading: boolean;
  loaded: boolean;
  errorOccurred: boolean;
  errorMessage: string;
  submitted: boolean;
  submitting: boolean;
}

class LinkCreateComponent extends React.Component<
  LinkCreateComponentProps,
  LinkCreateComponentState
> {
  state = {
    model: new LinkViewModel(),
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
        let model = values as LinkViewModel;
        this.submit(model);
      } else {
        this.setState({ ...this.state, submitting: false, submitted: false });
      }
    });
  };

  submit = (model: LinkViewModel) => {
    let mapper = new LinkMapper();
    axios
      .post<CreateResponse<Api.LinkClientRequestModel>>(
        Constants.ApiEndpoint + ApiRoutes.Links,
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
          <MachineSelectComponent
            apiRoute={Constants.ApiEndpoint + ApiRoutes.Machines}
            getFieldDecorator={this.props.form.getFieldDecorator}
            propertyName="assignedMachineId"
            required={false}
            selectedValue={this.state.model!.assignedMachineId}
          />

          <ChainSelectComponent
            apiRoute={Constants.ApiEndpoint + ApiRoutes.Chains}
            getFieldDecorator={this.props.form.getFieldDecorator}
            propertyName="chainId"
            required={true}
            selectedValue={this.state.model!.chainId}
          />

          <Form.Item>
            <label htmlFor="dateCompleted">DateCompleted</label>
            <br />
            {getFieldDecorator('dateCompleted', {
              rules: [],
            })(
              <DatePicker format={'YYYY-MM-DD'} placeholder={'DateCompleted'} />
            )}
          </Form.Item>

          <Form.Item>
            <label htmlFor="dateStarted">DateStarted</label>
            <br />
            {getFieldDecorator('dateStarted', {
              rules: [],
            })(
              <DatePicker format={'YYYY-MM-DD'} placeholder={'DateStarted'} />
            )}
          </Form.Item>

          <Form.Item>
            <label htmlFor="dynamicParameter">DynamicParameter</label>
            <br />
            {getFieldDecorator('dynamicParameter', {
              rules: [],
            })(<Input placeholder={'DynamicParameter'} />)}
          </Form.Item>

          <Form.Item>
            <label htmlFor="externalId">ExternalId</label>
            <br />
            {getFieldDecorator('externalId', {
              rules: [{ required: true, message: 'Required' }],
            })(<Input placeholder={'ExternalId'} />)}
          </Form.Item>

          <Form.Item>
            <label htmlFor="linkStatusId">LinkStatusId</label>
            <br />
            {getFieldDecorator('linkStatusId', {
              rules: [{ required: true, message: 'Required' }],
            })(<Input placeholder={'LinkStatusId'} />)}
          </Form.Item>

          <Form.Item>
            <label htmlFor="name">Name</label>
            <br />
            {getFieldDecorator('name', {
              rules: [
                { required: true, message: 'Required' },
                { max: 128, message: 'Exceeds max length of 128' },
              ],
            })(<Input placeholder={'Name'} />)}
          </Form.Item>

          <Form.Item>
            <label htmlFor="order">Order</label>
            <br />
            {getFieldDecorator('order', {
              rules: [{ required: true, message: 'Required' }],
            })(<InputNumber placeholder={'Order'} />)}
          </Form.Item>

          <Form.Item>
            <label htmlFor="response">Response</label>
            <br />
            {getFieldDecorator('response', {
              rules: [],
            })(<Input placeholder={'Response'} />)}
          </Form.Item>

          <Form.Item>
            <label htmlFor="staticParameter">StaticParameter</label>
            <br />
            {getFieldDecorator('staticParameter', {
              rules: [],
            })(<Input.TextArea placeholder={'StaticParameter'} />)}
          </Form.Item>

          <Form.Item>
            <label htmlFor="timeoutInSecond">TimeoutInSecond</label>
            <br />
            {getFieldDecorator('timeoutInSecond', {
              rules: [{ required: true, message: 'Required' }],
            })(<InputNumber placeholder={'TimeoutInSecond'} />)}
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

export const WrappedLinkCreateComponent = Form.create({ name: 'Link Create' })(
  LinkCreateComponent
);


/*<Codenesium>
    <Hash>8d9b0a3ee6c77a2e1009f06b296c5612</Hash>
</Codenesium>*/