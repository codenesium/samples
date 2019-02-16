import React, { Component } from 'react';
import axios from 'axios';
import * as Api from '../../api/models';
import { UpdateResponse } from '../../api/ApiObjects';
import Constants from '../../constants';
import { FormikProps, FormikErrors, Field, withFormik } from 'formik';
import IllustrationViewModel from './illustrationViewModel';
import IllustrationMapper from './illustrationMapper';

interface Props {
  model?: IllustrationViewModel;
}

const IllustrationEditDisplay = (props: FormikProps<IllustrationViewModel>) => {
  let status = props.status as UpdateResponse<
    Api.IllustrationClientRequestModel
  >;

  let errorsForField = (name: string): string => {
    let response = '';
    if (
      props.touched[name as keyof IllustrationViewModel] &&
      props.errors[name as keyof IllustrationViewModel]
    ) {
      response += props.errors[name as keyof IllustrationViewModel];
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
            errorExistForField('diagram')
              ? 'col-sm-2 col-form-label is-invalid'
              : 'col-sm-2 col-form-label'
          }
        >
          Diagram
        </label>
        <div className="col-sm-12">
          <Field
            type="datetime-local"
            name="diagram"
            className={
              errorExistForField('diagram')
                ? 'form-control is-invalid'
                : 'form-control'
            }
          />
          {errorExistForField('diagram') && (
            <small className="text-danger">{errorsForField('diagram')}</small>
          )}
        </div>
      </div>
      <div className="form-group row">
        <label
          htmlFor="name"
          className={
            errorExistForField('illustrationID')
              ? 'col-sm-2 col-form-label is-invalid'
              : 'col-sm-2 col-form-label'
          }
        >
          IllustrationID
        </label>
        <div className="col-sm-12">
          <Field
            type="datetime-local"
            name="illustrationID"
            className={
              errorExistForField('illustrationID')
                ? 'form-control is-invalid'
                : 'form-control'
            }
          />
          {errorExistForField('illustrationID') && (
            <small className="text-danger">
              {errorsForField('illustrationID')}
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

const IllustrationUpdate = withFormik<Props, IllustrationViewModel>({
  mapPropsToValues: props => {
    let response = new IllustrationViewModel();
    response.setProperties(
      props.model!.diagram,
      props.model!.illustrationID,
      props.model!.modifiedDate
    );
    return response;
  },

  // Custom sync validation
  validate: values => {
    let errors: FormikErrors<IllustrationViewModel> = {};

    if (values.illustrationID == 0) {
      errors.illustrationID = 'Required';
    }
    if (values.modifiedDate == undefined) {
      errors.modifiedDate = 'Required';
    }

    return errors;
  },
  handleSubmit: (values, actions) => {
    actions.setStatus(undefined);

    let mapper = new IllustrationMapper();

    axios
      .put(
        Constants.ApiUrl + 'illustrations/' + values.illustrationID,

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
            Api.IllustrationClientRequestModel
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

  displayName: 'IllustrationEdit',
})(IllustrationEditDisplay);

interface IParams {
  illustrationID: number;
}

interface IMatch {
  params: IParams;
}

interface IllustrationEditComponentProps {
  match: IMatch;
}

interface IllustrationEditComponentState {
  model?: IllustrationViewModel;
  loading: boolean;
  loaded: boolean;
  errorOccurred: boolean;
  errorMessage: string;
}

export default class IllustrationEditComponent extends React.Component<
  IllustrationEditComponentProps,
  IllustrationEditComponentState
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
        Constants.ApiUrl +
          'illustrations/' +
          this.props.match.params.illustrationID,
        {
          headers: {
            'Content-Type': 'application/json',
          },
        }
      )
      .then(
        resp => {
          let response = resp.data as Api.IllustrationClientResponseModel;

          console.log(response);

          let mapper = new IllustrationMapper();

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
      return <IllustrationUpdate model={this.state.model} />;
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
    <Hash>d071b55f7d475bdc67fea5cbee45642a</Hash>
</Codenesium>*/