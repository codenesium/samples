import React, { Component, FormEvent } from 'react';
import axios from 'axios';
import { CreateResponse } from '../../api/apiObjects';
import { Constants, ApiRoutes, ClientRoutes } from '../../constants';
import * as Api from '../../api/models';
import DocumentMapper from './documentMapper';
import DocumentViewModel from './documentViewModel';
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

interface DocumentCreateComponentProps {
  form: WrappedFormUtils;
  history: any;
  match: any;
}

interface DocumentCreateComponentState {
  model?: DocumentViewModel;
  loading: boolean;
  loaded: boolean;
  errorOccurred: boolean;
  errorMessage: string;
  submitted: boolean;
}

class DocumentCreateComponent extends React.Component<
  DocumentCreateComponentProps,
  DocumentCreateComponentState
> {
  state = {
    model: new DocumentViewModel(),
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
        let model = values as DocumentViewModel;
        console.log('Received values of form: ', model);
        this.submit(model);
      }
    });
  };

  submit = (model: DocumentViewModel) => {
    let mapper = new DocumentMapper();
    axios
      .post(
        Constants.ApiEndpoint + ApiRoutes.Documents,
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
            Api.DocumentClientRequestModel
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
            <label htmlFor="changeNumber">ChangeNumber</label>
            <br />
            {getFieldDecorator('changeNumber', {
              rules: [],
            })(
              <DatePicker
                format={'YYYY-MM-DD'}
                placeholder={'ChangeNumber'}
                id={'changeNumber'}
              />
            )}
          </Form.Item>

          <Form.Item>
            <label htmlFor="document1">Document</label>
            <br />
            {getFieldDecorator('document1', {
              rules: [],
            })(
              <DatePicker
                format={'YYYY-MM-DD'}
                placeholder={'Document'}
                id={'document1'}
              />
            )}
          </Form.Item>

          <Form.Item>
            <label htmlFor="documentLevel">DocumentLevel</label>
            <br />
            {getFieldDecorator('documentLevel', {
              rules: [],
            })(
              <DatePicker
                format={'YYYY-MM-DD'}
                placeholder={'DocumentLevel'}
                id={'documentLevel'}
              />
            )}
          </Form.Item>

          <Form.Item>
            <label htmlFor="documentSummary">DocumentSummary</label>
            <br />
            {getFieldDecorator('documentSummary', {
              rules: [],
            })(
              <DatePicker
                format={'YYYY-MM-DD'}
                placeholder={'DocumentSummary'}
                id={'documentSummary'}
              />
            )}
          </Form.Item>

          <Form.Item>
            <label htmlFor="fileExtension">FileExtension</label>
            <br />
            {getFieldDecorator('fileExtension', {
              rules: [],
            })(
              <DatePicker
                format={'YYYY-MM-DD'}
                placeholder={'FileExtension'}
                id={'fileExtension'}
              />
            )}
          </Form.Item>

          <Form.Item>
            <label htmlFor="fileName">FileName</label>
            <br />
            {getFieldDecorator('fileName', {
              rules: [],
            })(
              <DatePicker
                format={'YYYY-MM-DD'}
                placeholder={'FileName'}
                id={'fileName'}
              />
            )}
          </Form.Item>

          <Form.Item>
            <label htmlFor="folderFlag">FolderFlag</label>
            <br />
            {getFieldDecorator('folderFlag', {
              rules: [],
            })(
              <DatePicker
                format={'YYYY-MM-DD'}
                placeholder={'FolderFlag'}
                id={'folderFlag'}
              />
            )}
          </Form.Item>

          <Form.Item>
            <label htmlFor="modifiedDate">ModifiedDate</label>
            <br />
            {getFieldDecorator('modifiedDate', {
              rules: [],
            })(
              <DatePicker
                format={'YYYY-MM-DD'}
                placeholder={'ModifiedDate'}
                id={'modifiedDate'}
              />
            )}
          </Form.Item>

          <Form.Item>
            <label htmlFor="owner">Owner</label>
            <br />
            {getFieldDecorator('owner', {
              rules: [],
            })(
              <DatePicker
                format={'YYYY-MM-DD'}
                placeholder={'Owner'}
                id={'owner'}
              />
            )}
          </Form.Item>

          <Form.Item>
            <label htmlFor="revision">Revision</label>
            <br />
            {getFieldDecorator('revision', {
              rules: [],
            })(
              <DatePicker
                format={'YYYY-MM-DD'}
                placeholder={'Revision'}
                id={'revision'}
              />
            )}
          </Form.Item>

          <Form.Item>
            <label htmlFor="status">Status</label>
            <br />
            {getFieldDecorator('status', {
              rules: [],
            })(
              <DatePicker
                format={'YYYY-MM-DD'}
                placeholder={'Status'}
                id={'status'}
              />
            )}
          </Form.Item>

          <Form.Item>
            <label htmlFor="title">Title</label>
            <br />
            {getFieldDecorator('title', {
              rules: [],
            })(
              <DatePicker
                format={'YYYY-MM-DD'}
                placeholder={'Title'}
                id={'title'}
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

export const WrappedDocumentCreateComponent = Form.create({
  name: 'Document Create',
})(DocumentCreateComponent);


/*<Codenesium>
    <Hash>559b2e8ee02d9783089e09d9c9cf456b</Hash>
</Codenesium>*/