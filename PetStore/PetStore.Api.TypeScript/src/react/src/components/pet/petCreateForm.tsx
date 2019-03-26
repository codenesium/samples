import React, { Component, FormEvent } from 'react';
import axios, { AxiosError, AxiosResponse } from 'axios';
import { ActionResponse, CreateResponse } from '../../api/apiObjects';
import { Constants, ApiRoutes, ClientRoutes } from '../../constants';
import * as Api from '../../api/models';
import PetMapper from './petMapper';
import PetViewModel from './petViewModel';
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
import { BreedSelectComponent } from '../shared/breedSelect';
import { PenSelectComponent } from '../shared/penSelect';

interface PetCreateComponentProps {
  form: WrappedFormUtils;
  history: any;
  match: any;
}

interface PetCreateComponentState {
  model?: PetViewModel;
  loading: boolean;
  loaded: boolean;
  errorOccurred: boolean;
  errorMessage: string;
  submitted: boolean;
  submitting: boolean;
}

class PetCreateComponent extends React.Component<
  PetCreateComponentProps,
  PetCreateComponentState
> {
  state = {
    model: new PetViewModel(),
    loading: false,
    loaded: true,
    errorOccurred: false,
    errorMessage: '',
    submitted: false,
    submitting: false,
  };

  handleSubmit = (e: FormEvent<HTMLFormElement>) => {
    e.preventDefault();
    this.setState({ ...this.state, submitting: true, submitted: false });
    this.props.form.validateFields((err: any, values: any) => {
      if (!err) {
        let model = values as PetViewModel;
        this.submit(model);
      } else {
        this.setState({ ...this.state, submitting: false, submitted: false });
      }
    });
  };

  submit = (model: PetViewModel) => {
    let mapper = new PetMapper();
    axios
      .post<CreateResponse<Api.PetClientRequestModel>>(
        Constants.ApiEndpoint + ApiRoutes.Pets,
        mapper.mapViewModelToApiRequest(model),
        {
          headers: GlobalUtilities.defaultHeaders(),
        }
      )
      .then(response => {
        this.setState({
          ...this.state,
          submitted: true,
          submitting: false,
          model: mapper.mapApiResponseToViewModel(response.data.record!),
          errorOccurred: false,
          errorMessage: '',
        });
        GlobalUtilities.logInfo(response);
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
            <label htmlFor="acquiredDate">Acquired Date</label>
            <br />
            {getFieldDecorator('acquiredDate', {
              rules: [{ required: true, message: 'Required' }],
            })(
              <DatePicker format={'YYYY-MM-DD'} placeholder={'Acquired Date'} />
            )}
          </Form.Item>

          <BreedSelectComponent
            apiRoute={Constants.ApiEndpoint + ApiRoutes.Breeds}
            getFieldDecorator={this.props.form.getFieldDecorator}
            propertyName="breedId"
            required={true}
            selectedValue={this.state.model!.breedId}
          />

          <Form.Item>
            <label htmlFor="description">Description</label>
            <br />
            {getFieldDecorator('description', {
              rules: [{ required: true, message: 'Required' }],
            })(<Input placeholder={'Description'} />)}
          </Form.Item>

          <PenSelectComponent
            apiRoute={Constants.ApiEndpoint + ApiRoutes.Pens}
            getFieldDecorator={this.props.form.getFieldDecorator}
            propertyName="penId"
            required={true}
            selectedValue={this.state.model!.penId}
          />

          <Form.Item>
            <label htmlFor="price">Price</label>
            <br />
            {getFieldDecorator('price', {
              rules: [{ required: true, message: 'Required' }],
            })(<Input placeholder={'Price'} />)}
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

export const WrappedPetCreateComponent = Form.create({ name: 'Pet Create' })(
  PetCreateComponent
);


/*<Codenesium>
    <Hash>64a144898a9e5e8436e28b6b291b27e4</Hash>
</Codenesium>*/