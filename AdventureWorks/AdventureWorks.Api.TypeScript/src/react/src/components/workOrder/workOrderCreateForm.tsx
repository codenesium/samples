import React, { Component, FormEvent } from 'react';
import axios, { AxiosError, AxiosResponse } from 'axios';
import { ActionResponse, CreateResponse } from '../../api/apiObjects';
import { Constants, ApiRoutes, ClientRoutes } from '../../constants';
import * as Api from '../../api/models';
import WorkOrderMapper from './workOrderMapper';
import WorkOrderViewModel from './workOrderViewModel';
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
import { ProductSelectComponent } from '../shared/productSelect';
import { ScrapReasonSelectComponent } from '../shared/scrapReasonSelect';

interface WorkOrderCreateComponentProps {
  form: WrappedFormUtils;
  history: any;
  match: any;
}

interface WorkOrderCreateComponentState {
  model?: WorkOrderViewModel;
  loading: boolean;
  loaded: boolean;
  errorOccurred: boolean;
  errorMessage: string;
  submitted: boolean;
  submitting: boolean;
}

class WorkOrderCreateComponent extends React.Component<
  WorkOrderCreateComponentProps,
  WorkOrderCreateComponentState
> {
  state = {
    model: new WorkOrderViewModel(),
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
        let model = values as WorkOrderViewModel;
        this.submit(model);
      } else {
        this.setState({ ...this.state, submitting: false, submitted: false });
      }
    });
  };

  submit = (model: WorkOrderViewModel) => {
    let mapper = new WorkOrderMapper();
    axios
      .post<CreateResponse<Api.WorkOrderClientRequestModel>>(
        Constants.ApiEndpoint + ApiRoutes.WorkOrders,
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
            <label htmlFor="dueDate">Due Date</label>
            <br />
            {getFieldDecorator('dueDate', {
              rules: [{ required: true, message: 'Required' }],
            })(<DatePicker format={'YYYY-MM-DD'} placeholder={'Due Date'} />)}
          </Form.Item>

          <Form.Item>
            <label htmlFor="endDate">End Date</label>
            <br />
            {getFieldDecorator('endDate', {
              rules: [],
            })(<DatePicker format={'YYYY-MM-DD'} placeholder={'End Date'} />)}
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
            <label htmlFor="orderQty">Order Qty</label>
            <br />
            {getFieldDecorator('orderQty', {
              rules: [{ required: true, message: 'Required' }],
            })(<InputNumber placeholder={'Order Qty'} />)}
          </Form.Item>

          <ProductSelectComponent
            apiRoute={Constants.ApiEndpoint + ApiRoutes.Products}
            getFieldDecorator={this.props.form.getFieldDecorator}
            propertyName="productID"
            required={true}
            selectedValue={this.state.model!.productID}
          />

          <Form.Item>
            <label htmlFor="scrappedQty">Scrapped Qty</label>
            <br />
            {getFieldDecorator('scrappedQty', {
              rules: [{ required: true, message: 'Required' }],
            })(<InputNumber placeholder={'Scrapped Qty'} />)}
          </Form.Item>

          <ScrapReasonSelectComponent
            apiRoute={Constants.ApiEndpoint + ApiRoutes.ScrapReasons}
            getFieldDecorator={this.props.form.getFieldDecorator}
            propertyName="scrapReasonID"
            required={false}
            selectedValue={this.state.model!.scrapReasonID}
          />

          <Form.Item>
            <label htmlFor="startDate">Start Date</label>
            <br />
            {getFieldDecorator('startDate', {
              rules: [{ required: true, message: 'Required' }],
            })(<DatePicker format={'YYYY-MM-DD'} placeholder={'Start Date'} />)}
          </Form.Item>

          <Form.Item>
            <label htmlFor="stockedQty">Stocked Qty</label>
            <br />
            {getFieldDecorator('stockedQty', {
              rules: [{ required: true, message: 'Required' }],
            })(<InputNumber placeholder={'Stocked Qty'} />)}
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

export const WrappedWorkOrderCreateComponent = Form.create({
  name: 'WorkOrder Create',
})(WorkOrderCreateComponent);


/*<Codenesium>
    <Hash>2187da8ece91333d738f63e2c0e1ce5f</Hash>
</Codenesium>*/