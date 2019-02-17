import React, { Component } from 'react';
import axios from 'axios';
import * as Api from '../../api/models';
import { UpdateResponse } from '../../api/apiObjects';
import { Constants, ApiRoutes, ClientRoutes } from '../../constants';
import { FormikProps, FormikErrors, Field, withFormik } from 'formik';
import { LoadingForm } from '../../lib/components/loadingForm';
import { ErrorForm } from '../../lib/components/errorForm';
import TicketStatusViewModel from './ticketStatusViewModel';
import TicketStatusMapper from './ticketStatusMapper';

interface Props {
  model?: TicketStatusViewModel;
}

const TicketStatusEditDisplay = (props: FormikProps<TicketStatusViewModel>) => {
  let status = props.status as UpdateResponse<
    Api.TicketStatusClientRequestModel
  >;

  let errorsForField = (name: string): string => {
    let response = '';
    if (
      props.touched[name as keyof TicketStatusViewModel] &&
      props.errors[name as keyof TicketStatusViewModel]
    ) {
      response += props.errors[name as keyof TicketStatusViewModel];
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
            type="textbox"
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

const TicketStatusEdit = withFormik<Props, TicketStatusViewModel>({
  mapPropsToValues: props => {
    let response = new TicketStatusViewModel();
    response.setProperties(props.model!.id, props.model!.name);
    return response;
  },

  // Custom sync validation
  validate: values => {
    let errors: FormikErrors<TicketStatusViewModel> = {};

    if (values.id == 0) {
      errors.id = 'Required';
    }
    if (values.name == '') {
      errors.name = 'Required';
    }

    return errors;
  },
  handleSubmit: (values, actions) => {
    actions.setStatus(undefined);

    let mapper = new TicketStatusMapper();

    axios
      .put(
        Constants.ApiEndpoint + ApiRoutes.TicketStatus + '/' + values.id,

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
            Api.TicketStatusClientRequestModel
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

  displayName: 'TicketStatusEdit',
})(TicketStatusEditDisplay);

interface IParams {
  id: number;
}

interface IMatch {
  params: IParams;
}

interface TicketStatusEditComponentProps {
  match: IMatch;
}

interface TicketStatusEditComponentState {
  model?: TicketStatusViewModel;
  loading: boolean;
  loaded: boolean;
  errorOccurred: boolean;
  errorMessage: string;
}

export default class TicketStatusEditComponent extends React.Component<
  TicketStatusEditComponentProps,
  TicketStatusEditComponentState
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
          ApiRoutes.TicketStatus +
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
          let response = resp.data as Api.TicketStatusClientResponseModel;

          console.log(response);

          let mapper = new TicketStatusMapper();

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
      return <TicketStatusEdit model={this.state.model} />;
    } else {
      return null;
    }
  }
}


/*<Codenesium>
    <Hash>a082293970cd1a465e171ba84444149c</Hash>
</Codenesium>*/