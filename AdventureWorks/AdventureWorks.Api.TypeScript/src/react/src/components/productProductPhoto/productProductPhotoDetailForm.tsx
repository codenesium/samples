import React, { Component, FormEvent } from 'react';
import axios, { AxiosError, AxiosResponse } from 'axios';
import { Constants, ApiRoutes, ClientRoutes } from '../../constants';
import * as Api from '../../api/models';
import ProductProductPhotoMapper from './productProductPhotoMapper';
import ProductProductPhotoViewModel from './productProductPhotoViewModel';
import { Form, Input, Button, Spin, Alert } from 'antd';
import { WrappedFormUtils } from 'antd/es/form/Form';
import * as GlobalUtilities from '../../lib/globalUtilities';

interface ProductProductPhotoDetailComponentProps {
  form: WrappedFormUtils;
  history: any;
  match: any;
}

interface ProductProductPhotoDetailComponentState {
  model?: ProductProductPhotoViewModel;
  loading: boolean;
  loaded: boolean;
  errorOccurred: boolean;
  errorMessage: string;
}

class ProductProductPhotoDetailComponent extends React.Component<
  ProductProductPhotoDetailComponentProps,
  ProductProductPhotoDetailComponentState
> {
  state = {
    model: new ProductProductPhotoViewModel(),
    loading: false,
    loaded: true,
    errorOccurred: false,
    errorMessage: '',
  };

  handleEditClick(e: any) {
    this.props.history.push(
      ClientRoutes.ProductProductPhotoes +
        '/edit/' +
        this.state.model!.productID
    );
  }

  componentDidMount() {
    this.setState({ ...this.state, loading: true });

    axios
      .get<Api.ProductProductPhotoClientResponseModel>(
        Constants.ApiEndpoint +
          ApiRoutes.ProductProductPhotoes +
          '/' +
          this.props.match.params.id,
        {
          headers: GlobalUtilities.defaultHeaders(),
        }
      )
      .then(response => {
        GlobalUtilities.logInfo(response);

        let mapper = new ProductProductPhotoMapper();

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
              <h3>Primary</h3>
              <p>{String(this.state.model!.primary)}</p>
            </div>
            <div style={{ marginBottom: '10px' }}>
              <h3>Product I D</h3>
              <p>
                {String(
                  this.state.model!.productIDNavigation &&
                    this.state.model!.productIDNavigation!.toDisplay()
                )}
              </p>
            </div>
            <div style={{ marginBottom: '10px' }}>
              <h3>Product Photo I D</h3>
              <p>
                {String(
                  this.state.model!.productPhotoIDNavigation &&
                    this.state.model!.productPhotoIDNavigation!.toDisplay()
                )}
              </p>
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

export const WrappedProductProductPhotoDetailComponent = Form.create({
  name: 'ProductProductPhoto Detail',
})(ProductProductPhotoDetailComponent);


/*<Codenesium>
    <Hash>f084d1fc3cc15edc01ddf97f34858fca</Hash>
</Codenesium>*/