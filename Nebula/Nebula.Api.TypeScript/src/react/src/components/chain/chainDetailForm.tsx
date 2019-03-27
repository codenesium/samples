import React, { Component, FormEvent } from 'react';
import axios, { AxiosError, AxiosResponse } from 'axios';
import { Constants, ApiRoutes, ClientRoutes } from '../../constants';
import * as Api from '../../api/models';
import ChainMapper from './chainMapper';
import ChainViewModel from './chainViewModel';
import { Form, Input, Button, Spin, Alert } from 'antd';
import { WrappedFormUtils } from 'antd/es/form/Form';
import * as GlobalUtilities from '../../lib/globalUtilities';
import { ClaspTableComponent } from '../shared/claspTable';
import { LinkTableComponent } from '../shared/linkTable';

interface ChainDetailComponentProps {
  form: WrappedFormUtils;
  history: any;
  match: any;
}

interface ChainDetailComponentState {
  model?: ChainViewModel;
  loading: boolean;
  loaded: boolean;
  errorOccurred: boolean;
  errorMessage: string;
}

class ChainDetailComponent extends React.Component<
  ChainDetailComponentProps,
  ChainDetailComponentState
> {
  state = {
    model: new ChainViewModel(),
    loading: false,
    loaded: true,
    errorOccurred: false,
    errorMessage: '',
  };

  handleEditClick(e: any) {
    this.props.history.push(
      ClientRoutes.Chains + '/edit/' + this.state.model!.id
    );
  }

  componentDidMount() {
    this.setState({ ...this.state, loading: true });

    axios
      .get<Api.ChainClientResponseModel>(
        Constants.ApiEndpoint +
          ApiRoutes.Chains +
          '/' +
          this.props.match.params.id,
        {
          headers: GlobalUtilities.defaultHeaders(),
        }
      )
      .then(response => {
        GlobalUtilities.logInfo(response);

        let mapper = new ChainMapper();

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
              <h3>Chain Status</h3>
              <p>
                {String(
                  this.state.model!.chainStatusIdNavigation &&
                    this.state.model!.chainStatusIdNavigation!.toDisplay()
                )}
              </p>
            </div>
            <div>
              <h3>External</h3>
              <p>{String(this.state.model!.externalId)}</p>
            </div>
            <div>
              <h3>Name</h3>
              <p>{String(this.state.model!.name)}</p>
            </div>
            <div style={{ marginBottom: '10px' }}>
              <h3>Team</h3>
              <p>
                {String(
                  this.state.model!.teamIdNavigation &&
                    this.state.model!.teamIdNavigation!.toDisplay()
                )}
              </p>
            </div>
          </div>
          {message}
          <div>
            <h3>Clasps</h3>
            <ClaspTableComponent
              history={this.props.history}
              match={this.props.match}
              apiRoute={
                Constants.ApiEndpoint +
                ApiRoutes.Chains +
                '/' +
                this.state.model!.id +
                '/' +
                ApiRoutes.Clasps
              }
            />
          </div>
          <div>
            <h3>Links</h3>
            <LinkTableComponent
              history={this.props.history}
              match={this.props.match}
              apiRoute={
                Constants.ApiEndpoint +
                ApiRoutes.Chains +
                '/' +
                this.state.model!.id +
                '/' +
                ApiRoutes.Links
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

export const WrappedChainDetailComponent = Form.create({
  name: 'Chain Detail',
})(ChainDetailComponent);


/*<Codenesium>
    <Hash>5ca0c1398f3fece3872ff4733760d7a4</Hash>
</Codenesium>*/