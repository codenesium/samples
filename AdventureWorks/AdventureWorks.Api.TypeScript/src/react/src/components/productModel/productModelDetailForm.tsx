import React, { Component, FormEvent } from 'react';
import axios, { AxiosError, AxiosResponse } from 'axios';
import { Constants, ApiRoutes, ClientRoutes } from '../../constants';
import * as Api from '../../api/models';
import ProductModelMapper from './productModelMapper';
import ProductModelViewModel from './productModelViewModel';
import { Form, Input, Button, Spin, Alert } from 'antd';
import { WrappedFormUtils } from 'antd/es/form/Form';
import * as GlobalUtilities from '../../lib/globalUtilities';
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
      .get<Api.ProductModelClientResponseModel>(
        Constants.ApiEndpoint +
          ApiRoutes.ProductModels +
          '/' +
          this.props.match.params.id,
        {
          headers: GlobalUtilities.defaultHeaders(),
        }
      )
      .then(response => {
        GlobalUtilities.logInfo(response);

        let mapper = new ProductModelMapper();

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
              <h3>Catalog Description</h3>
              <p>{String(this.state.model!.catalogDescription)}</p>
            </div>
            <div>
              <h3>Instructions</h3>
              <p>{String(this.state.model!.instruction)}</p>
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
              <h3>Rowguid</h3>
              <p>{String(this.state.model!.rowguid)}</p>
            </div>
          </div>
          {message}
          <div>
            <h3>Products</h3>
            <ProductTableComponent
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
    <Hash>1538b61a9c0084d20179b0f71edbdf0d</Hash>
</Codenesium>*/