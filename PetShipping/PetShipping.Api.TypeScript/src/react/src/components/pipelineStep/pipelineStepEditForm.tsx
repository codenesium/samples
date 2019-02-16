import React, { Component } from 'react';
import axios from 'axios';
import * as Api from '../../api/models';
import { UpdateResponse } from '../../api/ApiObjects';
import { Constants, ApiRoutes, ClientRoutes } from '../../constants';
import { FormikProps, FormikErrors, Field, withFormik } from 'formik';
import { LoadingForm } from '../../lib/components/loadingForm';
import { ErrorForm } from '../../lib/components/errorForm';
import PipelineStepViewModel from './pipelineStepViewModel';
import PipelineStepMapper from './pipelineStepMapper';

interface Props {
  model?: PipelineStepViewModel;
}

const PipelineStepEditDisplay = (props: FormikProps<PipelineStepViewModel>) => {
  let status = props.status as UpdateResponse<
    Api.PipelineStepClientRequestModel
  >;

  let errorsForField = (name: string): string => {
    let response = '';
    if (
      props.touched[name as keyof PipelineStepViewModel] &&
      props.errors[name as keyof PipelineStepViewModel]
    ) {
      response += props.errors[name as keyof PipelineStepViewModel];
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
            errorExistForField('pipelineStepStatusId')
              ? 'col-sm-2 col-form-label is-invalid'
              : 'col-sm-2 col-form-label'
          }
        >
          PipelineStepStatusId
        </label>
        <div className="col-sm-12">
          <Field
            type="datetime-local"
            name="pipelineStepStatusId"
            className={
              errorExistForField('pipelineStepStatusId')
                ? 'form-control is-invalid'
                : 'form-control'
            }
          />
          {errorExistForField('pipelineStepStatusId') && (
            <small className="text-danger">
              {errorsForField('pipelineStepStatusId')}
            </small>
          )}
        </div>
      </div>
      <div className="form-group row">
        <label
          htmlFor="name"
          className={
            errorExistForField('shipperId')
              ? 'col-sm-2 col-form-label is-invalid'
              : 'col-sm-2 col-form-label'
          }
        >
          ShipperId
        </label>
        <div className="col-sm-12">
          <Field
            type="datetime-local"
            name="shipperId"
            className={
              errorExistForField('shipperId')
                ? 'form-control is-invalid'
                : 'form-control'
            }
          />
          {errorExistForField('shipperId') && (
            <small className="text-danger">{errorsForField('shipperId')}</small>
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

const PipelineStepEdit = withFormik<Props, PipelineStepViewModel>({
  mapPropsToValues: props => {
    let response = new PipelineStepViewModel();
    response.setProperties(
      props.model!.id,
      props.model!.name,
      props.model!.pipelineStepStatusId,
      props.model!.shipperId
    );
    return response;
  },

  // Custom sync validation
  validate: values => {
    let errors: FormikErrors<PipelineStepViewModel> = {};

    if (values.id == 0) {
      errors.id = 'Required';
    }
    if (values.name == '') {
      errors.name = 'Required';
    }
    if (values.pipelineStepStatusId == 0) {
      errors.pipelineStepStatusId = 'Required';
    }
    if (values.shipperId == 0) {
      errors.shipperId = 'Required';
    }

    return errors;
  },
  handleSubmit: (values, actions) => {
    actions.setStatus(undefined);

    let mapper = new PipelineStepMapper();

    axios
      .put(
        Constants.ApiEndpoint + ApiRoutes.PipelineSteps + '/' + values.id,

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
            Api.PipelineStepClientRequestModel
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

  displayName: 'PipelineStepEdit',
})(PipelineStepEditDisplay);

interface IParams {
  id: number;
}

interface IMatch {
  params: IParams;
}

interface PipelineStepEditComponentProps {
  match: IMatch;
}

interface PipelineStepEditComponentState {
  model?: PipelineStepViewModel;
  loading: boolean;
  loaded: boolean;
  errorOccurred: boolean;
  errorMessage: string;
}

export default class PipelineStepEditComponent extends React.Component<
  PipelineStepEditComponentProps,
  PipelineStepEditComponentState
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
          ApiRoutes.PipelineSteps +
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
          let response = resp.data as Api.PipelineStepClientResponseModel;

          console.log(response);

          let mapper = new PipelineStepMapper();

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
      return <PipelineStepEdit model={this.state.model} />;
    } else {
      return null;
    }
  }
}


/*<Codenesium>
    <Hash>85a58c2f4961fad8f67d5e1e0e9bcfd1</Hash>
</Codenesium>*/