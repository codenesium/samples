import React, { Component } from 'react';
import axios from 'axios';
import { CreateResponse } from '../../api/apiObjects';
import { FormikProps, FormikErrors, Field, withFormik } from 'formik';
import * as Yup from 'yup';
import { LoadingForm } from '../../lib/components/loadingForm';
import { ErrorForm } from '../../lib/components/errorForm';
import * as Api from '../../api/models';
import { Constants, ApiRoutes, ClientRoutes } from '../../constants';
import PipelineStepMapper from './pipelineStepMapper';
import PipelineStepViewModel from './pipelineStepViewModel';

interface Props {
  model?: PipelineStepViewModel;
}

const PipelineStepCreateDisplay: React.SFC<
  FormikProps<PipelineStepViewModel>
> = (props: FormikProps<PipelineStepViewModel>) => {
  let status = props.status as CreateResponse<
    Api.PipelineStepClientRequestModel
  >;

  let errorsForField = (name: string): string => {
    let response = '';
    if (
      props.touched[name as keyof PipelineStepViewModel] &&
      props.errors[name as keyof PipelineStepViewModel]
    ) {
      response += props.errors[name as keyof PipelineStepViewModel];
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

      <div className="form-group row">
        <label
          htmlFor="name"
          className={
            errorExistForField('pipelineStepStatusId')
              ? 'col-sm-2 col-form-label is-invalid'
              : 'col-sm-2 col-form-label'
          }
        >
          PipelineStepStatusId
        </label>
        <div className="col-sm-12">
          <Field
            type="datetime-local"
            name="pipelineStepStatusId"
            className={
              errorExistForField('pipelineStepStatusId')
                ? 'form-control is-invalid'
                : 'form-control'
            }
          />
          {errorExistForField('pipelineStepStatusId') && (
            <small className="text-danger">
              {errorsForField('pipelineStepStatusId')}
            </small>
          )}
        </div>
      </div>

      <div className="form-group row">
        <label
          htmlFor="name"
          className={
            errorExistForField('shipperId')
              ? 'col-sm-2 col-form-label is-invalid'
              : 'col-sm-2 col-form-label'
          }
        >
          ShipperId
        </label>
        <div className="col-sm-12">
          <Field
            type="datetime-local"
            name="shipperId"
            className={
              errorExistForField('shipperId')
                ? 'form-control is-invalid'
                : 'form-control'
            }
          />
          {errorExistForField('shipperId') && (
            <small className="text-danger">{errorsForField('shipperId')}</small>
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

const PipelineStepCreate = withFormik<Props, PipelineStepViewModel>({
  mapPropsToValues: props => {
    let response = new PipelineStepViewModel();
    if (props.model != undefined) {
      response.setProperties(
        props.model!.id,
        props.model!.name,
        props.model!.pipelineStepStatusId,
        props.model!.shipperId
      );
    }
    return response;
  },

  validate: values => {
    let errors: FormikErrors<PipelineStepViewModel> = {};

    if (values.name == '') {
      errors.name = 'Required';
    }
    if (values.pipelineStepStatusId == 0) {
      errors.pipelineStepStatusId = 'Required';
    }
    if (values.shipperId == 0) {
      errors.shipperId = 'Required';
    }

    return errors;
  },

  handleSubmit: (values, actions) => {
    actions.setStatus(undefined);
    let mapper = new PipelineStepMapper();

    axios
      .post(
        Constants.ApiEndpoint + ApiRoutes.PipelineSteps,
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
            Api.PipelineStepClientRequestModel
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
  displayName: 'PipelineStepCreate',
})(PipelineStepCreateDisplay);

interface PipelineStepCreateComponentProps {}

interface PipelineStepCreateComponentState {
  model?: PipelineStepViewModel;
  loading: boolean;
  loaded: boolean;
  errorOccurred: boolean;
  errorMessage: string;
}

export default class PipelineStepCreateComponent extends React.Component<
  PipelineStepCreateComponentProps,
  PipelineStepCreateComponentState
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
      return <PipelineStepCreate model={this.state.model} />;
    } else {
      return null;
    }
  }
}


/*<Codenesium>
    <Hash>93086164193dcfb846d2a29b3d9e9db6</Hash>
</Codenesium>*/