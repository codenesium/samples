import React, { Component } from 'react';
import axios from 'axios';
import * as Api from '../../api/models';
import { UpdateResponse } from '../../api/ApiObjects';
import Constants from '../../constants';
import { FormikProps, FormikErrors, Field, withFormik } from 'formik';
import ErrorLogMapper from './errorLogMapper';
import ErrorLogViewModel from './errorLogViewModel';

interface Props {
  model?: ErrorLogViewModel;
}

const ErrorLogDetailDisplay = (model: Props) => {
  return (
    <form role="form">
      <div className="form-group row">
        <label htmlFor="errorLine" className={'col-sm-2 col-form-label'}>
          ErrorLine
        </label>
        <div className="col-sm-12">{String(model.model!.errorLine)}</div>
      </div>

      <div className="form-group row">
        <label htmlFor="errorLogID" className={'col-sm-2 col-form-label'}>
          ErrorLogID
        </label>
        <div className="col-sm-12">{String(model.model!.errorLogID)}</div>
      </div>

      <div className="form-group row">
        <label htmlFor="errorMessage" className={'col-sm-2 col-form-label'}>
          ErrorMessage
        </label>
        <div className="col-sm-12">{String(model.model!.errorMessage)}</div>
      </div>

      <div className="form-group row">
        <label htmlFor="errorNumber" className={'col-sm-2 col-form-label'}>
          ErrorNumber
        </label>
        <div className="col-sm-12">{String(model.model!.errorNumber)}</div>
      </div>

      <div className="form-group row">
        <label htmlFor="errorProcedure" className={'col-sm-2 col-form-label'}>
          ErrorProcedure
        </label>
        <div className="col-sm-12">{String(model.model!.errorProcedure)}</div>
      </div>

      <div className="form-group row">
        <label htmlFor="errorSeverity" className={'col-sm-2 col-form-label'}>
          ErrorSeverity
        </label>
        <div className="col-sm-12">{String(model.model!.errorSeverity)}</div>
      </div>

      <div className="form-group row">
        <label htmlFor="errorState" className={'col-sm-2 col-form-label'}>
          ErrorState
        </label>
        <div className="col-sm-12">{String(model.model!.errorState)}</div>
      </div>

      <div className="form-group row">
        <label htmlFor="errorTime" className={'col-sm-2 col-form-label'}>
          ErrorTime
        </label>
        <div className="col-sm-12">{String(model.model!.errorTime)}</div>
      </div>

      <div className="form-group row">
        <label htmlFor="userName" className={'col-sm-2 col-form-label'}>
          UserName
        </label>
        <div className="col-sm-12">{String(model.model!.userName)}</div>
      </div>
    </form>
  );
};

interface IParams {
  errorLogID: number;
}

interface IMatch {
  params: IParams;
}

interface ErrorLogDetailComponentProps {
  match: IMatch;
}

interface ErrorLogDetailComponentState {
  model?: ErrorLogViewModel;
  loading: boolean;
  loaded: boolean;
  errorOccurred: boolean;
  errorMessage: string;
}

export default class ErrorLogDetailComponent extends React.Component<
  ErrorLogDetailComponentProps,
  ErrorLogDetailComponentState
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
        Constants.ApiUrl + 'errorlogs/' + this.props.match.params.errorLogID,
        {
          headers: {
            'Content-Type': 'application/json',
          },
        }
      )
      .then(
        resp => {
          let response = resp.data as Api.ErrorLogClientResponseModel;

          let mapper = new ErrorLogMapper();

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
      return <ErrorLogDetailDisplay model={this.state.model} />;
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
    <Hash>c4c19c1e0fcef794147df9063a6b0bb8</Hash>
</Codenesium>*/