import React, { Component, FormEvent } from 'react';
import axios from 'axios';
import { ActionResponse, CreateResponse } from '../../api/apiObjects';
import { Constants, ApiRoutes, ClientRoutes } from '../../constants';
import * as Api from '../../api/models';
import SelfReferenceMapper from './selfReferenceMapper';
import SelfReferenceViewModel from './selfReferenceViewModel';
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

interface SelfReferenceCreateComponentProps {
  form: WrappedFormUtils;
  history: any;
  match: any;
}

interface SelfReferenceCreateComponentState {
  model?: SelfReferenceViewModel;
  loading: boolean;
  loaded: boolean;
  errorOccurred: boolean;
  errorMessage: string;
  submitted: boolean;
}

class SelfReferenceCreateComponent extends React.Component<
  SelfReferenceCreateComponentProps,
  SelfReferenceCreateComponentState
> {
  state = {
    model: new SelfReferenceViewModel(),
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
        let model = values as SelfReferenceViewModel;
        console.log('Received values of form: ', model);
        this.submit(model);
      }
    });
  };

  submit = (model: SelfReferenceViewModel) => {
    let mapper = new SelfReferenceMapper();
    axios
      .post(
        Constants.ApiEndpoint + ApiRoutes.SelfReferences,
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
            Api.SelfReferenceClientRequestModel
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
            <label htmlFor="selfReferenceId">SelfReferenceId</label>
            <br />
            {getFieldDecorator('selfReferenceId', {
              rules: [],
            })(<Input placeholder={'SelfReferenceId'} />)}
          </Form.Item>

          <Form.Item>
            <label htmlFor="selfReferenceId2">SelfReferenceId2</label>
            <br />
            {getFieldDecorator('selfReferenceId2', {
              rules: [],
            })(<Input placeholder={'SelfReferenceId2'} />)}
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

export const WrappedSelfReferenceCreateComponent = Form.create({
  name: 'SelfReference Create',
})(SelfReferenceCreateComponent);


/*<Codenesium>
    <Hash>c75d27068c8daf5fcfd6d3d5559d6ac1</Hash>
</Codenesium>*/