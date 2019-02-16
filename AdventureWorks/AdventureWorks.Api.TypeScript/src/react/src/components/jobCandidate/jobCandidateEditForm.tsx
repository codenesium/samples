import React, { Component } from 'react';
import axios from 'axios';
import * as Api from '../../api/models';
import { UpdateResponse } from '../../api/ApiObjects';
import Constants from '../../constants';
import { FormikProps, FormikErrors, Field, withFormik } from 'formik';
import JobCandidateViewModel from './jobCandidateViewModel';
import JobCandidateMapper from './jobCandidateMapper';

interface Props {
  model?: JobCandidateViewModel;
}

const JobCandidateEditDisplay = (props: FormikProps<JobCandidateViewModel>) => {
  let status = props.status as UpdateResponse<
    Api.JobCandidateClientRequestModel
  >;

  let errorsForField = (name: string): string => {
    let response = '';
    if (
      props.touched[name as keyof JobCandidateViewModel] &&
      props.errors[name as keyof JobCandidateViewModel]
    ) {
      response += props.errors[name as keyof JobCandidateViewModel];
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
            errorExistForField('jobCandidateID')
              ? 'col-sm-2 col-form-label is-invalid'
              : 'col-sm-2 col-form-label'
          }
        >
          JobCandidateID
        </label>
        <div className="col-sm-12">
          <Field
            type="datetime-local"
            name="jobCandidateID"
            className={
              errorExistForField('jobCandidateID')
                ? 'form-control is-invalid'
                : 'form-control'
            }
          />
          {errorExistForField('jobCandidateID') && (
            <small className="text-danger">
              {errorsForField('jobCandidateID')}
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
            errorExistForField('resume')
              ? 'col-sm-2 col-form-label is-invalid'
              : 'col-sm-2 col-form-label'
          }
        >
          Resume
        </label>
        <div className="col-sm-12">
          <Field
            type="datetime-local"
            name="resume"
            className={
              errorExistForField('resume')
                ? 'form-control is-invalid'
                : 'form-control'
            }
          />
          {errorExistForField('resume') && (
            <small className="text-danger">{errorsForField('resume')}</small>
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

const JobCandidateUpdate = withFormik<Props, JobCandidateViewModel>({
  mapPropsToValues: props => {
    let response = new JobCandidateViewModel();
    response.setProperties(
      props.model!.businessEntityID,
      props.model!.jobCandidateID,
      props.model!.modifiedDate,
      props.model!.resume
    );
    return response;
  },

  // Custom sync validation
  validate: values => {
    let errors: FormikErrors<JobCandidateViewModel> = {};

    if (values.jobCandidateID == 0) {
      errors.jobCandidateID = 'Required';
    }
    if (values.modifiedDate == undefined) {
      errors.modifiedDate = 'Required';
    }

    return errors;
  },
  handleSubmit: (values, actions) => {
    actions.setStatus(undefined);

    let mapper = new JobCandidateMapper();

    axios
      .put(
        Constants.ApiUrl + 'jobcandidates/' + values.jobCandidateID,

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
            Api.JobCandidateClientRequestModel
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

  displayName: 'JobCandidateEdit',
})(JobCandidateEditDisplay);

interface IParams {
  jobCandidateID: number;
}

interface IMatch {
  params: IParams;
}

interface JobCandidateEditComponentProps {
  match: IMatch;
}

interface JobCandidateEditComponentState {
  model?: JobCandidateViewModel;
  loading: boolean;
  loaded: boolean;
  errorOccurred: boolean;
  errorMessage: string;
}

export default class JobCandidateEditComponent extends React.Component<
  JobCandidateEditComponentProps,
  JobCandidateEditComponentState
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
          'jobcandidates/' +
          this.props.match.params.jobCandidateID,
        {
          headers: {
            'Content-Type': 'application/json',
          },
        }
      )
      .then(
        resp => {
          let response = resp.data as Api.JobCandidateClientResponseModel;

          console.log(response);

          let mapper = new JobCandidateMapper();

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
      return <JobCandidateUpdate model={this.state.model} />;
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
    <Hash>c9c16096d77507477c283ddd7acea8ea</Hash>
</Codenesium>*/