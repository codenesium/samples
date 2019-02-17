import React, { Component } from 'react';
import axios from 'axios';
import * as Api from '../../api/models';
import { UpdateResponse } from '../../api/apiObjects';
import { Constants, ApiRoutes, ClientRoutes } from '../../constants';
import { FormikProps, FormikErrors, Field, withFormik } from 'formik';
import { LoadingForm } from '../../lib/components/loadingForm';
import { ErrorForm } from '../../lib/components/errorForm';
import JobCandidateMapper from './jobCandidateMapper';
import JobCandidateViewModel from './jobCandidateViewModel';

interface Props {
  history: any;
  model?: JobCandidateViewModel;
}

const JobCandidateDetailDisplay = (model: Props) => {
  return (
    <form role="form">
      <button
        className="btn btn-primary btn-sm align-middle float-right vertically-center"
        onClick={e => {
          model.history.push(
            ClientRoutes.JobCandidates + '/edit/' + model.model!.jobCandidateID
          );
        }}
      >
        <i className="fas fa-edit" />
      </button>
      <div className="form-group row">
        <label htmlFor="businessEntityID" className={'col-sm-2 col-form-label'}>
          BusinessEntityID
        </label>
        <div className="col-sm-12">{String(model.model!.businessEntityID)}</div>
      </div>
      <div className="form-group row">
        <label htmlFor="jobCandidateID" className={'col-sm-2 col-form-label'}>
          JobCandidateID
        </label>
        <div className="col-sm-12">{String(model.model!.jobCandidateID)}</div>
      </div>
      <div className="form-group row">
        <label htmlFor="modifiedDate" className={'col-sm-2 col-form-label'}>
          ModifiedDate
        </label>
        <div className="col-sm-12">{String(model.model!.modifiedDate)}</div>
      </div>
      <div className="form-group row">
        <label htmlFor="resume" className={'col-sm-2 col-form-label'}>
          Resume
        </label>
        <div className="col-sm-12">{String(model.model!.resume)}</div>
      </div>
    </form>
  );
};

interface IParams {
  jobCandidateID: number;
}

interface IMatch {
  params: IParams;
}

interface JobCandidateDetailComponentProps {
  match: IMatch;
  history: any;
}

interface JobCandidateDetailComponentState {
  model?: JobCandidateViewModel;
  loading: boolean;
  loaded: boolean;
  errorOccurred: boolean;
  errorMessage: string;
}

export default class JobCandidateDetailComponent extends React.Component<
  JobCandidateDetailComponentProps,
  JobCandidateDetailComponentState
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
          ApiRoutes.JobCandidates +
          '/' +
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

          let mapper = new JobCandidateMapper();

          console.log(response);

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
      return (
        <JobCandidateDetailDisplay
          history={this.props.history}
          model={this.state.model}
        />
      );
    } else {
      return null;
    }
  }
}


/*<Codenesium>
    <Hash>293ae1d6273161ab6971ae341678bf0d</Hash>
</Codenesium>*/