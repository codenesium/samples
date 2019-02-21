import React, { Component } from 'react';
import axios from 'axios';
import { CreateResponse } from '../../api/apiObjects';
import { FormikProps, FormikErrors, Field, withFormik } from 'formik';
import * as Yup from 'yup';
import { LoadingForm } from '../../lib/components/loadingForm';
import { ErrorForm } from '../../lib/components/errorForm';
import * as Api from '../../api/models';
import { Constants, ApiRoutes, ClientRoutes } from '../../constants';
import TeamMapper from './teamMapper';
import TeamViewModel from './teamViewModel';

interface Props {
  model?: TeamViewModel;
}

const TeamCreateDisplay: React.SFC<FormikProps<TeamViewModel>> = (
  props: FormikProps<TeamViewModel>
) => {
  let status = props.status as CreateResponse<Api.TeamClientRequestModel>;

  let errorsForField = (name: string): string => {
    let response = '';
    if (
      props.touched[name as keyof TeamViewModel] &&
      props.errors[name as keyof TeamViewModel]
    ) {
      response += props.errors[name as keyof TeamViewModel];
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
            errorExistForField('organizationId')
              ? 'col-sm-2 col-form-label is-invalid'
              : 'col-sm-2 col-form-label'
          }
        >
          OrganizationId
        </label>
        <div className="col-sm-12">
          <Field
            type="textbox"
            name="organizationId"
            className={
              errorExistForField('organizationId')
                ? 'form-control is-invalid'
                : 'form-control'
            }
          />
          {errorExistForField('organizationId') && (
            <small className="text-danger">
              {errorsForField('organizationId')}
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

const TeamCreate = withFormik<Props, TeamViewModel>({
  mapPropsToValues: props => {
    let response = new TeamViewModel();
    if (props.model != undefined) {
      response.setProperties(
        props.model!.id,
        props.model!.name,
        props.model!.organizationId
      );
    }
    return response;
  },

  validate: values => {
    let errors: FormikErrors<TeamViewModel> = {};

    if (values.name == '') {
      errors.name = 'Required';
    }
    if (values.organizationId == 0) {
      errors.organizationId = 'Required';
    }

    return errors;
  },

  handleSubmit: (values, actions) => {
    actions.setStatus(undefined);
    let mapper = new TeamMapper();

    axios
      .post(
        Constants.ApiEndpoint + ApiRoutes.Teams,
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
            Api.TeamClientRequestModel
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
  displayName: 'TeamCreate',
})(TeamCreateDisplay);

interface TeamCreateComponentProps {}

interface TeamCreateComponentState {
  model?: TeamViewModel;
  loading: boolean;
  loaded: boolean;
  errorOccurred: boolean;
  errorMessage: string;
}

export default class TeamCreateComponent extends React.Component<
  TeamCreateComponentProps,
  TeamCreateComponentState
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
      return <TeamCreate model={this.state.model} />;
    } else {
      return null;
    }
  }
}


/*<Codenesium>
    <Hash>b91826d78a8762014b66adbb5b287cc0</Hash>
</Codenesium>*/