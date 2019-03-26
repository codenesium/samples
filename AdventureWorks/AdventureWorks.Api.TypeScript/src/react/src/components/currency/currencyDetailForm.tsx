import React, { Component, FormEvent } from 'react';
import axios, { AxiosError, AxiosResponse } from 'axios';
import { Constants, ApiRoutes, ClientRoutes } from '../../constants';
import * as Api from '../../api/models';
import CurrencyMapper from './currencyMapper';
import CurrencyViewModel from './currencyViewModel';
import { Form, Input, Button, Spin, Alert } from 'antd';
import { WrappedFormUtils } from 'antd/es/form/Form';
import * as GlobalUtilities from '../../lib/globalUtilities';
import { CountryRegionCurrencyTableComponent } from '../shared/countryRegionCurrencyTable';
import { CurrencyRateTableComponent } from '../shared/currencyRateTable';

interface CurrencyDetailComponentProps {
  form: WrappedFormUtils;
  history: any;
  match: any;
}

interface CurrencyDetailComponentState {
  model?: CurrencyViewModel;
  loading: boolean;
  loaded: boolean;
  errorOccurred: boolean;
  errorMessage: string;
}

class CurrencyDetailComponent extends React.Component<
  CurrencyDetailComponentProps,
  CurrencyDetailComponentState
> {
  state = {
    model: new CurrencyViewModel(),
    loading: false,
    loaded: true,
    errorOccurred: false,
    errorMessage: '',
  };

  handleEditClick(e: any) {
    this.props.history.push(
      ClientRoutes.Currencies + '/edit/' + this.state.model!.currencyCode
    );
  }

  componentDidMount() {
    this.setState({ ...this.state, loading: true });

    axios
      .get<Api.CurrencyClientResponseModel>(
        Constants.ApiEndpoint +
          ApiRoutes.Currencies +
          '/' +
          this.props.match.params.id,
        {
          headers: GlobalUtilities.defaultHeaders(),
        }
      )
      .then(response => {
        GlobalUtilities.logInfo(response);

        let mapper = new CurrencyMapper();

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
          </div>
          {message}
          <div>
            <h3>CountryRegionCurrencies</h3>
            <CountryRegionCurrencyTableComponent
              history={this.props.history}
              match={this.props.match}
              apiRoute={
                Constants.ApiEndpoint +
                ApiRoutes.Currencies +
                '/' +
                this.state.model!.currencyCode +
                '/' +
                ApiRoutes.CountryRegionCurrencies
              }
            />
          </div>
          <div>
            <h3>CurrencyRates</h3>
            <CurrencyRateTableComponent
              history={this.props.history}
              match={this.props.match}
              apiRoute={
                Constants.ApiEndpoint +
                ApiRoutes.Currencies +
                '/' +
                this.state.model!.currencyCode +
                '/' +
                ApiRoutes.CurrencyRates
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

export const WrappedCurrencyDetailComponent = Form.create({
  name: 'Currency Detail',
})(CurrencyDetailComponent);


/*<Codenesium>
    <Hash>ff87e6fd54b839bbeb1db697f7ac8141</Hash>
</Codenesium>*/