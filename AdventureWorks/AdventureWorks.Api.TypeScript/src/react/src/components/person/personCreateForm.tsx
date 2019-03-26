import React, { Component, FormEvent } from 'react';
import axios, { AxiosError, AxiosResponse } from 'axios';
import { ActionResponse, CreateResponse } from '../../api/apiObjects';
import { Constants, ApiRoutes, ClientRoutes } from '../../constants';
import * as Api from '../../api/models';
import PersonMapper from './personMapper';
import PersonViewModel from './personViewModel';
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
import { BusinessEntitySelectComponent } from '../shared/businessEntitySelect';

interface PersonCreateComponentProps {
  form: WrappedFormUtils;
  history: any;
  match: any;
}

interface PersonCreateComponentState {
  model?: PersonViewModel;
  loading: boolean;
  loaded: boolean;
  errorOccurred: boolean;
  errorMessage: string;
  submitted: boolean;
  submitting: boolean;
}

class PersonCreateComponent extends React.Component<
  PersonCreateComponentProps,
  PersonCreateComponentState
> {
  state = {
    model: new PersonViewModel(),
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
        let model = values as PersonViewModel;
        this.submit(model);
      } else {
        this.setState({ ...this.state, submitting: false, submitted: false });
      }
    });
  };

  submit = (model: PersonViewModel) => {
    let mapper = new PersonMapper();
    axios
      .post<CreateResponse<Api.PersonClientRequestModel>>(
        Constants.ApiEndpoint + ApiRoutes.People,
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
            <label htmlFor="additionalContactInfo">
              Additional Contact Info
            </label>
            <br />
            {getFieldDecorator('additionalContactInfo', {
              rules: [],
            })(<Input placeholder={'Additional Contact Info'} />)}
          </Form.Item>

          <Form.Item>
            <label htmlFor="demographic">Demographics</label>
            <br />
            {getFieldDecorator('demographic', {
              rules: [],
            })(<Input placeholder={'Demographics'} />)}
          </Form.Item>

          <Form.Item>
            <label htmlFor="emailPromotion">Email Promotion</label>
            <br />
            {getFieldDecorator('emailPromotion', {
              rules: [{ required: true, message: 'Required' }],
            })(<InputNumber placeholder={'Email Promotion'} />)}
          </Form.Item>

          <Form.Item>
            <label htmlFor="firstName">First Name</label>
            <br />
            {getFieldDecorator('firstName', {
              rules: [
                { required: true, message: 'Required' },
                { max: 50, message: 'Exceeds max length of 50' },
              ],
            })(<Input placeholder={'First Name'} />)}
          </Form.Item>

          <Form.Item>
            <label htmlFor="lastName">Last Name</label>
            <br />
            {getFieldDecorator('lastName', {
              rules: [
                { required: true, message: 'Required' },
                { max: 50, message: 'Exceeds max length of 50' },
              ],
            })(<Input placeholder={'Last Name'} />)}
          </Form.Item>

          <Form.Item>
            <label htmlFor="middleName">Middle Name</label>
            <br />
            {getFieldDecorator('middleName', {
              rules: [{ max: 50, message: 'Exceeds max length of 50' }],
            })(<Input placeholder={'Middle Name'} />)}
          </Form.Item>

          <Form.Item>
            <label htmlFor="modifiedDate">Modified Date</label>
            <br />
            {getFieldDecorator('modifiedDate', {
              rules: [{ required: true, message: 'Required' }],
            })(
              <DatePicker format={'YYYY-MM-DD'} placeholder={'Modified Date'} />
            )}
          </Form.Item>

          <Form.Item>
            <label htmlFor="nameStyle">Name Style</label>
            <br />
            {getFieldDecorator('nameStyle', {
              rules: [],
              valuePropName: 'checked',
            })(<Switch />)}
          </Form.Item>

          <Form.Item>
            <label htmlFor="personType">Person Type</label>
            <br />
            {getFieldDecorator('personType', {
              rules: [
                { required: true, message: 'Required' },
                { max: 2, message: 'Exceeds max length of 2' },
              ],
            })(<Input placeholder={'Person Type'} />)}
          </Form.Item>

          <Form.Item>
            <label htmlFor="rowguid">Rowguid</label>
            <br />
            {getFieldDecorator('rowguid', {
              rules: [{ required: true, message: 'Required' }],
            })(<Input placeholder={'Rowguid'} />)}
          </Form.Item>

          <Form.Item>
            <label htmlFor="suffix">Suffix</label>
            <br />
            {getFieldDecorator('suffix', {
              rules: [{ max: 10, message: 'Exceeds max length of 10' }],
            })(<Input placeholder={'Suffix'} />)}
          </Form.Item>

          <Form.Item>
            <label htmlFor="title">Title</label>
            <br />
            {getFieldDecorator('title', {
              rules: [{ max: 8, message: 'Exceeds max length of 8' }],
            })(<Input placeholder={'Title'} />)}
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

export const WrappedPersonCreateComponent = Form.create({
  name: 'Person Create',
})(PersonCreateComponent);


/*<Codenesium>
    <Hash>1e708be7d9613f01d0c0ecc148b35fd5</Hash>
</Codenesium>*/