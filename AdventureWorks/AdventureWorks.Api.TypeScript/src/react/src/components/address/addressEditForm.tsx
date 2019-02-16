import React, { Component } from 'react';
import axios from 'axios';
import * as Api from '../../api/models';
import { UpdateResponse } from '../../api/ApiObjects';
import Constants from '../../constants';
import { FormikProps, FormikErrors, Field, withFormik } from 'formik';
import AddressViewModel from './addressViewModel';
import AddressMapper from './addressMapper';

interface Props {
  model?: AddressViewModel;
}

const AddressEditDisplay = (props: FormikProps<AddressViewModel>) => {
  let status = props.status as UpdateResponse<Api.AddressClientRequestModel>;

  let errorsForField = (name: string): string => {
    let response = '';
    if (
      props.touched[name as keyof AddressViewModel] &&
      props.errors[name as keyof AddressViewModel]
    ) {
      response += props.errors[name as keyof AddressViewModel];
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
            errorExistForField('addressID')
              ? 'col-sm-2 col-form-label is-invalid'
              : 'col-sm-2 col-form-label'
          }
        >
          AddressID
        </label>
        <div className="col-sm-12">
          <Field
            type="datetime-local"
            name="addressID"
            className={
              errorExistForField('addressID')
                ? 'form-control is-invalid'
                : 'form-control'
            }
          />
          {errorExistForField('addressID') && (
            <small className="text-danger">{errorsForField('addressID')}</small>
          )}
        </div>
      </div>
      <div className="form-group row">
        <label
          htmlFor="name"
          className={
            errorExistForField('addressLine1')
              ? 'col-sm-2 col-form-label is-invalid'
              : 'col-sm-2 col-form-label'
          }
        >
          AddressLine1
        </label>
        <div className="col-sm-12">
          <Field
            type="datetime-local"
            name="addressLine1"
            className={
              errorExistForField('addressLine1')
                ? 'form-control is-invalid'
                : 'form-control'
            }
          />
          {errorExistForField('addressLine1') && (
            <small className="text-danger">
              {errorsForField('addressLine1')}
            </small>
          )}
        </div>
      </div>
      <div className="form-group row">
        <label
          htmlFor="name"
          className={
            errorExistForField('addressLine2')
              ? 'col-sm-2 col-form-label is-invalid'
              : 'col-sm-2 col-form-label'
          }
        >
          AddressLine2
        </label>
        <div className="col-sm-12">
          <Field
            type="datetime-local"
            name="addressLine2"
            className={
              errorExistForField('addressLine2')
                ? 'form-control is-invalid'
                : 'form-control'
            }
          />
          {errorExistForField('addressLine2') && (
            <small className="text-danger">
              {errorsForField('addressLine2')}
            </small>
          )}
        </div>
      </div>
      <div className="form-group row">
        <label
          htmlFor="name"
          className={
            errorExistForField('city')
              ? 'col-sm-2 col-form-label is-invalid'
              : 'col-sm-2 col-form-label'
          }
        >
          City
        </label>
        <div className="col-sm-12">
          <Field
            type="datetime-local"
            name="city"
            className={
              errorExistForField('city')
                ? 'form-control is-invalid'
                : 'form-control'
            }
          />
          {errorExistForField('city') && (
            <small className="text-danger">{errorsForField('city')}</small>
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
            errorExistForField('postalCode')
              ? 'col-sm-2 col-form-label is-invalid'
              : 'col-sm-2 col-form-label'
          }
        >
          PostalCode
        </label>
        <div className="col-sm-12">
          <Field
            type="datetime-local"
            name="postalCode"
            className={
              errorExistForField('postalCode')
                ? 'form-control is-invalid'
                : 'form-control'
            }
          />
          {errorExistForField('postalCode') && (
            <small className="text-danger">
              {errorsForField('postalCode')}
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
      <div className="form-group row">
        <label
          htmlFor="name"
          className={
            errorExistForField('stateProvinceID')
              ? 'col-sm-2 col-form-label is-invalid'
              : 'col-sm-2 col-form-label'
          }
        >
          StateProvinceID
        </label>
        <div className="col-sm-12">
          <Field
            type="datetime-local"
            name="stateProvinceID"
            className={
              errorExistForField('stateProvinceID')
                ? 'form-control is-invalid'
                : 'form-control'
            }
          />
          {errorExistForField('stateProvinceID') && (
            <small className="text-danger">
              {errorsForField('stateProvinceID')}
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

const AddressUpdate = withFormik<Props, AddressViewModel>({
  mapPropsToValues: props => {
    let response = new AddressViewModel();
    response.setProperties(
      props.model!.addressID,
      props.model!.addressLine1,
      props.model!.addressLine2,
      props.model!.city,
      props.model!.modifiedDate,
      props.model!.postalCode,
      props.model!.rowguid,
      props.model!.stateProvinceID
    );
    return response;
  },

  // Custom sync validation
  validate: values => {
    let errors: FormikErrors<AddressViewModel> = {};

    if (values.addressID == 0) {
      errors.addressID = 'Required';
    }
    if (values.addressLine1 == '') {
      errors.addressLine1 = 'Required';
    }
    if (values.city == '') {
      errors.city = 'Required';
    }
    if (values.modifiedDate == undefined) {
      errors.modifiedDate = 'Required';
    }
    if (values.postalCode == '') {
      errors.postalCode = 'Required';
    }
    if (values.rowguid == undefined) {
      errors.rowguid = 'Required';
    }
    if (values.stateProvinceID == 0) {
      errors.stateProvinceID = 'Required';
    }

    return errors;
  },
  handleSubmit: (values, actions) => {
    actions.setStatus(undefined);

    let mapper = new AddressMapper();

    axios
      .put(
        Constants.ApiUrl + 'addresses/' + values.addressID,

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
            Api.AddressClientRequestModel
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

  displayName: 'AddressEdit',
})(AddressEditDisplay);

interface IParams {
  addressID: number;
}

interface IMatch {
  params: IParams;
}

interface AddressEditComponentProps {
  match: IMatch;
}

interface AddressEditComponentState {
  model?: AddressViewModel;
  loading: boolean;
  loaded: boolean;
  errorOccurred: boolean;
  errorMessage: string;
}

export default class AddressEditComponent extends React.Component<
  AddressEditComponentProps,
  AddressEditComponentState
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
        Constants.ApiUrl + 'addresses/' + this.props.match.params.addressID,
        {
          headers: {
            'Content-Type': 'application/json',
          },
        }
      )
      .then(
        resp => {
          let response = resp.data as Api.AddressClientResponseModel;

          console.log(response);

          let mapper = new AddressMapper();

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
      return <AddressUpdate model={this.state.model} />;
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
    <Hash>af4d5e83032271f9dbdc14488678ab5a</Hash>
</Codenesium>*/