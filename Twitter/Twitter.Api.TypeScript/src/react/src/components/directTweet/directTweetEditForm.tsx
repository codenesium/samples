import React, { Component } from 'react';
import axios from 'axios';
import * as Api from '../../api/models';
import { UpdateResponse } from '../../api/ApiObjects';
import { Constants, ApiRoutes, ClientRoutes } from '../../constants';
import { FormikProps, FormikErrors, Field, withFormik } from 'formik';
import { LoadingForm } from '../../lib/components/loadingForm';
import { ErrorForm } from '../../lib/components/errorForm';
import DirectTweetViewModel from './directTweetViewModel';
import DirectTweetMapper from './directTweetMapper';

interface Props {
  model?: DirectTweetViewModel;
}

const DirectTweetEditDisplay = (props: FormikProps<DirectTweetViewModel>) => {
  let status = props.status as UpdateResponse<
    Api.DirectTweetClientRequestModel
  >;

  let errorsForField = (name: string): string => {
    let response = '';
    if (
      props.touched[name as keyof DirectTweetViewModel] &&
      props.errors[name as keyof DirectTweetViewModel]
    ) {
      response += props.errors[name as keyof DirectTweetViewModel];
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
            errorExistForField('taggedUserId')
              ? 'col-sm-2 col-form-label is-invalid'
              : 'col-sm-2 col-form-label'
          }
        >
          Tagged_user_id
        </label>
        <div className="col-sm-12">
          <Field
            type="textbox"
            name="taggedUserId"
            className={
              errorExistForField('taggedUserId')
                ? 'form-control is-invalid'
                : 'form-control'
            }
          />
          {errorExistForField('taggedUserId') && (
            <small className="text-danger">
              {errorsForField('taggedUserId')}
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

const DirectTweetEdit = withFormik<Props, DirectTweetViewModel>({
  mapPropsToValues: props => {
    let response = new DirectTweetViewModel();
    response.setProperties(
      props.model!.content,
      props.model!.date,
      props.model!.taggedUserId,
      props.model!.time,
      props.model!.tweetId
    );
    return response;
  },

  // Custom sync validation
  validate: values => {
    let errors: FormikErrors<DirectTweetViewModel> = {};

    if (values.content == '') {
      errors.content = 'Required';
    }
    if (values.date == undefined) {
      errors.date = 'Required';
    }
    if (values.taggedUserId == 0) {
      errors.taggedUserId = 'Required';
    }
    if (values.time == undefined) {
      errors.time = 'Required';
    }
    if (values.tweetId == 0) {
      errors.tweetId = 'Required';
    }

    return errors;
  },
  handleSubmit: (values, actions) => {
    actions.setStatus(undefined);

    let mapper = new DirectTweetMapper();

    axios
      .put(
        Constants.ApiEndpoint + ApiRoutes.DirectTweets + '/' + values.tweetId,

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
            Api.DirectTweetClientRequestModel
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

  displayName: 'DirectTweetEdit',
})(DirectTweetEditDisplay);

interface IParams {
  tweetId: number;
}

interface IMatch {
  params: IParams;
}

interface DirectTweetEditComponentProps {
  match: IMatch;
}

interface DirectTweetEditComponentState {
  model?: DirectTweetViewModel;
  loading: boolean;
  loaded: boolean;
  errorOccurred: boolean;
  errorMessage: string;
}

export default class DirectTweetEditComponent extends React.Component<
  DirectTweetEditComponentProps,
  DirectTweetEditComponentState
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
          ApiRoutes.DirectTweets +
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
          let response = resp.data as Api.DirectTweetClientResponseModel;

          console.log(response);

          let mapper = new DirectTweetMapper();

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
      return <DirectTweetEdit model={this.state.model} />;
    } else {
      return null;
    }
  }
}


/*<Codenesium>
    <Hash>280c52fe8b1b736e8973122df4d990dc</Hash>
</Codenesium>*/