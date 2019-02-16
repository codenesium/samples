import React, { Component } from 'react';
import axios from 'axios';
import * as Api from '../../api/models';
import { UpdateResponse } from '../../api/ApiObjects';
import Constants from '../../constants';
import { FormikProps, FormikErrors, Field, withFormik } from 'formik';
import ProductModelViewModel from './productModelViewModel';
import ProductModelMapper from './productModelMapper';

interface Props {
  model?: ProductModelViewModel;
}

const ProductModelEditDisplay = (props: FormikProps<ProductModelViewModel>) => {
  let status = props.status as UpdateResponse<
    Api.ProductModelClientRequestModel
  >;

  let errorsForField = (name: string): string => {
    let response = '';
    if (
      props.touched[name as keyof ProductModelViewModel] &&
      props.errors[name as keyof ProductModelViewModel]
    ) {
      response += props.errors[name as keyof ProductModelViewModel];
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
            errorExistForField('catalogDescription')
              ? 'col-sm-2 col-form-label is-invalid'
              : 'col-sm-2 col-form-label'
          }
        >
          CatalogDescription
        </label>
        <div className="col-sm-12">
          <Field
            type="datetime-local"
            name="catalogDescription"
            className={
              errorExistForField('catalogDescription')
                ? 'form-control is-invalid'
                : 'form-control'
            }
          />
          {errorExistForField('catalogDescription') && (
            <small className="text-danger">
              {errorsForField('catalogDescription')}
            </small>
          )}
        </div>
      </div>
      <div className="form-group row">
        <label
          htmlFor="name"
          className={
            errorExistForField('instruction')
              ? 'col-sm-2 col-form-label is-invalid'
              : 'col-sm-2 col-form-label'
          }
        >
          Instructions
        </label>
        <div className="col-sm-12">
          <Field
            type="datetime-local"
            name="instruction"
            className={
              errorExistForField('instruction')
                ? 'form-control is-invalid'
                : 'form-control'
            }
          />
          {errorExistForField('instruction') && (
            <small className="text-danger">
              {errorsForField('instruction')}
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
            errorExistForField('productModelID')
              ? 'col-sm-2 col-form-label is-invalid'
              : 'col-sm-2 col-form-label'
          }
        >
          ProductModelID
        </label>
        <div className="col-sm-12">
          <Field
            type="datetime-local"
            name="productModelID"
            className={
              errorExistForField('productModelID')
                ? 'form-control is-invalid'
                : 'form-control'
            }
          />
          {errorExistForField('productModelID') && (
            <small className="text-danger">
              {errorsForField('productModelID')}
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

const ProductModelUpdate = withFormik<Props, ProductModelViewModel>({
  mapPropsToValues: props => {
    let response = new ProductModelViewModel();
    response.setProperties(
      props.model!.catalogDescription,
      props.model!.instruction,
      props.model!.modifiedDate,
      props.model!.name,
      props.model!.productModelID,
      props.model!.rowguid
    );
    return response;
  },

  // Custom sync validation
  validate: values => {
    let errors: FormikErrors<ProductModelViewModel> = {};

    if (values.modifiedDate == undefined) {
      errors.modifiedDate = 'Required';
    }
    if (values.name == '') {
      errors.name = 'Required';
    }
    if (values.productModelID == 0) {
      errors.productModelID = 'Required';
    }
    if (values.rowguid == undefined) {
      errors.rowguid = 'Required';
    }

    return errors;
  },
  handleSubmit: (values, actions) => {
    actions.setStatus(undefined);

    let mapper = new ProductModelMapper();

    axios
      .put(
        Constants.ApiUrl + 'productmodels/' + values.productModelID,

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
            Api.ProductModelClientRequestModel
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

  displayName: 'ProductModelEdit',
})(ProductModelEditDisplay);

interface IParams {
  productModelID: number;
}

interface IMatch {
  params: IParams;
}

interface ProductModelEditComponentProps {
  match: IMatch;
}

interface ProductModelEditComponentState {
  model?: ProductModelViewModel;
  loading: boolean;
  loaded: boolean;
  errorOccurred: boolean;
  errorMessage: string;
}

export default class ProductModelEditComponent extends React.Component<
  ProductModelEditComponentProps,
  ProductModelEditComponentState
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
          'productmodels/' +
          this.props.match.params.productModelID,
        {
          headers: {
            'Content-Type': 'application/json',
          },
        }
      )
      .then(
        resp => {
          let response = resp.data as Api.ProductModelClientResponseModel;

          console.log(response);

          let mapper = new ProductModelMapper();

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
      return <ProductModelUpdate model={this.state.model} />;
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
    <Hash>4388b19f2beb46c6b7f77e2204cba611</Hash>
</Codenesium>*/