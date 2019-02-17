import React, { Component } from 'react';
import axios from 'axios';
import { CreateResponse } from '../../api/apiObjects';
import { FormikProps, FormikErrors, Field, withFormik } from 'formik';
import * as Yup from 'yup';
import { LoadingForm } from '../../lib/components/loadingForm';
import { ErrorForm } from '../../lib/components/errorForm';
import * as Api from '../../api/models';
import { Constants, ApiRoutes, ClientRoutes } from '../../constants';
import FollowingMapper from './followingMapper';
import FollowingViewModel from './followingViewModel';

interface Props {
  model?: FollowingViewModel;
}

const FollowingCreateDisplay: React.SFC<FormikProps<FollowingViewModel>> = (
  props: FormikProps<FollowingViewModel>
) => {
  let status = props.status as CreateResponse<Api.FollowingClientRequestModel>;

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

const FollowingCreate = withFormik<Props, FollowingViewModel>({
  mapPropsToValues: props => {
    let response = new FollowingViewModel();
    if (props.model != undefined) {
      response.setProperties(
        props.model!.dateFollowed,
        props.model!.muted,
        props.model!.userId
      );
    }
    return response;
  },

  validate: values => {
    let errors: FormikErrors<FollowingViewModel> = {};

    return errors;
  },

  handleSubmit: (values, actions) => {
    actions.setStatus(undefined);
    let mapper = new FollowingMapper();

    axios
      .post(
        Constants.ApiEndpoint + ApiRoutes.Followings,
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
            Api.FollowingClientRequestModel
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
  displayName: 'FollowingCreate',
})(FollowingCreateDisplay);

interface FollowingCreateComponentProps {}

interface FollowingCreateComponentState {
  model?: FollowingViewModel;
  loading: boolean;
  loaded: boolean;
  errorOccurred: boolean;
  errorMessage: string;
}

export default class FollowingCreateComponent extends React.Component<
  FollowingCreateComponentProps,
  FollowingCreateComponentState
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
      return <FollowingCreate model={this.state.model} />;
    } else {
      return null;
    }
  }
}


/*<Codenesium>
    <Hash>e4cad52fdcc4f357f8298b76c102b630</Hash>
</Codenesium>*/