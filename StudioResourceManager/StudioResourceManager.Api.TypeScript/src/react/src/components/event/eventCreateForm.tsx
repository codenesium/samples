import React, { Component, FormEvent } from 'react';
import axios from 'axios';
import { CreateResponse } from '../../api/apiObjects';
import { Constants, ApiRoutes, ClientRoutes } from '../../constants';
import * as Api from '../../api/models';
import EventMapper from './eventMapper';
import EventViewModel from './eventViewModel';
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
import { EventStatusSelectComponent } from '../shared/eventStatusSelect';

interface EventCreateComponentProps {
  form: WrappedFormUtils;
  history: any;
  match: any;
}

interface EventCreateComponentState {
  model?: EventViewModel;
  loading: boolean;
  loaded: boolean;
  errorOccurred: boolean;
  errorMessage: string;
  submitted: boolean;
}

class EventCreateComponent extends React.Component<
  EventCreateComponentProps,
  EventCreateComponentState
> {
  state = {
    model: new EventViewModel(),
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
        let model = values as EventViewModel;
        console.log('Received values of form: ', model);
        this.submit(model);
      }
    });
  };

  submit = (model: EventViewModel) => {
    let mapper = new EventMapper();
    axios
      .post(
        Constants.ApiEndpoint + ApiRoutes.Events,
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
            Api.EventClientRequestModel
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
            <label htmlFor="actualEndDate">Actual End Date</label>
            <br />
            {getFieldDecorator('actualEndDate', {
              rules: [],
            })(
              <DatePicker
                format={'YYYY-MM-DD'}
                placeholder={'Actual End Date'}
              />
            )}
          </Form.Item>

          <Form.Item>
            <label htmlFor="actualStartDate">Actual Start Date</label>
            <br />
            {getFieldDecorator('actualStartDate', {
              rules: [],
            })(
              <DatePicker
                format={'YYYY-MM-DD'}
                placeholder={'Actual Start Date'}
              />
            )}
          </Form.Item>

          <Form.Item>
            <label htmlFor="billAmount">Bill Amount</label>
            <br />
            {getFieldDecorator('billAmount', {
              rules: [],
            })(<InputNumber placeholder={'Bill Amount'} />)}
          </Form.Item>

          <Form.Item>
            <label htmlFor="eventStatusId">status</label>
            <br />
            {getFieldDecorator('eventStatusId', {
              rules: [{ required: true, message: 'Required' }],
            })(<InputNumber placeholder={'status'} />)}
          </Form.Item>

          <Form.Item>
            <label htmlFor="scheduledEndDate">Scheduled End Date</label>
            <br />
            {getFieldDecorator('scheduledEndDate', {
              rules: [],
            })(
              <DatePicker
                format={'YYYY-MM-DD'}
                placeholder={'Scheduled End Date'}
              />
            )}
          </Form.Item>

          <Form.Item>
            <label htmlFor="scheduledStartDate">Scheduled Start Date</label>
            <br />
            {getFieldDecorator('scheduledStartDate', {
              rules: [],
            })(
              <DatePicker
                format={'YYYY-MM-DD'}
                placeholder={'Scheduled Start Date'}
              />
            )}
          </Form.Item>

          <Form.Item>
            <label htmlFor="studentNote">Student Notes</label>
            <br />
            {getFieldDecorator('studentNote', {
              rules: [],
            })(<Input placeholder={'Student Notes'} />)}
          </Form.Item>

          <Form.Item>
            <label htmlFor="teacherNote">Teacher notes</label>
            <br />
            {getFieldDecorator('teacherNote', {
              rules: [],
            })(<Input placeholder={'Teacher notes'} />)}
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

export const WrappedEventCreateComponent = Form.create({
  name: 'Event Create',
})(EventCreateComponent);


/*<Codenesium>
    <Hash>6cbee524d59595c7e930e81426df943d</Hash>
</Codenesium>*/