import React, { Component, FormEvent } from 'react';
import axios from 'axios';
import { Constants, ApiRoutes, ClientRoutes } from '../../constants';
import * as Api from '../../api/models';
import ProductMapper from './productMapper';
import ProductViewModel from './productViewModel';
import { Form, Input, Button, Spin, Alert } from 'antd';
import { WrappedFormUtils } from 'antd/es/form/Form';

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
      .get(
        Constants.ApiEndpoint +
          ApiRoutes.Products +
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
          let response = resp.data as Api.ProductClientResponseModel;

          console.log(response);

          let mapper = new ProductMapper();

          this.setState({
            model: mapper.mapApiResponseToViewModel(response),
            loading: false,
            loaded: true,
            errorOccurred: false,
            errorMessage: '',
          });
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
              <h3>Color</h3>
              <p>{String(this.state.model!.color)}</p>
            </div>
            <div>
              <h3>DaysToManufacture</h3>
              <p>{String(this.state.model!.daysToManufacture)}</p>
            </div>
            <div>
              <h3>DiscontinuedDate</h3>
              <p>{String(this.state.model!.discontinuedDate)}</p>
            </div>
            <div>
              <h3>FinishedGoodsFlag</h3>
              <p>{String(this.state.model!.finishedGoodsFlag)}</p>
            </div>
            <div>
              <h3>ListPrice</h3>
              <p>{String(this.state.model!.listPrice)}</p>
            </div>
            <div>
              <h3>MakeFlag</h3>
              <p>{String(this.state.model!.makeFlag)}</p>
            </div>
            <div>
              <h3>ModifiedDate</h3>
              <p>{String(this.state.model!.modifiedDate)}</p>
            </div>
            <div>
              <h3>Name</h3>
              <p>{String(this.state.model!.name)}</p>
            </div>
            <div>
              <h3>ProductID</h3>
              <p>{String(this.state.model!.productID)}</p>
            </div>
            <div>
              <h3>ProductLine</h3>
              <p>{String(this.state.model!.productLine)}</p>
            </div>
            <div>
              <h3>ProductModelID</h3>
              <p>{String(this.state.model!.productModelID)}</p>
            </div>
            <div>
              <h3>ProductNumber</h3>
              <p>{String(this.state.model!.productNumber)}</p>
            </div>
            <div>
              <h3>ProductSubcategoryID</h3>
              <p>{String(this.state.model!.productSubcategoryID)}</p>
            </div>
            <div>
              <h3>ReorderPoint</h3>
              <p>{String(this.state.model!.reorderPoint)}</p>
            </div>
            <div>
              <h3>rowguid</h3>
              <p>{String(this.state.model!.rowguid)}</p>
            </div>
            <div>
              <h3>SafetyStockLevel</h3>
              <p>{String(this.state.model!.safetyStockLevel)}</p>
            </div>
            <div>
              <h3>SellEndDate</h3>
              <p>{String(this.state.model!.sellEndDate)}</p>
            </div>
            <div>
              <h3>SellStartDate</h3>
              <p>{String(this.state.model!.sellStartDate)}</p>
            </div>
            <div>
              <h3>Size</h3>
              <p>{String(this.state.model!.size)}</p>
            </div>
            <div>
              <h3>SizeUnitMeasureCode</h3>
              <p>{String(this.state.model!.sizeUnitMeasureCode)}</p>
            </div>
            <div>
              <h3>StandardCost</h3>
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
            <div>
              <h3>WeightUnitMeasureCode</h3>
              <p>{String(this.state.model!.weightUnitMeasureCode)}</p>
            </div>
          </div>
          {message}
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
    <Hash>f35f032c6d69cddf372845ae96d81d72</Hash>
</Codenesium>*/