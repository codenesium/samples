import React, { Component } from 'react';
import axios from 'axios';
import * as Api from '../../api/models';
import { UpdateResponse } from '../../api/ApiObjects';
import { Constants, ApiRoutes, ClientRoutes } from '../../constants';
import { FormikProps, FormikErrors, Field, withFormik } from 'formik';
import { LoadingForm } from '../../lib/components/loadingForm';
import { ErrorForm } from '../../lib/components/errorForm';
import FollowingViewModel from './followingViewModel';
import FollowingMapper from './followingMapper';

interface Props {
  model?: FollowingViewModel;
}

const FollowingEditDisplay = (props: FormikProps<FollowingViewModel>) => {
  let status = props.status as UpdateResponse<Api.FollowingClientRequestModel>;

  let errorsForField = (name: string): string => {
    let response = '';
    if (
      props.touched[name as keyof FollowingViewModel] &&
      props.errors[name as keyof FollowingViewModel]
    ) {
      response += props.errors[name as keyof FollowingViewModel];
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
            errorExistForField('dateFollowed')
              ? 'col-sm-2 col-form-label is-invalid'
              : 'col-sm-2 col-form-label'
          }
        >
          Date_followed
        </label>
        <div className="col-sm-12">
          <Field
            type="textbox"
            name="dateFollowed"
            className={
              errorExistForField('dateFollowed')
                ? 'form-control is-invalid'
                : 'form-control'
            }
          />
          {errorExistForField('dateFollowed') && (
            <small className="text-danger">
              {errorsForField('dateFollowed')}
            </small>
          )}
        </div>
      </div>
      <div className="form-group row">
        <label
          htmlFor="name"
          className={
            errorExistForField('muted')
              ? 'col-sm-2 col-form-label is-invalid'
              : 'col-sm-2 col-form-label'
          }
        >
          Muted
        </label>
        <div className="col-sm-12">
          <Field
            type="textbox"
            name="muted"
            className={
              errorExistForField('muted')
                ? 'form-control is-invalid'
                : 'form-control'
            }
          />
          {errorExistForField('muted') && (
            <small className="text-danger">{errorsForField('muted')}</small>
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

const FollowingEdit = withFormik<Props, FollowingViewModel>({
  mapPropsToValues: props => {
    let response = new FollowingViewModel();
    response.setProperties(
      props.model!.dateFollowed,
      props.model!.muted,
      props.model!.userId
    );
    return response;
  },

  // Custom sync validation
  validate: values => {
    let errors: FormikErrors<FollowingViewModel> = {};

    if (values.userId == 0) {
      errors.userId = 'Required';
    }

    return errors;
  },
  handleSubmit: (values, actions) => {
    actions.setStatus(undefined);

    let mapper = new FollowingMapper();

    axios
      .put(
        Constants.ApiEndpoint + ApiRoutes.Followings + '/' + values.userId,

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
            Api.FollowingClientRequestModel
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

  displayName: 'FollowingEdit',
})(FollowingEditDisplay);

interface IParams {
  userId: number;
}

interface IMatch {
  params: IParams;
}

interface FollowingEditComponentProps {
  match: IMatch;
}

interface FollowingEditComponentState {
  model?: FollowingViewModel;
  loading: boolean;
  loaded: boolean;
  errorOccurred: boolean;
  errorMessage: string;
}

export default class FollowingEditComponent extends React.Component<
  FollowingEditComponentProps,
  FollowingEditComponentState
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
          ApiRoutes.Followings +
          '/' +
          this.props.match.params.userId,
        {
          headers: {
            'Content-Type': 'application/json',
          },
        }
      )
      .then(
        resp => {
          let response = resp.data as Api.FollowingClientResponseModel;

          console.log(response);

          let mapper = new FollowingMapper();

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
      return <FollowingEdit model={this.state.model} />;
    } else {
      return null;
    }
  }
}


/*<Codenesium>
    <Hash>fc03bc5a8e1e8a5fba4b7c594e155b2b</Hash>
</Codenesium>*/