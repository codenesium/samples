import React, { Component } from 'react';
import axios from 'axios';
import { CreateResponse } from '../../api/ApiObjects';
import { FormikProps, FormikErrors, Field, withFormik } from 'formik';
import * as Yup from 'yup';
import { LoadingForm } from '../../lib/components/loadingForm';
import { ErrorForm } from '../../lib/components/errorForm';
import * as Api from '../../api/models';
import { Constants, ApiRoutes, ClientRoutes } from '../../constants';
import EventMapper from './eventMapper';
import EventViewModel from './eventViewModel';

interface Props {
  model?: EventViewModel;
}

const EventCreateDisplay: React.SFC<FormikProps<EventViewModel>> = (
  props: FormikProps<EventViewModel>
) => {
  let status = props.status as CreateResponse<Api.EventClientRequestModel>;

  let errorsForField = (name: string): string => {
    let response = '';
    if (
      props.touched[name as keyof EventViewModel] &&
      props.errors[name as keyof EventViewModel]
    ) {
      response += props.errors[name as keyof EventViewModel];
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
            errorExistForField('address1')
              ? 'col-sm-2 col-form-label is-invalid'
              : 'col-sm-2 col-form-label'
          }
        >
          Address1
        </label>
        <div className="col-sm-12">
          <Field
            type="datetime-local"
            name="address1"
            className={
              errorExistForField('address1')
                ? 'form-control is-invalid'
                : 'form-control'
            }
          />
          {errorExistForField('address1') && (
            <small className="text-danger">{errorsForField('address1')}</small>
          )}
        </div>
      </div>

      <div className="form-group row">
        <label
          htmlFor="name"
          className={
            errorExistForField('address2')
              ? 'col-sm-2 col-form-label is-invalid'
              : 'col-sm-2 col-form-label'
          }
        >
          Address2
        </label>
        <div className="col-sm-12">
          <Field
            type="datetime-local"
            name="address2"
            className={
              errorExistForField('address2')
                ? 'form-control is-invalid'
                : 'form-control'
            }
          />
          {errorExistForField('address2') && (
            <small className="text-danger">{errorsForField('address2')}</small>
          )}
        </div>
      </div>

      <div className="form-group row">
        <label
          htmlFor="name"
          className={
            errorExistForField('cityId')
              ? 'col-sm-2 col-form-label is-invalid'
              : 'col-sm-2 col-form-label'
          }
        >
          CityId
        </label>
        <div className="col-sm-12">
          <Field
            type="datetime-local"
            name="cityId"
            className={
              errorExistForField('cityId')
                ? 'form-control is-invalid'
                : 'form-control'
            }
          />
          {errorExistForField('cityId') && (
            <small className="text-danger">{errorsForField('cityId')}</small>
          )}
        </div>
      </div>

      <div className="form-group row">
        <label
          htmlFor="name"
          className={
            errorExistForField('date')
              ? 'col-sm-2 col-form-label is-invalid'
              : 'col-sm-2 col-form-label'
          }
        >
          Date
        </label>
        <div className="col-sm-12">
          <Field
            type="datetime-local"
            name="date"
            className={
              errorExistForField('date')
                ? 'form-control is-invalid'
                : 'form-control'
            }
          />
          {errorExistForField('date') && (
            <small className="text-danger">{errorsForField('date')}</small>
          )}
        </div>
      </div>

      <div className="form-group row">
        <label
          htmlFor="name"
          className={
            errorExistForField('description')
              ? 'col-sm-2 col-form-label is-invalid'
              : 'col-sm-2 col-form-label'
          }
        >
          Description
        </label>
        <div className="col-sm-12">
          <Field
            type="datetime-local"
            name="description"
            className={
              errorExistForField('description')
                ? 'form-control is-invalid'
                : 'form-control'
            }
          />
          {errorExistForField('description') && (
            <small className="text-danger">
              {errorsForField('description')}
            </small>
          )}
        </div>
      </div>

      <div className="form-group row">
        <label
          htmlFor="name"
          className={
            errorExistForField('endDate')
              ? 'col-sm-2 col-form-label is-invalid'
              : 'col-sm-2 col-form-label'
          }
        >
          EndDate
        </label>
        <div className="col-sm-12">
          <Field
            type="datetime-local"
            name="endDate"
            className={
              errorExistForField('endDate')
                ? 'form-control is-invalid'
                : 'form-control'
            }
          />
          {errorExistForField('endDate') && (
            <small className="text-danger">{errorsForField('endDate')}</small>
          )}
        </div>
      </div>

      <div className="form-group row">
        <label
          htmlFor="name"
          className={
            errorExistForField('facebook')
              ? 'col-sm-2 col-form-label is-invalid'
              : 'col-sm-2 col-form-label'
          }
        >
          Facebook
        </label>
        <div className="col-sm-12">
          <Field
            type="datetime-local"
            name="facebook"
            className={
              errorExistForField('facebook')
                ? 'form-control is-invalid'
                : 'form-control'
            }
          />
          {errorExistForField('facebook') && (
            <small className="text-danger">{errorsForField('facebook')}</small>
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

      <div className="form-group row">
        <label
          htmlFor="name"
          className={
            errorExistForField('startDate')
              ? 'col-sm-2 col-form-label is-invalid'
              : 'col-sm-2 col-form-label'
          }
        >
          StartDate
        </label>
        <div className="col-sm-12">
          <Field
            type="datetime-local"
            name="startDate"
            className={
              errorExistForField('startDate')
                ? 'form-control is-invalid'
                : 'form-control'
            }
          />
          {errorExistForField('startDate') && (
            <small className="text-danger">{errorsForField('startDate')}</small>
          )}
        </div>
      </div>

      <div className="form-group row">
        <label
          htmlFor="name"
          className={
            errorExistForField('website')
              ? 'col-sm-2 col-form-label is-invalid'
              : 'col-sm-2 col-form-label'
          }
        >
          Website
        </label>
        <div className="col-sm-12">
          <Field
            type="datetime-local"
            name="website"
            className={
              errorExistForField('website')
                ? 'form-control is-invalid'
                : 'form-control'
            }
          />
          {errorExistForField('website') && (
            <small className="text-danger">{errorsForField('website')}</small>
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

const EventCreate = withFormik<Props, EventViewModel>({
  mapPropsToValues: props => {
    let response = new EventViewModel();
    if (props.model != undefined) {
      response.setProperties(
        props.model!.address1,
        props.model!.address2,
        props.model!.cityId,
        props.model!.date,
        props.model!.description,
        props.model!.endDate,
        props.model!.facebook,
        props.model!.id,
        props.model!.name,
        props.model!.startDate,
        props.model!.website
      );
    }
    return response;
  },

  validate: values => {
    let errors: FormikErrors<EventViewModel> = {};

    if (values.address1 == '') {
      errors.address1 = 'Required';
    }
    if (values.address2 == '') {
      errors.address2 = 'Required';
    }
    if (values.cityId == 0) {
      errors.cityId = 'Required';
    }
    if (values.date == undefined) {
      errors.date = 'Required';
    }
    if (values.description == '') {
      errors.description = 'Required';
    }
    if (values.endDate == undefined) {
      errors.endDate = 'Required';
    }
    if (values.facebook == '') {
      errors.facebook = 'Required';
    }
    if (values.name == '') {
      errors.name = 'Required';
    }
    if (values.startDate == undefined) {
      errors.startDate = 'Required';
    }
    if (values.website == '') {
      errors.website = 'Required';
    }

    return errors;
  },

  handleSubmit: (values, actions) => {
    actions.setStatus(undefined);
    let mapper = new EventMapper();

    axios
      .post(
        Constants.ApiEndpoint + ApiRoutes.Events,
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
            Api.EventClientRequestModel
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
  displayName: 'EventCreate',
})(EventCreateDisplay);

interface EventCreateComponentProps {}

interface EventCreateComponentState {
  model?: EventViewModel;
  loading: boolean;
  loaded: boolean;
  errorOccurred: boolean;
  errorMessage: string;
}

export default class EventCreateComponent extends React.Component<
  EventCreateComponentProps,
  EventCreateComponentState
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
      return <EventCreate model={this.state.model} />;
    } else {
      return null;
    }
  }
}


/*<Codenesium>
    <Hash>05858d3ebf6f9d20034dbad361901f8f</Hash>
</Codenesium>*/