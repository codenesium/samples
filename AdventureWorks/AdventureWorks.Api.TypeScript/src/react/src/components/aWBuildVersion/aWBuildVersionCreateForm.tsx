import React, { Component, FormEvent } from 'react';
import axios from 'axios';
import { CreateResponse } from '../../api/apiObjects';
import { Constants, ApiRoutes, ClientRoutes } from '../../constants';
import * as Api from '../../api/models';
import AWBuildVersionMapper from './aWBuildVersionMapper';
import AWBuildVersionViewModel from './aWBuildVersionViewModel';
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

interface AWBuildVersionCreateComponentProps {
  form: WrappedFormUtils;
  history: any;
  match: any;
}

interface AWBuildVersionCreateComponentState {
  model?: AWBuildVersionViewModel;
  loading: boolean;
  loaded: boolean;
  errorOccurred: boolean;
  errorMessage: string;
  submitted: boolean;
}

class AWBuildVersionCreateComponent extends React.Component<
  AWBuildVersionCreateComponentProps,
  AWBuildVersionCreateComponentState
> {
  state = {
    model: new AWBuildVersionViewModel(),
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
        let model = values as AWBuildVersionViewModel;
        console.log('Received values of form: ', model);
        this.submit(model);
      }
    });
  };

  submit = (model: AWBuildVersionViewModel) => {
    let mapper = new AWBuildVersionMapper();
    axios
      .post(
        Constants.ApiEndpoint + ApiRoutes.AWBuildVersions,
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
            Api.AWBuildVersionClientRequestModel
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
            <label htmlFor="database_Version">Database Version</label>
            <br />
            {getFieldDecorator('database_Version', {
              rules: [
                { required: true, message: 'Required' },
                { whitespace: true, message: 'Required' },
                { max: 25, message: 'Exceeds max length of 25' },
              ],
            })(
              <DatePicker
                format={'YYYY-MM-DD'}
                placeholder={'Database Version'}
              />
            )}
          </Form.Item>

          <Form.Item>
            <label htmlFor="modifiedDate">ModifiedDate</label>
            <br />
            {getFieldDecorator('modifiedDate', {
              rules: [
                { required: true, message: 'Required' },
                { whitespace: true, message: 'Required' },
              ],
            })(
              <DatePicker format={'YYYY-MM-DD'} placeholder={'ModifiedDate'} />
            )}
          </Form.Item>

          <Form.Item>
            <label htmlFor="versionDate">VersionDate</label>
            <br />
            {getFieldDecorator('versionDate', {
              rules: [
                { required: true, message: 'Required' },
                { whitespace: true, message: 'Required' },
              ],
            })(
              <DatePicker format={'YYYY-MM-DD'} placeholder={'VersionDate'} />
            )}
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

export const WrappedAWBuildVersionCreateComponent = Form.create({
  name: 'AWBuildVersion Create',
})(AWBuildVersionCreateComponent);


/*<Codenesium>
    <Hash>8b2eaee3c12c69e520f864a3bb1107f0</Hash>
</Codenesium>*/