import React, { Component } from 'react';
import axios from 'axios';
import * as Api from '../../api/models';
import { UpdateResponse } from '../../api/ApiObjects';
import { Constants, ApiRoutes, ClientRoutes } from '../../constants';
import { FormikProps, FormikErrors, Field, withFormik } from 'formik';
import { LoadingForm } from '../../lib/components/loadingForm';
import { ErrorForm } from '../../lib/components/errorForm';
import RowVersionCheckViewModel from './rowVersionCheckViewModel';
import RowVersionCheckMapper from './rowVersionCheckMapper';

interface Props {
  model?: RowVersionCheckViewModel;
}

const RowVersionCheckEditDisplay = (
  props: FormikProps<RowVersionCheckViewModel>
) => {
  let status = props.status as UpdateResponse<
    Api.RowVersionCheckClientRequestModel
  >;

  let errorsForField = (name: string): string => {
    let response = '';
    if (
      props.touched[name as keyof RowVersionCheckViewModel] &&
      props.errors[name as keyof RowVersionCheckViewModel]
    ) {
      response += props.errors[name as keyof RowVersionCheckViewModel];
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
            type="textbox"
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
            type="textbox"
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
            errorExistForField('rowVersion')
              ? 'col-sm-2 col-form-label is-invalid'
              : 'col-sm-2 col-form-label'
          }
        >
          RowVersion
        </label>
        <div className="col-sm-12">
          <Field
            type="textbox"
            name="rowVersion"
            className={
              errorExistForField('rowVersion')
                ? 'form-control is-invalid'
                : 'form-control'
            }
          />
          {errorExistForField('rowVersion') && (
            <small className="text-danger">
              {errorsForField('rowVersion')}
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

const RowVersionCheckEdit = withFormik<Props, RowVersionCheckViewModel>({
  mapPropsToValues: props => {
    let response = new RowVersionCheckViewModel();
    response.setProperties(
      props.model!.id,
      props.model!.name,
      props.model!.rowVersion
    );
    return response;
  },

  // Custom sync validation
  validate: values => {
    let errors: FormikErrors<RowVersionCheckViewModel> = {};

    if (values.id == 0) {
      errors.id = 'Required';
    }
    if (values.name == '') {
      errors.name = 'Required';
    }
    if (values.rowVersion == undefined) {
      errors.rowVersion = 'Required';
    }

    return errors;
  },
  handleSubmit: (values, actions) => {
    actions.setStatus(undefined);

    let mapper = new RowVersionCheckMapper();

    axios
      .put(
        Constants.ApiEndpoint + ApiRoutes.RowVersionChecks + '/' + values.id,

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
            Api.RowVersionCheckClientRequestModel
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

  displayName: 'RowVersionCheckEdit',
})(RowVersionCheckEditDisplay);

interface IParams {
  id: number;
}

interface IMatch {
  params: IParams;
}

interface RowVersionCheckEditComponentProps {
  match: IMatch;
}

interface RowVersionCheckEditComponentState {
  model?: RowVersionCheckViewModel;
  loading: boolean;
  loaded: boolean;
  errorOccurred: boolean;
  errorMessage: string;
}

export default class RowVersionCheckEditComponent extends React.Component<
  RowVersionCheckEditComponentProps,
  RowVersionCheckEditComponentState
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
          ApiRoutes.RowVersionChecks +
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
          let response = resp.data as Api.RowVersionCheckClientResponseModel;

          console.log(response);

          let mapper = new RowVersionCheckMapper();

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
      return <RowVersionCheckEdit model={this.state.model} />;
    } else {
      return null;
    }
  }
}


/*<Codenesium>
    <Hash>fcdb8804d9371b277b9c5699acfb2587</Hash>
</Codenesium>*/