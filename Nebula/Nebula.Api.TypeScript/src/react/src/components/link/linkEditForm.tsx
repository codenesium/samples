import React, { Component, FormEvent } from 'react';
import axios, { AxiosError, AxiosResponse } from 'axios';
import { ActionResponse, CreateResponse } from '../../api/apiObjects';
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
import * as GlobalUtilities from '../../lib/globalUtilities';
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
  submitting: boolean;
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
    submitting: false,
  };

  componentDidMount() {
    this.setState({ ...this.state, loading: true });

    axios
      .get<Api.LinkClientResponseModel>(
        Constants.ApiEndpoint +
          ApiRoutes.Links +
          '/' +
          this.props.match.params.id,
        {
          headers: GlobalUtilities.defaultHeaders(),
        }
      )
      .then(response => {
        GlobalUtilities.logInfo(response);

        let mapper = new LinkMapper();

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
        let model = values as LinkViewModel;
        this.submit(model);
      } else {
        this.setState({ ...this.state, submitting: false, submitted: false });
      }
    });
  };

  submit = (model: LinkViewModel) => {
    let mapper = new LinkMapper();
    axios
      .put<CreateResponse<Api.LinkClientRequestModel>>(
        Constants.ApiEndpoint + ApiRoutes.Links + '/' + this.state.model!.id,
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
          <MachineSelectComponent
            apiRoute={Constants.ApiEndpoint + ApiRoutes.Machines}
            getFieldDecorator={this.props.form.getFieldDecorator}
            propertyName="assignedMachineId"
            required={false}
            selectedValue={this.state.model!.assignedMachineId}
          />

          <ChainSelectComponent
            apiRoute={Constants.ApiEndpoint + ApiRoutes.Chains}
            getFieldDecorator={this.props.form.getFieldDecorator}
            propertyName="chainId"
            required={true}
            selectedValue={this.state.model!.chainId}
          />

          <Form.Item>
            <label htmlFor="dateCompleted">Date Completed (optional)</label>
            <br />
            {getFieldDecorator('dateCompleted', {
              rules: [],
            })(
              <DatePicker
                format={'YYYY-MM-DD'}
                placeholder={'Date Completed'}
              />
            )}
          </Form.Item>

          <Form.Item>
            <label htmlFor="dateStarted">Date Started (optional)</label>
            <br />
            {getFieldDecorator('dateStarted', {
              rules: [],
            })(
              <DatePicker format={'YYYY-MM-DD'} placeholder={'Date Started'} />
            )}
          </Form.Item>

          <Form.Item>
            <label htmlFor="dynamicParameters">
              Dynamic Parameters (optional)
            </label>
            <br />
            {getFieldDecorator('dynamicParameters', {
              rules: [],
            })(<Input placeholder={'Dynamic Parameters'} />)}
          </Form.Item>

          <Form.Item>
            <label htmlFor="externalId">External (required)</label>
            <br />
            {getFieldDecorator('externalId', {
              rules: [{ required: true, message: 'Required' }],
            })(<Input placeholder={'External'} />)}
          </Form.Item>

          <LinkStatusSelectComponent
            apiRoute={Constants.ApiEndpoint + ApiRoutes.LinkStatus}
            getFieldDecorator={this.props.form.getFieldDecorator}
            propertyName="linkStatusId"
            required={true}
            selectedValue={this.state.model!.linkStatusId}
          />

          <Form.Item>
            <label htmlFor="name">Name (required)</label>
            <br />
            {getFieldDecorator('name', {
              rules: [
                { required: true, message: 'Required' },
                { max: 128, message: 'Exceeds max length of 128' },
              ],
            })(<Input placeholder={'Name'} />)}
          </Form.Item>

          <Form.Item>
            <label htmlFor="order">Order (required)</label>
            <br />
            {getFieldDecorator('order', {
              rules: [{ required: true, message: 'Required' }],
            })(<InputNumber placeholder={'Order'} />)}
          </Form.Item>

          <Form.Item>
            <label htmlFor="response">Response (optional)</label>
            <br />
            {getFieldDecorator('response', {
              rules: [],
            })(<Input placeholder={'Response'} />)}
          </Form.Item>

          <Form.Item>
            <label htmlFor="staticParameters">
              Static Parameters (optional)
            </label>
            <br />
            {getFieldDecorator('staticParameters', {
              rules: [],
            })(<Input placeholder={'Static Parameters'} />)}
          </Form.Item>

          <Form.Item>
            <label htmlFor="timeoutInSeconds">
              Timeout In Seconds (required)
            </label>
            <br />
            {getFieldDecorator('timeoutInSeconds', {
              rules: [{ required: true, message: 'Required' }],
            })(<InputNumber placeholder={'Timeout In Seconds'} />)}
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

export const WrappedLinkEditComponent = Form.create({ name: 'Link Edit' })(
  LinkEditComponent
);


/*<Codenesium>
    <Hash>ea4423b972372c4b619f27cc497197af</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/