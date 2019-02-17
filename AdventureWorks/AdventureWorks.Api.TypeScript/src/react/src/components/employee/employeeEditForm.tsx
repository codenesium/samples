import React, { Component } from 'react';
import axios from 'axios';
import * as Api from '../../api/models';
import { UpdateResponse } from '../../api/apiObjects';
import { Constants, ApiRoutes, ClientRoutes } from '../../constants';
import { FormikProps, FormikErrors, Field, withFormik } from 'formik';
import { LoadingForm } from '../../lib/components/loadingForm';
import { ErrorForm } from '../../lib/components/errorForm';
import EmployeeViewModel from './employeeViewModel';
import EmployeeMapper from './employeeMapper';

interface Props {
  model?: EmployeeViewModel;
}

const EmployeeEditDisplay = (props: FormikProps<EmployeeViewModel>) => {
  let status = props.status as UpdateResponse<Api.EmployeeClientRequestModel>;

  let errorsForField = (name: string): string => {
    let response = '';
    if (
      props.touched[name as keyof EmployeeViewModel] &&
      props.errors[name as keyof EmployeeViewModel]
    ) {
      response += props.errors[name as keyof EmployeeViewModel];
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
            errorExistForField('birthDate')
              ? 'col-sm-2 col-form-label is-invalid'
              : 'col-sm-2 col-form-label'
          }
        >
          BirthDate
        </label>
        <div className="col-sm-12">
          <Field
            type="datetime-local"
            name="birthDate"
            className={
              errorExistForField('birthDate')
                ? 'form-control is-invalid'
                : 'form-control'
            }
          />
          {errorExistForField('birthDate') && (
            <small className="text-danger">{errorsForField('birthDate')}</small>
          )}
        </div>
      </div>
      <div className="form-group row">
        <label
          htmlFor="name"
          className={
            errorExistForField('businessEntityID')
              ? 'col-sm-2 col-form-label is-invalid'
              : 'col-sm-2 col-form-label'
          }
        >
          BusinessEntityID
        </label>
        <div className="col-sm-12">
          <Field
            type="datetime-local"
            name="businessEntityID"
            className={
              errorExistForField('businessEntityID')
                ? 'form-control is-invalid'
                : 'form-control'
            }
          />
          {errorExistForField('businessEntityID') && (
            <small className="text-danger">
              {errorsForField('businessEntityID')}
            </small>
          )}
        </div>
      </div>
      <div className="form-group row">
        <label
          htmlFor="name"
          className={
            errorExistForField('currentFlag')
              ? 'col-sm-2 col-form-label is-invalid'
              : 'col-sm-2 col-form-label'
          }
        >
          CurrentFlag
        </label>
        <div className="col-sm-12">
          <Field
            type="datetime-local"
            name="currentFlag"
            className={
              errorExistForField('currentFlag')
                ? 'form-control is-invalid'
                : 'form-control'
            }
          />
          {errorExistForField('currentFlag') && (
            <small className="text-danger">
              {errorsForField('currentFlag')}
            </small>
          )}
        </div>
      </div>
      <div className="form-group row">
        <label
          htmlFor="name"
          className={
            errorExistForField('gender')
              ? 'col-sm-2 col-form-label is-invalid'
              : 'col-sm-2 col-form-label'
          }
        >
          Gender
        </label>
        <div className="col-sm-12">
          <Field
            type="datetime-local"
            name="gender"
            className={
              errorExistForField('gender')
                ? 'form-control is-invalid'
                : 'form-control'
            }
          />
          {errorExistForField('gender') && (
            <small className="text-danger">{errorsForField('gender')}</small>
          )}
        </div>
      </div>
      <div className="form-group row">
        <label
          htmlFor="name"
          className={
            errorExistForField('hireDate')
              ? 'col-sm-2 col-form-label is-invalid'
              : 'col-sm-2 col-form-label'
          }
        >
          HireDate
        </label>
        <div className="col-sm-12">
          <Field
            type="datetime-local"
            name="hireDate"
            className={
              errorExistForField('hireDate')
                ? 'form-control is-invalid'
                : 'form-control'
            }
          />
          {errorExistForField('hireDate') && (
            <small className="text-danger">{errorsForField('hireDate')}</small>
          )}
        </div>
      </div>
      <div className="form-group row">
        <label
          htmlFor="name"
          className={
            errorExistForField('jobTitle')
              ? 'col-sm-2 col-form-label is-invalid'
              : 'col-sm-2 col-form-label'
          }
        >
          JobTitle
        </label>
        <div className="col-sm-12">
          <Field
            type="datetime-local"
            name="jobTitle"
            className={
              errorExistForField('jobTitle')
                ? 'form-control is-invalid'
                : 'form-control'
            }
          />
          {errorExistForField('jobTitle') && (
            <small className="text-danger">{errorsForField('jobTitle')}</small>
          )}
        </div>
      </div>
      <div className="form-group row">
        <label
          htmlFor="name"
          className={
            errorExistForField('loginID')
              ? 'col-sm-2 col-form-label is-invalid'
              : 'col-sm-2 col-form-label'
          }
        >
          LoginID
        </label>
        <div className="col-sm-12">
          <Field
            type="datetime-local"
            name="loginID"
            className={
              errorExistForField('loginID')
                ? 'form-control is-invalid'
                : 'form-control'
            }
          />
          {errorExistForField('loginID') && (
            <small className="text-danger">{errorsForField('loginID')}</small>
          )}
        </div>
      </div>
      <div className="form-group row">
        <label
          htmlFor="name"
          className={
            errorExistForField('maritalStatu')
              ? 'col-sm-2 col-form-label is-invalid'
              : 'col-sm-2 col-form-label'
          }
        >
          MaritalStatus
        </label>
        <div className="col-sm-12">
          <Field
            type="datetime-local"
            name="maritalStatu"
            className={
              errorExistForField('maritalStatu')
                ? 'form-control is-invalid'
                : 'form-control'
            }
          />
          {errorExistForField('maritalStatu') && (
            <small className="text-danger">
              {errorsForField('maritalStatu')}
            </small>
          )}
        </div>
      </div>
      <div className="form-group row">
        <label
          htmlFor="name"
          className={
            errorExistForField('modifiedDate')
              ? 'col-sm-2 col-form-label is-invalid'
              : 'col-sm-2 col-form-label'
          }
        >
          ModifiedDate
        </label>
        <div className="col-sm-12">
          <Field
            type="datetime-local"
            name="modifiedDate"
            className={
              errorExistForField('modifiedDate')
                ? 'form-control is-invalid'
                : 'form-control'
            }
          />
          {errorExistForField('modifiedDate') && (
            <small className="text-danger">
              {errorsForField('modifiedDate')}
            </small>
          )}
        </div>
      </div>
      <div className="form-group row">
        <label
          htmlFor="name"
          className={
            errorExistForField('nationalIDNumber')
              ? 'col-sm-2 col-form-label is-invalid'
              : 'col-sm-2 col-form-label'
          }
        >
          NationalIDNumber
        </label>
        <div className="col-sm-12">
          <Field
            type="datetime-local"
            name="nationalIDNumber"
            className={
              errorExistForField('nationalIDNumber')
                ? 'form-control is-invalid'
                : 'form-control'
            }
          />
          {errorExistForField('nationalIDNumber') && (
            <small className="text-danger">
              {errorsForField('nationalIDNumber')}
            </small>
          )}
        </div>
      </div>
      <div className="form-group row">
        <label
          htmlFor="name"
          className={
            errorExistForField('organizationLevel')
              ? 'col-sm-2 col-form-label is-invalid'
              : 'col-sm-2 col-form-label'
          }
        >
          OrganizationLevel
        </label>
        <div className="col-sm-12">
          <Field
            type="datetime-local"
            name="organizationLevel"
            className={
              errorExistForField('organizationLevel')
                ? 'form-control is-invalid'
                : 'form-control'
            }
          />
          {errorExistForField('organizationLevel') && (
            <small className="text-danger">
              {errorsForField('organizationLevel')}
            </small>
          )}
        </div>
      </div>
      <div className="form-group row">
        <label
          htmlFor="name"
          className={
            errorExistForField('rowguid')
              ? 'col-sm-2 col-form-label is-invalid'
              : 'col-sm-2 col-form-label'
          }
        >
          Rowguid
        </label>
        <div className="col-sm-12">
          <Field
            type="datetime-local"
            name="rowguid"
            className={
              errorExistForField('rowguid')
                ? 'form-control is-invalid'
                : 'form-control'
            }
          />
          {errorExistForField('rowguid') && (
            <small className="text-danger">{errorsForField('rowguid')}</small>
          )}
        </div>
      </div>
      <div className="form-group row">
        <label
          htmlFor="name"
          className={
            errorExistForField('salariedFlag')
              ? 'col-sm-2 col-form-label is-invalid'
              : 'col-sm-2 col-form-label'
          }
        >
          SalariedFlag
        </label>
        <div className="col-sm-12">
          <Field
            type="datetime-local"
            name="salariedFlag"
            className={
              errorExistForField('salariedFlag')
                ? 'form-control is-invalid'
                : 'form-control'
            }
          />
          {errorExistForField('salariedFlag') && (
            <small className="text-danger">
              {errorsForField('salariedFlag')}
            </small>
          )}
        </div>
      </div>
      <div className="form-group row">
        <label
          htmlFor="name"
          className={
            errorExistForField('sickLeaveHour')
              ? 'col-sm-2 col-form-label is-invalid'
              : 'col-sm-2 col-form-label'
          }
        >
          SickLeaveHours
        </label>
        <div className="col-sm-12">
          <Field
            type="datetime-local"
            name="sickLeaveHour"
            className={
              errorExistForField('sickLeaveHour')
                ? 'form-control is-invalid'
                : 'form-control'
            }
          />
          {errorExistForField('sickLeaveHour') && (
            <small className="text-danger">
              {errorsForField('sickLeaveHour')}
            </small>
          )}
        </div>
      </div>
      <div className="form-group row">
        <label
          htmlFor="name"
          className={
            errorExistForField('vacationHour')
              ? 'col-sm-2 col-form-label is-invalid'
              : 'col-sm-2 col-form-label'
          }
        >
          VacationHours
        </label>
        <div className="col-sm-12">
          <Field
            type="datetime-local"
            name="vacationHour"
            className={
              errorExistForField('vacationHour')
                ? 'form-control is-invalid'
                : 'form-control'
            }
          />
          {errorExistForField('vacationHour') && (
            <small className="text-danger">
              {errorsForField('vacationHour')}
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

const EmployeeEdit = withFormik<Props, EmployeeViewModel>({
  mapPropsToValues: props => {
    let response = new EmployeeViewModel();
    response.setProperties(
      props.model!.birthDate,
      props.model!.businessEntityID,
      props.model!.currentFlag,
      props.model!.gender,
      props.model!.hireDate,
      props.model!.jobTitle,
      props.model!.loginID,
      props.model!.maritalStatu,
      props.model!.modifiedDate,
      props.model!.nationalIDNumber,
      props.model!.organizationLevel,
      props.model!.rowguid,
      props.model!.salariedFlag,
      props.model!.sickLeaveHour,
      props.model!.vacationHour
    );
    return response;
  },

  // Custom sync validation
  validate: values => {
    let errors: FormikErrors<EmployeeViewModel> = {};

    if (values.birthDate == undefined) {
      errors.birthDate = 'Required';
    }
    if (values.businessEntityID == 0) {
      errors.businessEntityID = 'Required';
    }
    if (values.gender == '') {
      errors.gender = 'Required';
    }
    if (values.hireDate == undefined) {
      errors.hireDate = 'Required';
    }
    if (values.jobTitle == '') {
      errors.jobTitle = 'Required';
    }
    if (values.loginID == '') {
      errors.loginID = 'Required';
    }
    if (values.maritalStatu == '') {
      errors.maritalStatu = 'Required';
    }
    if (values.modifiedDate == undefined) {
      errors.modifiedDate = 'Required';
    }
    if (values.nationalIDNumber == '') {
      errors.nationalIDNumber = 'Required';
    }
    if (values.rowguid == undefined) {
      errors.rowguid = 'Required';
    }
    if (values.sickLeaveHour == 0) {
      errors.sickLeaveHour = 'Required';
    }
    if (values.vacationHour == 0) {
      errors.vacationHour = 'Required';
    }

    return errors;
  },
  handleSubmit: (values, actions) => {
    actions.setStatus(undefined);

    let mapper = new EmployeeMapper();

    axios
      .put(
        Constants.ApiEndpoint +
          ApiRoutes.Employees +
          '/' +
          values.businessEntityID,

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
            Api.EmployeeClientRequestModel
          >;
          actions.setStatus(response);
          console.log(response);
        },
        error => {
          console.log(error);
          actions.setStatus('Error from API');
        }
      )
      .then(response => {
        // cleanup
      });
  },

  displayName: 'EmployeeEdit',
})(EmployeeEditDisplay);

interface IParams {
  businessEntityID: number;
}

interface IMatch {
  params: IParams;
}

interface EmployeeEditComponentProps {
  match: IMatch;
}

interface EmployeeEditComponentState {
  model?: EmployeeViewModel;
  loading: boolean;
  loaded: boolean;
  errorOccurred: boolean;
  errorMessage: string;
}

export default class EmployeeEditComponent extends React.Component<
  EmployeeEditComponentProps,
  EmployeeEditComponentState
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
      .get(
        Constants.ApiEndpoint +
          ApiRoutes.Employees +
          '/' +
          this.props.match.params.businessEntityID,
        {
          headers: {
            'Content-Type': 'application/json',
          },
        }
      )
      .then(
        resp => {
          let response = resp.data as Api.EmployeeClientResponseModel;

          console.log(response);

          let mapper = new EmployeeMapper();

          this.setState({
            model: mapper.mapApiResponseToViewModel(response),
            loading: false,
            loaded: true,
            errorOccurred: false,
            errorMessage: '',
          });
        },
        error => {
          console.log(error);
          this.setState({
            model: undefined,
            loading: false,
            loaded: false,
            errorOccurred: true,
            errorMessage: 'Error from API',
          });
        }
      );
  }
  render() {
    if (this.state.loading) {
      return <LoadingForm />;
    } else if (this.state.errorOccurred) {
      return <ErrorForm message={this.state.errorMessage} />;
    } else if (this.state.loaded) {
      return <EmployeeEdit model={this.state.model} />;
    } else {
      return null;
    }
  }
}


/*<Codenesium>
    <Hash>a58a52aef8e6ff16b59e0ef6290547e6</Hash>
</Codenesium>*/