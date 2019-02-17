import React, { Component } from 'react';
import axios from 'axios';
import * as Api from '../../api/models';
import { UpdateResponse } from '../../api/apiObjects';
import { Constants, ApiRoutes, ClientRoutes } from '../../constants';
import { FormikProps, FormikErrors, Field, withFormik } from 'formik';
import { LoadingForm } from '../../lib/components/loadingForm';
import { ErrorForm } from '../../lib/components/errorForm';
import SaleTicketViewModel from './saleTicketViewModel';
import SaleTicketMapper from './saleTicketMapper';

interface Props {
  model?: SaleTicketViewModel;
}

const SaleTicketEditDisplay = (props: FormikProps<SaleTicketViewModel>) => {
  let status = props.status as UpdateResponse<Api.SaleTicketClientRequestModel>;

  let errorsForField = (name: string): string => {
    let response = '';
    if (
      props.touched[name as keyof SaleTicketViewModel] &&
      props.errors[name as keyof SaleTicketViewModel]
    ) {
      response += props.errors[name as keyof SaleTicketViewModel];
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
            errorExistForField('id')
              ? 'col-sm-2 col-form-label is-invalid'
              : 'col-sm-2 col-form-label'
          }
        >
          Id
        </label>
        <div className="col-sm-12">
          <Field
            type="datetime-local"
            name="id"
            className={
              errorExistForField('id')
                ? 'form-control is-invalid'
                : 'form-control'
            }
          />
          {errorExistForField('id') && (
            <small className="text-danger">{errorsForField('id')}</small>
          )}
        </div>
      </div>
      <div className="form-group row">
        <label
          htmlFor="name"
          className={
            errorExistForField('saleId')
              ? 'col-sm-2 col-form-label is-invalid'
              : 'col-sm-2 col-form-label'
          }
        >
          SaleId
        </label>
        <div className="col-sm-12">
          <Field
            type="textbox"
            name="saleId"
            className={
              errorExistForField('saleId')
                ? 'form-control is-invalid'
                : 'form-control'
            }
          />
          {errorExistForField('saleId') && (
            <small className="text-danger">{errorsForField('saleId')}</small>
          )}
        </div>
      </div>
      <div className="form-group row">
        <label
          htmlFor="name"
          className={
            errorExistForField('ticketId')
              ? 'col-sm-2 col-form-label is-invalid'
              : 'col-sm-2 col-form-label'
          }
        >
          TicketId
        </label>
        <div className="col-sm-12">
          <Field
            type="textbox"
            name="ticketId"
            className={
              errorExistForField('ticketId')
                ? 'form-control is-invalid'
                : 'form-control'
            }
          />
          {errorExistForField('ticketId') && (
            <small className="text-danger">{errorsForField('ticketId')}</small>
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

const SaleTicketEdit = withFormik<Props, SaleTicketViewModel>({
  mapPropsToValues: props => {
    let response = new SaleTicketViewModel();
    response.setProperties(
      props.model!.id,
      props.model!.saleId,
      props.model!.ticketId
    );
    return response;
  },

  // Custom sync validation
  validate: values => {
    let errors: FormikErrors<SaleTicketViewModel> = {};

    if (values.id == 0) {
      errors.id = 'Required';
    }
    if (values.saleId == 0) {
      errors.saleId = 'Required';
    }
    if (values.ticketId == 0) {
      errors.ticketId = 'Required';
    }

    return errors;
  },
  handleSubmit: (values, actions) => {
    actions.setStatus(undefined);

    let mapper = new SaleTicketMapper();

    axios
      .put(
        Constants.ApiEndpoint + ApiRoutes.SaleTickets + '/' + values.id,

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
            Api.SaleTicketClientRequestModel
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

  displayName: 'SaleTicketEdit',
})(SaleTicketEditDisplay);

interface IParams {
  id: number;
}

interface IMatch {
  params: IParams;
}

interface SaleTicketEditComponentProps {
  match: IMatch;
}

interface SaleTicketEditComponentState {
  model?: SaleTicketViewModel;
  loading: boolean;
  loaded: boolean;
  errorOccurred: boolean;
  errorMessage: string;
}

export default class SaleTicketEditComponent extends React.Component<
  SaleTicketEditComponentProps,
  SaleTicketEditComponentState
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
          ApiRoutes.SaleTickets +
          '/' +
          this.props.match.params.id,
        {
          headers: {
            'Content-Type': 'application/json',
          },
        }
      )
      .then(
        resp => {
          let response = resp.data as Api.SaleTicketClientResponseModel;

          console.log(response);

          let mapper = new SaleTicketMapper();

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
      return <SaleTicketEdit model={this.state.model} />;
    } else {
      return null;
    }
  }
}


/*<Codenesium>
    <Hash>9b35a512aa4f63b3de5c8ca45359f3d8</Hash>
</Codenesium>*/