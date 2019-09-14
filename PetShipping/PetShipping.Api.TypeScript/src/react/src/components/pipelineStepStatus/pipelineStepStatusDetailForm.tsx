import React, { Component, FormEvent } from 'react';
import axios, { AxiosError, AxiosResponse } from 'axios';
import { Constants, ApiRoutes, ClientRoutes } from '../../constants';
import * as Api from '../../api/models';
import PipelineStepStatusMapper from './pipelineStepStatusMapper';
import PipelineStepStatusViewModel from './pipelineStepStatusViewModel';
import { Form, Input, Button, Spin, Alert } from 'antd';
import { WrappedFormUtils } from 'antd/es/form/Form';
import * as GlobalUtilities from '../../lib/globalUtilities';
import { PipelineStepTableComponent } from '../shared/pipelineStepTable';

interface PipelineStepStatusDetailComponentProps {
  form: WrappedFormUtils;
  history: any;
  match: any;
}

interface PipelineStepStatusDetailComponentState {
  model?: PipelineStepStatusViewModel;
  loading: boolean;
  loaded: boolean;
  errorOccurred: boolean;
  errorMessage: string;
}

class PipelineStepStatusDetailComponent extends React.Component<
  PipelineStepStatusDetailComponentProps,
  PipelineStepStatusDetailComponentState
> {
  state = {
    model: new PipelineStepStatusViewModel(),
    loading: false,
    loaded: true,
    errorOccurred: false,
    errorMessage: '',
  };

  handleEditClick(e: any) {
    this.props.history.push(
      ClientRoutes.PipelineStepStatus + '/edit/' + this.state.model!.id
    );
  }

  componentDidMount() {
    this.setState({ ...this.state, loading: true });

    axios
      .get<Api.PipelineStepStatusClientResponseModel>(
        Constants.ApiEndpoint +
          ApiRoutes.PipelineStepStatus +
          '/' +
          this.props.match.params.id,
        {
          headers: GlobalUtilities.defaultHeaders(),
        }
      )
      .then(response => {
        GlobalUtilities.logInfo(response);

        let mapper = new PipelineStepStatusMapper();

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
              <h3>Name</h3>
              <p>{String(this.state.model!.name)}</p>
            </div>
          </div>
          {message}
          <div>
            <h3>PipelineSteps</h3>
            <PipelineStepTableComponent
              history={this.props.history}
              match={this.props.match}
              apiRoute={
                Constants.ApiEndpoint +
                ApiRoutes.PipelineStepStatus +
                '/' +
                this.state.model!.id +
                '/' +
                ApiRoutes.PipelineSteps
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

export const WrappedPipelineStepStatusDetailComponent = Form.create({
  name: 'PipelineStepStatus Detail',
})(PipelineStepStatusDetailComponent);


/*<Codenesium>
    <Hash>2a39b75a94bb6503c0022db82a7fd009</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/