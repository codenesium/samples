import React, { Component } from 'react';
import axios from 'axios';
import { CreateResponse } from '../../api/ApiObjects';
import { FormikProps, FormikErrors, Field, withFormik } from 'formik';
import * as Yup from 'yup';
import * as Api from '../../api/models';
import Constants from '../../constants';
import PhoneNumberTypeMapper from './phoneNumberTypeMapper';
import PhoneNumberTypeViewModel from './phoneNumberTypeViewModel';

interface Props {
  model?: PhoneNumberTypeViewModel;
}

const PhoneNumberTypeCreateDisplay: React.SFC<
  FormikProps<PhoneNumberTypeViewModel>
> = (props: FormikProps<PhoneNumberTypeViewModel>) => {
  let status = props.status as CreateResponse<
    Api.PhoneNumberTypeClientRequestModel
  >;

  let errorsForField = (name: string): string => {
    let response = '';
    if (
      props.touched[name as keyof PhoneNumberTypeViewModel] &&
      props.errors[name as keyof PhoneNumberTypeViewModel]
    ) {
      response += props.errors[name as keyof PhoneNumberTypeViewModel];
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
            errorExistForField('name')
              ? 'col-sm-2 col-form-label is-invalid'
              : 'col-sm-2 col-form-label'
          }
        >
          Name
        </label>
        <div className="col-sm-12">
          <Field
            type="datetime-local"
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

const PhoneNumberTypeCreate = withFormik<Props, PhoneNumberTypeViewModel>({
  mapPropsToValues: props => {
    let response = new PhoneNumberTypeViewModel();
    if (props.model != undefined) {
      response.setProperties(
        props.model!.modifiedDate,
        props.model!.name,
        props.model!.phoneNumberTypeID
      );
    }
    return response;
  },

  validate: values => {
    let errors: FormikErrors<PhoneNumberTypeViewModel> = {};

    if (values.modifiedDate == undefined) {
      errors.modifiedDate = 'Required';
    }
    if (values.name == '') {
      errors.name = 'Required';
    }

    return errors;
  },

  handleSubmit: (values, actions) => {
    actions.setStatus(undefined);
    let mapper = new PhoneNumberTypeMapper();

    axios
      .post(
        Constants.ApiUrl + 'phonenumbertypes',
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
            Api.PhoneNumberTypeClientRequestModel
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
  displayName: 'PhoneNumberTypeCreate',
})(PhoneNumberTypeCreateDisplay);

interface PhoneNumberTypeCreateComponentProps {}

interface PhoneNumberTypeCreateComponentState {
  model?: PhoneNumberTypeViewModel;
  loading: boolean;
  loaded: boolean;
  errorOccurred: boolean;
  errorMessage: string;
}

export default class PhoneNumberTypeCreateComponent extends React.Component<
  PhoneNumberTypeCreateComponentProps,
  PhoneNumberTypeCreateComponentState
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
      return <PhoneNumberTypeCreate model={this.state.model} />;
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
    <Hash>b438473f7b3bb37d03958af0d0a2d720</Hash>
</Codenesium>*/