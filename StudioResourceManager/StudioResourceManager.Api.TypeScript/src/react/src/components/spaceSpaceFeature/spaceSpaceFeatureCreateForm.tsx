import React, { Component, FormEvent } from 'react';
import axios, { AxiosError, AxiosResponse } from 'axios';
import { ActionResponse, CreateResponse } from '../../api/apiObjects';
import { Constants, ApiRoutes, ClientRoutes } from '../../constants';
import * as Api from '../../api/models';
import SpaceSpaceFeatureMapper from './spaceSpaceFeatureMapper';
import SpaceSpaceFeatureViewModel from './spaceSpaceFeatureViewModel';
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
import { SpaceFeatureSelectComponent } from '../shared/spaceFeatureSelect';
import { SpaceSelectComponent } from '../shared/spaceSelect';

interface SpaceSpaceFeatureCreateComponentProps {
  form: WrappedFormUtils;
  history: any;
  match: any;
}

interface SpaceSpaceFeatureCreateComponentState {
  model?: SpaceSpaceFeatureViewModel;
  loading: boolean;
  loaded: boolean;
  errorOccurred: boolean;
  errorMessage: string;
  submitted: boolean;
  submitting: boolean;
}

class SpaceSpaceFeatureCreateComponent extends React.Component<
  SpaceSpaceFeatureCreateComponentProps,
  SpaceSpaceFeatureCreateComponentState
> {
  state = {
    model: new SpaceSpaceFeatureViewModel(),
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
        let model = values as SpaceSpaceFeatureViewModel;
        this.submit(model);
      } else {
        this.setState({ ...this.state, submitting: false, submitted: false });
      }
    });
  };

  submit = (model: SpaceSpaceFeatureViewModel) => {
    let mapper = new SpaceSpaceFeatureMapper();
    axios
      .post<CreateResponse<Api.SpaceSpaceFeatureClientRequestModel>>(
        Constants.ApiEndpoint + ApiRoutes.SpaceSpaceFeatures,
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
          <SpaceFeatureSelectComponent
            apiRoute={Constants.ApiEndpoint + ApiRoutes.SpaceFeatures}
            getFieldDecorator={this.props.form.getFieldDecorator}
            propertyName="spaceFeatureId"
            required={true}
            selectedValue={this.state.model!.spaceFeatureId}
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

export const WrappedSpaceSpaceFeatureCreateComponent = Form.create({
  name: 'SpaceSpaceFeature Create',
})(SpaceSpaceFeatureCreateComponent);


/*<Codenesium>
    <Hash>7ad4a7b28e091f8964c9693bb976f083</Hash>
</Codenesium>*/