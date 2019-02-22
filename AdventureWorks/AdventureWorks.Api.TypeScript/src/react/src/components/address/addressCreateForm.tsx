import React, { Component, FormEvent } from 'react';
import axios from 'axios';
import { CreateResponse } from '../../api/apiObjects';
import { Constants, ApiRoutes, ClientRoutes } from '../../constants';
import * as Api from '../../api/models';
import AddressMapper from './addressMapper';
import AddressViewModel from './addressViewModel';
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

interface AddressCreateComponentProps {
  form: WrappedFormUtils;
  history: any;
  match: any;
}

interface AddressCreateComponentState {
  model?: AddressViewModel;
  loading: boolean;
  loaded: boolean;
  errorOccurred: boolean;
  errorMessage: string;
  submitted: boolean;
}

class AddressCreateComponent extends React.Component<
  AddressCreateComponentProps,
  AddressCreateComponentState
> {
  state = {
    model: new AddressViewModel(),
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
        let model = values as AddressViewModel;
        console.log('Received values of form: ', model);
        this.submit(model);
      }
    });
  };

  submit = (model: AddressViewModel) => {
    let mapper = new AddressMapper();
    axios
      .post(
        Constants.ApiEndpoint + ApiRoutes.Addresses,
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
            Api.AddressClientRequestModel
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
            <label htmlFor="addressLine1">AddressLine1</label>
            <br />
            {getFieldDecorator('addressLine1', {
              rules: [
                { required: true, message: 'Required' },
                { whitespace: true, message: 'Required' },
                { max: 60, message: 'Exceeds max length of 60' },
              ],
            })(
              <DatePicker format={'YYYY-MM-DD'} placeholder={'AddressLine1'} />
            )}
          </Form.Item>

          <Form.Item>
            <label htmlFor="addressLine2">AddressLine2</label>
            <br />
            {getFieldDecorator('addressLine2', {
              rules: [{ max: 60, message: 'Exceeds max length of 60' }],
            })(
              <DatePicker format={'YYYY-MM-DD'} placeholder={'AddressLine2'} />
            )}
          </Form.Item>

          <Form.Item>
            <label htmlFor="city">City</label>
            <br />
            {getFieldDecorator('city', {
              rules: [
                { required: true, message: 'Required' },
                { whitespace: true, message: 'Required' },
                { max: 30, message: 'Exceeds max length of 30' },
              ],
            })(<DatePicker format={'YYYY-MM-DD'} placeholder={'City'} />)}
          </Form.Item>

          <Form.Item>
            <label htmlFor="modifiedDate">ModifiedDate</label>
            <br />
            {getFieldDecorator('modifiedDate', {
              rules: [
                { required: true, message: 'Required' },
                { whitespace: true, message: 'Required' },
              ],
            })(
              <DatePicker format={'YYYY-MM-DD'} placeholder={'ModifiedDate'} />
            )}
          </Form.Item>

          <Form.Item>
            <label htmlFor="postalCode">PostalCode</label>
            <br />
            {getFieldDecorator('postalCode', {
              rules: [
                { required: true, message: 'Required' },
                { whitespace: true, message: 'Required' },
                { max: 15, message: 'Exceeds max length of 15' },
              ],
            })(<DatePicker format={'YYYY-MM-DD'} placeholder={'PostalCode'} />)}
          </Form.Item>

          <Form.Item>
            <label htmlFor="rowguid">rowguid</label>
            <br />
            {getFieldDecorator('rowguid', {
              rules: [
                { required: true, message: 'Required' },
                { whitespace: true, message: 'Required' },
              ],
            })(<DatePicker format={'YYYY-MM-DD'} placeholder={'rowguid'} />)}
          </Form.Item>

          <Form.Item>
            <label htmlFor="stateProvinceID">StateProvinceID</label>
            <br />
            {getFieldDecorator('stateProvinceID', {
              rules: [
                { required: true, message: 'Required' },
                { whitespace: true, message: 'Required' },
              ],
            })(
              <DatePicker
                format={'YYYY-MM-DD'}
                placeholder={'StateProvinceID'}
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

export const WrappedAddressCreateComponent = Form.create({
  name: 'Address Create',
})(AddressCreateComponent);


/*<Codenesium>
    <Hash>ee974f196f2c728421fb7b897525ced0</Hash>
</Codenesium>*/