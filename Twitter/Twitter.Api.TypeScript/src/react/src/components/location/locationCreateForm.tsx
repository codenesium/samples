import React, { Component } from 'react';
import axios from 'axios';
import { CreateResponse } from '../../api/apiObjects';
import { FormikProps, FormikErrors, Field, withFormik } from 'formik';
import * as Yup from 'yup';
import { LoadingForm } from '../../lib/components/loadingForm';
import { ErrorForm } from '../../lib/components/errorForm';
import * as Api from '../../api/models';
import { Constants, ApiRoutes, ClientRoutes } from '../../constants';
import LocationMapper from './locationMapper';
import LocationViewModel from './locationViewModel';

interface Props {
  model?: LocationViewModel;
}

const LocationCreateDisplay: React.SFC<FormikProps<LocationViewModel>> = (
  props: FormikProps<LocationViewModel>
) => {
  let status = props.status as CreateResponse<Api.LocationClientRequestModel>;

  let errorsForField = (name: string): string => {
    let response = '';
    if (
      props.touched[name as keyof LocationViewModel] &&
      props.errors[name as keyof LocationViewModel]
    ) {
      response += props.errors[name as keyof LocationViewModel];
    }

    if (
      status &&
      status.validationErrors &&
      status.validationErrors.find(
        f => f.propertyName.toLowerCase() == name.toLowerCase()
      )
    ) {
      response += status.validationErrors.filter(
        f => f.propertyName.toLowerCase() == name.toLowerCase()
      )[0].errorMessage;
    }

    return response;
  };

  let errorExistForField = (name: string): boolean => {
    return errorsForField(name) != '';
  };

  return (
    <form onSubmit={props.handleSubmit} role="form">
      <div className="form-group row">
        <label
          htmlFor="name"
          className={
            errorExistForField('gpsLat')
              ? 'col-sm-2 col-form-label is-invalid'
              : 'col-sm-2 col-form-label'
          }
        >
          Gps_lat
        </label>
        <div className="col-sm-12">
          <Field
            type="textbox"
            name="gpsLat"
            className={
              errorExistForField('gpsLat')
                ? 'form-control is-invalid'
                : 'form-control'
            }
          />
          {errorExistForField('gpsLat') && (
            <small className="text-danger">{errorsForField('gpsLat')}</small>
          )}
        </div>
      </div>

      <div className="form-group row">
        <label
          htmlFor="name"
          className={
            errorExistForField('gpsLong')
              ? 'col-sm-2 col-form-label is-invalid'
              : 'col-sm-2 col-form-label'
          }
        >
          Gps_long
        </label>
        <div className="col-sm-12">
          <Field
            type="textbox"
            name="gpsLong"
            className={
              errorExistForField('gpsLong')
                ? 'form-control is-invalid'
                : 'form-control'
            }
          />
          {errorExistForField('gpsLong') && (
            <small className="text-danger">{errorsForField('gpsLong')}</small>
          )}
        </div>
      </div>

      <div className="form-group row">
        <label
          htmlFor="name"
          className={
            errorExistForField('locationName')
              ? 'col-sm-2 col-form-label is-invalid'
              : 'col-sm-2 col-form-label'
          }
        >
          Location_name
        </label>
        <div className="col-sm-12">
          <Field
            type="textbox"
            name="locationName"
            className={
              errorExistForField('locationName')
                ? 'form-control is-invalid'
                : 'form-control'
            }
          />
          {errorExistForField('locationName') && (
            <small className="text-danger">
              {errorsForField('locationName')}
            </small>
          )}
        </div>
      </div>

      <button type="submit" className="btn btn-primary" disabled={false}>
        Submit
      </button>
      <br />
      <br />
      {status && status.success ? (
        <div className="alert alert-success">Success</div>
      ) : null}

      {status && !status.success ? (
        <div className="alert alert-danger">Error occurred</div>
      ) : null}
    </form>
  );
};

const LocationCreate = withFormik<Props, LocationViewModel>({
  mapPropsToValues: props => {
    let response = new LocationViewModel();
    if (props.model != undefined) {
      response.setProperties(
        props.model!.gpsLat,
        props.model!.gpsLong,
        props.model!.locationId,
        props.model!.locationName
      );
    }
    return response;
  },

  validate: values => {
    let errors: FormikErrors<LocationViewModel> = {};

    if (values.gpsLat == 0) {
      errors.gpsLat = 'Required';
    }
    if (values.gpsLong == 0) {
      errors.gpsLong = 'Required';
    }
    if (values.locationName == '') {
      errors.locationName = 'Required';
    }

    return errors;
  },

  handleSubmit: (values, actions) => {
    actions.setStatus(undefined);
    let mapper = new LocationMapper();

    axios
      .post(
        Constants.ApiEndpoint + ApiRoutes.Locations,
        mapper.mapViewModelToApiRequest(values),
        {
          headers: {
            'Content-Type': 'application/json',
          },
        }
      )
      .then(
        resp => {
          let response = resp.data as CreateResponse<
            Api.LocationClientRequestModel
          >;
          actions.setStatus(response);
          console.log(response);
        },
        error => {
          console.log(error);
          actions.setStatus('Error from API');
        }
      );
  },
  displayName: 'LocationCreate',
})(LocationCreateDisplay);

interface LocationCreateComponentProps {}

interface LocationCreateComponentState {
  model?: LocationViewModel;
  loading: boolean;
  loaded: boolean;
  errorOccurred: boolean;
  errorMessage: string;
}

export default class LocationCreateComponent extends React.Component<
  LocationCreateComponentProps,
  LocationCreateComponentState
> {
  state = {
    model: undefined,
    loading: false,
    loaded: true,
    errorOccurred: false,
    errorMessage: '',
  };

  render() {
    if (this.state.loading) {
      return <LoadingForm />;
    } else if (this.state.errorOccurred) {
      return <ErrorForm message={this.state.errorMessage} />;
    } else if (this.state.loaded) {
      return <LocationCreate model={this.state.model} />;
    } else {
      return null;
    }
  }
}


/*<Codenesium>
    <Hash>d2e5337eea17ad63f740766aa743c019</Hash>
</Codenesium>*/