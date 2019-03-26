import React, { Component, FormEvent } from 'react';
import axios, { AxiosError, AxiosResponse } from 'axios';
import { Constants, ApiRoutes, ClientRoutes } from '../../constants';
import * as Api from '../../api/models';
import DeviceActionMapper from './deviceActionMapper';
import DeviceActionViewModel from './deviceActionViewModel';
import { Form, Input, Button, Spin, Alert } from 'antd';
import { WrappedFormUtils } from 'antd/es/form/Form';
import * as GlobalUtilities from '../../lib/globalUtilities';

interface DeviceActionDetailComponentProps {
  form: WrappedFormUtils;
  history: any;
  match: any;
}

interface DeviceActionDetailComponentState {
  model?: DeviceActionViewModel;
  loading: boolean;
  loaded: boolean;
  errorOccurred: boolean;
  errorMessage: string;
}

class DeviceActionDetailComponent extends React.Component<
  DeviceActionDetailComponentProps,
  DeviceActionDetailComponentState
> {
  state = {
    model: new DeviceActionViewModel(),
    loading: false,
    loaded: true,
    errorOccurred: false,
    errorMessage: '',
  };

  handleEditClick(e: any) {
    this.props.history.push(
      ClientRoutes.DeviceActions + '/edit/' + this.state.model!.id
    );
  }

  componentDidMount() {
    this.setState({ ...this.state, loading: true });

    axios
      .get<Api.DeviceActionClientResponseModel>(
        Constants.ApiEndpoint +
          ApiRoutes.DeviceActions +
          '/' +
          this.props.match.params.id,
        {
          headers: GlobalUtilities.defaultHeaders(),
        }
      )
      .then(response => {
        GlobalUtilities.logInfo(response);

        let mapper = new DeviceActionMapper();

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
              <h3>Action</h3>
              <p>{String(this.state.model!.action)}</p>
            </div>
            <div style={{ marginBottom: '10px' }}>
              <h3>Device</h3>
              <p>
                {String(
                  this.state.model!.deviceIdNavigation &&
                    this.state.model!.deviceIdNavigation!.toDisplay()
                )}
              </p>
            </div>
            <div>
              <h3>Name</h3>
              <p>{String(this.state.model!.name)}</p>
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

export const WrappedDeviceActionDetailComponent = Form.create({
  name: 'DeviceAction Detail',
})(DeviceActionDetailComponent);


/*<Codenesium>
    <Hash>edc54c36eaa7df979a5152aa24a9720e</Hash>
</Codenesium>*/