import React, { Component } from 'react';
import axios from 'axios';
import { CreateResponse } from '../../api/apiObjects';
import { FormikProps, FormikErrors, Field, withFormik } from 'formik';
import * as Yup from 'yup';
import { LoadingForm } from '../../lib/components/loadingForm';
import { ErrorForm } from '../../lib/components/errorForm';
import * as Api from '../../api/models';
import { Constants, ApiRoutes, ClientRoutes } from '../../constants';
import VPersonMapper from './vPersonMapper';
import VPersonViewModel from './vPersonViewModel';

interface Props {
  model?: VPersonViewModel;
}

const VPersonCreateDisplay: React.SFC<FormikProps<VPersonViewModel>> = (
  props: FormikProps<VPersonViewModel>
) => {
  let status = props.status as CreateResponse<Api.VPersonClientRequestModel>;

  let errorsForField = (name: string): string => {
    let response = '';
    if (
      props.touched[name as keyof VPersonViewModel] &&
      props.errors[name as keyof VPersonViewModel]
    ) {
      response += props.errors[name as keyof VPersonViewModel];
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
            errorExistForField('personName')
              ? 'col-sm-2 col-form-label is-invalid'
              : 'col-sm-2 col-form-label'
          }
        >
          PersonName
        </label>
        <div className="col-sm-12">
          <Field
            type="textbox"
            name="personName"
            className={
              errorExistForField('personName')
                ? 'form-control is-invalid'
                : 'form-control'
            }
          />
          {errorExistForField('personName') && (
            <small className="text-danger">
              {errorsForField('personName')}
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

const VPersonCreate = withFormik<Props, VPersonViewModel>({
  mapPropsToValues: props => {
    let response = new VPersonViewModel();
    if (props.model != undefined) {
      response.setProperties(props.model!.personId, props.model!.personName);
    }
    return response;
  },

  validate: values => {
    let errors: FormikErrors<VPersonViewModel> = {};

    if (values.personName == '') {
      errors.personName = 'Required';
    }

    return errors;
  },

  handleSubmit: (values, actions) => {
    actions.setStatus(undefined);
    let mapper = new VPersonMapper();

    axios
      .post(
        Constants.ApiEndpoint + ApiRoutes.VPersons,
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
            Api.VPersonClientRequestModel
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
  displayName: 'VPersonCreate',
})(VPersonCreateDisplay);

interface VPersonCreateComponentProps {}

interface VPersonCreateComponentState {
  model?: VPersonViewModel;
  loading: boolean;
  loaded: boolean;
  errorOccurred: boolean;
  errorMessage: string;
}

export default class VPersonCreateComponent extends React.Component<
  VPersonCreateComponentProps,
  VPersonCreateComponentState
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
      return <VPersonCreate model={this.state.model} />;
    } else {
      return null;
    }
  }
}


/*<Codenesium>
    <Hash>0f493e32e53d47cba851f44d04ce09d3</Hash>
</Codenesium>*/