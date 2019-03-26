import React, { Component, FormEvent } from 'react';
import axios, { AxiosError, AxiosResponse } from 'axios';
import { Constants, ApiRoutes, ClientRoutes } from '../../constants';
import * as Api from '../../api/models';
import ProductMapper from './productMapper';
import ProductViewModel from './productViewModel';
import { Form, Input, Button, Spin, Alert } from 'antd';
import { WrappedFormUtils } from 'antd/es/form/Form';
import * as GlobalUtilities from '../../lib/globalUtilities';
import { BillOfMaterialTableComponent } from '../shared/billOfMaterialTable';
import { ProductCostHistoryTableComponent } from '../shared/productCostHistoryTable';
import { ProductDocumentTableComponent } from '../shared/productDocumentTable';
import { ProductInventoryTableComponent } from '../shared/productInventoryTable';
import { ProductListPriceHistoryTableComponent } from '../shared/productListPriceHistoryTable';
import { ProductProductPhotoTableComponent } from '../shared/productProductPhotoTable';
import { ProductReviewTableComponent } from '../shared/productReviewTable';
import { TransactionHistoryTableComponent } from '../shared/transactionHistoryTable';
import { WorkOrderTableComponent } from '../shared/workOrderTable';

interface ProductDetailComponentProps {
  form: WrappedFormUtils;
  history: any;
  match: any;
}

interface ProductDetailComponentState {
  model?: ProductViewModel;
  loading: boolean;
  loaded: boolean;
  errorOccurred: boolean;
  errorMessage: string;
}

class ProductDetailComponent extends React.Component<
  ProductDetailComponentProps,
  ProductDetailComponentState
> {
  state = {
    model: new ProductViewModel(),
    loading: false,
    loaded: true,
    errorOccurred: false,
    errorMessage: '',
  };

  handleEditClick(e: any) {
    this.props.history.push(
      ClientRoutes.Products + '/edit/' + this.state.model!.productID
    );
  }

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
      })
      .catch((error: AxiosError) => {
        GlobalUtilities.logError(error);

        if (error.response && error.response.status == 422) {
          this.setState({
            ...this.state,
            errorOccurred: false,
            errorMessage: '',
          });
        } else {
          this.setState({
            ...this.state,
            errorOccurred: true,
            errorMessage: 'Error Occurred',
          });
        }
      });
  }

  render() {
    let message: JSX.Element = <div />;
    if (this.state.errorOccurred) {
      message = <Alert message={this.state.errorMessage} type="error" />;
    }

    if (this.state.loading) {
      return <Spin size="large" />;
    } else if (this.state.loaded) {
      return (
        <div>
          <Button
            style={{ float: 'right' }}
            type="primary"
            onClick={(e: any) => {
              this.handleEditClick(e);
            }}
          >
            <i className="fas fa-edit" />
          </Button>
          <div>
            <div>
              <h3>Class</h3>
              <p>{String(this.state.model!.reservedClass)}</p>
            </div>
            <div>
              <h3>Color</h3>
              <p>{String(this.state.model!.color)}</p>
            </div>
            <div>
              <h3>Days To Manufacture</h3>
              <p>{String(this.state.model!.daysToManufacture)}</p>
            </div>
            <div>
              <h3>Discontinued Date</h3>
              <p>{String(this.state.model!.discontinuedDate)}</p>
            </div>
            <div>
              <h3>Finished Goods Flag</h3>
              <p>{String(this.state.model!.finishedGoodsFlag)}</p>
            </div>
            <div>
              <h3>List Price</h3>
              <p>{String(this.state.model!.listPrice)}</p>
            </div>
            <div>
              <h3>Make Flag</h3>
              <p>{String(this.state.model!.makeFlag)}</p>
            </div>
            <div>
              <h3>Modified Date</h3>
              <p>{String(this.state.model!.modifiedDate)}</p>
            </div>
            <div>
              <h3>Name</h3>
              <p>{String(this.state.model!.name)}</p>
            </div>
            <div>
              <h3>Product Line</h3>
              <p>{String(this.state.model!.productLine)}</p>
            </div>
            <div style={{ marginBottom: '10px' }}>
              <h3>Product Model I D</h3>
              <p>
                {String(
                  this.state.model!.productModelIDNavigation &&
                    this.state.model!.productModelIDNavigation!.toDisplay()
                )}
              </p>
            </div>
            <div>
              <h3>Product Number</h3>
              <p>{String(this.state.model!.productNumber)}</p>
            </div>
            <div style={{ marginBottom: '10px' }}>
              <h3>Product Subcategory I D</h3>
              <p>
                {String(
                  this.state.model!.productSubcategoryIDNavigation &&
                    this.state.model!.productSubcategoryIDNavigation!.toDisplay()
                )}
              </p>
            </div>
            <div>
              <h3>Reorder Point</h3>
              <p>{String(this.state.model!.reorderPoint)}</p>
            </div>
            <div>
              <h3>Rowguid</h3>
              <p>{String(this.state.model!.rowguid)}</p>
            </div>
            <div>
              <h3>Safety Stock Level</h3>
              <p>{String(this.state.model!.safetyStockLevel)}</p>
            </div>
            <div>
              <h3>Sell End Date</h3>
              <p>{String(this.state.model!.sellEndDate)}</p>
            </div>
            <div>
              <h3>Sell Start Date</h3>
              <p>{String(this.state.model!.sellStartDate)}</p>
            </div>
            <div>
              <h3>Size</h3>
              <p>{String(this.state.model!.size)}</p>
            </div>
            <div style={{ marginBottom: '10px' }}>
              <h3>Size Unit Measure Code</h3>
              <p>
                {String(
                  this.state.model!.sizeUnitMeasureCodeNavigation &&
                    this.state.model!.sizeUnitMeasureCodeNavigation!.toDisplay()
                )}
              </p>
            </div>
            <div>
              <h3>Standard Cost</h3>
              <p>{String(this.state.model!.standardCost)}</p>
            </div>
            <div>
              <h3>Style</h3>
              <p>{String(this.state.model!.style)}</p>
            </div>
            <div>
              <h3>Weight</h3>
              <p>{String(this.state.model!.weight)}</p>
            </div>
            <div style={{ marginBottom: '10px' }}>
              <h3>Weight Unit Measure Code</h3>
              <p>
                {String(
                  this.state.model!.weightUnitMeasureCodeNavigation &&
                    this.state.model!.weightUnitMeasureCodeNavigation!.toDisplay()
                )}
              </p>
            </div>
          </div>
          {message}
          <div>
            <h3>BillOfMaterials</h3>
            <BillOfMaterialTableComponent
              history={this.props.history}
              match={this.props.match}
              apiRoute={
                Constants.ApiEndpoint +
                ApiRoutes.Products +
                '/' +
                this.state.model!.productID +
                '/' +
                ApiRoutes.BillOfMaterials
              }
            />
          </div>
          <div>
            <h3>ProductCostHistories</h3>
            <ProductCostHistoryTableComponent
              history={this.props.history}
              match={this.props.match}
              apiRoute={
                Constants.ApiEndpoint +
                ApiRoutes.Products +
                '/' +
                this.state.model!.productID +
                '/' +
                ApiRoutes.ProductCostHistories
              }
            />
          </div>
          <div>
            <h3>ProductDocuments</h3>
            <ProductDocumentTableComponent
              history={this.props.history}
              match={this.props.match}
              apiRoute={
                Constants.ApiEndpoint +
                ApiRoutes.Products +
                '/' +
                this.state.model!.productID +
                '/' +
                ApiRoutes.ProductDocuments
              }
            />
          </div>
          <div>
            <h3>ProductInventories</h3>
            <ProductInventoryTableComponent
              history={this.props.history}
              match={this.props.match}
              apiRoute={
                Constants.ApiEndpoint +
                ApiRoutes.Products +
                '/' +
                this.state.model!.productID +
                '/' +
                ApiRoutes.ProductInventories
              }
            />
          </div>
          <div>
            <h3>ProductListPriceHistories</h3>
            <ProductListPriceHistoryTableComponent
              history={this.props.history}
              match={this.props.match}
              apiRoute={
                Constants.ApiEndpoint +
                ApiRoutes.Products +
                '/' +
                this.state.model!.productID +
                '/' +
                ApiRoutes.ProductListPriceHistories
              }
            />
          </div>
          <div>
            <h3>ProductProductPhotoes</h3>
            <ProductProductPhotoTableComponent
              history={this.props.history}
              match={this.props.match}
              apiRoute={
                Constants.ApiEndpoint +
                ApiRoutes.Products +
                '/' +
                this.state.model!.productID +
                '/' +
                ApiRoutes.ProductProductPhotoes
              }
            />
          </div>
          <div>
            <h3>ProductReviews</h3>
            <ProductReviewTableComponent
              history={this.props.history}
              match={this.props.match}
              apiRoute={
                Constants.ApiEndpoint +
                ApiRoutes.Products +
                '/' +
                this.state.model!.productID +
                '/' +
                ApiRoutes.ProductReviews
              }
            />
          </div>
          <div>
            <h3>TransactionHistories</h3>
            <TransactionHistoryTableComponent
              history={this.props.history}
              match={this.props.match}
              apiRoute={
                Constants.ApiEndpoint +
                ApiRoutes.Products +
                '/' +
                this.state.model!.productID +
                '/' +
                ApiRoutes.TransactionHistories
              }
            />
          </div>
          <div>
            <h3>WorkOrders</h3>
            <WorkOrderTableComponent
              history={this.props.history}
              match={this.props.match}
              apiRoute={
                Constants.ApiEndpoint +
                ApiRoutes.Products +
                '/' +
                this.state.model!.productID +
                '/' +
                ApiRoutes.WorkOrders
              }
            />
          </div>
        </div>
      );
    } else {
      return null;
    }
  }
}

export const WrappedProductDetailComponent = Form.create({
  name: 'Product Detail',
})(ProductDetailComponent);


/*<Codenesium>
    <Hash>d88dfb59d6903940f21cc8092afe819c</Hash>
</Codenesium>*/