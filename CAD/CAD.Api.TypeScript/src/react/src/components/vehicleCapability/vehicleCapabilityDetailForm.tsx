import React, { Component, FormEvent } from 'react';
import axios from 'axios';
import { Constants, ApiRoutes, ClientRoutes } from '../../constants';
import * as Api from '../../api/models';
import VehicleCapabilityMapper from './vehicleCapabilityMapper';
import VehicleCapabilityViewModel from './vehicleCapabilityViewModel';
import { Form, Input, Button, Spin, Alert } from 'antd';
import { WrappedFormUtils } from 'antd/es/form/Form';
import { VehicleRefCapabilityTableComponent } from '../shared/vehicleRefCapabilityTable';

interface VehicleCapabilityDetailComponentProps {
  form: WrappedFormUtils;
  history: any;
  match: any;
}

interface VehicleCapabilityDetailComponentState {
  model?: VehicleCapabilityViewModel;
  loading: boolean;
  loaded: boolean;
  errorOccurred: boolean;
  errorMessage: string;
}

class VehicleCapabilityDetailComponent extends React.Component<
  VehicleCapabilityDetailComponentProps,
  VehicleCapabilityDetailComponentState
> {
  state = {
    model: new VehicleCapabilityViewModel(),
    loading: false,
    loaded: true,
    errorOccurred: false,
    errorMessage: '',
  };

  handleEditClick(e: any) {
    this.props.history.push(
      ClientRoutes.VehicleCapabilities + '/edit/' + this.state.model!.id
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
          let response = resp.data as Api.VehicleCapabilityClientResponseModel;

          console.log(response);

          let mapper = new VehicleCapabilityMapper();

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
              <h3>name</h3>
              <p>{String(this.state.model!.name)}</p>
            </div>
          </div>
          {message}
          <div>
            <h3>VehicleRefCapabilities</h3>
            <VehicleRefCapabilityTableComponent
              id={this.state.model!.id}
              history={this.props.history}
              match={this.props.match}
              apiRoute={
                Constants.ApiEndpoint +
                ApiRoutes.VehicleCapabilities +
                '/' +
                this.state.model!.id +
                '/' +
                ApiRoutes.VehicleRefCapabilities
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

export const WrappedVehicleCapabilityDetailComponent = Form.create({
  name: 'VehicleCapability Detail',
})(VehicleCapabilityDetailComponent);


/*<Codenesium>
    <Hash>086f2c442adff0937cd372f1d3d44189</Hash>
</Codenesium>*/