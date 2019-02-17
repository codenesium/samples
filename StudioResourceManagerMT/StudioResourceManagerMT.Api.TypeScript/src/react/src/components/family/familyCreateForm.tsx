import React, { Component } from 'react';
import axios from 'axios';
import { CreateResponse } from '../../api/apiObjects';
import { FormikProps, FormikErrors, Field, withFormik } from 'formik';
import * as Yup from 'yup';
import { LoadingForm } from '../../lib/components/loadingForm';
import { ErrorForm } from '../../lib/components/errorForm';
import * as Api from '../../api/models';
import { Constants, ApiRoutes, ClientRoutes } from '../../constants';
import FamilyMapper from './familyMapper';
import FamilyViewModel from './familyViewModel';

interface Props {
  model?: FamilyViewModel;
}

const FamilyCreateDisplay: React.SFC<FormikProps<FamilyViewModel>> = (
  props: FormikProps<FamilyViewModel>
) => {
  let status = props.status as CreateResponse<Api.FamilyClientRequestModel>;

  let errorsForField = (name: string): string => {
    let response = '';
    if (
      props.touched[name as keyof FamilyViewModel] &&
      props.errors[name as keyof FamilyViewModel]
    ) {
      response += props.errors[name as keyof FamilyViewModel];
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
            errorExistForField('note')
              ? 'col-sm-2 col-form-label is-invalid'
              : 'col-sm-2 col-form-label'
          }
        >
          Notes
        </label>
        <div className="col-sm-12">
          <Field
            type="datetime-local"
            name="note"
            className={
              errorExistForField('note')
                ? 'form-control is-invalid'
                : 'form-control'
            }
          />
          {errorExistForField('note') && (
            <small className="text-danger">{errorsForField('note')}</small>
          )}
        </div>
      </div>

      <div className="form-group row">
        <label
          htmlFor="name"
          className={
            errorExistForField('primaryContactEmail')
              ? 'col-sm-2 col-form-label is-invalid'
              : 'col-sm-2 col-form-label'
          }
        >
          PrimaryContactEmail
        </label>
        <div className="col-sm-12">
          <Field
            type="datetime-local"
            name="primaryContactEmail"
            className={
              errorExistForField('primaryContactEmail')
                ? 'form-control is-invalid'
                : 'form-control'
            }
          />
          {errorExistForField('primaryContactEmail') && (
            <small className="text-danger">
              {errorsForField('primaryContactEmail')}
            </small>
          )}
        </div>
      </div>

      <div className="form-group row">
        <label
          htmlFor="name"
          className={
            errorExistForField('primaryContactFirstName')
              ? 'col-sm-2 col-form-label is-invalid'
              : 'col-sm-2 col-form-label'
          }
        >
          PrimaryContactFirstName
        </label>
        <div className="col-sm-12">
          <Field
            type="datetime-local"
            name="primaryContactFirstName"
            className={
              errorExistForField('primaryContactFirstName')
                ? 'form-control is-invalid'
                : 'form-control'
            }
          />
          {errorExistForField('primaryContactFirstName') && (
            <small className="text-danger">
              {errorsForField('primaryContactFirstName')}
            </small>
          )}
        </div>
      </div>

      <div className="form-group row">
        <label
          htmlFor="name"
          className={
            errorExistForField('primaryContactLastName')
              ? 'col-sm-2 col-form-label is-invalid'
              : 'col-sm-2 col-form-label'
          }
        >
          PrimaryContactLastName
        </label>
        <div className="col-sm-12">
          <Field
            type="datetime-local"
            name="primaryContactLastName"
            className={
              errorExistForField('primaryContactLastName')
                ? 'form-control is-invalid'
                : 'form-control'
            }
          />
          {errorExistForField('primaryContactLastName') && (
            <small className="text-danger">
              {errorsForField('primaryContactLastName')}
            </small>
          )}
        </div>
      </div>

      <div className="form-group row">
        <label
          htmlFor="name"
          className={
            errorExistForField('primaryContactPhone')
              ? 'col-sm-2 col-form-label is-invalid'
              : 'col-sm-2 col-form-label'
          }
        >
          PrimaryContactPhone
        </label>
        <div className="col-sm-12">
          <Field
            type="datetime-local"
            name="primaryContactPhone"
            className={
              errorExistForField('primaryContactPhone')
                ? 'form-control is-invalid'
                : 'form-control'
            }
          />
          {errorExistForField('primaryContactPhone') && (
            <small className="text-danger">
              {errorsForField('primaryContactPhone')}
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

const FamilyCreate = withFormik<Props, FamilyViewModel>({
  mapPropsToValues: props => {
    let response = new FamilyViewModel();
    if (props.model != undefined) {
      response.setProperties(
        props.model!.id,
        props.model!.note,
        props.model!.primaryContactEmail,
        props.model!.primaryContactFirstName,
        props.model!.primaryContactLastName,
        props.model!.primaryContactPhone
      );
    }
    return response;
  },

  validate: values => {
    let errors: FormikErrors<FamilyViewModel> = {};

    if (values.primaryContactPhone == '') {
      errors.primaryContactPhone = 'Required';
    }

    return errors;
  },

  handleSubmit: (values, actions) => {
    actions.setStatus(undefined);
    let mapper = new FamilyMapper();

    axios
      .post(
        Constants.ApiEndpoint + ApiRoutes.Families,
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
            Api.FamilyClientRequestModel
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
  displayName: 'FamilyCreate',
})(FamilyCreateDisplay);

interface FamilyCreateComponentProps {}

interface FamilyCreateComponentState {
  model?: FamilyViewModel;
  loading: boolean;
  loaded: boolean;
  errorOccurred: boolean;
  errorMessage: string;
}

export default class FamilyCreateComponent extends React.Component<
  FamilyCreateComponentProps,
  FamilyCreateComponentState
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
      return <FamilyCreate model={this.state.model} />;
    } else {
      return null;
    }
  }
}


/*<Codenesium>
    <Hash>6433f2e7664669a0051087eed5e7a7f0</Hash>
</Codenesium>*/