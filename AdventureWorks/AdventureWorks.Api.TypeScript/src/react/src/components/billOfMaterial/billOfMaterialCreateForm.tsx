import React, { Component, FormEvent } from 'react';
import axios from 'axios';
import { CreateResponse } from '../../api/apiObjects';
import { Constants, ApiRoutes, ClientRoutes } from '../../constants';
import * as Api from '../../api/models';
import BillOfMaterialMapper from './billOfMaterialMapper';
import BillOfMaterialViewModel from './billOfMaterialViewModel';
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

interface BillOfMaterialCreateComponentProps {
  form: WrappedFormUtils;
  history: any;
  match: any;
}

interface BillOfMaterialCreateComponentState {
  model?: BillOfMaterialViewModel;
  loading: boolean;
  loaded: boolean;
  errorOccurred: boolean;
  errorMessage: string;
  submitted: boolean;
}

class BillOfMaterialCreateComponent extends React.Component<
  BillOfMaterialCreateComponentProps,
  BillOfMaterialCreateComponentState
> {
  state = {
    model: new BillOfMaterialViewModel(),
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
        let model = values as BillOfMaterialViewModel;
        console.log('Received values of form: ', model);
        this.submit(model);
      }
    });
  };

  submit = (model: BillOfMaterialViewModel) => {
    let mapper = new BillOfMaterialMapper();
    axios
      .post(
        Constants.ApiEndpoint + ApiRoutes.BillOfMaterials,
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
            Api.BillOfMaterialClientRequestModel
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
            <label htmlFor="bOMLevel">BOMLevel</label>
            <br />
            {getFieldDecorator('bOMLevel', {
              rules: [{ required: true, message: 'Required' }],
            })(<DatePicker format={'YYYY-MM-DD'} placeholder={'BOMLevel'} />)}
          </Form.Item>

          <Form.Item>
            <label htmlFor="componentID">ComponentID</label>
            <br />
            {getFieldDecorator('componentID', {
              rules: [{ required: true, message: 'Required' }],
            })(
              <DatePicker format={'YYYY-MM-DD'} placeholder={'ComponentID'} />
            )}
          </Form.Item>

          <Form.Item>
            <label htmlFor="endDate">EndDate</label>
            <br />
            {getFieldDecorator('endDate', {
              rules: [],
            })(<DatePicker format={'YYYY-MM-DD'} placeholder={'EndDate'} />)}
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
            <label htmlFor="perAssemblyQty">PerAssemblyQty</label>
            <br />
            {getFieldDecorator('perAssemblyQty', {
              rules: [{ required: true, message: 'Required' }],
            })(
              <DatePicker
                format={'YYYY-MM-DD'}
                placeholder={'PerAssemblyQty'}
              />
            )}
          </Form.Item>

          <Form.Item>
            <label htmlFor="productAssemblyID">ProductAssemblyID</label>
            <br />
            {getFieldDecorator('productAssemblyID', {
              rules: [],
            })(
              <DatePicker
                format={'YYYY-MM-DD'}
                placeholder={'ProductAssemblyID'}
              />
            )}
          </Form.Item>

          <Form.Item>
            <label htmlFor="startDate">StartDate</label>
            <br />
            {getFieldDecorator('startDate', {
              rules: [{ required: true, message: 'Required' }],
            })(<DatePicker format={'YYYY-MM-DD'} placeholder={'StartDate'} />)}
          </Form.Item>

          <Form.Item>
            <label htmlFor="unitMeasureCode">UnitMeasureCode</label>
            <br />
            {getFieldDecorator('unitMeasureCode', {
              rules: [
                { required: true, message: 'Required' },
                { max: 3, message: 'Exceeds max length of 3' },
              ],
            })(
              <DatePicker
                format={'YYYY-MM-DD'}
                placeholder={'UnitMeasureCode'}
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

export const WrappedBillOfMaterialCreateComponent = Form.create({
  name: 'BillOfMaterial Create',
})(BillOfMaterialCreateComponent);


/*<Codenesium>
    <Hash>8b53aa09c71260d2960fe1665e68ba43</Hash>
</Codenesium>*/