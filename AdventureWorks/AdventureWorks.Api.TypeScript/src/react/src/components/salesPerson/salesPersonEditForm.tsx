import React, { Component, FormEvent } from 'react';
import axios, { AxiosError, AxiosResponse } from 'axios';
import { ActionResponse, CreateResponse } from '../../api/apiObjects';
import { Constants, ApiRoutes, ClientRoutes } from '../../constants';
import * as Api from '../../api/models';
import SalesPersonMapper from './salesPersonMapper';
import SalesPersonViewModel from './salesPersonViewModel';
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
import { SalesTerritorySelectComponent } from '../shared/salesTerritorySelect';
interface SalesPersonEditComponentProps {
  form: WrappedFormUtils;
  history: any;
  match: any;
}

interface SalesPersonEditComponentState {
  model?: SalesPersonViewModel;
  loading: boolean;
  loaded: boolean;
  errorOccurred: boolean;
  errorMessage: string;
  submitted: boolean;
  submitting: boolean;
}

class SalesPersonEditComponent extends React.Component<
  SalesPersonEditComponentProps,
  SalesPersonEditComponentState
> {
  state = {
    model: new SalesPersonViewModel(),
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
      .get<Api.SalesPersonClientResponseModel>(
        Constants.ApiEndpoint +
          ApiRoutes.SalesPersons +
          '/' +
          this.props.match.params.id,
        {
          headers: GlobalUtilities.defaultHeaders(),
        }
      )
      .then(response => {
        GlobalUtilities.logInfo(response);

        let mapper = new SalesPersonMapper();

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
        let model = values as SalesPersonViewModel;
        this.submit(model);
      } else {
        this.setState({ ...this.state, submitting: false, submitted: false });
      }
    });
  };

  submit = (model: SalesPersonViewModel) => {
    let mapper = new SalesPersonMapper();
    axios
      .put<CreateResponse<Api.SalesPersonClientRequestModel>>(
        Constants.ApiEndpoint +
          ApiRoutes.SalesPersons +
          '/' +
          this.state.model!.businessEntityID,
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
            <label htmlFor="bonus">Bonus</label>
            <br />
            {getFieldDecorator('bonus', {
              rules: [{ required: true, message: 'Required' }],
            })(<InputNumber placeholder={'Bonus'} />)}
          </Form.Item>

          <Form.Item>
            <label htmlFor="commissionPct">Commission Pct</label>
            <br />
            {getFieldDecorator('commissionPct', {
              rules: [{ required: true, message: 'Required' }],
            })(<InputNumber placeholder={'Commission Pct'} />)}
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
            <label htmlFor="rowguid">Rowguid</label>
            <br />
            {getFieldDecorator('rowguid', {
              rules: [{ required: true, message: 'Required' }],
            })(<Input placeholder={'Rowguid'} />)}
          </Form.Item>

          <Form.Item>
            <label htmlFor="salesLastYear">Sales Last Year</label>
            <br />
            {getFieldDecorator('salesLastYear', {
              rules: [{ required: true, message: 'Required' }],
            })(<InputNumber placeholder={'Sales Last Year'} />)}
          </Form.Item>

          <Form.Item>
            <label htmlFor="salesQuota">Sales Quota</label>
            <br />
            {getFieldDecorator('salesQuota', {
              rules: [],
            })(<InputNumber placeholder={'Sales Quota'} />)}
          </Form.Item>

          <Form.Item>
            <label htmlFor="salesYTD">Sales Y T D</label>
            <br />
            {getFieldDecorator('salesYTD', {
              rules: [{ required: true, message: 'Required' }],
            })(<InputNumber placeholder={'Sales Y T D'} />)}
          </Form.Item>

          <SalesTerritorySelectComponent
            apiRoute={Constants.ApiEndpoint + ApiRoutes.SalesTerritories}
            getFieldDecorator={this.props.form.getFieldDecorator}
            propertyName="territoryID"
            required={false}
            selectedValue={this.state.model!.territoryID}
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

export const WrappedSalesPersonEditComponent = Form.create({
  name: 'SalesPerson Edit',
})(SalesPersonEditComponent);


/*<Codenesium>
    <Hash>e5764100c0287c9c53c5be6e6e885ec6</Hash>
</Codenesium>*/