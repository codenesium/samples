import React, { Component } from 'react';
import axios from 'axios';
import { CreateResponse } from '../../api/ApiObjects';
import { FormikProps, FormikErrors, Field, withFormik } from 'formik';
import * as Yup from 'yup';
import { LoadingForm } from '../../lib/components/loadingForm';
import { ErrorForm } from '../../lib/components/errorForm';
import * as Api from '../../api/models';
import { Constants, ApiRoutes, ClientRoutes } from '../../constants';
import HandlerPipelineStepMapper from './handlerPipelineStepMapper';
import HandlerPipelineStepViewModel from './handlerPipelineStepViewModel';

interface Props {
  model?: HandlerPipelineStepViewModel;
}

const HandlerPipelineStepCreateDisplay: React.SFC<
  FormikProps<HandlerPipelineStepViewModel>
> = (props: FormikProps<HandlerPipelineStepViewModel>) => {
  let status = props.status as CreateResponse<
    Api.HandlerPipelineStepClientRequestModel
  >;

  let errorsForField = (name: string): string => {
    let response = '';
    if (
      props.touched[name as keyof HandlerPipelineStepViewModel] &&
      props.errors[name as keyof HandlerPipelineStepViewModel]
    ) {
      response += props.errors[name as keyof HandlerPipelineStepViewModel];
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

const HandlerPipelineStepCreate = withFormik<
  Props,
  HandlerPipelineStepViewModel
>({
  mapPropsToValues: props => {
    let response = new HandlerPipelineStepViewModel();
    if (props.model != undefined) {
      response.setProperties(
        props.model!.handlerId,
        props.model!.id,
        props.model!.pipelineStepId
      );
    }
    return response;
  },

  validate: values => {
    let errors: FormikErrors<HandlerPipelineStepViewModel> = {};

    if (values.handlerId == 0) {
      errors.handlerId = 'Required';
    }
    if (values.pipelineStepId == 0) {
      errors.pipelineStepId = 'Required';
    }

    return errors;
  },

  handleSubmit: (values, actions) => {
    actions.setStatus(undefined);
    let mapper = new HandlerPipelineStepMapper();

    axios
      .post(
        Constants.ApiEndpoint + ApiRoutes.HandlerPipelineSteps,
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
            Api.HandlerPipelineStepClientRequestModel
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
  displayName: 'HandlerPipelineStepCreate',
})(HandlerPipelineStepCreateDisplay);

interface HandlerPipelineStepCreateComponentProps {}

interface HandlerPipelineStepCreateComponentState {
  model?: HandlerPipelineStepViewModel;
  loading: boolean;
  loaded: boolean;
  errorOccurred: boolean;
  errorMessage: string;
}

export default class HandlerPipelineStepCreateComponent extends React.Component<
  HandlerPipelineStepCreateComponentProps,
  HandlerPipelineStepCreateComponentState
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
      return <HandlerPipelineStepCreate model={this.state.model} />;
    } else {
      return null;
    }
  }
}


/*<Codenesium>
    <Hash>77c60b5b4e5b9179e6d35c0c32e09488</Hash>
</Codenesium>*/