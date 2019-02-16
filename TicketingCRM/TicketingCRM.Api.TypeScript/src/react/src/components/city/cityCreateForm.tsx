import React, { Component } from 'react';
import axios from 'axios';
import { CreateResponse } from '../../api/ApiObjects';
import { FormikProps, FormikErrors, Field, withFormik } from 'formik';
import * as Yup from 'yup';
import { LoadingForm } from '../../lib/components/loadingForm';
import { ErrorForm } from '../../lib/components/errorForm';
import * as Api from '../../api/models';
import { Constants, ApiRoutes, ClientRoutes } from '../../constants';
import CityMapper from './cityMapper';
import CityViewModel from './cityViewModel';

interface Props {
  model?: CityViewModel;
}

const CityCreateDisplay: React.SFC<FormikProps<CityViewModel>> = (
  props: FormikProps<CityViewModel>
) => {
  let status = props.status as CreateResponse<Api.CityClientRequestModel>;

  let errorsForField = (name: string): string => {
    let response = '';
    if (
      props.touched[name as keyof CityViewModel] &&
      props.errors[name as keyof CityViewModel]
    ) {
      response += props.errors[name as keyof CityViewModel];
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

      <div className="form-group row">
        <label
          htmlFor="name"
          className={
            errorExistForField('provinceId')
              ? 'col-sm-2 col-form-label is-invalid'
              : 'col-sm-2 col-form-label'
          }
        >
          ProvinceId
        </label>
        <div className="col-sm-12">
          <Field
            type="datetime-local"
            name="provinceId"
            className={
              errorExistForField('provinceId')
                ? 'form-control is-invalid'
                : 'form-control'
            }
          />
          {errorExistForField('provinceId') && (
            <small className="text-danger">
              {errorsForField('provinceId')}
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

const CityCreate = withFormik<Props, CityViewModel>({
  mapPropsToValues: props => {
    let response = new CityViewModel();
    if (props.model != undefined) {
      response.setProperties(
        props.model!.id,
        props.model!.name,
        props.model!.provinceId
      );
    }
    return response;
  },

  validate: values => {
    let errors: FormikErrors<CityViewModel> = {};

    if (values.name == '') {
      errors.name = 'Required';
    }
    if (values.provinceId == 0) {
      errors.provinceId = 'Required';
    }

    return errors;
  },

  handleSubmit: (values, actions) => {
    actions.setStatus(undefined);
    let mapper = new CityMapper();

    axios
      .post(
        Constants.ApiEndpoint + ApiRoutes.Cities,
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
            Api.CityClientRequestModel
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
  displayName: 'CityCreate',
})(CityCreateDisplay);

interface CityCreateComponentProps {}

interface CityCreateComponentState {
  model?: CityViewModel;
  loading: boolean;
  loaded: boolean;
  errorOccurred: boolean;
  errorMessage: string;
}

export default class CityCreateComponent extends React.Component<
  CityCreateComponentProps,
  CityCreateComponentState
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
      return <CityCreate model={this.state.model} />;
    } else {
      return null;
    }
  }
}


/*<Codenesium>
    <Hash>4a2e6aae42d52f3269ab047a1ecff591</Hash>
</Codenesium>*/