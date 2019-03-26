import React, { Component, FormEvent } from 'react';
import axios, { AxiosError, AxiosResponse } from 'axios';
import { ActionResponse, CreateResponse } from '../../api/apiObjects';
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
  TimePicker,
} from 'antd';
import { WrappedFormUtils } from 'antd/es/form/Form';
import * as GlobalUtilities from '../../lib/globalUtilities';
interface DocumentEditComponentProps {
  form: WrappedFormUtils;
  history: any;
  match: any;
}

interface DocumentEditComponentState {
  model?: DocumentViewModel;
  loading: boolean;
  loaded: boolean;
  errorOccurred: boolean;
  errorMessage: string;
  submitted: boolean;
  submitting: boolean;
}

class DocumentEditComponent extends React.Component<
  DocumentEditComponentProps,
  DocumentEditComponentState
> {
  state = {
    model: new DocumentViewModel(),
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
      .get<Api.DocumentClientResponseModel>(
        Constants.ApiEndpoint +
          ApiRoutes.Documents +
          '/' +
          this.props.match.params.id,
        {
          headers: GlobalUtilities.defaultHeaders(),
        }
      )
      .then(response => {
        GlobalUtilities.logInfo(response);

        let mapper = new DocumentMapper();

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
        let model = values as DocumentViewModel;
        this.submit(model);
      } else {
        this.setState({ ...this.state, submitting: false, submitted: false });
      }
    });
  };

  submit = (model: DocumentViewModel) => {
    let mapper = new DocumentMapper();
    axios
      .put<CreateResponse<Api.DocumentClientRequestModel>>(
        Constants.ApiEndpoint +
          ApiRoutes.Documents +
          '/' +
          this.state.model!.rowguid,
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
          <Form.Item>
            <label htmlFor="changeNumber">Change Number</label>
            <br />
            {getFieldDecorator('changeNumber', {
              rules: [{ required: true, message: 'Required' }],
            })(<InputNumber placeholder={'Change Number'} />)}
          </Form.Item>

          <Form.Item>
            <label htmlFor="document1">Document</label>
            <br />
            {getFieldDecorator('document1', {
              rules: [],
            })(<Input placeholder={'Document'} />)}
          </Form.Item>

          <Form.Item>
            <label htmlFor="documentLevel">Document Level</label>
            <br />
            {getFieldDecorator('documentLevel', {
              rules: [],
            })(<InputNumber placeholder={'Document Level'} />)}
          </Form.Item>

          <Form.Item>
            <label htmlFor="documentSummary">Document Summary</label>
            <br />
            {getFieldDecorator('documentSummary', {
              rules: [],
            })(<Input placeholder={'Document Summary'} />)}
          </Form.Item>

          <Form.Item>
            <label htmlFor="fileExtension">File Extension</label>
            <br />
            {getFieldDecorator('fileExtension', {
              rules: [
                { required: true, message: 'Required' },
                { max: 8, message: 'Exceeds max length of 8' },
              ],
            })(<Input placeholder={'File Extension'} />)}
          </Form.Item>

          <Form.Item>
            <label htmlFor="fileName">File Name</label>
            <br />
            {getFieldDecorator('fileName', {
              rules: [
                { required: true, message: 'Required' },
                { max: 400, message: 'Exceeds max length of 400' },
              ],
            })(<Input placeholder={'File Name'} />)}
          </Form.Item>

          <Form.Item>
            <label htmlFor="folderFlag">Folder Flag</label>
            <br />
            {getFieldDecorator('folderFlag', {
              rules: [],
              valuePropName: 'checked',
            })(<Switch />)}
          </Form.Item>

          <Form.Item>
            <label htmlFor="modifiedDate">Modified Date</label>
            <br />
            {getFieldDecorator('modifiedDate', {
              rules: [{ required: true, message: 'Required' }],
            })(
              <DatePicker format={'YYYY-MM-DD'} placeholder={'Modified Date'} />
            )}
          </Form.Item>

          <Form.Item>
            <label htmlFor="owner">Owner</label>
            <br />
            {getFieldDecorator('owner', {
              rules: [{ required: true, message: 'Required' }],
            })(<InputNumber placeholder={'Owner'} />)}
          </Form.Item>

          <Form.Item>
            <label htmlFor="revision">Revision</label>
            <br />
            {getFieldDecorator('revision', {
              rules: [
                { required: true, message: 'Required' },
                { max: 5, message: 'Exceeds max length of 5' },
              ],
            })(<Input placeholder={'Revision'} />)}
          </Form.Item>

          <Form.Item>
            <label htmlFor="status">Status</label>
            <br />
            {getFieldDecorator('status', {
              rules: [{ required: true, message: 'Required' }],
            })(<InputNumber placeholder={'Status'} />)}
          </Form.Item>

          <Form.Item>
            <label htmlFor="title">Title</label>
            <br />
            {getFieldDecorator('title', {
              rules: [
                { required: true, message: 'Required' },
                { max: 50, message: 'Exceeds max length of 50' },
              ],
            })(<Input placeholder={'Title'} />)}
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

export const WrappedDocumentEditComponent = Form.create({
  name: 'Document Edit',
})(DocumentEditComponent);


/*<Codenesium>
    <Hash>f21f6251248883d3c3eab45046bb1d33</Hash>
</Codenesium>*/