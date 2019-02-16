import React, { Component } from 'react';
import axios from 'axios';
import * as Api from '../../api/models';
import { UpdateResponse } from '../../api/ApiObjects';
import Constants from '../../constants';
import { FormikProps, FormikErrors, Field, withFormik } from 'formik';
import SpecialOfferViewModel from './specialOfferViewModel';
import SpecialOfferMapper from './specialOfferMapper';

interface Props {
  model?: SpecialOfferViewModel;
}

const SpecialOfferEditDisplay = (props: FormikProps<SpecialOfferViewModel>) => {
  let status = props.status as UpdateResponse<
    Api.SpecialOfferClientRequestModel
  >;

  let errorsForField = (name: string): string => {
    let response = '';
    if (
      props.touched[name as keyof SpecialOfferViewModel] &&
      props.errors[name as keyof SpecialOfferViewModel]
    ) {
      response += props.errors[name as keyof SpecialOfferViewModel];
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
            errorExistForField('category')
              ? 'col-sm-2 col-form-label is-invalid'
              : 'col-sm-2 col-form-label'
          }
        >
          Category
        </label>
        <div className="col-sm-12">
          <Field
            type="datetime-local"
            name="category"
            className={
              errorExistForField('category')
                ? 'form-control is-invalid'
                : 'form-control'
            }
          />
          {errorExistForField('category') && (
            <small className="text-danger">{errorsForField('category')}</small>
          )}
        </div>
      </div>
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
            errorExistForField('discountPct')
              ? 'col-sm-2 col-form-label is-invalid'
              : 'col-sm-2 col-form-label'
          }
        >
          DiscountPct
        </label>
        <div className="col-sm-12">
          <Field
            type="datetime-local"
            name="discountPct"
            className={
              errorExistForField('discountPct')
                ? 'form-control is-invalid'
                : 'form-control'
            }
          />
          {errorExistForField('discountPct') && (
            <small className="text-danger">
              {errorsForField('discountPct')}
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
            errorExistForField('maxQty')
              ? 'col-sm-2 col-form-label is-invalid'
              : 'col-sm-2 col-form-label'
          }
        >
          MaxQty
        </label>
        <div className="col-sm-12">
          <Field
            type="datetime-local"
            name="maxQty"
            className={
              errorExistForField('maxQty')
                ? 'form-control is-invalid'
                : 'form-control'
            }
          />
          {errorExistForField('maxQty') && (
            <small className="text-danger">{errorsForField('maxQty')}</small>
          )}
        </div>
      </div>
      <div className="form-group row">
        <label
          htmlFor="name"
          className={
            errorExistForField('minQty')
              ? 'col-sm-2 col-form-label is-invalid'
              : 'col-sm-2 col-form-label'
          }
        >
          MinQty
        </label>
        <div className="col-sm-12">
          <Field
            type="datetime-local"
            name="minQty"
            className={
              errorExistForField('minQty')
                ? 'form-control is-invalid'
                : 'form-control'
            }
          />
          {errorExistForField('minQty') && (
            <small className="text-danger">{errorsForField('minQty')}</small>
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
      <div className="form-group row">
        <label
          htmlFor="name"
          className={
            errorExistForField('specialOfferID')
              ? 'col-sm-2 col-form-label is-invalid'
              : 'col-sm-2 col-form-label'
          }
        >
          SpecialOfferID
        </label>
        <div className="col-sm-12">
          <Field
            type="datetime-local"
            name="specialOfferID"
            className={
              errorExistForField('specialOfferID')
                ? 'form-control is-invalid'
                : 'form-control'
            }
          />
          {errorExistForField('specialOfferID') && (
            <small className="text-danger">
              {errorsForField('specialOfferID')}
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

const SpecialOfferUpdate = withFormik<Props, SpecialOfferViewModel>({
  mapPropsToValues: props => {
    let response = new SpecialOfferViewModel();
    response.setProperties(
      props.model!.category,
      props.model!.description,
      props.model!.discountPct,
      props.model!.endDate,
      props.model!.maxQty,
      props.model!.minQty,
      props.model!.modifiedDate,
      props.model!.rowguid,
      props.model!.specialOfferID,
      props.model!.startDate
    );
    return response;
  },

  // Custom sync validation
  validate: values => {
    let errors: FormikErrors<SpecialOfferViewModel> = {};

    if (values.category == '') {
      errors.category = 'Required';
    }
    if (values.description == '') {
      errors.description = 'Required';
    }
    if (values.discountPct == 0) {
      errors.discountPct = 'Required';
    }
    if (values.endDate == undefined) {
      errors.endDate = 'Required';
    }
    if (values.minQty == 0) {
      errors.minQty = 'Required';
    }
    if (values.modifiedDate == undefined) {
      errors.modifiedDate = 'Required';
    }
    if (values.rowguid == undefined) {
      errors.rowguid = 'Required';
    }
    if (values.specialOfferID == 0) {
      errors.specialOfferID = 'Required';
    }
    if (values.startDate == undefined) {
      errors.startDate = 'Required';
    }

    return errors;
  },
  handleSubmit: (values, actions) => {
    actions.setStatus(undefined);

    let mapper = new SpecialOfferMapper();

    axios
      .put(
        Constants.ApiUrl + 'specialoffers/' + values.specialOfferID,

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
            Api.SpecialOfferClientRequestModel
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

  displayName: 'SpecialOfferEdit',
})(SpecialOfferEditDisplay);

interface IParams {
  specialOfferID: number;
}

interface IMatch {
  params: IParams;
}

interface SpecialOfferEditComponentProps {
  match: IMatch;
}

interface SpecialOfferEditComponentState {
  model?: SpecialOfferViewModel;
  loading: boolean;
  loaded: boolean;
  errorOccurred: boolean;
  errorMessage: string;
}

export default class SpecialOfferEditComponent extends React.Component<
  SpecialOfferEditComponentProps,
  SpecialOfferEditComponentState
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
          'specialoffers/' +
          this.props.match.params.specialOfferID,
        {
          headers: {
            'Content-Type': 'application/json',
          },
        }
      )
      .then(
        resp => {
          let response = resp.data as Api.SpecialOfferClientResponseModel;

          console.log(response);

          let mapper = new SpecialOfferMapper();

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
      return <SpecialOfferUpdate model={this.state.model} />;
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
    <Hash>ea0fca29aee015f846df193eb71fd328</Hash>
</Codenesium>*/