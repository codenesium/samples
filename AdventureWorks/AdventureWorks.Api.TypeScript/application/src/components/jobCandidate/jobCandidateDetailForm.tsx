import React, { Component } from 'react';
import axios from 'axios';
import * as Api from '../../api/models';
import { UpdateResponse } from '../../api/ApiObjects';
import Constants from '../../constants';
import { FormikProps, FormikErrors, Field, withFormik } from 'formik';
import JobCandidateMapper from './jobCandidateMapper';
import JobCandidateViewModel from './jobCandidateViewModel';

interface Props {
  model?: JobCandidateViewModel;
}

const JobCandidateDetailDisplay = (model: Props) => {
  return (
    <form role="form">
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
      return <div>loading</div>;
    } else if (this.state.loaded) {
      return <JobCandidateDetailDisplay model={this.state.model} />;
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
    <Hash>e62d32edf04f4383424a5dc13d555225</Hash>
</Codenesium>*/