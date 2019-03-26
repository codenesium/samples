import React, { Component, FormEvent } from 'react';
import axios, { AxiosError, AxiosResponse } from 'axios';
import { Constants, ApiRoutes, ClientRoutes } from '../../constants';
import * as Api from '../../api/models';
import ShoppingCartItemMapper from './shoppingCartItemMapper';
import ShoppingCartItemViewModel from './shoppingCartItemViewModel';
import { Form, Input, Button, Spin, Alert } from 'antd';
import { WrappedFormUtils } from 'antd/es/form/Form';
import * as GlobalUtilities from '../../lib/globalUtilities';

interface ShoppingCartItemDetailComponentProps {
  form: WrappedFormUtils;
  history: any;
  match: any;
}

interface ShoppingCartItemDetailComponentState {
  model?: ShoppingCartItemViewModel;
  loading: boolean;
  loaded: boolean;
  errorOccurred: boolean;
  errorMessage: string;
}

class ShoppingCartItemDetailComponent extends React.Component<
  ShoppingCartItemDetailComponentProps,
  ShoppingCartItemDetailComponentState
> {
  state = {
    model: new ShoppingCartItemViewModel(),
    loading: false,
    loaded: true,
    errorOccurred: false,
    errorMessage: '',
  };

  handleEditClick(e: any) {
    this.props.history.push(
      ClientRoutes.ShoppingCartItems +
        '/edit/' +
        this.state.model!.shoppingCartItemID
    );
  }

  componentDidMount() {
    this.setState({ ...this.state, loading: true });

    axios
      .get<Api.ShoppingCartItemClientResponseModel>(
        Constants.ApiEndpoint +
          ApiRoutes.ShoppingCartItems +
          '/' +
          this.props.match.params.id,
        {
          headers: GlobalUtilities.defaultHeaders(),
        }
      )
      .then(response => {
        GlobalUtilities.logInfo(response);

        let mapper = new ShoppingCartItemMapper();

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
              <h3>Date Created</h3>
              <p>{String(this.state.model!.dateCreated)}</p>
            </div>
            <div>
              <h3>Modified Date</h3>
              <p>{String(this.state.model!.modifiedDate)}</p>
            </div>
            <div>
              <h3>Product I D</h3>
              <p>{String(this.state.model!.productID)}</p>
            </div>
            <div>
              <h3>Quantity</h3>
              <p>{String(this.state.model!.quantity)}</p>
            </div>
            <div>
              <h3>Shopping Cart I D</h3>
              <p>{String(this.state.model!.shoppingCartID)}</p>
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

export const WrappedShoppingCartItemDetailComponent = Form.create({
  name: 'ShoppingCartItem Detail',
})(ShoppingCartItemDetailComponent);


/*<Codenesium>
    <Hash>92640bcf38f8f034349db66f4e382a85</Hash>
</Codenesium>*/