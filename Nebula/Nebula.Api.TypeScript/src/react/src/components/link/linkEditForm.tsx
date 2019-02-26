import React, { Component, FormEvent } from 'react';
import axios from 'axios';
import { CreateResponse } from '../../api/apiObjects';
import { Constants, ApiRoutes, ClientRoutes } from '../../constants';
import * as Api from '../../api/models';
import LinkMapper from './linkMapper';
import LinkViewModel from './linkViewModel';
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
import { MachineSelectComponent } from '../shared/machineSelect';
import { ChainSelectComponent } from '../shared/chainSelect';
import { LinkStatusSelectComponent } from '../shared/linkStatusSelect';
interface LinkEditComponentProps {
  form: WrappedFormUtils;
  history: any;
  match: any;
}

interface LinkEditComponentState {
  model?: LinkViewModel;
  loading: boolean;
  loaded: boolean;
  errorOccurred: boolean;
  errorMessage: string;
  submitted: boolean;
}

class LinkEditComponent extends React.Component<
  LinkEditComponentProps,
  LinkEditComponentState
> {
  state = {
    model: new LinkViewModel(),
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
          ApiRoutes.Links +
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
          let response = resp.data as Api.LinkClientResponseModel;

          console.log(response);

          let mapper = new LinkMapper();

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
        let model = values as LinkViewModel;
        console.log('Received values of form: ', model);
        this.submit(model);
      }
    });
  };

  submit = (model: LinkViewModel) => {
    let mapper = new LinkMapper();
    axios
      .put(
        Constants.ApiEndpoint + ApiRoutes.Links + '/' + this.state.model!.id,
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
            Api.LinkClientRequestModel
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
            <label htmlFor="assignedMachineId">AssignedMachineId</label>
            <br />
            {getFieldDecorator('assignedMachineId', {
              rules: [],
            })(<Input placeholder={'AssignedMachineId'} />)}
          </Form.Item>

          <Form.Item>
            <label htmlFor="chainId">ChainId</label>
            <br />
            {getFieldDecorator('chainId', {
              rules: [{ required: true, message: 'Required' }],
            })(<Input placeholder={'ChainId'} />)}
          </Form.Item>

          <Form.Item>
            <label htmlFor="dateCompleted">DateCompleted</label>
            <br />
            {getFieldDecorator('dateCompleted', {
              rules: [],
            })(<Input placeholder={'DateCompleted'} />)}
          </Form.Item>

          <Form.Item>
            <label htmlFor="dateStarted">DateStarted</label>
            <br />
            {getFieldDecorator('dateStarted', {
              rules: [],
            })(<Input placeholder={'DateStarted'} />)}
          </Form.Item>

          <Form.Item>
            <label htmlFor="dynamicParameter">DynamicParameter</label>
            <br />
            {getFieldDecorator('dynamicParameter', {
              rules: [],
            })(<Input placeholder={'DynamicParameter'} />)}
          </Form.Item>

          <Form.Item>
            <label htmlFor="externalId">ExternalId</label>
            <br />
            {getFieldDecorator('externalId', {
              rules: [{ required: true, message: 'Required' }],
            })(<Input placeholder={'ExternalId'} />)}
          </Form.Item>

          <Form.Item>
            <label htmlFor="linkStatusId">LinkStatusId</label>
            <br />
            {getFieldDecorator('linkStatusId', {
              rules: [{ required: true, message: 'Required' }],
            })(<Input placeholder={'LinkStatusId'} />)}
          </Form.Item>

          <Form.Item>
            <label htmlFor="name">Name</label>
            <br />
            {getFieldDecorator('name', {
              rules: [
                { required: true, message: 'Required' },
                { max: 128, message: 'Exceeds max length of 128' },
              ],
            })(<Input placeholder={'Name'} />)}
          </Form.Item>

          <Form.Item>
            <label htmlFor="order">Order</label>
            <br />
            {getFieldDecorator('order', {
              rules: [{ required: true, message: 'Required' }],
            })(<Input placeholder={'Order'} />)}
          </Form.Item>

          <Form.Item>
            <label htmlFor="response">Response</label>
            <br />
            {getFieldDecorator('response', {
              rules: [],
            })(<Input placeholder={'Response'} />)}
          </Form.Item>

          <Form.Item>
            <label htmlFor="staticParameter">StaticParameter</label>
            <br />
            {getFieldDecorator('staticParameter', {
              rules: [],
            })(<Input placeholder={'StaticParameter'} />)}
          </Form.Item>

          <Form.Item>
            <label htmlFor="timeoutInSecond">TimeoutInSecond</label>
            <br />
            {getFieldDecorator('timeoutInSecond', {
              rules: [{ required: true, message: 'Required' }],
            })(<Input placeholder={'TimeoutInSecond'} />)}
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

export const WrappedLinkEditComponent = Form.create({ name: 'Link Edit' })(
  LinkEditComponent
);


/*<Codenesium>
    <Hash>f80a4717fdf5d1cf9b6f75a3f320e7aa</Hash>
</Codenesium>*/