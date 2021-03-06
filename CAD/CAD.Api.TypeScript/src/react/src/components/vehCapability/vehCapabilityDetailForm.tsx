import React, { Component, FormEvent } from 'react';
import axios, { AxiosError, AxiosResponse } from 'axios';
import { Constants, ApiRoutes, ClientRoutes } from '../../constants';
import * as Api from '../../api/models';
import VehCapabilityMapper from './vehCapabilityMapper';
import VehCapabilityViewModel from './vehCapabilityViewModel';
import { Form, Input, Button, Spin, Alert } from 'antd';
import { WrappedFormUtils } from 'antd/es/form/Form';
import * as GlobalUtilities from '../../lib/globalUtilities';
import { VehicleCapabilitiesTableComponent } from '../shared/vehicleCapabilitiesTable';

interface VehCapabilityDetailComponentProps {
  form: WrappedFormUtils;
  history: any;
  match: any;
}

interface VehCapabilityDetailComponentState {
  model?: VehCapabilityViewModel;
  loading: boolean;
  loaded: boolean;
  errorOccurred: boolean;
  errorMessage: string;
}

class VehCapabilityDetailComponent extends React.Component<
  VehCapabilityDetailComponentProps,
  VehCapabilityDetailComponentState
> {
  state = {
    model: new VehCapabilityViewModel(),
    loading: false,
    loaded: true,
    errorOccurred: false,
    errorMessage: '',
  };

  handleEditClick(e: any) {
    this.props.history.push(
      ClientRoutes.VehCapabilities + '/edit/' + this.state.model!.id
    );
  }

  componentDidMount() {
    this.setState({ ...this.state, loading: true });

    axios
      .get<Api.VehCapabilityClientResponseModel>(
        Constants.ApiEndpoint +
          ApiRoutes.VehCapabilities +
          '/' +
          this.props.match.params.id,
        {
          headers: GlobalUtilities.defaultHeaders(),
        }
      )
      .then(response => {
        GlobalUtilities.logInfo(response);

        let mapper = new VehCapabilityMapper();

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
                ApiRoutes.VehCapabilities +
                '/' +
                this.state.model!.id +
                '/' +
                ApiRoutes.VehicleCapabilities
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

export const WrappedVehCapabilityDetailComponent = Form.create({
  name: 'VehCapability Detail',
})(VehCapabilityDetailComponent);


/*<Codenesium>
    <Hash>243e3dbc875e09d674dfd3000408e4d8</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/