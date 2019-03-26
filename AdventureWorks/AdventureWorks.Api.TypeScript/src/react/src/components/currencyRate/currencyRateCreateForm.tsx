import React, { Component, FormEvent } from 'react';
import axios, { AxiosError, AxiosResponse } from 'axios';
import { ActionResponse, CreateResponse } from '../../api/apiObjects';
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
  TimePicker,
} from 'antd';
import { WrappedFormUtils } from 'antd/es/form/Form';
import * as GlobalUtilities from '../../lib/globalUtilities';
import { CurrencySelectComponent } from '../shared/currencySelect';

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
  submitting: boolean;
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
    submitting: false,
  };

  handleSubmit = (e: FormEvent<HTMLFormElement>) => {
    e.preventDefault();
    this.setState({ ...this.state, submitting: true, submitted: false });
    this.props.form.validateFields((err: any, values: any) => {
      if (!err) {
        let model = values as CurrencyRateViewModel;
        this.submit(model);
      } else {
        this.setState({ ...this.state, submitting: false, submitted: false });
      }
    });
  };

  submit = (model: CurrencyRateViewModel) => {
    let mapper = new CurrencyRateMapper();
    axios
      .post<CreateResponse<Api.CurrencyRateClientRequestModel>>(
        Constants.ApiEndpoint + ApiRoutes.CurrencyRates,
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
            <label htmlFor="averageRate">Average Rate</label>
            <br />
            {getFieldDecorator('averageRate', {
              rules: [{ required: true, message: 'Required' }],
            })(<InputNumber placeholder={'Average Rate'} />)}
          </Form.Item>

          <Form.Item>
            <label htmlFor="currencyRateDate">Currency Rate Date</label>
            <br />
            {getFieldDecorator('currencyRateDate', {
              rules: [{ required: true, message: 'Required' }],
            })(
              <DatePicker
                format={'YYYY-MM-DD'}
                placeholder={'Currency Rate Date'}
              />
            )}
          </Form.Item>

          <Form.Item>
            <label htmlFor="endOfDayRate">End Of Day Rate</label>
            <br />
            {getFieldDecorator('endOfDayRate', {
              rules: [{ required: true, message: 'Required' }],
            })(<InputNumber placeholder={'End Of Day Rate'} />)}
          </Form.Item>

          <CurrencySelectComponent
            apiRoute={Constants.ApiEndpoint + ApiRoutes.Currencies}
            getFieldDecorator={this.props.form.getFieldDecorator}
            propertyName="fromCurrencyCode"
            required={true}
            selectedValue={this.state.model!.fromCurrencyCode}
          />

          <Form.Item>
            <label htmlFor="modifiedDate">Modified Date</label>
            <br />
            {getFieldDecorator('modifiedDate', {
              rules: [{ required: true, message: 'Required' }],
            })(
              <DatePicker format={'YYYY-MM-DD'} placeholder={'Modified Date'} />
            )}
          </Form.Item>

          <CurrencySelectComponent
            apiRoute={Constants.ApiEndpoint + ApiRoutes.Currencies}
            getFieldDecorator={this.props.form.getFieldDecorator}
            propertyName="toCurrencyCode"
            required={true}
            selectedValue={this.state.model!.toCurrencyCode}
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

export const WrappedCurrencyRateCreateComponent = Form.create({
  name: 'CurrencyRate Create',
})(CurrencyRateCreateComponent);


/*<Codenesium>
    <Hash>df654157bc85bd6a97269c37711fa42f</Hash>
</Codenesium>*/