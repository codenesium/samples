import React, { Component, FormEvent } from 'react';
import axios from 'axios';
import { Constants, ApiRoutes, ClientRoutes } from '../../constants';
import * as Api from '../../api/models';
import LocationMapper from './locationMapper';
import LocationViewModel from './locationViewModel';
import { Form, Input, Button, Spin, Alert } from 'antd';
import { WrappedFormUtils } from 'antd/es/form/Form';
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
      .get(
        Constants.ApiEndpoint +
          ApiRoutes.Locations +
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
          let response = resp.data as Api.LocationClientResponseModel;

          console.log(response);

          let mapper = new LocationMapper();

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
              tweetId={this.state.model!.tweetId}
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
              userId={this.state.model!.userId}
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
    <Hash>7cef6b59a23736fcfae7c40f461217f8</Hash>
</Codenesium>*/