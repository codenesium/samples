import React, { Component } from 'react';
import axios from 'axios';
import { CreateResponse } from '../../api/apiObjects';
import { FormikProps, FormikErrors, Field, withFormik } from 'formik';
import * as Yup from 'yup';
import { LoadingForm } from '../../lib/components/loadingForm';
import { ErrorForm } from '../../lib/components/errorForm';
import * as Api from '../../api/models';
import { Constants, ApiRoutes, ClientRoutes } from '../../constants';
import DestinationMapper from './destinationMapper';
import DestinationViewModel from './destinationViewModel';

interface Props {
  model?: DestinationViewModel;
}

const DestinationCreateDisplay: React.SFC<FormikProps<DestinationViewModel>> = (
  props: FormikProps<DestinationViewModel>
) => {
  let status = props.status as CreateResponse<
    Api.DestinationClientRequestModel
  >;

  let errorsForField = (name: string): string => {
    let response = '';
    if (
      props.touched[name as keyof DestinationViewModel] &&
      props.errors[name as keyof DestinationViewModel]
    ) {
      response += props.errors[name as keyof DestinationViewModel];
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

      <div className="form-group row">
        <label
          htmlFor="name"
          className={
            errorExistForField('order')
              ? 'col-sm-2 col-form-label is-invalid'
              : 'col-sm-2 col-form-label'
          }
        >
          Order
        </label>
        <div className="col-sm-12">
          <Field
            type="datetime-local"
            name="order"
            className={
              errorExistForField('order')
                ? 'form-control is-invalid'
                : 'form-control'
            }
          />
          {errorExistForField('order') && (
            <small className="text-danger">{errorsForField('order')}</small>
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

const DestinationCreate = withFormik<Props, DestinationViewModel>({
  mapPropsToValues: props => {
    let response = new DestinationViewModel();
    if (props.model != undefined) {
      response.setProperties(
        props.model!.countryId,
        props.model!.id,
        props.model!.name,
        props.model!.order
      );
    }
    return response;
  },

  validate: values => {
    let errors: FormikErrors<DestinationViewModel> = {};

    if (values.countryId == 0) {
      errors.countryId = 'Required';
    }
    if (values.name == '') {
      errors.name = 'Required';
    }
    if (values.order == 0) {
      errors.order = 'Required';
    }

    return errors;
  },

  handleSubmit: (values, actions) => {
    actions.setStatus(undefined);
    let mapper = new DestinationMapper();

    axios
      .post(
        Constants.ApiEndpoint + ApiRoutes.Destinations,
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
            Api.DestinationClientRequestModel
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
  displayName: 'DestinationCreate',
})(DestinationCreateDisplay);

interface DestinationCreateComponentProps {}

interface DestinationCreateComponentState {
  model?: DestinationViewModel;
  loading: boolean;
  loaded: boolean;
  errorOccurred: boolean;
  errorMessage: string;
}

export default class DestinationCreateComponent extends React.Component<
  DestinationCreateComponentProps,
  DestinationCreateComponentState
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
      return <DestinationCreate model={this.state.model} />;
    } else {
      return null;
    }
  }
}


/*<Codenesium>
    <Hash>adab577dbeef75c7b9079b590406d972</Hash>
</Codenesium>*/