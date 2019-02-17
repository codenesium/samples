import React, { Component } from 'react';
import axios from 'axios';
import { CreateResponse } from '../../api/apiObjects';
import { FormikProps, FormikErrors, Field, withFormik } from 'formik';
import * as Yup from 'yup';
import { LoadingForm } from '../../lib/components/loadingForm';
import { ErrorForm } from '../../lib/components/errorForm';
import * as Api from '../../api/models';
import { Constants, ApiRoutes, ClientRoutes } from '../../constants';
import RetweetMapper from './retweetMapper';
import RetweetViewModel from './retweetViewModel';

interface Props {
  model?: RetweetViewModel;
}

const RetweetCreateDisplay: React.SFC<FormikProps<RetweetViewModel>> = (
  props: FormikProps<RetweetViewModel>
) => {
  let status = props.status as CreateResponse<Api.RetweetClientRequestModel>;

  let errorsForField = (name: string): string => {
    let response = '';
    if (
      props.touched[name as keyof RetweetViewModel] &&
      props.errors[name as keyof RetweetViewModel]
    ) {
      response += props.errors[name as keyof RetweetViewModel];
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
            errorExistForField('retwitterUserId')
              ? 'col-sm-2 col-form-label is-invalid'
              : 'col-sm-2 col-form-label'
          }
        >
          Retwitter_user_id
        </label>
        <div className="col-sm-12">
          <Field
            type="textbox"
            name="retwitterUserId"
            className={
              errorExistForField('retwitterUserId')
                ? 'form-control is-invalid'
                : 'form-control'
            }
          />
          {errorExistForField('retwitterUserId') && (
            <small className="text-danger">
              {errorsForField('retwitterUserId')}
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

      <div className="form-group row">
        <label
          htmlFor="name"
          className={
            errorExistForField('tweetTweetId')
              ? 'col-sm-2 col-form-label is-invalid'
              : 'col-sm-2 col-form-label'
          }
        >
          Tweet_tweet_id
        </label>
        <div className="col-sm-12">
          <Field
            type="textbox"
            name="tweetTweetId"
            className={
              errorExistForField('tweetTweetId')
                ? 'form-control is-invalid'
                : 'form-control'
            }
          />
          {errorExistForField('tweetTweetId') && (
            <small className="text-danger">
              {errorsForField('tweetTweetId')}
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

const RetweetCreate = withFormik<Props, RetweetViewModel>({
  mapPropsToValues: props => {
    let response = new RetweetViewModel();
    if (props.model != undefined) {
      response.setProperties(
        props.model!.date,
        props.model!.id,
        props.model!.retwitterUserId,
        props.model!.time,
        props.model!.tweetTweetId
      );
    }
    return response;
  },

  validate: values => {
    let errors: FormikErrors<RetweetViewModel> = {};

    if (values.tweetTweetId == 0) {
      errors.tweetTweetId = 'Required';
    }

    return errors;
  },

  handleSubmit: (values, actions) => {
    actions.setStatus(undefined);
    let mapper = new RetweetMapper();

    axios
      .post(
        Constants.ApiEndpoint + ApiRoutes.Retweets,
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
            Api.RetweetClientRequestModel
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
  displayName: 'RetweetCreate',
})(RetweetCreateDisplay);

interface RetweetCreateComponentProps {}

interface RetweetCreateComponentState {
  model?: RetweetViewModel;
  loading: boolean;
  loaded: boolean;
  errorOccurred: boolean;
  errorMessage: string;
}

export default class RetweetCreateComponent extends React.Component<
  RetweetCreateComponentProps,
  RetweetCreateComponentState
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
      return <RetweetCreate model={this.state.model} />;
    } else {
      return null;
    }
  }
}


/*<Codenesium>
    <Hash>9c8440dbc2fc8149e4f52f73a2fd4b0b</Hash>
</Codenesium>*/