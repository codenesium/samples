import React, { Component } from 'react';
import axios from 'axios';
import { CreateResponse } from '../../api/ApiObjects';
import { FormikProps, FormikErrors, Field, withFormik } from 'formik';
import * as Yup from 'yup';
import { LoadingForm } from '../../lib/components/loadingForm';
import { ErrorForm } from '../../lib/components/errorForm';
import * as Api from '../../api/models';
import { Constants, ApiRoutes, ClientRoutes } from '../../constants';
import PipelineStepDestinationMapper from './pipelineStepDestinationMapper';
import PipelineStepDestinationViewModel from './pipelineStepDestinationViewModel';

interface Props {
  model?: PipelineStepDestinationViewModel;
}

const PipelineStepDestinationCreateDisplay: React.SFC<
  FormikProps<PipelineStepDestinationViewModel>
> = (props: FormikProps<PipelineStepDestinationViewModel>) => {
  let status = props.status as CreateResponse<
    Api.PipelineStepDestinationClientRequestModel
  >;

  let errorsForField = (name: string): string => {
    let response = '';
    if (
      props.touched[name as keyof PipelineStepDestinationViewModel] &&
      props.errors[name as keyof PipelineStepDestinationViewModel]
    ) {
      response += props.errors[name as keyof PipelineStepDestinationViewModel];
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
            errorExistForField('destinationId')
              ? 'col-sm-2 col-form-label is-invalid'
              : 'col-sm-2 col-form-label'
          }
        >
          DestinationId
        </label>
        <div className="col-sm-12">
          <Field
            type="datetime-local"
            name="destinationId"
            className={
              errorExistForField('destinationId')
                ? 'form-control is-invalid'
                : 'form-control'
            }
          />
          {errorExistForField('destinationId') && (
            <small className="text-danger">
              {errorsForField('destinationId')}
            </small>
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

const PipelineStepDestinationCreate = withFormik<
  Props,
  PipelineStepDestinationViewModel
>({
  mapPropsToValues: props => {
    let response = new PipelineStepDestinationViewModel();
    if (props.model != undefined) {
      response.setProperties(
        props.model!.destinationId,
        props.model!.id,
        props.model!.pipelineStepId
      );
    }
    return response;
  },

  validate: values => {
    let errors: FormikErrors<PipelineStepDestinationViewModel> = {};

    if (values.destinationId == 0) {
      errors.destinationId = 'Required';
    }
    if (values.pipelineStepId == 0) {
      errors.pipelineStepId = 'Required';
    }

    return errors;
  },

  handleSubmit: (values, actions) => {
    actions.setStatus(undefined);
    let mapper = new PipelineStepDestinationMapper();

    axios
      .post(
        Constants.ApiEndpoint + ApiRoutes.PipelineStepDestinations,
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
            Api.PipelineStepDestinationClientRequestModel
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
  displayName: 'PipelineStepDestinationCreate',
})(PipelineStepDestinationCreateDisplay);

interface PipelineStepDestinationCreateComponentProps {}

interface PipelineStepDestinationCreateComponentState {
  model?: PipelineStepDestinationViewModel;
  loading: boolean;
  loaded: boolean;
  errorOccurred: boolean;
  errorMessage: string;
}

export default class PipelineStepDestinationCreateComponent extends React.Component<
  PipelineStepDestinationCreateComponentProps,
  PipelineStepDestinationCreateComponentState
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
      return <PipelineStepDestinationCreate model={this.state.model} />;
    } else {
      return null;
    }
  }
}


/*<Codenesium>
    <Hash>e13aa770b92a5c20c046381869a89e8e</Hash>
</Codenesium>*/