import React, { Component } from 'react';
import axios from 'axios';
import * as Api from '../../api/models';
import { UpdateResponse } from '../../api/ApiObjects';
import { Constants, ApiRoutes, ClientRoutes } from '../../constants';
import { FormikProps, FormikErrors, Field, withFormik } from 'formik';
import { LoadingForm } from '../../lib/components/loadingForm';
import { ErrorForm } from '../../lib/components/errorForm';
import EventViewModel from './eventViewModel';
import EventMapper from './eventMapper';

interface Props {
  model?: EventViewModel;
}

const EventEditDisplay = (props: FormikProps<EventViewModel>) => {
  let status = props.status as UpdateResponse<Api.EventClientRequestModel>;

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
          Actual End Date
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
          Actual Start Date
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
          Bill Amount
        </label>
        <div className="col-sm-12">
          <Field
            type="number"
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
          Status
        </label>
        <div className="col-sm-12">
          <Field
            type="number"
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
          Scheduled End Date
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
          Scheduled Start Date
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
          Student Notes
        </label>
        <div className="col-sm-12">
          <Field
            type="textbox"
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
          Teacher notes
        </label>
        <div className="col-sm-12">
          <Field
            type="textbox"
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

const EventEdit = withFormik<Props, EventViewModel>({
  mapPropsToValues: props => {
    let response = new EventViewModel();
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
    return response;
  },

  // Custom sync validation
  validate: values => {
    let errors: FormikErrors<EventViewModel> = {};

    if (values.eventStatusId == 0) {
      errors.eventStatusId = 'Required';
    }
    if (values.id == 0) {
      errors.id = 'Required';
    }

    return errors;
  },
  handleSubmit: (values, actions) => {
    actions.setStatus(undefined);

    let mapper = new EventMapper();

    axios
      .put(
        Constants.ApiEndpoint + ApiRoutes.Events + '/' + values.id,

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
            Api.EventClientRequestModel
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

  displayName: 'EventEdit',
})(EventEditDisplay);

interface IParams {
  id: number;
}

interface IMatch {
  params: IParams;
}

interface EventEditComponentProps {
  match: IMatch;
}

interface EventEditComponentState {
  model?: EventViewModel;
  loading: boolean;
  loaded: boolean;
  errorOccurred: boolean;
  errorMessage: string;
}

export default class EventEditComponent extends React.Component<
  EventEditComponentProps,
  EventEditComponentState
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
          ApiRoutes.Events +
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
          let response = resp.data as Api.EventClientResponseModel;

          console.log(response);

          let mapper = new EventMapper();

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
      return <EventEdit model={this.state.model} />;
    } else {
      return null;
    }
  }
}


/*<Codenesium>
    <Hash>5b7d937085fb0dd214a733c923346284</Hash>
</Codenesium>*/