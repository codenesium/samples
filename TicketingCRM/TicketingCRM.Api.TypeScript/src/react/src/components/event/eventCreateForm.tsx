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
import { CitySelectComponent } from '../shared/citySelect';

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
  submitting: boolean;
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
    submitting: false,
  };

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
      .post<CreateResponse<Api.EventClientRequestModel>>(
        Constants.ApiEndpoint + ApiRoutes.Events,
        mapper.mapViewModelToApiRequest(model),
        {
          headers: GlobalUtilities.defaultHeaders(),
        }
      )
      .then(response => {
        this.setState({
          ...this.state,
          submitted: true,
          submitting: false,
          model: mapper.mapApiResponseToViewModel(response.data.record!),
          errorOccurred: false,
          errorMessage: '',
        });
        GlobalUtilities.logInfo(response);
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
            <label htmlFor="address1">Address1</label>
            <br />
            {getFieldDecorator('address1', {
              rules: [
                { required: true, message: 'Required' },
                { max: 128, message: 'Exceeds max length of 128' },
              ],
            })(<Input placeholder={'Address1'} />)}
          </Form.Item>

          <Form.Item>
            <label htmlFor="address2">Address2</label>
            <br />
            {getFieldDecorator('address2', {
              rules: [
                { required: true, message: 'Required' },
                { max: 128, message: 'Exceeds max length of 128' },
              ],
            })(<Input placeholder={'Address2'} />)}
          </Form.Item>

          <CitySelectComponent
            apiRoute={Constants.ApiEndpoint + ApiRoutes.Cities}
            getFieldDecorator={this.props.form.getFieldDecorator}
            propertyName="cityId"
            required={true}
            selectedValue={this.state.model!.cityId}
          />

          <Form.Item>
            <label htmlFor="date">Date</label>
            <br />
            {getFieldDecorator('date', {
              rules: [{ required: true, message: 'Required' }],
            })(<DatePicker format={'YYYY-MM-DD'} placeholder={'Date'} />)}
          </Form.Item>

          <Form.Item>
            <label htmlFor="description">Description</label>
            <br />
            {getFieldDecorator('description', {
              rules: [{ required: true, message: 'Required' }],
            })(<Input placeholder={'Description'} />)}
          </Form.Item>

          <Form.Item>
            <label htmlFor="endDate">End Date</label>
            <br />
            {getFieldDecorator('endDate', {
              rules: [{ required: true, message: 'Required' }],
            })(<DatePicker format={'YYYY-MM-DD'} placeholder={'End Date'} />)}
          </Form.Item>

          <Form.Item>
            <label htmlFor="facebook">Facebook</label>
            <br />
            {getFieldDecorator('facebook', {
              rules: [
                { required: true, message: 'Required' },
                { max: 128, message: 'Exceeds max length of 128' },
              ],
            })(<Input placeholder={'Facebook'} />)}
          </Form.Item>

          <Form.Item>
            <label htmlFor="name">Name</label>
            <br />
            {getFieldDecorator('name', {
              rules: [
                { required: true, message: 'Required' },
                { max: 128, message: 'Exceeds max length of 128' },
              ],
            })(<Input placeholder={'Name'} />)}
          </Form.Item>

          <Form.Item>
            <label htmlFor="startDate">Start Date</label>
            <br />
            {getFieldDecorator('startDate', {
              rules: [{ required: true, message: 'Required' }],
            })(<DatePicker format={'YYYY-MM-DD'} placeholder={'Start Date'} />)}
          </Form.Item>

          <Form.Item>
            <label htmlFor="website">Website</label>
            <br />
            {getFieldDecorator('website', {
              rules: [
                { required: true, message: 'Required' },
                { max: 128, message: 'Exceeds max length of 128' },
              ],
            })(<Input placeholder={'Website'} />)}
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

export const WrappedEventCreateComponent = Form.create({
  name: 'Event Create',
})(EventCreateComponent);


/*<Codenesium>
    <Hash>a9f44630b0a082504934bcbc12112659</Hash>
</Codenesium>*/