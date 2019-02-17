import React, { Component } from 'react';
import axios from 'axios';
import * as Api from '../../api/models';
import { UpdateResponse } from '../../api/apiObjects';
import { Constants, ApiRoutes, ClientRoutes } from '../../constants';
import { FormikProps, FormikErrors, Field, withFormik } from 'formik';
import { LoadingForm } from '../../lib/components/loadingForm';
import { ErrorForm } from '../../lib/components/errorForm';
import PhoneNumberTypeViewModel from './phoneNumberTypeViewModel';
import PhoneNumberTypeMapper from './phoneNumberTypeMapper';

interface Props {
  model?: PhoneNumberTypeViewModel;
}

const PhoneNumberTypeEditDisplay = (
  props: FormikProps<PhoneNumberTypeViewModel>
) => {
  let status = props.status as UpdateResponse<
    Api.PhoneNumberTypeClientRequestModel
  >;

  let errorsForField = (name: string): string => {
    let response = '';
    if (
      props.touched[name as keyof PhoneNumberTypeViewModel] &&
      props.errors[name as keyof PhoneNumberTypeViewModel]
    ) {
      response += props.errors[name as keyof PhoneNumberTypeViewModel];
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
            errorExistForField('name')
              ? 'col-sm-2 col-form-label is-invalid'
              : 'col-sm-2 col-form-label'
          }
        >
          Name
        </label>
        <div className="col-sm-12">
          <Field
            type="datetime-local"
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
            errorExistForField('phoneNumberTypeID')
              ? 'col-sm-2 col-form-label is-invalid'
              : 'col-sm-2 col-form-label'
          }
        >
          PhoneNumberTypeID
        </label>
        <div className="col-sm-12">
          <Field
            type="datetime-local"
            name="phoneNumberTypeID"
            className={
              errorExistForField('phoneNumberTypeID')
                ? 'form-control is-invalid'
                : 'form-control'
            }
          />
          {errorExistForField('phoneNumberTypeID') && (
            <small className="text-danger">
              {errorsForField('phoneNumberTypeID')}
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

const PhoneNumberTypeEdit = withFormik<Props, PhoneNumberTypeViewModel>({
  mapPropsToValues: props => {
    let response = new PhoneNumberTypeViewModel();
    response.setProperties(
      props.model!.modifiedDate,
      props.model!.name,
      props.model!.phoneNumberTypeID
    );
    return response;
  },

  // Custom sync validation
  validate: values => {
    let errors: FormikErrors<PhoneNumberTypeViewModel> = {};

    if (values.modifiedDate == undefined) {
      errors.modifiedDate = 'Required';
    }
    if (values.name == '') {
      errors.name = 'Required';
    }
    if (values.phoneNumberTypeID == 0) {
      errors.phoneNumberTypeID = 'Required';
    }

    return errors;
  },
  handleSubmit: (values, actions) => {
    actions.setStatus(undefined);

    let mapper = new PhoneNumberTypeMapper();

    axios
      .put(
        Constants.ApiEndpoint +
          ApiRoutes.PhoneNumberTypes +
          '/' +
          values.phoneNumberTypeID,

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
            Api.PhoneNumberTypeClientRequestModel
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

  displayName: 'PhoneNumberTypeEdit',
})(PhoneNumberTypeEditDisplay);

interface IParams {
  phoneNumberTypeID: number;
}

interface IMatch {
  params: IParams;
}

interface PhoneNumberTypeEditComponentProps {
  match: IMatch;
}

interface PhoneNumberTypeEditComponentState {
  model?: PhoneNumberTypeViewModel;
  loading: boolean;
  loaded: boolean;
  errorOccurred: boolean;
  errorMessage: string;
}

export default class PhoneNumberTypeEditComponent extends React.Component<
  PhoneNumberTypeEditComponentProps,
  PhoneNumberTypeEditComponentState
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
          ApiRoutes.PhoneNumberTypes +
          '/' +
          this.props.match.params.phoneNumberTypeID,
        {
          headers: {
            'Content-Type': 'application/json',
          },
        }
      )
      .then(
        resp => {
          let response = resp.data as Api.PhoneNumberTypeClientResponseModel;

          console.log(response);

          let mapper = new PhoneNumberTypeMapper();

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
      return <PhoneNumberTypeEdit model={this.state.model} />;
    } else {
      return null;
    }
  }
}


/*<Codenesium>
    <Hash>5ba4dc5dadbd9e6a3fc40856ea88abd2</Hash>
</Codenesium>*/