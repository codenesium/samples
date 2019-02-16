import React, { Component } from 'react';
import axios from 'axios';
import * as Api from '../../api/models';
import { UpdateResponse } from '../../api/ApiObjects';
import Constants from '../../constants';
import { FormikProps, FormikErrors, Field, withFormik } from 'formik';
import LocationViewModel from './locationViewModel';
import LocationMapper from './locationMapper';

interface Props {
  model?: LocationViewModel;
}

const LocationEditDisplay = (props: FormikProps<LocationViewModel>) => {
  let status = props.status as UpdateResponse<Api.LocationClientRequestModel>;

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
            errorExistForField('availability')
              ? 'col-sm-2 col-form-label is-invalid'
              : 'col-sm-2 col-form-label'
          }
        >
          Availability
        </label>
        <div className="col-sm-12">
          <Field
            type="datetime-local"
            name="availability"
            className={
              errorExistForField('availability')
                ? 'form-control is-invalid'
                : 'form-control'
            }
          />
          {errorExistForField('availability') && (
            <small className="text-danger">
              {errorsForField('availability')}
            </small>
          )}
        </div>
      </div>
      <div className="form-group row">
        <label
          htmlFor="name"
          className={
            errorExistForField('costRate')
              ? 'col-sm-2 col-form-label is-invalid'
              : 'col-sm-2 col-form-label'
          }
        >
          CostRate
        </label>
        <div className="col-sm-12">
          <Field
            type="datetime-local"
            name="costRate"
            className={
              errorExistForField('costRate')
                ? 'form-control is-invalid'
                : 'form-control'
            }
          />
          {errorExistForField('costRate') && (
            <small className="text-danger">{errorsForField('costRate')}</small>
          )}
        </div>
      </div>
      <div className="form-group row">
        <label
          htmlFor="name"
          className={
            errorExistForField('locationID')
              ? 'col-sm-2 col-form-label is-invalid'
              : 'col-sm-2 col-form-label'
          }
        >
          LocationID
        </label>
        <div className="col-sm-12">
          <Field
            type="datetime-local"
            name="locationID"
            className={
              errorExistForField('locationID')
                ? 'form-control is-invalid'
                : 'form-control'
            }
          />
          {errorExistForField('locationID') && (
            <small className="text-danger">
              {errorsForField('locationID')}
            </small>
          )}
        </div>
      </div>
      <div className="form-group row">
        <label
          htmlFor="name"
          className={
            errorExistForField('modifiedDate')
              ? 'col-sm-2 col-form-label is-invalid'
              : 'col-sm-2 col-form-label'
          }
        >
          ModifiedDate
        </label>
        <div className="col-sm-12">
          <Field
            type="datetime-local"
            name="modifiedDate"
            className={
              errorExistForField('modifiedDate')
                ? 'form-control is-invalid'
                : 'form-control'
            }
          />
          {errorExistForField('modifiedDate') && (
            <small className="text-danger">
              {errorsForField('modifiedDate')}
            </small>
          )}
        </div>
      </div>
      <div className="form-group row">
        <label
          htmlFor="name"
          className={
            errorExistForField('name')
              ? 'col-sm-2 col-form-label is-invalid'
              : 'col-sm-2 col-form-label'
          }
        >
          Name
        </label>
        <div className="col-sm-12">
          <Field
            type="datetime-local"
            name="name"
            className={
              errorExistForField('name')
                ? 'form-control is-invalid'
                : 'form-control'
            }
          />
          {errorExistForField('name') && (
            <small className="text-danger">{errorsForField('name')}</small>
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

const LocationUpdate = withFormik<Props, LocationViewModel>({
  mapPropsToValues: props => {
    let response = new LocationViewModel();
    response.setProperties(
      props.model!.availability,
      props.model!.costRate,
      props.model!.locationID,
      props.model!.modifiedDate,
      props.model!.name
    );
    return response;
  },

  // Custom sync validation
  validate: values => {
    let errors: FormikErrors<LocationViewModel> = {};

    if (values.availability == 0) {
      errors.availability = 'Required';
    }
    if (values.costRate == 0) {
      errors.costRate = 'Required';
    }
    if (values.locationID == 0) {
      errors.locationID = 'Required';
    }
    if (values.modifiedDate == undefined) {
      errors.modifiedDate = 'Required';
    }
    if (values.name == '') {
      errors.name = 'Required';
    }

    return errors;
  },
  handleSubmit: (values, actions) => {
    actions.setStatus(undefined);

    let mapper = new LocationMapper();

    axios
      .put(
        Constants.ApiUrl + 'locations/' + values.locationID,

        mapper.mapViewModelToApiRequest(values),
        {
          headers: {
            'Content-Type': 'application/json',
          },
        }
      )
      .then(
        resp => {
          let response = resp.data as UpdateResponse<
            Api.LocationClientRequestModel
          >;
          actions.setStatus(response);
          console.log(response);
        },
        error => {
          console.log(error);
          actions.setStatus('Error from API');
        }
      )
      .then(response => {
        // cleanup
      });
  },

  displayName: 'LocationEdit',
})(LocationEditDisplay);

interface IParams {
  locationID: number;
}

interface IMatch {
  params: IParams;
}

interface LocationEditComponentProps {
  match: IMatch;
}

interface LocationEditComponentState {
  model?: LocationViewModel;
  loading: boolean;
  loaded: boolean;
  errorOccurred: boolean;
  errorMessage: string;
}

export default class LocationEditComponent extends React.Component<
  LocationEditComponentProps,
  LocationEditComponentState
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
      return <LocationUpdate model={this.state.model} />;
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
    <Hash>5ba0799a7f6cae94ba8ff71383abfa96</Hash>
</Codenesium>*/