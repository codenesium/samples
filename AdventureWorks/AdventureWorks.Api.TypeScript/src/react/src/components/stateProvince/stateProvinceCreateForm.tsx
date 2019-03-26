import React, { Component, FormEvent } from 'react';
import axios, { AxiosError, AxiosResponse } from 'axios';
import { ActionResponse, CreateResponse } from '../../api/apiObjects';
import { Constants, ApiRoutes, ClientRoutes } from '../../constants';
import * as Api from '../../api/models';
import StateProvinceMapper from './stateProvinceMapper';
import StateProvinceViewModel from './stateProvinceViewModel';
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
import { CountryRegionSelectComponent } from '../shared/countryRegionSelect';

interface StateProvinceCreateComponentProps {
  form: WrappedFormUtils;
  history: any;
  match: any;
}

interface StateProvinceCreateComponentState {
  model?: StateProvinceViewModel;
  loading: boolean;
  loaded: boolean;
  errorOccurred: boolean;
  errorMessage: string;
  submitted: boolean;
  submitting: boolean;
}

class StateProvinceCreateComponent extends React.Component<
  StateProvinceCreateComponentProps,
  StateProvinceCreateComponentState
> {
  state = {
    model: new StateProvinceViewModel(),
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
        let model = values as StateProvinceViewModel;
        this.submit(model);
      } else {
        this.setState({ ...this.state, submitting: false, submitted: false });
      }
    });
  };

  submit = (model: StateProvinceViewModel) => {
    let mapper = new StateProvinceMapper();
    axios
      .post<CreateResponse<Api.StateProvinceClientRequestModel>>(
        Constants.ApiEndpoint + ApiRoutes.StateProvinces,
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
          <CountryRegionSelectComponent
            apiRoute={Constants.ApiEndpoint + ApiRoutes.CountryRegions}
            getFieldDecorator={this.props.form.getFieldDecorator}
            propertyName="countryRegionCode"
            required={true}
            selectedValue={this.state.model!.countryRegionCode}
          />

          <Form.Item>
            <label htmlFor="isOnlyStateProvinceFlag">
              Is Only State Province Flag
            </label>
            <br />
            {getFieldDecorator('isOnlyStateProvinceFlag', {
              rules: [],
              valuePropName: 'checked',
            })(<Switch />)}
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
            <label htmlFor="name">Name</label>
            <br />
            {getFieldDecorator('name', {
              rules: [
                { required: true, message: 'Required' },
                { max: 50, message: 'Exceeds max length of 50' },
              ],
            })(<Input placeholder={'Name'} />)}
          </Form.Item>

          <Form.Item>
            <label htmlFor="rowguid">Rowguid</label>
            <br />
            {getFieldDecorator('rowguid', {
              rules: [{ required: true, message: 'Required' }],
            })(<Input placeholder={'Rowguid'} />)}
          </Form.Item>

          <Form.Item>
            <label htmlFor="stateProvinceCode">State Province Code</label>
            <br />
            {getFieldDecorator('stateProvinceCode', {
              rules: [
                { required: true, message: 'Required' },
                { max: 3, message: 'Exceeds max length of 3' },
              ],
            })(<Input placeholder={'State Province Code'} />)}
          </Form.Item>

          <Form.Item>
            <label htmlFor="territoryID">Territory I D</label>
            <br />
            {getFieldDecorator('territoryID', {
              rules: [{ required: true, message: 'Required' }],
            })(<InputNumber placeholder={'Territory I D'} />)}
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

export const WrappedStateProvinceCreateComponent = Form.create({
  name: 'StateProvince Create',
})(StateProvinceCreateComponent);


/*<Codenesium>
    <Hash>2e0260731fdf090e669794c4e8b88eea</Hash>
</Codenesium>*/