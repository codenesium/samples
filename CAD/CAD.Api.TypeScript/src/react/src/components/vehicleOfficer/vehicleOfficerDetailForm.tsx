import React, { Component, FormEvent } from 'react';
import axios from 'axios';
import { Constants, ApiRoutes, ClientRoutes } from '../../constants';
import * as Api from '../../api/models';
import VehicleOfficerMapper from './vehicleOfficerMapper';
import VehicleOfficerViewModel from './vehicleOfficerViewModel';
import { Form, Input, Button, Spin, Alert } from 'antd';
import { WrappedFormUtils } from 'antd/es/form/Form';

interface VehicleOfficerDetailComponentProps {
  form: WrappedFormUtils;
  history: any;
  match: any;
}

interface VehicleOfficerDetailComponentState {
  model?: VehicleOfficerViewModel;
  loading: boolean;
  loaded: boolean;
  errorOccurred: boolean;
  errorMessage: string;
}

class VehicleOfficerDetailComponent extends React.Component<
  VehicleOfficerDetailComponentProps,
  VehicleOfficerDetailComponentState
> {
  state = {
    model: new VehicleOfficerViewModel(),
    loading: false,
    loaded: true,
    errorOccurred: false,
    errorMessage: '',
  };

  handleEditClick(e: any) {
    this.props.history.push(
      ClientRoutes.VehicleOfficers + '/edit/' + this.state.model!.id
    );
  }

  componentDidMount() {
    this.setState({ ...this.state, loading: true });

    axios
      .get(
        Constants.ApiEndpoint +
          ApiRoutes.VehicleOfficers +
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
          let response = resp.data as Api.VehicleOfficerClientResponseModel;

          console.log(response);

          let mapper = new VehicleOfficerMapper();

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
              <h3>officerId</h3>
              <p>
                {String(this.state.model!.officerIdNavigation!.toDisplay())}
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

export const WrappedVehicleOfficerDetailComponent = Form.create({
  name: 'VehicleOfficer Detail',
})(VehicleOfficerDetailComponent);


/*<Codenesium>
    <Hash>dd161359d6bb25304e397fab0359f359</Hash>
</Codenesium>*/