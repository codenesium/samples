import React, { Component } from 'react';
import axios from 'axios';
import * as Api from '../../api/models';
import { UpdateResponse } from '../../api/ApiObjects';
import { Constants, ApiRoutes, ClientRoutes } from '../../constants';
import { FormikProps, FormikErrors, Field, withFormik } from 'formik';
import { LoadingForm } from '../../lib/components/loadingForm';
import { ErrorForm } from '../../lib/components/errorForm';
import EventStatusViewModel from './eventStatusViewModel';
import EventStatusMapper from './eventStatusMapper';

interface Props {
  model?: EventStatusViewModel;
}

const EventStatusEditDisplay = (props: FormikProps<EventStatusViewModel>) => {
  let status = props.status as UpdateResponse<
    Api.EventStatusClientRequestModel
  >;

  let errorsForField = (name: string): string => {
    let response = '';
    if (
      props.touched[name as keyof EventStatusViewModel] &&
      props.errors[name as keyof EventStatusViewModel]
    ) {
      response += props.errors[name as keyof EventStatusViewModel];
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
            errorExistForField('name')
              ? 'col-sm-2 col-form-label is-invalid'
              : 'col-sm-2 col-form-label'
          }
        >
          Name
        </label>
        <div className="col-sm-12">
          <Field
            type="textbox"
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

const EventStatusEdit = withFormik<Props, EventStatusViewModel>({
  mapPropsToValues: props => {
    let response = new EventStatusViewModel();
    response.setProperties(props.model!.id, props.model!.name);
    return response;
  },

  // Custom sync validation
  validate: values => {
    let errors: FormikErrors<EventStatusViewModel> = {};

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

    let mapper = new EventStatusMapper();

    axios
      .put(
        Constants.ApiEndpoint + ApiRoutes.EventStatus + '/' + values.id,

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
            Api.EventStatusClientRequestModel
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

  displayName: 'EventStatusEdit',
})(EventStatusEditDisplay);

interface IParams {
  id: number;
}

interface IMatch {
  params: IParams;
}

interface EventStatusEditComponentProps {
  match: IMatch;
}

interface EventStatusEditComponentState {
  model?: EventStatusViewModel;
  loading: boolean;
  loaded: boolean;
  errorOccurred: boolean;
  errorMessage: string;
}

export default class EventStatusEditComponent extends React.Component<
  EventStatusEditComponentProps,
  EventStatusEditComponentState
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
          ApiRoutes.EventStatus +
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
          let response = resp.data as Api.EventStatusClientResponseModel;

          console.log(response);

          let mapper = new EventStatusMapper();

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
      return <EventStatusEdit model={this.state.model} />;
    } else {
      return null;
    }
  }
}


/*<Codenesium>
    <Hash>5bd17ddd9bd69e7a9ba1a017a1eee2e4</Hash>
</Codenesium>*/