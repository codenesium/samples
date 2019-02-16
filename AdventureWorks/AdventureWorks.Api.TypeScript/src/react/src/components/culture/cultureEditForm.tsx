import React, { Component } from 'react';
import axios from 'axios';
import * as Api from '../../api/models';
import { UpdateResponse } from '../../api/ApiObjects';
import Constants from '../../constants';
import { FormikProps, FormikErrors, Field, withFormik } from 'formik';
import CultureViewModel from './cultureViewModel';
import CultureMapper from './cultureMapper';

interface Props {
  model?: CultureViewModel;
}

const CultureEditDisplay = (props: FormikProps<CultureViewModel>) => {
  let status = props.status as UpdateResponse<Api.CultureClientRequestModel>;

  let errorsForField = (name: string): string => {
    let response = '';
    if (
      props.touched[name as keyof CultureViewModel] &&
      props.errors[name as keyof CultureViewModel]
    ) {
      response += props.errors[name as keyof CultureViewModel];
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
            errorExistForField('cultureID')
              ? 'col-sm-2 col-form-label is-invalid'
              : 'col-sm-2 col-form-label'
          }
        >
          CultureID
        </label>
        <div className="col-sm-12">
          <Field
            type="datetime-local"
            name="cultureID"
            className={
              errorExistForField('cultureID')
                ? 'form-control is-invalid'
                : 'form-control'
            }
          />
          {errorExistForField('cultureID') && (
            <small className="text-danger">{errorsForField('cultureID')}</small>
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

const CultureUpdate = withFormik<Props, CultureViewModel>({
  mapPropsToValues: props => {
    let response = new CultureViewModel();
    response.setProperties(
      props.model!.cultureID,
      props.model!.modifiedDate,
      props.model!.name
    );
    return response;
  },

  // Custom sync validation
  validate: values => {
    let errors: FormikErrors<CultureViewModel> = {};

    if (values.cultureID == '') {
      errors.cultureID = 'Required';
    }
    if (values.modifiedDate == undefined) {
      errors.modifiedDate = 'Required';
    }
    if (values.name == '') {
      errors.name = 'Required';
    }

    return errors;
  },
  handleSubmit: (values, actions) => {
    actions.setStatus(undefined);

    let mapper = new CultureMapper();

    axios
      .put(
        Constants.ApiUrl + 'cultures/' + values.cultureID,

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
            Api.CultureClientRequestModel
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

  displayName: 'CultureEdit',
})(CultureEditDisplay);

interface IParams {
  cultureID: string;
}

interface IMatch {
  params: IParams;
}

interface CultureEditComponentProps {
  match: IMatch;
}

interface CultureEditComponentState {
  model?: CultureViewModel;
  loading: boolean;
  loaded: boolean;
  errorOccurred: boolean;
  errorMessage: string;
}

export default class CultureEditComponent extends React.Component<
  CultureEditComponentProps,
  CultureEditComponentState
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
      .get(Constants.ApiUrl + 'cultures/' + this.props.match.params.cultureID, {
        headers: {
          'Content-Type': 'application/json',
        },
      })
      .then(
        resp => {
          let response = resp.data as Api.CultureClientResponseModel;

          console.log(response);

          let mapper = new CultureMapper();

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
      return <CultureUpdate model={this.state.model} />;
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
    <Hash>d70606bc7af57a396dba2a31ec42ef3e</Hash>
</Codenesium>*/