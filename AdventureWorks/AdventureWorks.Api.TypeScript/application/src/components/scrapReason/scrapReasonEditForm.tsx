import React, { Component } from 'react';
import axios from 'axios';
import * as Api from '../../api/models';
import { UpdateResponse } from '../../api/ApiObjects';
import Constants from '../../constants';
import { FormikProps, FormikErrors, Field, withFormik } from 'formik';
import ScrapReasonViewModel from './scrapReasonViewModel';
import ScrapReasonMapper from './scrapReasonMapper';

interface Props {
  model?: ScrapReasonViewModel;
}

const ScrapReasonEditDisplay = (props: FormikProps<ScrapReasonViewModel>) => {
  let status = props.status as UpdateResponse<
    Api.ScrapReasonClientRequestModel
  >;

  let errorsForField = (name: string): string => {
    let response = '';
    if (
      props.touched[name as keyof ScrapReasonViewModel] &&
      props.errors[name as keyof ScrapReasonViewModel]
    ) {
      response += props.errors[name as keyof ScrapReasonViewModel];
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
            errorExistForField('scrapReasonID')
              ? 'col-sm-2 col-form-label is-invalid'
              : 'col-sm-2 col-form-label'
          }
        >
          ScrapReasonID
        </label>
        <div className="col-sm-12">
          <Field
            type="datetime-local"
            name="scrapReasonID"
            className={
              errorExistForField('scrapReasonID')
                ? 'form-control is-invalid'
                : 'form-control'
            }
          />
          {errorExistForField('scrapReasonID') && (
            <small className="text-danger">
              {errorsForField('scrapReasonID')}
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

const ScrapReasonUpdate = withFormik<Props, ScrapReasonViewModel>({
  mapPropsToValues: props => {
    let response = new ScrapReasonViewModel();
    response.setProperties(
      props.model!.modifiedDate,
      props.model!.name,
      props.model!.scrapReasonID
    );
    return response;
  },

  // Custom sync validation
  validate: values => {
    let errors: FormikErrors<ScrapReasonViewModel> = {};

    if (values.modifiedDate == undefined) {
      errors.modifiedDate = 'Required';
    }
    if (values.name == '') {
      errors.name = 'Required';
    }
    if (values.scrapReasonID == 0) {
      errors.scrapReasonID = 'Required';
    }

    return errors;
  },
  handleSubmit: (values, actions) => {
    actions.setStatus(undefined);

    let mapper = new ScrapReasonMapper();

    axios
      .put(
        Constants.ApiUrl + 'scrapreasons/' + values.scrapReasonID,

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
            Api.ScrapReasonClientRequestModel
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

  displayName: 'ScrapReasonEdit',
})(ScrapReasonEditDisplay);

interface IParams {
  scrapReasonID: number;
}

interface IMatch {
  params: IParams;
}

interface ScrapReasonEditComponentProps {
  match: IMatch;
}

interface ScrapReasonEditComponentState {
  model?: ScrapReasonViewModel;
  loading: boolean;
  loaded: boolean;
  errorOccurred: boolean;
  errorMessage: string;
}

export default class ScrapReasonEditComponent extends React.Component<
  ScrapReasonEditComponentProps,
  ScrapReasonEditComponentState
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
          'scrapreasons/' +
          this.props.match.params.scrapReasonID,
        {
          headers: {
            'Content-Type': 'application/json',
          },
        }
      )
      .then(
        resp => {
          let response = resp.data as Api.ScrapReasonClientResponseModel;

          console.log(response);

          let mapper = new ScrapReasonMapper();

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
      return <ScrapReasonUpdate model={this.state.model} />;
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
    <Hash>89a2025848da75db8805955151f25343</Hash>
</Codenesium>*/