import React, { Component } from 'react';
import axios from 'axios';
import { CreateResponse } from '../../api/apiObjects';
import { FormikProps, FormikErrors, Field, withFormik } from 'formik';
import * as Yup from 'yup';
import { LoadingForm } from '../../lib/components/loadingForm';
import { ErrorForm } from '../../lib/components/errorForm';
import * as Api from '../../api/models';
import { Constants, ApiRoutes, ClientRoutes } from '../../constants';
import PostHistoryMapper from './postHistoryMapper';
import PostHistoryViewModel from './postHistoryViewModel';

interface Props {
  model?: PostHistoryViewModel;
}

const PostHistoryCreateDisplay: React.SFC<FormikProps<PostHistoryViewModel>> = (
  props: FormikProps<PostHistoryViewModel>
) => {
  let status = props.status as CreateResponse<
    Api.PostHistoryClientRequestModel
  >;

  let errorsForField = (name: string): string => {
    let response = '';
    if (
      props.touched[name as keyof PostHistoryViewModel] &&
      props.errors[name as keyof PostHistoryViewModel]
    ) {
      response += props.errors[name as keyof PostHistoryViewModel];
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
            errorExistForField('comment')
              ? 'col-sm-2 col-form-label is-invalid'
              : 'col-sm-2 col-form-label'
          }
        >
          Comment
        </label>
        <div className="col-sm-12">
          <Field
            type="textbox"
            name="comment"
            className={
              errorExistForField('comment')
                ? 'form-control is-invalid'
                : 'form-control'
            }
          />
          {errorExistForField('comment') && (
            <small className="text-danger">{errorsForField('comment')}</small>
          )}
        </div>
      </div>

      <div className="form-group row">
        <label
          htmlFor="name"
          className={
            errorExistForField('creationDate')
              ? 'col-sm-2 col-form-label is-invalid'
              : 'col-sm-2 col-form-label'
          }
        >
          CreationDate
        </label>
        <div className="col-sm-12">
          <Field
            type="textbox"
            name="creationDate"
            className={
              errorExistForField('creationDate')
                ? 'form-control is-invalid'
                : 'form-control'
            }
          />
          {errorExistForField('creationDate') && (
            <small className="text-danger">
              {errorsForField('creationDate')}
            </small>
          )}
        </div>
      </div>

      <div className="form-group row">
        <label
          htmlFor="name"
          className={
            errorExistForField('postHistoryTypeId')
              ? 'col-sm-2 col-form-label is-invalid'
              : 'col-sm-2 col-form-label'
          }
        >
          PostHistoryTypeId
        </label>
        <div className="col-sm-12">
          <Field
            type="textbox"
            name="postHistoryTypeId"
            className={
              errorExistForField('postHistoryTypeId')
                ? 'form-control is-invalid'
                : 'form-control'
            }
          />
          {errorExistForField('postHistoryTypeId') && (
            <small className="text-danger">
              {errorsForField('postHistoryTypeId')}
            </small>
          )}
        </div>
      </div>

      <div className="form-group row">
        <label
          htmlFor="name"
          className={
            errorExistForField('postId')
              ? 'col-sm-2 col-form-label is-invalid'
              : 'col-sm-2 col-form-label'
          }
        >
          PostId
        </label>
        <div className="col-sm-12">
          <Field
            type="textbox"
            name="postId"
            className={
              errorExistForField('postId')
                ? 'form-control is-invalid'
                : 'form-control'
            }
          />
          {errorExistForField('postId') && (
            <small className="text-danger">{errorsForField('postId')}</small>
          )}
        </div>
      </div>

      <div className="form-group row">
        <label
          htmlFor="name"
          className={
            errorExistForField('revisionGUID')
              ? 'col-sm-2 col-form-label is-invalid'
              : 'col-sm-2 col-form-label'
          }
        >
          RevisionGUID
        </label>
        <div className="col-sm-12">
          <Field
            type="textbox"
            name="revisionGUID"
            className={
              errorExistForField('revisionGUID')
                ? 'form-control is-invalid'
                : 'form-control'
            }
          />
          {errorExistForField('revisionGUID') && (
            <small className="text-danger">
              {errorsForField('revisionGUID')}
            </small>
          )}
        </div>
      </div>

      <div className="form-group row">
        <label
          htmlFor="name"
          className={
            errorExistForField('text')
              ? 'col-sm-2 col-form-label is-invalid'
              : 'col-sm-2 col-form-label'
          }
        >
          Text
        </label>
        <div className="col-sm-12">
          <Field
            type="textbox"
            name="text"
            className={
              errorExistForField('text')
                ? 'form-control is-invalid'
                : 'form-control'
            }
          />
          {errorExistForField('text') && (
            <small className="text-danger">{errorsForField('text')}</small>
          )}
        </div>
      </div>

      <div className="form-group row">
        <label
          htmlFor="name"
          className={
            errorExistForField('userDisplayName')
              ? 'col-sm-2 col-form-label is-invalid'
              : 'col-sm-2 col-form-label'
          }
        >
          UserDisplayName
        </label>
        <div className="col-sm-12">
          <Field
            type="textbox"
            name="userDisplayName"
            className={
              errorExistForField('userDisplayName')
                ? 'form-control is-invalid'
                : 'form-control'
            }
          />
          {errorExistForField('userDisplayName') && (
            <small className="text-danger">
              {errorsForField('userDisplayName')}
            </small>
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

const PostHistoryCreate = withFormik<Props, PostHistoryViewModel>({
  mapPropsToValues: props => {
    let response = new PostHistoryViewModel();
    if (props.model != undefined) {
      response.setProperties(
        props.model!.comment,
        props.model!.creationDate,
        props.model!.id,
        props.model!.postHistoryTypeId,
        props.model!.postId,
        props.model!.revisionGUID,
        props.model!.text,
        props.model!.userDisplayName,
        props.model!.userId
      );
    }
    return response;
  },

  validate: values => {
    let errors: FormikErrors<PostHistoryViewModel> = {};

    if (values.creationDate == undefined) {
      errors.creationDate = 'Required';
    }
    if (values.postHistoryTypeId == 0) {
      errors.postHistoryTypeId = 'Required';
    }
    if (values.postId == 0) {
      errors.postId = 'Required';
    }
    if (values.revisionGUID == '') {
      errors.revisionGUID = 'Required';
    }

    return errors;
  },

  handleSubmit: (values, actions) => {
    actions.setStatus(undefined);
    let mapper = new PostHistoryMapper();

    axios
      .post(
        Constants.ApiEndpoint + ApiRoutes.PostHistories,
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
            Api.PostHistoryClientRequestModel
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
  displayName: 'PostHistoryCreate',
})(PostHistoryCreateDisplay);

interface PostHistoryCreateComponentProps {}

interface PostHistoryCreateComponentState {
  model?: PostHistoryViewModel;
  loading: boolean;
  loaded: boolean;
  errorOccurred: boolean;
  errorMessage: string;
}

export default class PostHistoryCreateComponent extends React.Component<
  PostHistoryCreateComponentProps,
  PostHistoryCreateComponentState
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
      return <PostHistoryCreate model={this.state.model} />;
    } else {
      return null;
    }
  }
}


/*<Codenesium>
    <Hash>31e75c2f86d2984601ba1728b158a49d</Hash>
</Codenesium>*/