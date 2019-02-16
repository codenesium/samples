import React, { Component } from 'react';
import axios from 'axios';
import { CreateResponse } from '../../api/ApiObjects';
import { FormikProps, FormikErrors, Field, withFormik } from 'formik';
import * as Yup from 'yup';
import * as Api from '../../api/models';
import Constants from '../../constants';
import ProductDescriptionMapper from './productDescriptionMapper';
import ProductDescriptionViewModel from './productDescriptionViewModel';

interface Props {
  model?: ProductDescriptionViewModel;
}

const ProductDescriptionCreateDisplay: React.SFC<
  FormikProps<ProductDescriptionViewModel>
> = (props: FormikProps<ProductDescriptionViewModel>) => {
  let status = props.status as CreateResponse<
    Api.ProductDescriptionClientRequestModel
  >;

  let errorsForField = (name: string): string => {
    let response = '';
    if (
      props.touched[name as keyof ProductDescriptionViewModel] &&
      props.errors[name as keyof ProductDescriptionViewModel]
    ) {
      response += props.errors[name as keyof ProductDescriptionViewModel];
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
            errorExistForField('description')
              ? 'col-sm-2 col-form-label is-invalid'
              : 'col-sm-2 col-form-label'
          }
        >
          Description
        </label>
        <div className="col-sm-12">
          <Field
            type="datetime-local"
            name="description"
            className={
              errorExistForField('description')
                ? 'form-control is-invalid'
                : 'form-control'
            }
          />
          {errorExistForField('description') && (
            <small className="text-danger">
              {errorsForField('description')}
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

const ProductDescriptionCreate = withFormik<Props, ProductDescriptionViewModel>(
  {
    mapPropsToValues: props => {
      let response = new ProductDescriptionViewModel();
      if (props.model != undefined) {
        response.setProperties(
          props.model!.description,
          props.model!.modifiedDate,
          props.model!.productDescriptionID,
          props.model!.rowguid
        );
      }
      return response;
    },

    validate: values => {
      let errors: FormikErrors<ProductDescriptionViewModel> = {};

      if (values.description == '') {
        errors.description = 'Required';
      }
      if (values.modifiedDate == undefined) {
        errors.modifiedDate = 'Required';
      }
      if (values.rowguid == undefined) {
        errors.rowguid = 'Required';
      }

      return errors;
    },

    handleSubmit: (values, actions) => {
      actions.setStatus(undefined);
      let mapper = new ProductDescriptionMapper();

      axios
        .post(
          Constants.ApiUrl + 'productdescriptions',
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
              Api.ProductDescriptionClientRequestModel
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
    displayName: 'ProductDescriptionCreate',
  }
)(ProductDescriptionCreateDisplay);

interface ProductDescriptionCreateComponentProps {}

interface ProductDescriptionCreateComponentState {
  model?: ProductDescriptionViewModel;
  loading: boolean;
  loaded: boolean;
  errorOccurred: boolean;
  errorMessage: string;
}

export default class ProductDescriptionCreateComponent extends React.Component<
  ProductDescriptionCreateComponentProps,
  ProductDescriptionCreateComponentState
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
      return <ProductDescriptionCreate model={this.state.model} />;
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
    <Hash>29fed335db5abbe9f8888cb89b60280f</Hash>
</Codenesium>*/