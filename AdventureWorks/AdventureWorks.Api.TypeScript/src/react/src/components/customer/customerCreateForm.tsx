import React, { Component, FormEvent } from 'react';
import axios, { AxiosError, AxiosResponse } from 'axios';
import { ActionResponse, CreateResponse } from '../../api/apiObjects';
import { Constants, ApiRoutes, ClientRoutes } from '../../constants';
import * as Api from '../../api/models';
import CustomerMapper from './customerMapper';
import CustomerViewModel from './customerViewModel';
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
import { StoreSelectComponent } from '../shared/storeSelect';
import { SalesTerritorySelectComponent } from '../shared/salesTerritorySelect';

interface CustomerCreateComponentProps {
  form: WrappedFormUtils;
  history: any;
  match: any;
}

interface CustomerCreateComponentState {
  model?: CustomerViewModel;
  loading: boolean;
  loaded: boolean;
  errorOccurred: boolean;
  errorMessage: string;
  submitted: boolean;
  submitting: boolean;
}

class CustomerCreateComponent extends React.Component<
  CustomerCreateComponentProps,
  CustomerCreateComponentState
> {
  state = {
    model: new CustomerViewModel(),
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
        let model = values as CustomerViewModel;
        this.submit(model);
      } else {
        this.setState({ ...this.state, submitting: false, submitted: false });
      }
    });
  };

  submit = (model: CustomerViewModel) => {
    let mapper = new CustomerMapper();
    axios
      .post<CreateResponse<Api.CustomerClientRequestModel>>(
        Constants.ApiEndpoint + ApiRoutes.Customers,
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
            <label htmlFor="accountNumber">Account Number</label>
            <br />
            {getFieldDecorator('accountNumber', {
              rules: [
                { required: true, message: 'Required' },
                { max: 10, message: 'Exceeds max length of 10' },
              ],
            })(<Input placeholder={'Account Number'} />)}
          </Form.Item>

          <Form.Item>
            <label htmlFor="modifiedDate">Modified Date</label>
            <br />
            {getFieldDecorator('modifiedDate', {
              rules: [{ required: true, message: 'Required' }],
            })(
              <DatePicker format={'YYYY-MM-DD'} placeholder={'Modified Date'} />
            )}
          </Form.Item>

          <Form.Item>
            <label htmlFor="personID">Person I D</label>
            <br />
            {getFieldDecorator('personID', {
              rules: [],
            })(<InputNumber placeholder={'Person I D'} />)}
          </Form.Item>

          <Form.Item>
            <label htmlFor="rowguid">Rowguid</label>
            <br />
            {getFieldDecorator('rowguid', {
              rules: [{ required: true, message: 'Required' }],
            })(<Input placeholder={'Rowguid'} />)}
          </Form.Item>

          <StoreSelectComponent
            apiRoute={Constants.ApiEndpoint + ApiRoutes.Stores}
            getFieldDecorator={this.props.form.getFieldDecorator}
            propertyName="storeID"
            required={false}
            selectedValue={this.state.model!.storeID}
          />

          <SalesTerritorySelectComponent
            apiRoute={Constants.ApiEndpoint + ApiRoutes.SalesTerritories}
            getFieldDecorator={this.props.form.getFieldDecorator}
            propertyName="territoryID"
            required={false}
            selectedValue={this.state.model!.territoryID}
          />

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

export const WrappedCustomerCreateComponent = Form.create({
  name: 'Customer Create',
})(CustomerCreateComponent);


/*<Codenesium>
    <Hash>8b22bf19f8a8af2d23f058bb86119ca6</Hash>
</Codenesium>*/