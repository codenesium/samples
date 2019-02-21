import React, { Component, FormEvent } from 'react';
import axios from 'axios';
import { Constants, ApiRoutes, ClientRoutes } from '../../constants';
import * as Api from '../../api/models';
import CurrencyRateMapper from './currencyRateMapper';
import CurrencyRateViewModel from './currencyRateViewModel';
import { Form, Input, Button, Spin, Alert } from 'antd';
import { WrappedFormUtils } from 'antd/es/form/Form';

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
      .get(
        Constants.ApiEndpoint +
          ApiRoutes.CurrencyRates +
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
          let response = resp.data as Api.CurrencyRateClientResponseModel;

          console.log(response);

          let mapper = new CurrencyRateMapper();

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
              <h3>AverageRate</h3>
              <p>{String(this.state.model!.averageRate)}</p>
            </div>
            <div>
              <h3>CurrencyRateDate</h3>
              <p>{String(this.state.model!.currencyRateDate)}</p>
            </div>
            <div>
              <h3>CurrencyRateID</h3>
              <p>{String(this.state.model!.currencyRateID)}</p>
            </div>
            <div>
              <h3>EndOfDayRate</h3>
              <p>{String(this.state.model!.endOfDayRate)}</p>
            </div>
            <div style={{ marginBottom: '10px' }}>
              <h3>FromCurrencyCode</h3>
              <p>
                {String(
                  this.state.model!.fromCurrencyCodeNavigation!.toDisplay()
                )}
              </p>
            </div>
            <div>
              <h3>ModifiedDate</h3>
              <p>{String(this.state.model!.modifiedDate)}</p>
            </div>
            <div style={{ marginBottom: '10px' }}>
              <h3>ToCurrencyCode</h3>
              <p>
                {String(
                  this.state.model!.toCurrencyCodeNavigation!.toDisplay()
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

export const WrappedCurrencyRateDetailComponent = Form.create({
  name: 'CurrencyRate Detail',
})(CurrencyRateDetailComponent);


/*<Codenesium>
    <Hash>0d22d631ecf921c1c15caacf43b4b376</Hash>
</Codenesium>*/