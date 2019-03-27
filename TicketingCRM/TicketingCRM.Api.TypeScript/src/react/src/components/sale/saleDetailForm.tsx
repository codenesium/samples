import React, { Component, FormEvent } from 'react';
import axios, { AxiosError, AxiosResponse } from 'axios';
import { Constants, ApiRoutes, ClientRoutes } from '../../constants';
import * as Api from '../../api/models';
import SaleMapper from './saleMapper';
import SaleViewModel from './saleViewModel';
import { Form, Input, Button, Spin, Alert } from 'antd';
import { WrappedFormUtils } from 'antd/es/form/Form';
import * as GlobalUtilities from '../../lib/globalUtilities';
import { SaleTicketsTableComponent } from '../shared/saleTicketsTable';

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
      .get<Api.SaleClientResponseModel>(
        Constants.ApiEndpoint +
          ApiRoutes.Sales +
          '/' +
          this.props.match.params.id,
        {
          headers: GlobalUtilities.defaultHeaders(),
        }
      )
      .then(response => {
        GlobalUtilities.logInfo(response);

        let mapper = new SaleMapper();

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
              <h3>Ip Address</h3>
              <p>{String(this.state.model!.ipAddress)}</p>
            </div>
            <div>
              <h3>Notes</h3>
              <p>{String(this.state.model!.notes)}</p>
            </div>
            <div>
              <h3>Sale Date</h3>
              <p>{String(this.state.model!.saleDate)}</p>
            </div>
            <div style={{ marginBottom: '10px' }}>
              <h3>Transaction</h3>
              <p>
                {String(
                  this.state.model!.transactionIdNavigation &&
                    this.state.model!.transactionIdNavigation!.toDisplay()
                )}
              </p>
            </div>
          </div>
          {message}
          <div>
            <h3>SaleTickets</h3>
            <SaleTicketsTableComponent
              history={this.props.history}
              match={this.props.match}
              apiRoute={
                Constants.ApiEndpoint +
                ApiRoutes.Sales +
                '/' +
                this.state.model!.id +
                '/' +
                ApiRoutes.SaleTickets
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

export const WrappedSaleDetailComponent = Form.create({ name: 'Sale Detail' })(
  SaleDetailComponent
);


/*<Codenesium>
    <Hash>b55c5d13bdb06558ef0f5099010258f7</Hash>
</Codenesium>*/