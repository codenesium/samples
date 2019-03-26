import React, { Component, FormEvent } from 'react';
import axios, { AxiosError, AxiosResponse } from 'axios';
import { Constants, ApiRoutes, ClientRoutes } from '../../constants';
import * as Api from '../../api/models';
import SpaceFeatureMapper from './spaceFeatureMapper';
import SpaceFeatureViewModel from './spaceFeatureViewModel';
import { Form, Input, Button, Spin, Alert } from 'antd';
import { WrappedFormUtils } from 'antd/es/form/Form';
import * as GlobalUtilities from '../../lib/globalUtilities';
import { SpaceSpaceFeatureTableComponent } from '../shared/spaceSpaceFeatureTable';

interface SpaceFeatureDetailComponentProps {
  form: WrappedFormUtils;
  history: any;
  match: any;
}

interface SpaceFeatureDetailComponentState {
  model?: SpaceFeatureViewModel;
  loading: boolean;
  loaded: boolean;
  errorOccurred: boolean;
  errorMessage: string;
}

class SpaceFeatureDetailComponent extends React.Component<
  SpaceFeatureDetailComponentProps,
  SpaceFeatureDetailComponentState
> {
  state = {
    model: new SpaceFeatureViewModel(),
    loading: false,
    loaded: true,
    errorOccurred: false,
    errorMessage: '',
  };

  handleEditClick(e: any) {
    this.props.history.push(
      ClientRoutes.SpaceFeatures + '/edit/' + this.state.model!.id
    );
  }

  componentDidMount() {
    this.setState({ ...this.state, loading: true });

    axios
      .get<Api.SpaceFeatureClientResponseModel>(
        Constants.ApiEndpoint +
          ApiRoutes.SpaceFeatures +
          '/' +
          this.props.match.params.id,
        {
          headers: GlobalUtilities.defaultHeaders(),
        }
      )
      .then(response => {
        GlobalUtilities.logInfo(response);

        let mapper = new SpaceFeatureMapper();

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
            <h3>SpaceSpaceFeatures</h3>
            <SpaceSpaceFeatureTableComponent
              history={this.props.history}
              match={this.props.match}
              apiRoute={
                Constants.ApiEndpoint +
                ApiRoutes.SpaceFeatures +
                '/' +
                this.state.model!.id +
                '/' +
                ApiRoutes.SpaceSpaceFeatures
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

export const WrappedSpaceFeatureDetailComponent = Form.create({
  name: 'SpaceFeature Detail',
})(SpaceFeatureDetailComponent);


/*<Codenesium>
    <Hash>957d53968bccfe483e818596bcd896b9</Hash>
</Codenesium>*/