import React, { Component, FormEvent } from 'react';
import axios, { AxiosError, AxiosResponse } from 'axios';
import { ActionResponse, CreateResponse } from '../../api/apiObjects';
import { Constants, ApiRoutes, ClientRoutes } from '../../constants';
import * as Api from '../../api/models';
import UnitOfficerMapper from './unitOfficerMapper';
import UnitOfficerViewModel from './unitOfficerViewModel';
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
import { OfficerSelectComponent } from '../shared/officerSelect';
import { UnitSelectComponent } from '../shared/unitSelect';

interface UnitOfficerCreateComponentProps {
  form: WrappedFormUtils;
  history: any;
  match: any;
}

interface UnitOfficerCreateComponentState {
  model?: UnitOfficerViewModel;
  loading: boolean;
  loaded: boolean;
  errorOccurred: boolean;
  errorMessage: string;
  submitted: boolean;
  submitting: boolean;
}

class UnitOfficerCreateComponent extends React.Component<
  UnitOfficerCreateComponentProps,
  UnitOfficerCreateComponentState
> {
  state = {
    model: new UnitOfficerViewModel(),
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
        let model = values as UnitOfficerViewModel;
        this.submit(model);
      } else {
        this.setState({ ...this.state, submitting: false, submitted: false });
      }
    });
  };

  submit = (model: UnitOfficerViewModel) => {
    let mapper = new UnitOfficerMapper();
    axios
      .post<CreateResponse<Api.UnitOfficerClientRequestModel>>(
        Constants.ApiEndpoint + ApiRoutes.UnitOfficers,
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
          <OfficerSelectComponent
            apiRoute={Constants.ApiEndpoint + ApiRoutes.Officers}
            getFieldDecorator={this.props.form.getFieldDecorator}
            propertyName="officerId"
            required={true}
            selectedValue={this.state.model!.officerId}
          />

          <UnitSelectComponent
            apiRoute={Constants.ApiEndpoint + ApiRoutes.Units}
            getFieldDecorator={this.props.form.getFieldDecorator}
            propertyName="unitId"
            required={true}
            selectedValue={this.state.model!.unitId}
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

export const WrappedUnitOfficerCreateComponent = Form.create({
  name: 'UnitOfficer Create',
})(UnitOfficerCreateComponent);


/*<Codenesium>
    <Hash>8eabae4efeb3c2bdb4cae948b35047c3</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/