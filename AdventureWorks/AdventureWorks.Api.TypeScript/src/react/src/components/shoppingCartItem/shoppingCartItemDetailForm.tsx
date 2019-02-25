import React, { Component, FormEvent } from 'react';
import axios from 'axios';
import { Constants, ApiRoutes, ClientRoutes } from '../../constants';
import * as Api from '../../api/models';
import ShoppingCartItemMapper from './shoppingCartItemMapper';
import ShoppingCartItemViewModel from './shoppingCartItemViewModel';
import { Form, Input, Button, Spin, Alert } from 'antd';
import { WrappedFormUtils } from 'antd/es/form/Form';

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
      .get(
        Constants.ApiEndpoint +
          ApiRoutes.ShoppingCartItems +
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
          let response = resp.data as Api.ShoppingCartItemClientResponseModel;

          console.log(response);

          let mapper = new ShoppingCartItemMapper();

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
              <h3>DateCreated</h3>
              <p>{String(this.state.model!.dateCreated)}</p>
            </div>
            <div>
              <h3>ModifiedDate</h3>
              <p>{String(this.state.model!.modifiedDate)}</p>
            </div>
            <div>
              <h3>ProductID</h3>
              <p>{String(this.state.model!.productID)}</p>
            </div>
            <div>
              <h3>Quantity</h3>
              <p>{String(this.state.model!.quantity)}</p>
            </div>
            <div>
              <h3>ShoppingCartID</h3>
              <p>{String(this.state.model!.shoppingCartID)}</p>
            </div>
            <div>
              <h3>ShoppingCartItemID</h3>
              <p>{String(this.state.model!.shoppingCartItemID)}</p>
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
    <Hash>43b6a606e26aad404fccce2254b18ff9</Hash>
</Codenesium>*/