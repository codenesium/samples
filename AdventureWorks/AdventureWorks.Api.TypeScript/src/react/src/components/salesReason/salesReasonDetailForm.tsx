import React, { Component, FormEvent } from 'react';
import axios from 'axios';
import { Constants, ApiRoutes, ClientRoutes } from '../../constants';
import * as Api from '../../api/models';
import SalesReasonMapper from './salesReasonMapper';
import SalesReasonViewModel from './salesReasonViewModel';
import { Form, Input, Button, Spin, Alert } from 'antd';
import { WrappedFormUtils } from 'antd/es/form/Form';
import { SalesOrderHeaderSalesReasonTableComponent } from '../shared/salesOrderHeaderSalesReasonTable';

interface SalesReasonDetailComponentProps {
  form: WrappedFormUtils;
  history: any;
  match: any;
}

interface SalesReasonDetailComponentState {
  model?: SalesReasonViewModel;
  loading: boolean;
  loaded: boolean;
  errorOccurred: boolean;
  errorMessage: string;
}

class SalesReasonDetailComponent extends React.Component<
  SalesReasonDetailComponentProps,
  SalesReasonDetailComponentState
> {
  state = {
    model: new SalesReasonViewModel(),
    loading: false,
    loaded: true,
    errorOccurred: false,
    errorMessage: '',
  };

  handleEditClick(e: any) {
    this.props.history.push(
      ClientRoutes.SalesReasons + '/edit/' + this.state.model!.salesReasonID
    );
  }

  componentDidMount() {
    this.setState({ ...this.state, loading: true });

    axios
      .get(
        Constants.ApiEndpoint +
          ApiRoutes.SalesReasons +
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
          let response = resp.data as Api.SalesReasonClientResponseModel;

          console.log(response);

          let mapper = new SalesReasonMapper();

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
              <h3>ModifiedDate</h3>
              <p>{String(this.state.model!.modifiedDate)}</p>
            </div>
            <div>
              <h3>Name</h3>
              <p>{String(this.state.model!.name)}</p>
            </div>
            <div>
              <h3>ReasonType</h3>
              <p>{String(this.state.model!.reasonType)}</p>
            </div>
            <div>
              <h3>SalesReasonID</h3>
              <p>{String(this.state.model!.salesReasonID)}</p>
            </div>
          </div>
          {message}
          <div>
            <h3>SalesOrderHeaderSalesReasons</h3>
            <SalesOrderHeaderSalesReasonTableComponent
              salesOrderID={this.state.model!.salesOrderID}
              history={this.props.history}
              match={this.props.match}
              apiRoute={
                Constants.ApiEndpoint +
                ApiRoutes.SalesReasons +
                '/' +
                this.state.model!.salesReasonID +
                '/' +
                ApiRoutes.SalesOrderHeaderSalesReasons
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

export const WrappedSalesReasonDetailComponent = Form.create({
  name: 'SalesReason Detail',
})(SalesReasonDetailComponent);


/*<Codenesium>
    <Hash>fb60b40143008286e91d22ff7c478480</Hash>
</Codenesium>*/