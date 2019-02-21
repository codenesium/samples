import React, { Component, FormEvent } from 'react';
import axios from 'axios';
import { CreateResponse } from '../../api/apiObjects';
import { Constants, ApiRoutes, ClientRoutes } from '../../constants';
import * as Api from '../../api/models';
import PurchaseOrderHeaderMapper from './purchaseOrderHeaderMapper';
import PurchaseOrderHeaderViewModel from './purchaseOrderHeaderViewModel';
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

interface PurchaseOrderHeaderCreateComponentProps {
  form: WrappedFormUtils;
  history: any;
  match: any;
}

interface PurchaseOrderHeaderCreateComponentState {
  model?: PurchaseOrderHeaderViewModel;
  loading: boolean;
  loaded: boolean;
  errorOccurred: boolean;
  errorMessage: string;
  submitted: boolean;
}

class PurchaseOrderHeaderCreateComponent extends React.Component<
  PurchaseOrderHeaderCreateComponentProps,
  PurchaseOrderHeaderCreateComponentState
> {
  state = {
    model: new PurchaseOrderHeaderViewModel(),
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
        let model = values as PurchaseOrderHeaderViewModel;
        console.log('Received values of form: ', model);
        this.submit(model);
      }
    });
  };

  submit = (model: PurchaseOrderHeaderViewModel) => {
    let mapper = new PurchaseOrderHeaderMapper();
    axios
      .post(
        Constants.ApiEndpoint + ApiRoutes.PurchaseOrderHeaders,
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
            Api.PurchaseOrderHeaderClientRequestModel
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
            <label htmlFor="employeeID">EmployeeID</label>
            <br />
            {getFieldDecorator('employeeID', {
              rules: [],
            })(
              <DatePicker
                format={'YYYY-MM-DD'}
                placeholder={'EmployeeID'}
                id={'employeeID'}
              />
            )}
          </Form.Item>

          <Form.Item>
            <label htmlFor="freight">Freight</label>
            <br />
            {getFieldDecorator('freight', {
              rules: [],
            })(
              <DatePicker
                format={'YYYY-MM-DD'}
                placeholder={'Freight'}
                id={'freight'}
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
            <label htmlFor="orderDate">OrderDate</label>
            <br />
            {getFieldDecorator('orderDate', {
              rules: [],
            })(
              <DatePicker
                format={'YYYY-MM-DD'}
                placeholder={'OrderDate'}
                id={'orderDate'}
              />
            )}
          </Form.Item>

          <Form.Item>
            <label htmlFor="revisionNumber">RevisionNumber</label>
            <br />
            {getFieldDecorator('revisionNumber', {
              rules: [],
            })(
              <DatePicker
                format={'YYYY-MM-DD'}
                placeholder={'RevisionNumber'}
                id={'revisionNumber'}
              />
            )}
          </Form.Item>

          <Form.Item>
            <label htmlFor="shipDate">ShipDate</label>
            <br />
            {getFieldDecorator('shipDate', {
              rules: [],
            })(
              <DatePicker
                format={'YYYY-MM-DD'}
                placeholder={'ShipDate'}
                id={'shipDate'}
              />
            )}
          </Form.Item>

          <Form.Item>
            <label htmlFor="shipMethodID">ShipMethodID</label>
            <br />
            {getFieldDecorator('shipMethodID', {
              rules: [],
            })(
              <DatePicker
                format={'YYYY-MM-DD'}
                placeholder={'ShipMethodID'}
                id={'shipMethodID'}
              />
            )}
          </Form.Item>

          <Form.Item>
            <label htmlFor="status">Status</label>
            <br />
            {getFieldDecorator('status', {
              rules: [],
            })(
              <DatePicker
                format={'YYYY-MM-DD'}
                placeholder={'Status'}
                id={'status'}
              />
            )}
          </Form.Item>

          <Form.Item>
            <label htmlFor="subTotal">SubTotal</label>
            <br />
            {getFieldDecorator('subTotal', {
              rules: [],
            })(
              <DatePicker
                format={'YYYY-MM-DD'}
                placeholder={'SubTotal'}
                id={'subTotal'}
              />
            )}
          </Form.Item>

          <Form.Item>
            <label htmlFor="taxAmt">TaxAmt</label>
            <br />
            {getFieldDecorator('taxAmt', {
              rules: [],
            })(
              <DatePicker
                format={'YYYY-MM-DD'}
                placeholder={'TaxAmt'}
                id={'taxAmt'}
              />
            )}
          </Form.Item>

          <Form.Item>
            <label htmlFor="totalDue">TotalDue</label>
            <br />
            {getFieldDecorator('totalDue', {
              rules: [],
            })(
              <DatePicker
                format={'YYYY-MM-DD'}
                placeholder={'TotalDue'}
                id={'totalDue'}
              />
            )}
          </Form.Item>

          <Form.Item>
            <label htmlFor="vendorID">VendorID</label>
            <br />
            {getFieldDecorator('vendorID', {
              rules: [],
            })(
              <DatePicker
                format={'YYYY-MM-DD'}
                placeholder={'VendorID'}
                id={'vendorID'}
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

export const WrappedPurchaseOrderHeaderCreateComponent = Form.create({
  name: 'PurchaseOrderHeader Create',
})(PurchaseOrderHeaderCreateComponent);


/*<Codenesium>
    <Hash>77da982ea78b7a8e708bb54a73073428</Hash>
</Codenesium>*/