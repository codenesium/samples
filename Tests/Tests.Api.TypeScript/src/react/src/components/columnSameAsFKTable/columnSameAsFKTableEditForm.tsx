import React, { Component } from 'react';
import axios from 'axios';
import * as Api from '../../api/models';
import { UpdateResponse } from '../../api/apiObjects';
import { Constants, ApiRoutes, ClientRoutes } from '../../constants';
import { FormikProps, FormikErrors, Field, withFormik } from 'formik';
import { LoadingForm } from '../../lib/components/loadingForm';
import { ErrorForm } from '../../lib/components/errorForm';
import ColumnSameAsFKTableViewModel from './columnSameAsFKTableViewModel';
import ColumnSameAsFKTableMapper from './columnSameAsFKTableMapper';

interface Props {
  model?: ColumnSameAsFKTableViewModel;
}

const ColumnSameAsFKTableEditDisplay = (
  props: FormikProps<ColumnSameAsFKTableViewModel>
) => {
  let status = props.status as UpdateResponse<
    Api.ColumnSameAsFKTableClientRequestModel
  >;

  let errorsForField = (name: string): string => {
    let response = '';
    if (
      props.touched[name as keyof ColumnSameAsFKTableViewModel] &&
      props.errors[name as keyof ColumnSameAsFKTableViewModel]
    ) {
      response += props.errors[name as keyof ColumnSameAsFKTableViewModel];
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
            errorExistForField('person')
              ? 'col-sm-2 col-form-label is-invalid'
              : 'col-sm-2 col-form-label'
          }
        >
          Person
        </label>
        <div className="col-sm-12">
          <Field
            type="textbox"
            name="person"
            className={
              errorExistForField('person')
                ? 'form-control is-invalid'
                : 'form-control'
            }
          />
          {errorExistForField('person') && (
            <small className="text-danger">{errorsForField('person')}</small>
          )}
        </div>
      </div>
      <div className="form-group row">
        <label
          htmlFor="name"
          className={
            errorExistForField('personId')
              ? 'col-sm-2 col-form-label is-invalid'
              : 'col-sm-2 col-form-label'
          }
        >
          PersonId
        </label>
        <div className="col-sm-12">
          <Field
            type="textbox"
            name="personId"
            className={
              errorExistForField('personId')
                ? 'form-control is-invalid'
                : 'form-control'
            }
          />
          {errorExistForField('personId') && (
            <small className="text-danger">{errorsForField('personId')}</small>
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

const ColumnSameAsFKTableEdit = withFormik<Props, ColumnSameAsFKTableViewModel>(
  {
    mapPropsToValues: props => {
      let response = new ColumnSameAsFKTableViewModel();
      response.setProperties(
        props.model!.id,
        props.model!.person,
        props.model!.personId
      );
      return response;
    },

    // Custom sync validation
    validate: values => {
      let errors: FormikErrors<ColumnSameAsFKTableViewModel> = {};

      if (values.id == 0) {
        errors.id = 'Required';
      }
      if (values.person == 0) {
        errors.person = 'Required';
      }
      if (values.personId == 0) {
        errors.personId = 'Required';
      }

      return errors;
    },
    handleSubmit: (values, actions) => {
      actions.setStatus(undefined);

      let mapper = new ColumnSameAsFKTableMapper();

      axios
        .put(
          Constants.ApiEndpoint +
            ApiRoutes.ColumnSameAsFKTables +
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
              Api.ColumnSameAsFKTableClientRequestModel
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

    displayName: 'ColumnSameAsFKTableEdit',
  }
)(ColumnSameAsFKTableEditDisplay);

interface IParams {
  id: number;
}

interface IMatch {
  params: IParams;
}

interface ColumnSameAsFKTableEditComponentProps {
  match: IMatch;
}

interface ColumnSameAsFKTableEditComponentState {
  model?: ColumnSameAsFKTableViewModel;
  loading: boolean;
  loaded: boolean;
  errorOccurred: boolean;
  errorMessage: string;
}

export default class ColumnSameAsFKTableEditComponent extends React.Component<
  ColumnSameAsFKTableEditComponentProps,
  ColumnSameAsFKTableEditComponentState
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
          ApiRoutes.ColumnSameAsFKTables +
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
          let response = resp.data as Api.ColumnSameAsFKTableClientResponseModel;

          console.log(response);

          let mapper = new ColumnSameAsFKTableMapper();

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
      return <ColumnSameAsFKTableEdit model={this.state.model} />;
    } else {
      return null;
    }
  }
}


/*<Codenesium>
    <Hash>d1884a011deae1ad9134df9fee779112</Hash>
</Codenesium>*/