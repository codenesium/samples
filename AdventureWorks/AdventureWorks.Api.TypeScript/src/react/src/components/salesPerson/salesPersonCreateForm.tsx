import React, { Component, FormEvent } from 'react';
import axios from 'axios';
import { CreateResponse } from '../../api/apiObjects';
import { Constants, ApiRoutes, ClientRoutes } from '../../constants';
import * as Api from '../../api/models';
import SalesPersonMapper from './salesPersonMapper';
import SalesPersonViewModel from './salesPersonViewModel';
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

interface SalesPersonCreateComponentProps {
  form: WrappedFormUtils;
  history: any;
  match: any;
}

interface SalesPersonCreateComponentState {
  model?: SalesPersonViewModel;
  loading: boolean;
  loaded: boolean;
  errorOccurred: boolean;
  errorMessage: string;
  submitted: boolean;
}

class SalesPersonCreateComponent extends React.Component<
  SalesPersonCreateComponentProps,
  SalesPersonCreateComponentState
> {
  state = {
    model: new SalesPersonViewModel(),
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
        let model = values as SalesPersonViewModel;
        console.log('Received values of form: ', model);
        this.submit(model);
      }
    });
  };

  submit = (model: SalesPersonViewModel) => {
    let mapper = new SalesPersonMapper();
    axios
      .post(
        Constants.ApiEndpoint + ApiRoutes.SalesPersons,
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
            Api.SalesPersonClientRequestModel
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
            <label htmlFor="bonus">Bonus</label>
            <br />
            {getFieldDecorator('bonus', {
              rules: [],
            })(
              <DatePicker
                format={'YYYY-MM-DD'}
                placeholder={'Bonus'}
                id={'bonus'}
              />
            )}
          </Form.Item>

          <Form.Item>
            <label htmlFor="commissionPct">CommissionPct</label>
            <br />
            {getFieldDecorator('commissionPct', {
              rules: [],
            })(
              <DatePicker
                format={'YYYY-MM-DD'}
                placeholder={'CommissionPct'}
                id={'commissionPct'}
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
            <label htmlFor="rowguid">rowguid</label>
            <br />
            {getFieldDecorator('rowguid', {
              rules: [],
            })(
              <DatePicker
                format={'YYYY-MM-DD'}
                placeholder={'rowguid'}
                id={'rowguid'}
              />
            )}
          </Form.Item>

          <Form.Item>
            <label htmlFor="salesLastYear">SalesLastYear</label>
            <br />
            {getFieldDecorator('salesLastYear', {
              rules: [],
            })(
              <DatePicker
                format={'YYYY-MM-DD'}
                placeholder={'SalesLastYear'}
                id={'salesLastYear'}
              />
            )}
          </Form.Item>

          <Form.Item>
            <label htmlFor="salesQuota">SalesQuota</label>
            <br />
            {getFieldDecorator('salesQuota', {
              rules: [],
            })(
              <DatePicker
                format={'YYYY-MM-DD'}
                placeholder={'SalesQuota'}
                id={'salesQuota'}
              />
            )}
          </Form.Item>

          <Form.Item>
            <label htmlFor="salesYTD">SalesYTD</label>
            <br />
            {getFieldDecorator('salesYTD', {
              rules: [],
            })(
              <DatePicker
                format={'YYYY-MM-DD'}
                placeholder={'SalesYTD'}
                id={'salesYTD'}
              />
            )}
          </Form.Item>

          <Form.Item>
            <label htmlFor="territoryID">TerritoryID</label>
            <br />
            {getFieldDecorator('territoryID', {
              rules: [],
            })(
              <DatePicker
                format={'YYYY-MM-DD'}
                placeholder={'TerritoryID'}
                id={'territoryID'}
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

export const WrappedSalesPersonCreateComponent = Form.create({
  name: 'SalesPerson Create',
})(SalesPersonCreateComponent);


/*<Codenesium>
    <Hash>4a46adf2b86bd7c17988e48f5dfc3dd2</Hash>
</Codenesium>*/