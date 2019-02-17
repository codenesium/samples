import React, { Component } from 'react';
import axios from 'axios';
import * as Api from '../../api/models';
import { UpdateResponse } from '../../api/apiObjects';
import { Constants, ApiRoutes, ClientRoutes } from '../../constants';
import { FormikProps, FormikErrors, Field, withFormik } from 'formik';
import { LoadingForm } from '../../lib/components/loadingForm';
import { ErrorForm } from '../../lib/components/errorForm';
import RateViewModel from './rateViewModel';
import RateMapper from './rateMapper';

interface Props {
  model?: RateViewModel;
}

const RateEditDisplay = (props: FormikProps<RateViewModel>) => {
  let status = props.status as UpdateResponse<Api.RateClientRequestModel>;

  let errorsForField = (name: string): string => {
    let response = '';
    if (
      props.touched[name as keyof RateViewModel] &&
      props.errors[name as keyof RateViewModel]
    ) {
      response += props.errors[name as keyof RateViewModel];
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
            errorExistForField('amountPerMinute')
              ? 'col-sm-2 col-form-label is-invalid'
              : 'col-sm-2 col-form-label'
          }
        >
          Amount Per Minute
        </label>
        <div className="col-sm-12">
          <Field
            type="number"
            name="amountPerMinute"
            className={
              errorExistForField('amountPerMinute')
                ? 'form-control is-invalid'
                : 'form-control'
            }
          />
          {errorExistForField('amountPerMinute') && (
            <small className="text-danger">
              {errorsForField('amountPerMinute')}
            </small>
          )}
        </div>
      </div>
      <div className="form-group row">
        <label
          htmlFor="name"
          className={
            errorExistForField('teacherId')
              ? 'col-sm-2 col-form-label is-invalid'
              : 'col-sm-2 col-form-label'
          }
        >
          TeacherId
        </label>
        <div className="col-sm-12">
          <Field
            type="number"
            name="teacherId"
            className={
              errorExistForField('teacherId')
                ? 'form-control is-invalid'
                : 'form-control'
            }
          />
          {errorExistForField('teacherId') && (
            <small className="text-danger">{errorsForField('teacherId')}</small>
          )}
        </div>
      </div>
      <div className="form-group row">
        <label
          htmlFor="name"
          className={
            errorExistForField('teacherSkillId')
              ? 'col-sm-2 col-form-label is-invalid'
              : 'col-sm-2 col-form-label'
          }
        >
          TeacherSkillId
        </label>
        <div className="col-sm-12">
          <Field
            type="number"
            name="teacherSkillId"
            className={
              errorExistForField('teacherSkillId')
                ? 'form-control is-invalid'
                : 'form-control'
            }
          />
          {errorExistForField('teacherSkillId') && (
            <small className="text-danger">
              {errorsForField('teacherSkillId')}
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

const RateEdit = withFormik<Props, RateViewModel>({
  mapPropsToValues: props => {
    let response = new RateViewModel();
    response.setProperties(
      props.model!.amountPerMinute,
      props.model!.id,
      props.model!.teacherId,
      props.model!.teacherSkillId
    );
    return response;
  },

  // Custom sync validation
  validate: values => {
    let errors: FormikErrors<RateViewModel> = {};

    if (values.amountPerMinute == 0) {
      errors.amountPerMinute = 'Required';
    }
    if (values.id == 0) {
      errors.id = 'Required';
    }
    if (values.teacherId == 0) {
      errors.teacherId = 'Required';
    }
    if (values.teacherSkillId == 0) {
      errors.teacherSkillId = 'Required';
    }

    return errors;
  },
  handleSubmit: (values, actions) => {
    actions.setStatus(undefined);

    let mapper = new RateMapper();

    axios
      .put(
        Constants.ApiEndpoint + ApiRoutes.Rates + '/' + values.id,

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
            Api.RateClientRequestModel
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

  displayName: 'RateEdit',
})(RateEditDisplay);

interface IParams {
  id: number;
}

interface IMatch {
  params: IParams;
}

interface RateEditComponentProps {
  match: IMatch;
}

interface RateEditComponentState {
  model?: RateViewModel;
  loading: boolean;
  loaded: boolean;
  errorOccurred: boolean;
  errorMessage: string;
}

export default class RateEditComponent extends React.Component<
  RateEditComponentProps,
  RateEditComponentState
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
          ApiRoutes.Rates +
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
          let response = resp.data as Api.RateClientResponseModel;

          console.log(response);

          let mapper = new RateMapper();

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
      return <RateEdit model={this.state.model} />;
    } else {
      return null;
    }
  }
}


/*<Codenesium>
    <Hash>7365b8d7dfe593bb26a47b1e60ffdc97</Hash>
</Codenesium>*/