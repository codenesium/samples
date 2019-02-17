import React, { Component } from 'react';
import axios from 'axios';
import * as Api from '../../api/models';
import { UpdateResponse } from '../../api/apiObjects';
import { Constants, ApiRoutes, ClientRoutes } from '../../constants';
import { FormikProps, FormikErrors, Field, withFormik } from 'formik';
import { LoadingForm } from '../../lib/components/loadingForm';
import { ErrorForm } from '../../lib/components/errorForm';
import AWBuildVersionMapper from './aWBuildVersionMapper';
import AWBuildVersionViewModel from './aWBuildVersionViewModel';

interface Props {
  history: any;
  model?: AWBuildVersionViewModel;
}

const AWBuildVersionDetailDisplay = (model: Props) => {
  return (
    <form role="form">
      <button
        className="btn btn-primary btn-sm align-middle float-right vertically-center"
        onClick={e => {
          model.history.push(
            ClientRoutes.AWBuildVersions +
              '/edit/' +
              model.model!.systemInformationID
          );
        }}
      >
        <i className="fas fa-edit" />
      </button>
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
  history: any;
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
        Constants.ApiEndpoint +
          ApiRoutes.AWBuildVersions +
          '/' +
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
      return <LoadingForm />;
    } else if (this.state.errorOccurred) {
      return <ErrorForm message={this.state.errorMessage} />;
    } else if (this.state.loaded) {
      return (
        <AWBuildVersionDetailDisplay
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
    <Hash>ccfe6632b35943c50aa2af695ad75443</Hash>
</Codenesium>*/