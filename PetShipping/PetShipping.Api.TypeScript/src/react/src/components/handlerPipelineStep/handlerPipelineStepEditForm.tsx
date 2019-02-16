import React, { Component } from 'react';
import axios from 'axios';
import * as Api from '../../api/models';
import { UpdateResponse } from '../../api/ApiObjects';
import { Constants, ApiRoutes, ClientRoutes } from '../../constants';
import { FormikProps, FormikErrors, Field, withFormik } from 'formik';
import { LoadingForm } from '../../lib/components/loadingForm';
import { ErrorForm } from '../../lib/components/errorForm';
import HandlerPipelineStepViewModel from './handlerPipelineStepViewModel';
import HandlerPipelineStepMapper from './handlerPipelineStepMapper';

interface Props {
  model?: HandlerPipelineStepViewModel;
}

const HandlerPipelineStepEditDisplay = (
  props: FormikProps<HandlerPipelineStepViewModel>
) => {
  let status = props.status as UpdateResponse<
    Api.HandlerPipelineStepClientRequestModel
  >;

  let errorsForField = (name: string): string => {
    let response = '';
    if (
      props.touched[name as keyof HandlerPipelineStepViewModel] &&
      props.errors[name as keyof HandlerPipelineStepViewModel]
    ) {
      response += props.errors[name as keyof HandlerPipelineStepViewModel];
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
            errorExistForField('handlerId')
              ? 'col-sm-2 col-form-label is-invalid'
              : 'col-sm-2 col-form-label'
          }
        >
          HandlerId
        </label>
        <div className="col-sm-12">
          <Field
            type="datetime-local"
            name="handlerId"
            className={
              errorExistForField('handlerId')
                ? 'form-control is-invalid'
                : 'form-control'
            }
          />
          {errorExistForField('handlerId') && (
            <small className="text-danger">{errorsForField('handlerId')}</small>
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

const HandlerPipelineStepEdit = withFormik<Props, HandlerPipelineStepViewModel>(
  {
    mapPropsToValues: props => {
      let response = new HandlerPipelineStepViewModel();
      response.setProperties(
        props.model!.handlerId,
        props.model!.id,
        props.model!.pipelineStepId
      );
      return response;
    },

    // Custom sync validation
    validate: values => {
      let errors: FormikErrors<HandlerPipelineStepViewModel> = {};

      if (values.handlerId == 0) {
        errors.handlerId = 'Required';
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

      let mapper = new HandlerPipelineStepMapper();

      axios
        .put(
          Constants.ApiEndpoint +
            ApiRoutes.HandlerPipelineSteps +
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
              Api.HandlerPipelineStepClientRequestModel
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

    displayName: 'HandlerPipelineStepEdit',
  }
)(HandlerPipelineStepEditDisplay);

interface IParams {
  id: number;
}

interface IMatch {
  params: IParams;
}

interface HandlerPipelineStepEditComponentProps {
  match: IMatch;
}

interface HandlerPipelineStepEditComponentState {
  model?: HandlerPipelineStepViewModel;
  loading: boolean;
  loaded: boolean;
  errorOccurred: boolean;
  errorMessage: string;
}

export default class HandlerPipelineStepEditComponent extends React.Component<
  HandlerPipelineStepEditComponentProps,
  HandlerPipelineStepEditComponentState
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
          ApiRoutes.HandlerPipelineSteps +
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
          let response = resp.data as Api.HandlerPipelineStepClientResponseModel;

          console.log(response);

          let mapper = new HandlerPipelineStepMapper();

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
      return <HandlerPipelineStepEdit model={this.state.model} />;
    } else {
      return null;
    }
  }
}


/*<Codenesium>
    <Hash>14af6cc9f150449b45106772b8df9909</Hash>
</Codenesium>*/