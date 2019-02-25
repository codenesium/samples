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
  TimePicker,
} from 'antd';
import { WrappedFormUtils } from 'antd/es/form/Form';

interface PurchaseOrderHeaderEditComponentProps {
  form: WrappedFormUtils;
  history: any;
  match: any;
}

interface PurchaseOrderHeaderEditComponentState {
  model?: PurchaseOrderHeaderViewModel;
  loading: boolean;
  loaded: boolean;
  errorOccurred: boolean;
  errorMessage: string;
  submitted: boolean;
}

class PurchaseOrderHeaderEditComponent extends React.Component<
  PurchaseOrderHeaderEditComponentProps,
  PurchaseOrderHeaderEditComponentState
> {
  state = {
    model: new PurchaseOrderHeaderViewModel(),
    loading: false,
    loaded: true,
    errorOccurred: false,
    errorMessage: '',
    submitted: false,
  };

  componentDidMount() {
    this.setState({ ...this.state, loading: true });

    axios
      .get(
        Constants.ApiEndpoint +
          ApiRoutes.PurchaseOrderHeaders +
          '/' +
          this.props.match.params.id,
        {
          headers: {
            'Content-Type': 'application/json',
          },
        }
      )
      .then(
        resp => {
          let response = resp.data as Api.PurchaseOrderHeaderClientResponseModel;

          console.log(response);

          let mapper = new PurchaseOrderHeaderMapper();

          this.setState({
            model: mapper.mapApiResponseToViewModel(response),
            loading: false,
            loaded: true,
            errorOccurred: false,
            errorMessage: '',
          });

          this.props.form.setFieldsValue(
            mapper.mapApiResponseToViewModel(response)
          );
        },
        error => {
          console.log(error);
          this.setState({
            model: undefined,
            loading: false,
            loaded: false,
            errorOccurred: true,
            errorMessage: 'Error from API',
          });
        }
      );
  }

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
      .put(
        Constants.ApiEndpoint +
          ApiRoutes.PurchaseOrderHeaders +
          '/' +
          this.state.model!.purchaseOrderID,
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
              rules: [{ required: true, message: 'Required' }],
            })(<DatePicker format={'YYYY-MM-DD'} placeholder={'EmployeeID'} />)}
          </Form.Item>

          <Form.Item>
            <label htmlFor="freight">Freight</label>
            <br />
            {getFieldDecorator('freight', {
              rules: [{ required: true, message: 'Required' }],
            })(<DatePicker format={'YYYY-MM-DD'} placeholder={'Freight'} />)}
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
            <label htmlFor="orderDate">OrderDate</label>
            <br />
            {getFieldDecorator('orderDate', {
              rules: [{ required: true, message: 'Required' }],
            })(<DatePicker format={'YYYY-MM-DD'} placeholder={'OrderDate'} />)}
          </Form.Item>

          <Form.Item>
            <label htmlFor="revisionNumber">RevisionNumber</label>
            <br />
            {getFieldDecorator('revisionNumber', {
              rules: [{ required: true, message: 'Required' }],
            })(
              <DatePicker
                format={'YYYY-MM-DD'}
                placeholder={'RevisionNumber'}
              />
            )}
          </Form.Item>

          <Form.Item>
            <label htmlFor="shipDate">ShipDate</label>
            <br />
            {getFieldDecorator('shipDate', {
              rules: [],
            })(<DatePicker format={'YYYY-MM-DD'} placeholder={'ShipDate'} />)}
          </Form.Item>

          <Form.Item>
            <label htmlFor="shipMethodID">ShipMethodID</label>
            <br />
            {getFieldDecorator('shipMethodID', {
              rules: [{ required: true, message: 'Required' }],
            })(
              <DatePicker format={'YYYY-MM-DD'} placeholder={'ShipMethodID'} />
            )}
          </Form.Item>

          <Form.Item>
            <label htmlFor="status">Status</label>
            <br />
            {getFieldDecorator('status', {
              rules: [{ required: true, message: 'Required' }],
            })(<DatePicker format={'YYYY-MM-DD'} placeholder={'Status'} />)}
          </Form.Item>

          <Form.Item>
            <label htmlFor="subTotal">SubTotal</label>
            <br />
            {getFieldDecorator('subTotal', {
              rules: [{ required: true, message: 'Required' }],
            })(<DatePicker format={'YYYY-MM-DD'} placeholder={'SubTotal'} />)}
          </Form.Item>

          <Form.Item>
            <label htmlFor="taxAmt">TaxAmt</label>
            <br />
            {getFieldDecorator('taxAmt', {
              rules: [{ required: true, message: 'Required' }],
            })(<DatePicker format={'YYYY-MM-DD'} placeholder={'TaxAmt'} />)}
          </Form.Item>

          <Form.Item>
            <label htmlFor="totalDue">TotalDue</label>
            <br />
            {getFieldDecorator('totalDue', {
              rules: [{ required: true, message: 'Required' }],
            })(<DatePicker format={'YYYY-MM-DD'} placeholder={'TotalDue'} />)}
          </Form.Item>

          <Form.Item>
            <label htmlFor="vendorID">VendorID</label>
            <br />
            {getFieldDecorator('vendorID', {
              rules: [{ required: true, message: 'Required' }],
            })(<DatePicker format={'YYYY-MM-DD'} placeholder={'VendorID'} />)}
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

export const WrappedPurchaseOrderHeaderEditComponent = Form.create({
  name: 'PurchaseOrderHeader Edit',
})(PurchaseOrderHeaderEditComponent);


/*<Codenesium>
    <Hash>69845e0fb236187a6c3b8c7ea48b51a9</Hash>
</Codenesium>*/