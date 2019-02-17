import React, { Component } from 'react';
import axios from 'axios';
import { CreateResponse } from '../../api/apiObjects';
import { FormikProps, FormikErrors, Field, withFormik } from 'formik';
import * as Yup from 'yup';
import { LoadingForm } from '../../lib/components/loadingForm';
import { ErrorForm } from '../../lib/components/errorForm';
import * as Api from '../../api/models';
import { Constants, ApiRoutes, ClientRoutes } from '../../constants';
import TicketStatusMapper from './ticketStatusMapper';
import TicketStatusViewModel from './ticketStatusViewModel';

interface Props {
  model?: TicketStatusViewModel;
}

const TicketStatusCreateDisplay: React.SFC<
  FormikProps<TicketStatusViewModel>
> = (props: FormikProps<TicketStatusViewModel>) => {
  let status = props.status as CreateResponse<
    Api.TicketStatusClientRequestModel
  >;

  let errorsForField = (name: string): string => {
    let response = '';
    if (
      props.touched[name as keyof TicketStatusViewModel] &&
      props.errors[name as keyof TicketStatusViewModel]
    ) {
      response += props.errors[name as keyof TicketStatusViewModel];
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

const TicketStatusCreate = withFormik<Props, TicketStatusViewModel>({
  mapPropsToValues: props => {
    let response = new TicketStatusViewModel();
    if (props.model != undefined) {
      response.setProperties(props.model!.id, props.model!.name);
    }
    return response;
  },

  validate: values => {
    let errors: FormikErrors<TicketStatusViewModel> = {};

    if (values.name == '') {
      errors.name = 'Required';
    }

    return errors;
  },

  handleSubmit: (values, actions) => {
    actions.setStatus(undefined);
    let mapper = new TicketStatusMapper();

    axios
      .post(
        Constants.ApiEndpoint + ApiRoutes.TicketStatus,
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
            Api.TicketStatusClientRequestModel
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
  displayName: 'TicketStatusCreate',
})(TicketStatusCreateDisplay);

interface TicketStatusCreateComponentProps {}

interface TicketStatusCreateComponentState {
  model?: TicketStatusViewModel;
  loading: boolean;
  loaded: boolean;
  errorOccurred: boolean;
  errorMessage: string;
}

export default class TicketStatusCreateComponent extends React.Component<
  TicketStatusCreateComponentProps,
  TicketStatusCreateComponentState
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
      return <TicketStatusCreate model={this.state.model} />;
    } else {
      return null;
    }
  }
}


/*<Codenesium>
    <Hash>6069c2371ee0d975e6cd3b15da5eabd6</Hash>
</Codenesium>*/