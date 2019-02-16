import React, { Component } from 'react';
import axios from 'axios';
import { CreateResponse } from '../../api/ApiObjects';
import { FormikProps, FormikErrors, Field, withFormik } from 'formik';
import * as Yup from 'yup';
import { LoadingForm } from '../../lib/components/loadingForm';
import { ErrorForm } from '../../lib/components/errorForm';
import * as Api from '../../api/models';
import { Constants, ApiRoutes, ClientRoutes } from '../../constants';
import LinkTypeMapper from './linkTypeMapper';
import LinkTypeViewModel from './linkTypeViewModel';

interface Props {
  model?: LinkTypeViewModel;
}

const LinkTypeCreateDisplay: React.SFC<FormikProps<LinkTypeViewModel>> = (
  props: FormikProps<LinkTypeViewModel>
) => {
  let status = props.status as CreateResponse<Api.LinkTypeClientRequestModel>;

  let errorsForField = (name: string): string => {
    let response = '';
    if (
      props.touched[name as keyof LinkTypeViewModel] &&
      props.errors[name as keyof LinkTypeViewModel]
    ) {
      response += props.errors[name as keyof LinkTypeViewModel];
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

const LinkTypeCreate = withFormik<Props, LinkTypeViewModel>({
  mapPropsToValues: props => {
    let response = new LinkTypeViewModel();
    if (props.model != undefined) {
      response.setProperties(props.model!.id, props.model!.type);
    }
    return response;
  },

  validate: values => {
    let errors: FormikErrors<LinkTypeViewModel> = {};

    if (values.type == '') {
      errors.type = 'Required';
    }

    return errors;
  },

  handleSubmit: (values, actions) => {
    actions.setStatus(undefined);
    let mapper = new LinkTypeMapper();

    axios
      .post(
        Constants.ApiEndpoint + ApiRoutes.LinkTypes,
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
            Api.LinkTypeClientRequestModel
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
  displayName: 'LinkTypeCreate',
})(LinkTypeCreateDisplay);

interface LinkTypeCreateComponentProps {}

interface LinkTypeCreateComponentState {
  model?: LinkTypeViewModel;
  loading: boolean;
  loaded: boolean;
  errorOccurred: boolean;
  errorMessage: string;
}

export default class LinkTypeCreateComponent extends React.Component<
  LinkTypeCreateComponentProps,
  LinkTypeCreateComponentState
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
      return <LinkTypeCreate model={this.state.model} />;
    } else {
      return null;
    }
  }
}


/*<Codenesium>
    <Hash>56e66d9df380a3b0dd06c3f958f55ae9</Hash>
</Codenesium>*/