import React, { Component } from 'react';
import axios from 'axios';
import { CreateResponse } from '../../api/ApiObjects';
import { FormikProps, FormikErrors, Field, withFormik } from 'formik';
import * as Yup from 'yup';
import { LoadingForm } from '../../lib/components/loadingForm';
import { ErrorForm } from '../../lib/components/errorForm';
import * as Api from '../../api/models';
import { Constants, ApiRoutes, ClientRoutes } from '../../constants';
import DeviceActionMapper from './deviceActionMapper';
import DeviceActionViewModel from './deviceActionViewModel';

interface Props {
  model?: DeviceActionViewModel;
}

const DeviceActionCreateDisplay: React.SFC<
  FormikProps<DeviceActionViewModel>
> = (props: FormikProps<DeviceActionViewModel>) => {
  let status = props.status as CreateResponse<
    Api.DeviceActionClientRequestModel
  >;

  let errorsForField = (name: string): string => {
    let response = '';
    if (
      props.touched[name as keyof DeviceActionViewModel] &&
      props.errors[name as keyof DeviceActionViewModel]
    ) {
      response += props.errors[name as keyof DeviceActionViewModel];
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
            errorExistForField('action')
              ? 'col-sm-2 col-form-label is-invalid'
              : 'col-sm-2 col-form-label'
          }
        >
          Action
        </label>
        <div className="col-sm-12">
          <Field
            type="textbox"
            name="action"
            className={
              errorExistForField('action')
                ? 'form-control is-invalid'
                : 'form-control'
            }
          />
          {errorExistForField('action') && (
            <small className="text-danger">{errorsForField('action')}</small>
          )}
        </div>
      </div>

      <div className="form-group row">
        <label
          htmlFor="name"
          className={
            errorExistForField('deviceId')
              ? 'col-sm-2 col-form-label is-invalid'
              : 'col-sm-2 col-form-label'
          }
        >
          DeviceId
        </label>
        <div className="col-sm-12">
          <Field
            type="textbox"
            name="deviceId"
            className={
              errorExistForField('deviceId')
                ? 'form-control is-invalid'
                : 'form-control'
            }
          />
          {errorExistForField('deviceId') && (
            <small className="text-danger">{errorsForField('deviceId')}</small>
          )}
        </div>
      </div>

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

const DeviceActionCreate = withFormik<Props, DeviceActionViewModel>({
  mapPropsToValues: props => {
    let response = new DeviceActionViewModel();
    if (props.model != undefined) {
      response.setProperties(
        props.model!.action,
        props.model!.deviceId,
        props.model!.id,
        props.model!.name
      );
    }
    return response;
  },

  validate: values => {
    let errors: FormikErrors<DeviceActionViewModel> = {};

    if (values.action == '') {
      errors.action = 'Required';
    }
    if (values.deviceId == 0) {
      errors.deviceId = 'Required';
    }
    if (values.name == '') {
      errors.name = 'Required';
    }

    return errors;
  },

  handleSubmit: (values, actions) => {
    actions.setStatus(undefined);
    let mapper = new DeviceActionMapper();

    axios
      .post(
        Constants.ApiEndpoint + ApiRoutes.DeviceActions,
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
            Api.DeviceActionClientRequestModel
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
  displayName: 'DeviceActionCreate',
})(DeviceActionCreateDisplay);

interface DeviceActionCreateComponentProps {}

interface DeviceActionCreateComponentState {
  model?: DeviceActionViewModel;
  loading: boolean;
  loaded: boolean;
  errorOccurred: boolean;
  errorMessage: string;
}

export default class DeviceActionCreateComponent extends React.Component<
  DeviceActionCreateComponentProps,
  DeviceActionCreateComponentState
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
      return <DeviceActionCreate model={this.state.model} />;
    } else {
      return null;
    }
  }
}


/*<Codenesium>
    <Hash>285c4ce308b07126aeb4c38f321cf746</Hash>
</Codenesium>*/