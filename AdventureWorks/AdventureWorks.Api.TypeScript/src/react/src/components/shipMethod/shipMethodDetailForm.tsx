import React, { Component, FormEvent } from 'react';
import axios, { AxiosError, AxiosResponse } from 'axios';
import { Constants, ApiRoutes, ClientRoutes } from '../../constants';
import * as Api from '../../api/models';
import ShipMethodMapper from './shipMethodMapper';
import ShipMethodViewModel from './shipMethodViewModel';
import { Form, Input, Button, Spin, Alert } from 'antd';
import { WrappedFormUtils } from 'antd/es/form/Form';
import * as GlobalUtilities from '../../lib/globalUtilities';
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
      .get<Api.ShipMethodClientResponseModel>(
        Constants.ApiEndpoint +
          ApiRoutes.ShipMethods +
          '/' +
          this.props.match.params.id,
        {
          headers: GlobalUtilities.defaultHeaders(),
        }
      )
      .then(response => {
        GlobalUtilities.logInfo(response);

        let mapper = new ShipMethodMapper();

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
            <div>
              <h3>Ship Base</h3>
              <p>{String(this.state.model!.shipBase)}</p>
            </div>
            <div>
              <h3>Ship Rate</h3>
              <p>{String(this.state.model!.shipRate)}</p>
            </div>
          </div>
          {message}
          <div>
            <h3>PurchaseOrderHeaders</h3>
            <PurchaseOrderHeaderTableComponent
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
    <Hash>2781b43c9350bffbc596ddb3a3fe4cc4</Hash>
</Codenesium>*/