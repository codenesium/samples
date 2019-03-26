import React, { Component, FormEvent } from 'react';
import axios, { AxiosError, AxiosResponse } from 'axios';
import { Constants, ApiRoutes, ClientRoutes } from '../../constants';
import * as Api from '../../api/models';
import HandlerPipelineStepMapper from './handlerPipelineStepMapper';
import HandlerPipelineStepViewModel from './handlerPipelineStepViewModel';
import { Form, Input, Button, Spin, Alert } from 'antd';
import { WrappedFormUtils } from 'antd/es/form/Form';
import * as GlobalUtilities from '../../lib/globalUtilities';

interface HandlerPipelineStepDetailComponentProps {
  form: WrappedFormUtils;
  history: any;
  match: any;
}

interface HandlerPipelineStepDetailComponentState {
  model?: HandlerPipelineStepViewModel;
  loading: boolean;
  loaded: boolean;
  errorOccurred: boolean;
  errorMessage: string;
}

class HandlerPipelineStepDetailComponent extends React.Component<
  HandlerPipelineStepDetailComponentProps,
  HandlerPipelineStepDetailComponentState
> {
  state = {
    model: new HandlerPipelineStepViewModel(),
    loading: false,
    loaded: true,
    errorOccurred: false,
    errorMessage: '',
  };

  handleEditClick(e: any) {
    this.props.history.push(
      ClientRoutes.HandlerPipelineSteps + '/edit/' + this.state.model!.id
    );
  }

  componentDidMount() {
    this.setState({ ...this.state, loading: true });

    axios
      .get<Api.HandlerPipelineStepClientResponseModel>(
        Constants.ApiEndpoint +
          ApiRoutes.HandlerPipelineSteps +
          '/' +
          this.props.match.params.id,
        {
          headers: GlobalUtilities.defaultHeaders(),
        }
      )
      .then(response => {
        GlobalUtilities.logInfo(response);

        let mapper = new HandlerPipelineStepMapper();

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
              <h3>handlerId</h3>
              <p>
                {String(
                  this.state.model!.handlerIdNavigation &&
                    this.state.model!.handlerIdNavigation!.toDisplay()
                )}
              </p>
            </div>
            <div style={{ marginBottom: '10px' }}>
              <h3>pipelineStepId</h3>
              <p>
                {String(
                  this.state.model!.pipelineStepIdNavigation &&
                    this.state.model!.pipelineStepIdNavigation!.toDisplay()
                )}
              </p>
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

export const WrappedHandlerPipelineStepDetailComponent = Form.create({
  name: 'HandlerPipelineStep Detail',
})(HandlerPipelineStepDetailComponent);


/*<Codenesium>
    <Hash>6b0bb48d39a906d43a733011bfd2a64b</Hash>
</Codenesium>*/