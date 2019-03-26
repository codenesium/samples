import React, { Component, FormEvent } from 'react';
import axios, { AxiosError, AxiosResponse } from 'axios';
import { ActionResponse, CreateResponse } from '../../api/apiObjects';
import { Constants, ApiRoutes, ClientRoutes } from '../../constants';
import * as Api from '../../api/models';
import ProductMapper from './productMapper';
import ProductViewModel from './productViewModel';
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
import { ProductModelSelectComponent } from '../shared/productModelSelect';
import { ProductSubcategorySelectComponent } from '../shared/productSubcategorySelect';
import { UnitMeasureSelectComponent } from '../shared/unitMeasureSelect';
interface ProductEditComponentProps {
  form: WrappedFormUtils;
  history: any;
  match: any;
}

interface ProductEditComponentState {
  model?: ProductViewModel;
  loading: boolean;
  loaded: boolean;
  errorOccurred: boolean;
  errorMessage: string;
  submitted: boolean;
  submitting: boolean;
}

class ProductEditComponent extends React.Component<
  ProductEditComponentProps,
  ProductEditComponentState
> {
  state = {
    model: new ProductViewModel(),
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
      .get<Api.ProductClientResponseModel>(
        Constants.ApiEndpoint +
          ApiRoutes.Products +
          '/' +
          this.props.match.params.id,
        {
          headers: GlobalUtilities.defaultHeaders(),
        }
      )
      .then(response => {
        GlobalUtilities.logInfo(response);

        let mapper = new ProductMapper();

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
        let model = values as ProductViewModel;
        this.submit(model);
      } else {
        this.setState({ ...this.state, submitting: false, submitted: false });
      }
    });
  };

  submit = (model: ProductViewModel) => {
    let mapper = new ProductMapper();
    axios
      .put<CreateResponse<Api.ProductClientRequestModel>>(
        Constants.ApiEndpoint +
          ApiRoutes.Products +
          '/' +
          this.state.model!.productID,
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
            <label htmlFor="reservedClass">Class</label>
            <br />
            {getFieldDecorator('reservedClass', {
              rules: [{ max: 2, message: 'Exceeds max length of 2' }],
            })(<Input placeholder={'Class'} />)}
          </Form.Item>

          <Form.Item>
            <label htmlFor="color">Color</label>
            <br />
            {getFieldDecorator('color', {
              rules: [{ max: 15, message: 'Exceeds max length of 15' }],
            })(<Input placeholder={'Color'} />)}
          </Form.Item>

          <Form.Item>
            <label htmlFor="daysToManufacture">Days To Manufacture</label>
            <br />
            {getFieldDecorator('daysToManufacture', {
              rules: [{ required: true, message: 'Required' }],
            })(<InputNumber placeholder={'Days To Manufacture'} />)}
          </Form.Item>

          <Form.Item>
            <label htmlFor="discontinuedDate">Discontinued Date</label>
            <br />
            {getFieldDecorator('discontinuedDate', {
              rules: [],
            })(
              <DatePicker
                format={'YYYY-MM-DD'}
                placeholder={'Discontinued Date'}
              />
            )}
          </Form.Item>

          <Form.Item>
            <label htmlFor="finishedGoodsFlag">Finished Goods Flag</label>
            <br />
            {getFieldDecorator('finishedGoodsFlag', {
              rules: [],
              valuePropName: 'checked',
            })(<Switch />)}
          </Form.Item>

          <Form.Item>
            <label htmlFor="listPrice">List Price</label>
            <br />
            {getFieldDecorator('listPrice', {
              rules: [{ required: true, message: 'Required' }],
            })(<InputNumber placeholder={'List Price'} />)}
          </Form.Item>

          <Form.Item>
            <label htmlFor="makeFlag">Make Flag</label>
            <br />
            {getFieldDecorator('makeFlag', {
              rules: [],
              valuePropName: 'checked',
            })(<Switch />)}
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
            <label htmlFor="name">Name</label>
            <br />
            {getFieldDecorator('name', {
              rules: [
                { required: true, message: 'Required' },
                { max: 50, message: 'Exceeds max length of 50' },
              ],
            })(<Input placeholder={'Name'} />)}
          </Form.Item>

          <Form.Item>
            <label htmlFor="productLine">Product Line</label>
            <br />
            {getFieldDecorator('productLine', {
              rules: [{ max: 2, message: 'Exceeds max length of 2' }],
            })(<Input placeholder={'Product Line'} />)}
          </Form.Item>

          <ProductModelSelectComponent
            apiRoute={Constants.ApiEndpoint + ApiRoutes.ProductModels}
            getFieldDecorator={this.props.form.getFieldDecorator}
            propertyName="productModelID"
            required={false}
            selectedValue={this.state.model!.productModelID}
          />

          <Form.Item>
            <label htmlFor="productNumber">Product Number</label>
            <br />
            {getFieldDecorator('productNumber', {
              rules: [
                { required: true, message: 'Required' },
                { max: 25, message: 'Exceeds max length of 25' },
              ],
            })(<Input placeholder={'Product Number'} />)}
          </Form.Item>

          <ProductSubcategorySelectComponent
            apiRoute={Constants.ApiEndpoint + ApiRoutes.ProductSubcategories}
            getFieldDecorator={this.props.form.getFieldDecorator}
            propertyName="productSubcategoryID"
            required={false}
            selectedValue={this.state.model!.productSubcategoryID}
          />

          <Form.Item>
            <label htmlFor="reorderPoint">Reorder Point</label>
            <br />
            {getFieldDecorator('reorderPoint', {
              rules: [{ required: true, message: 'Required' }],
            })(<InputNumber placeholder={'Reorder Point'} />)}
          </Form.Item>

          <Form.Item>
            <label htmlFor="rowguid">Rowguid</label>
            <br />
            {getFieldDecorator('rowguid', {
              rules: [{ required: true, message: 'Required' }],
            })(<Input placeholder={'Rowguid'} />)}
          </Form.Item>

          <Form.Item>
            <label htmlFor="safetyStockLevel">Safety Stock Level</label>
            <br />
            {getFieldDecorator('safetyStockLevel', {
              rules: [{ required: true, message: 'Required' }],
            })(<InputNumber placeholder={'Safety Stock Level'} />)}
          </Form.Item>

          <Form.Item>
            <label htmlFor="sellEndDate">Sell End Date</label>
            <br />
            {getFieldDecorator('sellEndDate', {
              rules: [],
            })(
              <DatePicker format={'YYYY-MM-DD'} placeholder={'Sell End Date'} />
            )}
          </Form.Item>

          <Form.Item>
            <label htmlFor="sellStartDate">Sell Start Date</label>
            <br />
            {getFieldDecorator('sellStartDate', {
              rules: [{ required: true, message: 'Required' }],
            })(
              <DatePicker
                format={'YYYY-MM-DD'}
                placeholder={'Sell Start Date'}
              />
            )}
          </Form.Item>

          <Form.Item>
            <label htmlFor="size">Size</label>
            <br />
            {getFieldDecorator('size', {
              rules: [{ max: 5, message: 'Exceeds max length of 5' }],
            })(<Input placeholder={'Size'} />)}
          </Form.Item>

          <UnitMeasureSelectComponent
            apiRoute={Constants.ApiEndpoint + ApiRoutes.UnitMeasures}
            getFieldDecorator={this.props.form.getFieldDecorator}
            propertyName="sizeUnitMeasureCode"
            required={false}
            selectedValue={this.state.model!.sizeUnitMeasureCode}
          />

          <Form.Item>
            <label htmlFor="standardCost">Standard Cost</label>
            <br />
            {getFieldDecorator('standardCost', {
              rules: [{ required: true, message: 'Required' }],
            })(<InputNumber placeholder={'Standard Cost'} />)}
          </Form.Item>

          <Form.Item>
            <label htmlFor="style">Style</label>
            <br />
            {getFieldDecorator('style', {
              rules: [{ max: 2, message: 'Exceeds max length of 2' }],
            })(<Input placeholder={'Style'} />)}
          </Form.Item>

          <Form.Item>
            <label htmlFor="weight">Weight</label>
            <br />
            {getFieldDecorator('weight', {
              rules: [],
            })(<InputNumber placeholder={'Weight'} />)}
          </Form.Item>

          <UnitMeasureSelectComponent
            apiRoute={Constants.ApiEndpoint + ApiRoutes.UnitMeasures}
            getFieldDecorator={this.props.form.getFieldDecorator}
            propertyName="weightUnitMeasureCode"
            required={false}
            selectedValue={this.state.model!.weightUnitMeasureCode}
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

export const WrappedProductEditComponent = Form.create({
  name: 'Product Edit',
})(ProductEditComponent);


/*<Codenesium>
    <Hash>4e9581551e6ebfc2f6c4cbf22bcb7403</Hash>
</Codenesium>*/