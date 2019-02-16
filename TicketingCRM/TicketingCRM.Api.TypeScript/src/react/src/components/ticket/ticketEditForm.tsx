import React, { Component } from 'react';
import axios from 'axios';
import * as Api from '../../api/models';
import { UpdateResponse } from '../../api/ApiObjects';
import { Constants, ApiRoutes, ClientRoutes } from '../../constants';
import { FormikProps, FormikErrors, Field, withFormik } from 'formik';
import { LoadingForm } from '../../lib/components/loadingForm';
import { ErrorForm } from '../../lib/components/errorForm';
import TicketViewModel from './ticketViewModel';
import TicketMapper from './ticketMapper';

interface Props {
  model?: TicketViewModel;
}

const TicketEditDisplay = (props: FormikProps<TicketViewModel>) => {
  let status = props.status as UpdateResponse<Api.TicketClientRequestModel>;

  let errorsForField = (name: string): string => {
    let response = '';
    if (
      props.touched[name as keyof TicketViewModel] &&
      props.errors[name as keyof TicketViewModel]
    ) {
      response += props.errors[name as keyof TicketViewModel];
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
            errorExistForField('publicId')
              ? 'col-sm-2 col-form-label is-invalid'
              : 'col-sm-2 col-form-label'
          }
        >
          PublicId
        </label>
        <div className="col-sm-12">
          <Field
            type="datetime-local"
            name="publicId"
            className={
              errorExistForField('publicId')
                ? 'form-control is-invalid'
                : 'form-control'
            }
          />
          {errorExistForField('publicId') && (
            <small className="text-danger">{errorsForField('publicId')}</small>
          )}
        </div>
      </div>
      <div className="form-group row">
        <label
          htmlFor="name"
          className={
            errorExistForField('ticketStatusId')
              ? 'col-sm-2 col-form-label is-invalid'
              : 'col-sm-2 col-form-label'
          }
        >
          TicketStatusId
        </label>
        <div className="col-sm-12">
          <Field
            type="datetime-local"
            name="ticketStatusId"
            className={
              errorExistForField('ticketStatusId')
                ? 'form-control is-invalid'
                : 'form-control'
            }
          />
          {errorExistForField('ticketStatusId') && (
            <small className="text-danger">
              {errorsForField('ticketStatusId')}
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

const TicketEdit = withFormik<Props, TicketViewModel>({
  mapPropsToValues: props => {
    let response = new TicketViewModel();
    response.setProperties(
      props.model!.id,
      props.model!.publicId,
      props.model!.ticketStatusId
    );
    return response;
  },

  // Custom sync validation
  validate: values => {
    let errors: FormikErrors<TicketViewModel> = {};

    if (values.id == 0) {
      errors.id = 'Required';
    }
    if (values.publicId == '') {
      errors.publicId = 'Required';
    }
    if (values.ticketStatusId == 0) {
      errors.ticketStatusId = 'Required';
    }

    return errors;
  },
  handleSubmit: (values, actions) => {
    actions.setStatus(undefined);

    let mapper = new TicketMapper();

    axios
      .put(
        Constants.ApiEndpoint + ApiRoutes.Tickets + '/' + values.id,

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
            Api.TicketClientRequestModel
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

  displayName: 'TicketEdit',
})(TicketEditDisplay);

interface IParams {
  id: number;
}

interface IMatch {
  params: IParams;
}

interface TicketEditComponentProps {
  match: IMatch;
}

interface TicketEditComponentState {
  model?: TicketViewModel;
  loading: boolean;
  loaded: boolean;
  errorOccurred: boolean;
  errorMessage: string;
}

export default class TicketEditComponent extends React.Component<
  TicketEditComponentProps,
  TicketEditComponentState
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
          ApiRoutes.Tickets +
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
          let response = resp.data as Api.TicketClientResponseModel;

          console.log(response);

          let mapper = new TicketMapper();

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
      return <TicketEdit model={this.state.model} />;
    } else {
      return null;
    }
  }
}


/*<Codenesium>
    <Hash>b9ccfa0088232537ed219d580c788b90</Hash>
</Codenesium>*/