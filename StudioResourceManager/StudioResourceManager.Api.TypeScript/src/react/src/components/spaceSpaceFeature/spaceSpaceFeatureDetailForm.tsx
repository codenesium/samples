import React, { Component, FormEvent } from 'react';
import axios, { AxiosError, AxiosResponse } from 'axios';
import { Constants, ApiRoutes, ClientRoutes } from '../../constants';
import * as Api from '../../api/models';
import SpaceSpaceFeatureMapper from './spaceSpaceFeatureMapper';
import SpaceSpaceFeatureViewModel from './spaceSpaceFeatureViewModel';
import { Form, Input, Button, Spin, Alert } from 'antd';
import { WrappedFormUtils } from 'antd/es/form/Form';
import * as GlobalUtilities from '../../lib/globalUtilities';

interface SpaceSpaceFeatureDetailComponentProps {
  form: WrappedFormUtils;
  history: any;
  match: any;
}

interface SpaceSpaceFeatureDetailComponentState {
  model?: SpaceSpaceFeatureViewModel;
  loading: boolean;
  loaded: boolean;
  errorOccurred: boolean;
  errorMessage: string;
}

class SpaceSpaceFeatureDetailComponent extends React.Component<
  SpaceSpaceFeatureDetailComponentProps,
  SpaceSpaceFeatureDetailComponentState
> {
  state = {
    model: new SpaceSpaceFeatureViewModel(),
    loading: false,
    loaded: true,
    errorOccurred: false,
    errorMessage: '',
  };

  handleEditClick(e: any) {
    this.props.history.push(
      ClientRoutes.SpaceSpaceFeatures + '/edit/' + this.state.model!.id
    );
  }

  componentDidMount() {
    this.setState({ ...this.state, loading: true });

    axios
      .get<Api.SpaceSpaceFeatureClientResponseModel>(
        Constants.ApiEndpoint +
          ApiRoutes.SpaceSpaceFeatures +
          '/' +
          this.props.match.params.id,
        {
          headers: GlobalUtilities.defaultHeaders(),
        }
      )
      .then(response => {
        GlobalUtilities.logInfo(response);

        let mapper = new SpaceSpaceFeatureMapper();

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
              <h3>Space Feature</h3>
              <p>
                {String(
                  this.state.model!.spaceFeatureIdNavigation &&
                    this.state.model!.spaceFeatureIdNavigation!.toDisplay()
                )}
              </p>
            </div>
            <div style={{ marginBottom: '10px' }}>
              <h3>Space</h3>
              <p>
                {String(
                  this.state.model!.spaceIdNavigation &&
                    this.state.model!.spaceIdNavigation!.toDisplay()
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

export const WrappedSpaceSpaceFeatureDetailComponent = Form.create({
  name: 'SpaceSpaceFeature Detail',
})(SpaceSpaceFeatureDetailComponent);


/*<Codenesium>
    <Hash>9885139c125d6bd0232adbb00b7c8e54</Hash>
</Codenesium>*/