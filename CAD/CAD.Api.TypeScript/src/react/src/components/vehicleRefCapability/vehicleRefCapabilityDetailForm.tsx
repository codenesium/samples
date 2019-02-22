import React, { Component, FormEvent } from 'react';
import axios from 'axios';
import { Constants, ApiRoutes, ClientRoutes } from '../../constants';
import * as Api from '../../api/models';
import VehicleRefCapabilityMapper from './vehicleRefCapabilityMapper';
import VehicleRefCapabilityViewModel from './vehicleRefCapabilityViewModel';
import { Form, Input, Button, Spin, Alert } from 'antd';
import { WrappedFormUtils } from 'antd/es/form/Form';

interface VehicleRefCapabilityDetailComponentProps {
  form: WrappedFormUtils;
  history: any;
  match: any;
}

interface VehicleRefCapabilityDetailComponentState {
  model?: VehicleRefCapabilityViewModel;
  loading: boolean;
  loaded: boolean;
  errorOccurred: boolean;
  errorMessage: string;
}

class VehicleRefCapabilityDetailComponent extends React.Component<
  VehicleRefCapabilityDetailComponentProps,
  VehicleRefCapabilityDetailComponentState
> {
  state = {
    model: new VehicleRefCapabilityViewModel(),
    loading: false,
    loaded: true,
    errorOccurred: false,
    errorMessage: '',
  };

  handleEditClick(e: any) {
    this.props.history.push(
      ClientRoutes.VehicleRefCapabilities + '/edit/' + this.state.model!.id
    );
  }

  componentDidMount() {
    this.setState({ ...this.state, loading: true });

    axios
      .get(
        Constants.ApiEndpoint +
          ApiRoutes.VehicleRefCapabilities +
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
          let response = resp.data as Api.VehicleRefCapabilityClientResponseModel;

          console.log(response);

          let mapper = new VehicleRefCapabilityMapper();

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

export const WrappedVehicleRefCapabilityDetailComponent = Form.create({
  name: 'VehicleRefCapability Detail',
})(VehicleRefCapabilityDetailComponent);


/*<Codenesium>
    <Hash>d64e53f9c7d9b6d16c8a76c4b67f9721</Hash>
</Codenesium>*/