import React, { Component, FormEvent } from 'react';
import axios, { AxiosError, AxiosResponse } from 'axios';
import { Constants, ApiRoutes, ClientRoutes } from '../../constants';
import * as Api from '../../api/models';
import SalesReasonMapper from './salesReasonMapper';
import SalesReasonViewModel from './salesReasonViewModel';
import { Form, Input, Button, Spin, Alert } from 'antd';
import { WrappedFormUtils } from 'antd/es/form/Form';
import * as GlobalUtilities from '../../lib/globalUtilities';
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
      .get<Api.SalesReasonClientResponseModel>(
        Constants.ApiEndpoint +
          ApiRoutes.SalesReasons +
          '/' +
          this.props.match.params.id,
        {
          headers: GlobalUtilities.defaultHeaders(),
        }
      )
      .then(response => {
        GlobalUtilities.logInfo(response);

        let mapper = new SalesReasonMapper();

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
              <h3>Modified Date</h3>
              <p>{String(this.state.model!.modifiedDate)}</p>
            </div>
            <div>
              <h3>Name</h3>
              <p>{String(this.state.model!.name)}</p>
            </div>
            <div>
              <h3>Reason Type</h3>
              <p>{String(this.state.model!.reasonType)}</p>
            </div>
          </div>
          {message}
          <div>
            <h3>SalesOrderHeaderSalesReasons</h3>
            <SalesOrderHeaderSalesReasonTableComponent
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
    <Hash>a9e9c8f15b71b1d443513f9096edf351</Hash>
</Codenesium>*/