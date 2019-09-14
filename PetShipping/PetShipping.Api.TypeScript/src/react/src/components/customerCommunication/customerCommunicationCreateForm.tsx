import React, { Component, FormEvent } from 'react';
import axios, { AxiosError, AxiosResponse } from 'axios';
import { ActionResponse, CreateResponse } from '../../api/apiObjects';
import { Constants, ApiRoutes, ClientRoutes } from '../../constants';
import * as Api from '../../api/models';
import CustomerCommunicationMapper from './customerCommunicationMapper';
import CustomerCommunicationViewModel from './customerCommunicationViewModel';
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
import { CustomerSelectComponent } from '../shared/customerSelect';
import { EmployeeSelectComponent } from '../shared/employeeSelect';

interface CustomerCommunicationCreateComponentProps {
  form: WrappedFormUtils;
  history: any;
  match: any;
}

interface CustomerCommunicationCreateComponentState {
  model?: CustomerCommunicationViewModel;
  loading: boolean;
  loaded: boolean;
  errorOccurred: boolean;
  errorMessage: string;
  submitted: boolean;
  submitting: boolean;
}

class CustomerCommunicationCreateComponent extends React.Component<
  CustomerCommunicationCreateComponentProps,
  CustomerCommunicationCreateComponentState
> {
  state = {
    model: new CustomerCommunicationViewModel(),
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
        let model = values as CustomerCommunicationViewModel;
        this.submit(model);
      } else {
        this.setState({ ...this.state, submitting: false, submitted: false });
      }
    });
  };

  submit = (model: CustomerCommunicationViewModel) => {
    let mapper = new CustomerCommunicationMapper();
    axios
      .post<CreateResponse<Api.CustomerCommunicationClientRequestModel>>(
        Constants.ApiEndpoint + ApiRoutes.CustomerCommunications,
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
          <CustomerSelectComponent
            apiRoute={Constants.ApiEndpoint + ApiRoutes.Customers}
            getFieldDecorator={this.props.form.getFieldDecorator}
            propertyName="customerId"
            required={true}
            selectedValue={this.state.model!.customerId}
          />

          <Form.Item>
            <label htmlFor="dateCreated">Date Created (required)</label>
            <br />
            {getFieldDecorator('dateCreated', {
              rules: [{ required: true, message: 'Required' }],
            })(
              <DatePicker format={'YYYY-MM-DD'} placeholder={'Date Created'} />
            )}
          </Form.Item>

          <EmployeeSelectComponent
            apiRoute={Constants.ApiEndpoint + ApiRoutes.Employees}
            getFieldDecorator={this.props.form.getFieldDecorator}
            propertyName="employeeId"
            required={true}
            selectedValue={this.state.model!.employeeId}
          />

          <Form.Item>
            <label htmlFor="notes">Notes (required)</label>
            <br />
            {getFieldDecorator('notes', {
              rules: [{ required: true, message: 'Required' }],
            })(<Input placeholder={'Notes'} />)}
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

export const WrappedCustomerCommunicationCreateComponent = Form.create({
  name: 'CustomerCommunication Create',
})(CustomerCommunicationCreateComponent);


/*<Codenesium>
    <Hash>8169aabd8ac078f86d172e1b1a6ecd1e</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/