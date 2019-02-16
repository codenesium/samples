import React, { Component } from 'react';
import axios from 'axios';
import { CreateResponse } from '../../api/ApiObjects';
import { FormikProps, FormikErrors, Field, withFormik } from 'formik';
import * as Yup from 'yup';
import { LoadingForm } from '../../lib/components/loadingForm';
import { ErrorForm } from '../../lib/components/errorForm';
import * as Api from '../../api/models';
import { Constants, ApiRoutes, ClientRoutes } from '../../constants';
import QuoteTweetMapper from './quoteTweetMapper';
import QuoteTweetViewModel from './quoteTweetViewModel';

interface Props {
  model?: QuoteTweetViewModel;
}

const QuoteTweetCreateDisplay: React.SFC<FormikProps<QuoteTweetViewModel>> = (
  props: FormikProps<QuoteTweetViewModel>
) => {
  let status = props.status as CreateResponse<Api.QuoteTweetClientRequestModel>;

  let errorsForField = (name: string): string => {
    let response = '';
    if (
      props.touched[name as keyof QuoteTweetViewModel] &&
      props.errors[name as keyof QuoteTweetViewModel]
    ) {
      response += props.errors[name as keyof QuoteTweetViewModel];
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
            errorExistForField('content')
              ? 'col-sm-2 col-form-label is-invalid'
              : 'col-sm-2 col-form-label'
          }
        >
          Content
        </label>
        <div className="col-sm-12">
          <Field
            type="textbox"
            name="content"
            className={
              errorExistForField('content')
                ? 'form-control is-invalid'
                : 'form-control'
            }
          />
          {errorExistForField('content') && (
            <small className="text-danger">{errorsForField('content')}</small>
          )}
        </div>
      </div>

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
            errorExistForField('retweeterUserId')
              ? 'col-sm-2 col-form-label is-invalid'
              : 'col-sm-2 col-form-label'
          }
        >
          Retweeter_user_id
        </label>
        <div className="col-sm-12">
          <Field
            type="textbox"
            name="retweeterUserId"
            className={
              errorExistForField('retweeterUserId')
                ? 'form-control is-invalid'
                : 'form-control'
            }
          />
          {errorExistForField('retweeterUserId') && (
            <small className="text-danger">
              {errorsForField('retweeterUserId')}
            </small>
          )}
        </div>
      </div>

      <div className="form-group row">
        <label
          htmlFor="name"
          className={
            errorExistForField('sourceTweetId')
              ? 'col-sm-2 col-form-label is-invalid'
              : 'col-sm-2 col-form-label'
          }
        >
          Source_tweet_id
        </label>
        <div className="col-sm-12">
          <Field
            type="textbox"
            name="sourceTweetId"
            className={
              errorExistForField('sourceTweetId')
                ? 'form-control is-invalid'
                : 'form-control'
            }
          />
          {errorExistForField('sourceTweetId') && (
            <small className="text-danger">
              {errorsForField('sourceTweetId')}
            </small>
          )}
        </div>
      </div>

      <div className="form-group row">
        <label
          htmlFor="name"
          className={
            errorExistForField('time')
              ? 'col-sm-2 col-form-label is-invalid'
              : 'col-sm-2 col-form-label'
          }
        >
          Time
        </label>
        <div className="col-sm-12">
          <Field
            type="textbox"
            name="time"
            className={
              errorExistForField('time')
                ? 'form-control is-invalid'
                : 'form-control'
            }
          />
          {errorExistForField('time') && (
            <small className="text-danger">{errorsForField('time')}</small>
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

const QuoteTweetCreate = withFormik<Props, QuoteTweetViewModel>({
  mapPropsToValues: props => {
    let response = new QuoteTweetViewModel();
    if (props.model != undefined) {
      response.setProperties(
        props.model!.content,
        props.model!.date,
        props.model!.quoteTweetId,
        props.model!.retweeterUserId,
        props.model!.sourceTweetId,
        props.model!.time
      );
    }
    return response;
  },

  validate: values => {
    let errors: FormikErrors<QuoteTweetViewModel> = {};

    if (values.content == '') {
      errors.content = 'Required';
    }
    if (values.date == undefined) {
      errors.date = 'Required';
    }
    if (values.retweeterUserId == 0) {
      errors.retweeterUserId = 'Required';
    }
    if (values.sourceTweetId == 0) {
      errors.sourceTweetId = 'Required';
    }
    if (values.time == undefined) {
      errors.time = 'Required';
    }

    return errors;
  },

  handleSubmit: (values, actions) => {
    actions.setStatus(undefined);
    let mapper = new QuoteTweetMapper();

    axios
      .post(
        Constants.ApiEndpoint + ApiRoutes.QuoteTweets,
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
            Api.QuoteTweetClientRequestModel
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
  displayName: 'QuoteTweetCreate',
})(QuoteTweetCreateDisplay);

interface QuoteTweetCreateComponentProps {}

interface QuoteTweetCreateComponentState {
  model?: QuoteTweetViewModel;
  loading: boolean;
  loaded: boolean;
  errorOccurred: boolean;
  errorMessage: string;
}

export default class QuoteTweetCreateComponent extends React.Component<
  QuoteTweetCreateComponentProps,
  QuoteTweetCreateComponentState
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
      return <QuoteTweetCreate model={this.state.model} />;
    } else {
      return null;
    }
  }
}


/*<Codenesium>
    <Hash>0e71a2da3de59eed1a57703e6b136060</Hash>
</Codenesium>*/