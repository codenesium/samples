import React, { Component } from 'react';
import axios from 'axios';
import * as Api from '../../api/models';
import { UpdateResponse } from '../../api/ApiObjects';
import Constants from '../../constants';
import { FormikProps, FormikErrors, Field, withFormik } from 'formik';
import AWBuildVersionViewModel from './aWBuildVersionViewModel';
import AWBuildVersionMapper from './aWBuildVersionMapper';

interface Props {
  model?: AWBuildVersionViewModel;
}

const AWBuildVersionEditDisplay = (
  props: FormikProps<AWBuildVersionViewModel>
) => {
  let status = props.status as UpdateResponse<
    Api.AWBuildVersionClientRequestModel
  >;

  let errorsForField = (name: string): string => {
    let response = '';
    if (
      props.touched[name as keyof AWBuildVersionViewModel] &&
      props.errors[name as keyof AWBuildVersionViewModel]
    ) {
      response += props.errors[name as keyof AWBuildVersionViewModel];
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
            errorExistForField('database_Version')
              ? 'col-sm-2 col-form-label is-invalid'
              : 'col-sm-2 col-form-label'
          }
        >
          Database Version
        </label>
        <div className="col-sm-12">
          <Field
            type="datetime-local"
            name="database_Version"
            className={
              errorExistForField('database_Version')
                ? 'form-control is-invalid'
                : 'form-control'
            }
          />
          {errorExistForField('database_Version') && (
            <small className="text-danger">
              {errorsForField('database_Version')}
            </small>
          )}
        </div>
      </div>
      <div className="form-group row">
        <label
          htmlFor="name"
          className={
            errorExistForField('modifiedDate')
              ? 'col-sm-2 col-form-label is-invalid'
              : 'col-sm-2 col-form-label'
          }
        >
          ModifiedDate
        </label>
        <div className="col-sm-12">
          <Field
            type="datetime-local"
            name="modifiedDate"
            className={
              errorExistForField('modifiedDate')
                ? 'form-control is-invalid'
                : 'form-control'
            }
          />
          {errorExistForField('modifiedDate') && (
            <small className="text-danger">
              {errorsForField('modifiedDate')}
            </small>
          )}
        </div>
      </div>
      <div className="form-group row">
        <label
          htmlFor="name"
          className={
            errorExistForField('systemInformationID')
              ? 'col-sm-2 col-form-label is-invalid'
              : 'col-sm-2 col-form-label'
          }
        >
          SystemInformationID
        </label>
        <div className="col-sm-12">
          <Field
            type="datetime-local"
            name="systemInformationID"
            className={
              errorExistForField('systemInformationID')
                ? 'form-control is-invalid'
                : 'form-control'
            }
          />
          {errorExistForField('systemInformationID') && (
            <small className="text-danger">
              {errorsForField('systemInformationID')}
            </small>
          )}
        </div>
      </div>
      <div className="form-group row">
        <label
          htmlFor="name"
          className={
            errorExistForField('versionDate')
              ? 'col-sm-2 col-form-label is-invalid'
              : 'col-sm-2 col-form-label'
          }
        >
          VersionDate
        </label>
        <div className="col-sm-12">
          <Field
            type="datetime-local"
            name="versionDate"
            className={
              errorExistForField('versionDate')
                ? 'form-control is-invalid'
                : 'form-control'
            }
          />
          {errorExistForField('versionDate') && (
            <small className="text-danger">
              {errorsForField('versionDate')}
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

const AWBuildVersionUpdate = withFormik<Props, AWBuildVersionViewModel>({
  mapPropsToValues: props => {
    let response = new AWBuildVersionViewModel();
    response.setProperties(
      props.model!.database_Version,
      props.model!.modifiedDate,
      props.model!.systemInformationID,
      props.model!.versionDate
    );
    return response;
  },

  // Custom sync validation
  validate: values => {
    let errors: FormikErrors<AWBuildVersionViewModel> = {};

    if (values.database_Version == '') {
      errors.database_Version = 'Required';
    }
    if (values.modifiedDate == undefined) {
      errors.modifiedDate = 'Required';
    }
    if (values.systemInformationID == 0) {
      errors.systemInformationID = 'Required';
    }
    if (values.versionDate == undefined) {
      errors.versionDate = 'Required';
    }

    return errors;
  },
  handleSubmit: (values, actions) => {
    actions.setStatus(undefined);

    let mapper = new AWBuildVersionMapper();

    axios
      .put(
        Constants.ApiUrl + 'awbuildversions/' + values.systemInformationID,

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
            Api.AWBuildVersionClientRequestModel
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

  displayName: 'AWBuildVersionEdit',
})(AWBuildVersionEditDisplay);

interface IParams {
  systemInformationID: number;
}

interface IMatch {
  params: IParams;
}

interface AWBuildVersionEditComponentProps {
  match: IMatch;
}

interface AWBuildVersionEditComponentState {
  model?: AWBuildVersionViewModel;
  loading: boolean;
  loaded: boolean;
  errorOccurred: boolean;
  errorMessage: string;
}

export default class AWBuildVersionEditComponent extends React.Component<
  AWBuildVersionEditComponentProps,
  AWBuildVersionEditComponentState
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
        Constants.ApiUrl +
          'awbuildversions/' +
          this.props.match.params.systemInformationID,
        {
          headers: {
            'Content-Type': 'application/json',
          },
        }
      )
      .then(
        resp => {
          let response = resp.data as Api.AWBuildVersionClientResponseModel;

          console.log(response);

          let mapper = new AWBuildVersionMapper();

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
      return <div>loading</div>;
    } else if (this.state.loaded) {
      return <AWBuildVersionUpdate model={this.state.model} />;
    } else if (this.state.errorOccurred) {
      return (
        <div className="alert alert-danger">{this.state.errorMessage}</div>
      );
    } else {
      return <div />;
    }
  }
}


/*<Codenesium>
    <Hash>8887cd793910059eab4ac600146e20d6</Hash>
</Codenesium>*/