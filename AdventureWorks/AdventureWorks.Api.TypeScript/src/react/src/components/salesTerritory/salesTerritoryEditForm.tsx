import React, { Component, FormEvent } from 'react';
import axios from 'axios';
import { ActionResponse, CreateResponse } from '../../api/apiObjects';
import { Constants, ApiRoutes, ClientRoutes } from '../../constants';
import * as Api from '../../api/models';
import SalesTerritoryMapper from './salesTerritoryMapper';
import SalesTerritoryViewModel from './salesTerritoryViewModel';
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
interface SalesTerritoryEditComponentProps {
  form: WrappedFormUtils;
  history: any;
  match: any;
}

interface SalesTerritoryEditComponentState {
  model?: SalesTerritoryViewModel;
  loading: boolean;
  loaded: boolean;
  errorOccurred: boolean;
  errorMessage: string;
  submitted: boolean;
  submitting: boolean;
}

class SalesTerritoryEditComponent extends React.Component<
  SalesTerritoryEditComponentProps,
  SalesTerritoryEditComponentState
> {
  state = {
    model: new SalesTerritoryViewModel(),
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
      .get(
        Constants.ApiEndpoint +
          ApiRoutes.SalesTerritories +
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
          let response = resp.data as Api.SalesTerritoryClientResponseModel;

          console.log(response);

          let mapper = new SalesTerritoryMapper();

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
    this.setState({ ...this.state, submitting: true, submitted: false });
    this.props.form.validateFields((err: any, values: any) => {
      if (!err) {
        let model = values as SalesTerritoryViewModel;
        console.log('Received values of form: ', model);
        this.submit(model);
      } else {
        this.setState({ ...this.state, submitting: false, submitted: false });
      }
    });
  };

  submit = (model: SalesTerritoryViewModel) => {
    let mapper = new SalesTerritoryMapper();
    axios
      .put(
        Constants.ApiEndpoint +
          ApiRoutes.SalesTerritories +
          '/' +
          this.state.model!.territoryID,
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
            Api.SalesTerritoryClientRequestModel
          >;
          this.setState({
            ...this.state,
            submitted: true,
            submitting: false,
            model: mapper.mapApiResponseToViewModel(response.record!),
            errorOccurred: false,
            errorMessage: '',
          });
          console.log(response);
        },
        error => {
          console.log(error);
          let errorResponse = error.response.data as ActionResponse;
          if (error.response.data) {
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
            submitting: false,
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
            <label htmlFor="costLastYear">CostLastYear</label>
            <br />
            {getFieldDecorator('costLastYear', {
              rules: [{ required: true, message: 'Required' }],
            })(
              <DatePicker format={'YYYY-MM-DD'} placeholder={'CostLastYear'} />
            )}
          </Form.Item>

          <Form.Item>
            <label htmlFor="costYTD">CostYTD</label>
            <br />
            {getFieldDecorator('costYTD', {
              rules: [{ required: true, message: 'Required' }],
            })(<DatePicker format={'YYYY-MM-DD'} placeholder={'CostYTD'} />)}
          </Form.Item>

          <Form.Item>
            <label htmlFor="countryRegionCode">CountryRegionCode</label>
            <br />
            {getFieldDecorator('countryRegionCode', {
              rules: [
                { required: true, message: 'Required' },
                { max: 3, message: 'Exceeds max length of 3' },
              ],
            })(
              <DatePicker
                format={'YYYY-MM-DD'}
                placeholder={'CountryRegionCode'}
              />
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
            <label htmlFor="name">Name</label>
            <br />
            {getFieldDecorator('name', {
              rules: [
                { required: true, message: 'Required' },
                { max: 50, message: 'Exceeds max length of 50' },
              ],
            })(<DatePicker format={'YYYY-MM-DD'} placeholder={'Name'} />)}
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
            <label htmlFor="salesYTD">SalesYTD</label>
            <br />
            {getFieldDecorator('salesYTD', {
              rules: [{ required: true, message: 'Required' }],
            })(<DatePicker format={'YYYY-MM-DD'} placeholder={'SalesYTD'} />)}
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

export const WrappedSalesTerritoryEditComponent = Form.create({
  name: 'SalesTerritory Edit',
})(SalesTerritoryEditComponent);


/*<Codenesium>
    <Hash>96c6d89577733c254a25b98c29be9288</Hash>
</Codenesium>*/