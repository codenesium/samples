import React, { Component, FormEvent } from 'react';
import axios, { AxiosError, AxiosResponse } from 'axios';
import { Constants, ApiRoutes, ClientRoutes } from '../../constants';
import * as Api from '../../api/models';
import PipelineStepStepRequirementMapper from './pipelineStepStepRequirementMapper';
import PipelineStepStepRequirementViewModel from './pipelineStepStepRequirementViewModel';
import { Form, Input, Button, Spin, Alert } from 'antd';
import { WrappedFormUtils } from 'antd/es/form/Form';
import * as GlobalUtilities from '../../lib/globalUtilities';

interface PipelineStepStepRequirementDetailComponentProps {
  form: WrappedFormUtils;
  history: any;
  match: any;
}

interface PipelineStepStepRequirementDetailComponentState {
  model?: PipelineStepStepRequirementViewModel;
  loading: boolean;
  loaded: boolean;
  errorOccurred: boolean;
  errorMessage: string;
}

class PipelineStepStepRequirementDetailComponent extends React.Component<
  PipelineStepStepRequirementDetailComponentProps,
  PipelineStepStepRequirementDetailComponentState
> {
  state = {
    model: new PipelineStepStepRequirementViewModel(),
    loading: false,
    loaded: true,
    errorOccurred: false,
    errorMessage: '',
  };

  handleEditClick(e: any) {
    this.props.history.push(
      ClientRoutes.PipelineStepStepRequirements +
        '/edit/' +
        this.state.model!.id
    );
  }

  componentDidMount() {
    this.setState({ ...this.state, loading: true });

    axios
      .get<Api.PipelineStepStepRequirementClientResponseModel>(
        Constants.ApiEndpoint +
          ApiRoutes.PipelineStepStepRequirements +
          '/' +
          this.props.match.params.id,
        {
          headers: GlobalUtilities.defaultHeaders(),
        }
      )
      .then(response => {
        GlobalUtilities.logInfo(response);

        let mapper = new PipelineStepStepRequirementMapper();

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
              <h3>details</h3>
              <p>{String(this.state.model!.detail)}</p>
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
            <div>
              <h3>requirementMet</h3>
              <p>{String(this.state.model!.requirementMet)}</p>
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

export const WrappedPipelineStepStepRequirementDetailComponent = Form.create({
  name: 'PipelineStepStepRequirement Detail',
})(PipelineStepStepRequirementDetailComponent);


/*<Codenesium>
    <Hash>98e7ea0dc825f8b15e8a32dda1a2bf80</Hash>
</Codenesium>*/