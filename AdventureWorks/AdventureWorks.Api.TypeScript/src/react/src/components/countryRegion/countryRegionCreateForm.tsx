import React, { Component } from 'react';
import axios from 'axios';
import { CreateResponse } from '../../api/ApiObjects';
import { FormikProps, FormikErrors, Field, withFormik } from 'formik';
import * as Yup from 'yup';
import * as Api from '../../api/models';
import Constants from '../../constants';
import CountryRegionMapper from './countryRegionMapper';
import CountryRegionViewModel from './countryRegionViewModel';

interface Props {
  model?: CountryRegionViewModel;
}

const CountryRegionCreateDisplay: React.SFC<
  FormikProps<CountryRegionViewModel>
> = (props: FormikProps<CountryRegionViewModel>) => {
  let status = props.status as CreateResponse<
    Api.CountryRegionClientRequestModel
  >;

  let errorsForField = (name: string): string => {
    let response = '';
    if (
      props.touched[name as keyof CountryRegionViewModel] &&
      props.errors[name as keyof CountryRegionViewModel]
    ) {
      response += props.errors[name as keyof CountryRegionViewModel];
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

const CountryRegionCreate = withFormik<Props, CountryRegionViewModel>({
  mapPropsToValues: props => {
    let response = new CountryRegionViewModel();
    if (props.model != undefined) {
      response.setProperties(
        props.model!.countryRegionCode,
        props.model!.modifiedDate,
        props.model!.name
      );
    }
    return response;
  },

  validate: values => {
    let errors: FormikErrors<CountryRegionViewModel> = {};

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
    let mapper = new CountryRegionMapper();

    axios
      .post(
        Constants.ApiUrl + 'countryregions',
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
            Api.CountryRegionClientRequestModel
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
  displayName: 'CountryRegionCreate',
})(CountryRegionCreateDisplay);

interface CountryRegionCreateComponentProps {}

interface CountryRegionCreateComponentState {
  model?: CountryRegionViewModel;
  loading: boolean;
  loaded: boolean;
  errorOccurred: boolean;
  errorMessage: string;
}

export default class CountryRegionCreateComponent extends React.Component<
  CountryRegionCreateComponentProps,
  CountryRegionCreateComponentState
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
      return <CountryRegionCreate model={this.state.model} />;
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
    <Hash>f048841205cd6692a0957cdcfd423b03</Hash>
</Codenesium>*/