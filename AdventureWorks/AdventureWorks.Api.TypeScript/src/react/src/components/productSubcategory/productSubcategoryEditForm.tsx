import React, { Component } from 'react';
import axios from 'axios';
import * as Api from '../../api/models';
import { UpdateResponse } from '../../api/ApiObjects';
import Constants from '../../constants';
import { FormikProps, FormikErrors, Field, withFormik } from 'formik';
import ProductSubcategoryViewModel from './productSubcategoryViewModel';
import ProductSubcategoryMapper from './productSubcategoryMapper';

interface Props {
  model?: ProductSubcategoryViewModel;
}

const ProductSubcategoryEditDisplay = (
  props: FormikProps<ProductSubcategoryViewModel>
) => {
  let status = props.status as UpdateResponse<
    Api.ProductSubcategoryClientRequestModel
  >;

  let errorsForField = (name: string): string => {
    let response = '';
    if (
      props.touched[name as keyof ProductSubcategoryViewModel] &&
      props.errors[name as keyof ProductSubcategoryViewModel]
    ) {
      response += props.errors[name as keyof ProductSubcategoryViewModel];
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
            errorExistForField('name')
              ? 'col-sm-2 col-form-label is-invalid'
              : 'col-sm-2 col-form-label'
          }
        >
          Name
        </label>
        <div className="col-sm-12">
          <Field
            type="datetime-local"
            name="name"
            className={
              errorExistForField('name')
                ? 'form-control is-invalid'
                : 'form-control'
            }
          />
          {errorExistForField('name') && (
            <small className="text-danger">{errorsForField('name')}</small>
          )}
        </div>
      </div>
      <div className="form-group row">
        <label
          htmlFor="name"
          className={
            errorExistForField('productCategoryID')
              ? 'col-sm-2 col-form-label is-invalid'
              : 'col-sm-2 col-form-label'
          }
        >
          ProductCategoryID
        </label>
        <div className="col-sm-12">
          <Field
            type="datetime-local"
            name="productCategoryID"
            className={
              errorExistForField('productCategoryID')
                ? 'form-control is-invalid'
                : 'form-control'
            }
          />
          {errorExistForField('productCategoryID') && (
            <small className="text-danger">
              {errorsForField('productCategoryID')}
            </small>
          )}
        </div>
      </div>
      <div className="form-group row">
        <label
          htmlFor="name"
          className={
            errorExistForField('productSubcategoryID')
              ? 'col-sm-2 col-form-label is-invalid'
              : 'col-sm-2 col-form-label'
          }
        >
          ProductSubcategoryID
        </label>
        <div className="col-sm-12">
          <Field
            type="datetime-local"
            name="productSubcategoryID"
            className={
              errorExistForField('productSubcategoryID')
                ? 'form-control is-invalid'
                : 'form-control'
            }
          />
          {errorExistForField('productSubcategoryID') && (
            <small className="text-danger">
              {errorsForField('productSubcategoryID')}
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

const ProductSubcategoryUpdate = withFormik<Props, ProductSubcategoryViewModel>(
  {
    mapPropsToValues: props => {
      let response = new ProductSubcategoryViewModel();
      response.setProperties(
        props.model!.modifiedDate,
        props.model!.name,
        props.model!.productCategoryID,
        props.model!.productSubcategoryID,
        props.model!.rowguid
      );
      return response;
    },

    // Custom sync validation
    validate: values => {
      let errors: FormikErrors<ProductSubcategoryViewModel> = {};

      if (values.modifiedDate == undefined) {
        errors.modifiedDate = 'Required';
      }
      if (values.name == '') {
        errors.name = 'Required';
      }
      if (values.productCategoryID == 0) {
        errors.productCategoryID = 'Required';
      }
      if (values.productSubcategoryID == 0) {
        errors.productSubcategoryID = 'Required';
      }
      if (values.rowguid == undefined) {
        errors.rowguid = 'Required';
      }

      return errors;
    },
    handleSubmit: (values, actions) => {
      actions.setStatus(undefined);

      let mapper = new ProductSubcategoryMapper();

      axios
        .put(
          Constants.ApiUrl +
            'productsubcategories/' +
            values.productSubcategoryID,

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
              Api.ProductSubcategoryClientRequestModel
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

    displayName: 'ProductSubcategoryEdit',
  }
)(ProductSubcategoryEditDisplay);

interface IParams {
  productSubcategoryID: number;
}

interface IMatch {
  params: IParams;
}

interface ProductSubcategoryEditComponentProps {
  match: IMatch;
}

interface ProductSubcategoryEditComponentState {
  model?: ProductSubcategoryViewModel;
  loading: boolean;
  loaded: boolean;
  errorOccurred: boolean;
  errorMessage: string;
}

export default class ProductSubcategoryEditComponent extends React.Component<
  ProductSubcategoryEditComponentProps,
  ProductSubcategoryEditComponentState
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
          'productsubcategories/' +
          this.props.match.params.productSubcategoryID,
        {
          headers: {
            'Content-Type': 'application/json',
          },
        }
      )
      .then(
        resp => {
          let response = resp.data as Api.ProductSubcategoryClientResponseModel;

          console.log(response);

          let mapper = new ProductSubcategoryMapper();

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
      return <ProductSubcategoryUpdate model={this.state.model} />;
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
    <Hash>272c2c37e45a6df226cf8ded2264f096</Hash>
</Codenesium>*/