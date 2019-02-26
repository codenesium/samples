import React, { Component, FormEvent } from 'react';
import axios from 'axios';
import { CreateResponse } from '../../api/apiObjects';
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
  };

  handleSubmit = (e: FormEvent<HTMLFormElement>) => {
    e.preventDefault();
    this.props.form.validateFields((err: any, values: any) => {
      if (!err) {
        let model = values as PetViewModel;
        console.log('Received values of form: ', model);
        this.submit(model);
      }
    });
  };

  submit = (model: PetViewModel) => {
    let mapper = new PetMapper();
    axios
      .post(
        Constants.ApiEndpoint + ApiRoutes.Pets,
        mapper.mapViewModelToApiRequest(model),
        {
          headers: {
            'Content-Type': 'application/json',
          },
        }
      )
      .then(
        resp => {
          let response = resp.data as CreateResponse<Api.PetClientRequestModel>;
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
            <label htmlFor="acquiredDate">acquiredDate</label>
            <br />
            {getFieldDecorator('acquiredDate', {
              rules: [{ required: true, message: 'Required' }],
            })(<Input placeholder={'acquiredDate'} />)}
          </Form.Item>

          <Form.Item>
            <label htmlFor="breedId">breedId</label>
            <br />
            {getFieldDecorator('breedId', {
              rules: [{ required: true, message: 'Required' }],
            })(<Input placeholder={'breedId'} />)}
          </Form.Item>

          <Form.Item>
            <label htmlFor="description">description</label>
            <br />
            {getFieldDecorator('description', {
              rules: [{ required: true, message: 'Required' }],
            })(<Input placeholder={'description'} />)}
          </Form.Item>

          <Form.Item>
            <label htmlFor="penId">penId</label>
            <br />
            {getFieldDecorator('penId', {
              rules: [{ required: true, message: 'Required' }],
            })(<Input placeholder={'penId'} />)}
          </Form.Item>

          <Form.Item>
            <label htmlFor="price">price</label>
            <br />
            {getFieldDecorator('price', {
              rules: [{ required: true, message: 'Required' }],
            })(<Input placeholder={'price'} />)}
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

export const WrappedPetCreateComponent = Form.create({ name: 'Pet Create' })(
  PetCreateComponent
);


/*<Codenesium>
    <Hash>49b5deebee576e7c026734f9c1cf5b3e</Hash>
</Codenesium>*/