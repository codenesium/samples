import React, { Component } from 'react';
import axios from 'axios';
import { CreateResponse } from '../../api/ApiObjects';
import { FormikProps, FormikErrors, Field, withFormik } from 'formik';
import * as Yup from 'yup';
import { LoadingForm } from '../../lib/components/loadingForm';
import { ErrorForm } from '../../lib/components/errorForm';
import * as Api from '../../api/models';
import { Constants, ApiRoutes, ClientRoutes } from '../../constants';
import PostTypeMapper from './postTypeMapper';
import PostTypeViewModel from './postTypeViewModel';

interface Props {
  model?: PostTypeViewModel;
}

const PostTypeCreateDisplay: React.SFC<FormikProps<PostTypeViewModel>> = (
  props: FormikProps<PostTypeViewModel>
) => {
  let status = props.status as CreateResponse<Api.PostTypeClientRequestModel>;

  let errorsForField = (name: string): string => {
    let response = '';
    if (
      props.touched[name as keyof PostTypeViewModel] &&
      props.errors[name as keyof PostTypeViewModel]
    ) {
      response += props.errors[name as keyof PostTypeViewModel];
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
            errorExistForField('type')
              ? 'col-sm-2 col-form-label is-invalid'
              : 'col-sm-2 col-form-label'
          }
        >
          Type
        </label>
        <div className="col-sm-12">
          <Field
            type="datetime-local"
            name="type"
            className={
              errorExistForField('type')
                ? 'form-control is-invalid'
                : 'form-control'
            }
          />
          {errorExistForField('type') && (
            <small className="text-danger">{errorsForField('type')}</small>
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

const PostTypeCreate = withFormik<Props, PostTypeViewModel>({
  mapPropsToValues: props => {
    let response = new PostTypeViewModel();
    if (props.model != undefined) {
      response.setProperties(props.model!.id, props.model!.type);
    }
    return response;
  },

  validate: values => {
    let errors: FormikErrors<PostTypeViewModel> = {};

    if (values.type == '') {
      errors.type = 'Required';
    }

    return errors;
  },

  handleSubmit: (values, actions) => {
    actions.setStatus(undefined);
    let mapper = new PostTypeMapper();

    axios
      .post(
        Constants.ApiEndpoint + ApiRoutes.PostTypes,
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
            Api.PostTypeClientRequestModel
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
  displayName: 'PostTypeCreate',
})(PostTypeCreateDisplay);

interface PostTypeCreateComponentProps {}

interface PostTypeCreateComponentState {
  model?: PostTypeViewModel;
  loading: boolean;
  loaded: boolean;
  errorOccurred: boolean;
  errorMessage: string;
}

export default class PostTypeCreateComponent extends React.Component<
  PostTypeCreateComponentProps,
  PostTypeCreateComponentState
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
      return <PostTypeCreate model={this.state.model} />;
    } else {
      return null;
    }
  }
}


/*<Codenesium>
    <Hash>f1d97f10fc66d27df3afdac9e271b096</Hash>
</Codenesium>*/