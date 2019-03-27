import React, { Component, FormEvent } from 'react';
import axios, { AxiosError, AxiosResponse } from 'axios';
import { Constants, ApiRoutes, ClientRoutes } from '../../constants';
import * as Api from '../../api/models';
import ChainStatusMapper from './chainStatusMapper';
import ChainStatusViewModel from './chainStatusViewModel';
import { Form, Input, Button, Spin, Alert } from 'antd';
import { WrappedFormUtils } from 'antd/es/form/Form';
import * as GlobalUtilities from '../../lib/globalUtilities';
import { ChainTableComponent } from '../shared/chainTable';

interface ChainStatusDetailComponentProps {
  form: WrappedFormUtils;
  history: any;
  match: any;
}

interface ChainStatusDetailComponentState {
  model?: ChainStatusViewModel;
  loading: boolean;
  loaded: boolean;
  errorOccurred: boolean;
  errorMessage: string;
}

class ChainStatusDetailComponent extends React.Component<
  ChainStatusDetailComponentProps,
  ChainStatusDetailComponentState
> {
  state = {
    model: new ChainStatusViewModel(),
    loading: false,
    loaded: true,
    errorOccurred: false,
    errorMessage: '',
  };

  handleEditClick(e: any) {
    this.props.history.push(
      ClientRoutes.ChainStatus + '/edit/' + this.state.model!.id
    );
  }

  componentDidMount() {
    this.setState({ ...this.state, loading: true });

    axios
      .get<Api.ChainStatusClientResponseModel>(
        Constants.ApiEndpoint +
          ApiRoutes.ChainStatus +
          '/' +
          this.props.match.params.id,
        {
          headers: GlobalUtilities.defaultHeaders(),
        }
      )
      .then(response => {
        GlobalUtilities.logInfo(response);

        let mapper = new ChainStatusMapper();

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
            <h3>Chains</h3>
            <ChainTableComponent
              history={this.props.history}
              match={this.props.match}
              apiRoute={
                Constants.ApiEndpoint +
                ApiRoutes.ChainStatus +
                '/' +
                this.state.model!.id +
                '/' +
                ApiRoutes.Chains
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

export const WrappedChainStatusDetailComponent = Form.create({
  name: 'ChainStatus Detail',
})(ChainStatusDetailComponent);


/*<Codenesium>
    <Hash>dc98a6e76f7fe6a2a6bc3dcd35ce4c36</Hash>
</Codenesium>*/