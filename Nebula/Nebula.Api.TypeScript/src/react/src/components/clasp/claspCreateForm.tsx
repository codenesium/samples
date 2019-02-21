import React, { Component } from 'react';
import axios from 'axios';
import { CreateResponse } from '../../api/apiObjects';
import { FormikProps, FormikErrors, Field, withFormik } from 'formik';
import * as Yup from 'yup';
import { LoadingForm } from '../../lib/components/loadingForm';
import { ErrorForm } from '../../lib/components/errorForm';
import * as Api from '../../api/models';
import { Constants, ApiRoutes, ClientRoutes } from '../../constants';
import ClaspMapper from './claspMapper';
import ClaspViewModel from './claspViewModel';

interface Props {
  model?: ClaspViewModel;
}

const ClaspCreateDisplay: React.SFC<FormikProps<ClaspViewModel>> = (
  props: FormikProps<ClaspViewModel>
) => {
  let status = props.status as CreateResponse<Api.ClaspClientRequestModel>;

  let errorsForField = (name: string): string => {
    let response = '';
    if (
      props.touched[name as keyof ClaspViewModel] &&
      props.errors[name as keyof ClaspViewModel]
    ) {
      response += props.errors[name as keyof ClaspViewModel];
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
            errorExistForField('nextChainId')
              ? 'col-sm-2 col-form-label is-invalid'
              : 'col-sm-2 col-form-label'
          }
        >
          NextChainId
        </label>
        <div className="col-sm-12">
          <Field
            type="textbox"
            name="nextChainId"
            className={
              errorExistForField('nextChainId')
                ? 'form-control is-invalid'
                : 'form-control'
            }
          />
          {errorExistForField('nextChainId') && (
            <small className="text-danger">
              {errorsForField('nextChainId')}
            </small>
          )}
        </div>
      </div>

      <div className="form-group row">
        <label
          htmlFor="name"
          className={
            errorExistForField('previousChainId')
              ? 'col-sm-2 col-form-label is-invalid'
              : 'col-sm-2 col-form-label'
          }
        >
          PreviousChainId
        </label>
        <div className="col-sm-12">
          <Field
            type="textbox"
            name="previousChainId"
            className={
              errorExistForField('previousChainId')
                ? 'form-control is-invalid'
                : 'form-control'
            }
          />
          {errorExistForField('previousChainId') && (
            <small className="text-danger">
              {errorsForField('previousChainId')}
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

const ClaspCreate = withFormik<Props, ClaspViewModel>({
  mapPropsToValues: props => {
    let response = new ClaspViewModel();
    if (props.model != undefined) {
      response.setProperties(
        props.model!.id,
        props.model!.nextChainId,
        props.model!.previousChainId
      );
    }
    return response;
  },

  validate: values => {
    let errors: FormikErrors<ClaspViewModel> = {};

    if (values.nextChainId == 0) {
      errors.nextChainId = 'Required';
    }
    if (values.previousChainId == 0) {
      errors.previousChainId = 'Required';
    }

    return errors;
  },

  handleSubmit: (values, actions) => {
    actions.setStatus(undefined);
    let mapper = new ClaspMapper();

    axios
      .post(
        Constants.ApiEndpoint + ApiRoutes.Clasps,
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
            Api.ClaspClientRequestModel
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
  displayName: 'ClaspCreate',
})(ClaspCreateDisplay);

interface ClaspCreateComponentProps {}

interface ClaspCreateComponentState {
  model?: ClaspViewModel;
  loading: boolean;
  loaded: boolean;
  errorOccurred: boolean;
  errorMessage: string;
}

export default class ClaspCreateComponent extends React.Component<
  ClaspCreateComponentProps,
  ClaspCreateComponentState
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
      return <ClaspCreate model={this.state.model} />;
    } else {
      return null;
    }
  }
}


/*<Codenesium>
    <Hash>3e8dabb3358daf96ba3d526378c8a0b1</Hash>
</Codenesium>*/