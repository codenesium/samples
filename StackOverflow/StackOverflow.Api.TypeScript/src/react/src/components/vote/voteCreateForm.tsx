import React, { Component, FormEvent } from 'react';
import axios from 'axios';
import { CreateResponse } from '../../api/apiObjects';
import { Constants, ApiRoutes, ClientRoutes } from '../../constants';
import * as Api from '../../api/models';
import VoteMapper from './voteMapper';
import VoteViewModel from './voteViewModel';
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

interface VoteCreateComponentProps {
  form: WrappedFormUtils;
  history: any;
  match: any;
}

interface VoteCreateComponentState {
  model?: VoteViewModel;
  loading: boolean;
  loaded: boolean;
  errorOccurred: boolean;
  errorMessage: string;
  submitted: boolean;
}

class VoteCreateComponent extends React.Component<
  VoteCreateComponentProps,
  VoteCreateComponentState
> {
  state = {
    model: new VoteViewModel(),
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
        let model = values as VoteViewModel;
        console.log('Received values of form: ', model);
        this.submit(model);
      }
    });
  };

  submit = (model: VoteViewModel) => {
    let mapper = new VoteMapper();
    axios
      .post(
        Constants.ApiEndpoint + ApiRoutes.Votes,
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
            Api.VoteClientRequestModel
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
            <label htmlFor="bountyAmount">BountyAmount</label>
            <br />
            {getFieldDecorator('bountyAmount', {
              rules: [],
            })(<Input placeholder={'BountyAmount'} />)}
          </Form.Item>

          <Form.Item>
            <label htmlFor="creationDate">CreationDate</label>
            <br />
            {getFieldDecorator('creationDate', {
              rules: [{ required: true, message: 'Required' }],
            })(<Input placeholder={'CreationDate'} />)}
          </Form.Item>

          <Form.Item>
            <label htmlFor="postId">PostId</label>
            <br />
            {getFieldDecorator('postId', {
              rules: [{ required: true, message: 'Required' }],
            })(<Input placeholder={'PostId'} />)}
          </Form.Item>

          <Form.Item>
            <label htmlFor="userId">UserId</label>
            <br />
            {getFieldDecorator('userId', {
              rules: [],
            })(<Input placeholder={'UserId'} />)}
          </Form.Item>

          <Form.Item>
            <label htmlFor="voteTypeId">VoteTypeId</label>
            <br />
            {getFieldDecorator('voteTypeId', {
              rules: [{ required: true, message: 'Required' }],
            })(<Input placeholder={'VoteTypeId'} />)}
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

export const WrappedVoteCreateComponent = Form.create({ name: 'Vote Create' })(
  VoteCreateComponent
);


/*<Codenesium>
    <Hash>935fda91a3bb8e070a44c119dba168c8</Hash>
</Codenesium>*/