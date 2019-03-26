import React, { Component, FormEvent } from 'react';
import axios, { AxiosError, AxiosResponse } from 'axios';
import { Constants, ApiRoutes, ClientRoutes } from '../../constants';
import * as Api from '../../api/models';
import VehicleCapabilittyMapper from './vehicleCapabilittyMapper';
import VehicleCapabilittyViewModel from './vehicleCapabilittyViewModel';
import { Form, Input, Button, Spin, Alert } from 'antd';
import { WrappedFormUtils } from 'antd/es/form/Form';
import * as GlobalUtilities from '../../lib/globalUtilities';

interface VehicleCapabilittyDetailComponentProps {
  form: WrappedFormUtils;
  history: any;
  match: any;
}

interface VehicleCapabilittyDetailComponentState {
  model?: VehicleCapabilittyViewModel;
  loading: boolean;
  loaded: boolean;
  errorOccurred: boolean;
  errorMessage: string;
}

class VehicleCapabilittyDetailComponent extends React.Component<
  VehicleCapabilittyDetailComponentProps,
  VehicleCapabilittyDetailComponentState
> {
  state = {
    model: new VehicleCapabilittyViewModel(),
    loading: false,
    loaded: true,
    errorOccurred: false,
    errorMessage: '',
  };

  handleEditClick(e: any) {
    this.props.history.push(
      ClientRoutes.VehicleCapabilities + '/edit/' + this.state.model!.vehicleId
    );
  }

  componentDidMount() {
    this.setState({ ...this.state, loading: true });

    axios
      .get<Api.VehicleCapabilittyClientResponseModel>(
        Constants.ApiEndpoint +
          ApiRoutes.VehicleCapabilities +
          '/' +
          this.props.match.params.id,
        {
          headers: GlobalUtilities.defaultHeaders(),
        }
      )
      .then(response => {
        GlobalUtilities.logInfo(response);

        let mapper = new VehicleCapabilittyMapper();

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
              <h3>vehicleCapabilityId</h3>
              <p>
                {String(
                  this.state.model!.vehicleCapabilityIdNavigation &&
                    this.state.model!.vehicleCapabilityIdNavigation!.toDisplay()
                )}
              </p>
            </div>
            <div style={{ marginBottom: '10px' }}>
              <h3>vehicleId</h3>
              <p>
                {String(
                  this.state.model!.vehicleIdNavigation &&
                    this.state.model!.vehicleIdNavigation!.toDisplay()
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

export const WrappedVehicleCapabilittyDetailComponent = Form.create({
  name: 'VehicleCapabilitty Detail',
})(VehicleCapabilittyDetailComponent);


/*<Codenesium>
    <Hash>f4af9156bf506ca0e11134fe7fe4fe7c</Hash>
</Codenesium>*/