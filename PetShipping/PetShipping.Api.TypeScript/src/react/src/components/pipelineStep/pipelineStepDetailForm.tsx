import React, { Component, FormEvent } from 'react';
import axios, { AxiosError, AxiosResponse } from 'axios';
import { Constants, ApiRoutes, ClientRoutes } from '../../constants';
import * as Api from '../../api/models';
import PipelineStepMapper from './pipelineStepMapper';
import PipelineStepViewModel from './pipelineStepViewModel';
import { Form, Input, Button, Spin, Alert } from 'antd';
import { WrappedFormUtils } from 'antd/es/form/Form';
import * as GlobalUtilities from '../../lib/globalUtilities';
import { HandlerPipelineStepTableComponent } from '../shared/handlerPipelineStepTable';
import { OtherTransportTableComponent } from '../shared/otherTransportTable';
import { PipelineStepDestinationTableComponent } from '../shared/pipelineStepDestinationTable';
import { PipelineStepNoteTableComponent } from '../shared/pipelineStepNoteTable';
import { PipelineStepStepRequirementTableComponent } from '../shared/pipelineStepStepRequirementTable';

interface PipelineStepDetailComponentProps {
  form: WrappedFormUtils;
  history: any;
  match: any;
}

interface PipelineStepDetailComponentState {
  model?: PipelineStepViewModel;
  loading: boolean;
  loaded: boolean;
  errorOccurred: boolean;
  errorMessage: string;
}

class PipelineStepDetailComponent extends React.Component<
  PipelineStepDetailComponentProps,
  PipelineStepDetailComponentState
> {
  state = {
    model: new PipelineStepViewModel(),
    loading: false,
    loaded: true,
    errorOccurred: false,
    errorMessage: '',
  };

  handleEditClick(e: any) {
    this.props.history.push(
      ClientRoutes.PipelineSteps + '/edit/' + this.state.model!.id
    );
  }

  componentDidMount() {
    this.setState({ ...this.state, loading: true });

    axios
      .get<Api.PipelineStepClientResponseModel>(
        Constants.ApiEndpoint +
          ApiRoutes.PipelineSteps +
          '/' +
          this.props.match.params.id,
        {
          headers: GlobalUtilities.defaultHeaders(),
        }
      )
      .then(response => {
        GlobalUtilities.logInfo(response);

        let mapper = new PipelineStepMapper();

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
              <h3>name</h3>
              <p>{String(this.state.model!.name)}</p>
            </div>
            <div style={{ marginBottom: '10px' }}>
              <h3>pipelineStepStatusId</h3>
              <p>
                {String(
                  this.state.model!.pipelineStepStatusIdNavigation &&
                    this.state.model!.pipelineStepStatusIdNavigation!.toDisplay()
                )}
              </p>
            </div>
            <div style={{ marginBottom: '10px' }}>
              <h3>shipperId</h3>
              <p>
                {String(
                  this.state.model!.shipperIdNavigation &&
                    this.state.model!.shipperIdNavigation!.toDisplay()
                )}
              </p>
            </div>
          </div>
          {message}
          <div>
            <h3>HandlerPipelineSteps</h3>
            <HandlerPipelineStepTableComponent
              history={this.props.history}
              match={this.props.match}
              apiRoute={
                Constants.ApiEndpoint +
                ApiRoutes.PipelineSteps +
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
                ApiRoutes.PipelineSteps +
                '/' +
                this.state.model!.id +
                '/' +
                ApiRoutes.OtherTransports
              }
            />
          </div>
          <div>
            <h3>PipelineStepDestinations</h3>
            <PipelineStepDestinationTableComponent
              history={this.props.history}
              match={this.props.match}
              apiRoute={
                Constants.ApiEndpoint +
                ApiRoutes.PipelineSteps +
                '/' +
                this.state.model!.id +
                '/' +
                ApiRoutes.PipelineStepDestinations
              }
            />
          </div>
          <div>
            <h3>PipelineStepNotes</h3>
            <PipelineStepNoteTableComponent
              history={this.props.history}
              match={this.props.match}
              apiRoute={
                Constants.ApiEndpoint +
                ApiRoutes.PipelineSteps +
                '/' +
                this.state.model!.id +
                '/' +
                ApiRoutes.PipelineStepNotes
              }
            />
          </div>
          <div>
            <h3>PipelineStepStepRequirements</h3>
            <PipelineStepStepRequirementTableComponent
              history={this.props.history}
              match={this.props.match}
              apiRoute={
                Constants.ApiEndpoint +
                ApiRoutes.PipelineSteps +
                '/' +
                this.state.model!.id +
                '/' +
                ApiRoutes.PipelineStepStepRequirements
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

export const WrappedPipelineStepDetailComponent = Form.create({
  name: 'PipelineStep Detail',
})(PipelineStepDetailComponent);


/*<Codenesium>
    <Hash>a34513b1d09b8001167fff3c952d1cc9</Hash>
</Codenesium>*/