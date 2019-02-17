import React, { Component } from 'react';
import axios from 'axios';
import * as Api from '../../api/models';
import { UpdateResponse } from '../../api/apiObjects';
import { Constants, ApiRoutes, ClientRoutes } from '../../constants';
import { FormikProps, FormikErrors, Field, withFormik } from 'formik';
import { LoadingForm } from '../../lib/components/loadingForm';
import { ErrorForm } from '../../lib/components/errorForm';
import TweetViewModel from './tweetViewModel';
import TweetMapper from './tweetMapper';

interface Props {
  model?: TweetViewModel;
}

const TweetEditDisplay = (props: FormikProps<TweetViewModel>) => {
  let status = props.status as UpdateResponse<Api.TweetClientRequestModel>;

  let errorsForField = (name: string): string => {
    let response = '';
    if (
      props.touched[name as keyof TweetViewModel] &&
      props.errors[name as keyof TweetViewModel]
    ) {
      response += props.errors[name as keyof TweetViewModel];
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
            errorExistForField('locationId')
              ? 'col-sm-2 col-form-label is-invalid'
              : 'col-sm-2 col-form-label'
          }
        >
          Location_id
        </label>
        <div className="col-sm-12">
          <Field
            type="textbox"
            name="locationId"
            className={
              errorExistForField('locationId')
                ? 'form-control is-invalid'
                : 'form-control'
            }
          />
          {errorExistForField('locationId') && (
            <small className="text-danger">
              {errorsForField('locationId')}
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
            errorExistForField('userUserId')
              ? 'col-sm-2 col-form-label is-invalid'
              : 'col-sm-2 col-form-label'
          }
        >
          User_user_id
        </label>
        <div className="col-sm-12">
          <Field
            type="textbox"
            name="userUserId"
            className={
              errorExistForField('userUserId')
                ? 'form-control is-invalid'
                : 'form-control'
            }
          />
          {errorExistForField('userUserId') && (
            <small className="text-danger">
              {errorsForField('userUserId')}
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

const TweetEdit = withFormik<Props, TweetViewModel>({
  mapPropsToValues: props => {
    let response = new TweetViewModel();
    response.setProperties(
      props.model!.content,
      props.model!.date,
      props.model!.locationId,
      props.model!.time,
      props.model!.tweetId,
      props.model!.userUserId
    );
    return response;
  },

  // Custom sync validation
  validate: values => {
    let errors: FormikErrors<TweetViewModel> = {};

    if (values.content == '') {
      errors.content = 'Required';
    }
    if (values.date == undefined) {
      errors.date = 'Required';
    }
    if (values.locationId == 0) {
      errors.locationId = 'Required';
    }
    if (values.time == undefined) {
      errors.time = 'Required';
    }
    if (values.tweetId == 0) {
      errors.tweetId = 'Required';
    }
    if (values.userUserId == 0) {
      errors.userUserId = 'Required';
    }

    return errors;
  },
  handleSubmit: (values, actions) => {
    actions.setStatus(undefined);

    let mapper = new TweetMapper();

    axios
      .put(
        Constants.ApiEndpoint + ApiRoutes.Tweets + '/' + values.tweetId,

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
            Api.TweetClientRequestModel
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

  displayName: 'TweetEdit',
})(TweetEditDisplay);

interface IParams {
  tweetId: number;
}

interface IMatch {
  params: IParams;
}

interface TweetEditComponentProps {
  match: IMatch;
}

interface TweetEditComponentState {
  model?: TweetViewModel;
  loading: boolean;
  loaded: boolean;
  errorOccurred: boolean;
  errorMessage: string;
}

export default class TweetEditComponent extends React.Component<
  TweetEditComponentProps,
  TweetEditComponentState
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
          ApiRoutes.Tweets +
          '/' +
          this.props.match.params.tweetId,
        {
          headers: {
            'Content-Type': 'application/json',
          },
        }
      )
      .then(
        resp => {
          let response = resp.data as Api.TweetClientResponseModel;

          console.log(response);

          let mapper = new TweetMapper();

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
      return <TweetEdit model={this.state.model} />;
    } else {
      return null;
    }
  }
}


/*<Codenesium>
    <Hash>5574de56966743f02ffd99dae1ff9d6f</Hash>
</Codenesium>*/