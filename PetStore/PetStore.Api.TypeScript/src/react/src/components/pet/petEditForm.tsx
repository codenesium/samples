import React, { Component } from 'react';
import axios from 'axios';
import * as Api from '../../api/models';
import { UpdateResponse } from '../../api/ApiObjects';
import { Constants, ApiRoutes, ClientRoutes } from '../../constants';
import { FormikProps, FormikErrors, Field, withFormik } from 'formik';
import { LoadingForm } from '../../lib/components/loadingForm';
import { ErrorForm } from '../../lib/components/errorForm';
import PetViewModel from './petViewModel';
import PetMapper from './petMapper';

interface Props {
  model?: PetViewModel;
}

const PetEditDisplay = (props: FormikProps<PetViewModel>) => {
  let status = props.status as UpdateResponse<Api.PetClientRequestModel>;

  let errorsForField = (name: string): string => {
    let response = '';
    if (
      props.touched[name as keyof PetViewModel] &&
      props.errors[name as keyof PetViewModel]
    ) {
      response += props.errors[name as keyof PetViewModel];
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
            errorExistForField('acquiredDate')
              ? 'col-sm-2 col-form-label is-invalid'
              : 'col-sm-2 col-form-label'
          }
        >
          AcquiredDate
        </label>
        <div className="col-sm-12">
          <Field
            type="textbox"
            name="acquiredDate"
            className={
              errorExistForField('acquiredDate')
                ? 'form-control is-invalid'
                : 'form-control'
            }
          />
          {errorExistForField('acquiredDate') && (
            <small className="text-danger">
              {errorsForField('acquiredDate')}
            </small>
          )}
        </div>
      </div>
      <div className="form-group row">
        <label
          htmlFor="name"
          className={
            errorExistForField('breedId')
              ? 'col-sm-2 col-form-label is-invalid'
              : 'col-sm-2 col-form-label'
          }
        >
          BreedId
        </label>
        <div className="col-sm-12">
          <Field
            type="textbox"
            name="breedId"
            className={
              errorExistForField('breedId')
                ? 'form-control is-invalid'
                : 'form-control'
            }
          />
          {errorExistForField('breedId') && (
            <small className="text-danger">{errorsForField('breedId')}</small>
          )}
        </div>
      </div>
      <div className="form-group row">
        <label
          htmlFor="name"
          className={
            errorExistForField('description')
              ? 'col-sm-2 col-form-label is-invalid'
              : 'col-sm-2 col-form-label'
          }
        >
          Description
        </label>
        <div className="col-sm-12">
          <Field
            type="textbox"
            name="description"
            className={
              errorExistForField('description')
                ? 'form-control is-invalid'
                : 'form-control'
            }
          />
          {errorExistForField('description') && (
            <small className="text-danger">
              {errorsForField('description')}
            </small>
          )}
        </div>
      </div>
      <div className="form-group row">
        <label
          htmlFor="name"
          className={
            errorExistForField('penId')
              ? 'col-sm-2 col-form-label is-invalid'
              : 'col-sm-2 col-form-label'
          }
        >
          PenId
        </label>
        <div className="col-sm-12">
          <Field
            type="textbox"
            name="penId"
            className={
              errorExistForField('penId')
                ? 'form-control is-invalid'
                : 'form-control'
            }
          />
          {errorExistForField('penId') && (
            <small className="text-danger">{errorsForField('penId')}</small>
          )}
        </div>
      </div>
      <div className="form-group row">
        <label
          htmlFor="name"
          className={
            errorExistForField('price')
              ? 'col-sm-2 col-form-label is-invalid'
              : 'col-sm-2 col-form-label'
          }
        >
          Price
        </label>
        <div className="col-sm-12">
          <Field
            type="textbox"
            name="price"
            className={
              errorExistForField('price')
                ? 'form-control is-invalid'
                : 'form-control'
            }
          />
          {errorExistForField('price') && (
            <small className="text-danger">{errorsForField('price')}</small>
          )}
        </div>
      </div>
      <div className="form-group row">
        <label
          htmlFor="name"
          className={
            errorExistForField('speciesId')
              ? 'col-sm-2 col-form-label is-invalid'
              : 'col-sm-2 col-form-label'
          }
        >
          SpeciesId
        </label>
        <div className="col-sm-12">
          <Field
            type="textbox"
            name="speciesId"
            className={
              errorExistForField('speciesId')
                ? 'form-control is-invalid'
                : 'form-control'
            }
          />
          {errorExistForField('speciesId') && (
            <small className="text-danger">{errorsForField('speciesId')}</small>
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

const PetEdit = withFormik<Props, PetViewModel>({
  mapPropsToValues: props => {
    let response = new PetViewModel();
    response.setProperties(
      props.model!.acquiredDate,
      props.model!.breedId,
      props.model!.description,
      props.model!.id,
      props.model!.penId,
      props.model!.price,
      props.model!.speciesId
    );
    return response;
  },

  // Custom sync validation
  validate: values => {
    let errors: FormikErrors<PetViewModel> = {};

    if (values.acquiredDate == undefined) {
      errors.acquiredDate = 'Required';
    }
    if (values.breedId == 0) {
      errors.breedId = 'Required';
    }
    if (values.description == '') {
      errors.description = 'Required';
    }
    if (values.id == 0) {
      errors.id = 'Required';
    }
    if (values.penId == 0) {
      errors.penId = 'Required';
    }
    if (values.price == 0) {
      errors.price = 'Required';
    }
    if (values.speciesId == 0) {
      errors.speciesId = 'Required';
    }

    return errors;
  },
  handleSubmit: (values, actions) => {
    actions.setStatus(undefined);

    let mapper = new PetMapper();

    axios
      .put(
        Constants.ApiEndpoint + ApiRoutes.Pets + '/' + values.id,

        mapper.mapViewModelToApiRequest(values),
        {
          headers: {
            'Content-Type': 'application/json',
          },
        }
      )
      .then(
        resp => {
          let response = resp.data as UpdateResponse<Api.PetClientRequestModel>;
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

  displayName: 'PetEdit',
})(PetEditDisplay);

interface IParams {
  id: number;
}

interface IMatch {
  params: IParams;
}

interface PetEditComponentProps {
  match: IMatch;
}

interface PetEditComponentState {
  model?: PetViewModel;
  loading: boolean;
  loaded: boolean;
  errorOccurred: boolean;
  errorMessage: string;
}

export default class PetEditComponent extends React.Component<
  PetEditComponentProps,
  PetEditComponentState
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
          ApiRoutes.Pets +
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
          let response = resp.data as Api.PetClientResponseModel;

          console.log(response);

          let mapper = new PetMapper();

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
      return <PetEdit model={this.state.model} />;
    } else {
      return null;
    }
  }
}


/*<Codenesium>
    <Hash>f17091717ec759f27b52b7f0d766a8c5</Hash>
</Codenesium>*/