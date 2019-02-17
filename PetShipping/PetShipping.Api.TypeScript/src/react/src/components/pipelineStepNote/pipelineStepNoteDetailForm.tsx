import React, { Component } from 'react';
import axios from 'axios';
import * as Api from '../../api/models';
import { UpdateResponse } from '../../api/apiObjects';
import { Constants, ApiRoutes, ClientRoutes } from '../../constants';
import { FormikProps, FormikErrors, Field, withFormik } from 'formik';
import { LoadingForm } from '../../lib/components/loadingForm';
import { ErrorForm } from '../../lib/components/errorForm';
import PipelineStepNoteMapper from './pipelineStepNoteMapper';
import PipelineStepNoteViewModel from './pipelineStepNoteViewModel';

interface Props {
  history: any;
  model?: PipelineStepNoteViewModel;
}

const PipelineStepNoteDetailDisplay = (model: Props) => {
  return (
    <form role="form">
      <button
        className="btn btn-primary btn-sm align-middle float-right vertically-center"
        onClick={e => {
          model.history.push(
            ClientRoutes.PipelineStepNotes + '/edit/' + model.model!.id
          );
        }}
      >
        <i className="fas fa-edit" />
      </button>
      <div className="form-group row">
        <label htmlFor="employeeId" className={'col-sm-2 col-form-label'}>
          EmployeeId
        </label>
        <div className="col-sm-12">
          {model.model!.employeeIdNavigation!.toDisplay()}
        </div>
      </div>
      <div className="form-group row">
        <label htmlFor="id" className={'col-sm-2 col-form-label'}>
          Id
        </label>
        <div className="col-sm-12">{String(model.model!.id)}</div>
      </div>
      <div className="form-group row">
        <label htmlFor="note" className={'col-sm-2 col-form-label'}>
          Note
        </label>
        <div className="col-sm-12">{String(model.model!.note)}</div>
      </div>
      <div className="form-group row">
        <label htmlFor="pipelineStepId" className={'col-sm-2 col-form-label'}>
          PipelineStepId
        </label>
        <div className="col-sm-12">
          {model.model!.pipelineStepIdNavigation!.toDisplay()}
        </div>
      </div>
    </form>
  );
};

interface IParams {
  id: number;
}

interface IMatch {
  params: IParams;
}

interface PipelineStepNoteDetailComponentProps {
  match: IMatch;
  history: any;
}

interface PipelineStepNoteDetailComponentState {
  model?: PipelineStepNoteViewModel;
  loading: boolean;
  loaded: boolean;
  errorOccurred: boolean;
  errorMessage: string;
}

export default class PipelineStepNoteDetailComponent extends React.Component<
  PipelineStepNoteDetailComponentProps,
  PipelineStepNoteDetailComponentState
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
          ApiRoutes.PipelineStepNotes +
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
          let response = resp.data as Api.PipelineStepNoteClientResponseModel;

          let mapper = new PipelineStepNoteMapper();

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
        <PipelineStepNoteDetailDisplay
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
    <Hash>1e7652ca4967b15cbd8e73b478e00af4</Hash>
</Codenesium>*/