import React, { Component, FormEvent } from 'react';
import axios, { AxiosError, AxiosResponse } from 'axios';
import { Constants, ApiRoutes, ClientRoutes } from '../../constants';
import * as Api from '../../api/models';
import DeviceMapper from './deviceMapper';
import DeviceViewModel from './deviceViewModel';
import { Form, Input, Button, Spin, Alert } from 'antd';
import { WrappedFormUtils } from 'antd/es/form/Form';
import * as GlobalUtilities from '../../lib/globalUtilities';
import { DeviceActionTableComponent } from '../shared/deviceActionTable';

interface DeviceDetailComponentProps {
  form: WrappedFormUtils;
  history: any;
  match: any;
}

interface DeviceDetailComponentState {
  model?: DeviceViewModel;
  loading: boolean;
  loaded: boolean;
  errorOccurred: boolean;
  errorMessage: string;
}

class DeviceDetailComponent extends React.Component<
  DeviceDetailComponentProps,
  DeviceDetailComponentState
> {
  state = {
    model: new DeviceViewModel(),
    loading: false,
    loaded: true,
    errorOccurred: false,
    errorMessage: '',
  };

  handleEditClick(e: any) {
    this.props.history.push(
      ClientRoutes.Devices + '/edit/' + this.state.model!.id
    );
  }

  componentDidMount() {
    this.setState({ ...this.state, loading: true });

    axios
      .get<Api.DeviceClientResponseModel>(
        Constants.ApiEndpoint +
          ApiRoutes.Devices +
          '/' +
          this.props.match.params.id,
        {
          headers: GlobalUtilities.defaultHeaders(),
        }
      )
      .then(response => {
        GlobalUtilities.logInfo(response);

        let mapper = new DeviceMapper();

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
              <h3>Date of Last Ping</h3>
              <p>{String(this.state.model!.dateOfLastPing)}</p>
            </div>
            <div>
              <h3>Active</h3>
              <p>{String(this.state.model!.isActive)}</p>
            </div>
            <div>
              <h3>Name</h3>
              <p>{String(this.state.model!.name)}</p>
            </div>
            <div>
              <h3>Public Id</h3>
              <p>{String(this.state.model!.publicId)}</p>
            </div>
          </div>
          {message}
          <div>
            <h3>DeviceActions</h3>
            <DeviceActionTableComponent
              history={this.props.history}
              match={this.props.match}
              apiRoute={
                Constants.ApiEndpoint +
                ApiRoutes.Devices +
                '/' +
                this.state.model!.id +
                '/' +
                ApiRoutes.DeviceActions
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

export const WrappedDeviceDetailComponent = Form.create({
  name: 'Device Detail',
})(DeviceDetailComponent);


/*<Codenesium>
    <Hash>c34cdf90a810be58cb1368f5d5a68bed</Hash>
</Codenesium>*/