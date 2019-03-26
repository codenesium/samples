import React, { Component, FormEvent } from 'react';
import axios, { AxiosError, AxiosResponse } from 'axios';
import { Constants, ApiRoutes, ClientRoutes } from '../../constants';
import * as Api from '../../api/models';
import ProductSubcategoryMapper from './productSubcategoryMapper';
import ProductSubcategoryViewModel from './productSubcategoryViewModel';
import { Form, Input, Button, Spin, Alert } from 'antd';
import { WrappedFormUtils } from 'antd/es/form/Form';
import * as GlobalUtilities from '../../lib/globalUtilities';
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
      .get<Api.ProductSubcategoryClientResponseModel>(
        Constants.ApiEndpoint +
          ApiRoutes.ProductSubcategories +
          '/' +
          this.props.match.params.id,
        {
          headers: GlobalUtilities.defaultHeaders(),
        }
      )
      .then(response => {
        GlobalUtilities.logInfo(response);

        let mapper = new ProductSubcategoryMapper();

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
              <h3>Modified Date</h3>
              <p>{String(this.state.model!.modifiedDate)}</p>
            </div>
            <div>
              <h3>Name</h3>
              <p>{String(this.state.model!.name)}</p>
            </div>
            <div style={{ marginBottom: '10px' }}>
              <h3>Product Category I D</h3>
              <p>
                {String(
                  this.state.model!.productCategoryIDNavigation &&
                    this.state.model!.productCategoryIDNavigation!.toDisplay()
                )}
              </p>
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
    <Hash>47996873e5ac98c78f4c0d6507d85988</Hash>
</Codenesium>*/