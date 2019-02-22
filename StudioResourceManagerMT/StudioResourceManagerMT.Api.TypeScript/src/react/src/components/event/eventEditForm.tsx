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
            <label htmlFor="actualEndDate">actualEndDate</label>
            <br />
            {getFieldDecorator('actualEndDate', {
              rules: [],
            })(
              <DatePicker format={'YYYY-MM-DD'} placeholder={'actualEndDate'} />
            )}
          </Form.Item>

          <Form.Item>
            <label htmlFor="actualStartDate">actualStartDate</label>
            <br />
            {getFieldDecorator('actualStartDate', {
              rules: [],
            })(
              <DatePicker
                format={'YYYY-MM-DD'}
                placeholder={'actualStartDate'}
              />
            )}
          </Form.Item>

          <Form.Item>
            <label htmlFor="billAmount">billAmount</label>
            <br />
            {getFieldDecorator('billAmount', {
              rules: [],
            })(<DatePicker format={'YYYY-MM-DD'} placeholder={'billAmount'} />)}
          </Form.Item>

          <Form.Item>
            <label htmlFor="eventStatusId">eventStatusId</label>
            <br />
            {getFieldDecorator('eventStatusId', {
              rules: [
                { required: true, message: 'Required' },
                { whitespace: true, message: 'Required' },
              ],
            })(
              <DatePicker format={'YYYY-MM-DD'} placeholder={'eventStatusId'} />
            )}
          </Form.Item>

          <Form.Item>
            <label htmlFor="scheduledEndDate">scheduledEndDate</label>
            <br />
            {getFieldDecorator('scheduledEndDate', {
              rules: [],
            })(
              <DatePicker
                format={'YYYY-MM-DD'}
                placeholder={'scheduledEndDate'}
              />
            )}
          </Form.Item>

          <Form.Item>
            <label htmlFor="scheduledStartDate">scheduledStartDate</label>
            <br />
            {getFieldDecorator('scheduledStartDate', {
              rules: [],
            })(
              <DatePicker
                format={'YYYY-MM-DD'}
                placeholder={'scheduledStartDate'}
              />
            )}
          </Form.Item>

          <Form.Item>
            <label htmlFor="studentNote">studentNotes</label>
            <br />
            {getFieldDecorator('studentNote', {
              rules: [],
            })(
              <DatePicker format={'YYYY-MM-DD'} placeholder={'studentNotes'} />
            )}
          </Form.Item>

          <Form.Item>
            <label htmlFor="teacherNote">teacherNotes</label>
            <br />
            {getFieldDecorator('teacherNote', {
              rules: [],
            })(
              <DatePicker format={'YYYY-MM-DD'} placeholder={'teacherNotes'} />
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

export const WrappedEventEditComponent = Form.create({ name: 'Event Edit' })(
  EventEditComponent
);


/*<Codenesium>
    <Hash>46f15749658578375ba31081a1012e97</Hash>
</Codenesium>*/