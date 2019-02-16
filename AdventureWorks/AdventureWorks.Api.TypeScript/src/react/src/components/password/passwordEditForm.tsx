import React, { Component } from 'react';
import axios from 'axios';
import * as Api from '../../api/models';
import { UpdateResponse } from '../../api/ApiObjects';
import Constants from '../../constants';
import { FormikProps, FormikErrors, Field, withFormik } from 'formik';
import PasswordViewModel from './passwordViewModel';
import PasswordMapper from './passwordMapper';

interface Props {
  model?: PasswordViewModel;
}

const PasswordEditDisplay = (props: FormikProps<PasswordViewModel>) => {
  let status = props.status as UpdateResponse<Api.PasswordClientRequestModel>;

  let errorsForField = (name: string): string => {
    let response = '';
    if (
      props.touched[name as keyof PasswordViewModel] &&
      props.errors[name as keyof PasswordViewModel]
    ) {
      response += props.errors[name as keyof PasswordViewModel];
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
            errorExistForField('businessEntityID')
              ? 'col-sm-2 col-form-label is-invalid'
              : 'col-sm-2 col-form-label'
          }
        >
          BusinessEntityID
        </label>
        <div className="col-sm-12">
          <Field
            type="datetime-local"
            name="businessEntityID"
            className={
              errorExistForField('businessEntityID')
                ? 'form-control is-invalid'
                : 'form-control'
            }
          />
          {errorExistForField('businessEntityID') && (
            <small className="text-danger">
              {errorsForField('businessEntityID')}
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
            errorExistForField('passwordHash')
              ? 'col-sm-2 col-form-label is-invalid'
              : 'col-sm-2 col-form-label'
          }
        >
          PasswordHash
        </label>
        <div className="col-sm-12">
          <Field
            type="datetime-local"
            name="passwordHash"
            className={
              errorExistForField('passwordHash')
                ? 'form-control is-invalid'
                : 'form-control'
            }
          />
          {errorExistForField('passwordHash') && (
            <small className="text-danger">
              {errorsForField('passwordHash')}
            </small>
          )}
        </div>
      </div>
      <div className="form-group row">
        <label
          htmlFor="name"
          className={
            errorExistForField('passwordSalt')
              ? 'col-sm-2 col-form-label is-invalid'
              : 'col-sm-2 col-form-label'
          }
        >
          PasswordSalt
        </label>
        <div className="col-sm-12">
          <Field
            type="datetime-local"
            name="passwordSalt"
            className={
              errorExistForField('passwordSalt')
                ? 'form-control is-invalid'
                : 'form-control'
            }
          />
          {errorExistForField('passwordSalt') && (
            <small className="text-danger">
              {errorsForField('passwordSalt')}
            </small>
          )}
        </div>
      </div>
      <div className="form-group row">
        <label
          htmlFor="name"
          className={
            errorExistForField('rowguid')
              ? 'col-sm-2 col-form-label is-invalid'
              : 'col-sm-2 col-form-label'
          }
        >
          Rowguid
        </label>
        <div className="col-sm-12">
          <Field
            type="datetime-local"
            name="rowguid"
            className={
              errorExistForField('rowguid')
                ? 'form-control is-invalid'
                : 'form-control'
            }
          />
          {errorExistForField('rowguid') && (
            <small className="text-danger">{errorsForField('rowguid')}</small>
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

const PasswordUpdate = withFormik<Props, PasswordViewModel>({
  mapPropsToValues: props => {
    let response = new PasswordViewModel();
    response.setProperties(
      props.model!.businessEntityID,
      props.model!.modifiedDate,
      props.model!.passwordHash,
      props.model!.passwordSalt,
      props.model!.rowguid
    );
    return response;
  },

  // Custom sync validation
  validate: values => {
    let errors: FormikErrors<PasswordViewModel> = {};

    if (values.businessEntityID == 0) {
      errors.businessEntityID = 'Required';
    }
    if (values.modifiedDate == undefined) {
      errors.modifiedDate = 'Required';
    }
    if (values.passwordHash == '') {
      errors.passwordHash = 'Required';
    }
    if (values.passwordSalt == '') {
      errors.passwordSalt = 'Required';
    }
    if (values.rowguid == undefined) {
      errors.rowguid = 'Required';
    }

    return errors;
  },
  handleSubmit: (values, actions) => {
    actions.setStatus(undefined);

    let mapper = new PasswordMapper();

    axios
      .put(
        Constants.ApiUrl + 'passwords/' + values.businessEntityID,

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
            Api.PasswordClientRequestModel
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

  displayName: 'PasswordEdit',
})(PasswordEditDisplay);

interface IParams {
  businessEntityID: number;
}

interface IMatch {
  params: IParams;
}

interface PasswordEditComponentProps {
  match: IMatch;
}

interface PasswordEditComponentState {
  model?: PasswordViewModel;
  loading: boolean;
  loaded: boolean;
  errorOccurred: boolean;
  errorMessage: string;
}

export default class PasswordEditComponent extends React.Component<
  PasswordEditComponentProps,
  PasswordEditComponentState
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
          'passwords/' +
          this.props.match.params.businessEntityID,
        {
          headers: {
            'Content-Type': 'application/json',
          },
        }
      )
      .then(
        resp => {
          let response = resp.data as Api.PasswordClientResponseModel;

          console.log(response);

          let mapper = new PasswordMapper();

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
      return <PasswordUpdate model={this.state.model} />;
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
    <Hash>0b69c50be08b0f9304aa2237ced90207</Hash>
</Codenesium>*/