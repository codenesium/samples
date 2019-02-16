import React, { Component } from 'react';
import axios from 'axios';
import { CreateResponse } from '../api/ApiObjects';
import { FormikProps, FormikErrors, Field, withFormik } from 'formik';
import * as Yup from 'yup';
import * as Api from '../api/models';
import Constants from '../constants';
import TeacherSkillMapper from '../mapping/teacherSkillMapper';
import TeacherSkillViewModel from '../viewmodels/teacherSkillViewModel';

interface Props {
  model?: TeacherSkillViewModel;
}

const TeacherSkillCreateDisplay: React.SFC<
  FormikProps<TeacherSkillViewModel>
> = (props: FormikProps<TeacherSkillViewModel>) => {
  let status = props.status as CreateResponse<
    Api.TeacherSkillClientRequestModel
  >;

  let errorsForField = (name: string): string => {
    let response = '';
    if (
      props.touched[name as keyof TeacherSkillViewModel] &&
      props.errors[name as keyof TeacherSkillViewModel]
    ) {
      response += props.errors[name as keyof TeacherSkillViewModel];
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

const TeacherSkillCreateComponent = withFormik<Props, TeacherSkillViewModel>({
  mapPropsToValues: props => {
    let response = new TeacherSkillViewModel();
    if (props.model != undefined) {
      response.setProperties(
        props.model!.id,
        props.model!.isDeleted,
        props.model!.name,
        props.model!.tenantId
      );
    }
    return response;
  },

  validate: values => {
    let errors: FormikErrors<TeacherSkillViewModel> = {};

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
    let mapper = new TeacherSkillMapper();

    axios
      .post(
        Constants.ApiUrl + 'teacherskills',
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
            Api.TeacherSkillClientRequestModel
          >;
          actions.setStatus(response);
          console.log(response);
        },
        error => {
          let response = error.response.data as CreateResponse<
            Api.TeacherSkillClientRequestModel
          >;
          actions.setStatus(response);
          console.log(response);
        }
      );
  },
  displayName: 'TeacherSkillCreate',
})(TeacherSkillCreateDisplay);

export default TeacherSkillCreateComponent;


/*<Codenesium>
    <Hash>2574675f1f967e09117e3a40de13cca6</Hash>
</Codenesium>*/