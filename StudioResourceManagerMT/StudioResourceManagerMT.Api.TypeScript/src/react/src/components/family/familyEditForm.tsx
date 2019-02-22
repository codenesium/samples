import React, { Component, FormEvent } from 'react';
import axios from 'axios';
import { CreateResponse } from '../../api/apiObjects';
import { Constants, ApiRoutes, ClientRoutes } from '../../constants';
import * as Api from '../../api/models';
import FamilyMapper from './familyMapper';
import FamilyViewModel from './familyViewModel';
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

interface FamilyEditComponentProps {
  form: WrappedFormUtils;
  history: any;
  match: any;
}

interface FamilyEditComponentState {
  model?: FamilyViewModel;
  loading: boolean;
  loaded: boolean;
  errorOccurred: boolean;
  errorMessage: string;
  submitted: boolean;
}

class FamilyEditComponent extends React.Component<
  FamilyEditComponentProps,
  FamilyEditComponentState
> {
  state = {
    model: new FamilyViewModel(),
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
          ApiRoutes.Families +
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
          let response = resp.data as Api.FamilyClientResponseModel;

          console.log(response);

          let mapper = new FamilyMapper();

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
        let model = values as FamilyViewModel;
        console.log('Received values of form: ', model);
        this.submit(model);
      }
    });
  };

  submit = (model: FamilyViewModel) => {
    let mapper = new FamilyMapper();
    axios
      .put(
        Constants.ApiEndpoint + ApiRoutes.Families + '/' + this.state.model!.id,
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
            Api.FamilyClientRequestModel
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
            <label htmlFor="note">notes</label>
            <br />
            {getFieldDecorator('note', {
              rules: [],
            })(<DatePicker format={'YYYY-MM-DD'} placeholder={'notes'} />)}
          </Form.Item>

          <Form.Item>
            <label htmlFor="primaryContactEmail">primaryContactEmail</label>
            <br />
            {getFieldDecorator('primaryContactEmail', {
              rules: [{ max: 128, message: 'Exceeds max length of 128' }],
            })(
              <DatePicker
                format={'YYYY-MM-DD'}
                placeholder={'primaryContactEmail'}
              />
            )}
          </Form.Item>

          <Form.Item>
            <label htmlFor="primaryContactFirstName">
              primaryContactFirstName
            </label>
            <br />
            {getFieldDecorator('primaryContactFirstName', {
              rules: [{ max: 128, message: 'Exceeds max length of 128' }],
            })(
              <DatePicker
                format={'YYYY-MM-DD'}
                placeholder={'primaryContactFirstName'}
              />
            )}
          </Form.Item>

          <Form.Item>
            <label htmlFor="primaryContactLastName">
              primaryContactLastName
            </label>
            <br />
            {getFieldDecorator('primaryContactLastName', {
              rules: [{ max: 128, message: 'Exceeds max length of 128' }],
            })(
              <DatePicker
                format={'YYYY-MM-DD'}
                placeholder={'primaryContactLastName'}
              />
            )}
          </Form.Item>

          <Form.Item>
            <label htmlFor="primaryContactPhone">primaryContactPhone</label>
            <br />
            {getFieldDecorator('primaryContactPhone', {
              rules: [
                { required: true, message: 'Required' },
                { whitespace: true, message: 'Required' },
                { max: 128, message: 'Exceeds max length of 128' },
              ],
            })(
              <DatePicker
                format={'YYYY-MM-DD'}
                placeholder={'primaryContactPhone'}
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

export const WrappedFamilyEditComponent = Form.create({ name: 'Family Edit' })(
  FamilyEditComponent
);


/*<Codenesium>
    <Hash>4addbc8970d9019295c9019ee7fce219</Hash>
</Codenesium>*/