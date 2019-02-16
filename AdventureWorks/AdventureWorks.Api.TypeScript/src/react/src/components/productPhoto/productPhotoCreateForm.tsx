import React, { Component } from 'react';
import axios from 'axios';
import { CreateResponse } from '../../api/ApiObjects';
import { FormikProps, FormikErrors, Field, withFormik } from 'formik';
import * as Yup from 'yup';
import * as Api from '../../api/models';
import Constants from '../../constants';
import ProductPhotoMapper from './productPhotoMapper';
import ProductPhotoViewModel from './productPhotoViewModel';

interface Props {
  model?: ProductPhotoViewModel;
}

const ProductPhotoCreateDisplay: React.SFC<
  FormikProps<ProductPhotoViewModel>
> = (props: FormikProps<ProductPhotoViewModel>) => {
  let status = props.status as CreateResponse<
    Api.ProductPhotoClientRequestModel
  >;

  let errorsForField = (name: string): string => {
    let response = '';
    if (
      props.touched[name as keyof ProductPhotoViewModel] &&
      props.errors[name as keyof ProductPhotoViewModel]
    ) {
      response += props.errors[name as keyof ProductPhotoViewModel];
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
            errorExistForField('largePhoto')
              ? 'col-sm-2 col-form-label is-invalid'
              : 'col-sm-2 col-form-label'
          }
        >
          LargePhoto
        </label>
        <div className="col-sm-12">
          <Field
            type="datetime-local"
            name="largePhoto"
            className={
              errorExistForField('largePhoto')
                ? 'form-control is-invalid'
                : 'form-control'
            }
          />
          {errorExistForField('largePhoto') && (
            <small className="text-danger">
              {errorsForField('largePhoto')}
            </small>
          )}
        </div>
      </div>

      <div className="form-group row">
        <label
          htmlFor="name"
          className={
            errorExistForField('largePhotoFileName')
              ? 'col-sm-2 col-form-label is-invalid'
              : 'col-sm-2 col-form-label'
          }
        >
          LargePhotoFileName
        </label>
        <div className="col-sm-12">
          <Field
            type="datetime-local"
            name="largePhotoFileName"
            className={
              errorExistForField('largePhotoFileName')
                ? 'form-control is-invalid'
                : 'form-control'
            }
          />
          {errorExistForField('largePhotoFileName') && (
            <small className="text-danger">
              {errorsForField('largePhotoFileName')}
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
            errorExistForField('thumbNailPhoto')
              ? 'col-sm-2 col-form-label is-invalid'
              : 'col-sm-2 col-form-label'
          }
        >
          ThumbNailPhoto
        </label>
        <div className="col-sm-12">
          <Field
            type="datetime-local"
            name="thumbNailPhoto"
            className={
              errorExistForField('thumbNailPhoto')
                ? 'form-control is-invalid'
                : 'form-control'
            }
          />
          {errorExistForField('thumbNailPhoto') && (
            <small className="text-danger">
              {errorsForField('thumbNailPhoto')}
            </small>
          )}
        </div>
      </div>

      <div className="form-group row">
        <label
          htmlFor="name"
          className={
            errorExistForField('thumbnailPhotoFileName')
              ? 'col-sm-2 col-form-label is-invalid'
              : 'col-sm-2 col-form-label'
          }
        >
          ThumbnailPhotoFileName
        </label>
        <div className="col-sm-12">
          <Field
            type="datetime-local"
            name="thumbnailPhotoFileName"
            className={
              errorExistForField('thumbnailPhotoFileName')
                ? 'form-control is-invalid'
                : 'form-control'
            }
          />
          {errorExistForField('thumbnailPhotoFileName') && (
            <small className="text-danger">
              {errorsForField('thumbnailPhotoFileName')}
            </small>
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

const ProductPhotoCreate = withFormik<Props, ProductPhotoViewModel>({
  mapPropsToValues: props => {
    let response = new ProductPhotoViewModel();
    if (props.model != undefined) {
      response.setProperties(
        props.model!.largePhoto,
        props.model!.largePhotoFileName,
        props.model!.modifiedDate,
        props.model!.productPhotoID,
        props.model!.thumbNailPhoto,
        props.model!.thumbnailPhotoFileName
      );
    }
    return response;
  },

  validate: values => {
    let errors: FormikErrors<ProductPhotoViewModel> = {};

    if (values.modifiedDate == undefined) {
      errors.modifiedDate = 'Required';
    }

    return errors;
  },

  handleSubmit: (values, actions) => {
    actions.setStatus(undefined);
    let mapper = new ProductPhotoMapper();

    axios
      .post(
        Constants.ApiUrl + 'productphotoes',
        mapper.mapViewModelToApiRequest(values),
        {
          headers: {
            'Content-Type': 'application/json',
          },
        }
      )
      .then(
        resp => {
          let response = resp.data as CreateResponse<
            Api.ProductPhotoClientRequestModel
          >;
          actions.setStatus(response);
          console.log(response);
        },
        error => {
          console.log(error);
          actions.setStatus('Error from API');
        }
      );
  },
  displayName: 'ProductPhotoCreate',
})(ProductPhotoCreateDisplay);

interface ProductPhotoCreateComponentProps {}

interface ProductPhotoCreateComponentState {
  model?: ProductPhotoViewModel;
  loading: boolean;
  loaded: boolean;
  errorOccurred: boolean;
  errorMessage: string;
}

export default class ProductPhotoCreateComponent extends React.Component<
  ProductPhotoCreateComponentProps,
  ProductPhotoCreateComponentState
> {
  state = {
    model: undefined,
    loading: false,
    loaded: true,
    errorOccurred: false,
    errorMessage: '',
  };

  render() {
    if (this.state.loading) {
      return <div>loading</div>;
    } else if (this.state.loaded) {
      return <ProductPhotoCreate model={this.state.model} />;
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
    <Hash>d627f23ac73fca8861855322d5e651f6</Hash>
</Codenesium>*/