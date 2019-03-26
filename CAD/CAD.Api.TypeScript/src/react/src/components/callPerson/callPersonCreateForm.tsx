import React, { Component, FormEvent } from 'react';
import axios, { AxiosError, AxiosResponse } from 'axios';
import { ActionResponse, CreateResponse } from '../../api/apiObjects';
import { Constants, ApiRoutes, ClientRoutes } from '../../constants';
import * as Api from '../../api/models';
import CallPersonMapper from './callPersonMapper';
import CallPersonViewModel from './callPersonViewModel';
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
import { PersonSelectComponent } from '../shared/personSelect';
import { PersonTypeSelectComponent } from '../shared/personTypeSelect';

interface CallPersonCreateComponentProps {
  form: WrappedFormUtils;
  history: any;
  match: any;
}

interface CallPersonCreateComponentState {
  model?: CallPersonViewModel;
  loading: boolean;
  loaded: boolean;
  errorOccurred: boolean;
  errorMessage: string;
  submitted: boolean;
  submitting: boolean;
}

class CallPersonCreateComponent extends React.Component<
  CallPersonCreateComponentProps,
  CallPersonCreateComponentState
> {
  state = {
    model: new CallPersonViewModel(),
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
        let model = values as CallPersonViewModel;
        this.submit(model);
      } else {
        this.setState({ ...this.state, submitting: false, submitted: false });
      }
    });
  };

  submit = (model: CallPersonViewModel) => {
    let mapper = new CallPersonMapper();
    axios
      .post<CreateResponse<Api.CallPersonClientRequestModel>>(
        Constants.ApiEndpoint + ApiRoutes.CallPersons,
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
            <label htmlFor="note">note</label>
            <br />
            {getFieldDecorator('note', {
              rules: [{ max: 8000, message: 'Exceeds max length of 8000' }],
            })(<Input placeholder={'note'} />)}
          </Form.Item>

          <Form.Item>
            <label htmlFor="personId">personId</label>
            <br />
            {getFieldDecorator('personId', {
              rules: [{ required: true, message: 'Required' }],
            })(<Input placeholder={'personId'} />)}
          </Form.Item>

          <Form.Item>
            <label htmlFor="personTypeId">personTypeId</label>
            <br />
            {getFieldDecorator('personTypeId', {
              rules: [{ required: true, message: 'Required' }],
            })(<Input placeholder={'personTypeId'} />)}
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

export const WrappedCallPersonCreateComponent = Form.create({
  name: 'CallPerson Create',
})(CallPersonCreateComponent);


/*<Codenesium>
    <Hash>6dddd09ce31d162a6b989cce697cdf0b</Hash>
</Codenesium>*/