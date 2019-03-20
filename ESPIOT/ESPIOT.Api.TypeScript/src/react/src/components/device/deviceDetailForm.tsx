import React, { Component, FormEvent } from 'react';
import axios from 'axios';
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
      .get(
        Constants.ApiEndpoint +
          ApiRoutes.Devices +
          '/' +
          this.props.match.params.id,
        {
          headers: GlobalUtilities.defaultHeaders(),
        }
      )
      .then(
        resp => {
          let response = resp.data as Api.DeviceClientResponseModel;

          GlobalUtilities.logInfo(resp);

          let mapper = new DeviceMapper();

          this.setState({
            model: mapper.mapApiResponseToViewModel(response),
            loading: false,
            loaded: true,
            errorOccurred: false,
            errorMessage: '',
          });
        },
        error => {
          GlobalUtilities.logError(error);
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
    <Hash>5687a82a7cc0d0cf9a287dfb99104c59</Hash>
</Codenesium>*/