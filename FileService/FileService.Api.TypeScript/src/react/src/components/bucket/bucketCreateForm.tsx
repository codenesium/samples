import React, { Component } from 'react';
import axios from 'axios';
import { CreateResponse } from '../../api/ApiObjects';
import { FormikProps, FormikErrors, Field, withFormik } from 'formik';
import * as Yup from 'yup';
import { LoadingForm } from '../../lib/components/loadingForm';
import { ErrorForm } from '../../lib/components/errorForm';
import * as Api from '../../api/models';
import { Constants, ApiRoutes, ClientRoutes } from '../../constants';
import BucketMapper from './bucketMapper';
import BucketViewModel from './bucketViewModel';

interface Props {
  model?: BucketViewModel;
}

const BucketCreateDisplay: React.SFC<FormikProps<BucketViewModel>> = (
  props: FormikProps<BucketViewModel>
) => {
  let status = props.status as CreateResponse<Api.BucketClientRequestModel>;

  let errorsForField = (name: string): string => {
    let response = '';
    if (
      props.touched[name as keyof BucketViewModel] &&
      props.errors[name as keyof BucketViewModel]
    ) {
      response += props.errors[name as keyof BucketViewModel];
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
            errorExistForField('externalId')
              ? 'col-sm-2 col-form-label is-invalid'
              : 'col-sm-2 col-form-label'
          }
        >
          ExternalId
        </label>
        <div className="col-sm-12">
          <Field
            type="textbox"
            name="externalId"
            className={
              errorExistForField('externalId')
                ? 'form-control is-invalid'
                : 'form-control'
            }
          />
          {errorExistForField('externalId') && (
            <small className="text-danger">
              {errorsForField('externalId')}
            </small>
          )}
        </div>
      </div>

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
            type="textbox"
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

const BucketCreate = withFormik<Props, BucketViewModel>({
  mapPropsToValues: props => {
    let response = new BucketViewModel();
    if (props.model != undefined) {
      response.setProperties(
        props.model!.externalId,
        props.model!.id,
        props.model!.name
      );
    }
    return response;
  },

  validate: values => {
    let errors: FormikErrors<BucketViewModel> = {};

    if (values.externalId == undefined) {
      errors.externalId = 'Required';
    }
    if (values.name == '') {
      errors.name = 'Required';
    }

    return errors;
  },

  handleSubmit: (values, actions) => {
    actions.setStatus(undefined);
    let mapper = new BucketMapper();

    axios
      .post(
        Constants.ApiEndpoint + ApiRoutes.Buckets,
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
            Api.BucketClientRequestModel
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
  displayName: 'BucketCreate',
})(BucketCreateDisplay);

interface BucketCreateComponentProps {}

interface BucketCreateComponentState {
  model?: BucketViewModel;
  loading: boolean;
  loaded: boolean;
  errorOccurred: boolean;
  errorMessage: string;
}

export default class BucketCreateComponent extends React.Component<
  BucketCreateComponentProps,
  BucketCreateComponentState
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
      return <BucketCreate model={this.state.model} />;
    } else {
      return null;
    }
  }
}


/*<Codenesium>
    <Hash>28ad61f6efeb9085d8d2c0bfe6f93e11</Hash>
</Codenesium>*/