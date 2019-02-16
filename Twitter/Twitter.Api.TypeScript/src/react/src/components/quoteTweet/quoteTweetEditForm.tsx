import React, { Component } from 'react';
import axios from 'axios';
import * as Api from '../../api/models';
import { UpdateResponse } from '../../api/ApiObjects';
import { Constants, ApiRoutes, ClientRoutes } from '../../constants';
import { FormikProps, FormikErrors, Field, withFormik } from 'formik';
import { LoadingForm } from '../../lib/components/loadingForm';
import { ErrorForm } from '../../lib/components/errorForm';
import QuoteTweetViewModel from './quoteTweetViewModel';
import QuoteTweetMapper from './quoteTweetMapper';

interface Props {
  model?: QuoteTweetViewModel;
}

const QuoteTweetEditDisplay = (props: FormikProps<QuoteTweetViewModel>) => {
  let status = props.status as UpdateResponse<Api.QuoteTweetClientRequestModel>;

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

const QuoteTweetEdit = withFormik<Props, QuoteTweetViewModel>({
  mapPropsToValues: props => {
    let response = new QuoteTweetViewModel();
    response.setProperties(
      props.model!.content,
      props.model!.date,
      props.model!.quoteTweetId,
      props.model!.retweeterUserId,
      props.model!.sourceTweetId,
      props.model!.time
    );
    return response;
  },

  // Custom sync validation
  validate: values => {
    let errors: FormikErrors<QuoteTweetViewModel> = {};

    if (values.content == '') {
      errors.content = 'Required';
    }
    if (values.date == undefined) {
      errors.date = 'Required';
    }
    if (values.quoteTweetId == 0) {
      errors.quoteTweetId = 'Required';
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
      .put(
        Constants.ApiEndpoint +
          ApiRoutes.QuoteTweets +
          '/' +
          values.quoteTweetId,

        mapper.mapViewModelToApiRequest(values),
        {
          headers: {
            'Content-Type': 'application/json',
          },
        }
      )
      .then(
        resp => {
          let response = resp.data as UpdateResponse<
            Api.QuoteTweetClientRequestModel
          >;
          actions.setStatus(response);
          console.log(response);
        },
        error => {
          console.log(error);
          actions.setStatus('Error from API');
        }
      )
      .then(response => {
        // cleanup
      });
  },

  displayName: 'QuoteTweetEdit',
})(QuoteTweetEditDisplay);

interface IParams {
  quoteTweetId: number;
}

interface IMatch {
  params: IParams;
}

interface QuoteTweetEditComponentProps {
  match: IMatch;
}

interface QuoteTweetEditComponentState {
  model?: QuoteTweetViewModel;
  loading: boolean;
  loaded: boolean;
  errorOccurred: boolean;
  errorMessage: string;
}

export default class QuoteTweetEditComponent extends React.Component<
  QuoteTweetEditComponentProps,
  QuoteTweetEditComponentState
> {
  state = {
    model: undefined,
    loading: false,
    loaded: false,
    errorOccurred: false,
    errorMessage: '',
  };

  componentDidMount() {
    this.setState({ ...this.state, loading: true });

    axios
      .get(
        Constants.ApiEndpoint +
          ApiRoutes.QuoteTweets +
          '/' +
          this.props.match.params.quoteTweetId,
        {
          headers: {
            'Content-Type': 'application/json',
          },
        }
      )
      .then(
        resp => {
          let response = resp.data as Api.QuoteTweetClientResponseModel;

          console.log(response);

          let mapper = new QuoteTweetMapper();

          this.setState({
            model: mapper.mapApiResponseToViewModel(response),
            loading: false,
            loaded: true,
            errorOccurred: false,
            errorMessage: '',
          });
        },
        error => {
          console.log(error);
          this.setState({
            model: undefined,
            loading: false,
            loaded: false,
            errorOccurred: true,
            errorMessage: 'Error from API',
          });
        }
      );
  }
  render() {
    if (this.state.loading) {
      return <LoadingForm />;
    } else if (this.state.errorOccurred) {
      return <ErrorForm message={this.state.errorMessage} />;
    } else if (this.state.loaded) {
      return <QuoteTweetEdit model={this.state.model} />;
    } else {
      return null;
    }
  }
}


/*<Codenesium>
    <Hash>8b71caaa2596b46aa1ec24c114d73817</Hash>
</Codenesium>*/