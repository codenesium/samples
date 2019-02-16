import React, { Component } from 'react';
import axios from 'axios';
import * as Api from '../../api/models';
import { UpdateResponse } from '../../api/ApiObjects';
import { Constants, ApiRoutes, ClientRoutes } from '../../constants';
import { FormikProps, FormikErrors, Field, withFormik } from 'formik';
import { LoadingForm } from '../../lib/components/loadingForm';
import { ErrorForm } from '../../lib/components/errorForm';
import DeviceViewModel from './deviceViewModel';
import DeviceMapper from './deviceMapper';

interface Props {
  model?: DeviceViewModel;
}

const DeviceEditDisplay = (props: FormikProps<DeviceViewModel>) => {
  let status = props.status as UpdateResponse<Api.DeviceClientRequestModel>;

  let errorsForField = (name: string): string => {
    let response = '';
    if (
      props.touched[name as keyof DeviceViewModel] &&
      props.errors[name as keyof DeviceViewModel]
    ) {
      response += props.errors[name as keyof DeviceViewModel];
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
            errorExistForField('dateOfLastPing')
              ? 'col-sm-2 col-form-label is-invalid'
              : 'col-sm-2 col-form-label'
          }
        >
          DateOfLastPing
        </label>
        <div className="col-sm-12">
          <Field
            type="textbox"
            name="dateOfLastPing"
            className={
              errorExistForField('dateOfLastPing')
                ? 'form-control is-invalid'
                : 'form-control'
            }
          />
          {errorExistForField('dateOfLastPing') && (
            <small className="text-danger">
              {errorsForField('dateOfLastPing')}
            </small>
          )}
        </div>
      </div>
      <div className="form-group row">
        <label
          htmlFor="name"
          className={
            errorExistForField('isActive')
              ? 'col-sm-2 col-form-label is-invalid'
              : 'col-sm-2 col-form-label'
          }
        >
          IsActive
        </label>
        <div className="col-sm-12">
          <Field
            type="textbox"
            name="isActive"
            className={
              errorExistForField('isActive')
                ? 'form-control is-invalid'
                : 'form-control'
            }
          />
          {errorExistForField('isActive') && (
            <small className="text-danger">{errorsForField('isActive')}</small>
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
      <div className="form-group row">
        <label
          htmlFor="name"
          className={
            errorExistForField('publicId')
              ? 'col-sm-2 col-form-label is-invalid'
              : 'col-sm-2 col-form-label'
          }
        >
          PublicId
        </label>
        <div className="col-sm-12">
          <Field
            type="textbox"
            name="publicId"
            className={
              errorExistForField('publicId')
                ? 'form-control is-invalid'
                : 'form-control'
            }
          />
          {errorExistForField('publicId') && (
            <small className="text-danger">{errorsForField('publicId')}</small>
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

const DeviceEdit = withFormik<Props, DeviceViewModel>({
  mapPropsToValues: props => {
    let response = new DeviceViewModel();
    response.setProperties(
      props.model!.dateOfLastPing,
      props.model!.id,
      props.model!.isActive,
      props.model!.name,
      props.model!.publicId
    );
    return response;
  },

  // Custom sync validation
  validate: values => {
    let errors: FormikErrors<DeviceViewModel> = {};

    if (values.dateOfLastPing == undefined) {
      errors.dateOfLastPing = 'Required';
    }
    if (values.id == 0) {
      errors.id = 'Required';
    }
    if (values.name == '') {
      errors.name = 'Required';
    }
    if (values.publicId == undefined) {
      errors.publicId = 'Required';
    }

    return errors;
  },
  handleSubmit: (values, actions) => {
    actions.setStatus(undefined);

    let mapper = new DeviceMapper();

    axios
      .put(
        Constants.ApiEndpoint + ApiRoutes.Devices + '/' + values.id,

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
            Api.DeviceClientRequestModel
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

  displayName: 'DeviceEdit',
})(DeviceEditDisplay);

interface IParams {
  id: number;
}

interface IMatch {
  params: IParams;
}

interface DeviceEditComponentProps {
  match: IMatch;
}

interface DeviceEditComponentState {
  model?: DeviceViewModel;
  loading: boolean;
  loaded: boolean;
  errorOccurred: boolean;
  errorMessage: string;
}

export default class DeviceEditComponent extends React.Component<
  DeviceEditComponentProps,
  DeviceEditComponentState
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
          ApiRoutes.Devices +
          '/' +
          this.props.match.params.id,
        {
          headers: {
            'Content-Type': 'application/json',
          },
        }
      )
      .then(
        resp => {
          let response = resp.data as Api.DeviceClientResponseModel;

          console.log(response);

          let mapper = new DeviceMapper();

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
      return <DeviceEdit model={this.state.model} />;
    } else {
      return null;
    }
  }
}


/*<Codenesium>
    <Hash>81765d95d1b543749a85a4eb202729a4</Hash>
</Codenesium>*/