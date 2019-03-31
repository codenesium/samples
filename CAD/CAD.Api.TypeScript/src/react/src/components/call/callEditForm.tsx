import React, { Component, FormEvent } from 'react';
import axios, { AxiosError, AxiosResponse } from 'axios';
import { ActionResponse, CreateResponse } from '../../api/apiObjects';
import { Constants, ApiRoutes, ClientRoutes } from '../../constants';
import * as Api from '../../api/models';
import CallMapper from './callMapper';
import CallViewModel from './callViewModel';
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
import { AddressSelectComponent } from '../shared/addressSelect';
import { CallDispositionSelectComponent } from '../shared/callDispositionSelect';
import { CallStatusSelectComponent } from '../shared/callStatusSelect';
import { CallTypeSelectComponent } from '../shared/callTypeSelect';
interface CallEditComponentProps {
  form: WrappedFormUtils;
  history: any;
  match: any;
}

interface CallEditComponentState {
  model?: CallViewModel;
  loading: boolean;
  loaded: boolean;
  errorOccurred: boolean;
  errorMessage: string;
  submitted: boolean;
  submitting: boolean;
}

class CallEditComponent extends React.Component<
  CallEditComponentProps,
  CallEditComponentState
> {
  state = {
    model: new CallViewModel(),
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
      .get<Api.CallClientResponseModel>(
        Constants.ApiEndpoint +
          ApiRoutes.Calls +
          '/' +
          this.props.match.params.id,
        {
          headers: GlobalUtilities.defaultHeaders(),
        }
      )
      .then(response => {
        GlobalUtilities.logInfo(response);

        let mapper = new CallMapper();

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
        let model = values as CallViewModel;
        this.submit(model);
      } else {
        this.setState({ ...this.state, submitting: false, submitted: false });
      }
    });
  };

  submit = (model: CallViewModel) => {
    let mapper = new CallMapper();
    axios
      .put<CreateResponse<Api.CallClientRequestModel>>(
        Constants.ApiEndpoint + ApiRoutes.Calls + '/' + this.state.model!.id,
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
          <AddressSelectComponent
            apiRoute={Constants.ApiEndpoint + ApiRoutes.Addresses}
            getFieldDecorator={this.props.form.getFieldDecorator}
            propertyName="addressId"
            required={false}
            selectedValue={this.state.model!.addressId}
          />

          <CallDispositionSelectComponent
            apiRoute={Constants.ApiEndpoint + ApiRoutes.CallDispositions}
            getFieldDecorator={this.props.form.getFieldDecorator}
            propertyName="callDispositionId"
            required={false}
            selectedValue={this.state.model!.callDispositionId}
          />

          <CallStatusSelectComponent
            apiRoute={Constants.ApiEndpoint + ApiRoutes.CallStatus}
            getFieldDecorator={this.props.form.getFieldDecorator}
            propertyName="callStatusId"
            required={false}
            selectedValue={this.state.model!.callStatusId}
          />

          <Form.Item>
            <label htmlFor="callString">Call String (required)</label>
            <br />
            {getFieldDecorator('callString', {
              rules: [
                { required: true, message: 'Required' },
                { max: 24, message: 'Exceeds max length of 24' },
              ],
            })(<Input placeholder={'Call String'} />)}
          </Form.Item>

          <CallTypeSelectComponent
            apiRoute={Constants.ApiEndpoint + ApiRoutes.CallTypes}
            getFieldDecorator={this.props.form.getFieldDecorator}
            propertyName="callTypeId"
            required={false}
            selectedValue={this.state.model!.callTypeId}
          />

          <Form.Item>
            <label htmlFor="dateCleared">Date Cleared (optional)</label>
            <br />
            {getFieldDecorator('dateCleared', {
              rules: [],
            })(
              <DatePicker format={'YYYY-MM-DD'} placeholder={'Date Cleared'} />
            )}
          </Form.Item>

          <Form.Item>
            <label htmlFor="dateCreated">Date Created (required)</label>
            <br />
            {getFieldDecorator('dateCreated', {
              rules: [{ required: true, message: 'Required' }],
            })(
              <DatePicker format={'YYYY-MM-DD'} placeholder={'Date Created'} />
            )}
          </Form.Item>

          <Form.Item>
            <label htmlFor="dateDispatched">Date Dispatched (optional)</label>
            <br />
            {getFieldDecorator('dateDispatched', {
              rules: [],
            })(
              <DatePicker
                format={'YYYY-MM-DD'}
                placeholder={'Date Dispatched'}
              />
            )}
          </Form.Item>

          <Form.Item>
            <label htmlFor="quickCallNumber">
              Quick Call Number (required)
            </label>
            <br />
            {getFieldDecorator('quickCallNumber', {
              rules: [{ required: true, message: 'Required' }],
            })(<InputNumber placeholder={'Quick Call Number'} />)}
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

export const WrappedCallEditComponent = Form.create({ name: 'Call Edit' })(
  CallEditComponent
);


/*<Codenesium>
    <Hash>ce2097edb2433f240c3daa1a9486ea73</Hash>
</Codenesium>*/