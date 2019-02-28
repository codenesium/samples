import React, { Component, FormEvent } from 'react';
import axios from 'axios';
import { ActionResponse, CreateResponse } from '../../api/apiObjects';
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
import { ToLowerCaseFirstLetter } from '../../lib/stringUtilities';
import { BusinessEntitySelectComponent } from '../shared/businessEntitySelect';

interface PersonCreateComponentProps {
  form: WrappedFormUtils;
  history: any;
  match: any;
}

interface PersonCreateComponentState {
  model?: PersonViewModel;
  loading: boolean;
  loaded: boolean;
  errorOccurred: boolean;
  errorMessage: string;
  submitted: boolean;
}

class PersonCreateComponent extends React.Component<
  PersonCreateComponentProps,
  PersonCreateComponentState
> {
  state = {
    model: new PersonViewModel(),
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
        let model = values as PersonViewModel;
        console.log('Received values of form: ', model);
        this.submit(model);
      }
    });
  };

  submit = (model: PersonViewModel) => {
    let mapper = new PersonMapper();
    axios
      .post(
        Constants.ApiEndpoint + ApiRoutes.People,
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
          if (error.response.data) {
            let errorResponse = error.response.data as ActionResponse;

            errorResponse.validationErrors.forEach(x => {
              this.props.form.setFields({
                [ToLowerCaseFirstLetter(x.propertyName)]: {
                  value: this.props.form.getFieldValue(
                    ToLowerCaseFirstLetter(x.propertyName)
                  ),
                  errors: [new Error(x.errorMessage)],
                },
              });
            });
          }
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

export const WrappedPersonCreateComponent = Form.create({
  name: 'Person Create',
})(PersonCreateComponent);


/*<Codenesium>
    <Hash>8403f743fc461652d0711da7abbb97f0</Hash>
</Codenesium>*/