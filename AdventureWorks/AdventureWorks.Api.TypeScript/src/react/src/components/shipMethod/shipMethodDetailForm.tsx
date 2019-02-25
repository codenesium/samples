import React, { Component, FormEvent } from 'react';
import axios from 'axios';
import { Constants, ApiRoutes, ClientRoutes } from '../../constants';
import * as Api from '../../api/models';
import ShipMethodMapper from './shipMethodMapper';
import ShipMethodViewModel from './shipMethodViewModel';
import { Form, Input, Button, Spin, Alert } from 'antd';
import { WrappedFormUtils } from 'antd/es/form/Form';
import { PurchaseOrderHeaderTableComponent } from '../shared/purchaseOrderHeaderTable';

interface ShipMethodDetailComponentProps {
  form: WrappedFormUtils;
  history: any;
  match: any;
}

interface ShipMethodDetailComponentState {
  model?: ShipMethodViewModel;
  loading: boolean;
  loaded: boolean;
  errorOccurred: boolean;
  errorMessage: string;
}

class ShipMethodDetailComponent extends React.Component<
  ShipMethodDetailComponentProps,
  ShipMethodDetailComponentState
> {
  state = {
    model: new ShipMethodViewModel(),
    loading: false,
    loaded: true,
    errorOccurred: false,
    errorMessage: '',
  };

  handleEditClick(e: any) {
    this.props.history.push(
      ClientRoutes.ShipMethods + '/edit/' + this.state.model!.shipMethodID
    );
  }

  componentDidMount() {
    this.setState({ ...this.state, loading: true });

    axios
      .get(
        Constants.ApiEndpoint +
          ApiRoutes.ShipMethods +
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
          let response = resp.data as Api.ShipMethodClientResponseModel;

          console.log(response);

          let mapper = new ShipMethodMapper();

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
              <h3>ModifiedDate</h3>
              <p>{String(this.state.model!.modifiedDate)}</p>
            </div>
            <div>
              <h3>Name</h3>
              <p>{String(this.state.model!.name)}</p>
            </div>
            <div>
              <h3>rowguid</h3>
              <p>{String(this.state.model!.rowguid)}</p>
            </div>
            <div>
              <h3>ShipBase</h3>
              <p>{String(this.state.model!.shipBase)}</p>
            </div>
            <div>
              <h3>ShipMethodID</h3>
              <p>{String(this.state.model!.shipMethodID)}</p>
            </div>
            <div>
              <h3>ShipRate</h3>
              <p>{String(this.state.model!.shipRate)}</p>
            </div>
          </div>
          {message}
          <div>
            <h3>PurchaseOrderHeaders</h3>
            <PurchaseOrderHeaderTableComponent
              purchaseOrderID={this.state.model!.purchaseOrderID}
              history={this.props.history}
              match={this.props.match}
              apiRoute={
                Constants.ApiEndpoint +
                ApiRoutes.ShipMethods +
                '/' +
                this.state.model!.shipMethodID +
                '/' +
                ApiRoutes.PurchaseOrderHeaders
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

export const WrappedShipMethodDetailComponent = Form.create({
  name: 'ShipMethod Detail',
})(ShipMethodDetailComponent);


/*<Codenesium>
    <Hash>fc184043594c48a180303fbe8ca9e7f0</Hash>
</Codenesium>*/