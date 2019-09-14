import React, { Component, FormEvent } from 'react';
import axios, { AxiosError, AxiosResponse } from 'axios';
import { ActionResponse, CreateResponse } from '../../api/apiObjects';
import { Constants, ApiRoutes, ClientRoutes } from '../../constants';
import * as Api from '../../api/models';
import ColumnSameAsFKTableMapper from './columnSameAsFKTableMapper';
import ColumnSameAsFKTableViewModel from './columnSameAsFKTableViewModel';
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

interface ColumnSameAsFKTableCreateComponentProps {
  form: WrappedFormUtils;
  history: any;
  match: any;
}

interface ColumnSameAsFKTableCreateComponentState {
  model?: ColumnSameAsFKTableViewModel;
  loading: boolean;
  loaded: boolean;
  errorOccurred: boolean;
  errorMessage: string;
  submitted: boolean;
  submitting: boolean;
}

class ColumnSameAsFKTableCreateComponent extends React.Component<
  ColumnSameAsFKTableCreateComponentProps,
  ColumnSameAsFKTableCreateComponentState
> {
  state = {
    model: new ColumnSameAsFKTableViewModel(),
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
        let model = values as ColumnSameAsFKTableViewModel;
        this.submit(model);
      } else {
        this.setState({ ...this.state, submitting: false, submitted: false });
      }
    });
  };

  submit = (model: ColumnSameAsFKTableViewModel) => {
    let mapper = new ColumnSameAsFKTableMapper();
    axios
      .post<CreateResponse<Api.ColumnSameAsFKTableClientRequestModel>>(
        Constants.ApiEndpoint + ApiRoutes.ColumnSameAsFKTables,
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
          <PersonSelectComponent
            apiRoute={Constants.ApiEndpoint + ApiRoutes.People}
            getFieldDecorator={this.props.form.getFieldDecorator}
            propertyName="person"
            required={true}
            selectedValue={this.state.model!.person}
          />

          <PersonSelectComponent
            apiRoute={Constants.ApiEndpoint + ApiRoutes.People}
            getFieldDecorator={this.props.form.getFieldDecorator}
            propertyName="personId"
            required={true}
            selectedValue={this.state.model!.personId}
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

export const WrappedColumnSameAsFKTableCreateComponent = Form.create({
  name: 'ColumnSameAsFKTable Create',
})(ColumnSameAsFKTableCreateComponent);


/*<Codenesium>
    <Hash>44210ca0c338fe9a04dec2626e84eb23</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/