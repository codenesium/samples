import React, { Component, FormEvent } from 'react';
import axios from 'axios';
import { CreateResponse } from '../../api/apiObjects';
import { LoadingForm } from '../../lib/components/loadingForm';
import { ErrorForm } from '../../lib/components/errorForm';
import { Constants, ApiRoutes, ClientRoutes } from '../../constants';
import * as Api from '../../api/models';
import VenueMapper from './venueMapper';
import VenueViewModel from './venueViewModel';
import { Form, Input, Button, Checkbox, InputNumber, DatePicker } from 'antd';
import { WrappedFormUtils } from 'antd/es/form/Form';
import { Alert } from 'antd';

interface VenueCreateComponentProps {
  form: WrappedFormUtils;
  history: any;
  match: any;
}

interface VenueCreateComponentState {
  model?: VenueViewModel;
  loading: boolean;
  loaded: boolean;
  errorOccurred: boolean;
  errorMessage: string;
  submitted: boolean;
}

class VenueCreateComponent extends React.Component<
  VenueCreateComponentProps,
  VenueCreateComponentState
> {
  state = {
    model: new VenueViewModel(),
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
        let model = values as VenueViewModel;
        console.log('Received values of form: ', model);
        this.submit(model);
      }
    });
  };

  submit = (model: VenueViewModel) => {
    let mapper = new VenueMapper();
    axios
      .post(
        Constants.ApiEndpoint + ApiRoutes.Venues,
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
            Api.VenueClientRequestModel
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
      return <LoadingForm />;
    } else if (this.state.loaded) {
      return (
        <Form onSubmit={this.handleSubmit}>
          <Form.Item>
            <label htmlFor="address1">address1</label>
            <br />
            {getFieldDecorator('address1', {
              rules: [],
            })(<DatePicker placeholder={'address1'} id={'address1'} />)}
          </Form.Item>

          <Form.Item>
            <label htmlFor="address2">address2</label>
            <br />
            {getFieldDecorator('address2', {
              rules: [],
            })(<DatePicker placeholder={'address2'} id={'address2'} />)}
          </Form.Item>

          <Form.Item>
            <label htmlFor="adminId">adminId</label>
            <br />
            {getFieldDecorator('adminId', {
              rules: [],
            })(<DatePicker placeholder={'adminId'} id={'adminId'} />)}
          </Form.Item>

          <Form.Item>
            <label htmlFor="email">email</label>
            <br />
            {getFieldDecorator('email', {
              rules: [],
            })(<DatePicker placeholder={'email'} id={'email'} />)}
          </Form.Item>

          <Form.Item>
            <label htmlFor="facebook">facebook</label>
            <br />
            {getFieldDecorator('facebook', {
              rules: [],
            })(<DatePicker placeholder={'facebook'} id={'facebook'} />)}
          </Form.Item>

          <Form.Item>
            <label htmlFor="name">name</label>
            <br />
            {getFieldDecorator('name', {
              rules: [],
            })(<DatePicker placeholder={'name'} id={'name'} />)}
          </Form.Item>

          <Form.Item>
            <label htmlFor="phone">phone</label>
            <br />
            {getFieldDecorator('phone', {
              rules: [],
            })(<DatePicker placeholder={'phone'} id={'phone'} />)}
          </Form.Item>

          <Form.Item>
            <label htmlFor="provinceId">provinceId</label>
            <br />
            {getFieldDecorator('provinceId', {
              rules: [],
            })(<DatePicker placeholder={'provinceId'} id={'provinceId'} />)}
          </Form.Item>

          <Form.Item>
            <label htmlFor="website">website</label>
            <br />
            {getFieldDecorator('website', {
              rules: [],
            })(<DatePicker placeholder={'website'} id={'website'} />)}
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

export const WrappedVenueCreateComponent = Form.create({
  name: 'Venue Create',
})(VenueCreateComponent);


/*<Codenesium>
    <Hash>d5be5af9015d3d71b54882a5c67fd57c</Hash>
</Codenesium>*/