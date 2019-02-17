import React, { Component } from 'react';
import axios from 'axios';
import { CreateResponse } from '../../api/apiObjects';
import { FormikProps, FormikErrors, Field, withFormik } from 'formik';
import * as Yup from 'yup';
import { LoadingForm } from '../../lib/components/loadingForm';
import { ErrorForm } from '../../lib/components/errorForm';
import * as Api from '../../api/models';
import { Constants, ApiRoutes, ClientRoutes } from '../../constants';
import SelfReferenceMapper from './selfReferenceMapper';
import SelfReferenceViewModel from './selfReferenceViewModel';

interface Props {
  model?: SelfReferenceViewModel;
}

const SelfReferenceCreateDisplay: React.SFC<
  FormikProps<SelfReferenceViewModel>
> = (props: FormikProps<SelfReferenceViewModel>) => {
  let status = props.status as CreateResponse<
    Api.SelfReferenceClientRequestModel
  >;

  let errorsForField = (name: string): string => {
    let response = '';
    if (
      props.touched[name as keyof SelfReferenceViewModel] &&
      props.errors[name as keyof SelfReferenceViewModel]
    ) {
      response += props.errors[name as keyof SelfReferenceViewModel];
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
            errorExistForField('selfReferenceId')
              ? 'col-sm-2 col-form-label is-invalid'
              : 'col-sm-2 col-form-label'
          }
        >
          SelfReferenceId
        </label>
        <div className="col-sm-12">
          <Field
            type="textbox"
            name="selfReferenceId"
            className={
              errorExistForField('selfReferenceId')
                ? 'form-control is-invalid'
                : 'form-control'
            }
          />
          {errorExistForField('selfReferenceId') && (
            <small className="text-danger">
              {errorsForField('selfReferenceId')}
            </small>
          )}
        </div>
      </div>

      <div className="form-group row">
        <label
          htmlFor="name"
          className={
            errorExistForField('selfReferenceId2')
              ? 'col-sm-2 col-form-label is-invalid'
              : 'col-sm-2 col-form-label'
          }
        >
          SelfReferenceId2
        </label>
        <div className="col-sm-12">
          <Field
            type="textbox"
            name="selfReferenceId2"
            className={
              errorExistForField('selfReferenceId2')
                ? 'form-control is-invalid'
                : 'form-control'
            }
          />
          {errorExistForField('selfReferenceId2') && (
            <small className="text-danger">
              {errorsForField('selfReferenceId2')}
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

const SelfReferenceCreate = withFormik<Props, SelfReferenceViewModel>({
  mapPropsToValues: props => {
    let response = new SelfReferenceViewModel();
    if (props.model != undefined) {
      response.setProperties(
        props.model!.id,
        props.model!.selfReferenceId,
        props.model!.selfReferenceId2
      );
    }
    return response;
  },

  validate: values => {
    let errors: FormikErrors<SelfReferenceViewModel> = {};

    return errors;
  },

  handleSubmit: (values, actions) => {
    actions.setStatus(undefined);
    let mapper = new SelfReferenceMapper();

    axios
      .post(
        Constants.ApiEndpoint + ApiRoutes.SelfReferences,
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
            Api.SelfReferenceClientRequestModel
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
  displayName: 'SelfReferenceCreate',
})(SelfReferenceCreateDisplay);

interface SelfReferenceCreateComponentProps {}

interface SelfReferenceCreateComponentState {
  model?: SelfReferenceViewModel;
  loading: boolean;
  loaded: boolean;
  errorOccurred: boolean;
  errorMessage: string;
}

export default class SelfReferenceCreateComponent extends React.Component<
  SelfReferenceCreateComponentProps,
  SelfReferenceCreateComponentState
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
      return <SelfReferenceCreate model={this.state.model} />;
    } else {
      return null;
    }
  }
}


/*<Codenesium>
    <Hash>4960971d64f456cfc15072d1120cff91</Hash>
</Codenesium>*/