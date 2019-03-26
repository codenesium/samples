import React, { Component, FormEvent } from 'react';
import axios, { AxiosError, AxiosResponse } from 'axios';
import { Constants, ApiRoutes, ClientRoutes } from '../../constants';
import * as Api from '../../api/models';
import ProductCategoryMapper from './productCategoryMapper';
import ProductCategoryViewModel from './productCategoryViewModel';
import { Form, Input, Button, Spin, Alert } from 'antd';
import { WrappedFormUtils } from 'antd/es/form/Form';
import * as GlobalUtilities from '../../lib/globalUtilities';
import { ProductSubcategoryTableComponent } from '../shared/productSubcategoryTable';

interface ProductCategoryDetailComponentProps {
  form: WrappedFormUtils;
  history: any;
  match: any;
}

interface ProductCategoryDetailComponentState {
  model?: ProductCategoryViewModel;
  loading: boolean;
  loaded: boolean;
  errorOccurred: boolean;
  errorMessage: string;
}

class ProductCategoryDetailComponent extends React.Component<
  ProductCategoryDetailComponentProps,
  ProductCategoryDetailComponentState
> {
  state = {
    model: new ProductCategoryViewModel(),
    loading: false,
    loaded: true,
    errorOccurred: false,
    errorMessage: '',
  };

  handleEditClick(e: any) {
    this.props.history.push(
      ClientRoutes.ProductCategories +
        '/edit/' +
        this.state.model!.productCategoryID
    );
  }

  componentDidMount() {
    this.setState({ ...this.state, loading: true });

    axios
      .get<Api.ProductCategoryClientResponseModel>(
        Constants.ApiEndpoint +
          ApiRoutes.ProductCategories +
          '/' +
          this.props.match.params.id,
        {
          headers: GlobalUtilities.defaultHeaders(),
        }
      )
      .then(response => {
        GlobalUtilities.logInfo(response);

        let mapper = new ProductCategoryMapper();

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
            <div>
              <h3>Rowguid</h3>
              <p>{String(this.state.model!.rowguid)}</p>
            </div>
          </div>
          {message}
          <div>
            <h3>ProductSubcategories</h3>
            <ProductSubcategoryTableComponent
              history={this.props.history}
              match={this.props.match}
              apiRoute={
                Constants.ApiEndpoint +
                ApiRoutes.ProductCategories +
                '/' +
                this.state.model!.productCategoryID +
                '/' +
                ApiRoutes.ProductSubcategories
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

export const WrappedProductCategoryDetailComponent = Form.create({
  name: 'ProductCategory Detail',
})(ProductCategoryDetailComponent);


/*<Codenesium>
    <Hash>299054b1057bc18aafd718df5b7d7aa3</Hash>
</Codenesium>*/