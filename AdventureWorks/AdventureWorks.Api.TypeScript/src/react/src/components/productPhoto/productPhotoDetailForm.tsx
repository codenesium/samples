import React, { Component, FormEvent } from 'react';
import axios, { AxiosError, AxiosResponse } from 'axios';
import { Constants, ApiRoutes, ClientRoutes } from '../../constants';
import * as Api from '../../api/models';
import ProductPhotoMapper from './productPhotoMapper';
import ProductPhotoViewModel from './productPhotoViewModel';
import { Form, Input, Button, Spin, Alert } from 'antd';
import { WrappedFormUtils } from 'antd/es/form/Form';
import * as GlobalUtilities from '../../lib/globalUtilities';
import { ProductProductPhotoTableComponent } from '../shared/productProductPhotoTable';

interface ProductPhotoDetailComponentProps {
  form: WrappedFormUtils;
  history: any;
  match: any;
}

interface ProductPhotoDetailComponentState {
  model?: ProductPhotoViewModel;
  loading: boolean;
  loaded: boolean;
  errorOccurred: boolean;
  errorMessage: string;
}

class ProductPhotoDetailComponent extends React.Component<
  ProductPhotoDetailComponentProps,
  ProductPhotoDetailComponentState
> {
  state = {
    model: new ProductPhotoViewModel(),
    loading: false,
    loaded: true,
    errorOccurred: false,
    errorMessage: '',
  };

  handleEditClick(e: any) {
    this.props.history.push(
      ClientRoutes.ProductPhotoes + '/edit/' + this.state.model!.productPhotoID
    );
  }

  componentDidMount() {
    this.setState({ ...this.state, loading: true });

    axios
      .get<Api.ProductPhotoClientResponseModel>(
        Constants.ApiEndpoint +
          ApiRoutes.ProductPhotoes +
          '/' +
          this.props.match.params.id,
        {
          headers: GlobalUtilities.defaultHeaders(),
        }
      )
      .then(response => {
        GlobalUtilities.logInfo(response);

        let mapper = new ProductPhotoMapper();

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
              <h3>Large Photo</h3>
              <p>{String(this.state.model!.largePhoto)}</p>
            </div>
            <div>
              <h3>Large Photo File Name</h3>
              <p>{String(this.state.model!.largePhotoFileName)}</p>
            </div>
            <div>
              <h3>Modified Date</h3>
              <p>{String(this.state.model!.modifiedDate)}</p>
            </div>
            <div>
              <h3>Thumb Nail Photo</h3>
              <p>{String(this.state.model!.thumbNailPhoto)}</p>
            </div>
            <div>
              <h3>Thumbnail Photo File Name</h3>
              <p>{String(this.state.model!.thumbnailPhotoFileName)}</p>
            </div>
          </div>
          {message}
          <div>
            <h3>ProductProductPhotoes</h3>
            <ProductProductPhotoTableComponent
              history={this.props.history}
              match={this.props.match}
              apiRoute={
                Constants.ApiEndpoint +
                ApiRoutes.ProductPhotoes +
                '/' +
                this.state.model!.productPhotoID +
                '/' +
                ApiRoutes.ProductProductPhotoes
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

export const WrappedProductPhotoDetailComponent = Form.create({
  name: 'ProductPhoto Detail',
})(ProductPhotoDetailComponent);


/*<Codenesium>
    <Hash>3e412e44ad04524abd1f05b6c4da9c93</Hash>
</Codenesium>*/