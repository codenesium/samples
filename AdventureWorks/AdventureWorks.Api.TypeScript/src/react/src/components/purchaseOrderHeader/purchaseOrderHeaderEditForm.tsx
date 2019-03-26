import React, { Component, FormEvent } from 'react';
import axios, { AxiosError, AxiosResponse } from 'axios';
import { ActionResponse, CreateResponse } from '../../api/apiObjects';
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
import * as GlobalUtilities from '../../lib/globalUtilities';
import { ShipMethodSelectComponent } from '../shared/shipMethodSelect';
import { VendorSelectComponent } from '../shared/vendorSelect';
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
  submitting: boolean;
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
    submitting: false,
  };

  componentDidMount() {
    this.setState({ ...this.state, loading: true });

    axios
      .get<Api.PurchaseOrderHeaderClientResponseModel>(
        Constants.ApiEndpoint +
          ApiRoutes.PurchaseOrderHeaders +
          '/' +
          this.props.match.params.id,
        {
          headers: GlobalUtilities.defaultHeaders(),
        }
      )
      .then(response => {
        GlobalUtilities.logInfo(response);

        let mapper = new PurchaseOrderHeaderMapper();

        this.setState({
          model: mapper.mapApiResponseToViewModel(response.data),
          loading: false,
          loaded: true,
          errorOccurred: false,
          errorMessage: '',
        });

        this.props.form.setFieldsValue(
          mapper.mapApiResponseToViewModel(response.data)
        );
      })
      .catch((error: AxiosError) => {
        GlobalUtilities.logError(error);

        if (error.response && error.response.status == 422) {
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
  }

  handleSubmit = (e: FormEvent<HTMLFormElement>) => {
    e.preventDefault();
    this.setState({ ...this.state, submitting: true, submitted: false });
    this.props.form.validateFields((err: any, values: any) => {
      if (!err) {
        let model = values as PurchaseOrderHeaderViewModel;
        this.submit(model);
      } else {
        this.setState({ ...this.state, submitting: false, submitted: false });
      }
    });
  };

  submit = (model: PurchaseOrderHeaderViewModel) => {
    let mapper = new PurchaseOrderHeaderMapper();
    axios
      .put<CreateResponse<Api.PurchaseOrderHeaderClientRequestModel>>(
        Constants.ApiEndpoint +
          ApiRoutes.PurchaseOrderHeaders +
          '/' +
          this.state.model!.purchaseOrderID,
        mapper.mapViewModelToApiRequest(model),
        {
          headers: GlobalUtilities.defaultHeaders(),
        }
      )
      .then(response => {
        GlobalUtilities.logInfo(response);
        this.setState({
          ...this.state,
          submitted: true,
          submitting: false,
          model: mapper.mapApiResponseToViewModel(response.data.record!),
          errorOccurred: false,
          errorMessage: '',
        });
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
            <label htmlFor="employeeID">Employee I D</label>
            <br />
            {getFieldDecorator('employeeID', {
              rules: [{ required: true, message: 'Required' }],
            })(<InputNumber placeholder={'Employee I D'} />)}
          </Form.Item>

          <Form.Item>
            <label htmlFor="freight">Freight</label>
            <br />
            {getFieldDecorator('freight', {
              rules: [{ required: true, message: 'Required' }],
            })(<InputNumber placeholder={'Freight'} />)}
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
            <label htmlFor="orderDate">Order Date</label>
            <br />
            {getFieldDecorator('orderDate', {
              rules: [{ required: true, message: 'Required' }],
            })(<DatePicker format={'YYYY-MM-DD'} placeholder={'Order Date'} />)}
          </Form.Item>

          <Form.Item>
            <label htmlFor="revisionNumber">Revision Number</label>
            <br />
            {getFieldDecorator('revisionNumber', {
              rules: [{ required: true, message: 'Required' }],
            })(<InputNumber placeholder={'Revision Number'} />)}
          </Form.Item>

          <Form.Item>
            <label htmlFor="shipDate">Ship Date</label>
            <br />
            {getFieldDecorator('shipDate', {
              rules: [],
            })(<DatePicker format={'YYYY-MM-DD'} placeholder={'Ship Date'} />)}
          </Form.Item>

          <ShipMethodSelectComponent
            apiRoute={Constants.ApiEndpoint + ApiRoutes.ShipMethods}
            getFieldDecorator={this.props.form.getFieldDecorator}
            propertyName="shipMethodID"
            required={true}
            selectedValue={this.state.model!.shipMethodID}
          />

          <Form.Item>
            <label htmlFor="status">Status</label>
            <br />
            {getFieldDecorator('status', {
              rules: [{ required: true, message: 'Required' }],
            })(<InputNumber placeholder={'Status'} />)}
          </Form.Item>

          <Form.Item>
            <label htmlFor="subTotal">Sub Total</label>
            <br />
            {getFieldDecorator('subTotal', {
              rules: [{ required: true, message: 'Required' }],
            })(<InputNumber placeholder={'Sub Total'} />)}
          </Form.Item>

          <Form.Item>
            <label htmlFor="taxAmt">Tax Amt</label>
            <br />
            {getFieldDecorator('taxAmt', {
              rules: [{ required: true, message: 'Required' }],
            })(<InputNumber placeholder={'Tax Amt'} />)}
          </Form.Item>

          <Form.Item>
            <label htmlFor="totalDue">Total Due</label>
            <br />
            {getFieldDecorator('totalDue', {
              rules: [{ required: true, message: 'Required' }],
            })(<InputNumber placeholder={'Total Due'} />)}
          </Form.Item>

          <VendorSelectComponent
            apiRoute={Constants.ApiEndpoint + ApiRoutes.Vendors}
            getFieldDecorator={this.props.form.getFieldDecorator}
            propertyName="vendorID"
            required={true}
            selectedValue={this.state.model!.vendorID}
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

export const WrappedPurchaseOrderHeaderEditComponent = Form.create({
  name: 'PurchaseOrderHeader Edit',
})(PurchaseOrderHeaderEditComponent);


/*<Codenesium>
    <Hash>fd22bccd1d4a40f2bc405297e55d3193</Hash>
</Codenesium>*/