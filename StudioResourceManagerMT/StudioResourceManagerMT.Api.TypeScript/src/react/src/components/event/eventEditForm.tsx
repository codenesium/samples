import React, { Component, FormEvent } from 'react';
import axios, { AxiosError, AxiosResponse } from 'axios';
import { ActionResponse, CreateResponse } from '../../api/apiObjects';
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
import * as GlobalUtilities from '../../lib/globalUtilities';
import { EventStatuSelectComponent } from '../shared/eventStatuSelect';
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
  submitting: boolean;
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
    submitting: false,
  };

  componentDidMount() {
    this.setState({ ...this.state, loading: true });

    axios
      .get<Api.EventClientResponseModel>(
        Constants.ApiEndpoint +
          ApiRoutes.Events +
          '/' +
          this.props.match.params.id,
        {
          headers: GlobalUtilities.defaultHeaders(),
        }
      )
      .then(response => {
        GlobalUtilities.logInfo(response);

        let mapper = new EventMapper();

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
        let model = values as EventViewModel;
        this.submit(model);
      } else {
        this.setState({ ...this.state, submitting: false, submitted: false });
      }
    });
  };

  submit = (model: EventViewModel) => {
    let mapper = new EventMapper();
    axios
      .put<CreateResponse<Api.EventClientRequestModel>>(
        Constants.ApiEndpoint + ApiRoutes.Events + '/' + this.state.model!.id,
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
            <label htmlFor="actualEndDate">Actual End Date (optional)</label>
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
            <label htmlFor="actualStartDate">
              Actual Start Date (optional)
            </label>
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
            <label htmlFor="billAmount">Bill Amount (optional)</label>
            <br />
            {getFieldDecorator('billAmount', {
              rules: [],
            })(<InputNumber placeholder={'Bill Amount'} />)}
          </Form.Item>

          <EventStatuSelectComponent
            apiRoute={Constants.ApiEndpoint + ApiRoutes.EventStatus}
            getFieldDecorator={this.props.form.getFieldDecorator}
            propertyName="eventStatusId"
            required={true}
            selectedValue={this.state.model!.eventStatusId}
          />

          <Form.Item>
            <label htmlFor="scheduledEndDate">
              Scheduled End Date (optional)
            </label>
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
            <label htmlFor="scheduledStartDate">
              Scheduled Start Date (optional)
            </label>
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
            <label htmlFor="studentNote">Student Notes (optional)</label>
            <br />
            {getFieldDecorator('studentNote', {
              rules: [],
            })(<Input placeholder={'Student Notes'} />)}
          </Form.Item>

          <Form.Item>
            <label htmlFor="teacherNote">Teacher Notes (optional)</label>
            <br />
            {getFieldDecorator('teacherNote', {
              rules: [],
            })(<Input placeholder={'Teacher Notes'} />)}
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

export const WrappedEventEditComponent = Form.create({ name: 'Event Edit' })(
  EventEditComponent
);


/*<Codenesium>
    <Hash>ce4014a85e85576062e653059263f725</Hash>
</Codenesium>*/