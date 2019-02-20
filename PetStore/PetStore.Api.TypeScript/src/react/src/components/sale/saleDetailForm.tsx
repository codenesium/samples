import React, { Component, FormEvent } from 'react';
import axios from 'axios';
import { LoadingForm } from '../../lib/components/loadingForm';
import { Constants, ApiRoutes, ClientRoutes } from '../../constants';
import * as Api from '../../api/models';
import SaleMapper from './saleMapper';
import SaleViewModel from './saleViewModel';
import { Form, Input, Button } from 'antd';
import { WrappedFormUtils } from 'antd/es/form/Form';
import { Alert } from 'antd';

interface SaleDetailComponentProps {
  form: WrappedFormUtils;
  history: any;
  match: any;
}

interface SaleDetailComponentState {
  model?: SaleViewModel;
  loading: boolean;
  loaded: boolean;
  errorOccurred: boolean;
  errorMessage: string;
}

class SaleDetailComponent extends React.Component<
  SaleDetailComponentProps,
  SaleDetailComponentState
> {
  state = {
    model: new SaleViewModel(),
    loading: false,
    loaded: true,
    errorOccurred: false,
    errorMessage: '',
  };

  handleEditClick(e: any) {
    this.props.history.push(
      ClientRoutes.Sales + '/edit/' + this.state.model!.id
    );
  }

  componentDidMount() {
    this.setState({ ...this.state, loading: true });

    axios
      .get(
        Constants.ApiEndpoint +
          ApiRoutes.Sales +
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
          let response = resp.data as Api.SaleClientResponseModel;

          console.log(response);

          let mapper = new SaleMapper();

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
      return <LoadingForm />;
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
              <div>amount</div>
              <div>{this.state.model!.amount}</div>
            </div>
            <div>
              <div>firstName</div>
              <div>{this.state.model!.firstName}</div>
            </div>
            <div>
              <div>lastName</div>
              <div>{this.state.model!.lastName}</div>
            </div>
            <div style={{ marginBottom: '10px' }}>
              <h3>paymentTypeId</h3>
              <div>
                {this.state.model!.paymentTypeIdNavigation!.toDisplay()}
              </div>
            </div>
            <div style={{ marginBottom: '10px' }}>
              <h3>petId</h3>
              <div>{this.state.model!.petIdNavigation!.toDisplay()}</div>
            </div>
            <div>
              <div>phone</div>
              <div>{this.state.model!.phone}</div>
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

export const WrappedSaleDetailComponent = Form.create({ name: 'Sale Detail' })(
  SaleDetailComponent
);


/*<Codenesium>
    <Hash>c8d1f7a669cebba46f261de50a1ba4de</Hash>
</Codenesium>*/