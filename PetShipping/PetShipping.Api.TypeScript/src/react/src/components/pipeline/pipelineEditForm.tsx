import React, { Component } from 'react';
import axios from 'axios';
import * as Api from '../../api/models';
import { UpdateResponse } from '../../api/ApiObjects';
import { Constants, ApiRoutes, ClientRoutes } from '../../constants';
import { FormikProps, FormikErrors, Field, withFormik } from 'formik';
import { LoadingForm } from '../../lib/components/loadingForm';
import { ErrorForm } from '../../lib/components/errorForm';
import PipelineViewModel from './pipelineViewModel';
import PipelineMapper from './pipelineMapper';

interface Props {
  model?: PipelineViewModel;
}

const PipelineEditDisplay = (props: FormikProps<PipelineViewModel>) => {
  let status = props.status as UpdateResponse<Api.PipelineClientRequestModel>;

  let errorsForField = (name: string): string => {
    let response = '';
    if (
      props.touched[name as keyof PipelineViewModel] &&
      props.errors[name as keyof PipelineViewModel]
    ) {
      response += props.errors[name as keyof PipelineViewModel];
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
            errorExistForField('pipelineStatusId')
              ? 'col-sm-2 col-form-label is-invalid'
              : 'col-sm-2 col-form-label'
          }
        >
          PipelineStatusId
        </label>
        <div className="col-sm-12">
          <Field
            type="datetime-local"
            name="pipelineStatusId"
            className={
              errorExistForField('pipelineStatusId')
                ? 'form-control is-invalid'
                : 'form-control'
            }
          />
          {errorExistForField('pipelineStatusId') && (
            <small className="text-danger">
              {errorsForField('pipelineStatusId')}
            </small>
          )}
        </div>
      </div>
      <div className="form-group row">
        <label
          htmlFor="name"
          className={
            errorExistForField('saleId')
              ? 'col-sm-2 col-form-label is-invalid'
              : 'col-sm-2 col-form-label'
          }
        >
          SaleId
        </label>
        <div className="col-sm-12">
          <Field
            type="datetime-local"
            name="saleId"
            className={
              errorExistForField('saleId')
                ? 'form-control is-invalid'
                : 'form-control'
            }
          />
          {errorExistForField('saleId') && (
            <small className="text-danger">{errorsForField('saleId')}</small>
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

const PipelineEdit = withFormik<Props, PipelineViewModel>({
  mapPropsToValues: props => {
    let response = new PipelineViewModel();
    response.setProperties(
      props.model!.id,
      props.model!.pipelineStatusId,
      props.model!.saleId
    );
    return response;
  },

  // Custom sync validation
  validate: values => {
    let errors: FormikErrors<PipelineViewModel> = {};

    if (values.id == 0) {
      errors.id = 'Required';
    }
    if (values.pipelineStatusId == 0) {
      errors.pipelineStatusId = 'Required';
    }
    if (values.saleId == 0) {
      errors.saleId = 'Required';
    }

    return errors;
  },
  handleSubmit: (values, actions) => {
    actions.setStatus(undefined);

    let mapper = new PipelineMapper();

    axios
      .put(
        Constants.ApiEndpoint + ApiRoutes.Pipelines + '/' + values.id,

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
            Api.PipelineClientRequestModel
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

  displayName: 'PipelineEdit',
})(PipelineEditDisplay);

interface IParams {
  id: number;
}

interface IMatch {
  params: IParams;
}

interface PipelineEditComponentProps {
  match: IMatch;
}

interface PipelineEditComponentState {
  model?: PipelineViewModel;
  loading: boolean;
  loaded: boolean;
  errorOccurred: boolean;
  errorMessage: string;
}

export default class PipelineEditComponent extends React.Component<
  PipelineEditComponentProps,
  PipelineEditComponentState
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
          ApiRoutes.Pipelines +
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
          let response = resp.data as Api.PipelineClientResponseModel;

          console.log(response);

          let mapper = new PipelineMapper();

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
      return <PipelineEdit model={this.state.model} />;
    } else {
      return null;
    }
  }
}


/*<Codenesium>
    <Hash>7e5783bca1e7d5e009d69ddbe37a1f10</Hash>
</Codenesium>*/