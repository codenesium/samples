import React, { Component, FormEvent } from 'react';
import axios from 'axios';
import { CreateResponse } from '../../api/apiObjects';
import { LoadingForm } from '../../lib/components/loadingForm';
import { ErrorForm } from '../../lib/components/errorForm';
import { Constants, ApiRoutes, ClientRoutes } from '../../constants';
import * as Api from '../../api/models';
import TicketMapper from './ticketMapper';
import TicketViewModel from './ticketViewModel';
import { Form, Input, Button, Checkbox, InputNumber, DatePicker } from 'antd';
import { WrappedFormUtils } from 'antd/es/form/Form';
import { Alert } from 'antd';

interface TicketCreateComponentProps {
  form: WrappedFormUtils;
  history: any;
  match: any;
}

interface TicketCreateComponentState {
  model?: TicketViewModel;
  loading: boolean;
  loaded: boolean;
  errorOccurred: boolean;
  errorMessage: string;
  submitted: boolean;
}

class TicketCreateComponent extends React.Component<
  TicketCreateComponentProps,
  TicketCreateComponentState
> {
  state = {
    model: new TicketViewModel(),
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
        let model = values as TicketViewModel;
        console.log('Received values of form: ', model);
        this.submit(model);
      }
    });
  };

  submit = (model: TicketViewModel) => {
    let mapper = new TicketMapper();
    axios
      .post(
        Constants.ApiEndpoint + ApiRoutes.Tickets,
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
            Api.TicketClientRequestModel
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
            <label htmlFor="publicId">publicId</label>
            <br />
            {getFieldDecorator('publicId', {
              rules: [],
            })(<Input placeholder={'publicId'} id={'publicId'} />)}
          </Form.Item>

          <Form.Item>
            <label htmlFor="ticketStatusId">ticketStatusId</label>
            <br />
            {getFieldDecorator('ticketStatusId', {
              rules: [],
            })(<Input placeholder={'ticketStatusId'} id={'ticketStatusId'} />)}
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

export const WrappedTicketCreateComponent = Form.create({
  name: 'Ticket Create',
})(TicketCreateComponent);


/*<Codenesium>
    <Hash>950af8ccc40ed509f5ad78d9ba3f3118</Hash>
</Codenesium>*/