import React, { Component, FormEvent } from 'react';
import axios from 'axios';
import { CreateResponse } from '../../api/apiObjects';
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
  };

  handleSubmit = (e: FormEvent<HTMLFormElement>) => {
    e.preventDefault();
    this.props.form.validateFields((err: any, values: any) => {
      if (!err) {
        let model = values as ColumnSameAsFKTableViewModel;
        console.log('Received values of form: ', model);
        this.submit(model);
      }
    });
  };

  submit = (model: ColumnSameAsFKTableViewModel) => {
    let mapper = new ColumnSameAsFKTableMapper();
    axios
      .post(
        Constants.ApiEndpoint + ApiRoutes.ColumnSameAsFKTables,
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
            Api.ColumnSameAsFKTableClientRequestModel
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
            <label htmlFor="person">Person</label>
            <br />
            {getFieldDecorator('person', {
              rules: [{ required: true, message: 'Required' }],
            })(<Input placeholder={'Person'} />)}
          </Form.Item>

          <Form.Item>
            <label htmlFor="personId">PersonId</label>
            <br />
            {getFieldDecorator('personId', {
              rules: [{ required: true, message: 'Required' }],
            })(<Input placeholder={'PersonId'} />)}
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

export const WrappedColumnSameAsFKTableCreateComponent = Form.create({
  name: 'ColumnSameAsFKTable Create',
})(ColumnSameAsFKTableCreateComponent);


/*<Codenesium>
    <Hash>12dcc72d41b29e3f7b40f6bf5ad00784</Hash>
</Codenesium>*/