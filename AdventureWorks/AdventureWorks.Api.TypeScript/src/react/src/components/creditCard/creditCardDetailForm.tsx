import React, { Component, FormEvent } from 'react';
import axios, { AxiosError, AxiosResponse } from 'axios';
import { Constants, ApiRoutes, ClientRoutes } from '../../constants';
import * as Api from '../../api/models';
import CreditCardMapper from './creditCardMapper';
import CreditCardViewModel from './creditCardViewModel';
import { Form, Input, Button, Spin, Alert } from 'antd';
import { WrappedFormUtils } from 'antd/es/form/Form';
import * as GlobalUtilities from '../../lib/globalUtilities';
import { PersonCreditCardTableComponent } from '../shared/personCreditCardTable';
import { SalesOrderHeaderTableComponent } from '../shared/salesOrderHeaderTable';

interface CreditCardDetailComponentProps {
  form: WrappedFormUtils;
  history: any;
  match: any;
}

interface CreditCardDetailComponentState {
  model?: CreditCardViewModel;
  loading: boolean;
  loaded: boolean;
  errorOccurred: boolean;
  errorMessage: string;
}

class CreditCardDetailComponent extends React.Component<
  CreditCardDetailComponentProps,
  CreditCardDetailComponentState
> {
  state = {
    model: new CreditCardViewModel(),
    loading: false,
    loaded: true,
    errorOccurred: false,
    errorMessage: '',
  };

  handleEditClick(e: any) {
    this.props.history.push(
      ClientRoutes.CreditCards + '/edit/' + this.state.model!.creditCardID
    );
  }

  componentDidMount() {
    this.setState({ ...this.state, loading: true });

    axios
      .get<Api.CreditCardClientResponseModel>(
        Constants.ApiEndpoint +
          ApiRoutes.CreditCards +
          '/' +
          this.props.match.params.id,
        {
          headers: GlobalUtilities.defaultHeaders(),
        }
      )
      .then(response => {
        GlobalUtilities.logInfo(response);

        let mapper = new CreditCardMapper();

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
              <h3>Card Number</h3>
              <p>{String(this.state.model!.cardNumber)}</p>
            </div>
            <div>
              <h3>Card Type</h3>
              <p>{String(this.state.model!.cardType)}</p>
            </div>
            <div>
              <h3>Exp Month</h3>
              <p>{String(this.state.model!.expMonth)}</p>
            </div>
            <div>
              <h3>Exp Year</h3>
              <p>{String(this.state.model!.expYear)}</p>
            </div>
            <div>
              <h3>Modified Date</h3>
              <p>{String(this.state.model!.modifiedDate)}</p>
            </div>
          </div>
          {message}
          <div>
            <h3>PersonCreditCards</h3>
            <PersonCreditCardTableComponent
              history={this.props.history}
              match={this.props.match}
              apiRoute={
                Constants.ApiEndpoint +
                ApiRoutes.CreditCards +
                '/' +
                this.state.model!.creditCardID +
                '/' +
                ApiRoutes.PersonCreditCards
              }
            />
          </div>
          <div>
            <h3>SalesOrderHeaders</h3>
            <SalesOrderHeaderTableComponent
              history={this.props.history}
              match={this.props.match}
              apiRoute={
                Constants.ApiEndpoint +
                ApiRoutes.CreditCards +
                '/' +
                this.state.model!.creditCardID +
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

export const WrappedCreditCardDetailComponent = Form.create({
  name: 'CreditCard Detail',
})(CreditCardDetailComponent);


/*<Codenesium>
    <Hash>fa73df993348fb8f6fd60ece5eef0c29</Hash>
</Codenesium>*/