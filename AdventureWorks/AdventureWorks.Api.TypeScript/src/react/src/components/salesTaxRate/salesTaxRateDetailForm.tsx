import React, { Component, FormEvent } from 'react';
import axios from 'axios';
import { Constants, ApiRoutes, ClientRoutes } from '../../constants';
import * as Api from '../../api/models';
import SalesTaxRateMapper from './salesTaxRateMapper';
import SalesTaxRateViewModel from './salesTaxRateViewModel';
import { Form, Input, Button, Spin, Alert } from 'antd';
import { WrappedFormUtils } from 'antd/es/form/Form';

interface SalesTaxRateDetailComponentProps {
  form: WrappedFormUtils;
  history: any;
  match: any;
}

interface SalesTaxRateDetailComponentState {
  model?: SalesTaxRateViewModel;
  loading: boolean;
  loaded: boolean;
  errorOccurred: boolean;
  errorMessage: string;
}

class SalesTaxRateDetailComponent extends React.Component<
  SalesTaxRateDetailComponentProps,
  SalesTaxRateDetailComponentState
> {
  state = {
    model: new SalesTaxRateViewModel(),
    loading: false,
    loaded: true,
    errorOccurred: false,
    errorMessage: '',
  };

  handleEditClick(e: any) {
    this.props.history.push(
      ClientRoutes.SalesTaxRates + '/edit/' + this.state.model!.salesTaxRateID
    );
  }

  componentDidMount() {
    this.setState({ ...this.state, loading: true });

    axios
      .get(
        Constants.ApiEndpoint +
          ApiRoutes.SalesTaxRates +
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
          let response = resp.data as Api.SalesTaxRateClientResponseModel;

          console.log(response);

          let mapper = new SalesTaxRateMapper();

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
              <h3>SalesTaxRateID</h3>
              <p>{String(this.state.model!.salesTaxRateID)}</p>
            </div>
            <div>
              <h3>StateProvinceID</h3>
              <p>{String(this.state.model!.stateProvinceID)}</p>
            </div>
            <div>
              <h3>TaxRate</h3>
              <p>{String(this.state.model!.taxRate)}</p>
            </div>
            <div>
              <h3>TaxType</h3>
              <p>{String(this.state.model!.taxType)}</p>
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

export const WrappedSalesTaxRateDetailComponent = Form.create({
  name: 'SalesTaxRate Detail',
})(SalesTaxRateDetailComponent);


/*<Codenesium>
    <Hash>d910e541c780147c064e7598219eef10</Hash>
</Codenesium>*/