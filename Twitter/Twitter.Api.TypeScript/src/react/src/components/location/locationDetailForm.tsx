import React, { Component } from 'react';
import axios from 'axios';
import * as Api from '../../api/models';
import { UpdateResponse } from '../../api/apiObjects';
import { Constants, ApiRoutes, ClientRoutes } from '../../constants';
import { FormikProps, FormikErrors, Field, withFormik } from 'formik';
import { LoadingForm } from '../../lib/components/loadingForm';
import { ErrorForm } from '../../lib/components/errorForm';
import LocationMapper from './locationMapper';
import LocationViewModel from './locationViewModel';

interface Props {
  history: any;
  model?: LocationViewModel;
}

const LocationDetailDisplay = (model: Props) => {
  return (
    <form role="form">
      <button
        className="btn btn-primary btn-sm align-middle float-right vertically-center"
        onClick={e => {
          model.history.push(
            ClientRoutes.Locations + '/edit/' + model.model!.locationId
          );
        }}
      >
        <i className="fas fa-edit" />
      </button>
      <div className="form-group row">
        <label htmlFor="gpsLat" className={'col-sm-2 col-form-label'}>
          Gps_lat
        </label>
        <div className="col-sm-12">{String(model.model!.gpsLat)}</div>
      </div>
      <div className="form-group row">
        <label htmlFor="gpsLong" className={'col-sm-2 col-form-label'}>
          Gps_long
        </label>
        <div className="col-sm-12">{String(model.model!.gpsLong)}</div>
      </div>
      <div className="form-group row">
        <label htmlFor="locationName" className={'col-sm-2 col-form-label'}>
          Location_name
        </label>
        <div className="col-sm-12">{String(model.model!.locationName)}</div>
      </div>
    </form>
  );
};

interface IParams {
  locationId: number;
}

interface IMatch {
  params: IParams;
}

interface LocationDetailComponentProps {
  match: IMatch;
  history: any;
}

interface LocationDetailComponentState {
  model?: LocationViewModel;
  loading: boolean;
  loaded: boolean;
  errorOccurred: boolean;
  errorMessage: string;
}

export default class LocationDetailComponent extends React.Component<
  LocationDetailComponentProps,
  LocationDetailComponentState
> {
  state = {
    model: undefined,
    loading: false,
    loaded: false,
    errorOccurred: false,
    errorMessage: '',
  };

  componentDidMount() {
    this.setState({ ...this.state, loading: true });

    axios
      .get(
        Constants.ApiEndpoint +
          ApiRoutes.Locations +
          '/' +
          this.props.match.params.locationId,
        {
          headers: {
            'Content-Type': 'application/json',
          },
        }
      )
      .then(
        resp => {
          let response = resp.data as Api.LocationClientResponseModel;

          let mapper = new LocationMapper();

          console.log(response);

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
            loaded: false,
            errorOccurred: true,
            errorMessage: 'Error from API',
          });
        }
      );
  }
  render() {
    if (this.state.loading) {
      return <LoadingForm />;
    } else if (this.state.errorOccurred) {
      return <ErrorForm message={this.state.errorMessage} />;
    } else if (this.state.loaded) {
      return (
        <LocationDetailDisplay
          history={this.props.history}
          model={this.state.model}
        />
      );
    } else {
      return null;
    }
  }
}


/*<Codenesium>
    <Hash>dd911879849dbde6b2dd07be8c9fce7e</Hash>
</Codenesium>*/