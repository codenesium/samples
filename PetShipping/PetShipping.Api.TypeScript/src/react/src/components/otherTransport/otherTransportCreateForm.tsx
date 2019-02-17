import React, { Component } from 'react';
import axios from 'axios';
import { CreateResponse } from '../../api/apiObjects';
import { FormikProps, FormikErrors, Field, withFormik } from 'formik';
import * as Yup from 'yup';
import { LoadingForm } from '../../lib/components/loadingForm';
import { ErrorForm } from '../../lib/components/errorForm';
import * as Api from '../../api/models';
import { Constants, ApiRoutes, ClientRoutes } from '../../constants';
import OtherTransportMapper from './otherTransportMapper';
import OtherTransportViewModel from './otherTransportViewModel';

interface Props {
  model?: OtherTransportViewModel;
}

const OtherTransportCreateDisplay: React.SFC<
  FormikProps<OtherTransportViewModel>
> = (props: FormikProps<OtherTransportViewModel>) => {
  let status = props.status as CreateResponse<
    Api.OtherTransportClientRequestModel
  >;

  let errorsForField = (name: string): string => {
    let response = '';
    if (
      props.touched[name as keyof OtherTransportViewModel] &&
      props.errors[name as keyof OtherTransportViewModel]
    ) {
      response += props.errors[name as keyof OtherTransportViewModel];
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

const OtherTransportCreate = withFormik<Props, OtherTransportViewModel>({
  mapPropsToValues: props => {
    let response = new OtherTransportViewModel();
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
    let errors: FormikErrors<OtherTransportViewModel> = {};

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
    let mapper = new OtherTransportMapper();

    axios
      .post(
        Constants.ApiEndpoint + ApiRoutes.OtherTransports,
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
            Api.OtherTransportClientRequestModel
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
  displayName: 'OtherTransportCreate',
})(OtherTransportCreateDisplay);

interface OtherTransportCreateComponentProps {}

interface OtherTransportCreateComponentState {
  model?: OtherTransportViewModel;
  loading: boolean;
  loaded: boolean;
  errorOccurred: boolean;
  errorMessage: string;
}

export default class OtherTransportCreateComponent extends React.Component<
  OtherTransportCreateComponentProps,
  OtherTransportCreateComponentState
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
      return <OtherTransportCreate model={this.state.model} />;
    } else {
      return null;
    }
  }
}


/*<Codenesium>
    <Hash>bfdd65da38368f73db8bd540c44dcc12</Hash>
</Codenesium>*/