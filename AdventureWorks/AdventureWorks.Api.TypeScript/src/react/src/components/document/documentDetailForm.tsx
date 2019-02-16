import React, { Component } from 'react';
import axios from 'axios';
import * as Api from '../../api/models';
import { UpdateResponse } from '../../api/ApiObjects';
import Constants from '../../constants';
import { FormikProps, FormikErrors, Field, withFormik } from 'formik';
import DocumentMapper from './documentMapper';
import DocumentViewModel from './documentViewModel';

interface Props {
  model?: DocumentViewModel;
}

const DocumentDetailDisplay = (model: Props) => {
  return (
    <form role="form">
      <div className="form-group row">
        <label htmlFor="changeNumber" className={'col-sm-2 col-form-label'}>
          ChangeNumber
        </label>
        <div className="col-sm-12">{String(model.model!.changeNumber)}</div>
      </div>

      <div className="form-group row">
        <label htmlFor="document1" className={'col-sm-2 col-form-label'}>
          Document
        </label>
        <div className="col-sm-12">{String(model.model!.document1)}</div>
      </div>

      <div className="form-group row">
        <label htmlFor="documentLevel" className={'col-sm-2 col-form-label'}>
          DocumentLevel
        </label>
        <div className="col-sm-12">{String(model.model!.documentLevel)}</div>
      </div>

      <div className="form-group row">
        <label htmlFor="documentSummary" className={'col-sm-2 col-form-label'}>
          DocumentSummary
        </label>
        <div className="col-sm-12">{String(model.model!.documentSummary)}</div>
      </div>

      <div className="form-group row">
        <label htmlFor="fileExtension" className={'col-sm-2 col-form-label'}>
          FileExtension
        </label>
        <div className="col-sm-12">{String(model.model!.fileExtension)}</div>
      </div>

      <div className="form-group row">
        <label htmlFor="fileName" className={'col-sm-2 col-form-label'}>
          FileName
        </label>
        <div className="col-sm-12">{String(model.model!.fileName)}</div>
      </div>

      <div className="form-group row">
        <label htmlFor="folderFlag" className={'col-sm-2 col-form-label'}>
          FolderFlag
        </label>
        <div className="col-sm-12">{String(model.model!.folderFlag)}</div>
      </div>

      <div className="form-group row">
        <label htmlFor="modifiedDate" className={'col-sm-2 col-form-label'}>
          ModifiedDate
        </label>
        <div className="col-sm-12">{String(model.model!.modifiedDate)}</div>
      </div>

      <div className="form-group row">
        <label htmlFor="owner" className={'col-sm-2 col-form-label'}>
          Owner
        </label>
        <div className="col-sm-12">{String(model.model!.owner)}</div>
      </div>

      <div className="form-group row">
        <label htmlFor="revision" className={'col-sm-2 col-form-label'}>
          Revision
        </label>
        <div className="col-sm-12">{String(model.model!.revision)}</div>
      </div>

      <div className="form-group row">
        <label htmlFor="rowguid" className={'col-sm-2 col-form-label'}>
          Rowguid
        </label>
        <div className="col-sm-12">{String(model.model!.rowguid)}</div>
      </div>

      <div className="form-group row">
        <label htmlFor="status" className={'col-sm-2 col-form-label'}>
          Status
        </label>
        <div className="col-sm-12">{String(model.model!.status)}</div>
      </div>

      <div className="form-group row">
        <label htmlFor="title" className={'col-sm-2 col-form-label'}>
          Title
        </label>
        <div className="col-sm-12">{String(model.model!.title)}</div>
      </div>
    </form>
  );
};

interface IParams {
  rowguid: any;
}

interface IMatch {
  params: IParams;
}

interface DocumentDetailComponentProps {
  match: IMatch;
}

interface DocumentDetailComponentState {
  model?: DocumentViewModel;
  loading: boolean;
  loaded: boolean;
  errorOccurred: boolean;
  errorMessage: string;
}

export default class DocumentDetailComponent extends React.Component<
  DocumentDetailComponentProps,
  DocumentDetailComponentState
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
      .get(Constants.ApiUrl + 'documents/' + this.props.match.params.rowguid, {
        headers: {
          'Content-Type': 'application/json',
        },
      })
      .then(
        resp => {
          let response = resp.data as Api.DocumentClientResponseModel;

          let mapper = new DocumentMapper();

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
      return <DocumentDetailDisplay model={this.state.model} />;
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
    <Hash>08651dbd895bbdd5ea93a364c406f2f4</Hash>
</Codenesium>*/