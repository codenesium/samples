import React, { Component } from 'react';
import axios from 'axios';
import { CreateResponse } from '../../api/ApiObjects';
import { FormikProps, FormikErrors, Field, withFormik } from 'formik';
import * as Yup from 'yup';
import { LoadingForm } from '../../lib/components/loadingForm';
import { ErrorForm } from '../../lib/components/errorForm';
import * as Api from '../../api/models';
import { Constants, ApiRoutes, ClientRoutes } from '../../constants';
import PipelineStepNoteMapper from './pipelineStepNoteMapper';
import PipelineStepNoteViewModel from './pipelineStepNoteViewModel';

interface Props {
  model?: PipelineStepNoteViewModel;
}

const PipelineStepNoteCreateDisplay: React.SFC<
  FormikProps<PipelineStepNoteViewModel>
> = (props: FormikProps<PipelineStepNoteViewModel>) => {
  let status = props.status as CreateResponse<
    Api.PipelineStepNoteClientRequestModel
  >;

  let errorsForField = (name: string): string => {
    let response = '';
    if (
      props.touched[name as keyof PipelineStepNoteViewModel] &&
      props.errors[name as keyof PipelineStepNoteViewModel]
    ) {
      response += props.errors[name as keyof PipelineStepNoteViewModel];
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
            errorExistForField('employeeId')
              ? 'col-sm-2 col-form-label is-invalid'
              : 'col-sm-2 col-form-label'
          }
        >
          EmployeeId
        </label>
        <div className="col-sm-12">
          <Field
            type="datetime-local"
            name="employeeId"
            className={
              errorExistForField('employeeId')
                ? 'form-control is-invalid'
                : 'form-control'
            }
          />
          {errorExistForField('employeeId') && (
            <small className="text-danger">
              {errorsForField('employeeId')}
            </small>
          )}
        </div>
      </div>

      <div className="form-group row">
        <label
          htmlFor="name"
          className={
            errorExistForField('note')
              ? 'col-sm-2 col-form-label is-invalid'
              : 'col-sm-2 col-form-label'
          }
        >
          Note
        </label>
        <div className="col-sm-12">
          <Field
            type="datetime-local"
            name="note"
            className={
              errorExistForField('note')
                ? 'form-control is-invalid'
                : 'form-control'
            }
          />
          {errorExistForField('note') && (
            <small className="text-danger">{errorsForField('note')}</small>
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

const PipelineStepNoteCreate = withFormik<Props, PipelineStepNoteViewModel>({
  mapPropsToValues: props => {
    let response = new PipelineStepNoteViewModel();
    if (props.model != undefined) {
      response.setProperties(
        props.model!.employeeId,
        props.model!.id,
        props.model!.note,
        props.model!.pipelineStepId
      );
    }
    return response;
  },

  validate: values => {
    let errors: FormikErrors<PipelineStepNoteViewModel> = {};

    if (values.employeeId == 0) {
      errors.employeeId = 'Required';
    }
    if (values.note == '') {
      errors.note = 'Required';
    }
    if (values.pipelineStepId == 0) {
      errors.pipelineStepId = 'Required';
    }

    return errors;
  },

  handleSubmit: (values, actions) => {
    actions.setStatus(undefined);
    let mapper = new PipelineStepNoteMapper();

    axios
      .post(
        Constants.ApiEndpoint + ApiRoutes.PipelineStepNotes,
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
            Api.PipelineStepNoteClientRequestModel
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
  displayName: 'PipelineStepNoteCreate',
})(PipelineStepNoteCreateDisplay);

interface PipelineStepNoteCreateComponentProps {}

interface PipelineStepNoteCreateComponentState {
  model?: PipelineStepNoteViewModel;
  loading: boolean;
  loaded: boolean;
  errorOccurred: boolean;
  errorMessage: string;
}

export default class PipelineStepNoteCreateComponent extends React.Component<
  PipelineStepNoteCreateComponentProps,
  PipelineStepNoteCreateComponentState
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
      return <PipelineStepNoteCreate model={this.state.model} />;
    } else {
      return null;
    }
  }
}


/*<Codenesium>
    <Hash>ae46fcc42e6658df7cb8194a5accfdb3</Hash>
</Codenesium>*/