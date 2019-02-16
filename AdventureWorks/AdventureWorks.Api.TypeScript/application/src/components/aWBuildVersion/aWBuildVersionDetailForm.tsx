import React, { Component } from 'react';
import axios from 'axios';
import * as Api from '../../api/models';
import { UpdateResponse } from '../../api/ApiObjects';
import Constants from '../../constants';
import { FormikProps, FormikErrors, Field, withFormik } from 'formik';
import AWBuildVersionMapper from './aWBuildVersionMapper';
import AWBuildVersionViewModel from './aWBuildVersionViewModel';

interface Props {
  model?: AWBuildVersionViewModel;
}

const AWBuildVersionDetailDisplay = (model: Props) => {
  return (
    <form role="form">
      <div className="form-group row">
        <label htmlFor="database_Version" className={'col-sm-2 col-form-label'}>
          Database Version
        </label>
        <div className="col-sm-12">{String(model.model!.database_Version)}</div>
      </div>

      <div className="form-group row">
        <label htmlFor="modifiedDate" className={'col-sm-2 col-form-label'}>
          ModifiedDate
        </label>
        <div className="col-sm-12">{String(model.model!.modifiedDate)}</div>
      </div>

      <div className="form-group row">
        <label
          htmlFor="systemInformationID"
          className={'col-sm-2 col-form-label'}
        >
          SystemInformationID
        </label>
        <div className="col-sm-12">
          {String(model.model!.systemInformationID)}
        </div>
      </div>

      <div className="form-group row">
        <label htmlFor="versionDate" className={'col-sm-2 col-form-label'}>
          VersionDate
        </label>
        <div className="col-sm-12">{String(model.model!.versionDate)}</div>
      </div>
    </form>
  );
};

interface IParams {
  systemInformationID: number;
}

interface IMatch {
  params: IParams;
}

interface AWBuildVersionDetailComponentProps {
  match: IMatch;
}

interface AWBuildVersionDetailComponentState {
  model?: AWBuildVersionViewModel;
  loading: boolean;
  loaded: boolean;
  errorOccurred: boolean;
  errorMessage: string;
}

export default class AWBuildVersionDetailComponent extends React.Component<
  AWBuildVersionDetailComponentProps,
  AWBuildVersionDetailComponentState
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
          'awbuildversions/' +
          this.props.match.params.systemInformationID,
        {
          headers: {
            'Content-Type': 'application/json',
          },
        }
      )
      .then(
        resp => {
          let response = resp.data as Api.AWBuildVersionClientResponseModel;

          let mapper = new AWBuildVersionMapper();

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
      return <AWBuildVersionDetailDisplay model={this.state.model} />;
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
    <Hash>eeb93dfa011d910b30e1da6f45e89e49</Hash>
</Codenesium>*/