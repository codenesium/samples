import React, { Component } from 'react';
import axios from 'axios';
import * as Api from '../../api/models';
import { UpdateResponse } from '../../api/ApiObjects';
import { Constants, ApiRoutes, ClientRoutes } from '../../constants';
import { FormikProps, FormikErrors, Field, withFormik } from 'formik';
import { LoadingForm } from '../../lib/components/loadingForm';
import { ErrorForm } from '../../lib/components/errorForm';
import OtherTransportViewModel from './otherTransportViewModel';
import OtherTransportMapper from './otherTransportMapper';

interface Props {
  model?: OtherTransportViewModel;
}

const OtherTransportEditDisplay = (
  props: FormikProps<OtherTransportViewModel>
) => {
  let status = props.status as UpdateResponse<
    Api.OtherTransportClientRequestModel
  >;

  let errorsForField = (name: string): string => {
    let response = '';
    if (
      props.touched[name as keyof OtherTransportViewModel] &&
      props.errors[name as keyof OtherTransportViewModel]
    ) {
      response += props.errors[name as keyof OtherTransportViewModel];
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

const OtherTransportEdit = withFormik<Props, OtherTransportViewModel>({
  mapPropsToValues: props => {
    let response = new OtherTransportViewModel();
    response.setProperties(
      props.model!.handlerId,
      props.model!.id,
      props.model!.pipelineStepId
    );
    return response;
  },

  // Custom sync validation
  validate: values => {
    let errors: FormikErrors<OtherTransportViewModel> = {};

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

    let mapper = new OtherTransportMapper();

    axios
      .put(
        Constants.ApiEndpoint + ApiRoutes.OtherTransports + '/' + values.id,

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
            Api.OtherTransportClientRequestModel
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

  displayName: 'OtherTransportEdit',
})(OtherTransportEditDisplay);

interface IParams {
  id: number;
}

interface IMatch {
  params: IParams;
}

interface OtherTransportEditComponentProps {
  match: IMatch;
}

interface OtherTransportEditComponentState {
  model?: OtherTransportViewModel;
  loading: boolean;
  loaded: boolean;
  errorOccurred: boolean;
  errorMessage: string;
}

export default class OtherTransportEditComponent extends React.Component<
  OtherTransportEditComponentProps,
  OtherTransportEditComponentState
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
          ApiRoutes.OtherTransports +
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
          let response = resp.data as Api.OtherTransportClientResponseModel;

          console.log(response);

          let mapper = new OtherTransportMapper();

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
      return <OtherTransportEdit model={this.state.model} />;
    } else {
      return null;
    }
  }
}


/*<Codenesium>
    <Hash>928de44a682436d43cfa5fc548046003</Hash>
</Codenesium>*/