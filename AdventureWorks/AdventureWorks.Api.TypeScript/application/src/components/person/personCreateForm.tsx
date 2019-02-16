import React, { Component } from 'react';
import axios from 'axios';
import { CreateResponse } from '../../api/ApiObjects';
import { FormikProps, FormikErrors, Field, withFormik } from 'formik';
import * as Yup from 'yup';
import * as Api from '../../api/models';
import Constants from '../../constants';
import PersonMapper from './personMapper';
import PersonViewModel from './personViewModel';

interface Props {
  model?: PersonViewModel;
}

const PersonCreateDisplay: React.SFC<FormikProps<PersonViewModel>> = (
  props: FormikProps<PersonViewModel>
) => {
  let status = props.status as CreateResponse<Api.PersonClientRequestModel>;

  let errorsForField = (name: string): string => {
    let response = '';
    if (
      props.touched[name as keyof PersonViewModel] &&
      props.errors[name as keyof PersonViewModel]
    ) {
      response += props.errors[name as keyof PersonViewModel];
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
            errorExistForField('additionalContactInfo')
              ? 'col-sm-2 col-form-label is-invalid'
              : 'col-sm-2 col-form-label'
          }
        >
          AdditionalContactInfo
        </label>
        <div className="col-sm-12">
          <Field
            type="datetime-local"
            name="additionalContactInfo"
            className={
              errorExistForField('additionalContactInfo')
                ? 'form-control is-invalid'
                : 'form-control'
            }
          />
          {errorExistForField('additionalContactInfo') && (
            <small className="text-danger">
              {errorsForField('additionalContactInfo')}
            </small>
          )}
        </div>
      </div>

      <div className="form-group row">
        <label
          htmlFor="name"
          className={
            errorExistForField('demographic')
              ? 'col-sm-2 col-form-label is-invalid'
              : 'col-sm-2 col-form-label'
          }
        >
          Demographics
        </label>
        <div className="col-sm-12">
          <Field
            type="datetime-local"
            name="demographic"
            className={
              errorExistForField('demographic')
                ? 'form-control is-invalid'
                : 'form-control'
            }
          />
          {errorExistForField('demographic') && (
            <small className="text-danger">
              {errorsForField('demographic')}
            </small>
          )}
        </div>
      </div>

      <div className="form-group row">
        <label
          htmlFor="name"
          className={
            errorExistForField('emailPromotion')
              ? 'col-sm-2 col-form-label is-invalid'
              : 'col-sm-2 col-form-label'
          }
        >
          EmailPromotion
        </label>
        <div className="col-sm-12">
          <Field
            type="datetime-local"
            name="emailPromotion"
            className={
              errorExistForField('emailPromotion')
                ? 'form-control is-invalid'
                : 'form-control'
            }
          />
          {errorExistForField('emailPromotion') && (
            <small className="text-danger">
              {errorsForField('emailPromotion')}
            </small>
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
            type="datetime-local"
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
            errorExistForField('lastName')
              ? 'col-sm-2 col-form-label is-invalid'
              : 'col-sm-2 col-form-label'
          }
        >
          LastName
        </label>
        <div className="col-sm-12">
          <Field
            type="datetime-local"
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
            errorExistForField('middleName')
              ? 'col-sm-2 col-form-label is-invalid'
              : 'col-sm-2 col-form-label'
          }
        >
          MiddleName
        </label>
        <div className="col-sm-12">
          <Field
            type="datetime-local"
            name="middleName"
            className={
              errorExistForField('middleName')
                ? 'form-control is-invalid'
                : 'form-control'
            }
          />
          {errorExistForField('middleName') && (
            <small className="text-danger">
              {errorsForField('middleName')}
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
            errorExistForField('nameStyle')
              ? 'col-sm-2 col-form-label is-invalid'
              : 'col-sm-2 col-form-label'
          }
        >
          NameStyle
        </label>
        <div className="col-sm-12">
          <Field
            type="datetime-local"
            name="nameStyle"
            className={
              errorExistForField('nameStyle')
                ? 'form-control is-invalid'
                : 'form-control'
            }
          />
          {errorExistForField('nameStyle') && (
            <small className="text-danger">{errorsForField('nameStyle')}</small>
          )}
        </div>
      </div>

      <div className="form-group row">
        <label
          htmlFor="name"
          className={
            errorExistForField('personType')
              ? 'col-sm-2 col-form-label is-invalid'
              : 'col-sm-2 col-form-label'
          }
        >
          PersonType
        </label>
        <div className="col-sm-12">
          <Field
            type="datetime-local"
            name="personType"
            className={
              errorExistForField('personType')
                ? 'form-control is-invalid'
                : 'form-control'
            }
          />
          {errorExistForField('personType') && (
            <small className="text-danger">
              {errorsForField('personType')}
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
            errorExistForField('suffix')
              ? 'col-sm-2 col-form-label is-invalid'
              : 'col-sm-2 col-form-label'
          }
        >
          Suffix
        </label>
        <div className="col-sm-12">
          <Field
            type="datetime-local"
            name="suffix"
            className={
              errorExistForField('suffix')
                ? 'form-control is-invalid'
                : 'form-control'
            }
          />
          {errorExistForField('suffix') && (
            <small className="text-danger">{errorsForField('suffix')}</small>
          )}
        </div>
      </div>

      <div className="form-group row">
        <label
          htmlFor="name"
          className={
            errorExistForField('title')
              ? 'col-sm-2 col-form-label is-invalid'
              : 'col-sm-2 col-form-label'
          }
        >
          Title
        </label>
        <div className="col-sm-12">
          <Field
            type="datetime-local"
            name="title"
            className={
              errorExistForField('title')
                ? 'form-control is-invalid'
                : 'form-control'
            }
          />
          {errorExistForField('title') && (
            <small className="text-danger">{errorsForField('title')}</small>
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

const PersonCreate = withFormik<Props, PersonViewModel>({
  mapPropsToValues: props => {
    let response = new PersonViewModel();
    if (props.model != undefined) {
      response.setProperties(
        props.model!.additionalContactInfo,
        props.model!.businessEntityID,
        props.model!.demographic,
        props.model!.emailPromotion,
        props.model!.firstName,
        props.model!.lastName,
        props.model!.middleName,
        props.model!.modifiedDate,
        props.model!.nameStyle,
        props.model!.personType,
        props.model!.rowguid,
        props.model!.suffix,
        props.model!.title
      );
    }
    return response;
  },

  validate: values => {
    let errors: FormikErrors<PersonViewModel> = {};

    if (values.emailPromotion == 0) {
      errors.emailPromotion = 'Required';
    }
    if (values.firstName == '') {
      errors.firstName = 'Required';
    }
    if (values.lastName == '') {
      errors.lastName = 'Required';
    }
    if (values.modifiedDate == undefined) {
      errors.modifiedDate = 'Required';
    }
    if (values.nameStyle == false) {
      errors.nameStyle = 'Required';
    }
    if (values.personType == '') {
      errors.personType = 'Required';
    }
    if (values.rowguid == undefined) {
      errors.rowguid = 'Required';
    }

    return errors;
  },

  handleSubmit: (values, actions) => {
    actions.setStatus(undefined);
    let mapper = new PersonMapper();

    axios
      .post(
        Constants.ApiUrl + 'people',
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
            Api.PersonClientRequestModel
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
  displayName: 'PersonCreate',
})(PersonCreateDisplay);

interface PersonCreateComponentProps {}

interface PersonCreateComponentState {
  model?: PersonViewModel;
  loading: boolean;
  loaded: boolean;
  errorOccurred: boolean;
  errorMessage: string;
}

export default class PersonCreateComponent extends React.Component<
  PersonCreateComponentProps,
  PersonCreateComponentState
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
      return <div>loading</div>;
    } else if (this.state.loaded) {
      return <PersonCreate model={this.state.model} />;
    } else if (this.state.errorOccurred) {
      return (
        <div className="alert alert-danger">{this.state.errorMessage}</div>
      );
    } else {
      return <div />;
    }
  }
}


/*<Codenesium>
    <Hash>6f7723369afba470175649f5fcf04bbe</Hash>
</Codenesium>*/