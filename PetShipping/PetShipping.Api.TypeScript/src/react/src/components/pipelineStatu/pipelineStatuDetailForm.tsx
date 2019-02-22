import React, { Component, FormEvent } from 'react';
import axios from 'axios';
import { Constants, ApiRoutes, ClientRoutes } from '../../constants';
import * as Api from '../../api/models';
import PipelineStatuMapper from './pipelineStatuMapper';
import PipelineStatuViewModel from './pipelineStatuViewModel';
import { Form, Input, Button, Spin, Alert } from 'antd';
import { WrappedFormUtils } from 'antd/es/form/Form';
import { PipelineTableComponent } from '../shared/pipelineTable';

interface PipelineStatuDetailComponentProps {
  form: WrappedFormUtils;
  history: any;
  match: any;
}

interface PipelineStatuDetailComponentState {
  model?: PipelineStatuViewModel;
  loading: boolean;
  loaded: boolean;
  errorOccurred: boolean;
  errorMessage: string;
}

class PipelineStatuDetailComponent extends React.Component<
  PipelineStatuDetailComponentProps,
  PipelineStatuDetailComponentState
> {
  state = {
    model: new PipelineStatuViewModel(),
    loading: false,
    loaded: true,
    errorOccurred: false,
    errorMessage: '',
  };

  handleEditClick(e: any) {
    this.props.history.push(
      ClientRoutes.PipelineStatus + '/edit/' + this.state.model!.id
    );
  }

  componentDidMount() {
    this.setState({ ...this.state, loading: true });

    axios
      .get(
        Constants.ApiEndpoint +
          ApiRoutes.PipelineStatus +
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
          let response = resp.data as Api.PipelineStatuClientResponseModel;

          console.log(response);

          let mapper = new PipelineStatuMapper();

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
              <h3>id</h3>
              <p>{String(this.state.model!.id)}</p>
            </div>
            <div>
              <h3>name</h3>
              <p>{String(this.state.model!.name)}</p>
            </div>
          </div>
          {message}
          <div>
            <h3>Pipelines</h3>
            <PipelineTableComponent
              id={this.state.model!.id}
              history={this.props.history}
              match={this.props.match}
              apiRoute={
                Constants.ApiEndpoint +
                ApiRoutes.PipelineStatus +
                '/' +
                this.state.model!.id +
                '/' +
                ApiRoutes.Pipelines
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

export const WrappedPipelineStatuDetailComponent = Form.create({
  name: 'PipelineStatu Detail',
})(PipelineStatuDetailComponent);


/*<Codenesium>
    <Hash>e4a94a36e11d59f0d39cb5f6a5bca1e8</Hash>
</Codenesium>*/