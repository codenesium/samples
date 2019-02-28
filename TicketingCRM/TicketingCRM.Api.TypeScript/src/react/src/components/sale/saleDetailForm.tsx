import React, { Component, FormEvent } from 'react';
import axios from 'axios';
import { Constants, ApiRoutes, ClientRoutes } from '../../constants';
import * as Api from '../../api/models';
import SaleMapper from './saleMapper';
import SaleViewModel from './saleViewModel';
import { Form, Input, Button, Spin, Alert } from 'antd';
import { WrappedFormUtils } from 'antd/es/form/Form';
import { SaleTicketTableComponent } from '../shared/saleTicketTable';

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
              <h3>ipAddress</h3>
              <p>{String(this.state.model!.ipAddress)}</p>
            </div>
            <div>
              <h3>notes</h3>
              <p>{String(this.state.model!.note)}</p>
            </div>
            <div>
              <h3>saleDate</h3>
              <p>{String(this.state.model!.saleDate)}</p>
            </div>
            <div style={{ marginBottom: '10px' }}>
              <h3>transactionId</h3>
              <p>
                {String(this.state.model!.transactionIdNavigation!.toDisplay())}
              </p>
            </div>
          </div>
          {message}
          <div>
            <h3>SaleTickets</h3>
            <SaleTicketTableComponent
              id={this.state.model!.id}
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
    <Hash>cb980b2101fce41d6774aa92d0df6f09</Hash>
</Codenesium>*/