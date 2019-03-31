import React, { Component, FormEvent } from 'react';
import axios, { AxiosError, AxiosResponse } from 'axios';
import { ActionResponse, CreateResponse } from '../../api/apiObjects';
import { Constants, ApiRoutes, ClientRoutes } from '../../constants';
import * as Api from '../../api/models';
import FamilyMapper from './familyMapper';
import FamilyViewModel from './familyViewModel';
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

interface FamilyCreateComponentProps {
  form: WrappedFormUtils;
  history: any;
  match: any;
}

interface FamilyCreateComponentState {
  model?: FamilyViewModel;
  loading: boolean;
  loaded: boolean;
  errorOccurred: boolean;
  errorMessage: string;
  submitted: boolean;
  submitting: boolean;
}

class FamilyCreateComponent extends React.Component<
  FamilyCreateComponentProps,
  FamilyCreateComponentState
> {
  state = {
    model: new FamilyViewModel(),
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
        let model = values as FamilyViewModel;
        this.submit(model);
      } else {
        this.setState({ ...this.state, submitting: false, submitted: false });
      }
    });
  };

  submit = (model: FamilyViewModel) => {
    let mapper = new FamilyMapper();
    axios
      .post<CreateResponse<Api.FamilyClientRequestModel>>(
        Constants.ApiEndpoint + ApiRoutes.Families,
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
            <label htmlFor="note">Notes (optional)</label>
            <br />
            {getFieldDecorator('note', {
              rules: [],
            })(<Input placeholder={'Notes'} />)}
          </Form.Item>

          <Form.Item>
            <label htmlFor="primaryContactEmail">
              Primary Contact Email (optional)
            </label>
            <br />
            {getFieldDecorator('primaryContactEmail', {
              rules: [{ max: 128, message: 'Exceeds max length of 128' }],
            })(<Input placeholder={'Primary Contact Email'} />)}
          </Form.Item>

          <Form.Item>
            <label htmlFor="primaryContactFirstName">
              Primary Contact First Name (optional)
            </label>
            <br />
            {getFieldDecorator('primaryContactFirstName', {
              rules: [{ max: 128, message: 'Exceeds max length of 128' }],
            })(<Input placeholder={'Primary Contact First Name'} />)}
          </Form.Item>

          <Form.Item>
            <label htmlFor="primaryContactLastName">
              Primary Contact Last Name (optional)
            </label>
            <br />
            {getFieldDecorator('primaryContactLastName', {
              rules: [{ max: 128, message: 'Exceeds max length of 128' }],
            })(<Input placeholder={'Primary Contact Last Name'} />)}
          </Form.Item>

          <Form.Item>
            <label htmlFor="primaryContactPhone">
              Primary Contact Phone (required)
            </label>
            <br />
            {getFieldDecorator('primaryContactPhone', {
              rules: [
                { required: true, message: 'Required' },
                { max: 128, message: 'Exceeds max length of 128' },
              ],
            })(<Input placeholder={'Primary Contact Phone'} />)}
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

export const WrappedFamilyCreateComponent = Form.create({
  name: 'Family Create',
})(FamilyCreateComponent);


/*<Codenesium>
    <Hash>779adaa00e5b7706e461a445e9ecb0b5</Hash>
</Codenesium>*/