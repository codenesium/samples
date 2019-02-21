import React, { Component, FormEvent } from 'react';
import axios from 'axios';
import { CreateResponse } from '../../api/apiObjects';
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
} from 'antd';
import { WrappedFormUtils } from 'antd/es/form/Form';

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
  };

  handleSubmit = (e: FormEvent<HTMLFormElement>) => {
    e.preventDefault();
    this.props.form.validateFields((err: any, values: any) => {
      if (!err) {
        let model = values as WorkOrderViewModel;
        console.log('Received values of form: ', model);
        this.submit(model);
      }
    });
  };

  submit = (model: WorkOrderViewModel) => {
    let mapper = new WorkOrderMapper();
    axios
      .post(
        Constants.ApiEndpoint + ApiRoutes.WorkOrders,
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
            Api.WorkOrderClientRequestModel
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
            <label htmlFor="dueDate">DueDate</label>
            <br />
            {getFieldDecorator('dueDate', {
              rules: [],
            })(
              <DatePicker
                format={'YYYY-MM-DD'}
                placeholder={'DueDate'}
                id={'dueDate'}
              />
            )}
          </Form.Item>

          <Form.Item>
            <label htmlFor="endDate">EndDate</label>
            <br />
            {getFieldDecorator('endDate', {
              rules: [],
            })(
              <DatePicker
                format={'YYYY-MM-DD'}
                placeholder={'EndDate'}
                id={'endDate'}
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
            <label htmlFor="orderQty">OrderQty</label>
            <br />
            {getFieldDecorator('orderQty', {
              rules: [],
            })(
              <DatePicker
                format={'YYYY-MM-DD'}
                placeholder={'OrderQty'}
                id={'orderQty'}
              />
            )}
          </Form.Item>

          <Form.Item>
            <label htmlFor="productID">ProductID</label>
            <br />
            {getFieldDecorator('productID', {
              rules: [],
            })(
              <DatePicker
                format={'YYYY-MM-DD'}
                placeholder={'ProductID'}
                id={'productID'}
              />
            )}
          </Form.Item>

          <Form.Item>
            <label htmlFor="scrappedQty">ScrappedQty</label>
            <br />
            {getFieldDecorator('scrappedQty', {
              rules: [],
            })(
              <DatePicker
                format={'YYYY-MM-DD'}
                placeholder={'ScrappedQty'}
                id={'scrappedQty'}
              />
            )}
          </Form.Item>

          <Form.Item>
            <label htmlFor="scrapReasonID">ScrapReasonID</label>
            <br />
            {getFieldDecorator('scrapReasonID', {
              rules: [],
            })(
              <DatePicker
                format={'YYYY-MM-DD'}
                placeholder={'ScrapReasonID'}
                id={'scrapReasonID'}
              />
            )}
          </Form.Item>

          <Form.Item>
            <label htmlFor="startDate">StartDate</label>
            <br />
            {getFieldDecorator('startDate', {
              rules: [],
            })(
              <DatePicker
                format={'YYYY-MM-DD'}
                placeholder={'StartDate'}
                id={'startDate'}
              />
            )}
          </Form.Item>

          <Form.Item>
            <label htmlFor="stockedQty">StockedQty</label>
            <br />
            {getFieldDecorator('stockedQty', {
              rules: [],
            })(
              <DatePicker
                format={'YYYY-MM-DD'}
                placeholder={'StockedQty'}
                id={'stockedQty'}
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

export const WrappedWorkOrderCreateComponent = Form.create({
  name: 'WorkOrder Create',
})(WorkOrderCreateComponent);


/*<Codenesium>
    <Hash>620889a5ab18ba2e941334ba3c7fcef8</Hash>
</Codenesium>*/