import React, { Component } from 'react';
import axios from 'axios';
import * as Api from '../../api/models';
import { UpdateResponse } from '../../api/apiObjects';
import { Constants, ApiRoutes, ClientRoutes } from '../../constants';
import { FormikProps, FormikErrors, Field, withFormik } from 'formik';
import { LoadingForm } from '../../lib/components/loadingForm';
import { ErrorForm } from '../../lib/components/errorForm';
import SalesReasonViewModel from './salesReasonViewModel';
import SalesReasonMapper from './salesReasonMapper';

interface Props {
  model?: SalesReasonViewModel;
}

const SalesReasonEditDisplay = (props: FormikProps<SalesReasonViewModel>) => {
  let status = props.status as UpdateResponse<
    Api.SalesReasonClientRequestModel
  >;

  let errorsForField = (name: string): string => {
    let response = '';
    if (
      props.touched[name as keyof SalesReasonViewModel] &&
      props.errors[name as keyof SalesReasonViewModel]
    ) {
      response += props.errors[name as keyof SalesReasonViewModel];
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
            errorExistForField('reasonType')
              ? 'col-sm-2 col-form-label is-invalid'
              : 'col-sm-2 col-form-label'
          }
        >
          ReasonType
        </label>
        <div className="col-sm-12">
          <Field
            type="datetime-local"
            name="reasonType"
            className={
              errorExistForField('reasonType')
                ? 'form-control is-invalid'
                : 'form-control'
            }
          />
          {errorExistForField('reasonType') && (
            <small className="text-danger">
              {errorsForField('reasonType')}
            </small>
          )}
        </div>
      </div>
      <div className="form-group row">
        <label
          htmlFor="name"
          className={
            errorExistForField('salesReasonID')
              ? 'col-sm-2 col-form-label is-invalid'
              : 'col-sm-2 col-form-label'
          }
        >
          SalesReasonID
        </label>
        <div className="col-sm-12">
          <Field
            type="datetime-local"
            name="salesReasonID"
            className={
              errorExistForField('salesReasonID')
                ? 'form-control is-invalid'
                : 'form-control'
            }
          />
          {errorExistForField('salesReasonID') && (
            <small className="text-danger">
              {errorsForField('salesReasonID')}
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

const SalesReasonEdit = withFormik<Props, SalesReasonViewModel>({
  mapPropsToValues: props => {
    let response = new SalesReasonViewModel();
    response.setProperties(
      props.model!.modifiedDate,
      props.model!.name,
      props.model!.reasonType,
      props.model!.salesReasonID
    );
    return response;
  },

  // Custom sync validation
  validate: values => {
    let errors: FormikErrors<SalesReasonViewModel> = {};

    if (values.modifiedDate == undefined) {
      errors.modifiedDate = 'Required';
    }
    if (values.name == '') {
      errors.name = 'Required';
    }
    if (values.reasonType == '') {
      errors.reasonType = 'Required';
    }
    if (values.salesReasonID == 0) {
      errors.salesReasonID = 'Required';
    }

    return errors;
  },
  handleSubmit: (values, actions) => {
    actions.setStatus(undefined);

    let mapper = new SalesReasonMapper();

    axios
      .put(
        Constants.ApiEndpoint +
          ApiRoutes.SalesReasons +
          '/' +
          values.salesReasonID,

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
            Api.SalesReasonClientRequestModel
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

  displayName: 'SalesReasonEdit',
})(SalesReasonEditDisplay);

interface IParams {
  salesReasonID: number;
}

interface IMatch {
  params: IParams;
}

interface SalesReasonEditComponentProps {
  match: IMatch;
}

interface SalesReasonEditComponentState {
  model?: SalesReasonViewModel;
  loading: boolean;
  loaded: boolean;
  errorOccurred: boolean;
  errorMessage: string;
}

export default class SalesReasonEditComponent extends React.Component<
  SalesReasonEditComponentProps,
  SalesReasonEditComponentState
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
          ApiRoutes.SalesReasons +
          '/' +
          this.props.match.params.salesReasonID,
        {
          headers: {
            'Content-Type': 'application/json',
          },
        }
      )
      .then(
        resp => {
          let response = resp.data as Api.SalesReasonClientResponseModel;

          console.log(response);

          let mapper = new SalesReasonMapper();

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
      return <SalesReasonEdit model={this.state.model} />;
    } else {
      return null;
    }
  }
}


/*<Codenesium>
    <Hash>92b5ec52c6c458c867296739173a2ff3</Hash>
</Codenesium>*/