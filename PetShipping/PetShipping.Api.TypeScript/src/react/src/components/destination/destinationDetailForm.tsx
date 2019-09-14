import React, { Component, FormEvent } from 'react';
import axios, { AxiosError, AxiosResponse } from 'axios';
import { Constants, ApiRoutes, ClientRoutes } from '../../constants';
import * as Api from '../../api/models';
import DestinationMapper from './destinationMapper';
import DestinationViewModel from './destinationViewModel';
import { Form, Input, Button, Spin, Alert } from 'antd';
import { WrappedFormUtils } from 'antd/es/form/Form';
import * as GlobalUtilities from '../../lib/globalUtilities';
import { PipelineStepDestinationTableComponent } from '../shared/pipelineStepDestinationTable';

interface DestinationDetailComponentProps {
  form: WrappedFormUtils;
  history: any;
  match: any;
}

interface DestinationDetailComponentState {
  model?: DestinationViewModel;
  loading: boolean;
  loaded: boolean;
  errorOccurred: boolean;
  errorMessage: string;
}

class DestinationDetailComponent extends React.Component<
  DestinationDetailComponentProps,
  DestinationDetailComponentState
> {
  state = {
    model: new DestinationViewModel(),
    loading: false,
    loaded: true,
    errorOccurred: false,
    errorMessage: '',
  };

  handleEditClick(e: any) {
    this.props.history.push(
      ClientRoutes.Destinations + '/edit/' + this.state.model!.id
    );
  }

  componentDidMount() {
    this.setState({ ...this.state, loading: true });

    axios
      .get<Api.DestinationClientResponseModel>(
        Constants.ApiEndpoint +
          ApiRoutes.Destinations +
          '/' +
          this.props.match.params.id,
        {
          headers: GlobalUtilities.defaultHeaders(),
        }
      )
      .then(response => {
        GlobalUtilities.logInfo(response);

        let mapper = new DestinationMapper();

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
            <div style={{ marginBottom: '10px' }}>
              <h3>Country</h3>
              <p>
                {String(
                  this.state.model!.countryIdNavigation &&
                    this.state.model!.countryIdNavigation!.toDisplay()
                )}
              </p>
            </div>
            <div>
              <h3>Name</h3>
              <p>{String(this.state.model!.name)}</p>
            </div>
            <div>
              <h3>Order</h3>
              <p>{String(this.state.model!.order)}</p>
            </div>
          </div>
          {message}
          <div>
            <h3>PipelineStepDestinations</h3>
            <PipelineStepDestinationTableComponent
              history={this.props.history}
              match={this.props.match}
              apiRoute={
                Constants.ApiEndpoint +
                ApiRoutes.Destinations +
                '/' +
                this.state.model!.id +
                '/' +
                ApiRoutes.PipelineStepDestinations
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

export const WrappedDestinationDetailComponent = Form.create({
  name: 'Destination Detail',
})(DestinationDetailComponent);


/*<Codenesium>
    <Hash>32b6803c298f03e08d8fdef1c8178d5d</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/