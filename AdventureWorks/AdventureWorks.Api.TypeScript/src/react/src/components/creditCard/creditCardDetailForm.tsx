import React, { Component, FormEvent } from 'react';
import axios from 'axios';
import { Constants, ApiRoutes, ClientRoutes } from '../../constants';
import * as Api from '../../api/models';
import CreditCardMapper from './creditCardMapper';
import CreditCardViewModel from './creditCardViewModel';
import { Form, Input, Button, Spin, Alert } from 'antd';
import { WrappedFormUtils } from 'antd/es/form/Form';

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
      .get(
        Constants.ApiEndpoint +
          ApiRoutes.CreditCards +
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
          let response = resp.data as Api.CreditCardClientResponseModel;

          console.log(response);

          let mapper = new CreditCardMapper();

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
              <h3>CardNumber</h3>
              <p>{String(this.state.model!.cardNumber)}</p>
            </div>
            <div>
              <h3>CardType</h3>
              <p>{String(this.state.model!.cardType)}</p>
            </div>
            <div>
              <h3>CreditCardID</h3>
              <p>{String(this.state.model!.creditCardID)}</p>
            </div>
            <div>
              <h3>ExpMonth</h3>
              <p>{String(this.state.model!.expMonth)}</p>
            </div>
            <div>
              <h3>ExpYear</h3>
              <p>{String(this.state.model!.expYear)}</p>
            </div>
            <div>
              <h3>ModifiedDate</h3>
              <p>{String(this.state.model!.modifiedDate)}</p>
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

export const WrappedCreditCardDetailComponent = Form.create({
  name: 'CreditCard Detail',
})(CreditCardDetailComponent);


/*<Codenesium>
    <Hash>59bec918395d536bbda76d9bf80539fb</Hash>
</Codenesium>*/