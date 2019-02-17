import React, { Component } from 'react';
import axios from 'axios';
import { CreateResponse } from '../../api/apiObjects';
import { FormikProps, FormikErrors, Field, withFormik } from 'formik';
import * as Yup from 'yup';
import { LoadingForm } from '../../lib/components/loadingForm';
import { ErrorForm } from '../../lib/components/errorForm';
import * as Api from '../../api/models';
import { Constants, ApiRoutes, ClientRoutes } from '../../constants';
import BadgeMapper from './badgeMapper';
import BadgeViewModel from './badgeViewModel';

interface Props {
  model?: BadgeViewModel;
}

const BadgeCreateDisplay: React.SFC<FormikProps<BadgeViewModel>> = (
  props: FormikProps<BadgeViewModel>
) => {
  let status = props.status as CreateResponse<Api.BadgeClientRequestModel>;

  let errorsForField = (name: string): string => {
    let response = '';
    if (
      props.touched[name as keyof BadgeViewModel] &&
      props.errors[name as keyof BadgeViewModel]
    ) {
      response += props.errors[name as keyof BadgeViewModel];
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
            errorExistForField('date')
              ? 'col-sm-2 col-form-label is-invalid'
              : 'col-sm-2 col-form-label'
          }
        >
          Date
        </label>
        <div className="col-sm-12">
          <Field
            type="textbox"
            name="date"
            className={
              errorExistForField('date')
                ? 'form-control is-invalid'
                : 'form-control'
            }
          />
          {errorExistForField('date') && (
            <small className="text-danger">{errorsForField('date')}</small>
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
            errorExistForField('userId')
              ? 'col-sm-2 col-form-label is-invalid'
              : 'col-sm-2 col-form-label'
          }
        >
          UserId
        </label>
        <div className="col-sm-12">
          <Field
            type="textbox"
            name="userId"
            className={
              errorExistForField('userId')
                ? 'form-control is-invalid'
                : 'form-control'
            }
          />
          {errorExistForField('userId') && (
            <small className="text-danger">{errorsForField('userId')}</small>
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

const BadgeCreate = withFormik<Props, BadgeViewModel>({
  mapPropsToValues: props => {
    let response = new BadgeViewModel();
    if (props.model != undefined) {
      response.setProperties(
        props.model!.date,
        props.model!.id,
        props.model!.name,
        props.model!.userId
      );
    }
    return response;
  },

  validate: values => {
    let errors: FormikErrors<BadgeViewModel> = {};

    if (values.date == undefined) {
      errors.date = 'Required';
    }
    if (values.name == '') {
      errors.name = 'Required';
    }
    if (values.userId == 0) {
      errors.userId = 'Required';
    }

    return errors;
  },

  handleSubmit: (values, actions) => {
    actions.setStatus(undefined);
    let mapper = new BadgeMapper();

    axios
      .post(
        Constants.ApiEndpoint + ApiRoutes.Badges,
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
            Api.BadgeClientRequestModel
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
  displayName: 'BadgeCreate',
})(BadgeCreateDisplay);

interface BadgeCreateComponentProps {}

interface BadgeCreateComponentState {
  model?: BadgeViewModel;
  loading: boolean;
  loaded: boolean;
  errorOccurred: boolean;
  errorMessage: string;
}

export default class BadgeCreateComponent extends React.Component<
  BadgeCreateComponentProps,
  BadgeCreateComponentState
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
      return <BadgeCreate model={this.state.model} />;
    } else {
      return null;
    }
  }
}


/*<Codenesium>
    <Hash>68366688286071807a7cd8e549ef74be</Hash>
</Codenesium>*/