import React, { Component } from 'react';
import axios from 'axios';
import * as Api from '../../api/models';
import { UpdateResponse } from '../../api/apiObjects';
import { Constants, ApiRoutes, ClientRoutes } from '../../constants';
import { FormikProps, FormikErrors, Field, withFormik } from 'formik';
import { LoadingForm } from '../../lib/components/loadingForm';
import { ErrorForm } from '../../lib/components/errorForm';
import CreditCardViewModel from './creditCardViewModel';
import CreditCardMapper from './creditCardMapper';

interface Props {
  model?: CreditCardViewModel;
}

const CreditCardEditDisplay = (props: FormikProps<CreditCardViewModel>) => {
  let status = props.status as UpdateResponse<Api.CreditCardClientRequestModel>;

  let errorsForField = (name: string): string => {
    let response = '';
    if (
      props.touched[name as keyof CreditCardViewModel] &&
      props.errors[name as keyof CreditCardViewModel]
    ) {
      response += props.errors[name as keyof CreditCardViewModel];
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
            errorExistForField('cardNumber')
              ? 'col-sm-2 col-form-label is-invalid'
              : 'col-sm-2 col-form-label'
          }
        >
          CardNumber
        </label>
        <div className="col-sm-12">
          <Field
            type="datetime-local"
            name="cardNumber"
            className={
              errorExistForField('cardNumber')
                ? 'form-control is-invalid'
                : 'form-control'
            }
          />
          {errorExistForField('cardNumber') && (
            <small className="text-danger">
              {errorsForField('cardNumber')}
            </small>
          )}
        </div>
      </div>
      <div className="form-group row">
        <label
          htmlFor="name"
          className={
            errorExistForField('cardType')
              ? 'col-sm-2 col-form-label is-invalid'
              : 'col-sm-2 col-form-label'
          }
        >
          CardType
        </label>
        <div className="col-sm-12">
          <Field
            type="datetime-local"
            name="cardType"
            className={
              errorExistForField('cardType')
                ? 'form-control is-invalid'
                : 'form-control'
            }
          />
          {errorExistForField('cardType') && (
            <small className="text-danger">{errorsForField('cardType')}</small>
          )}
        </div>
      </div>
      <div className="form-group row">
        <label
          htmlFor="name"
          className={
            errorExistForField('creditCardID')
              ? 'col-sm-2 col-form-label is-invalid'
              : 'col-sm-2 col-form-label'
          }
        >
          CreditCardID
        </label>
        <div className="col-sm-12">
          <Field
            type="datetime-local"
            name="creditCardID"
            className={
              errorExistForField('creditCardID')
                ? 'form-control is-invalid'
                : 'form-control'
            }
          />
          {errorExistForField('creditCardID') && (
            <small className="text-danger">
              {errorsForField('creditCardID')}
            </small>
          )}
        </div>
      </div>
      <div className="form-group row">
        <label
          htmlFor="name"
          className={
            errorExistForField('expMonth')
              ? 'col-sm-2 col-form-label is-invalid'
              : 'col-sm-2 col-form-label'
          }
        >
          ExpMonth
        </label>
        <div className="col-sm-12">
          <Field
            type="datetime-local"
            name="expMonth"
            className={
              errorExistForField('expMonth')
                ? 'form-control is-invalid'
                : 'form-control'
            }
          />
          {errorExistForField('expMonth') && (
            <small className="text-danger">{errorsForField('expMonth')}</small>
          )}
        </div>
      </div>
      <div className="form-group row">
        <label
          htmlFor="name"
          className={
            errorExistForField('expYear')
              ? 'col-sm-2 col-form-label is-invalid'
              : 'col-sm-2 col-form-label'
          }
        >
          ExpYear
        </label>
        <div className="col-sm-12">
          <Field
            type="datetime-local"
            name="expYear"
            className={
              errorExistForField('expYear')
                ? 'form-control is-invalid'
                : 'form-control'
            }
          />
          {errorExistForField('expYear') && (
            <small className="text-danger">{errorsForField('expYear')}</small>
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

const CreditCardEdit = withFormik<Props, CreditCardViewModel>({
  mapPropsToValues: props => {
    let response = new CreditCardViewModel();
    response.setProperties(
      props.model!.cardNumber,
      props.model!.cardType,
      props.model!.creditCardID,
      props.model!.expMonth,
      props.model!.expYear,
      props.model!.modifiedDate
    );
    return response;
  },

  // Custom sync validation
  validate: values => {
    let errors: FormikErrors<CreditCardViewModel> = {};

    if (values.cardNumber == '') {
      errors.cardNumber = 'Required';
    }
    if (values.cardType == '') {
      errors.cardType = 'Required';
    }
    if (values.creditCardID == 0) {
      errors.creditCardID = 'Required';
    }
    if (values.expMonth == 0) {
      errors.expMonth = 'Required';
    }
    if (values.expYear == 0) {
      errors.expYear = 'Required';
    }
    if (values.modifiedDate == undefined) {
      errors.modifiedDate = 'Required';
    }

    return errors;
  },
  handleSubmit: (values, actions) => {
    actions.setStatus(undefined);

    let mapper = new CreditCardMapper();

    axios
      .put(
        Constants.ApiEndpoint +
          ApiRoutes.CreditCards +
          '/' +
          values.creditCardID,

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
            Api.CreditCardClientRequestModel
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

  displayName: 'CreditCardEdit',
})(CreditCardEditDisplay);

interface IParams {
  creditCardID: number;
}

interface IMatch {
  params: IParams;
}

interface CreditCardEditComponentProps {
  match: IMatch;
}

interface CreditCardEditComponentState {
  model?: CreditCardViewModel;
  loading: boolean;
  loaded: boolean;
  errorOccurred: boolean;
  errorMessage: string;
}

export default class CreditCardEditComponent extends React.Component<
  CreditCardEditComponentProps,
  CreditCardEditComponentState
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
          ApiRoutes.CreditCards +
          '/' +
          this.props.match.params.creditCardID,
        {
          headers: {
            'Content-Type': 'application/json',
          },
        }
      )
      .then(
        resp => {
          let response = resp.data as Api.CreditCardClientResponseModel;

          console.log(response);

          let mapper = new CreditCardMapper();

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
      return <CreditCardEdit model={this.state.model} />;
    } else {
      return null;
    }
  }
}


/*<Codenesium>
    <Hash>9efa2baa2eba9498463855e667fdf0c0</Hash>
</Codenesium>*/