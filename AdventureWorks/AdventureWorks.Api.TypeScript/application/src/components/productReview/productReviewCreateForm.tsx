import React, { Component } from 'react';
import axios from 'axios';
import { CreateResponse } from '../../api/ApiObjects';
import { FormikProps, FormikErrors, Field, withFormik } from 'formik';
import * as Yup from 'yup';
import * as Api from '../../api/models';
import Constants from '../../constants';
import ProductReviewMapper from './productReviewMapper';
import ProductReviewViewModel from './productReviewViewModel';

interface Props {
  model?: ProductReviewViewModel;
}

const ProductReviewCreateDisplay: React.SFC<
  FormikProps<ProductReviewViewModel>
> = (props: FormikProps<ProductReviewViewModel>) => {
  let status = props.status as CreateResponse<
    Api.ProductReviewClientRequestModel
  >;

  let errorsForField = (name: string): string => {
    let response = '';
    if (
      props.touched[name as keyof ProductReviewViewModel] &&
      props.errors[name as keyof ProductReviewViewModel]
    ) {
      response += props.errors[name as keyof ProductReviewViewModel];
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
            errorExistForField('comment')
              ? 'col-sm-2 col-form-label is-invalid'
              : 'col-sm-2 col-form-label'
          }
        >
          Comments
        </label>
        <div className="col-sm-12">
          <Field
            type="datetime-local"
            name="comment"
            className={
              errorExistForField('comment')
                ? 'form-control is-invalid'
                : 'form-control'
            }
          />
          {errorExistForField('comment') && (
            <small className="text-danger">{errorsForField('comment')}</small>
          )}
        </div>
      </div>

      <div className="form-group row">
        <label
          htmlFor="name"
          className={
            errorExistForField('emailAddress')
              ? 'col-sm-2 col-form-label is-invalid'
              : 'col-sm-2 col-form-label'
          }
        >
          EmailAddress
        </label>
        <div className="col-sm-12">
          <Field
            type="datetime-local"
            name="emailAddress"
            className={
              errorExistForField('emailAddress')
                ? 'form-control is-invalid'
                : 'form-control'
            }
          />
          {errorExistForField('emailAddress') && (
            <small className="text-danger">
              {errorsForField('emailAddress')}
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
            errorExistForField('productID')
              ? 'col-sm-2 col-form-label is-invalid'
              : 'col-sm-2 col-form-label'
          }
        >
          ProductID
        </label>
        <div className="col-sm-12">
          <Field
            type="datetime-local"
            name="productID"
            className={
              errorExistForField('productID')
                ? 'form-control is-invalid'
                : 'form-control'
            }
          />
          {errorExistForField('productID') && (
            <small className="text-danger">{errorsForField('productID')}</small>
          )}
        </div>
      </div>

      <div className="form-group row">
        <label
          htmlFor="name"
          className={
            errorExistForField('rating')
              ? 'col-sm-2 col-form-label is-invalid'
              : 'col-sm-2 col-form-label'
          }
        >
          Rating
        </label>
        <div className="col-sm-12">
          <Field
            type="datetime-local"
            name="rating"
            className={
              errorExistForField('rating')
                ? 'form-control is-invalid'
                : 'form-control'
            }
          />
          {errorExistForField('rating') && (
            <small className="text-danger">{errorsForField('rating')}</small>
          )}
        </div>
      </div>

      <div className="form-group row">
        <label
          htmlFor="name"
          className={
            errorExistForField('reviewDate')
              ? 'col-sm-2 col-form-label is-invalid'
              : 'col-sm-2 col-form-label'
          }
        >
          ReviewDate
        </label>
        <div className="col-sm-12">
          <Field
            type="datetime-local"
            name="reviewDate"
            className={
              errorExistForField('reviewDate')
                ? 'form-control is-invalid'
                : 'form-control'
            }
          />
          {errorExistForField('reviewDate') && (
            <small className="text-danger">
              {errorsForField('reviewDate')}
            </small>
          )}
        </div>
      </div>

      <div className="form-group row">
        <label
          htmlFor="name"
          className={
            errorExistForField('reviewerName')
              ? 'col-sm-2 col-form-label is-invalid'
              : 'col-sm-2 col-form-label'
          }
        >
          ReviewerName
        </label>
        <div className="col-sm-12">
          <Field
            type="datetime-local"
            name="reviewerName"
            className={
              errorExistForField('reviewerName')
                ? 'form-control is-invalid'
                : 'form-control'
            }
          />
          {errorExistForField('reviewerName') && (
            <small className="text-danger">
              {errorsForField('reviewerName')}
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

const ProductReviewCreate = withFormik<Props, ProductReviewViewModel>({
  mapPropsToValues: props => {
    let response = new ProductReviewViewModel();
    if (props.model != undefined) {
      response.setProperties(
        props.model!.comment,
        props.model!.emailAddress,
        props.model!.modifiedDate,
        props.model!.productID,
        props.model!.productReviewID,
        props.model!.rating,
        props.model!.reviewDate,
        props.model!.reviewerName
      );
    }
    return response;
  },

  validate: values => {
    let errors: FormikErrors<ProductReviewViewModel> = {};

    if (values.emailAddress == '') {
      errors.emailAddress = 'Required';
    }
    if (values.modifiedDate == undefined) {
      errors.modifiedDate = 'Required';
    }
    if (values.productID == 0) {
      errors.productID = 'Required';
    }
    if (values.rating == 0) {
      errors.rating = 'Required';
    }
    if (values.reviewDate == undefined) {
      errors.reviewDate = 'Required';
    }
    if (values.reviewerName == '') {
      errors.reviewerName = 'Required';
    }

    return errors;
  },

  handleSubmit: (values, actions) => {
    actions.setStatus(undefined);
    let mapper = new ProductReviewMapper();

    axios
      .post(
        Constants.ApiUrl + 'productreviews',
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
            Api.ProductReviewClientRequestModel
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
  displayName: 'ProductReviewCreate',
})(ProductReviewCreateDisplay);

interface ProductReviewCreateComponentProps {}

interface ProductReviewCreateComponentState {
  model?: ProductReviewViewModel;
  loading: boolean;
  loaded: boolean;
  errorOccurred: boolean;
  errorMessage: string;
}

export default class ProductReviewCreateComponent extends React.Component<
  ProductReviewCreateComponentProps,
  ProductReviewCreateComponentState
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
      return <ProductReviewCreate model={this.state.model} />;
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
    <Hash>387df67a8ac7bc70619a8c51827a602b</Hash>
</Codenesium>*/