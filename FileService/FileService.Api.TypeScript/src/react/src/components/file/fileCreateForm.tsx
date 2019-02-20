import React, { Component, FormEvent } from 'react';
import axios from 'axios';
import { CreateResponse } from '../../api/apiObjects';
import { LoadingForm } from '../../lib/components/loadingForm';
import { ErrorForm } from '../../lib/components/errorForm';
import { Constants, ApiRoutes, ClientRoutes } from '../../constants';
import * as Api from '../../api/models';
import FileMapper from './fileMapper';
import FileViewModel from './fileViewModel';
import { Form, Input, Button, Checkbox, InputNumber, DatePicker } from 'antd';
import { WrappedFormUtils } from 'antd/es/form/Form';
import { Alert } from 'antd';

interface FileCreateComponentProps {
  form: WrappedFormUtils;
  history: any;
  match: any;
}

interface FileCreateComponentState {
  model?: FileViewModel;
  loading: boolean;
  loaded: boolean;
  errorOccurred: boolean;
  errorMessage: string;
  submitted: boolean;
}

class FileCreateComponent extends React.Component<
  FileCreateComponentProps,
  FileCreateComponentState
> {
  state = {
    model: new FileViewModel(),
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
        let model = values as FileViewModel;
        console.log('Received values of form: ', model);
        this.submit(model);
      }
    });
  };

  submit = (model: FileViewModel) => {
    let mapper = new FileMapper();
    axios
      .post(
        Constants.ApiEndpoint + ApiRoutes.Files,
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
            Api.FileClientRequestModel
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
      return <LoadingForm />;
    } else if (this.state.loaded) {
      return (
        <Form onSubmit={this.handleSubmit}>
          <Form.Item>
            <label htmlFor="bucketId">BucketId</label>
            <br />
            {getFieldDecorator('bucketId', {
              rules: [],
            })(<Input placeholder={'BucketId'} id={'bucketId'} />)}
          </Form.Item>

          <Form.Item>
            <label htmlFor="dateCreated">DateCreated</label>
            <br />
            {getFieldDecorator('dateCreated', {
              rules: [],
            })(<DatePicker placeholder={'DateCreated'} id={'dateCreated'} />)}
          </Form.Item>

          <Form.Item>
            <label htmlFor="description">Description</label>
            <br />
            {getFieldDecorator('description', {
              rules: [],
            })(<Input placeholder={'Description'} id={'description'} />)}
          </Form.Item>

          <Form.Item>
            <label htmlFor="expiration">Expiration</label>
            <br />
            {getFieldDecorator('expiration', {
              rules: [],
            })(<Input placeholder={'Expiration'} id={'expiration'} />)}
          </Form.Item>

          <Form.Item>
            <label htmlFor="extension">Extension</label>
            <br />
            {getFieldDecorator('extension', {
              rules: [],
            })(<Input placeholder={'Extension'} id={'extension'} />)}
          </Form.Item>

          <Form.Item>
            <label htmlFor="externalId">ExternalId</label>
            <br />
            {getFieldDecorator('externalId', {
              rules: [],
            })(<Input placeholder={'ExternalId'} id={'externalId'} />)}
          </Form.Item>

          <Form.Item>
            <label htmlFor="fileSizeInByte">FileSizeInByte</label>
            <br />
            {getFieldDecorator('fileSizeInByte', {
              rules: [],
            })(
              <InputNumber
                placeholder={'FileSizeInByte'}
                id={'fileSizeInByte'}
              />
            )}
          </Form.Item>

          <Form.Item>
            <label htmlFor="fileTypeId">FileTypeId</label>
            <br />
            {getFieldDecorator('fileTypeId', {
              rules: [],
            })(<Input placeholder={'FileTypeId'} id={'fileTypeId'} />)}
          </Form.Item>

          <Form.Item>
            <label htmlFor="location">Location</label>
            <br />
            {getFieldDecorator('location', {
              rules: [],
            })(<Input placeholder={'Location'} id={'location'} />)}
          </Form.Item>

          <Form.Item>
            <label htmlFor="privateKey">PrivateKey</label>
            <br />
            {getFieldDecorator('privateKey', {
              rules: [],
            })(<Input placeholder={'PrivateKey'} id={'privateKey'} />)}
          </Form.Item>

          <Form.Item>
            <label htmlFor="publicKey">PublicKey</label>
            <br />
            {getFieldDecorator('publicKey', {
              rules: [],
            })(<Input placeholder={'PublicKey'} id={'publicKey'} />)}
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

export const WrappedFileCreateComponent = Form.create({ name: 'File Create' })(
  FileCreateComponent
);


/*<Codenesium>
    <Hash>32cdf41f9d2caf47b4b28d6ac71ab723</Hash>
</Codenesium>*/