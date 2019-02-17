import React, { Component } from 'react';
import axios from 'axios';
import * as Api from '../../api/models';
import { UpdateResponse } from '../../api/apiObjects';
import { Constants, ApiRoutes, ClientRoutes } from '../../constants';
import { FormikProps, FormikErrors, Field, withFormik } from 'formik';
import { LoadingForm } from '../../lib/components/loadingForm';
import { ErrorForm } from '../../lib/components/errorForm';
import DocumentViewModel from './documentViewModel';
import DocumentMapper from './documentMapper';

interface Props {
  model?: DocumentViewModel;
}

const DocumentEditDisplay = (props: FormikProps<DocumentViewModel>) => {
  let status = props.status as UpdateResponse<Api.DocumentClientRequestModel>;

  let errorsForField = (name: string): string => {
    let response = '';
    if (
      props.touched[name as keyof DocumentViewModel] &&
      props.errors[name as keyof DocumentViewModel]
    ) {
      response += props.errors[name as keyof DocumentViewModel];
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
            errorExistForField('changeNumber')
              ? 'col-sm-2 col-form-label is-invalid'
              : 'col-sm-2 col-form-label'
          }
        >
          ChangeNumber
        </label>
        <div className="col-sm-12">
          <Field
            type="datetime-local"
            name="changeNumber"
            className={
              errorExistForField('changeNumber')
                ? 'form-control is-invalid'
                : 'form-control'
            }
          />
          {errorExistForField('changeNumber') && (
            <small className="text-danger">
              {errorsForField('changeNumber')}
            </small>
          )}
        </div>
      </div>
      <div className="form-group row">
        <label
          htmlFor="name"
          className={
            errorExistForField('document1')
              ? 'col-sm-2 col-form-label is-invalid'
              : 'col-sm-2 col-form-label'
          }
        >
          Document
        </label>
        <div className="col-sm-12">
          <Field
            type="datetime-local"
            name="document1"
            className={
              errorExistForField('document1')
                ? 'form-control is-invalid'
                : 'form-control'
            }
          />
          {errorExistForField('document1') && (
            <small className="text-danger">{errorsForField('document1')}</small>
          )}
        </div>
      </div>
      <div className="form-group row">
        <label
          htmlFor="name"
          className={
            errorExistForField('documentLevel')
              ? 'col-sm-2 col-form-label is-invalid'
              : 'col-sm-2 col-form-label'
          }
        >
          DocumentLevel
        </label>
        <div className="col-sm-12">
          <Field
            type="datetime-local"
            name="documentLevel"
            className={
              errorExistForField('documentLevel')
                ? 'form-control is-invalid'
                : 'form-control'
            }
          />
          {errorExistForField('documentLevel') && (
            <small className="text-danger">
              {errorsForField('documentLevel')}
            </small>
          )}
        </div>
      </div>
      <div className="form-group row">
        <label
          htmlFor="name"
          className={
            errorExistForField('documentSummary')
              ? 'col-sm-2 col-form-label is-invalid'
              : 'col-sm-2 col-form-label'
          }
        >
          DocumentSummary
        </label>
        <div className="col-sm-12">
          <Field
            type="datetime-local"
            name="documentSummary"
            className={
              errorExistForField('documentSummary')
                ? 'form-control is-invalid'
                : 'form-control'
            }
          />
          {errorExistForField('documentSummary') && (
            <small className="text-danger">
              {errorsForField('documentSummary')}
            </small>
          )}
        </div>
      </div>
      <div className="form-group row">
        <label
          htmlFor="name"
          className={
            errorExistForField('fileExtension')
              ? 'col-sm-2 col-form-label is-invalid'
              : 'col-sm-2 col-form-label'
          }
        >
          FileExtension
        </label>
        <div className="col-sm-12">
          <Field
            type="datetime-local"
            name="fileExtension"
            className={
              errorExistForField('fileExtension')
                ? 'form-control is-invalid'
                : 'form-control'
            }
          />
          {errorExistForField('fileExtension') && (
            <small className="text-danger">
              {errorsForField('fileExtension')}
            </small>
          )}
        </div>
      </div>
      <div className="form-group row">
        <label
          htmlFor="name"
          className={
            errorExistForField('fileName')
              ? 'col-sm-2 col-form-label is-invalid'
              : 'col-sm-2 col-form-label'
          }
        >
          FileName
        </label>
        <div className="col-sm-12">
          <Field
            type="datetime-local"
            name="fileName"
            className={
              errorExistForField('fileName')
                ? 'form-control is-invalid'
                : 'form-control'
            }
          />
          {errorExistForField('fileName') && (
            <small className="text-danger">{errorsForField('fileName')}</small>
          )}
        </div>
      </div>
      <div className="form-group row">
        <label
          htmlFor="name"
          className={
            errorExistForField('folderFlag')
              ? 'col-sm-2 col-form-label is-invalid'
              : 'col-sm-2 col-form-label'
          }
        >
          FolderFlag
        </label>
        <div className="col-sm-12">
          <Field
            type="datetime-local"
            name="folderFlag"
            className={
              errorExistForField('folderFlag')
                ? 'form-control is-invalid'
                : 'form-control'
            }
          />
          {errorExistForField('folderFlag') && (
            <small className="text-danger">
              {errorsForField('folderFlag')}
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
            errorExistForField('owner')
              ? 'col-sm-2 col-form-label is-invalid'
              : 'col-sm-2 col-form-label'
          }
        >
          Owner
        </label>
        <div className="col-sm-12">
          <Field
            type="datetime-local"
            name="owner"
            className={
              errorExistForField('owner')
                ? 'form-control is-invalid'
                : 'form-control'
            }
          />
          {errorExistForField('owner') && (
            <small className="text-danger">{errorsForField('owner')}</small>
          )}
        </div>
      </div>
      <div className="form-group row">
        <label
          htmlFor="name"
          className={
            errorExistForField('revision')
              ? 'col-sm-2 col-form-label is-invalid'
              : 'col-sm-2 col-form-label'
          }
        >
          Revision
        </label>
        <div className="col-sm-12">
          <Field
            type="datetime-local"
            name="revision"
            className={
              errorExistForField('revision')
                ? 'form-control is-invalid'
                : 'form-control'
            }
          />
          {errorExistForField('revision') && (
            <small className="text-danger">{errorsForField('revision')}</small>
          )}
        </div>
      </div>
      <div className="form-group row">
        <label
          htmlFor="name"
          className={
            errorExistForField('rowguid')
              ? 'col-sm-2 col-form-label is-invalid'
              : 'col-sm-2 col-form-label'
          }
        >
          Rowguid
        </label>
        <div className="col-sm-12">
          <Field
            type="datetime-local"
            name="rowguid"
            className={
              errorExistForField('rowguid')
                ? 'form-control is-invalid'
                : 'form-control'
            }
          />
          {errorExistForField('rowguid') && (
            <small className="text-danger">{errorsForField('rowguid')}</small>
          )}
        </div>
      </div>
      <div className="form-group row">
        <label
          htmlFor="name"
          className={
            errorExistForField('status')
              ? 'col-sm-2 col-form-label is-invalid'
              : 'col-sm-2 col-form-label'
          }
        >
          Status
        </label>
        <div className="col-sm-12">
          <Field
            type="datetime-local"
            name="status"
            className={
              errorExistForField('status')
                ? 'form-control is-invalid'
                : 'form-control'
            }
          />
          {errorExistForField('status') && (
            <small className="text-danger">{errorsForField('status')}</small>
          )}
        </div>
      </div>
      <div className="form-group row">
        <label
          htmlFor="name"
          className={
            errorExistForField('title')
              ? 'col-sm-2 col-form-label is-invalid'
              : 'col-sm-2 col-form-label'
          }
        >
          Title
        </label>
        <div className="col-sm-12">
          <Field
            type="datetime-local"
            name="title"
            className={
              errorExistForField('title')
                ? 'form-control is-invalid'
                : 'form-control'
            }
          />
          {errorExistForField('title') && (
            <small className="text-danger">{errorsForField('title')}</small>
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

const DocumentEdit = withFormik<Props, DocumentViewModel>({
  mapPropsToValues: props => {
    let response = new DocumentViewModel();
    response.setProperties(
      props.model!.changeNumber,
      props.model!.document1,
      props.model!.documentLevel,
      props.model!.documentSummary,
      props.model!.fileExtension,
      props.model!.fileName,
      props.model!.folderFlag,
      props.model!.modifiedDate,
      props.model!.owner,
      props.model!.revision,
      props.model!.rowguid,
      props.model!.status,
      props.model!.title
    );
    return response;
  },

  // Custom sync validation
  validate: values => {
    let errors: FormikErrors<DocumentViewModel> = {};

    if (values.changeNumber == 0) {
      errors.changeNumber = 'Required';
    }
    if (values.fileExtension == '') {
      errors.fileExtension = 'Required';
    }
    if (values.fileName == '') {
      errors.fileName = 'Required';
    }
    if (values.modifiedDate == undefined) {
      errors.modifiedDate = 'Required';
    }
    if (values.owner == 0) {
      errors.owner = 'Required';
    }
    if (values.revision == '') {
      errors.revision = 'Required';
    }
    if (values.rowguid == undefined) {
      errors.rowguid = 'Required';
    }
    if (values.status == 0) {
      errors.status = 'Required';
    }
    if (values.title == '') {
      errors.title = 'Required';
    }

    return errors;
  },
  handleSubmit: (values, actions) => {
    actions.setStatus(undefined);

    let mapper = new DocumentMapper();

    axios
      .put(
        Constants.ApiEndpoint + ApiRoutes.Documents + '/' + values.rowguid,

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
            Api.DocumentClientRequestModel
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

  displayName: 'DocumentEdit',
})(DocumentEditDisplay);

interface IParams {
  rowguid: any;
}

interface IMatch {
  params: IParams;
}

interface DocumentEditComponentProps {
  match: IMatch;
}

interface DocumentEditComponentState {
  model?: DocumentViewModel;
  loading: boolean;
  loaded: boolean;
  errorOccurred: boolean;
  errorMessage: string;
}

export default class DocumentEditComponent extends React.Component<
  DocumentEditComponentProps,
  DocumentEditComponentState
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
          ApiRoutes.Documents +
          '/' +
          this.props.match.params.rowguid,
        {
          headers: {
            'Content-Type': 'application/json',
          },
        }
      )
      .then(
        resp => {
          let response = resp.data as Api.DocumentClientResponseModel;

          console.log(response);

          let mapper = new DocumentMapper();

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
      return <DocumentEdit model={this.state.model} />;
    } else {
      return null;
    }
  }
}


/*<Codenesium>
    <Hash>3f6991af915cc9ad773e413ce8233690</Hash>
</Codenesium>*/