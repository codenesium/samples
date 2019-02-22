import React, { Component, FormEvent } from 'react';
import axios from 'axios';
import { Constants, ApiRoutes, ClientRoutes } from '../../constants';
import * as Api from '../../api/models';
import PipelineStepStepRequirementMapper from './pipelineStepStepRequirementMapper';
import PipelineStepStepRequirementViewModel from './pipelineStepStepRequirementViewModel';
import { Form, Input, Button, Spin, Alert } from 'antd';
import { WrappedFormUtils } from 'antd/es/form/Form';

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
      .get(
        Constants.ApiEndpoint +
          ApiRoutes.PipelineStepStepRequirements +
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
          let response = resp.data as Api.PipelineStepStepRequirementClientResponseModel;

          console.log(response);

          let mapper = new PipelineStepStepRequirementMapper();

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
              <h3>details</h3>
              <p>{String(this.state.model!.detail)}</p>
            </div>
            <div>
              <h3>id</h3>
              <p>{String(this.state.model!.id)}</p>
            </div>
            <div style={{ marginBottom: '10px' }}>
              <h3>pipelineStepId</h3>
              <p>
                {String(
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
    <Hash>127e9050cee49e0a82829f4e86db4f6c</Hash>
</Codenesium>*/