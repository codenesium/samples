import React, { Component, FormEvent } from 'react';
import axios, { AxiosError, AxiosResponse } from 'axios';
import { ActionResponse, CreateResponse } from '../../api/apiObjects';
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
import * as GlobalUtilities from '../../lib/globalUtilities';
import { ProductSelectComponent } from '../shared/productSelect';
import { UnitMeasureSelectComponent } from '../shared/unitMeasureSelect';

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
  submitting: boolean;
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
    submitting: false,
  };

  handleSubmit = (e: FormEvent<HTMLFormElement>) => {
    e.preventDefault();
    this.setState({ ...this.state, submitting: true, submitted: false });
    this.props.form.validateFields((err: any, values: any) => {
      if (!err) {
        let model = values as BillOfMaterialViewModel;
        this.submit(model);
      } else {
        this.setState({ ...this.state, submitting: false, submitted: false });
      }
    });
  };

  submit = (model: BillOfMaterialViewModel) => {
    let mapper = new BillOfMaterialMapper();
    axios
      .post<CreateResponse<Api.BillOfMaterialClientRequestModel>>(
        Constants.ApiEndpoint + ApiRoutes.BillOfMaterials,
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
            <label htmlFor="bOMLevel">B O M Level</label>
            <br />
            {getFieldDecorator('bOMLevel', {
              rules: [{ required: true, message: 'Required' }],
            })(<InputNumber placeholder={'B O M Level'} />)}
          </Form.Item>

          <ProductSelectComponent
            apiRoute={Constants.ApiEndpoint + ApiRoutes.Products}
            getFieldDecorator={this.props.form.getFieldDecorator}
            propertyName="componentID"
            required={true}
            selectedValue={this.state.model!.componentID}
          />

          <Form.Item>
            <label htmlFor="endDate">End Date</label>
            <br />
            {getFieldDecorator('endDate', {
              rules: [],
            })(<DatePicker format={'YYYY-MM-DD'} placeholder={'End Date'} />)}
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
            <label htmlFor="perAssemblyQty">Per Assembly Qty</label>
            <br />
            {getFieldDecorator('perAssemblyQty', {
              rules: [{ required: true, message: 'Required' }],
            })(<InputNumber placeholder={'Per Assembly Qty'} />)}
          </Form.Item>

          <ProductSelectComponent
            apiRoute={Constants.ApiEndpoint + ApiRoutes.Products}
            getFieldDecorator={this.props.form.getFieldDecorator}
            propertyName="productAssemblyID"
            required={false}
            selectedValue={this.state.model!.productAssemblyID}
          />

          <Form.Item>
            <label htmlFor="startDate">Start Date</label>
            <br />
            {getFieldDecorator('startDate', {
              rules: [{ required: true, message: 'Required' }],
            })(<DatePicker format={'YYYY-MM-DD'} placeholder={'Start Date'} />)}
          </Form.Item>

          <UnitMeasureSelectComponent
            apiRoute={Constants.ApiEndpoint + ApiRoutes.UnitMeasures}
            getFieldDecorator={this.props.form.getFieldDecorator}
            propertyName="unitMeasureCode"
            required={true}
            selectedValue={this.state.model!.unitMeasureCode}
          />

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

export const WrappedBillOfMaterialCreateComponent = Form.create({
  name: 'BillOfMaterial Create',
})(BillOfMaterialCreateComponent);


/*<Codenesium>
    <Hash>d15593962ff08a260849fe89525b3738</Hash>
</Codenesium>*/