import React, { Component, FormEvent } from 'react';
import axios from 'axios';
import { Constants, ApiRoutes, ClientRoutes } from '../../constants';
import * as Api from '../../api/models';
import ProductModelMapper from './productModelMapper';
import ProductModelViewModel from './productModelViewModel';
import { Form, Input, Button, Spin, Alert } from 'antd';
import { WrappedFormUtils } from 'antd/es/form/Form';
import { ProductTableComponent } from '../shared/productTable';
import { ProductModelIllustrationTableComponent } from '../shared/productModelIllustrationTable';
import { ProductModelProductDescriptionCultureTableComponent } from '../shared/productModelProductDescriptionCultureTable';

interface ProductModelDetailComponentProps {
  form: WrappedFormUtils;
  history: any;
  match: any;
}

interface ProductModelDetailComponentState {
  model?: ProductModelViewModel;
  loading: boolean;
  loaded: boolean;
  errorOccurred: boolean;
  errorMessage: string;
}

class ProductModelDetailComponent extends React.Component<
  ProductModelDetailComponentProps,
  ProductModelDetailComponentState
> {
  state = {
    model: new ProductModelViewModel(),
    loading: false,
    loaded: true,
    errorOccurred: false,
    errorMessage: '',
  };

  handleEditClick(e: any) {
    this.props.history.push(
      ClientRoutes.ProductModels + '/edit/' + this.state.model!.productModelID
    );
  }

  componentDidMount() {
    this.setState({ ...this.state, loading: true });

    axios
      .get(
        Constants.ApiEndpoint +
          ApiRoutes.ProductModels +
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
          let response = resp.data as Api.ProductModelClientResponseModel;

          console.log(response);

          let mapper = new ProductModelMapper();

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
              <h3>CatalogDescription</h3>
              <p>{String(this.state.model!.catalogDescription)}</p>
            </div>
            <div>
              <h3>Instructions</h3>
              <p>{String(this.state.model!.instruction)}</p>
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
              <h3>ProductModelID</h3>
              <p>{String(this.state.model!.productModelID)}</p>
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
                ApiRoutes.ProductModels +
                '/' +
                this.state.model!.productModelID +
                '/' +
                ApiRoutes.Products
              }
            />
          </div>
          <div>
            <h3>ProductModelIllustrations</h3>
            <ProductModelIllustrationTableComponent
              productModelID={this.state.model!.productModelID}
              history={this.props.history}
              match={this.props.match}
              apiRoute={
                Constants.ApiEndpoint +
                ApiRoutes.ProductModels +
                '/' +
                this.state.model!.productModelID +
                '/' +
                ApiRoutes.ProductModelIllustrations
              }
            />
          </div>
          <div>
            <h3>ProductModelProductDescriptionCultures</h3>
            <ProductModelProductDescriptionCultureTableComponent
              productModelID={this.state.model!.productModelID}
              history={this.props.history}
              match={this.props.match}
              apiRoute={
                Constants.ApiEndpoint +
                ApiRoutes.ProductModels +
                '/' +
                this.state.model!.productModelID +
                '/' +
                ApiRoutes.ProductModelProductDescriptionCultures
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

export const WrappedProductModelDetailComponent = Form.create({
  name: 'ProductModel Detail',
})(ProductModelDetailComponent);


/*<Codenesium>
    <Hash>aace4ada5917ec0eeceb31fdb4910e79</Hash>
</Codenesium>*/