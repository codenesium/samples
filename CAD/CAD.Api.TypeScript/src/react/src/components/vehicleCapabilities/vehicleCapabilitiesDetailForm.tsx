import React, { Component, FormEvent } from 'react';
import axios from 'axios';
import { Constants, ApiRoutes, ClientRoutes } from '../../constants';
import * as Api from '../../api/models';
import VehicleCapabilitiesMapper from './vehicleCapabilitiesMapper';
import VehicleCapabilitiesViewModel from './vehicleCapabilitiesViewModel';
import { Form, Input, Button, Spin, Alert } from 'antd';
import { WrappedFormUtils } from 'antd/es/form/Form';

interface VehicleCapabilitiesDetailComponentProps {
  form: WrappedFormUtils;
  history: any;
  match: any;
}

interface VehicleCapabilitiesDetailComponentState {
  model?: VehicleCapabilitiesViewModel;
  loading: boolean;
  loaded: boolean;
  errorOccurred: boolean;
  errorMessage: string;
}

class VehicleCapabilitiesDetailComponent extends React.Component<
  VehicleCapabilitiesDetailComponentProps,
  VehicleCapabilitiesDetailComponentState
> {
  state = {
    model: new VehicleCapabilitiesViewModel(),
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
      .get(
        Constants.ApiEndpoint +
          ApiRoutes.VehicleCapabilities +
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
          let response = resp.data as Api.VehicleCapabilitiesClientResponseModel;

          console.log(response);

          let mapper = new VehicleCapabilitiesMapper();

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
            <div style={{ marginBottom: '10px' }}>
              <h3>vehicleCapabilityId</h3>
              <p>
                {String(
                  this.state.model!.vehicleCapabilityIdNavigation!.toDisplay()
                )}
              </p>
            </div>
            <div style={{ marginBottom: '10px' }}>
              <h3>vehicleId</h3>
              <p>
                {String(this.state.model!.vehicleIdNavigation!.toDisplay())}
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

export const WrappedVehicleCapabilitiesDetailComponent = Form.create({
  name: 'VehicleCapabilities Detail',
})(VehicleCapabilitiesDetailComponent);


/*<Codenesium>
    <Hash>2f8dcdc31c4e503c18a7791129a46dbe</Hash>
</Codenesium>*/