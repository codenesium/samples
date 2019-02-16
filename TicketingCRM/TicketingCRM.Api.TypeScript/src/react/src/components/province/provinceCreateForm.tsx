import React, { Component } from 'react';
import axios from 'axios';
import { CreateResponse } from '../../api/ApiObjects';
import { FormikProps, FormikErrors, Field, withFormik } from 'formik';
import * as Yup from 'yup';
import { LoadingForm } from '../../lib/components/loadingForm';
import { ErrorForm } from '../../lib/components/errorForm';
import * as Api from '../../api/models';
import { Constants, ApiRoutes, ClientRoutes } from '../../constants';
import ProvinceMapper from './provinceMapper';
import ProvinceViewModel from './provinceViewModel';

interface Props {
  model?: ProvinceViewModel;
}

const ProvinceCreateDisplay: React.SFC<FormikProps<ProvinceViewModel>> = (
  props: FormikProps<ProvinceViewModel>
) => {
  let status = props.status as CreateResponse<Api.ProvinceClientRequestModel>;

  let errorsForField = (name: string): string => {
    let response = '';
    if (
      props.touched[name as keyof ProvinceViewModel] &&
      props.errors[name as keyof ProvinceViewModel]
    ) {
      response += props.errors[name as keyof ProvinceViewModel];
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

const ProvinceCreate = withFormik<Props, ProvinceViewModel>({
  mapPropsToValues: props => {
    let response = new ProvinceViewModel();
    if (props.model != undefined) {
      response.setProperties(
        props.model!.countryId,
        props.model!.id,
        props.model!.name
      );
    }
    return response;
  },

  validate: values => {
    let errors: FormikErrors<ProvinceViewModel> = {};

    if (values.countryId == 0) {
      errors.countryId = 'Required';
    }
    if (values.name == '') {
      errors.name = 'Required';
    }

    return errors;
  },

  handleSubmit: (values, actions) => {
    actions.setStatus(undefined);
    let mapper = new ProvinceMapper();

    axios
      .post(
        Constants.ApiEndpoint + ApiRoutes.Provinces,
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
            Api.ProvinceClientRequestModel
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
  displayName: 'ProvinceCreate',
})(ProvinceCreateDisplay);

interface ProvinceCreateComponentProps {}

interface ProvinceCreateComponentState {
  model?: ProvinceViewModel;
  loading: boolean;
  loaded: boolean;
  errorOccurred: boolean;
  errorMessage: string;
}

export default class ProvinceCreateComponent extends React.Component<
  ProvinceCreateComponentProps,
  ProvinceCreateComponentState
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
      return <ProvinceCreate model={this.state.model} />;
    } else {
      return null;
    }
  }
}


/*<Codenesium>
    <Hash>43e5308f403fa0b51cde00ce925b7a73</Hash>
</Codenesium>*/