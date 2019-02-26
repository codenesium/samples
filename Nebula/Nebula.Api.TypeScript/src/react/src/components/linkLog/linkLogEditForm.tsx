import React, { Component, FormEvent } from 'react';
import axios from 'axios';
import { ActionResponse, CreateResponse } from '../../api/apiObjects';
import { Constants, ApiRoutes, ClientRoutes } from '../../constants';
import * as Api from '../../api/models';
import LinkLogMapper from './linkLogMapper';
import LinkLogViewModel from './linkLogViewModel';
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
import { LinkSelectComponent } from '../shared/linkSelect';
interface LinkLogEditComponentProps {
  form: WrappedFormUtils;
  history: any;
  match: any;
}

interface LinkLogEditComponentState {
  model?: LinkLogViewModel;
  loading: boolean;
  loaded: boolean;
  errorOccurred: boolean;
  errorMessage: string;
  submitted: boolean;
}

class LinkLogEditComponent extends React.Component<
  LinkLogEditComponentProps,
  LinkLogEditComponentState
> {
  state = {
    model: new LinkLogViewModel(),
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
          ApiRoutes.LinkLogs +
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
          let response = resp.data as Api.LinkLogClientResponseModel;

          console.log(response);

          let mapper = new LinkLogMapper();

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
        let model = values as LinkLogViewModel;
        console.log('Received values of form: ', model);
        this.submit(model);
      }
    });
  };

  submit = (model: LinkLogViewModel) => {
    let mapper = new LinkLogMapper();
    axios
      .put(
        Constants.ApiEndpoint + ApiRoutes.LinkLogs + '/' + this.state.model!.id,
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
            Api.LinkLogClientRequestModel
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
          let errorResponse = error.response.data as ActionResponse;
          if (error.response.data) {
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
            <label htmlFor="dateEntered">DateEntered</label>
            <br />
            {getFieldDecorator('dateEntered', {
              rules: [{ required: true, message: 'Required' }],
            })(<Input placeholder={'DateEntered'} />)}
          </Form.Item>

          <Form.Item>
            <label htmlFor="linkId">LinkId</label>
            <br />
            {getFieldDecorator('linkId', {
              rules: [{ required: true, message: 'Required' }],
            })(<Input placeholder={'LinkId'} />)}
          </Form.Item>

          <Form.Item>
            <label htmlFor="log">Log</label>
            <br />
            {getFieldDecorator('log', {
              rules: [{ required: true, message: 'Required' }],
            })(<Input placeholder={'Log'} />)}
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

export const WrappedLinkLogEditComponent = Form.create({
  name: 'LinkLog Edit',
})(LinkLogEditComponent);


/*<Codenesium>
    <Hash>1167b0406dca9c96cf33b26f6e8e5d3e</Hash>
</Codenesium>*/