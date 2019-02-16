import React, { Component } from 'react';
import axios from 'axios';
import { CreateResponse } from '../api/ApiObjects';
import { FormikProps, FormikErrors, Field, withFormik } from 'formik';
import * as Yup from 'yup';
import * as Api from '../api/models';
import Constants from '../constants';
import SpaceMapper from '../mapping/spaceMapper';
import SpaceViewModel from '../viewmodels/spaceViewModel';

interface Props {
  model?: SpaceViewModel;
}

const SpaceCreateDisplay: React.SFC<FormikProps<SpaceViewModel>> = (
  props: FormikProps<SpaceViewModel>
) => {
  let status = props.status as CreateResponse<Api.SpaceClientRequestModel>;

  let errorsForField = (name: string): string => {
    let response = '';
    if (
      props.touched[name as keyof SpaceViewModel] &&
      props.errors[name as keyof SpaceViewModel]
    ) {
      response += props.errors[name as keyof SpaceViewModel];
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
            errorExistForField('description')
              ? 'col-sm-2 col-form-label is-invalid'
              : 'col-sm-2 col-form-label'
          }
        >
          Description
        </label>
        <div className="col-sm-12">
          <Field
            type="input"
            name="description"
            className={
              errorExistForField('description')
                ? 'form-control is-invalid'
                : 'form-control'
            }
          />

          {errorExistForField('description') && (
            <small className="text-danger">
              {errorsForField('description')}
            </small>
          )}
        </div>
      </div>

      <div className="form-group row">
        <label
          htmlFor="name"
          className={
            errorExistForField('isDeleted')
              ? 'col-sm-2 col-form-label is-invalid'
              : 'col-sm-2 col-form-label'
          }
        >
          IsDeleted
        </label>
        <div className="col-sm-12">
          <Field
            type="input"
            name="isDeleted"
            className={
              errorExistForField('isDeleted')
                ? 'form-control is-invalid'
                : 'form-control'
            }
          />

          {errorExistForField('isDeleted') && (
            <small className="text-danger">{errorsForField('isDeleted')}</small>
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
            type="input"
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
            errorExistForField('tenantId')
              ? 'col-sm-2 col-form-label is-invalid'
              : 'col-sm-2 col-form-label'
          }
        >
          TenantId
        </label>
        <div className="col-sm-12">
          <Field
            type="input"
            name="tenantId"
            className={
              errorExistForField('tenantId')
                ? 'form-control is-invalid'
                : 'form-control'
            }
          />

          {errorExistForField('tenantId') && (
            <small className="text-danger">{errorsForField('tenantId')}</small>
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

const SpaceCreateComponent = withFormik<Props, SpaceViewModel>({
  mapPropsToValues: props => {
    let response = new SpaceViewModel();
    if (props.model != undefined) {
      response.setProperties(
        props.model!.description,
        props.model!.id,
        props.model!.isDeleted,
        props.model!.name,
        props.model!.tenantId
      );
    }
    return response;
  },

  validate: values => {
    let errors: FormikErrors<SpaceViewModel> = {};

    if (values.description == '') {
      errors.description = 'Required';
    }
    if (values.isDeleted == false) {
      errors.isDeleted = 'Required';
    }
    if (values.name == '') {
      errors.name = 'Required';
    }
    if (values.tenantId == 0) {
      errors.tenantId = 'Required';
    }

    return errors;
  },

  handleSubmit: (values, actions) => {
    actions.setStatus(undefined);
    let mapper = new SpaceMapper();

    axios
      .post(
        Constants.ApiUrl + 'spaces',
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
            Api.SpaceClientRequestModel
          >;
          actions.setStatus(response);
          console.log(response);
        },
        error => {
          let response = error.response.data as CreateResponse<
            Api.SpaceClientRequestModel
          >;
          actions.setStatus(response);
          console.log(response);
        }
      );
  },
  displayName: 'SpaceCreate',
})(SpaceCreateDisplay);

export default SpaceCreateComponent;


/*<Codenesium>
    <Hash>b2d5000ef92e79ee45c5f826b1dbc104</Hash>
</Codenesium>*/