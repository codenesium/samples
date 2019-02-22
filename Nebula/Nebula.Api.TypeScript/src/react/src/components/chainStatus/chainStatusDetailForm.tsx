import React, { Component, FormEvent } from 'react';
import axios from 'axios';
import { Constants, ApiRoutes, ClientRoutes } from '../../constants';
import * as Api from '../../api/models';
import ChainStatusMapper from './chainStatusMapper';
import ChainStatusViewModel from './chainStatusViewModel';
import { Form, Input, Button, Spin, Alert } from 'antd';
import { WrappedFormUtils } from 'antd/es/form/Form';
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
      ClientRoutes.ChainStatuses + '/edit/' + this.state.model!.id
    );
  }

  componentDidMount() {
    this.setState({ ...this.state, loading: true });

    axios
      .get(
        Constants.ApiEndpoint +
          ApiRoutes.ChainStatuses +
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
          let response = resp.data as Api.ChainStatusClientResponseModel;

          console.log(response);

          let mapper = new ChainStatusMapper();

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
              <h3>Id</h3>
              <p>{String(this.state.model!.id)}</p>
            </div>
            <div>
              <h3>Name</h3>
              <p>{String(this.state.model!.name)}</p>
            </div>
          </div>
          {message}
          <div>
            <h3>Chains</h3>
            <ChainTableComponent
              id={this.state.model!.id}
              history={this.props.history}
              match={this.props.match}
              apiRoute={
                Constants.ApiEndpoint +
                ApiRoutes.ChainStatuses +
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
    <Hash>bd4578e833cef4d7c1b103d1416eb205</Hash>
</Codenesium>*/