import React, { Component, FormEvent } from 'react';
import axios, { AxiosError, AxiosResponse } from 'axios';
import { Constants, ApiRoutes, ClientRoutes } from '../../constants';
import * as Api from '../../api/models';
import VehicleMapper from './vehicleMapper';
import VehicleViewModel from './vehicleViewModel';
import { Form, Input, Button, Spin, Alert } from 'antd';
import { WrappedFormUtils } from 'antd/es/form/Form';
import * as GlobalUtilities from '../../lib/globalUtilities';
import { VehicleCapabilitiesTableComponent } from '../shared/vehicleCapabilitiesTable';
import { VehicleOfficerTableComponent } from '../shared/vehicleOfficerTable';

interface VehicleDetailComponentProps {
  form: WrappedFormUtils;
  history: any;
  match: any;
}

interface VehicleDetailComponentState {
  model?: VehicleViewModel;
  loading: boolean;
  loaded: boolean;
  errorOccurred: boolean;
  errorMessage: string;
}

class VehicleDetailComponent extends React.Component<
  VehicleDetailComponentProps,
  VehicleDetailComponentState
> {
  state = {
    model: new VehicleViewModel(),
    loading: false,
    loaded: true,
    errorOccurred: false,
    errorMessage: '',
  };

  handleEditClick(e: any) {
    this.props.history.push(
      ClientRoutes.Vehicles + '/edit/' + this.state.model!.id
    );
  }

  componentDidMount() {
    this.setState({ ...this.state, loading: true });

    axios
      .get<Api.VehicleClientResponseModel>(
        Constants.ApiEndpoint +
          ApiRoutes.Vehicles +
          '/' +
          this.props.match.params.id,
        {
          headers: GlobalUtilities.defaultHeaders(),
        }
      )
      .then(response => {
        GlobalUtilities.logInfo(response);

        let mapper = new VehicleMapper();

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
            <h3>VehicleCapabilities</h3>
            <VehicleCapabilitiesTableComponent
              history={this.props.history}
              match={this.props.match}
              apiRoute={
                Constants.ApiEndpoint +
                ApiRoutes.Vehicles +
                '/' +
                this.state.model!.id +
                '/' +
                ApiRoutes.VehicleCapabilities
              }
            />
          </div>
          <div>
            <h3>VehicleOfficers</h3>
            <VehicleOfficerTableComponent
              history={this.props.history}
              match={this.props.match}
              apiRoute={
                Constants.ApiEndpoint +
                ApiRoutes.Vehicles +
                '/' +
                this.state.model!.id +
                '/' +
                ApiRoutes.VehicleOfficers
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

export const WrappedVehicleDetailComponent = Form.create({
  name: 'Vehicle Detail',
})(VehicleDetailComponent);


/*<Codenesium>
    <Hash>cc87d14400158d76e414c8ed40eb8155</Hash>
</Codenesium>*/