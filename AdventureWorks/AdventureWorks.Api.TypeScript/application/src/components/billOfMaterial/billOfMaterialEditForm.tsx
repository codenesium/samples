import React, { Component } from 'react';
import axios from 'axios';
import * as Api from '../../api/models';
import { UpdateResponse } from '../../api/ApiObjects';
import Constants from '../../constants';
import { FormikProps, FormikErrors, Field, withFormik } from 'formik';
import BillOfMaterialViewModel from './billOfMaterialViewModel';
import BillOfMaterialMapper from './billOfMaterialMapper';

interface Props {
  model?: BillOfMaterialViewModel;
}

const BillOfMaterialEditDisplay = (
  props: FormikProps<BillOfMaterialViewModel>
) => {
  let status = props.status as UpdateResponse<
    Api.BillOfMaterialClientRequestModel
  >;

  let errorsForField = (name: string): string => {
    let response = '';
    if (
      props.touched[name as keyof BillOfMaterialViewModel] &&
      props.errors[name as keyof BillOfMaterialViewModel]
    ) {
      response += props.errors[name as keyof BillOfMaterialViewModel];
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
            errorExistForField('billOfMaterialsID')
              ? 'col-sm-2 col-form-label is-invalid'
              : 'col-sm-2 col-form-label'
          }
        >
          BillOfMaterialsID
        </label>
        <div className="col-sm-12">
          <Field
            type="datetime-local"
            name="billOfMaterialsID"
            className={
              errorExistForField('billOfMaterialsID')
                ? 'form-control is-invalid'
                : 'form-control'
            }
          />
          {errorExistForField('billOfMaterialsID') && (
            <small className="text-danger">
              {errorsForField('billOfMaterialsID')}
            </small>
          )}
        </div>
      </div>
      <div className="form-group row">
        <label
          htmlFor="name"
          className={
            errorExistForField('bOMLevel')
              ? 'col-sm-2 col-form-label is-invalid'
              : 'col-sm-2 col-form-label'
          }
        >
          BOMLevel
        </label>
        <div className="col-sm-12">
          <Field
            type="datetime-local"
            name="bOMLevel"
            className={
              errorExistForField('bOMLevel')
                ? 'form-control is-invalid'
                : 'form-control'
            }
          />
          {errorExistForField('bOMLevel') && (
            <small className="text-danger">{errorsForField('bOMLevel')}</small>
          )}
        </div>
      </div>
      <div className="form-group row">
        <label
          htmlFor="name"
          className={
            errorExistForField('componentID')
              ? 'col-sm-2 col-form-label is-invalid'
              : 'col-sm-2 col-form-label'
          }
        >
          ComponentID
        </label>
        <div className="col-sm-12">
          <Field
            type="datetime-local"
            name="componentID"
            className={
              errorExistForField('componentID')
                ? 'form-control is-invalid'
                : 'form-control'
            }
          />
          {errorExistForField('componentID') && (
            <small className="text-danger">
              {errorsForField('componentID')}
            </small>
          )}
        </div>
      </div>
      <div className="form-group row">
        <label
          htmlFor="name"
          className={
            errorExistForField('endDate')
              ? 'col-sm-2 col-form-label is-invalid'
              : 'col-sm-2 col-form-label'
          }
        >
          EndDate
        </label>
        <div className="col-sm-12">
          <Field
            type="datetime-local"
            name="endDate"
            className={
              errorExistForField('endDate')
                ? 'form-control is-invalid'
                : 'form-control'
            }
          />
          {errorExistForField('endDate') && (
            <small className="text-danger">{errorsForField('endDate')}</small>
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
            errorExistForField('perAssemblyQty')
              ? 'col-sm-2 col-form-label is-invalid'
              : 'col-sm-2 col-form-label'
          }
        >
          PerAssemblyQty
        </label>
        <div className="col-sm-12">
          <Field
            type="datetime-local"
            name="perAssemblyQty"
            className={
              errorExistForField('perAssemblyQty')
                ? 'form-control is-invalid'
                : 'form-control'
            }
          />
          {errorExistForField('perAssemblyQty') && (
            <small className="text-danger">
              {errorsForField('perAssemblyQty')}
            </small>
          )}
        </div>
      </div>
      <div className="form-group row">
        <label
          htmlFor="name"
          className={
            errorExistForField('productAssemblyID')
              ? 'col-sm-2 col-form-label is-invalid'
              : 'col-sm-2 col-form-label'
          }
        >
          ProductAssemblyID
        </label>
        <div className="col-sm-12">
          <Field
            type="datetime-local"
            name="productAssemblyID"
            className={
              errorExistForField('productAssemblyID')
                ? 'form-control is-invalid'
                : 'form-control'
            }
          />
          {errorExistForField('productAssemblyID') && (
            <small className="text-danger">
              {errorsForField('productAssemblyID')}
            </small>
          )}
        </div>
      </div>
      <div className="form-group row">
        <label
          htmlFor="name"
          className={
            errorExistForField('startDate')
              ? 'col-sm-2 col-form-label is-invalid'
              : 'col-sm-2 col-form-label'
          }
        >
          StartDate
        </label>
        <div className="col-sm-12">
          <Field
            type="datetime-local"
            name="startDate"
            className={
              errorExistForField('startDate')
                ? 'form-control is-invalid'
                : 'form-control'
            }
          />
          {errorExistForField('startDate') && (
            <small className="text-danger">{errorsForField('startDate')}</small>
          )}
        </div>
      </div>
      <div className="form-group row">
        <label
          htmlFor="name"
          className={
            errorExistForField('unitMeasureCode')
              ? 'col-sm-2 col-form-label is-invalid'
              : 'col-sm-2 col-form-label'
          }
        >
          UnitMeasureCode
        </label>
        <div className="col-sm-12">
          <Field
            type="datetime-local"
            name="unitMeasureCode"
            className={
              errorExistForField('unitMeasureCode')
                ? 'form-control is-invalid'
                : 'form-control'
            }
          />
          {errorExistForField('unitMeasureCode') && (
            <small className="text-danger">
              {errorsForField('unitMeasureCode')}
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

const BillOfMaterialUpdate = withFormik<Props, BillOfMaterialViewModel>({
  mapPropsToValues: props => {
    let response = new BillOfMaterialViewModel();
    response.setProperties(
      props.model!.billOfMaterialsID,
      props.model!.bOMLevel,
      props.model!.componentID,
      props.model!.endDate,
      props.model!.modifiedDate,
      props.model!.perAssemblyQty,
      props.model!.productAssemblyID,
      props.model!.startDate,
      props.model!.unitMeasureCode
    );
    return response;
  },

  // Custom sync validation
  validate: values => {
    let errors: FormikErrors<BillOfMaterialViewModel> = {};

    if (values.billOfMaterialsID == 0) {
      errors.billOfMaterialsID = 'Required';
    }
    if (values.bOMLevel == 0) {
      errors.bOMLevel = 'Required';
    }
    if (values.componentID == 0) {
      errors.componentID = 'Required';
    }
    if (values.modifiedDate == undefined) {
      errors.modifiedDate = 'Required';
    }
    if (values.perAssemblyQty == 0) {
      errors.perAssemblyQty = 'Required';
    }
    if (values.startDate == undefined) {
      errors.startDate = 'Required';
    }
    if (values.unitMeasureCode == '') {
      errors.unitMeasureCode = 'Required';
    }

    return errors;
  },
  handleSubmit: (values, actions) => {
    actions.setStatus(undefined);

    let mapper = new BillOfMaterialMapper();

    axios
      .put(
        Constants.ApiUrl + 'billofmaterials/' + values.billOfMaterialsID,

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
            Api.BillOfMaterialClientRequestModel
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

  displayName: 'BillOfMaterialEdit',
})(BillOfMaterialEditDisplay);

interface IParams {
  billOfMaterialsID: number;
}

interface IMatch {
  params: IParams;
}

interface BillOfMaterialEditComponentProps {
  match: IMatch;
}

interface BillOfMaterialEditComponentState {
  model?: BillOfMaterialViewModel;
  loading: boolean;
  loaded: boolean;
  errorOccurred: boolean;
  errorMessage: string;
}

export default class BillOfMaterialEditComponent extends React.Component<
  BillOfMaterialEditComponentProps,
  BillOfMaterialEditComponentState
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
          'billofmaterials/' +
          this.props.match.params.billOfMaterialsID,
        {
          headers: {
            'Content-Type': 'application/json',
          },
        }
      )
      .then(
        resp => {
          let response = resp.data as Api.BillOfMaterialClientResponseModel;

          console.log(response);

          let mapper = new BillOfMaterialMapper();

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
      return <BillOfMaterialUpdate model={this.state.model} />;
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
    <Hash>e0f5ffe4424b1f9c4980a133857f9443</Hash>
</Codenesium>*/