import React, { Component, FormEvent } from 'react';
import axios, { AxiosError, AxiosResponse } from 'axios';
import { Constants, ApiRoutes, ClientRoutes } from '../../constants';
import * as Api from '../../api/models';
import PaymentTypeMapper from './paymentTypeMapper';
import PaymentTypeViewModel from './paymentTypeViewModel';
import { Form, Input, Button, Spin, Alert } from 'antd';
import { WrappedFormUtils } from 'antd/es/form/Form';
import * as GlobalUtilities from '../../lib/globalUtilities';
import { SaleTableComponent } from '../shared/saleTable';

interface PaymentTypeDetailComponentProps {
  form: WrappedFormUtils;
  history: any;
  match: any;
}

interface PaymentTypeDetailComponentState {
  model?: PaymentTypeViewModel;
  loading: boolean;
  loaded: boolean;
  errorOccurred: boolean;
  errorMessage: string;
}

class PaymentTypeDetailComponent extends React.Component<
  PaymentTypeDetailComponentProps,
  PaymentTypeDetailComponentState
> {
  state = {
    model: new PaymentTypeViewModel(),
    loading: false,
    loaded: true,
    errorOccurred: false,
    errorMessage: '',
  };

  handleEditClick(e: any) {
    this.props.history.push(
      ClientRoutes.PaymentTypes + '/edit/' + this.state.model!.id
    );
  }

  componentDidMount() {
    this.setState({ ...this.state, loading: true });

    axios
      .get<Api.PaymentTypeClientResponseModel>(
        Constants.ApiEndpoint +
          ApiRoutes.PaymentTypes +
          '/' +
          this.props.match.params.id,
        {
          headers: GlobalUtilities.defaultHeaders(),
        }
      )
      .then(response => {
        GlobalUtilities.logInfo(response);

        let mapper = new PaymentTypeMapper();

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
              <h3>Name</h3>
              <p>{String(this.state.model!.name)}</p>
            </div>
          </div>
          {message}
          <div>
            <h3>Sales</h3>
            <SaleTableComponent
              history={this.props.history}
              match={this.props.match}
              apiRoute={
                Constants.ApiEndpoint +
                ApiRoutes.PaymentTypes +
                '/' +
                this.state.model!.id +
                '/' +
                ApiRoutes.Sales
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

export const WrappedPaymentTypeDetailComponent = Form.create({
  name: 'PaymentType Detail',
})(PaymentTypeDetailComponent);


/*<Codenesium>
    <Hash>0133dd098b55f425fbd997118c860580</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/