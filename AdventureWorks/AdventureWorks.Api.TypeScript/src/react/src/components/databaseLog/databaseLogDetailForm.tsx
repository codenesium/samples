import React, { Component } from 'react';
import axios from 'axios';
import * as Api from '../../api/models';
import { UpdateResponse } from '../../api/ApiObjects';
import Constants from '../../constants';
import { FormikProps, FormikErrors, Field, withFormik } from 'formik';
import DatabaseLogMapper from './databaseLogMapper';
import DatabaseLogViewModel from './databaseLogViewModel';

interface Props {
  model?: DatabaseLogViewModel;
}

const DatabaseLogDetailDisplay = (model: Props) => {
  return (
    <form role="form">
      <div className="form-group row">
        <label htmlFor="databaseLogID" className={'col-sm-2 col-form-label'}>
          DatabaseLogID
        </label>
        <div className="col-sm-12">{String(model.model!.databaseLogID)}</div>
      </div>

      <div className="form-group row">
        <label htmlFor="databaseUser" className={'col-sm-2 col-form-label'}>
          DatabaseUser
        </label>
        <div className="col-sm-12">{String(model.model!.databaseUser)}</div>
      </div>

      <div className="form-group row">
        <label htmlFor="postTime" className={'col-sm-2 col-form-label'}>
          PostTime
        </label>
        <div className="col-sm-12">{String(model.model!.postTime)}</div>
      </div>

      <div className="form-group row">
        <label htmlFor="schema" className={'col-sm-2 col-form-label'}>
          Schema
        </label>
        <div className="col-sm-12">{String(model.model!.schema)}</div>
      </div>

      <div className="form-group row">
        <label htmlFor="tsql" className={'col-sm-2 col-form-label'}>
          TSQL
        </label>
        <div className="col-sm-12">{String(model.model!.tsql)}</div>
      </div>

      <div className="form-group row">
        <label htmlFor="xmlEvent" className={'col-sm-2 col-form-label'}>
          XmlEvent
        </label>
        <div className="col-sm-12">{String(model.model!.xmlEvent)}</div>
      </div>
    </form>
  );
};

interface IParams {
  databaseLogID: number;
}

interface IMatch {
  params: IParams;
}

interface DatabaseLogDetailComponentProps {
  match: IMatch;
}

interface DatabaseLogDetailComponentState {
  model?: DatabaseLogViewModel;
  loading: boolean;
  loaded: boolean;
  errorOccurred: boolean;
  errorMessage: string;
}

export default class DatabaseLogDetailComponent extends React.Component<
  DatabaseLogDetailComponentProps,
  DatabaseLogDetailComponentState
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
          'databaselogs/' +
          this.props.match.params.databaseLogID,
        {
          headers: {
            'Content-Type': 'application/json',
          },
        }
      )
      .then(
        resp => {
          let response = resp.data as Api.DatabaseLogClientResponseModel;

          let mapper = new DatabaseLogMapper();

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
      return <DatabaseLogDetailDisplay model={this.state.model} />;
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
    <Hash>88289c0c54dd89b02f7de94113d5af7d</Hash>
</Codenesium>*/