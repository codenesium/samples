import React, { Component } from 'react';
import axios from 'axios';
import * as Api from '../../api/models';
import { UpdateResponse } from '../../api/ApiObjects';
import { Constants, ApiRoutes, ClientRoutes } from '../../constants';
import { FormikProps, FormikErrors, Field, withFormik } from 'formik';
import { LoadingForm } from '../../lib/components/loadingForm';
import { ErrorForm } from '../../lib/components/errorForm';
import FileMapper from './fileMapper';
import FileViewModel from './fileViewModel';

interface Props {
  history: any;
  model?: FileViewModel;
}

const FileDetailDisplay = (model: Props) => {
  return (
    <form role="form">
      <button
        className="btn btn-primary btn-sm align-middle float-right vertically-center"
        onClick={e => {
          model.history.push(ClientRoutes.Files + '/edit/' + model.model!.id);
        }}
      >
        <i className="fas fa-edit" />
      </button>
      <div className="form-group row">
        <label htmlFor="bucketId" className={'col-sm-2 col-form-label'}>
          BucketId
        </label>
        <div className="col-sm-12">
          {model.model!.bucketIdNavigation!.toDisplay()}
        </div>
      </div>
      <div className="form-group row">
        <label htmlFor="dateCreated" className={'col-sm-2 col-form-label'}>
          DateCreated
        </label>
        <div className="col-sm-12">{String(model.model!.dateCreated)}</div>
      </div>
      <div className="form-group row">
        <label htmlFor="description" className={'col-sm-2 col-form-label'}>
          Description
        </label>
        <div className="col-sm-12">{String(model.model!.description)}</div>
      </div>
      <div className="form-group row">
        <label htmlFor="expiration" className={'col-sm-2 col-form-label'}>
          Expiration
        </label>
        <div className="col-sm-12">{String(model.model!.expiration)}</div>
      </div>
      <div className="form-group row">
        <label htmlFor="extension" className={'col-sm-2 col-form-label'}>
          Extension
        </label>
        <div className="col-sm-12">{String(model.model!.extension)}</div>
      </div>
      <div className="form-group row">
        <label htmlFor="externalId" className={'col-sm-2 col-form-label'}>
          ExternalId
        </label>
        <div className="col-sm-12">{String(model.model!.externalId)}</div>
      </div>
      <div className="form-group row">
        <label htmlFor="fileSizeInByte" className={'col-sm-2 col-form-label'}>
          FileSizeInByte
        </label>
        <div className="col-sm-12">{String(model.model!.fileSizeInByte)}</div>
      </div>
      <div className="form-group row">
        <label htmlFor="fileTypeId" className={'col-sm-2 col-form-label'}>
          FileTypeId
        </label>
        <div className="col-sm-12">
          {model.model!.fileTypeIdNavigation!.toDisplay()}
        </div>
      </div>
      <div className="form-group row">
        <label htmlFor="id" className={'col-sm-2 col-form-label'}>
          Id
        </label>
        <div className="col-sm-12">{String(model.model!.id)}</div>
      </div>
      <div className="form-group row">
        <label htmlFor="location" className={'col-sm-2 col-form-label'}>
          Location
        </label>
        <div className="col-sm-12">{String(model.model!.location)}</div>
      </div>
      <div className="form-group row">
        <label htmlFor="privateKey" className={'col-sm-2 col-form-label'}>
          PrivateKey
        </label>
        <div className="col-sm-12">{String(model.model!.privateKey)}</div>
      </div>
      <div className="form-group row">
        <label htmlFor="publicKey" className={'col-sm-2 col-form-label'}>
          PublicKey
        </label>
        <div className="col-sm-12">{String(model.model!.publicKey)}</div>
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

interface FileDetailComponentProps {
  match: IMatch;
  history: any;
}

interface FileDetailComponentState {
  model?: FileViewModel;
  loading: boolean;
  loaded: boolean;
  errorOccurred: boolean;
  errorMessage: string;
}

export default class FileDetailComponent extends React.Component<
  FileDetailComponentProps,
  FileDetailComponentState
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
          ApiRoutes.Files +
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
          let response = resp.data as Api.FileClientResponseModel;

          let mapper = new FileMapper();

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
        <FileDetailDisplay
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
    <Hash>dd279cf97fd9a97df743549419560aad</Hash>
</Codenesium>*/