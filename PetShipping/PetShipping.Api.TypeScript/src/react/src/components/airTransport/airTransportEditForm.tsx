import React, { Component } from 'react';
import axios from 'axios';
import * as Api from '../../api/models';
import { UpdateResponse } from '../../api/apiObjects';
import { Constants, ApiRoutes, ClientRoutes } from '../../constants';
import { FormikProps, FormikErrors, Field, withFormik } from 'formik';
import { LoadingForm } from '../../lib/components/loadingForm';
import { ErrorForm } from '../../lib/components/errorForm';
import AirTransportViewModel from './airTransportViewModel';
import AirTransportMapper from './airTransportMapper';

interface Props {
  model?: AirTransportViewModel;
}

const AirTransportEditDisplay = (props: FormikProps<AirTransportViewModel>) => {
  let status = props.status as UpdateResponse<
    Api.AirTransportClientRequestModel
  >;

  let errorsForField = (name: string): string => {
    let response = '';
    if (
      props.touched[name as keyof AirTransportViewModel] &&
      props.errors[name as keyof AirTransportViewModel]
    ) {
      response += props.errors[name as keyof AirTransportViewModel];
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
            errorExistForField('airlineId')
              ? 'col-sm-2 col-form-label is-invalid'
              : 'col-sm-2 col-form-label'
          }
        >
          AirlineId
        </label>
        <div className="col-sm-12">
          <Field
            type="datetime-local"
            name="airlineId"
            className={
              errorExistForField('airlineId')
                ? 'form-control is-invalid'
                : 'form-control'
            }
          />
          {errorExistForField('airlineId') && (
            <small className="text-danger">{errorsForField('airlineId')}</small>
          )}
        </div>
      </div>
      <div className="form-group row">
        <label
          htmlFor="name"
          className={
            errorExistForField('flightNumber')
              ? 'col-sm-2 col-form-label is-invalid'
              : 'col-sm-2 col-form-label'
          }
        >
          FlightNumber
        </label>
        <div className="col-sm-12">
          <Field
            type="datetime-local"
            name="flightNumber"
            className={
              errorExistForField('flightNumber')
                ? 'form-control is-invalid'
                : 'form-control'
            }
          />
          {errorExistForField('flightNumber') && (
            <small className="text-danger">
              {errorsForField('flightNumber')}
            </small>
          )}
        </div>
      </div>
      <div className="form-group row">
        <label
          htmlFor="name"
          className={
            errorExistForField('handlerId')
              ? 'col-sm-2 col-form-label is-invalid'
              : 'col-sm-2 col-form-label'
          }
        >
          HandlerId
        </label>
        <div className="col-sm-12">
          <Field
            type="datetime-local"
            name="handlerId"
            className={
              errorExistForField('handlerId')
                ? 'form-control is-invalid'
                : 'form-control'
            }
          />
          {errorExistForField('handlerId') && (
            <small className="text-danger">{errorsForField('handlerId')}</small>
          )}
        </div>
      </div>
      <div className="form-group row">
        <label
          htmlFor="name"
          className={
            errorExistForField('id')
              ? 'col-sm-2 col-form-label is-invalid'
              : 'col-sm-2 col-form-label'
          }
        >
          Id
        </label>
        <div className="col-sm-12">
          <Field
            type="datetime-local"
            name="id"
            className={
              errorExistForField('id')
                ? 'form-control is-invalid'
                : 'form-control'
            }
          />
          {errorExistForField('id') && (
            <small className="text-danger">{errorsForField('id')}</small>
          )}
        </div>
      </div>
      <div className="form-group row">
        <label
          htmlFor="name"
          className={
            errorExistForField('landDate')
              ? 'col-sm-2 col-form-label is-invalid'
              : 'col-sm-2 col-form-label'
          }
        >
          LandDate
        </label>
        <div className="col-sm-12">
          <Field
            type="datetime-local"
            name="landDate"
            className={
              errorExistForField('landDate')
                ? 'form-control is-invalid'
                : 'form-control'
            }
          />
          {errorExistForField('landDate') && (
            <small className="text-danger">{errorsForField('landDate')}</small>
          )}
        </div>
      </div>
      <div className="form-group row">
        <label
          htmlFor="name"
          className={
            errorExistForField('pipelineStepId')
              ? 'col-sm-2 col-form-label is-invalid'
              : 'col-sm-2 col-form-label'
          }
        >
          PipelineStepId
        </label>
        <div className="col-sm-12">
          <Field
            type="datetime-local"
            name="pipelineStepId"
            className={
              errorExistForField('pipelineStepId')
                ? 'form-control is-invalid'
                : 'form-control'
            }
          />
          {errorExistForField('pipelineStepId') && (
            <small className="text-danger">
              {errorsForField('pipelineStepId')}
            </small>
          )}
        </div>
      </div>
      <div className="form-group row">
        <label
          htmlFor="name"
          className={
            errorExistForField('takeoffDate')
              ? 'col-sm-2 col-form-label is-invalid'
              : 'col-sm-2 col-form-label'
          }
        >
          TakeoffDate
        </label>
        <div className="col-sm-12">
          <Field
            type="datetime-local"
            name="takeoffDate"
            className={
              errorExistForField('takeoffDate')
                ? 'form-control is-invalid'
                : 'form-control'
            }
          />
          {errorExistForField('takeoffDate') && (
            <small className="text-danger">
              {errorsForField('takeoffDate')}
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

const AirTransportEdit = withFormik<Props, AirTransportViewModel>({
  mapPropsToValues: props => {
    let response = new AirTransportViewModel();
    response.setProperties(
      props.model!.airlineId,
      props.model!.flightNumber,
      props.model!.handlerId,
      props.model!.id,
      props.model!.landDate,
      props.model!.pipelineStepId,
      props.model!.takeoffDate
    );
    return response;
  },

  // Custom sync validation
  validate: values => {
    let errors: FormikErrors<AirTransportViewModel> = {};

    if (values.airlineId == 0) {
      errors.airlineId = 'Required';
    }
    if (values.flightNumber == '') {
      errors.flightNumber = 'Required';
    }
    if (values.handlerId == 0) {
      errors.handlerId = 'Required';
    }
    if (values.id == 0) {
      errors.id = 'Required';
    }
    if (values.landDate == undefined) {
      errors.landDate = 'Required';
    }
    if (values.pipelineStepId == 0) {
      errors.pipelineStepId = 'Required';
    }
    if (values.takeoffDate == undefined) {
      errors.takeoffDate = 'Required';
    }

    return errors;
  },
  handleSubmit: (values, actions) => {
    actions.setStatus(undefined);

    let mapper = new AirTransportMapper();

    axios
      .put(
        Constants.ApiEndpoint +
          ApiRoutes.AirTransports +
          '/' +
          values.airlineId,

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
            Api.AirTransportClientRequestModel
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

  displayName: 'AirTransportEdit',
})(AirTransportEditDisplay);

interface IParams {
  airlineId: number;
}

interface IMatch {
  params: IParams;
}

interface AirTransportEditComponentProps {
  match: IMatch;
}

interface AirTransportEditComponentState {
  model?: AirTransportViewModel;
  loading: boolean;
  loaded: boolean;
  errorOccurred: boolean;
  errorMessage: string;
}

export default class AirTransportEditComponent extends React.Component<
  AirTransportEditComponentProps,
  AirTransportEditComponentState
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
          ApiRoutes.AirTransports +
          '/' +
          this.props.match.params.airlineId,
        {
          headers: {
            'Content-Type': 'application/json',
          },
        }
      )
      .then(
        resp => {
          let response = resp.data as Api.AirTransportClientResponseModel;

          console.log(response);

          let mapper = new AirTransportMapper();

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
      return <AirTransportEdit model={this.state.model} />;
    } else {
      return null;
    }
  }
}


/*<Codenesium>
    <Hash>f0da6c1db3168bf7378d4de5e9b4e66d</Hash>
</Codenesium>*/