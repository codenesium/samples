import React, { Component, FormEvent } from 'react';
import axios from 'axios';
import { CreateResponse } from '../../api/apiObjects';
import { Constants, ApiRoutes, ClientRoutes } from '../../constants';
import * as Api from '../../api/models';
import SaleMapper from './saleMapper';
import SaleViewModel from './saleViewModel';
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
import { PetSelectComponent } from '../shared/petSelect';
interface SaleEditComponentProps {
  form: WrappedFormUtils;
  history: any;
  match: any;
}

interface SaleEditComponentState {
  model?: SaleViewModel;
  loading: boolean;
  loaded: boolean;
  errorOccurred: boolean;
  errorMessage: string;
  submitted: boolean;
}

class SaleEditComponent extends React.Component<
  SaleEditComponentProps,
  SaleEditComponentState
> {
  state = {
    model: new SaleViewModel(),
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
          ApiRoutes.Sales +
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
          let response = resp.data as Api.SaleClientResponseModel;

          console.log(response);

          let mapper = new SaleMapper();

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
        let model = values as SaleViewModel;
        console.log('Received values of form: ', model);
        this.submit(model);
      }
    });
  };

  submit = (model: SaleViewModel) => {
    let mapper = new SaleMapper();
    axios
      .put(
        Constants.ApiEndpoint + ApiRoutes.Sales + '/' + this.state.model!.id,
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
            Api.SaleClientRequestModel
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
            <label htmlFor="amount">amount</label>
            <br />
            {getFieldDecorator('amount', {
              rules: [{ required: true, message: 'Required' }],
            })(<InputNumber placeholder={'amount'} />)}
          </Form.Item>

          <Form.Item>
            <label htmlFor="cutomerId">cutomerId</label>
            <br />
            {getFieldDecorator('cutomerId', {
              rules: [{ required: true, message: 'Required' }],
            })(<Input placeholder={'cutomerId'} />)}
          </Form.Item>

          <Form.Item>
            <label htmlFor="note">note</label>
            <br />
            {getFieldDecorator('note', {
              rules: [{ required: true, message: 'Required' }],
            })(<Input placeholder={'note'} />)}
          </Form.Item>

          <Form.Item>
            <label htmlFor="petId">petId</label>
            <br />
            {getFieldDecorator('petId', {
              rules: [{ required: true, message: 'Required' }],
            })(<Input placeholder={'petId'} />)}
          </Form.Item>

          <Form.Item>
            <label htmlFor="saleDate">saleDate</label>
            <br />
            {getFieldDecorator('saleDate', {
              rules: [{ required: true, message: 'Required' }],
            })(<DatePicker format={'YYYY-MM-DD'} placeholder={'saleDate'} />)}
          </Form.Item>

          <Form.Item>
            <label htmlFor="salesPersonId">salesPersonId</label>
            <br />
            {getFieldDecorator('salesPersonId', {
              rules: [{ required: true, message: 'Required' }],
            })(<Input placeholder={'salesPersonId'} />)}
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

export const WrappedSaleEditComponent = Form.create({ name: 'Sale Edit' })(
  SaleEditComponent
);


/*<Codenesium>
    <Hash>39560f0b68f05762c44d34bdd9ea4b3e</Hash>
</Codenesium>*/