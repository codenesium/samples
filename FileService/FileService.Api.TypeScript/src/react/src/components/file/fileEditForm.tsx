import React, { Component, FormEvent } from 'react';
import axios, { AxiosError, AxiosResponse } from 'axios';
import { ActionResponse, CreateResponse } from '../../api/apiObjects';
import { Constants, ApiRoutes, ClientRoutes } from '../../constants';
import * as Api from '../../api/models';
import FileMapper from './fileMapper';
import FileViewModel from './fileViewModel';
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
import * as GlobalUtilities from '../../lib/globalUtilities';
import { BucketSelectComponent } from '../shared/bucketSelect';
import { FileTypeSelectComponent } from '../shared/fileTypeSelect';
interface FileEditComponentProps {
  form: WrappedFormUtils;
  history: any;
  match: any;
}

interface FileEditComponentState {
  model?: FileViewModel;
  loading: boolean;
  loaded: boolean;
  errorOccurred: boolean;
  errorMessage: string;
  submitted: boolean;
  submitting: boolean;
}

class FileEditComponent extends React.Component<
  FileEditComponentProps,
  FileEditComponentState
> {
  state = {
    model: new FileViewModel(),
    loading: false,
    loaded: true,
    errorOccurred: false,
    errorMessage: '',
    submitted: false,
    submitting: false,
  };

  componentDidMount() {
    this.setState({ ...this.state, loading: true });

    axios
      .get<Api.FileClientResponseModel>(
        Constants.ApiEndpoint +
          ApiRoutes.Files +
          '/' +
          this.props.match.params.id,
        {
          headers: GlobalUtilities.defaultHeaders(),
        }
      )
      .then(response => {
        GlobalUtilities.logInfo(response);

        let mapper = new FileMapper();

        this.setState({
          model: mapper.mapApiResponseToViewModel(response.data),
          loading: false,
          loaded: true,
          errorOccurred: false,
          errorMessage: '',
        });

        this.props.form.setFieldsValue(
          mapper.mapApiResponseToViewModel(response.data)
        );
      })
      .catch((error: AxiosError) => {
        GlobalUtilities.logError(error);

        if (error.response && error.response.status == 422) {
          this.setState({
            ...this.state,
            submitted: true,
            submitting: false,
            errorOccurred: false,
            errorMessage: '',
          });
        } else {
          this.setState({
            ...this.state,
            submitted: true,
            submitting: false,
            errorOccurred: true,
            errorMessage: 'Error Occurred',
          });
        }
      });
  }

  handleSubmit = (e: FormEvent<HTMLFormElement>) => {
    e.preventDefault();
    this.setState({ ...this.state, submitting: true, submitted: false });
    this.props.form.validateFields((err: any, values: any) => {
      if (!err) {
        let model = values as FileViewModel;
        this.submit(model);
      } else {
        this.setState({ ...this.state, submitting: false, submitted: false });
      }
    });
  };

  submit = (model: FileViewModel) => {
    let mapper = new FileMapper();
    axios
      .put<CreateResponse<Api.FileClientRequestModel>>(
        Constants.ApiEndpoint + ApiRoutes.Files + '/' + this.state.model!.id,
        mapper.mapViewModelToApiRequest(model),
        {
          headers: GlobalUtilities.defaultHeaders(),
        }
      )
      .then(response => {
        GlobalUtilities.logInfo(response);
        this.setState({
          ...this.state,
          submitted: true,
          submitting: false,
          model: mapper.mapApiResponseToViewModel(response.data.record!),
          errorOccurred: false,
          errorMessage: '',
        });
      })
      .catch((error: AxiosError) => {
        GlobalUtilities.logError(error);

        if (error.response && error.response.status == 422) {
          let errorResponse = error.response.data as ActionResponse;
          errorResponse.validationErrors.forEach(x => {
            this.props.form.setFields({
              [GlobalUtilities.toLowerCaseFirstLetter(x.propertyName)]: {
                value: this.props.form.getFieldValue(
                  GlobalUtilities.toLowerCaseFirstLetter(x.propertyName)
                ),
                errors: [new Error(x.errorMessage)],
              },
            });
          });
          this.setState({
            ...this.state,
            submitted: true,
            submitting: false,
            errorOccurred: false,
            errorMessage: '',
          });
        } else {
          this.setState({
            ...this.state,
            submitted: true,
            submitting: false,
            errorOccurred: true,
            errorMessage: 'Error Occurred',
          });
        }
      });
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
          <BucketSelectComponent
            apiRoute={Constants.ApiEndpoint + ApiRoutes.Buckets}
            getFieldDecorator={this.props.form.getFieldDecorator}
            propertyName="bucketId"
            required={false}
            selectedValue={this.state.model!.bucketId}
          />

          <Form.Item>
            <label htmlFor="dateCreated">DateCreated</label>
            <br />
            {getFieldDecorator('dateCreated', {
              rules: [{ required: true, message: 'Required' }],
            })(
              <DatePicker format={'YYYY-MM-DD'} placeholder={'DateCreated'} />
            )}
          </Form.Item>

          <Form.Item>
            <label htmlFor="description">Description</label>
            <br />
            {getFieldDecorator('description', {
              rules: [{ max: 255, message: 'Exceeds max length of 255' }],
            })(<Input placeholder={'Description'} />)}
          </Form.Item>

          <Form.Item>
            <label htmlFor="expiration">Expiration</label>
            <br />
            {getFieldDecorator('expiration', {
              rules: [{ required: true, message: 'Required' }],
            })(<DatePicker format={'YYYY-MM-DD'} placeholder={'Expiration'} />)}
          </Form.Item>

          <Form.Item>
            <label htmlFor="extension">Extension</label>
            <br />
            {getFieldDecorator('extension', {
              rules: [
                { required: true, message: 'Required' },
                { max: 32, message: 'Exceeds max length of 32' },
              ],
            })(<Input placeholder={'Extension'} />)}
          </Form.Item>

          <Form.Item>
            <label htmlFor="externalId">ExternalId</label>
            <br />
            {getFieldDecorator('externalId', {
              rules: [{ required: true, message: 'Required' }],
            })(<Input placeholder={'ExternalId'} />)}
          </Form.Item>

          <Form.Item>
            <label htmlFor="fileSizeInByte">FileSizeInByte</label>
            <br />
            {getFieldDecorator('fileSizeInByte', {
              rules: [{ required: true, message: 'Required' }],
            })(<InputNumber placeholder={'FileSizeInByte'} />)}
          </Form.Item>

          <FileTypeSelectComponent
            apiRoute={Constants.ApiEndpoint + ApiRoutes.FileTypes}
            getFieldDecorator={this.props.form.getFieldDecorator}
            propertyName="fileTypeId"
            required={true}
            selectedValue={this.state.model!.fileTypeId}
          />

          <Form.Item>
            <label htmlFor="location">Location</label>
            <br />
            {getFieldDecorator('location', {
              rules: [
                { required: true, message: 'Required' },
                { max: 255, message: 'Exceeds max length of 255' },
              ],
            })(<Input placeholder={'Location'} />)}
          </Form.Item>

          <Form.Item>
            <label htmlFor="privateKey">PrivateKey</label>
            <br />
            {getFieldDecorator('privateKey', {
              rules: [
                { required: true, message: 'Required' },
                { max: 64, message: 'Exceeds max length of 64' },
              ],
            })(<Input placeholder={'PrivateKey'} />)}
          </Form.Item>

          <Form.Item>
            <label htmlFor="publicKey">PublicKey</label>
            <br />
            {getFieldDecorator('publicKey', {
              rules: [
                { required: true, message: 'Required' },
                { max: 64, message: 'Exceeds max length of 64' },
              ],
            })(<Input placeholder={'PublicKey'} />)}
          </Form.Item>

          <Form.Item>
            <Button
              type="primary"
              htmlType="submit"
              loading={this.state.submitting}
            >
              {this.state.submitting ? 'Submitting...' : 'Submit'}
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

export const WrappedFileEditComponent = Form.create({ name: 'File Edit' })(
  FileEditComponent
);


/*<Codenesium>
    <Hash>4528198efc08b4d15dbfe2f080e96fbb</Hash>
</Codenesium>*/