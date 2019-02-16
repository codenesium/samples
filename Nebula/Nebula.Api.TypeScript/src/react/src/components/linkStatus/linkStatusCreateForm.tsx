import React, { Component } from 'react';
import axios from 'axios';
import { CreateResponse } from '../../api/ApiObjects';
import { FormikProps, FormikErrors, Field, withFormik } from 'formik';
import * as Yup from 'yup';
import { LoadingForm } from '../../lib/components/loadingForm';
import { ErrorForm } from '../../lib/components/errorForm';
import * as Api from '../../api/models';
import { Constants, ApiRoutes, ClientRoutes } from '../../constants';
import LinkStatusMapper from './linkStatusMapper';
import LinkStatusViewModel from './linkStatusViewModel';

interface Props {
  model?: LinkStatusViewModel;
}

const LinkStatusCreateDisplay: React.SFC<FormikProps<LinkStatusViewModel>> = (
  props: FormikProps<LinkStatusViewModel>
) => {
  let status = props.status as CreateResponse<Api.LinkStatusClientRequestModel>;

  let errorsForField = (name: string): string => {
    let response = '';
    if (
      props.touched[name as keyof LinkStatusViewModel] &&
      props.errors[name as keyof LinkStatusViewModel]
    ) {
      response += props.errors[name as keyof LinkStatusViewModel];
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
            errorExistForField('name')
              ? 'col-sm-2 col-form-label is-invalid'
              : 'col-sm-2 col-form-label'
          }
        >
          Name
        </label>
        <div className="col-sm-12">
          <Field
            type="textbox"
            name="name"
            className={
              errorExistForField('name')
                ? 'form-control is-invalid'
                : 'form-control'
            }
          />
          {errorExistForField('name') && (
            <small className="text-danger">{errorsForField('name')}</small>
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

const LinkStatusCreate = withFormik<Props, LinkStatusViewModel>({
  mapPropsToValues: props => {
    let response = new LinkStatusViewModel();
    if (props.model != undefined) {
      response.setProperties(props.model!.id, props.model!.name);
    }
    return response;
  },

  validate: values => {
    let errors: FormikErrors<LinkStatusViewModel> = {};

    if (values.name == '') {
      errors.name = 'Required';
    }

    return errors;
  },

  handleSubmit: (values, actions) => {
    actions.setStatus(undefined);
    let mapper = new LinkStatusMapper();

    axios
      .post(
        Constants.ApiEndpoint + ApiRoutes.LinkStatuses,
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
            Api.LinkStatusClientRequestModel
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
  displayName: 'LinkStatusCreate',
})(LinkStatusCreateDisplay);

interface LinkStatusCreateComponentProps {}

interface LinkStatusCreateComponentState {
  model?: LinkStatusViewModel;
  loading: boolean;
  loaded: boolean;
  errorOccurred: boolean;
  errorMessage: string;
}

export default class LinkStatusCreateComponent extends React.Component<
  LinkStatusCreateComponentProps,
  LinkStatusCreateComponentState
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
      return <LinkStatusCreate model={this.state.model} />;
    } else {
      return null;
    }
  }
}


/*<Codenesium>
    <Hash>48de54d579a84016669f541c9d837396</Hash>
</Codenesium>*/