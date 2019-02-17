import React, { Component } from 'react';
import axios from 'axios';
import { CreateResponse } from '../../api/apiObjects';
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
            errorExistForField('actualEndDate')
              ? 'col-sm-2 col-form-label is-invalid'
              : 'col-sm-2 col-form-label'
          }
        >
          ActualEndDate
        </label>
        <div className="col-sm-12">
          <Field
            type="datetime-local"
            name="actualEndDate"
            className={
              errorExistForField('actualEndDate')
                ? 'form-control is-invalid'
                : 'form-control'
            }
          />
          {errorExistForField('actualEndDate') && (
            <small className="text-danger">
              {errorsForField('actualEndDate')}
            </small>
          )}
        </div>
      </div>

      <div className="form-group row">
        <label
          htmlFor="name"
          className={
            errorExistForField('actualStartDate')
              ? 'col-sm-2 col-form-label is-invalid'
              : 'col-sm-2 col-form-label'
          }
        >
          ActualStartDate
        </label>
        <div className="col-sm-12">
          <Field
            type="datetime-local"
            name="actualStartDate"
            className={
              errorExistForField('actualStartDate')
                ? 'form-control is-invalid'
                : 'form-control'
            }
          />
          {errorExistForField('actualStartDate') && (
            <small className="text-danger">
              {errorsForField('actualStartDate')}
            </small>
          )}
        </div>
      </div>

      <div className="form-group row">
        <label
          htmlFor="name"
          className={
            errorExistForField('billAmount')
              ? 'col-sm-2 col-form-label is-invalid'
              : 'col-sm-2 col-form-label'
          }
        >
          BillAmount
        </label>
        <div className="col-sm-12">
          <Field
            type="datetime-local"
            name="billAmount"
            className={
              errorExistForField('billAmount')
                ? 'form-control is-invalid'
                : 'form-control'
            }
          />
          {errorExistForField('billAmount') && (
            <small className="text-danger">
              {errorsForField('billAmount')}
            </small>
          )}
        </div>
      </div>

      <div className="form-group row">
        <label
          htmlFor="name"
          className={
            errorExistForField('eventStatusId')
              ? 'col-sm-2 col-form-label is-invalid'
              : 'col-sm-2 col-form-label'
          }
        >
          EventStatusId
        </label>
        <div className="col-sm-12">
          <Field
            type="datetime-local"
            name="eventStatusId"
            className={
              errorExistForField('eventStatusId')
                ? 'form-control is-invalid'
                : 'form-control'
            }
          />
          {errorExistForField('eventStatusId') && (
            <small className="text-danger">
              {errorsForField('eventStatusId')}
            </small>
          )}
        </div>
      </div>

      <div className="form-group row">
        <label
          htmlFor="name"
          className={
            errorExistForField('scheduledEndDate')
              ? 'col-sm-2 col-form-label is-invalid'
              : 'col-sm-2 col-form-label'
          }
        >
          ScheduledEndDate
        </label>
        <div className="col-sm-12">
          <Field
            type="datetime-local"
            name="scheduledEndDate"
            className={
              errorExistForField('scheduledEndDate')
                ? 'form-control is-invalid'
                : 'form-control'
            }
          />
          {errorExistForField('scheduledEndDate') && (
            <small className="text-danger">
              {errorsForField('scheduledEndDate')}
            </small>
          )}
        </div>
      </div>

      <div className="form-group row">
        <label
          htmlFor="name"
          className={
            errorExistForField('scheduledStartDate')
              ? 'col-sm-2 col-form-label is-invalid'
              : 'col-sm-2 col-form-label'
          }
        >
          ScheduledStartDate
        </label>
        <div className="col-sm-12">
          <Field
            type="datetime-local"
            name="scheduledStartDate"
            className={
              errorExistForField('scheduledStartDate')
                ? 'form-control is-invalid'
                : 'form-control'
            }
          />
          {errorExistForField('scheduledStartDate') && (
            <small className="text-danger">
              {errorsForField('scheduledStartDate')}
            </small>
          )}
        </div>
      </div>

      <div className="form-group row">
        <label
          htmlFor="name"
          className={
            errorExistForField('studentNote')
              ? 'col-sm-2 col-form-label is-invalid'
              : 'col-sm-2 col-form-label'
          }
        >
          StudentNotes
        </label>
        <div className="col-sm-12">
          <Field
            type="datetime-local"
            name="studentNote"
            className={
              errorExistForField('studentNote')
                ? 'form-control is-invalid'
                : 'form-control'
            }
          />
          {errorExistForField('studentNote') && (
            <small className="text-danger">
              {errorsForField('studentNote')}
            </small>
          )}
        </div>
      </div>

      <div className="form-group row">
        <label
          htmlFor="name"
          className={
            errorExistForField('teacherNote')
              ? 'col-sm-2 col-form-label is-invalid'
              : 'col-sm-2 col-form-label'
          }
        >
          TeacherNotes
        </label>
        <div className="col-sm-12">
          <Field
            type="datetime-local"
            name="teacherNote"
            className={
              errorExistForField('teacherNote')
                ? 'form-control is-invalid'
                : 'form-control'
            }
          />
          {errorExistForField('teacherNote') && (
            <small className="text-danger">
              {errorsForField('teacherNote')}
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

const EventCreate = withFormik<Props, EventViewModel>({
  mapPropsToValues: props => {
    let response = new EventViewModel();
    if (props.model != undefined) {
      response.setProperties(
        props.model!.actualEndDate,
        props.model!.actualStartDate,
        props.model!.billAmount,
        props.model!.eventStatusId,
        props.model!.id,
        props.model!.scheduledEndDate,
        props.model!.scheduledStartDate,
        props.model!.studentNote,
        props.model!.teacherNote
      );
    }
    return response;
  },

  validate: values => {
    let errors: FormikErrors<EventViewModel> = {};

    if (values.eventStatusId == 0) {
      errors.eventStatusId = 'Required';
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
    <Hash>5d68a26808bf7545229a739b64bd0918</Hash>
</Codenesium>*/