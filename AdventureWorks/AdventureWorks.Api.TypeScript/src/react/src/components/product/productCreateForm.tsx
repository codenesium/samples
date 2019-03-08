import React, { Component, FormEvent } from 'react';
import axios from 'axios';
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
import { ToLowerCaseFirstLetter } from '../../lib/stringUtilities';
import { ProductModelSelectComponent } from '../shared/productModelSelect';
import { ProductSubcategorySelectComponent } from '../shared/productSubcategorySelect';
import { UnitMeasureSelectComponent } from '../shared/unitMeasureSelect';

interface ProductCreateComponentProps {
  form: WrappedFormUtils;
  history: any;
  match: any;
}

interface ProductCreateComponentState {
  model?: ProductViewModel;
  loading: boolean;
  loaded: boolean;
  errorOccurred: boolean;
  errorMessage: string;
  submitted: boolean;
  submitting: boolean;
}

class ProductCreateComponent extends React.Component<
  ProductCreateComponentProps,
  ProductCreateComponentState
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

  handleSubmit = (e: FormEvent<HTMLFormElement>) => {
    e.preventDefault();
    this.setState({ ...this.state, submitting: true, submitted: false });
    this.props.form.validateFields((err: any, values: any) => {
      if (!err) {
        let model = values as ProductViewModel;
        console.log('Received values of form: ', model);
        this.submit(model);
      } else {
        this.setState({ ...this.state, submitting: false, submitted: false });
      }
    });
  };

  submit = (model: ProductViewModel) => {
    let mapper = new ProductMapper();
    axios
      .post(
        Constants.ApiEndpoint + ApiRoutes.Products,
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
            Api.ProductClientRequestModel
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
            <label htmlFor="color">Color</label>
            <br />
            {getFieldDecorator('color', {
              rules: [{ max: 15, message: 'Exceeds max length of 15' }],
            })(<DatePicker format={'YYYY-MM-DD'} placeholder={'Color'} />)}
          </Form.Item>

          <Form.Item>
            <label htmlFor="daysToManufacture">DaysToManufacture</label>
            <br />
            {getFieldDecorator('daysToManufacture', {
              rules: [{ required: true, message: 'Required' }],
            })(
              <DatePicker
                format={'YYYY-MM-DD'}
                placeholder={'DaysToManufacture'}
              />
            )}
          </Form.Item>

          <Form.Item>
            <label htmlFor="discontinuedDate">DiscontinuedDate</label>
            <br />
            {getFieldDecorator('discontinuedDate', {
              rules: [],
            })(
              <DatePicker
                format={'YYYY-MM-DD'}
                placeholder={'DiscontinuedDate'}
              />
            )}
          </Form.Item>

          <Form.Item>
            <label htmlFor="finishedGoodsFlag">FinishedGoodsFlag</label>
            <br />
            {getFieldDecorator('finishedGoodsFlag', {
              rules: [{ required: true, message: 'Required' }],
            })(
              <DatePicker
                format={'YYYY-MM-DD'}
                placeholder={'FinishedGoodsFlag'}
              />
            )}
          </Form.Item>

          <Form.Item>
            <label htmlFor="listPrice">ListPrice</label>
            <br />
            {getFieldDecorator('listPrice', {
              rules: [{ required: true, message: 'Required' }],
            })(<DatePicker format={'YYYY-MM-DD'} placeholder={'ListPrice'} />)}
          </Form.Item>

          <Form.Item>
            <label htmlFor="makeFlag">MakeFlag</label>
            <br />
            {getFieldDecorator('makeFlag', {
              rules: [{ required: true, message: 'Required' }],
            })(<DatePicker format={'YYYY-MM-DD'} placeholder={'MakeFlag'} />)}
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
            <label htmlFor="productLine">ProductLine</label>
            <br />
            {getFieldDecorator('productLine', {
              rules: [{ max: 2, message: 'Exceeds max length of 2' }],
            })(
              <DatePicker format={'YYYY-MM-DD'} placeholder={'ProductLine'} />
            )}
          </Form.Item>

          <Form.Item>
            <label htmlFor="productModelID">ProductModelID</label>
            <br />
            {getFieldDecorator('productModelID', {
              rules: [],
            })(
              <DatePicker
                format={'YYYY-MM-DD'}
                placeholder={'ProductModelID'}
              />
            )}
          </Form.Item>

          <Form.Item>
            <label htmlFor="productNumber">ProductNumber</label>
            <br />
            {getFieldDecorator('productNumber', {
              rules: [
                { required: true, message: 'Required' },
                { max: 25, message: 'Exceeds max length of 25' },
              ],
            })(
              <DatePicker format={'YYYY-MM-DD'} placeholder={'ProductNumber'} />
            )}
          </Form.Item>

          <Form.Item>
            <label htmlFor="productSubcategoryID">ProductSubcategoryID</label>
            <br />
            {getFieldDecorator('productSubcategoryID', {
              rules: [],
            })(
              <DatePicker
                format={'YYYY-MM-DD'}
                placeholder={'ProductSubcategoryID'}
              />
            )}
          </Form.Item>

          <Form.Item>
            <label htmlFor="reorderPoint">ReorderPoint</label>
            <br />
            {getFieldDecorator('reorderPoint', {
              rules: [{ required: true, message: 'Required' }],
            })(
              <DatePicker format={'YYYY-MM-DD'} placeholder={'ReorderPoint'} />
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
            <label htmlFor="safetyStockLevel">SafetyStockLevel</label>
            <br />
            {getFieldDecorator('safetyStockLevel', {
              rules: [{ required: true, message: 'Required' }],
            })(
              <DatePicker
                format={'YYYY-MM-DD'}
                placeholder={'SafetyStockLevel'}
              />
            )}
          </Form.Item>

          <Form.Item>
            <label htmlFor="sellEndDate">SellEndDate</label>
            <br />
            {getFieldDecorator('sellEndDate', {
              rules: [],
            })(
              <DatePicker format={'YYYY-MM-DD'} placeholder={'SellEndDate'} />
            )}
          </Form.Item>

          <Form.Item>
            <label htmlFor="sellStartDate">SellStartDate</label>
            <br />
            {getFieldDecorator('sellStartDate', {
              rules: [{ required: true, message: 'Required' }],
            })(
              <DatePicker format={'YYYY-MM-DD'} placeholder={'SellStartDate'} />
            )}
          </Form.Item>

          <Form.Item>
            <label htmlFor="size">Size</label>
            <br />
            {getFieldDecorator('size', {
              rules: [{ max: 5, message: 'Exceeds max length of 5' }],
            })(<DatePicker format={'YYYY-MM-DD'} placeholder={'Size'} />)}
          </Form.Item>

          <Form.Item>
            <label htmlFor="sizeUnitMeasureCode">SizeUnitMeasureCode</label>
            <br />
            {getFieldDecorator('sizeUnitMeasureCode', {
              rules: [{ max: 3, message: 'Exceeds max length of 3' }],
            })(
              <DatePicker
                format={'YYYY-MM-DD'}
                placeholder={'SizeUnitMeasureCode'}
              />
            )}
          </Form.Item>

          <Form.Item>
            <label htmlFor="standardCost">StandardCost</label>
            <br />
            {getFieldDecorator('standardCost', {
              rules: [{ required: true, message: 'Required' }],
            })(
              <DatePicker format={'YYYY-MM-DD'} placeholder={'StandardCost'} />
            )}
          </Form.Item>

          <Form.Item>
            <label htmlFor="style">Style</label>
            <br />
            {getFieldDecorator('style', {
              rules: [{ max: 2, message: 'Exceeds max length of 2' }],
            })(<DatePicker format={'YYYY-MM-DD'} placeholder={'Style'} />)}
          </Form.Item>

          <Form.Item>
            <label htmlFor="weight">Weight</label>
            <br />
            {getFieldDecorator('weight', {
              rules: [],
            })(<DatePicker format={'YYYY-MM-DD'} placeholder={'Weight'} />)}
          </Form.Item>

          <Form.Item>
            <label htmlFor="weightUnitMeasureCode">WeightUnitMeasureCode</label>
            <br />
            {getFieldDecorator('weightUnitMeasureCode', {
              rules: [{ max: 3, message: 'Exceeds max length of 3' }],
            })(
              <DatePicker
                format={'YYYY-MM-DD'}
                placeholder={'WeightUnitMeasureCode'}
              />
            )}
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

export const WrappedProductCreateComponent = Form.create({
  name: 'Product Create',
})(ProductCreateComponent);


/*<Codenesium>
    <Hash>51edacb8ea89612af369b230b8e7fa78</Hash>
</Codenesium>*/