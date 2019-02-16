import React, { Component } from 'react';
import axios from 'axios';
import * as Api from '../api/models';
import { UpdateResponse } from '../api/ApiObjects';
import Constants from '../constants';
import { FormikProps, FormikErrors, Field, withFormik } from 'formik';
import TeacherViewModel from '../viewmodels/teacherViewModel';
import TeacherMapper from '../mapping/teacherMapper';

interface Props {
  model?: TeacherViewModel;
}

const TeacherEditDisplay = (props: FormikProps<TeacherViewModel>) => {
  let status = props.status as UpdateResponse<Api.TeacherClientRequestModel>;

  let errorsForField = (name: string): string => {
    let response = '';
    if (
      props.touched[name as keyof TeacherViewModel] &&
      props.errors[name as keyof TeacherViewModel]
    ) {
      response += props.errors[name as keyof TeacherViewModel];
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
            type="input"
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
            type="input"
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
            errorExistForField('firstName')
              ? 'col-sm-2 col-form-label is-invalid'
              : 'col-sm-2 col-form-label'
          }
        >
          FirstName
        </label>
        <div className="col-sm-12">
          <Field
            type="input"
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
            errorExistForField('id')
              ? 'col-sm-2 col-form-label is-invalid'
              : 'col-sm-2 col-form-label'
          }
        >
          Id
        </label>
        <div className="col-sm-12">
          <Field
            type="input"
            name="id"
            className={
              errorExistForField('id')
                ? 'form-control is-invalid'
                : 'form-control'
            }
          />

          {errorExistForField('id') && (
            <small className="text-danger">{errorsForField('id')}</small>
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
            errorExistForField('lastName')
              ? 'col-sm-2 col-form-label is-invalid'
              : 'col-sm-2 col-form-label'
          }
        >
          LastName
        </label>
        <div className="col-sm-12">
          <Field
            type="input"
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
            type="input"
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
            type="input"
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

const TeacherUpdate = withFormik<Props, TeacherViewModel>({
  mapPropsToValues: props => {
    let response = new TeacherViewModel();
    response.setProperties(
      props.model!.birthday,
      props.model!.email,
      props.model!.firstName,
      props.model!.id,
      props.model!.isDeleted,
      props.model!.lastName,
      props.model!.phone,
      props.model!.tenantId,
      props.model!.userId
    );
    return response;
  },

  // Custom sync validation
  validate: values => {
    let errors: FormikErrors<TeacherViewModel> = {};

    if (values.birthday == undefined) {
      errors.birthday = 'Required';
    }
    if (values.email == '') {
      errors.email = 'Required';
    }
    if (values.firstName == '') {
      errors.firstName = 'Required';
    }
    if (values.id == 0) {
      errors.id = 'Required';
    }
    if (values.isDeleted == false) {
      errors.isDeleted = 'Required';
    }
    if (values.lastName == '') {
      errors.lastName = 'Required';
    }
    if (values.tenantId == 0) {
      errors.tenantId = 'Required';
    }
    if (values.userId == 0) {
      errors.userId = 'Required';
    }

    return errors;
  },
  handleSubmit: (values, actions) => {
    actions.setStatus(undefined);

    let mapper = new TeacherMapper();

    axios
      .put(
        Constants.ApiUrl + 'teachers/' + values.id,

        mapper.mapViewModelToApiRequest(values),
        {
          headers: {
            'Content-Type': 'application/json',
          },
        }
      )
      .then(
        resp => {
          let response = resp.data as UpdateResponse<
            Api.TeacherClientRequestModel
          >;
          actions.setStatus(response);
          console.log(response);
        },
        error => {
          let response = error.response.data as UpdateResponse<
            Api.TeacherClientRequestModel
          >;
          actions.setStatus(response);
          console.log(response);
        }
      )
      .then(response => {
        // cleanup
      });
  },

  displayName: 'TeacherEdit',
})(TeacherEditDisplay);

interface IParams {
  id: number;
}

interface IMatch {
  params: IParams;
}

interface TeacherEditComponentProps {
  match: IMatch;
}

interface TeacherEditComponentState {
  model?: TeacherViewModel;
  loading: boolean;
  loaded: boolean;
  errorOccurred: boolean;
  errorMessage: string;
}

export default class TeacherEditComponent extends React.Component<
  TeacherEditComponentProps,
  TeacherEditComponentState
> {
  state = {
    model: undefined,
    loading: false,
    loaded: false,
    errorOccurred: false,
    errorMessage: '',
  };

  componentDidMount() {
    this.setState({ ...this.state, loading: true });

    axios
      .get(Constants.ApiUrl + 'teachers/' + this.props.match.params.id, {
        headers: {
          'Content-Type': 'application/json',
        },
      })
      .then(
        resp => {
          let response = resp.data as Api.TeacherClientResponseModel;

          console.log(response);

          let mapper = new TeacherMapper();

          this.setState({
            model: mapper.mapApiResponseToViewModel(response),
            loading: false,
            loaded: true,
            errorOccurred: false,
            errorMessage: '',
          });
        },
        error => {
          let response = error.response.data as UpdateResponse<
            Api.TeacherClientRequestModel
          >;
          this.setState({
            model: undefined,
            loading: false,
            loaded: false,
            errorOccurred: true,
            errorMessage: 'Error from API',
          });
          console.log(response);
        }
      );
  }
  render() {
    if (this.state.loading) {
      return <div>loading</div>;
    } else if (this.state.loaded) {
      return <TeacherUpdate model={this.state.model} />;
    } else if (this.state.errorOccurred) {
      return <div>{this.state.errorMessage}</div>;
    } else {
      return <div />;
    }
  }
}


/*<Codenesium>
    <Hash>afff4167723ad5de50da7dd4340c412a</Hash>
</Codenesium>*/