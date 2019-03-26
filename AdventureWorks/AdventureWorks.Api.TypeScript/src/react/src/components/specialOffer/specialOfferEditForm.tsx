import React, { Component, FormEvent } from 'react';
import axios, { AxiosError, AxiosResponse } from 'axios';
import { ActionResponse, CreateResponse } from '../../api/apiObjects';
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
import * as GlobalUtilities from '../../lib/globalUtilities';
interface SpecialOfferEditComponentProps {
  form: WrappedFormUtils;
  history: any;
  match: any;
}

interface SpecialOfferEditComponentState {
  model?: SpecialOfferViewModel;
  loading: boolean;
  loaded: boolean;
  errorOccurred: boolean;
  errorMessage: string;
  submitted: boolean;
  submitting: boolean;
}

class SpecialOfferEditComponent extends React.Component<
  SpecialOfferEditComponentProps,
  SpecialOfferEditComponentState
> {
  state = {
    model: new SpecialOfferViewModel(),
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
      .get<Api.SpecialOfferClientResponseModel>(
        Constants.ApiEndpoint +
          ApiRoutes.SpecialOffers +
          '/' +
          this.props.match.params.id,
        {
          headers: GlobalUtilities.defaultHeaders(),
        }
      )
      .then(response => {
        GlobalUtilities.logInfo(response);

        let mapper = new SpecialOfferMapper();

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
        let model = values as SpecialOfferViewModel;
        this.submit(model);
      } else {
        this.setState({ ...this.state, submitting: false, submitted: false });
      }
    });
  };

  submit = (model: SpecialOfferViewModel) => {
    let mapper = new SpecialOfferMapper();
    axios
      .put<CreateResponse<Api.SpecialOfferClientRequestModel>>(
        Constants.ApiEndpoint +
          ApiRoutes.SpecialOffers +
          '/' +
          this.state.model!.specialOfferID,
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
            <label htmlFor="category">Category</label>
            <br />
            {getFieldDecorator('category', {
              rules: [
                { required: true, message: 'Required' },
                { max: 50, message: 'Exceeds max length of 50' },
              ],
            })(<Input placeholder={'Category'} />)}
          </Form.Item>

          <Form.Item>
            <label htmlFor="description">Description</label>
            <br />
            {getFieldDecorator('description', {
              rules: [
                { required: true, message: 'Required' },
                { max: 255, message: 'Exceeds max length of 255' },
              ],
            })(<Input placeholder={'Description'} />)}
          </Form.Item>

          <Form.Item>
            <label htmlFor="discountPct">Discount Pct</label>
            <br />
            {getFieldDecorator('discountPct', {
              rules: [{ required: true, message: 'Required' }],
            })(<InputNumber placeholder={'Discount Pct'} />)}
          </Form.Item>

          <Form.Item>
            <label htmlFor="endDate">End Date</label>
            <br />
            {getFieldDecorator('endDate', {
              rules: [{ required: true, message: 'Required' }],
            })(<DatePicker format={'YYYY-MM-DD'} placeholder={'End Date'} />)}
          </Form.Item>

          <Form.Item>
            <label htmlFor="maxQty">Max Qty</label>
            <br />
            {getFieldDecorator('maxQty', {
              rules: [],
            })(<InputNumber placeholder={'Max Qty'} />)}
          </Form.Item>

          <Form.Item>
            <label htmlFor="minQty">Min Qty</label>
            <br />
            {getFieldDecorator('minQty', {
              rules: [{ required: true, message: 'Required' }],
            })(<InputNumber placeholder={'Min Qty'} />)}
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
            <label htmlFor="rowguid">Rowguid</label>
            <br />
            {getFieldDecorator('rowguid', {
              rules: [{ required: true, message: 'Required' }],
            })(<Input placeholder={'Rowguid'} />)}
          </Form.Item>

          <Form.Item>
            <label htmlFor="startDate">Start Date</label>
            <br />
            {getFieldDecorator('startDate', {
              rules: [{ required: true, message: 'Required' }],
            })(<DatePicker format={'YYYY-MM-DD'} placeholder={'Start Date'} />)}
          </Form.Item>

          <Form.Item>
            <label htmlFor="reservedType">Type</label>
            <br />
            {getFieldDecorator('reservedType', {
              rules: [
                { required: true, message: 'Required' },
                { max: 50, message: 'Exceeds max length of 50' },
              ],
            })(<Input placeholder={'Type'} />)}
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

export const WrappedSpecialOfferEditComponent = Form.create({
  name: 'SpecialOffer Edit',
})(SpecialOfferEditComponent);


/*<Codenesium>
    <Hash>d6bca6ad1c10d959763a90a893b99e77</Hash>
</Codenesium>*/