import React, { Component, FormEvent } from 'react';
import axios from 'axios';
import { CreateResponse } from '../../api/apiObjects';
import { Constants, ApiRoutes, ClientRoutes } from '../../constants';
import * as Api from '../../api/models';
import SpecialOfferMapper from './specialOfferMapper';
import SpecialOfferViewModel from './specialOfferViewModel';
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

interface SpecialOfferCreateComponentProps {
  form: WrappedFormUtils;
  history: any;
  match: any;
}

interface SpecialOfferCreateComponentState {
  model?: SpecialOfferViewModel;
  loading: boolean;
  loaded: boolean;
  errorOccurred: boolean;
  errorMessage: string;
  submitted: boolean;
}

class SpecialOfferCreateComponent extends React.Component<
  SpecialOfferCreateComponentProps,
  SpecialOfferCreateComponentState
> {
  state = {
    model: new SpecialOfferViewModel(),
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
        let model = values as SpecialOfferViewModel;
        console.log('Received values of form: ', model);
        this.submit(model);
      }
    });
  };

  submit = (model: SpecialOfferViewModel) => {
    let mapper = new SpecialOfferMapper();
    axios
      .post(
        Constants.ApiEndpoint + ApiRoutes.SpecialOffers,
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
            Api.SpecialOfferClientRequestModel
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
            <label htmlFor="category">Category</label>
            <br />
            {getFieldDecorator('category', {
              rules: [
                { required: true, message: 'Required' },
                { max: 50, message: 'Exceeds max length of 50' },
              ],
            })(<DatePicker format={'YYYY-MM-DD'} placeholder={'Category'} />)}
          </Form.Item>

          <Form.Item>
            <label htmlFor="description">Description</label>
            <br />
            {getFieldDecorator('description', {
              rules: [
                { required: true, message: 'Required' },
                { max: 255, message: 'Exceeds max length of 255' },
              ],
            })(
              <DatePicker format={'YYYY-MM-DD'} placeholder={'Description'} />
            )}
          </Form.Item>

          <Form.Item>
            <label htmlFor="discountPct">DiscountPct</label>
            <br />
            {getFieldDecorator('discountPct', {
              rules: [{ required: true, message: 'Required' }],
            })(
              <DatePicker format={'YYYY-MM-DD'} placeholder={'DiscountPct'} />
            )}
          </Form.Item>

          <Form.Item>
            <label htmlFor="endDate">EndDate</label>
            <br />
            {getFieldDecorator('endDate', {
              rules: [{ required: true, message: 'Required' }],
            })(<DatePicker format={'YYYY-MM-DD'} placeholder={'EndDate'} />)}
          </Form.Item>

          <Form.Item>
            <label htmlFor="maxQty">MaxQty</label>
            <br />
            {getFieldDecorator('maxQty', {
              rules: [],
            })(<DatePicker format={'YYYY-MM-DD'} placeholder={'MaxQty'} />)}
          </Form.Item>

          <Form.Item>
            <label htmlFor="minQty">MinQty</label>
            <br />
            {getFieldDecorator('minQty', {
              rules: [{ required: true, message: 'Required' }],
            })(<DatePicker format={'YYYY-MM-DD'} placeholder={'MinQty'} />)}
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
            <label htmlFor="rowguid">rowguid</label>
            <br />
            {getFieldDecorator('rowguid', {
              rules: [{ required: true, message: 'Required' }],
            })(<DatePicker format={'YYYY-MM-DD'} placeholder={'rowguid'} />)}
          </Form.Item>

          <Form.Item>
            <label htmlFor="startDate">StartDate</label>
            <br />
            {getFieldDecorator('startDate', {
              rules: [{ required: true, message: 'Required' }],
            })(<DatePicker format={'YYYY-MM-DD'} placeholder={'StartDate'} />)}
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

export const WrappedSpecialOfferCreateComponent = Form.create({
  name: 'SpecialOffer Create',
})(SpecialOfferCreateComponent);


/*<Codenesium>
    <Hash>a5d9d193aea1ca88c6e8ba9df3641bb1</Hash>
</Codenesium>*/