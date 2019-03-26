import React, { Component, FormEvent } from 'react';
import axios, { AxiosError, AxiosResponse } from 'axios';
import { Constants, ApiRoutes, ClientRoutes } from '../../constants';
import * as Api from '../../api/models';
import SalesTaxRateMapper from './salesTaxRateMapper';
import SalesTaxRateViewModel from './salesTaxRateViewModel';
import { Form, Input, Button, Spin, Alert } from 'antd';
import { WrappedFormUtils } from 'antd/es/form/Form';
import * as GlobalUtilities from '../../lib/globalUtilities';

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
      .get<Api.SalesTaxRateClientResponseModel>(
        Constants.ApiEndpoint +
          ApiRoutes.SalesTaxRates +
          '/' +
          this.props.match.params.id,
        {
          headers: GlobalUtilities.defaultHeaders(),
        }
      )
      .then(response => {
        GlobalUtilities.logInfo(response);

        let mapper = new SalesTaxRateMapper();

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
              <h3>State Province I D</h3>
              <p>{String(this.state.model!.stateProvinceID)}</p>
            </div>
            <div>
              <h3>Tax Rate</h3>
              <p>{String(this.state.model!.taxRate)}</p>
            </div>
            <div>
              <h3>Tax Type</h3>
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
    <Hash>8635c82f929d659330e1c0989bf23dcb</Hash>
</Codenesium>*/