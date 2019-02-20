import React, { Component, FormEvent } from 'react';
import axios from 'axios';
import { CreateResponse } from '../../api/apiObjects';
import { LoadingForm } from '../../lib/components/loadingForm';
import { ErrorForm } from '../../lib/components/errorForm';
import { Constants, ApiRoutes, ClientRoutes } from '../../constants';
import * as Api from '../../api/models';
import FamilyMapper from './familyMapper';
import FamilyViewModel from './familyViewModel';
import { Form, Input, Button, Checkbox, InputNumber, DatePicker } from 'antd';
import { WrappedFormUtils } from 'antd/es/form/Form';
import { Alert } from 'antd';

interface FamilyCreateComponentProps {
  form: WrappedFormUtils;
  history: any;
  match: any;
}

interface FamilyCreateComponentState {
  model?: FamilyViewModel;
  loading: boolean;
  loaded: boolean;
  errorOccurred: boolean;
  errorMessage: string;
  submitted: boolean;
}

class FamilyCreateComponent extends React.Component<
  FamilyCreateComponentProps,
  FamilyCreateComponentState
> {
  state = {
    model: new FamilyViewModel(),
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
        let model = values as FamilyViewModel;
        console.log('Received values of form: ', model);
        this.submit(model);
      }
    });
  };

  submit = (model: FamilyViewModel) => {
    let mapper = new FamilyMapper();
    axios
      .post(
        Constants.ApiEndpoint + ApiRoutes.Families,
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
      return <LoadingForm />;
    } else if (this.state.loaded) {
      return (
        <Form onSubmit={this.handleSubmit}>
          <Form.Item>
            <label htmlFor="note">notes</label>
            <br />
            {getFieldDecorator('note', {
              rules: [],
            })(<Input placeholder={'notes'} id={'note'} />)}
          </Form.Item>

          <Form.Item>
            <label htmlFor="primaryContactEmail">Primary Contact Email</label>
            <br />
            {getFieldDecorator('primaryContactEmail', {
              rules: [],
            })(
              <Input
                placeholder={'Primary Contact Email'}
                id={'primaryContactEmail'}
              />
            )}
          </Form.Item>

          <Form.Item>
            <label htmlFor="primaryContactFirstName">
              Primary Contact First Name
            </label>
            <br />
            {getFieldDecorator('primaryContactFirstName', {
              rules: [],
            })(
              <Input
                placeholder={'Primary Contact First Name'}
                id={'primaryContactFirstName'}
              />
            )}
          </Form.Item>

          <Form.Item>
            <label htmlFor="primaryContactLastName">
              Primary Contact Last Name
            </label>
            <br />
            {getFieldDecorator('primaryContactLastName', {
              rules: [],
            })(
              <Input
                placeholder={'Primary Contact Last Name'}
                id={'primaryContactLastName'}
              />
            )}
          </Form.Item>

          <Form.Item>
            <label htmlFor="primaryContactPhone">Primary Contact Phone</label>
            <br />
            {getFieldDecorator('primaryContactPhone', {
              rules: [],
            })(
              <InputNumber
                placeholder={'Primary Contact Phone'}
                id={'primaryContactPhone'}
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

export const WrappedFamilyCreateComponent = Form.create({
  name: 'Family Create',
})(FamilyCreateComponent);


/*<Codenesium>
    <Hash>e728e9958ec2cff7791536a95161d9b8</Hash>
</Codenesium>*/