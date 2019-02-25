import React, { Component, FormEvent } from 'react';
import axios from 'axios';
import { CreateResponse } from '../../api/apiObjects';
import { Constants, ApiRoutes, ClientRoutes } from '../../constants';
import * as Api from '../../api/models';
import PersonMapper from './personMapper';
import PersonViewModel from './personViewModel';
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

interface PersonEditComponentProps {
  form: WrappedFormUtils;
  history: any;
  match: any;
}

interface PersonEditComponentState {
  model?: PersonViewModel;
  loading: boolean;
  loaded: boolean;
  errorOccurred: boolean;
  errorMessage: string;
  submitted: boolean;
}

class PersonEditComponent extends React.Component<
  PersonEditComponentProps,
  PersonEditComponentState
> {
  state = {
    model: new PersonViewModel(),
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
          ApiRoutes.People +
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
          let response = resp.data as Api.PersonClientResponseModel;

          console.log(response);

          let mapper = new PersonMapper();

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
        let model = values as PersonViewModel;
        console.log('Received values of form: ', model);
        this.submit(model);
      }
    });
  };

  submit = (model: PersonViewModel) => {
    let mapper = new PersonMapper();
    axios
      .put(
        Constants.ApiEndpoint +
          ApiRoutes.People +
          '/' +
          this.state.model!.businessEntityID,
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
            Api.PersonClientRequestModel
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
            <label htmlFor="additionalContactInfo">AdditionalContactInfo</label>
            <br />
            {getFieldDecorator('additionalContactInfo', {
              rules: [],
            })(
              <DatePicker
                format={'YYYY-MM-DD'}
                placeholder={'AdditionalContactInfo'}
              />
            )}
          </Form.Item>

          <Form.Item>
            <label htmlFor="demographic">Demographics</label>
            <br />
            {getFieldDecorator('demographic', {
              rules: [],
            })(
              <DatePicker format={'YYYY-MM-DD'} placeholder={'Demographics'} />
            )}
          </Form.Item>

          <Form.Item>
            <label htmlFor="emailPromotion">EmailPromotion</label>
            <br />
            {getFieldDecorator('emailPromotion', {
              rules: [{ required: true, message: 'Required' }],
            })(
              <DatePicker
                format={'YYYY-MM-DD'}
                placeholder={'EmailPromotion'}
              />
            )}
          </Form.Item>

          <Form.Item>
            <label htmlFor="firstName">FirstName</label>
            <br />
            {getFieldDecorator('firstName', {
              rules: [
                { required: true, message: 'Required' },
                { max: 50, message: 'Exceeds max length of 50' },
              ],
            })(<DatePicker format={'YYYY-MM-DD'} placeholder={'FirstName'} />)}
          </Form.Item>

          <Form.Item>
            <label htmlFor="lastName">LastName</label>
            <br />
            {getFieldDecorator('lastName', {
              rules: [
                { required: true, message: 'Required' },
                { max: 50, message: 'Exceeds max length of 50' },
              ],
            })(<DatePicker format={'YYYY-MM-DD'} placeholder={'LastName'} />)}
          </Form.Item>

          <Form.Item>
            <label htmlFor="middleName">MiddleName</label>
            <br />
            {getFieldDecorator('middleName', {
              rules: [{ max: 50, message: 'Exceeds max length of 50' }],
            })(<DatePicker format={'YYYY-MM-DD'} placeholder={'MiddleName'} />)}
          </Form.Item>

          <Form.Item>
            <label htmlFor="modifiedDate">ModifiedDate</label>
            <br />
            {getFieldDecorator('modifiedDate', {
              rules: [{ required: true, message: 'Required' }],
            })(
              <DatePicker format={'YYYY-MM-DD'} placeholder={'ModifiedDate'} />
            )}
          </Form.Item>

          <Form.Item>
            <label htmlFor="nameStyle">NameStyle</label>
            <br />
            {getFieldDecorator('nameStyle', {
              rules: [{ required: true, message: 'Required' }],
            })(<DatePicker format={'YYYY-MM-DD'} placeholder={'NameStyle'} />)}
          </Form.Item>

          <Form.Item>
            <label htmlFor="personType">PersonType</label>
            <br />
            {getFieldDecorator('personType', {
              rules: [
                { required: true, message: 'Required' },
                { max: 2, message: 'Exceeds max length of 2' },
              ],
            })(<DatePicker format={'YYYY-MM-DD'} placeholder={'PersonType'} />)}
          </Form.Item>

          <Form.Item>
            <label htmlFor="rowguid">rowguid</label>
            <br />
            {getFieldDecorator('rowguid', {
              rules: [{ required: true, message: 'Required' }],
            })(<DatePicker format={'YYYY-MM-DD'} placeholder={'rowguid'} />)}
          </Form.Item>

          <Form.Item>
            <label htmlFor="suffix">Suffix</label>
            <br />
            {getFieldDecorator('suffix', {
              rules: [{ max: 10, message: 'Exceeds max length of 10' }],
            })(<DatePicker format={'YYYY-MM-DD'} placeholder={'Suffix'} />)}
          </Form.Item>

          <Form.Item>
            <label htmlFor="title">Title</label>
            <br />
            {getFieldDecorator('title', {
              rules: [{ max: 8, message: 'Exceeds max length of 8' }],
            })(<DatePicker format={'YYYY-MM-DD'} placeholder={'Title'} />)}
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

export const WrappedPersonEditComponent = Form.create({ name: 'Person Edit' })(
  PersonEditComponent
);


/*<Codenesium>
    <Hash>8be319dbee83ba78f7f3b8c7270ffccb</Hash>
</Codenesium>*/