import React, { Component, FormEvent } from 'react';
import axios from 'axios';
import { Constants, ApiRoutes, ClientRoutes } from '../../constants';
import * as Api from '../../api/models';
import ProductSubcategoryMapper from './productSubcategoryMapper';
import ProductSubcategoryViewModel from './productSubcategoryViewModel';
import { Form, Input, Button, Spin, Alert } from 'antd';
import { WrappedFormUtils } from 'antd/es/form/Form';
import { ProductTableComponent } from '../shared/productTable';

interface ProductSubcategoryDetailComponentProps {
  form: WrappedFormUtils;
  history: any;
  match: any;
}

interface ProductSubcategoryDetailComponentState {
  model?: ProductSubcategoryViewModel;
  loading: boolean;
  loaded: boolean;
  errorOccurred: boolean;
  errorMessage: string;
}

class ProductSubcategoryDetailComponent extends React.Component<
  ProductSubcategoryDetailComponentProps,
  ProductSubcategoryDetailComponentState
> {
  state = {
    model: new ProductSubcategoryViewModel(),
    loading: false,
    loaded: true,
    errorOccurred: false,
    errorMessage: '',
  };

  handleEditClick(e: any) {
    this.props.history.push(
      ClientRoutes.ProductSubcategories +
        '/edit/' +
        this.state.model!.productSubcategoryID
    );
  }

  componentDidMount() {
    this.setState({ ...this.state, loading: true });

    axios
      .get(
        Constants.ApiEndpoint +
          ApiRoutes.ProductSubcategories +
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
          let response = resp.data as Api.ProductSubcategoryClientResponseModel;

          console.log(response);

          let mapper = new ProductSubcategoryMapper();

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
            loaded: true,
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
              <h3>ModifiedDate</h3>
              <p>{String(this.state.model!.modifiedDate)}</p>
            </div>
            <div>
              <h3>Name</h3>
              <p>{String(this.state.model!.name)}</p>
            </div>
            <div style={{ marginBottom: '10px' }}>
              <h3>ProductCategoryID</h3>
              <p>
                {String(
                  this.state.model!.productCategoryIDNavigation!.toDisplay()
                )}
              </p>
            </div>
            <div>
              <h3>ProductSubcategoryID</h3>
              <p>{String(this.state.model!.productSubcategoryID)}</p>
            </div>
            <div>
              <h3>rowguid</h3>
              <p>{String(this.state.model!.rowguid)}</p>
            </div>
          </div>
          {message}
          <div>
            <h3>Products</h3>
            <ProductTableComponent
              productID={this.state.model!.productID}
              history={this.props.history}
              match={this.props.match}
              apiRoute={
                Constants.ApiEndpoint +
                ApiRoutes.ProductSubcategories +
                '/' +
                this.state.model!.productSubcategoryID +
                '/' +
                ApiRoutes.Products
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

export const WrappedProductSubcategoryDetailComponent = Form.create({
  name: 'ProductSubcategory Detail',
})(ProductSubcategoryDetailComponent);


/*<Codenesium>
    <Hash>e2766aead73ada38ee728bd111629b66</Hash>
</Codenesium>*/