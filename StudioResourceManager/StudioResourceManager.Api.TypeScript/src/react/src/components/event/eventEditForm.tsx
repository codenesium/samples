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

interface EventEditComponentProps {
  form: WrappedFormUtils;
  history: any;
  match: any;
}

interface EventEditComponentState {
  model?: EventViewModel;
  loading: boolean;
  loaded: boolean;
  errorOccurred: boolean;
  errorMessage: string;
  submitted: boolean;
}

class EventEditComponent extends React.Component<
  EventEditComponentProps,
  EventEditComponentState
> {
  state = {
    model: new EventViewModel(),
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
          ApiRoutes.Events +
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
          let response = resp.data as Api.EventClientResponseModel;

          console.log(response);

          let mapper = new EventMapper();

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
        let model = values as EventViewModel;
        console.log('Received values of form: ', model);
        this.submit(model);
      }
    });
  };

  submit = (model: EventViewModel) => {
    let mapper = new EventMapper();
    axios
      .put(
        Constants.ApiEndpoint + ApiRoutes.Events + '/' + this.state.model!.id,
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

export const WrappedEventEditComponent = Form.create({ name: 'Event Edit' })(
  EventEditComponent
);


/*<Codenesium>
    <Hash>6bad692b18952ddd4d50b74ba98296c9</Hash>
</Codenesium>*/