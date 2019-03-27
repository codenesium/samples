import React, { Component, FormEvent } from 'react';
import axios, { AxiosError, AxiosResponse } from 'axios';
import { ActionResponse, CreateResponse } from '../../api/apiObjects';
import { Constants, ApiRoutes, ClientRoutes } from '../../constants';
import * as Api from '../../api/models';
import NoteMapper from './noteMapper';
import NoteViewModel from './noteViewModel';
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
import { CallSelectComponent } from '../shared/callSelect';
import { OfficerSelectComponent } from '../shared/officerSelect';

interface NoteCreateComponentProps {
  form: WrappedFormUtils;
  history: any;
  match: any;
}

interface NoteCreateComponentState {
  model?: NoteViewModel;
  loading: boolean;
  loaded: boolean;
  errorOccurred: boolean;
  errorMessage: string;
  submitted: boolean;
  submitting: boolean;
}

class NoteCreateComponent extends React.Component<
  NoteCreateComponentProps,
  NoteCreateComponentState
> {
  state = {
    model: new NoteViewModel(),
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
        let model = values as NoteViewModel;
        this.submit(model);
      } else {
        this.setState({ ...this.state, submitting: false, submitted: false });
      }
    });
  };

  submit = (model: NoteViewModel) => {
    let mapper = new NoteMapper();
    axios
      .post<CreateResponse<Api.NoteClientRequestModel>>(
        Constants.ApiEndpoint + ApiRoutes.Notes,
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
          <CallSelectComponent
            apiRoute={Constants.ApiEndpoint + ApiRoutes.Calls}
            getFieldDecorator={this.props.form.getFieldDecorator}
            propertyName="callId"
            required={true}
            selectedValue={this.state.model!.callId}
          />

          <Form.Item>
            <label htmlFor="dateCreated">Date Created</label>
            <br />
            {getFieldDecorator('dateCreated', {
              rules: [{ required: true, message: 'Required' }],
            })(
              <DatePicker format={'YYYY-MM-DD'} placeholder={'Date Created'} />
            )}
          </Form.Item>

          <Form.Item>
            <label htmlFor="noteText">Note Text</label>
            <br />
            {getFieldDecorator('noteText', {
              rules: [
                { required: true, message: 'Required' },
                { max: 8000, message: 'Exceeds max length of 8000' },
              ],
            })(<Input placeholder={'Note Text'} />)}
          </Form.Item>

          <OfficerSelectComponent
            apiRoute={Constants.ApiEndpoint + ApiRoutes.Officers}
            getFieldDecorator={this.props.form.getFieldDecorator}
            propertyName="officerId"
            required={true}
            selectedValue={this.state.model!.officerId}
          />

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

export const WrappedNoteCreateComponent = Form.create({ name: 'Note Create' })(
  NoteCreateComponent
);


/*<Codenesium>
    <Hash>1e5ef27101c9771e0156a9e4515fc694</Hash>
</Codenesium>*/