import React, { Component } from 'react';
import axios from 'axios';
import { CreateResponse } from '../../api/apiObjects';
import { FormikProps, FormikErrors, Field, withFormik } from 'formik';
import * as Yup from 'yup';
import { LoadingForm } from '../../lib/components/loadingForm';
import { ErrorForm } from '../../lib/components/errorForm';
import * as Api from '../../api/models';
import { Constants, ApiRoutes, ClientRoutes } from '../../constants';
import RateMapper from './rateMapper';
import RateViewModel from './rateViewModel';

interface Props {
  model?: RateViewModel;
}

const RateCreateDisplay: React.SFC<FormikProps<RateViewModel>> = (
  props: FormikProps<RateViewModel>
) => {
  let status = props.status as CreateResponse<Api.RateClientRequestModel>;

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
          AmountPerMinute
        </label>
        <div className="col-sm-12">
          <Field
            type="datetime-local"
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
            type="datetime-local"
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
            type="datetime-local"
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

const RateCreate = withFormik<Props, RateViewModel>({
  mapPropsToValues: props => {
    let response = new RateViewModel();
    if (props.model != undefined) {
      response.setProperties(
        props.model!.amountPerMinute,
        props.model!.id,
        props.model!.teacherId,
        props.model!.teacherSkillId
      );
    }
    return response;
  },

  validate: values => {
    let errors: FormikErrors<RateViewModel> = {};

    if (values.amountPerMinute == 0) {
      errors.amountPerMinute = 'Required';
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
      .post(
        Constants.ApiEndpoint + ApiRoutes.Rates,
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
            Api.RateClientRequestModel
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
  displayName: 'RateCreate',
})(RateCreateDisplay);

interface RateCreateComponentProps {}

interface RateCreateComponentState {
  model?: RateViewModel;
  loading: boolean;
  loaded: boolean;
  errorOccurred: boolean;
  errorMessage: string;
}

export default class RateCreateComponent extends React.Component<
  RateCreateComponentProps,
  RateCreateComponentState
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
      return <LoadingForm />;
    } else if (this.state.errorOccurred) {
      return <ErrorForm message={this.state.errorMessage} />;
    } else if (this.state.loaded) {
      return <RateCreate model={this.state.model} />;
    } else {
      return null;
    }
  }
}


/*<Codenesium>
    <Hash>a8e7e501926086f6330aa251c0bd1b7b</Hash>
</Codenesium>*/