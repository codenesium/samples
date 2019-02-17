import React, { Component } from 'react';
import axios from 'axios';
import * as Api from '../../api/models';
import { UpdateResponse } from '../../api/apiObjects';
import { Constants, ApiRoutes, ClientRoutes } from '../../constants';
import { FormikProps, FormikErrors, Field, withFormik } from 'formik';
import { LoadingForm } from '../../lib/components/loadingForm';
import { ErrorForm } from '../../lib/components/errorForm';
import StudioViewModel from './studioViewModel';
import StudioMapper from './studioMapper';

interface Props {
  model?: StudioViewModel;
}

const StudioEditDisplay = (props: FormikProps<StudioViewModel>) => {
  let status = props.status as UpdateResponse<Api.StudioClientRequestModel>;

  let errorsForField = (name: string): string => {
    let response = '';
    if (
      props.touched[name as keyof StudioViewModel] &&
      props.errors[name as keyof StudioViewModel]
    ) {
      response += props.errors[name as keyof StudioViewModel];
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
            errorExistForField('address1')
              ? 'col-sm-2 col-form-label is-invalid'
              : 'col-sm-2 col-form-label'
          }
        >
          Address1
        </label>
        <div className="col-sm-12">
          <Field
            type="datetime-local"
            name="address1"
            className={
              errorExistForField('address1')
                ? 'form-control is-invalid'
                : 'form-control'
            }
          />
          {errorExistForField('address1') && (
            <small className="text-danger">{errorsForField('address1')}</small>
          )}
        </div>
      </div>
      <div className="form-group row">
        <label
          htmlFor="name"
          className={
            errorExistForField('address2')
              ? 'col-sm-2 col-form-label is-invalid'
              : 'col-sm-2 col-form-label'
          }
        >
          Address2
        </label>
        <div className="col-sm-12">
          <Field
            type="datetime-local"
            name="address2"
            className={
              errorExistForField('address2')
                ? 'form-control is-invalid'
                : 'form-control'
            }
          />
          {errorExistForField('address2') && (
            <small className="text-danger">{errorsForField('address2')}</small>
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
            errorExistForField('id')
              ? 'col-sm-2 col-form-label is-invalid'
              : 'col-sm-2 col-form-label'
          }
        >
          Id
        </label>
        <div className="col-sm-12">
          <Field
            type="datetime-local"
            name="id"
            className={
              errorExistForField('id')
                ? 'form-control is-invalid'
                : 'form-control'
            }
          />
          {errorExistForField('id') && (
            <small className="text-danger">{errorsForField('id')}</small>
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
            errorExistForField('province')
              ? 'col-sm-2 col-form-label is-invalid'
              : 'col-sm-2 col-form-label'
          }
        >
          Province
        </label>
        <div className="col-sm-12">
          <Field
            type="datetime-local"
            name="province"
            className={
              errorExistForField('province')
                ? 'form-control is-invalid'
                : 'form-control'
            }
          />
          {errorExistForField('province') && (
            <small className="text-danger">{errorsForField('province')}</small>
          )}
        </div>
      </div>
      <div className="form-group row">
        <label
          htmlFor="name"
          className={
            errorExistForField('website')
              ? 'col-sm-2 col-form-label is-invalid'
              : 'col-sm-2 col-form-label'
          }
        >
          Website
        </label>
        <div className="col-sm-12">
          <Field
            type="datetime-local"
            name="website"
            className={
              errorExistForField('website')
                ? 'form-control is-invalid'
                : 'form-control'
            }
          />
          {errorExistForField('website') && (
            <small className="text-danger">{errorsForField('website')}</small>
          )}
        </div>
      </div>
      <div className="form-group row">
        <label
          htmlFor="name"
          className={
            errorExistForField('zip')
              ? 'col-sm-2 col-form-label is-invalid'
              : 'col-sm-2 col-form-label'
          }
        >
          Zip
        </label>
        <div className="col-sm-12">
          <Field
            type="datetime-local"
            name="zip"
            className={
              errorExistForField('zip')
                ? 'form-control is-invalid'
                : 'form-control'
            }
          />
          {errorExistForField('zip') && (
            <small className="text-danger">{errorsForField('zip')}</small>
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

const StudioEdit = withFormik<Props, StudioViewModel>({
  mapPropsToValues: props => {
    let response = new StudioViewModel();
    response.setProperties(
      props.model!.address1,
      props.model!.address2,
      props.model!.city,
      props.model!.id,
      props.model!.name,
      props.model!.province,
      props.model!.website,
      props.model!.zip
    );
    return response;
  },

  // Custom sync validation
  validate: values => {
    let errors: FormikErrors<StudioViewModel> = {};

    if (values.address1 == '') {
      errors.address1 = 'Required';
    }
    if (values.address2 == '') {
      errors.address2 = 'Required';
    }
    if (values.city == '') {
      errors.city = 'Required';
    }
    if (values.id == 0) {
      errors.id = 'Required';
    }
    if (values.name == '') {
      errors.name = 'Required';
    }
    if (values.province == '') {
      errors.province = 'Required';
    }
    if (values.website == '') {
      errors.website = 'Required';
    }

    return errors;
  },
  handleSubmit: (values, actions) => {
    actions.setStatus(undefined);

    let mapper = new StudioMapper();

    axios
      .put(
        Constants.ApiEndpoint + ApiRoutes.Studios + '/' + values.id,

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
            Api.StudioClientRequestModel
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

  displayName: 'StudioEdit',
})(StudioEditDisplay);

interface IParams {
  id: number;
}

interface IMatch {
  params: IParams;
}

interface StudioEditComponentProps {
  match: IMatch;
}

interface StudioEditComponentState {
  model?: StudioViewModel;
  loading: boolean;
  loaded: boolean;
  errorOccurred: boolean;
  errorMessage: string;
}

export default class StudioEditComponent extends React.Component<
  StudioEditComponentProps,
  StudioEditComponentState
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
          ApiRoutes.Studios +
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
          let response = resp.data as Api.StudioClientResponseModel;

          console.log(response);

          let mapper = new StudioMapper();

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
      return <StudioEdit model={this.state.model} />;
    } else {
      return null;
    }
  }
}


/*<Codenesium>
    <Hash>72ade048773d0b16935737f43a97321a</Hash>
</Codenesium>*/