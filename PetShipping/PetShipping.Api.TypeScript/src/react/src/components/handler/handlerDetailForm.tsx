import React, { Component, FormEvent } from 'react';
import axios, { AxiosError, AxiosResponse } from 'axios';
import { Constants, ApiRoutes, ClientRoutes } from '../../constants';
import * as Api from '../../api/models';
import HandlerMapper from './handlerMapper';
import HandlerViewModel from './handlerViewModel';
import { Form, Input, Button, Spin, Alert } from 'antd';
import { WrappedFormUtils } from 'antd/es/form/Form';
import * as GlobalUtilities from '../../lib/globalUtilities';
import { AirTransportTableComponent } from '../shared/airTransportTable';
import { HandlerPipelineStepTableComponent } from '../shared/handlerPipelineStepTable';
import { OtherTransportTableComponent } from '../shared/otherTransportTable';

interface HandlerDetailComponentProps {
  form: WrappedFormUtils;
  history: any;
  match: any;
}

interface HandlerDetailComponentState {
  model?: HandlerViewModel;
  loading: boolean;
  loaded: boolean;
  errorOccurred: boolean;
  errorMessage: string;
}

class HandlerDetailComponent extends React.Component<
  HandlerDetailComponentProps,
  HandlerDetailComponentState
> {
  state = {
    model: new HandlerViewModel(),
    loading: false,
    loaded: true,
    errorOccurred: false,
    errorMessage: '',
  };

  handleEditClick(e: any) {
    this.props.history.push(
      ClientRoutes.Handlers + '/edit/' + this.state.model!.id
    );
  }

  componentDidMount() {
    this.setState({ ...this.state, loading: true });

    axios
      .get<Api.HandlerClientResponseModel>(
        Constants.ApiEndpoint +
          ApiRoutes.Handlers +
          '/' +
          this.props.match.params.id,
        {
          headers: GlobalUtilities.defaultHeaders(),
        }
      )
      .then(response => {
        GlobalUtilities.logInfo(response);

        let mapper = new HandlerMapper();

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
              <h3>countryId</h3>
              <p>{String(this.state.model!.countryId)}</p>
            </div>
            <div>
              <h3>email</h3>
              <p>{String(this.state.model!.email)}</p>
            </div>
            <div>
              <h3>firstName</h3>
              <p>{String(this.state.model!.firstName)}</p>
            </div>
            <div>
              <h3>lastName</h3>
              <p>{String(this.state.model!.lastName)}</p>
            </div>
            <div>
              <h3>phone</h3>
              <p>{String(this.state.model!.phone)}</p>
            </div>
          </div>
          {message}
          <div>
            <h3>AirTransports</h3>
            <AirTransportTableComponent
              history={this.props.history}
              match={this.props.match}
              apiRoute={
                Constants.ApiEndpoint +
                ApiRoutes.Handlers +
                '/' +
                this.state.model!.id +
                '/' +
                ApiRoutes.AirTransports
              }
            />
          </div>
          <div>
            <h3>HandlerPipelineSteps</h3>
            <HandlerPipelineStepTableComponent
              history={this.props.history}
              match={this.props.match}
              apiRoute={
                Constants.ApiEndpoint +
                ApiRoutes.Handlers +
                '/' +
                this.state.model!.id +
                '/' +
                ApiRoutes.HandlerPipelineSteps
              }
            />
          </div>
          <div>
            <h3>OtherTransports</h3>
            <OtherTransportTableComponent
              history={this.props.history}
              match={this.props.match}
              apiRoute={
                Constants.ApiEndpoint +
                ApiRoutes.Handlers +
                '/' +
                this.state.model!.id +
                '/' +
                ApiRoutes.OtherTransports
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

export const WrappedHandlerDetailComponent = Form.create({
  name: 'Handler Detail',
})(HandlerDetailComponent);


/*<Codenesium>
    <Hash>e240e6dde0135b22295687e97bce1652</Hash>
</Codenesium>*/