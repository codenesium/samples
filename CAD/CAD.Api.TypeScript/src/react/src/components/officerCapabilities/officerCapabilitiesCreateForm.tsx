import React, { Component, FormEvent } from 'react';
import axios from 'axios';
import { ActionResponse, CreateResponse } from '../../api/apiObjects';
import { Constants, ApiRoutes, ClientRoutes } from '../../constants';
import * as Api from '../../api/models';
import OfficerCapabilitiesMapper from './officerCapabilitiesMapper';
import OfficerCapabilitiesViewModel from './officerCapabilitiesViewModel';
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
import { ToLowerCaseFirstLetter } from '../../lib/stringUtilities';
import { OfficerCapabilitySelectComponent } from '../shared/officerCapabilitySelect';
import { OfficerSelectComponent } from '../shared/officerSelect';

interface OfficerCapabilitiesCreateComponentProps {
  form: WrappedFormUtils;
  history: any;
  match: any;
}

interface OfficerCapabilitiesCreateComponentState {
  model?: OfficerCapabilitiesViewModel;
  loading: boolean;
  loaded: boolean;
  errorOccurred: boolean;
  errorMessage: string;
  submitted: boolean;
}

class OfficerCapabilitiesCreateComponent extends React.Component<
  OfficerCapabilitiesCreateComponentProps,
  OfficerCapabilitiesCreateComponentState
> {
  state = {
    model: new OfficerCapabilitiesViewModel(),
    loading: false,
    loaded: true,
    errorOccurred: false,
    errorMessage: '',
    submitted: false,
  };

  handleSubmit = (e: FormEvent<HTMLFormElement>) => {
    e.preventDefault();
    this.props.form.validateFields((err: any, values: any) => {
      if (!err) {
        let model = values as OfficerCapabilitiesViewModel;
        console.log('Received values of form: ', model);
        this.submit(model);
      }
    });
  };

  submit = (model: OfficerCapabilitiesViewModel) => {
    let mapper = new OfficerCapabilitiesMapper();
    axios
      .post(
        Constants.ApiEndpoint + ApiRoutes.OfficerCapabilities,
        mapper.mapViewModelToApiRequest(model),
        {
          headers: {
            'Content-Type': 'application/json',
          },
        }
      )
      .then(
        resp => {
          let response = resp.data as CreateResponse<
            Api.OfficerCapabilitiesClientRequestModel
          >;
          this.setState({
            ...this.state,
            submitted: true,
            model: mapper.mapApiResponseToViewModel(response.record!),
            errorOccurred: false,
            errorMessage: '',
          });
          console.log(response);
        },
        error => {
          console.log(error);
          if (error.response.data) {
            let errorResponse = error.response.data as ActionResponse;

            errorResponse.validationErrors.forEach(x => {
              this.props.form.setFields({
                [ToLowerCaseFirstLetter(x.propertyName)]: {
                  value: this.props.form.getFieldValue(
                    ToLowerCaseFirstLetter(x.propertyName)
                  ),
                  errors: [new Error(x.errorMessage)],
                },
              });
            });
          }
          this.setState({
            ...this.state,
            submitted: true,
            errorOccurred: true,
            errorMessage: 'Error from API',
          });
        }
      );
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
            <label htmlFor="officerId">officerId</label>
            <br />
            {getFieldDecorator('officerId', {
              rules: [{ required: true, message: 'Required' }],
            })(<Input placeholder={'officerId'} />)}
          </Form.Item>

          <Form.Item>
            <Button type="primary" htmlType="submit">
              Submit
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

export const WrappedOfficerCapabilitiesCreateComponent = Form.create({
  name: 'OfficerCapabilities Create',
})(OfficerCapabilitiesCreateComponent);


/*<Codenesium>
    <Hash>6b5e6cd956973b4a8e2ff7c83771b203</Hash>
</Codenesium>*/