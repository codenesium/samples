import React, { Component, FormEvent } from 'react';
import axios from 'axios';
import { Constants, ApiRoutes, ClientRoutes } from '../../constants';
import * as Api from '../../api/models';
import ProductPhotoMapper from './productPhotoMapper';
import ProductPhotoViewModel from './productPhotoViewModel';
import { Form, Input, Button, Spin, Alert } from 'antd';
import { WrappedFormUtils } from 'antd/es/form/Form';

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
      .get(
        Constants.ApiEndpoint +
          ApiRoutes.ProductPhotoes +
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
          let response = resp.data as Api.ProductPhotoClientResponseModel;

          console.log(response);

          let mapper = new ProductPhotoMapper();

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
              <h3>LargePhoto</h3>
              <p>{String(this.state.model!.largePhoto)}</p>
            </div>
            <div>
              <h3>LargePhotoFileName</h3>
              <p>{String(this.state.model!.largePhotoFileName)}</p>
            </div>
            <div>
              <h3>ModifiedDate</h3>
              <p>{String(this.state.model!.modifiedDate)}</p>
            </div>
            <div>
              <h3>ProductPhotoID</h3>
              <p>{String(this.state.model!.productPhotoID)}</p>
            </div>
            <div>
              <h3>ThumbNailPhoto</h3>
              <p>{String(this.state.model!.thumbNailPhoto)}</p>
            </div>
            <div>
              <h3>ThumbnailPhotoFileName</h3>
              <p>{String(this.state.model!.thumbnailPhotoFileName)}</p>
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

export const WrappedProductPhotoDetailComponent = Form.create({
  name: 'ProductPhoto Detail',
})(ProductPhotoDetailComponent);


/*<Codenesium>
    <Hash>2a0c8754de28165292a430c86b32e0e0</Hash>
</Codenesium>*/