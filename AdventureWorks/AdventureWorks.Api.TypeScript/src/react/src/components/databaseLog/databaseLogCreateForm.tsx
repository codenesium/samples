import React, { Component, FormEvent } from 'react';
import axios from 'axios';
import { CreateResponse } from '../../api/apiObjects';
import { Constants, ApiRoutes, ClientRoutes } from '../../constants';
import * as Api from '../../api/models';
import DatabaseLogMapper from './databaseLogMapper';
import DatabaseLogViewModel from './databaseLogViewModel';
import {
  Form,
  Input,
  Button,
  Switch,
  InputNumber,
  DatePicker,
  Spin,
  Alert,
} from 'antd';
import { WrappedFormUtils } from 'antd/es/form/Form';

interface DatabaseLogCreateComponentProps {
  form: WrappedFormUtils;
  history: any;
  match: any;
}

interface DatabaseLogCreateComponentState {
  model?: DatabaseLogViewModel;
  loading: boolean;
  loaded: boolean;
  errorOccurred: boolean;
  errorMessage: string;
  submitted: boolean;
}

class DatabaseLogCreateComponent extends React.Component<
  DatabaseLogCreateComponentProps,
  DatabaseLogCreateComponentState
> {
  state = {
    model: new DatabaseLogViewModel(),
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
        let model = values as DatabaseLogViewModel;
        console.log('Received values of form: ', model);
        this.submit(model);
      }
    });
  };

  submit = (model: DatabaseLogViewModel) => {
    let mapper = new DatabaseLogMapper();
    axios
      .post(
        Constants.ApiEndpoint + ApiRoutes.DatabaseLogs,
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
            Api.DatabaseLogClientRequestModel
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
            <label htmlFor="databaseUser">DatabaseUser</label>
            <br />
            {getFieldDecorator('databaseUser', {
              rules: [],
            })(
              <DatePicker
                format={'YYYY-MM-DD'}
                placeholder={'DatabaseUser'}
                id={'databaseUser'}
              />
            )}
          </Form.Item>

          <Form.Item>
            <label htmlFor="postTime">PostTime</label>
            <br />
            {getFieldDecorator('postTime', {
              rules: [],
            })(
              <DatePicker
                format={'YYYY-MM-DD'}
                placeholder={'PostTime'}
                id={'postTime'}
              />
            )}
          </Form.Item>

          <Form.Item>
            <label htmlFor="schema">Schema</label>
            <br />
            {getFieldDecorator('schema', {
              rules: [],
            })(
              <DatePicker
                format={'YYYY-MM-DD'}
                placeholder={'Schema'}
                id={'schema'}
              />
            )}
          </Form.Item>

          <Form.Item>
            <label htmlFor="tsql">TSQL</label>
            <br />
            {getFieldDecorator('tsql', {
              rules: [],
            })(
              <DatePicker
                format={'YYYY-MM-DD'}
                placeholder={'TSQL'}
                id={'tsql'}
              />
            )}
          </Form.Item>

          <Form.Item>
            <label htmlFor="xmlEvent">XmlEvent</label>
            <br />
            {getFieldDecorator('xmlEvent', {
              rules: [],
            })(
              <DatePicker
                format={'YYYY-MM-DD'}
                placeholder={'XmlEvent'}
                id={'xmlEvent'}
              />
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

export const WrappedDatabaseLogCreateComponent = Form.create({
  name: 'DatabaseLog Create',
})(DatabaseLogCreateComponent);


/*<Codenesium>
    <Hash>8633559378c5000d2c0d114205de0067</Hash>
</Codenesium>*/