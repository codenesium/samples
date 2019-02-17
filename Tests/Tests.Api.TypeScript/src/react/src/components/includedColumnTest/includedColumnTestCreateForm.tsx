import React, { Component } from 'react';
import axios from 'axios';
import { CreateResponse } from '../../api/apiObjects';
import { FormikProps, FormikErrors, Field, withFormik } from 'formik';
import * as Yup from 'yup';
import { LoadingForm } from '../../lib/components/loadingForm';
import { ErrorForm } from '../../lib/components/errorForm';
import * as Api from '../../api/models';
import { Constants, ApiRoutes, ClientRoutes } from '../../constants';
import IncludedColumnTestMapper from './includedColumnTestMapper';
import IncludedColumnTestViewModel from './includedColumnTestViewModel';

interface Props {
  model?: IncludedColumnTestViewModel;
}

const IncludedColumnTestCreateDisplay: React.SFC<
  FormikProps<IncludedColumnTestViewModel>
> = (props: FormikProps<IncludedColumnTestViewModel>) => {
  let status = props.status as CreateResponse<
    Api.IncludedColumnTestClientRequestModel
  >;

  let errorsForField = (name: string): string => {
    let response = '';
    if (
      props.touched[name as keyof IncludedColumnTestViewModel] &&
      props.errors[name as keyof IncludedColumnTestViewModel]
    ) {
      response += props.errors[name as keyof IncludedColumnTestViewModel];
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
            type="textbox"
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
            errorExistForField('name2')
              ? 'col-sm-2 col-form-label is-invalid'
              : 'col-sm-2 col-form-label'
          }
        >
          Name2
        </label>
        <div className="col-sm-12">
          <Field
            type="textbox"
            name="name2"
            className={
              errorExistForField('name2')
                ? 'form-control is-invalid'
                : 'form-control'
            }
          />
          {errorExistForField('name2') && (
            <small className="text-danger">{errorsForField('name2')}</small>
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

const IncludedColumnTestCreate = withFormik<Props, IncludedColumnTestViewModel>(
  {
    mapPropsToValues: props => {
      let response = new IncludedColumnTestViewModel();
      if (props.model != undefined) {
        response.setProperties(
          props.model!.id,
          props.model!.name,
          props.model!.name2
        );
      }
      return response;
    },

    validate: values => {
      let errors: FormikErrors<IncludedColumnTestViewModel> = {};

      if (values.name == '') {
        errors.name = 'Required';
      }
      if (values.name2 == '') {
        errors.name2 = 'Required';
      }

      return errors;
    },

    handleSubmit: (values, actions) => {
      actions.setStatus(undefined);
      let mapper = new IncludedColumnTestMapper();

      axios
        .post(
          Constants.ApiEndpoint + ApiRoutes.IncludedColumnTests,
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
              Api.IncludedColumnTestClientRequestModel
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
    displayName: 'IncludedColumnTestCreate',
  }
)(IncludedColumnTestCreateDisplay);

interface IncludedColumnTestCreateComponentProps {}

interface IncludedColumnTestCreateComponentState {
  model?: IncludedColumnTestViewModel;
  loading: boolean;
  loaded: boolean;
  errorOccurred: boolean;
  errorMessage: string;
}

export default class IncludedColumnTestCreateComponent extends React.Component<
  IncludedColumnTestCreateComponentProps,
  IncludedColumnTestCreateComponentState
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
      return <IncludedColumnTestCreate model={this.state.model} />;
    } else {
      return null;
    }
  }
}


/*<Codenesium>
    <Hash>ef90e9809f02bf43bd8b4d596d704df6</Hash>
</Codenesium>*/