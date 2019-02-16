import React, { Component } from 'react';
import axios from 'axios';
import * as Api from '../../api/models';
import { UpdateResponse } from '../../api/ApiObjects';
import Constants from '../../constants';
import { FormikProps, FormikErrors, Field, withFormik } from 'formik';
import LocationMapper from './locationMapper';
import LocationViewModel from './locationViewModel';

interface Props {
  model?: LocationViewModel;
}

const LocationDetailDisplay = (model: Props) => {
  return (
    <form role="form">
      <div className="form-group row">
        <label htmlFor="availability" className={'col-sm-2 col-form-label'}>
          Availability
        </label>
        <div className="col-sm-12">{String(model.model!.availability)}</div>
      </div>

      <div className="form-group row">
        <label htmlFor="costRate" className={'col-sm-2 col-form-label'}>
          CostRate
        </label>
        <div className="col-sm-12">{String(model.model!.costRate)}</div>
      </div>

      <div className="form-group row">
        <label htmlFor="locationID" className={'col-sm-2 col-form-label'}>
          LocationID
        </label>
        <div className="col-sm-12">{String(model.model!.locationID)}</div>
      </div>

      <div className="form-group row">
        <label htmlFor="modifiedDate" className={'col-sm-2 col-form-label'}>
          ModifiedDate
        </label>
        <div className="col-sm-12">{String(model.model!.modifiedDate)}</div>
      </div>

      <div className="form-group row">
        <label htmlFor="name" className={'col-sm-2 col-form-label'}>
          Name
        </label>
        <div className="col-sm-12">{String(model.model!.name)}</div>
      </div>
    </form>
  );
};

interface IParams {
  locationID: number;
}

interface IMatch {
  params: IParams;
}

interface LocationDetailComponentProps {
  match: IMatch;
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
        Constants.ApiUrl + 'locations/' + this.props.match.params.locationID,
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
      return <div>loading</div>;
    } else if (this.state.loaded) {
      return <LocationDetailDisplay model={this.state.model} />;
    } else if (this.state.errorOccurred) {
      return (
        <div className="alert alert-danger">{this.state.errorMessage}</div>
      );
    } else {
      return <div />;
    }
  }
}


/*<Codenesium>
    <Hash>22b839a92dca3052daacec938ae5396d</Hash>
</Codenesium>*/