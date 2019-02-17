import React, { Component } from 'react';
import axios from 'axios';
import { CreateResponse } from '../../api/apiObjects';
import { FormikProps, FormikErrors, Field, withFormik } from 'formik';
import * as Yup from 'yup';
import { LoadingForm } from '../../lib/components/loadingForm';
import { ErrorForm } from '../../lib/components/errorForm';
import * as Api from '../../api/models';
import { Constants, ApiRoutes, ClientRoutes } from '../../constants';
import PostLinkMapper from './postLinkMapper';
import PostLinkViewModel from './postLinkViewModel';

interface Props {
  model?: PostLinkViewModel;
}

const PostLinkCreateDisplay: React.SFC<FormikProps<PostLinkViewModel>> = (
  props: FormikProps<PostLinkViewModel>
) => {
  let status = props.status as CreateResponse<Api.PostLinkClientRequestModel>;

  let errorsForField = (name: string): string => {
    let response = '';
    if (
      props.touched[name as keyof PostLinkViewModel] &&
      props.errors[name as keyof PostLinkViewModel]
    ) {
      response += props.errors[name as keyof PostLinkViewModel];
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
            errorExistForField('linkTypeId')
              ? 'col-sm-2 col-form-label is-invalid'
              : 'col-sm-2 col-form-label'
          }
        >
          LinkTypeId
        </label>
        <div className="col-sm-12">
          <Field
            type="textbox"
            name="linkTypeId"
            className={
              errorExistForField('linkTypeId')
                ? 'form-control is-invalid'
                : 'form-control'
            }
          />
          {errorExistForField('linkTypeId') && (
            <small className="text-danger">
              {errorsForField('linkTypeId')}
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
            errorExistForField('relatedPostId')
              ? 'col-sm-2 col-form-label is-invalid'
              : 'col-sm-2 col-form-label'
          }
        >
          RelatedPostId
        </label>
        <div className="col-sm-12">
          <Field
            type="textbox"
            name="relatedPostId"
            className={
              errorExistForField('relatedPostId')
                ? 'form-control is-invalid'
                : 'form-control'
            }
          />
          {errorExistForField('relatedPostId') && (
            <small className="text-danger">
              {errorsForField('relatedPostId')}
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

const PostLinkCreate = withFormik<Props, PostLinkViewModel>({
  mapPropsToValues: props => {
    let response = new PostLinkViewModel();
    if (props.model != undefined) {
      response.setProperties(
        props.model!.creationDate,
        props.model!.id,
        props.model!.linkTypeId,
        props.model!.postId,
        props.model!.relatedPostId
      );
    }
    return response;
  },

  validate: values => {
    let errors: FormikErrors<PostLinkViewModel> = {};

    if (values.creationDate == undefined) {
      errors.creationDate = 'Required';
    }
    if (values.linkTypeId == 0) {
      errors.linkTypeId = 'Required';
    }
    if (values.postId == 0) {
      errors.postId = 'Required';
    }
    if (values.relatedPostId == 0) {
      errors.relatedPostId = 'Required';
    }

    return errors;
  },

  handleSubmit: (values, actions) => {
    actions.setStatus(undefined);
    let mapper = new PostLinkMapper();

    axios
      .post(
        Constants.ApiEndpoint + ApiRoutes.PostLinks,
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
            Api.PostLinkClientRequestModel
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
  displayName: 'PostLinkCreate',
})(PostLinkCreateDisplay);

interface PostLinkCreateComponentProps {}

interface PostLinkCreateComponentState {
  model?: PostLinkViewModel;
  loading: boolean;
  loaded: boolean;
  errorOccurred: boolean;
  errorMessage: string;
}

export default class PostLinkCreateComponent extends React.Component<
  PostLinkCreateComponentProps,
  PostLinkCreateComponentState
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
      return <PostLinkCreate model={this.state.model} />;
    } else {
      return null;
    }
  }
}


/*<Codenesium>
    <Hash>72013f0760958e89f74c0ac7f22faee5</Hash>
</Codenesium>*/