import React, { Component } from 'react';
import axios from 'axios';
import * as Api from '../../api/models';
import { UpdateResponse } from '../../api/ApiObjects';
import Constants from '../../constants';
import { FormikProps, FormikErrors, Field, withFormik } from 'formik';
import StoreViewModel from './storeViewModel';
import StoreMapper from './storeMapper';

interface Props {
  model?: StoreViewModel;
}

const StoreEditDisplay = (props: FormikProps<StoreViewModel>) => {
  let status = props.status as UpdateResponse<Api.StoreClientRequestModel>;

  let errorsForField = (name: string): string => {
    let response = '';
    if (
      props.touched[name as keyof StoreViewModel] &&
      props.errors[name as keyof StoreViewModel]
    ) {
      response += props.errors[name as keyof StoreViewModel];
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
            errorExistForField('businessEntityID')
              ? 'col-sm-2 col-form-label is-invalid'
              : 'col-sm-2 col-form-label'
          }
        >
          BusinessEntityID
        </label>
        <div className="col-sm-12">
          <Field
            type="datetime-local"
            name="businessEntityID"
            className={
              errorExistForField('businessEntityID')
                ? 'form-control is-invalid'
                : 'form-control'
            }
          />
          {errorExistForField('businessEntityID') && (
            <small className="text-danger">
              {errorsForField('businessEntityID')}
            </small>
          )}
        </div>
      </div>
      <div className="form-group row">
        <label
          htmlFor="name"
          className={
            errorExistForField('demographic')
              ? 'col-sm-2 col-form-label is-invalid'
              : 'col-sm-2 col-form-label'
          }
        >
          Demographics
        </label>
        <div className="col-sm-12">
          <Field
            type="datetime-local"
            name="demographic"
            className={
              errorExistForField('demographic')
                ? 'form-control is-invalid'
                : 'form-control'
            }
          />
          {errorExistForField('demographic') && (
            <small className="text-danger">
              {errorsForField('demographic')}
            </small>
          )}
        </div>
      </div>
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
            errorExistForField('rowguid')
              ? 'col-sm-2 col-form-label is-invalid'
              : 'col-sm-2 col-form-label'
          }
        >
          Rowguid
        </label>
        <div className="col-sm-12">
          <Field
            type="datetime-local"
            name="rowguid"
            className={
              errorExistForField('rowguid')
                ? 'form-control is-invalid'
                : 'form-control'
            }
          />
          {errorExistForField('rowguid') && (
            <small className="text-danger">{errorsForField('rowguid')}</small>
          )}
        </div>
      </div>
      <div className="form-group row">
        <label
          htmlFor="name"
          className={
            errorExistForField('salesPersonID')
              ? 'col-sm-2 col-form-label is-invalid'
              : 'col-sm-2 col-form-label'
          }
        >
          SalesPersonID
        </label>
        <div className="col-sm-12">
          <Field
            type="datetime-local"
            name="salesPersonID"
            className={
              errorExistForField('salesPersonID')
                ? 'form-control is-invalid'
                : 'form-control'
            }
          />
          {errorExistForField('salesPersonID') && (
            <small className="text-danger">
              {errorsForField('salesPersonID')}
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

const StoreUpdate = withFormik<Props, StoreViewModel>({
  mapPropsToValues: props => {
    let response = new StoreViewModel();
    response.setProperties(
      props.model!.businessEntityID,
      props.model!.demographic,
      props.model!.modifiedDate,
      props.model!.name,
      props.model!.rowguid,
      props.model!.salesPersonID
    );
    return response;
  },

  // Custom sync validation
  validate: values => {
    let errors: FormikErrors<StoreViewModel> = {};

    if (values.businessEntityID == 0) {
      errors.businessEntityID = 'Required';
    }
    if (values.modifiedDate == undefined) {
      errors.modifiedDate = 'Required';
    }
    if (values.name == '') {
      errors.name = 'Required';
    }
    if (values.rowguid == undefined) {
      errors.rowguid = 'Required';
    }

    return errors;
  },
  handleSubmit: (values, actions) => {
    actions.setStatus(undefined);

    let mapper = new StoreMapper();

    axios
      .put(
        Constants.ApiUrl + 'stores/' + values.businessEntityID,

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
            Api.StoreClientRequestModel
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

  displayName: 'StoreEdit',
})(StoreEditDisplay);

interface IParams {
  businessEntityID: number;
}

interface IMatch {
  params: IParams;
}

interface StoreEditComponentProps {
  match: IMatch;
}

interface StoreEditComponentState {
  model?: StoreViewModel;
  loading: boolean;
  loaded: boolean;
  errorOccurred: boolean;
  errorMessage: string;
}

export default class StoreEditComponent extends React.Component<
  StoreEditComponentProps,
  StoreEditComponentState
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
        Constants.ApiUrl + 'stores/' + this.props.match.params.businessEntityID,
        {
          headers: {
            'Content-Type': 'application/json',
          },
        }
      )
      .then(
        resp => {
          let response = resp.data as Api.StoreClientResponseModel;

          console.log(response);

          let mapper = new StoreMapper();

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
      return <div>loading</div>;
    } else if (this.state.loaded) {
      return <StoreUpdate model={this.state.model} />;
    } else if (this.state.errorOccurred) {
      return (
        <div className="alert alert-danger">{this.state.errorMessage}</div>
      );
    } else {
      return <div />;
    }
  }
}


/*<Codenesium>
    <Hash>50edc7b5502b63e01e887ce44fd5f7f2</Hash>
</Codenesium>*/