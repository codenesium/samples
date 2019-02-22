import React, { Component, FormEvent } from 'react';
import axios from 'axios';
import { CreateResponse } from '../../api/apiObjects';
import { Constants, ApiRoutes, ClientRoutes } from '../../constants';
import * as Api from '../../api/models';
import CreditCardMapper from './creditCardMapper';
import CreditCardViewModel from './creditCardViewModel';
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

interface CreditCardCreateComponentProps {
  form: WrappedFormUtils;
  history: any;
  match: any;
}

interface CreditCardCreateComponentState {
  model?: CreditCardViewModel;
  loading: boolean;
  loaded: boolean;
  errorOccurred: boolean;
  errorMessage: string;
  submitted: boolean;
}

class CreditCardCreateComponent extends React.Component<
  CreditCardCreateComponentProps,
  CreditCardCreateComponentState
> {
  state = {
    model: new CreditCardViewModel(),
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
        let model = values as CreditCardViewModel;
        console.log('Received values of form: ', model);
        this.submit(model);
      }
    });
  };

  submit = (model: CreditCardViewModel) => {
    let mapper = new CreditCardMapper();
    axios
      .post(
        Constants.ApiEndpoint + ApiRoutes.CreditCards,
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
            Api.CreditCardClientRequestModel
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
            <label htmlFor="cardNumber">CardNumber</label>
            <br />
            {getFieldDecorator('cardNumber', {
              rules: [
                { required: true, message: 'Required' },
                { max: 25, message: 'Exceeds max length of 25' },
              ],
            })(<DatePicker format={'YYYY-MM-DD'} placeholder={'CardNumber'} />)}
          </Form.Item>

          <Form.Item>
            <label htmlFor="cardType">CardType</label>
            <br />
            {getFieldDecorator('cardType', {
              rules: [
                { required: true, message: 'Required' },
                { max: 50, message: 'Exceeds max length of 50' },
              ],
            })(<DatePicker format={'YYYY-MM-DD'} placeholder={'CardType'} />)}
          </Form.Item>

          <Form.Item>
            <label htmlFor="expMonth">ExpMonth</label>
            <br />
            {getFieldDecorator('expMonth', {
              rules: [{ required: true, message: 'Required' }],
            })(<DatePicker format={'YYYY-MM-DD'} placeholder={'ExpMonth'} />)}
          </Form.Item>

          <Form.Item>
            <label htmlFor="expYear">ExpYear</label>
            <br />
            {getFieldDecorator('expYear', {
              rules: [{ required: true, message: 'Required' }],
            })(<DatePicker format={'YYYY-MM-DD'} placeholder={'ExpYear'} />)}
          </Form.Item>

          <Form.Item>
            <label htmlFor="modifiedDate">ModifiedDate</label>
            <br />
            {getFieldDecorator('modifiedDate', {
              rules: [{ required: true, message: 'Required' }],
            })(
              <DatePicker format={'YYYY-MM-DD'} placeholder={'ModifiedDate'} />
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

export const WrappedCreditCardCreateComponent = Form.create({
  name: 'CreditCard Create',
})(CreditCardCreateComponent);


/*<Codenesium>
    <Hash>0fd7c445c4fca0719298bf9223cedfc8</Hash>
</Codenesium>*/