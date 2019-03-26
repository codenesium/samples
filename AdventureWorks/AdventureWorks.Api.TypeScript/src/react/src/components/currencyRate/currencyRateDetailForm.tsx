import React, { Component, FormEvent } from 'react';
import axios, { AxiosError, AxiosResponse } from 'axios';
import { Constants, ApiRoutes, ClientRoutes } from '../../constants';
import * as Api from '../../api/models';
import CurrencyRateMapper from './currencyRateMapper';
import CurrencyRateViewModel from './currencyRateViewModel';
import { Form, Input, Button, Spin, Alert } from 'antd';
import { WrappedFormUtils } from 'antd/es/form/Form';
import * as GlobalUtilities from '../../lib/globalUtilities';
import { SalesOrderHeaderTableComponent } from '../shared/salesOrderHeaderTable';

interface CurrencyRateDetailComponentProps {
  form: WrappedFormUtils;
  history: any;
  match: any;
}

interface CurrencyRateDetailComponentState {
  model?: CurrencyRateViewModel;
  loading: boolean;
  loaded: boolean;
  errorOccurred: boolean;
  errorMessage: string;
}

class CurrencyRateDetailComponent extends React.Component<
  CurrencyRateDetailComponentProps,
  CurrencyRateDetailComponentState
> {
  state = {
    model: new CurrencyRateViewModel(),
    loading: false,
    loaded: true,
    errorOccurred: false,
    errorMessage: '',
  };

  handleEditClick(e: any) {
    this.props.history.push(
      ClientRoutes.CurrencyRates + '/edit/' + this.state.model!.currencyRateID
    );
  }

  componentDidMount() {
    this.setState({ ...this.state, loading: true });

    axios
      .get<Api.CurrencyRateClientResponseModel>(
        Constants.ApiEndpoint +
          ApiRoutes.CurrencyRates +
          '/' +
          this.props.match.params.id,
        {
          headers: GlobalUtilities.defaultHeaders(),
        }
      )
      .then(response => {
        GlobalUtilities.logInfo(response);

        let mapper = new CurrencyRateMapper();

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
              <h3>Average Rate</h3>
              <p>{String(this.state.model!.averageRate)}</p>
            </div>
            <div>
              <h3>Currency Rate Date</h3>
              <p>{String(this.state.model!.currencyRateDate)}</p>
            </div>
            <div>
              <h3>End Of Day Rate</h3>
              <p>{String(this.state.model!.endOfDayRate)}</p>
            </div>
            <div style={{ marginBottom: '10px' }}>
              <h3>From Currency Code</h3>
              <p>
                {String(
                  this.state.model!.fromCurrencyCodeNavigation &&
                    this.state.model!.fromCurrencyCodeNavigation!.toDisplay()
                )}
              </p>
            </div>
            <div>
              <h3>Modified Date</h3>
              <p>{String(this.state.model!.modifiedDate)}</p>
            </div>
            <div style={{ marginBottom: '10px' }}>
              <h3>To Currency Code</h3>
              <p>
                {String(
                  this.state.model!.toCurrencyCodeNavigation &&
                    this.state.model!.toCurrencyCodeNavigation!.toDisplay()
                )}
              </p>
            </div>
          </div>
          {message}
          <div>
            <h3>SalesOrderHeaders</h3>
            <SalesOrderHeaderTableComponent
              history={this.props.history}
              match={this.props.match}
              apiRoute={
                Constants.ApiEndpoint +
                ApiRoutes.CurrencyRates +
                '/' +
                this.state.model!.currencyRateID +
                '/' +
                ApiRoutes.SalesOrderHeaders
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

export const WrappedCurrencyRateDetailComponent = Form.create({
  name: 'CurrencyRate Detail',
})(CurrencyRateDetailComponent);


/*<Codenesium>
    <Hash>c3ba3afa9326e55a13757b0350ea121f</Hash>
</Codenesium>*/