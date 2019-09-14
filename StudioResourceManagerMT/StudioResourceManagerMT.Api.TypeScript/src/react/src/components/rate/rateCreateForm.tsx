import React, { Component, FormEvent } from 'react';
import axios, { AxiosError, AxiosResponse } from 'axios';
import { ActionResponse, CreateResponse } from '../../api/apiObjects';
import { Constants, ApiRoutes, ClientRoutes } from '../../constants';
import * as Api from '../../api/models';
import RateMapper from './rateMapper';
import RateViewModel from './rateViewModel';
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
import { TeacherSelectComponent } from '../shared/teacherSelect';
import { TeacherSkillSelectComponent } from '../shared/teacherSkillSelect';

interface RateCreateComponentProps {
  form: WrappedFormUtils;
  history: any;
  match: any;
}

interface RateCreateComponentState {
  model?: RateViewModel;
  loading: boolean;
  loaded: boolean;
  errorOccurred: boolean;
  errorMessage: string;
  submitted: boolean;
  submitting: boolean;
}

class RateCreateComponent extends React.Component<
  RateCreateComponentProps,
  RateCreateComponentState
> {
  state = {
    model: new RateViewModel(),
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
        let model = values as RateViewModel;
        this.submit(model);
      } else {
        this.setState({ ...this.state, submitting: false, submitted: false });
      }
    });
  };

  submit = (model: RateViewModel) => {
    let mapper = new RateMapper();
    axios
      .post<CreateResponse<Api.RateClientRequestModel>>(
        Constants.ApiEndpoint + ApiRoutes.Rates,
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
            <label htmlFor="amountPerMinute">
              Amount Per Minute (required)
            </label>
            <br />
            {getFieldDecorator('amountPerMinute', {
              rules: [{ required: true, message: 'Required' }],
            })(<InputNumber placeholder={'Amount Per Minute'} />)}
          </Form.Item>

          <TeacherSelectComponent
            apiRoute={Constants.ApiEndpoint + ApiRoutes.Teachers}
            getFieldDecorator={this.props.form.getFieldDecorator}
            propertyName="teacherId"
            required={true}
            selectedValue={this.state.model!.teacherId}
          />

          <TeacherSkillSelectComponent
            apiRoute={Constants.ApiEndpoint + ApiRoutes.TeacherSkills}
            getFieldDecorator={this.props.form.getFieldDecorator}
            propertyName="teacherSkillId"
            required={true}
            selectedValue={this.state.model!.teacherSkillId}
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

export const WrappedRateCreateComponent = Form.create({ name: 'Rate Create' })(
  RateCreateComponent
);


/*<Codenesium>
    <Hash>4ceac80ebd0721be4b7721f8b0ea395b</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/