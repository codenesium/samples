import React, { Component, FormEvent } from 'react';
import axios from 'axios';
import { CreateResponse } from '../../api/apiObjects';
import { Constants, ApiRoutes, ClientRoutes } from '../../constants';
import * as Api from '../../api/models';
import TagMapper from './tagMapper';
import TagViewModel from './tagViewModel';
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

interface TagCreateComponentProps {
  form: WrappedFormUtils;
  history: any;
  match: any;
}

interface TagCreateComponentState {
  model?: TagViewModel;
  loading: boolean;
  loaded: boolean;
  errorOccurred: boolean;
  errorMessage: string;
  submitted: boolean;
}

class TagCreateComponent extends React.Component<
  TagCreateComponentProps,
  TagCreateComponentState
> {
  state = {
    model: new TagViewModel(),
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
        let model = values as TagViewModel;
        console.log('Received values of form: ', model);
        this.submit(model);
      }
    });
  };

  submit = (model: TagViewModel) => {
    let mapper = new TagMapper();
    axios
      .post(
        Constants.ApiEndpoint + ApiRoutes.Tags,
        mapper.mapViewModelToApiRequest(model),
        {
          headers: {
            'Content-Type': 'application/json',
          },
        }
      )
      .then(
        resp => {
          let response = resp.data as CreateResponse<Api.TagClientRequestModel>;
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
            <label htmlFor="count">Count</label>
            <br />
            {getFieldDecorator('count', {
              rules: [],
            })(<Input placeholder={'Count'} id={'count'} />)}
          </Form.Item>

          <Form.Item>
            <label htmlFor="excerptPostId">ExcerptPostId</label>
            <br />
            {getFieldDecorator('excerptPostId', {
              rules: [],
            })(<Input placeholder={'ExcerptPostId'} id={'excerptPostId'} />)}
          </Form.Item>

          <Form.Item>
            <label htmlFor="tagName">TagName</label>
            <br />
            {getFieldDecorator('tagName', {
              rules: [],
            })(<Input placeholder={'TagName'} id={'tagName'} />)}
          </Form.Item>

          <Form.Item>
            <label htmlFor="wikiPostId">WikiPostId</label>
            <br />
            {getFieldDecorator('wikiPostId', {
              rules: [],
            })(<Input placeholder={'WikiPostId'} id={'wikiPostId'} />)}
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

export const WrappedTagCreateComponent = Form.create({ name: 'Tag Create' })(
  TagCreateComponent
);


/*<Codenesium>
    <Hash>9907d4aeb94b0295b45e53c4397ad027</Hash>
</Codenesium>*/