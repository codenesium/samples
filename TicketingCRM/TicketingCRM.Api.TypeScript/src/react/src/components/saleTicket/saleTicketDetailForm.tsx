import React, { Component, FormEvent } from 'react';
import axios from 'axios';
import { LoadingForm } from '../../lib/components/loadingForm';
import { Constants, ApiRoutes, ClientRoutes } from '../../constants';
import * as Api from '../../api/models';
import SaleTicketMapper from './saleTicketMapper';
import SaleTicketViewModel from './saleTicketViewModel';
import { Form, Input, Button } from 'antd';
import { WrappedFormUtils } from 'antd/es/form/Form';
import { Alert } from 'antd';

interface SaleTicketDetailComponentProps {
  form: WrappedFormUtils;
  history: any;
  match: any;
}

interface SaleTicketDetailComponentState {
  model?: SaleTicketViewModel;
  loading: boolean;
  loaded: boolean;
  errorOccurred: boolean;
  errorMessage: string;
}

class SaleTicketDetailComponent extends React.Component<
  SaleTicketDetailComponentProps,
  SaleTicketDetailComponentState
> {
  state = {
    model: new SaleTicketViewModel(),
    loading: false,
    loaded: true,
    errorOccurred: false,
    errorMessage: '',
  };

  handleEditClick(e: any) {
    this.props.history.push(
      ClientRoutes.SaleTickets + '/edit/' + this.state.model!.id
    );
  }

  componentDidMount() {
    this.setState({ ...this.state, loading: true });

    axios
      .get(
        Constants.ApiEndpoint +
          ApiRoutes.SaleTickets +
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
          let response = resp.data as Api.SaleTicketClientResponseModel;

          console.log(response);

          let mapper = new SaleTicketMapper();

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
            <div style={{ marginBottom: '10px' }}>
              <h3>saleId</h3>
              <div>{this.state.model!.saleIdNavigation!.toDisplay()}</div>
            </div>
            <div style={{ marginBottom: '10px' }}>
              <h3>ticketId</h3>
              <div>{this.state.model!.ticketIdNavigation!.toDisplay()}</div>
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

export const WrappedSaleTicketDetailComponent = Form.create({
  name: 'SaleTicket Detail',
})(SaleTicketDetailComponent);


/*<Codenesium>
    <Hash>16b0b96b41b3e8e2bea0310c8d1fbbf9</Hash>
</Codenesium>*/