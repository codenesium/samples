import React, { Component, FormEvent } from 'react';
import axios from 'axios';
import { CreateResponse } from '../../api/apiObjects';
import { Constants, ApiRoutes, ClientRoutes } from '../../constants';
import * as Api from '../../api/models';
import CurrencyRateMapper from './currencyRateMapper';
import CurrencyRateViewModel from './currencyRateViewModel';
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

interface CurrencyRateCreateComponentProps {
  form: WrappedFormUtils;
  history: any;
  match: any;
}

interface CurrencyRateCreateComponentState {
  model?: CurrencyRateViewModel;
  loading: boolean;
  loaded: boolean;
  errorOccurred: boolean;
  errorMessage: string;
  submitted: boolean;
}

class CurrencyRateCreateComponent extends React.Component<
  CurrencyRateCreateComponentProps,
  CurrencyRateCreateComponentState
> {
  state = {
    model: new CurrencyRateViewModel(),
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
        let model = values as CurrencyRateViewModel;
        console.log('Received values of form: ', model);
        this.submit(model);
      }
    });
  };

  submit = (model: CurrencyRateViewModel) => {
    let mapper = new CurrencyRateMapper();
    axios
      .post(
        Constants.ApiEndpoint + ApiRoutes.CurrencyRates,
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
            Api.CurrencyRateClientRequestModel
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
            <label htmlFor="averageRate">AverageRate</label>
            <br />
            {getFieldDecorator('averageRate', {
              rules: [],
            })(
              <DatePicker
                format={'YYYY-MM-DD'}
                placeholder={'AverageRate'}
                id={'averageRate'}
              />
            )}
          </Form.Item>

          <Form.Item>
            <label htmlFor="currencyRateDate">CurrencyRateDate</label>
            <br />
            {getFieldDecorator('currencyRateDate', {
              rules: [],
            })(
              <DatePicker
                format={'YYYY-MM-DD'}
                placeholder={'CurrencyRateDate'}
                id={'currencyRateDate'}
              />
            )}
          </Form.Item>

          <Form.Item>
            <label htmlFor="endOfDayRate">EndOfDayRate</label>
            <br />
            {getFieldDecorator('endOfDayRate', {
              rules: [],
            })(
              <DatePicker
                format={'YYYY-MM-DD'}
                placeholder={'EndOfDayRate'}
                id={'endOfDayRate'}
              />
            )}
          </Form.Item>

          <Form.Item>
            <label htmlFor="fromCurrencyCode">FromCurrencyCode</label>
            <br />
            {getFieldDecorator('fromCurrencyCode', {
              rules: [],
            })(
              <DatePicker
                format={'YYYY-MM-DD'}
                placeholder={'FromCurrencyCode'}
                id={'fromCurrencyCode'}
              />
            )}
          </Form.Item>

          <Form.Item>
            <label htmlFor="modifiedDate">ModifiedDate</label>
            <br />
            {getFieldDecorator('modifiedDate', {
              rules: [],
            })(
              <DatePicker
                format={'YYYY-MM-DD'}
                placeholder={'ModifiedDate'}
                id={'modifiedDate'}
              />
            )}
          </Form.Item>

          <Form.Item>
            <label htmlFor="toCurrencyCode">ToCurrencyCode</label>
            <br />
            {getFieldDecorator('toCurrencyCode', {
              rules: [],
            })(
              <DatePicker
                format={'YYYY-MM-DD'}
                placeholder={'ToCurrencyCode'}
                id={'toCurrencyCode'}
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

export const WrappedCurrencyRateCreateComponent = Form.create({
  name: 'CurrencyRate Create',
})(CurrencyRateCreateComponent);


/*<Codenesium>
    <Hash>196f63a192bbbe2fa62828c64082dcce</Hash>
</Codenesium>*/