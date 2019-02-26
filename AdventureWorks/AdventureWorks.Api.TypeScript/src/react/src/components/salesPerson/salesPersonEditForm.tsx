import React, { Component, FormEvent } from 'react';
import axios from 'axios';
import { CreateResponse } from '../../api/apiObjects';
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
  };

  componentDidMount() {
    this.setState({ ...this.state, loading: true });

    axios
      .get(
        Constants.ApiEndpoint +
          ApiRoutes.SalesPersons +
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
          let response = resp.data as Api.SalesPersonClientResponseModel;

          console.log(response);

          let mapper = new SalesPersonMapper();

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
        let model = values as SalesPersonViewModel;
        console.log('Received values of form: ', model);
        this.submit(model);
      }
    });
  };

  submit = (model: SalesPersonViewModel) => {
    let mapper = new SalesPersonMapper();
    axios
      .put(
        Constants.ApiEndpoint +
          ApiRoutes.SalesPersons +
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
            Api.SalesPersonClientRequestModel
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
            <label htmlFor="bonus">Bonus</label>
            <br />
            {getFieldDecorator('bonus', {
              rules: [{ required: true, message: 'Required' }],
            })(<DatePicker format={'YYYY-MM-DD'} placeholder={'Bonus'} />)}
          </Form.Item>

          <Form.Item>
            <label htmlFor="commissionPct">CommissionPct</label>
            <br />
            {getFieldDecorator('commissionPct', {
              rules: [{ required: true, message: 'Required' }],
            })(
              <DatePicker format={'YYYY-MM-DD'} placeholder={'CommissionPct'} />
            )}
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
            <label htmlFor="rowguid">rowguid</label>
            <br />
            {getFieldDecorator('rowguid', {
              rules: [{ required: true, message: 'Required' }],
            })(<DatePicker format={'YYYY-MM-DD'} placeholder={'rowguid'} />)}
          </Form.Item>

          <Form.Item>
            <label htmlFor="salesLastYear">SalesLastYear</label>
            <br />
            {getFieldDecorator('salesLastYear', {
              rules: [{ required: true, message: 'Required' }],
            })(
              <DatePicker format={'YYYY-MM-DD'} placeholder={'SalesLastYear'} />
            )}
          </Form.Item>

          <Form.Item>
            <label htmlFor="salesQuota">SalesQuota</label>
            <br />
            {getFieldDecorator('salesQuota', {
              rules: [],
            })(<DatePicker format={'YYYY-MM-DD'} placeholder={'SalesQuota'} />)}
          </Form.Item>

          <Form.Item>
            <label htmlFor="salesYTD">SalesYTD</label>
            <br />
            {getFieldDecorator('salesYTD', {
              rules: [{ required: true, message: 'Required' }],
            })(<DatePicker format={'YYYY-MM-DD'} placeholder={'SalesYTD'} />)}
          </Form.Item>

          <Form.Item>
            <label htmlFor="territoryID">TerritoryID</label>
            <br />
            {getFieldDecorator('territoryID', {
              rules: [],
            })(
              <DatePicker format={'YYYY-MM-DD'} placeholder={'TerritoryID'} />
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

export const WrappedSalesPersonEditComponent = Form.create({
  name: 'SalesPerson Edit',
})(SalesPersonEditComponent);


/*<Codenesium>
    <Hash>9493b5e5b23241e40e4a4c0c8ffc1ee8</Hash>
</Codenesium>*/