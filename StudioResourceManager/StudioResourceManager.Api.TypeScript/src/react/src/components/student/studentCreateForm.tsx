import React, { Component } from 'react';
import axios from 'axios';
import { CreateResponse } from '../../api/ApiObjects';
import { FormikProps, FormikErrors, Field, withFormik } from 'formik';
import * as Yup from 'yup';
import { LoadingForm } from '../../lib/components/loadingForm';
import { ErrorForm } from '../../lib/components/errorForm';
import * as Api from '../../api/models';
import { Constants, ApiRoutes, ClientRoutes } from '../../constants';
import StudentMapper from './studentMapper';
import StudentViewModel from './studentViewModel';

interface Props {
  model?: StudentViewModel;
}

const StudentCreateDisplay: React.SFC<FormikProps<StudentViewModel>> = (
  props: FormikProps<StudentViewModel>
) => {
  let status = props.status as CreateResponse<Api.StudentClientRequestModel>;

  let errorsForField = (name: string): string => {
    let response = '';
    if (
      props.touched[name as keyof StudentViewModel] &&
      props.errors[name as keyof StudentViewModel]
    ) {
      response += props.errors[name as keyof StudentViewModel];
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
            errorExistForField('birthday')
              ? 'col-sm-2 col-form-label is-invalid'
              : 'col-sm-2 col-form-label'
          }
        >
          Birthday
        </label>
        <div className="col-sm-12">
          <Field
            type="datetime-local"
            name="birthday"
            className={
              errorExistForField('birthday')
                ? 'form-control is-invalid'
                : 'form-control'
            }
          />
          {errorExistForField('birthday') && (
            <small className="text-danger">{errorsForField('birthday')}</small>
          )}
        </div>
      </div>

      <div className="form-group row">
        <label
          htmlFor="name"
          className={
            errorExistForField('email')
              ? 'col-sm-2 col-form-label is-invalid'
              : 'col-sm-2 col-form-label'
          }
        >
          Email
        </label>
        <div className="col-sm-12">
          <Field
            type="email"
            name="email"
            className={
              errorExistForField('email')
                ? 'form-control is-invalid'
                : 'form-control'
            }
          />
          {errorExistForField('email') && (
            <small className="text-danger">{errorsForField('email')}</small>
          )}
        </div>
      </div>

      <div className="form-group row">
        <label
          htmlFor="name"
          className={
            errorExistForField('emailRemindersEnabled')
              ? 'col-sm-2 col-form-label is-invalid'
              : 'col-sm-2 col-form-label'
          }
        >
          Email Reminders Enabled
        </label>
        <div className="col-sm-12">
          <Field
            type="checkbox"
            checked={props.values.emailRemindersEnabled}
            name="emailRemindersEnabled"
            className={
              errorExistForField('emailRemindersEnabled')
                ? 'form-control is-invalid'
                : 'form-control'
            }
          />
          {errorExistForField('emailRemindersEnabled') && (
            <small className="text-danger">
              {errorsForField('emailRemindersEnabled')}
            </small>
          )}
        </div>
      </div>

      <div className="form-group row">
        <label
          htmlFor="name"
          className={
            errorExistForField('familyId')
              ? 'col-sm-2 col-form-label is-invalid'
              : 'col-sm-2 col-form-label'
          }
        >
          FamilyId
        </label>
        <div className="col-sm-12">
          <Field
            type="number"
            name="familyId"
            className={
              errorExistForField('familyId')
                ? 'form-control is-invalid'
                : 'form-control'
            }
          />
          {errorExistForField('familyId') && (
            <small className="text-danger">{errorsForField('familyId')}</small>
          )}
        </div>
      </div>

      <div className="form-group row">
        <label
          htmlFor="name"
          className={
            errorExistForField('firstName')
              ? 'col-sm-2 col-form-label is-invalid'
              : 'col-sm-2 col-form-label'
          }
        >
          First Name
        </label>
        <div className="col-sm-12">
          <Field
            type="textbox"
            name="firstName"
            className={
              errorExistForField('firstName')
                ? 'form-control is-invalid'
                : 'form-control'
            }
          />
          {errorExistForField('firstName') && (
            <small className="text-danger">{errorsForField('firstName')}</small>
          )}
        </div>
      </div>

      <div className="form-group row">
        <label
          htmlFor="name"
          className={
            errorExistForField('isAdult')
              ? 'col-sm-2 col-form-label is-invalid'
              : 'col-sm-2 col-form-label'
          }
        >
          Is Adult
        </label>
        <div className="col-sm-12">
          <Field
            type="checkbox"
            checked={props.values.isAdult}
            name="isAdult"
            className={
              errorExistForField('isAdult')
                ? 'form-control is-invalid'
                : 'form-control'
            }
          />
          {errorExistForField('isAdult') && (
            <small className="text-danger">{errorsForField('isAdult')}</small>
          )}
        </div>
      </div>

      <div className="form-group row">
        <label
          htmlFor="name"
          className={
            errorExistForField('lastName')
              ? 'col-sm-2 col-form-label is-invalid'
              : 'col-sm-2 col-form-label'
          }
        >
          Last Name
        </label>
        <div className="col-sm-12">
          <Field
            type="textbox"
            name="lastName"
            className={
              errorExistForField('lastName')
                ? 'form-control is-invalid'
                : 'form-control'
            }
          />
          {errorExistForField('lastName') && (
            <small className="text-danger">{errorsForField('lastName')}</small>
          )}
        </div>
      </div>

      <div className="form-group row">
        <label
          htmlFor="name"
          className={
            errorExistForField('phone')
              ? 'col-sm-2 col-form-label is-invalid'
              : 'col-sm-2 col-form-label'
          }
        >
          Phone
        </label>
        <div className="col-sm-12">
          <Field
            type="tel"
            name="phone"
            className={
              errorExistForField('phone')
                ? 'form-control is-invalid'
                : 'form-control'
            }
          />
          {errorExistForField('phone') && (
            <small className="text-danger">{errorsForField('phone')}</small>
          )}
        </div>
      </div>

      <div className="form-group row">
        <label
          htmlFor="name"
          className={
            errorExistForField('smsRemindersEnabled')
              ? 'col-sm-2 col-form-label is-invalid'
              : 'col-sm-2 col-form-label'
          }
        >
          SMS Reminders Enabled
        </label>
        <div className="col-sm-12">
          <Field
            type="checkbox"
            checked={props.values.smsRemindersEnabled}
            name="smsRemindersEnabled"
            className={
              errorExistForField('smsRemindersEnabled')
                ? 'form-control is-invalid'
                : 'form-control'
            }
          />
          {errorExistForField('smsRemindersEnabled') && (
            <small className="text-danger">
              {errorsForField('smsRemindersEnabled')}
            </small>
          )}
        </div>
      </div>

      <div className="form-group row">
        <label
          htmlFor="name"
          className={
            errorExistForField('userId')
              ? 'col-sm-2 col-form-label is-invalid'
              : 'col-sm-2 col-form-label'
          }
        >
          UserId
        </label>
        <div className="col-sm-12">
          <Field
            type="number"
            name="userId"
            className={
              errorExistForField('userId')
                ? 'form-control is-invalid'
                : 'form-control'
            }
          />
          {errorExistForField('userId') && (
            <small className="text-danger">{errorsForField('userId')}</small>
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

const StudentCreate = withFormik<Props, StudentViewModel>({
  mapPropsToValues: props => {
    let response = new StudentViewModel();
    if (props.model != undefined) {
      response.setProperties(
        props.model!.birthday,
        props.model!.email,
        props.model!.emailRemindersEnabled,
        props.model!.familyId,
        props.model!.firstName,
        props.model!.id,
        props.model!.isAdult,
        props.model!.lastName,
        props.model!.phone,
        props.model!.smsRemindersEnabled,
        props.model!.userId
      );
    }
    return response;
  },

  validate: values => {
    let errors: FormikErrors<StudentViewModel> = {};

    if (values.birthday == undefined) {
      errors.birthday = 'Required';
    }
    if (values.email == '') {
      errors.email = 'Required';
    }
    if (values.familyId == 0) {
      errors.familyId = 'Required';
    }
    if (values.firstName == '') {
      errors.firstName = 'Required';
    }
    if (values.lastName == '') {
      errors.lastName = 'Required';
    }
    if (values.phone == '') {
      errors.phone = 'Required';
    }
    if (values.userId == 0) {
      errors.userId = 'Required';
    }

    return errors;
  },

  handleSubmit: (values, actions) => {
    actions.setStatus(undefined);
    let mapper = new StudentMapper();

    axios
      .post(
        Constants.ApiEndpoint + ApiRoutes.Students,
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
            Api.StudentClientRequestModel
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
  displayName: 'StudentCreate',
})(StudentCreateDisplay);

interface StudentCreateComponentProps {}

interface StudentCreateComponentState {
  model?: StudentViewModel;
  loading: boolean;
  loaded: boolean;
  errorOccurred: boolean;
  errorMessage: string;
}

export default class StudentCreateComponent extends React.Component<
  StudentCreateComponentProps,
  StudentCreateComponentState
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
      return <StudentCreate model={this.state.model} />;
    } else {
      return null;
    }
  }
}


/*<Codenesium>
    <Hash>c2bff9aba88254c04f0b4116e9ab129f</Hash>
</Codenesium>*/