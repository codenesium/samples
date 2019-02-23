import React, { Component, FormEvent } from 'react';
import axios from 'axios';
import { CreateResponse } from '../../api/apiObjects';
import { Constants, ApiRoutes, ClientRoutes } from '../../constants';
import * as Api from '../../api/models';
import OfficerRefCapabilityMapper from './officerRefCapabilityMapper';
import OfficerRefCapabilityViewModel from './officerRefCapabilityViewModel';
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

interface OfficerRefCapabilityEditComponentProps {
  form: WrappedFormUtils;
  history: any;
  match: any;
}

interface OfficerRefCapabilityEditComponentState {
  model?: OfficerRefCapabilityViewModel;
  loading: boolean;
  loaded: boolean;
  errorOccurred: boolean;
  errorMessage: string;
  submitted: boolean;
}

class OfficerRefCapabilityEditComponent extends React.Component<
  OfficerRefCapabilityEditComponentProps,
  OfficerRefCapabilityEditComponentState
> {
  state = {
    model: new OfficerRefCapabilityViewModel(),
    loading: false,
    loaded: true,
    errorOccurred: false,
    errorMessage: '',
    submitted: false,
  };

  componentDidMount() {
    this.setState({ ...this.state, loading: true });

    axios
      .get(
        Constants.ApiEndpoint +
          ApiRoutes.OfficerRefCapabilities +
          '/' +
          this.props.match.params.id,
        {
          headers: {
            'Content-Type': 'application/json',
          },
        }
      )
      .then(
        resp => {
          let response = resp.data as Api.OfficerRefCapabilityClientResponseModel;

          console.log(response);

          let mapper = new OfficerRefCapabilityMapper();

          this.setState({
            model: mapper.mapApiResponseToViewModel(response),
            loading: false,
            loaded: true,
            errorOccurred: false,
            errorMessage: '',
          });

          this.props.form.setFieldsValue(
            mapper.mapApiResponseToViewModel(response)
          );
        },
        error => {
          console.log(error);
          this.setState({
            model: undefined,
            loading: false,
            loaded: false,
            errorOccurred: true,
            errorMessage: 'Error from API',
          });
        }
      );
  }

  handleSubmit = (e: FormEvent<HTMLFormElement>) => {
    e.preventDefault();
    this.props.form.validateFields((err: any, values: any) => {
      if (!err) {
        let model = values as OfficerRefCapabilityViewModel;
        console.log('Received values of form: ', model);
        this.submit(model);
      }
    });
  };

  submit = (model: OfficerRefCapabilityViewModel) => {
    let mapper = new OfficerRefCapabilityMapper();
    axios
      .put(
        Constants.ApiEndpoint +
          ApiRoutes.OfficerRefCapabilities +
          '/' +
          this.state.model!.id,
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
            Api.OfficerRefCapabilityClientRequestModel
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
            <label htmlFor="capabilityId">capabilityId</label>
            <br />
            {getFieldDecorator('capabilityId', {
              rules: [{ required: true, message: 'Required' }],
            })(<Input placeholder={'capabilityId'} />)}
          </Form.Item>

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

export const WrappedOfficerRefCapabilityEditComponent = Form.create({
  name: 'OfficerRefCapability Edit',
})(OfficerRefCapabilityEditComponent);


/*<Codenesium>
    <Hash>d94f3a1db70e3954ce444cad8f3fccf2</Hash>
</Codenesium>*/