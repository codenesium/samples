import React, { Component, FormEvent } from 'react';
import axios, { AxiosError, AxiosResponse } from 'axios';
import { ActionResponse, CreateResponse } from '../../api/apiObjects';
import { Constants, ApiRoutes, ClientRoutes } from '../../constants';
import * as Api from '../../api/models';
import EmployeeMapper from './employeeMapper';
import EmployeeViewModel from './employeeViewModel';
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
interface EmployeeEditComponentProps {
  form: WrappedFormUtils;
  history: any;
  match: any;
}

interface EmployeeEditComponentState {
  model?: EmployeeViewModel;
  loading: boolean;
  loaded: boolean;
  errorOccurred: boolean;
  errorMessage: string;
  submitted: boolean;
  submitting: boolean;
}

class EmployeeEditComponent extends React.Component<
  EmployeeEditComponentProps,
  EmployeeEditComponentState
> {
  state = {
    model: new EmployeeViewModel(),
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
      .get<Api.EmployeeClientResponseModel>(
        Constants.ApiEndpoint +
          ApiRoutes.Employees +
          '/' +
          this.props.match.params.id,
        {
          headers: GlobalUtilities.defaultHeaders(),
        }
      )
      .then(response => {
        GlobalUtilities.logInfo(response);

        let mapper = new EmployeeMapper();

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
        let model = values as EmployeeViewModel;
        this.submit(model);
      } else {
        this.setState({ ...this.state, submitting: false, submitted: false });
      }
    });
  };

  submit = (model: EmployeeViewModel) => {
    let mapper = new EmployeeMapper();
    axios
      .put<CreateResponse<Api.EmployeeClientRequestModel>>(
        Constants.ApiEndpoint +
          ApiRoutes.Employees +
          '/' +
          this.state.model!.businessEntityID,
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
            <label htmlFor="birthDate">Birth Date</label>
            <br />
            {getFieldDecorator('birthDate', {
              rules: [{ required: true, message: 'Required' }],
            })(<DatePicker format={'YYYY-MM-DD'} placeholder={'Birth Date'} />)}
          </Form.Item>

          <Form.Item>
            <label htmlFor="currentFlag">Current Flag</label>
            <br />
            {getFieldDecorator('currentFlag', {
              rules: [],
              valuePropName: 'checked',
            })(<Switch />)}
          </Form.Item>

          <Form.Item>
            <label htmlFor="gender">Gender</label>
            <br />
            {getFieldDecorator('gender', {
              rules: [
                { required: true, message: 'Required' },
                { max: 1, message: 'Exceeds max length of 1' },
              ],
            })(<Input placeholder={'Gender'} />)}
          </Form.Item>

          <Form.Item>
            <label htmlFor="hireDate">Hire Date</label>
            <br />
            {getFieldDecorator('hireDate', {
              rules: [{ required: true, message: 'Required' }],
            })(<DatePicker format={'YYYY-MM-DD'} placeholder={'Hire Date'} />)}
          </Form.Item>

          <Form.Item>
            <label htmlFor="jobTitle">Job Title</label>
            <br />
            {getFieldDecorator('jobTitle', {
              rules: [
                { required: true, message: 'Required' },
                { max: 50, message: 'Exceeds max length of 50' },
              ],
            })(<Input placeholder={'Job Title'} />)}
          </Form.Item>

          <Form.Item>
            <label htmlFor="loginID">Login I D</label>
            <br />
            {getFieldDecorator('loginID', {
              rules: [
                { required: true, message: 'Required' },
                { max: 256, message: 'Exceeds max length of 256' },
              ],
            })(<Input placeholder={'Login I D'} />)}
          </Form.Item>

          <Form.Item>
            <label htmlFor="maritalStatu">Marital Status</label>
            <br />
            {getFieldDecorator('maritalStatu', {
              rules: [
                { required: true, message: 'Required' },
                { max: 1, message: 'Exceeds max length of 1' },
              ],
            })(<Input placeholder={'Marital Status'} />)}
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
            <label htmlFor="nationalIDNumber">National I D Number</label>
            <br />
            {getFieldDecorator('nationalIDNumber', {
              rules: [
                { required: true, message: 'Required' },
                { max: 15, message: 'Exceeds max length of 15' },
              ],
            })(<Input placeholder={'National I D Number'} />)}
          </Form.Item>

          <Form.Item>
            <label htmlFor="organizationLevel">Organization Level</label>
            <br />
            {getFieldDecorator('organizationLevel', {
              rules: [],
            })(<InputNumber placeholder={'Organization Level'} />)}
          </Form.Item>

          <Form.Item>
            <label htmlFor="rowguid">Rowguid</label>
            <br />
            {getFieldDecorator('rowguid', {
              rules: [{ required: true, message: 'Required' }],
            })(<Input placeholder={'Rowguid'} />)}
          </Form.Item>

          <Form.Item>
            <label htmlFor="salariedFlag">Salaried Flag</label>
            <br />
            {getFieldDecorator('salariedFlag', {
              rules: [],
              valuePropName: 'checked',
            })(<Switch />)}
          </Form.Item>

          <Form.Item>
            <label htmlFor="sickLeaveHour">Sick Leave Hours</label>
            <br />
            {getFieldDecorator('sickLeaveHour', {
              rules: [{ required: true, message: 'Required' }],
            })(<InputNumber placeholder={'Sick Leave Hours'} />)}
          </Form.Item>

          <Form.Item>
            <label htmlFor="vacationHour">Vacation Hours</label>
            <br />
            {getFieldDecorator('vacationHour', {
              rules: [{ required: true, message: 'Required' }],
            })(<InputNumber placeholder={'Vacation Hours'} />)}
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

export const WrappedEmployeeEditComponent = Form.create({
  name: 'Employee Edit',
})(EmployeeEditComponent);


/*<Codenesium>
    <Hash>69c231e72c3dff2bd9a6cf8254e9f553</Hash>
</Codenesium>*/