import React, { Component, FormEvent } from 'react';
import axios, { AxiosError, AxiosResponse } from 'axios';
import { ActionResponse, CreateResponse } from '../../api/apiObjects';
import { Constants, ApiRoutes, ClientRoutes } from '../../constants';
import * as Api from '../../api/models';
import LocationMapper from './locationMapper';
import LocationViewModel from './locationViewModel';
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

interface LocationCreateComponentProps {
  form: WrappedFormUtils;
  history: any;
  match: any;
}

interface LocationCreateComponentState {
  model?: LocationViewModel;
  loading: boolean;
  loaded: boolean;
  errorOccurred: boolean;
  errorMessage: string;
  submitted: boolean;
  submitting: boolean;
}

class LocationCreateComponent extends React.Component<
  LocationCreateComponentProps,
  LocationCreateComponentState
> {
  state = {
    model: new LocationViewModel(),
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
        let model = values as LocationViewModel;
        this.submit(model);
      } else {
        this.setState({ ...this.state, submitting: false, submitted: false });
      }
    });
  };

  submit = (model: LocationViewModel) => {
    let mapper = new LocationMapper();
    axios
      .post<CreateResponse<Api.LocationClientRequestModel>>(
        Constants.ApiEndpoint + ApiRoutes.Locations,
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
            <label htmlFor="gpsLat">gps_lat (required)</label>
            <br />
            {getFieldDecorator('gpsLat', {
              rules: [{ required: true, message: 'Required' }],
            })(<Input placeholder={'gps_lat'} />)}
          </Form.Item>

          <Form.Item>
            <label htmlFor="gpsLong">gps_long (required)</label>
            <br />
            {getFieldDecorator('gpsLong', {
              rules: [{ required: true, message: 'Required' }],
            })(<Input placeholder={'gps_long'} />)}
          </Form.Item>

          <Form.Item>
            <label htmlFor="locationName">location_name (required)</label>
            <br />
            {getFieldDecorator('locationName', {
              rules: [
                { required: true, message: 'Required' },
                { max: 64, message: 'Exceeds max length of 64' },
              ],
            })(<Input placeholder={'location_name'} />)}
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

export const WrappedLocationCreateComponent = Form.create({
  name: 'Location Create',
})(LocationCreateComponent);


/*<Codenesium>
    <Hash>fe328c9a6317b5bccb4732fdd55fdd24</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/