import React, { Component } from 'react';
import axios from 'axios';
import * as Api from '../../api/models';
import { UpdateResponse } from '../../api/apiObjects';
import { Constants, ApiRoutes, ClientRoutes } from '../../constants';
import { FormikProps, FormikErrors, Field, withFormik } from 'formik';
import { LoadingForm } from '../../lib/components/loadingForm';
import { ErrorForm } from '../../lib/components/errorForm';
import PipelineStepDestinationViewModel from './pipelineStepDestinationViewModel';
import PipelineStepDestinationMapper from './pipelineStepDestinationMapper';

interface Props {
  model?: PipelineStepDestinationViewModel;
}

const PipelineStepDestinationEditDisplay = (
  props: FormikProps<PipelineStepDestinationViewModel>
) => {
  let status = props.status as UpdateResponse<
    Api.PipelineStepDestinationClientRequestModel
  >;

  let errorsForField = (name: string): string => {
    let response = '';
    if (
      props.touched[name as keyof PipelineStepDestinationViewModel] &&
      props.errors[name as keyof PipelineStepDestinationViewModel]
    ) {
      response += props.errors[name as keyof PipelineStepDestinationViewModel];
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
            errorExistForField('destinationId')
              ? 'col-sm-2 col-form-label is-invalid'
              : 'col-sm-2 col-form-label'
          }
        >
          DestinationId
        </label>
        <div className="col-sm-12">
          <Field
            type="datetime-local"
            name="destinationId"
            className={
              errorExistForField('destinationId')
                ? 'form-control is-invalid'
                : 'form-control'
            }
          />
          {errorExistForField('destinationId') && (
            <small className="text-danger">
              {errorsForField('destinationId')}
            </small>
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
            errorExistForField('pipelineStepId')
              ? 'col-sm-2 col-form-label is-invalid'
              : 'col-sm-2 col-form-label'
          }
        >
          PipelineStepId
        </label>
        <div className="col-sm-12">
          <Field
            type="datetime-local"
            name="pipelineStepId"
            className={
              errorExistForField('pipelineStepId')
                ? 'form-control is-invalid'
                : 'form-control'
            }
          />
          {errorExistForField('pipelineStepId') && (
            <small className="text-danger">
              {errorsForField('pipelineStepId')}
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

const PipelineStepDestinationEdit = withFormik<
  Props,
  PipelineStepDestinationViewModel
>({
  mapPropsToValues: props => {
    let response = new PipelineStepDestinationViewModel();
    response.setProperties(
      props.model!.destinationId,
      props.model!.id,
      props.model!.pipelineStepId
    );
    return response;
  },

  // Custom sync validation
  validate: values => {
    let errors: FormikErrors<PipelineStepDestinationViewModel> = {};

    if (values.destinationId == 0) {
      errors.destinationId = 'Required';
    }
    if (values.id == 0) {
      errors.id = 'Required';
    }
    if (values.pipelineStepId == 0) {
      errors.pipelineStepId = 'Required';
    }

    return errors;
  },
  handleSubmit: (values, actions) => {
    actions.setStatus(undefined);

    let mapper = new PipelineStepDestinationMapper();

    axios
      .put(
        Constants.ApiEndpoint +
          ApiRoutes.PipelineStepDestinations +
          '/' +
          values.id,

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
            Api.PipelineStepDestinationClientRequestModel
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

  displayName: 'PipelineStepDestinationEdit',
})(PipelineStepDestinationEditDisplay);

interface IParams {
  id: number;
}

interface IMatch {
  params: IParams;
}

interface PipelineStepDestinationEditComponentProps {
  match: IMatch;
}

interface PipelineStepDestinationEditComponentState {
  model?: PipelineStepDestinationViewModel;
  loading: boolean;
  loaded: boolean;
  errorOccurred: boolean;
  errorMessage: string;
}

export default class PipelineStepDestinationEditComponent extends React.Component<
  PipelineStepDestinationEditComponentProps,
  PipelineStepDestinationEditComponentState
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
          ApiRoutes.PipelineStepDestinations +
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
          let response = resp.data as Api.PipelineStepDestinationClientResponseModel;

          console.log(response);

          let mapper = new PipelineStepDestinationMapper();

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
      return <PipelineStepDestinationEdit model={this.state.model} />;
    } else {
      return null;
    }
  }
}


/*<Codenesium>
    <Hash>36eec6c1144cbeefa7ee0acbc2cfc579</Hash>
</Codenesium>*/