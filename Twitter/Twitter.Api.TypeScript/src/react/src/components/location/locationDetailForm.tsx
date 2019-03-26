import React, { Component, FormEvent } from 'react';
import axios, { AxiosError, AxiosResponse } from 'axios';
import { Constants, ApiRoutes, ClientRoutes } from '../../constants';
import * as Api from '../../api/models';
import LocationMapper from './locationMapper';
import LocationViewModel from './locationViewModel';
import { Form, Input, Button, Spin, Alert } from 'antd';
import { WrappedFormUtils } from 'antd/es/form/Form';
import * as GlobalUtilities from '../../lib/globalUtilities';
import { TweetTableComponent } from '../shared/tweetTable';
import { UserTableComponent } from '../shared/userTable';

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
      ClientRoutes.Locations + '/edit/' + this.state.model!.locationId
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
              <h3>gps_lat</h3>
              <p>{String(this.state.model!.gpsLat)}</p>
            </div>
            <div>
              <h3>gps_long</h3>
              <p>{String(this.state.model!.gpsLong)}</p>
            </div>
            <div>
              <h3>location_name</h3>
              <p>{String(this.state.model!.locationName)}</p>
            </div>
          </div>
          {message}
          <div>
            <h3>Tweets</h3>
            <TweetTableComponent
              history={this.props.history}
              match={this.props.match}
              apiRoute={
                Constants.ApiEndpoint +
                ApiRoutes.Locations +
                '/' +
                this.state.model!.locationId +
                '/' +
                ApiRoutes.Tweets
              }
            />
          </div>
          <div>
            <h3>Users</h3>
            <UserTableComponent
              history={this.props.history}
              match={this.props.match}
              apiRoute={
                Constants.ApiEndpoint +
                ApiRoutes.Locations +
                '/' +
                this.state.model!.locationId +
                '/' +
                ApiRoutes.Users
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
    <Hash>28216cf9d74c08bcd51f1d1e93b4d658</Hash>
</Codenesium>*/