import React, { Component, FormEvent } from 'react';
import axios, { AxiosError, AxiosResponse } from 'axios';
import { Constants, ApiRoutes, ClientRoutes } from '../../constants';
import * as Api from '../../api/models';
import ProductDescriptionMapper from './productDescriptionMapper';
import ProductDescriptionViewModel from './productDescriptionViewModel';
import { Form, Input, Button, Spin, Alert } from 'antd';
import { WrappedFormUtils } from 'antd/es/form/Form';
import * as GlobalUtilities from '../../lib/globalUtilities';
import { ProductModelProductDescriptionCultureTableComponent } from '../shared/productModelProductDescriptionCultureTable';

interface ProductDescriptionDetailComponentProps {
  form: WrappedFormUtils;
  history: any;
  match: any;
}

interface ProductDescriptionDetailComponentState {
  model?: ProductDescriptionViewModel;
  loading: boolean;
  loaded: boolean;
  errorOccurred: boolean;
  errorMessage: string;
}

class ProductDescriptionDetailComponent extends React.Component<
  ProductDescriptionDetailComponentProps,
  ProductDescriptionDetailComponentState
> {
  state = {
    model: new ProductDescriptionViewModel(),
    loading: false,
    loaded: true,
    errorOccurred: false,
    errorMessage: '',
  };

  handleEditClick(e: any) {
    this.props.history.push(
      ClientRoutes.ProductDescriptions +
        '/edit/' +
        this.state.model!.productDescriptionID
    );
  }

  componentDidMount() {
    this.setState({ ...this.state, loading: true });

    axios
      .get<Api.ProductDescriptionClientResponseModel>(
        Constants.ApiEndpoint +
          ApiRoutes.ProductDescriptions +
          '/' +
          this.props.match.params.id,
        {
          headers: GlobalUtilities.defaultHeaders(),
        }
      )
      .then(response => {
        GlobalUtilities.logInfo(response);

        let mapper = new ProductDescriptionMapper();

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
              <h3>Description</h3>
              <p>{String(this.state.model!.description)}</p>
            </div>
            <div>
              <h3>Modified Date</h3>
              <p>{String(this.state.model!.modifiedDate)}</p>
            </div>
            <div>
              <h3>Rowguid</h3>
              <p>{String(this.state.model!.rowguid)}</p>
            </div>
          </div>
          {message}
          <div>
            <h3>ProductModelProductDescriptionCultures</h3>
            <ProductModelProductDescriptionCultureTableComponent
              history={this.props.history}
              match={this.props.match}
              apiRoute={
                Constants.ApiEndpoint +
                ApiRoutes.ProductDescriptions +
                '/' +
                this.state.model!.productDescriptionID +
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

export const WrappedProductDescriptionDetailComponent = Form.create({
  name: 'ProductDescription Detail',
})(ProductDescriptionDetailComponent);


/*<Codenesium>
    <Hash>4fcf3196d49fcbdf860c6dd42c1f3d00</Hash>
</Codenesium>*/