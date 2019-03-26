import React, { Component, FormEvent } from 'react';
import axios, { AxiosError, AxiosResponse } from 'axios';
import { Constants, ApiRoutes, ClientRoutes } from '../../constants';
import * as Api from '../../api/models';
import LocationMapper from './locationMapper';
import LocationViewModel from './locationViewModel';
import { Form, Input, Button, Spin, Alert } from 'antd';
import { WrappedFormUtils } from 'antd/es/form/Form';
import * as GlobalUtilities from '../../lib/globalUtilities';
import { ProductInventoryTableComponent } from '../shared/productInventoryTable';
import { WorkOrderRoutingTableComponent } from '../shared/workOrderRoutingTable';

interface LocationDetailComponentProps {
  form: WrappedFormUtils;
  history: any;
  match: any;
}

interface LocationDetailComponentState {
  model?: LocationViewModel;
  loading: boolean;
  loaded: boolean;
  errorOccurred: boolean;
  errorMessage: string;
}

class LocationDetailComponent extends React.Component<
  LocationDetailComponentProps,
  LocationDetailComponentState
> {
  state = {
    model: new LocationViewModel(),
    loading: false,
    loaded: true,
    errorOccurred: false,
    errorMessage: '',
  };

  handleEditClick(e: any) {
    this.props.history.push(
      ClientRoutes.Locations + '/edit/' + this.state.model!.locationID
    );
  }

  componentDidMount() {
    this.setState({ ...this.state, loading: true });

    axios
      .get<Api.LocationClientResponseModel>(
        Constants.ApiEndpoint +
          ApiRoutes.Locations +
          '/' +
          this.props.match.params.id,
        {
          headers: GlobalUtilities.defaultHeaders(),
        }
      )
      .then(response => {
        GlobalUtilities.logInfo(response);

        let mapper = new LocationMapper();

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
              <h3>Availability</h3>
              <p>{String(this.state.model!.availability)}</p>
            </div>
            <div>
              <h3>Cost Rate</h3>
              <p>{String(this.state.model!.costRate)}</p>
            </div>
            <div>
              <h3>Modified Date</h3>
              <p>{String(this.state.model!.modifiedDate)}</p>
            </div>
            <div>
              <h3>Name</h3>
              <p>{String(this.state.model!.name)}</p>
            </div>
          </div>
          {message}
          <div>
            <h3>ProductInventories</h3>
            <ProductInventoryTableComponent
              history={this.props.history}
              match={this.props.match}
              apiRoute={
                Constants.ApiEndpoint +
                ApiRoutes.Locations +
                '/' +
                this.state.model!.locationID +
                '/' +
                ApiRoutes.ProductInventories
              }
            />
          </div>
          <div>
            <h3>WorkOrderRoutings</h3>
            <WorkOrderRoutingTableComponent
              history={this.props.history}
              match={this.props.match}
              apiRoute={
                Constants.ApiEndpoint +
                ApiRoutes.Locations +
                '/' +
                this.state.model!.locationID +
                '/' +
                ApiRoutes.WorkOrderRoutings
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

export const WrappedLocationDetailComponent = Form.create({
  name: 'Location Detail',
})(LocationDetailComponent);


/*<Codenesium>
    <Hash>1e4f206a6b35fa1816084ad6c3202f35</Hash>
</Codenesium>*/