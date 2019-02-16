import React, { Component } from 'react';
import axios from 'axios';
import { CreateResponse } from '../../api/ApiObjects';
import { FormikProps, FormikErrors, Field, withFormik } from 'formik';
import * as Yup from 'yup';
import { LoadingForm } from '../../lib/components/loadingForm';
import { ErrorForm } from '../../lib/components/errorForm';
import * as Api from '../../api/models';
import { Constants, ApiRoutes, ClientRoutes } from '../../constants';
import CountryRequirementMapper from './countryRequirementMapper';
import CountryRequirementViewModel from './countryRequirementViewModel';

interface Props {
  model?: CountryRequirementViewModel;
}

const CountryRequirementCreateDisplay: React.SFC<
  FormikProps<CountryRequirementViewModel>
> = (props: FormikProps<CountryRequirementViewModel>) => {
  let status = props.status as CreateResponse<
    Api.CountryRequirementClientRequestModel
  >;

  let errorsForField = (name: string): string => {
    let response = '';
    if (
      props.touched[name as keyof CountryRequirementViewModel] &&
      props.errors[name as keyof CountryRequirementViewModel]
    ) {
      response += props.errors[name as keyof CountryRequirementViewModel];
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
            errorExistForField('countryId')
              ? 'col-sm-2 col-form-label is-invalid'
              : 'col-sm-2 col-form-label'
          }
        >
          CountryId
        </label>
        <div className="col-sm-12">
          <Field
            type="datetime-local"
            name="countryId"
            className={
              errorExistForField('countryId')
                ? 'form-control is-invalid'
                : 'form-control'
            }
          />
          {errorExistForField('countryId') && (
            <small className="text-danger">{errorsForField('countryId')}</small>
          )}
        </div>
      </div>

      <div className="form-group row">
        <label
          htmlFor="name"
          className={
            errorExistForField('detail')
              ? 'col-sm-2 col-form-label is-invalid'
              : 'col-sm-2 col-form-label'
          }
        >
          Details
        </label>
        <div className="col-sm-12">
          <Field
            type="datetime-local"
            name="detail"
            className={
              errorExistForField('detail')
                ? 'form-control is-invalid'
                : 'form-control'
            }
          />
          {errorExistForField('detail') && (
            <small className="text-danger">{errorsForField('detail')}</small>
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

const CountryRequirementCreate = withFormik<Props, CountryRequirementViewModel>(
  {
    mapPropsToValues: props => {
      let response = new CountryRequirementViewModel();
      if (props.model != undefined) {
        response.setProperties(
          props.model!.countryId,
          props.model!.detail,
          props.model!.id
        );
      }
      return response;
    },

    validate: values => {
      let errors: FormikErrors<CountryRequirementViewModel> = {};

      if (values.countryId == 0) {
        errors.countryId = 'Required';
      }
      if (values.detail == '') {
        errors.detail = 'Required';
      }

      return errors;
    },

    handleSubmit: (values, actions) => {
      actions.setStatus(undefined);
      let mapper = new CountryRequirementMapper();

      axios
        .post(
          Constants.ApiEndpoint + ApiRoutes.CountryRequirements,
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
              Api.CountryRequirementClientRequestModel
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
    displayName: 'CountryRequirementCreate',
  }
)(CountryRequirementCreateDisplay);

interface CountryRequirementCreateComponentProps {}

interface CountryRequirementCreateComponentState {
  model?: CountryRequirementViewModel;
  loading: boolean;
  loaded: boolean;
  errorOccurred: boolean;
  errorMessage: string;
}

export default class CountryRequirementCreateComponent extends React.Component<
  CountryRequirementCreateComponentProps,
  CountryRequirementCreateComponentState
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
      return <CountryRequirementCreate model={this.state.model} />;
    } else {
      return null;
    }
  }
}


/*<Codenesium>
    <Hash>3453c7c0e0ce9f2c5556a93d3b7f8265</Hash>
</Codenesium>*/