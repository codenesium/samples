import React, { Component, FormEvent } from 'react';
import axios from 'axios';
import { CreateResponse } from '../../api/apiObjects';
import { LoadingForm } from '../../lib/components/loadingForm';
import { ErrorForm } from '../../lib/components/errorForm';
import { Constants, ApiRoutes, ClientRoutes } from '../../constants';
import * as Api from '../../api/models';
import StudioMapper from './studioMapper';
import StudioViewModel from './studioViewModel';
import { Form, Input, Button, Checkbox, InputNumber, DatePicker } from 'antd';
import { WrappedFormUtils } from 'antd/es/form/Form';
import { Alert } from 'antd';

interface StudioCreateComponentProps {
  form: WrappedFormUtils;
  history: any;
  match: any;
}

interface StudioCreateComponentState {
  model?: StudioViewModel;
  loading: boolean;
  loaded: boolean;
  errorOccurred: boolean;
  errorMessage: string;
  submitted: boolean;
}

class StudioCreateComponent extends React.Component<
  StudioCreateComponentProps,
  StudioCreateComponentState
> {
  state = {
    model: new StudioViewModel(),
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
        let model = values as StudioViewModel;
        console.log('Received values of form: ', model);
        this.submit(model);
      }
    });
  };

  submit = (model: StudioViewModel) => {
    let mapper = new StudioMapper();
    axios
      .post(
        Constants.ApiEndpoint + ApiRoutes.Studios,
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
            Api.StudioClientRequestModel
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
            })(<Input placeholder={'address1'} id={'address1'} />)}
          </Form.Item>

          <Form.Item>
            <label htmlFor="address2">address2</label>
            <br />
            {getFieldDecorator('address2', {
              rules: [],
            })(<Input placeholder={'address2'} id={'address2'} />)}
          </Form.Item>

          <Form.Item>
            <label htmlFor="city">city</label>
            <br />
            {getFieldDecorator('city', {
              rules: [],
            })(<Input placeholder={'city'} id={'city'} />)}
          </Form.Item>

          <Form.Item>
            <label htmlFor="name">name</label>
            <br />
            {getFieldDecorator('name', {
              rules: [],
            })(<Input placeholder={'name'} id={'name'} />)}
          </Form.Item>

          <Form.Item>
            <label htmlFor="province">province</label>
            <br />
            {getFieldDecorator('province', {
              rules: [],
            })(<Input placeholder={'province'} id={'province'} />)}
          </Form.Item>

          <Form.Item>
            <label htmlFor="website">website</label>
            <br />
            {getFieldDecorator('website', {
              rules: [],
            })(<Input placeholder={'website'} id={'website'} />)}
          </Form.Item>

          <Form.Item>
            <label htmlFor="zip">zip</label>
            <br />
            {getFieldDecorator('zip', {
              rules: [],
            })(<Input placeholder={'zip'} id={'zip'} />)}
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

export const WrappedStudioCreateComponent = Form.create({
  name: 'Studio Create',
})(StudioCreateComponent);


/*<Codenesium>
    <Hash>32b6969a88a1a6b73a72f19f1f3dd2f5</Hash>
</Codenesium>*/