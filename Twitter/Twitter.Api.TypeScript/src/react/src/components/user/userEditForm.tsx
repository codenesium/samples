import React, { Component } from 'react';
import axios from 'axios';
import * as Api from '../../api/models';
import { UpdateResponse } from '../../api/ApiObjects';
import { Constants, ApiRoutes, ClientRoutes } from '../../constants';
import { FormikProps, FormikErrors, Field, withFormik } from 'formik';
import { LoadingForm } from '../../lib/components/loadingForm';
import { ErrorForm } from '../../lib/components/errorForm';
import UserViewModel from './userViewModel';
import UserMapper from './userMapper';

interface Props {
  model?: UserViewModel;
}

const UserEditDisplay = (props: FormikProps<UserViewModel>) => {
  let status = props.status as UpdateResponse<Api.UserClientRequestModel>;

  let errorsForField = (name: string): string => {
    let response = '';
    if (
      props.touched[name as keyof UserViewModel] &&
      props.errors[name as keyof UserViewModel]
    ) {
      response += props.errors[name as keyof UserViewModel];
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
            errorExistForField('bioImgUrl')
              ? 'col-sm-2 col-form-label is-invalid'
              : 'col-sm-2 col-form-label'
          }
        >
          Bio_img_url
        </label>
        <div className="col-sm-12">
          <Field
            type="textbox"
            name="bioImgUrl"
            className={
              errorExistForField('bioImgUrl')
                ? 'form-control is-invalid'
                : 'form-control'
            }
          />
          {errorExistForField('bioImgUrl') && (
            <small className="text-danger">{errorsForField('bioImgUrl')}</small>
          )}
        </div>
      </div>
      <div className="form-group row">
        <label
          htmlFor="name"
          className={
            errorExistForField('birthday')
              ? 'col-sm-2 col-form-label is-invalid'
              : 'col-sm-2 col-form-label'
          }
        >
          Birthday
        </label>
        <div className="col-sm-12">
          <Field
            type="textbox"
            name="birthday"
            className={
              errorExistForField('birthday')
                ? 'form-control is-invalid'
                : 'form-control'
            }
          />
          {errorExistForField('birthday') && (
            <small className="text-danger">{errorsForField('birthday')}</small>
          )}
        </div>
      </div>
      <div className="form-group row">
        <label
          htmlFor="name"
          className={
            errorExistForField('contentDescription')
              ? 'col-sm-2 col-form-label is-invalid'
              : 'col-sm-2 col-form-label'
          }
        >
          Content_description
        </label>
        <div className="col-sm-12">
          <Field
            type="textbox"
            name="contentDescription"
            className={
              errorExistForField('contentDescription')
                ? 'form-control is-invalid'
                : 'form-control'
            }
          />
          {errorExistForField('contentDescription') && (
            <small className="text-danger">
              {errorsForField('contentDescription')}
            </small>
          )}
        </div>
      </div>
      <div className="form-group row">
        <label
          htmlFor="name"
          className={
            errorExistForField('email')
              ? 'col-sm-2 col-form-label is-invalid'
              : 'col-sm-2 col-form-label'
          }
        >
          Email
        </label>
        <div className="col-sm-12">
          <Field
            type="textbox"
            name="email"
            className={
              errorExistForField('email')
                ? 'form-control is-invalid'
                : 'form-control'
            }
          />
          {errorExistForField('email') && (
            <small className="text-danger">{errorsForField('email')}</small>
          )}
        </div>
      </div>
      <div className="form-group row">
        <label
          htmlFor="name"
          className={
            errorExistForField('fullName')
              ? 'col-sm-2 col-form-label is-invalid'
              : 'col-sm-2 col-form-label'
          }
        >
          Full_name
        </label>
        <div className="col-sm-12">
          <Field
            type="textbox"
            name="fullName"
            className={
              errorExistForField('fullName')
                ? 'form-control is-invalid'
                : 'form-control'
            }
          />
          {errorExistForField('fullName') && (
            <small className="text-danger">{errorsForField('fullName')}</small>
          )}
        </div>
      </div>
      <div className="form-group row">
        <label
          htmlFor="name"
          className={
            errorExistForField('headerImgUrl')
              ? 'col-sm-2 col-form-label is-invalid'
              : 'col-sm-2 col-form-label'
          }
        >
          Header_img_url
        </label>
        <div className="col-sm-12">
          <Field
            type="textbox"
            name="headerImgUrl"
            className={
              errorExistForField('headerImgUrl')
                ? 'form-control is-invalid'
                : 'form-control'
            }
          />
          {errorExistForField('headerImgUrl') && (
            <small className="text-danger">
              {errorsForField('headerImgUrl')}
            </small>
          )}
        </div>
      </div>
      <div className="form-group row">
        <label
          htmlFor="name"
          className={
            errorExistForField('interest')
              ? 'col-sm-2 col-form-label is-invalid'
              : 'col-sm-2 col-form-label'
          }
        >
          Interest
        </label>
        <div className="col-sm-12">
          <Field
            type="textbox"
            name="interest"
            className={
              errorExistForField('interest')
                ? 'form-control is-invalid'
                : 'form-control'
            }
          />
          {errorExistForField('interest') && (
            <small className="text-danger">{errorsForField('interest')}</small>
          )}
        </div>
      </div>
      <div className="form-group row">
        <label
          htmlFor="name"
          className={
            errorExistForField('locationLocationId')
              ? 'col-sm-2 col-form-label is-invalid'
              : 'col-sm-2 col-form-label'
          }
        >
          Location_location_id
        </label>
        <div className="col-sm-12">
          <Field
            type="textbox"
            name="locationLocationId"
            className={
              errorExistForField('locationLocationId')
                ? 'form-control is-invalid'
                : 'form-control'
            }
          />
          {errorExistForField('locationLocationId') && (
            <small className="text-danger">
              {errorsForField('locationLocationId')}
            </small>
          )}
        </div>
      </div>
      <div className="form-group row">
        <label
          htmlFor="name"
          className={
            errorExistForField('password')
              ? 'col-sm-2 col-form-label is-invalid'
              : 'col-sm-2 col-form-label'
          }
        >
          Password
        </label>
        <div className="col-sm-12">
          <Field
            type="textbox"
            name="password"
            className={
              errorExistForField('password')
                ? 'form-control is-invalid'
                : 'form-control'
            }
          />
          {errorExistForField('password') && (
            <small className="text-danger">{errorsForField('password')}</small>
          )}
        </div>
      </div>
      <div className="form-group row">
        <label
          htmlFor="name"
          className={
            errorExistForField('phoneNumber')
              ? 'col-sm-2 col-form-label is-invalid'
              : 'col-sm-2 col-form-label'
          }
        >
          Phone_number
        </label>
        <div className="col-sm-12">
          <Field
            type="textbox"
            name="phoneNumber"
            className={
              errorExistForField('phoneNumber')
                ? 'form-control is-invalid'
                : 'form-control'
            }
          />
          {errorExistForField('phoneNumber') && (
            <small className="text-danger">
              {errorsForField('phoneNumber')}
            </small>
          )}
        </div>
      </div>
      <div className="form-group row">
        <label
          htmlFor="name"
          className={
            errorExistForField('privacy')
              ? 'col-sm-2 col-form-label is-invalid'
              : 'col-sm-2 col-form-label'
          }
        >
          Privacy
        </label>
        <div className="col-sm-12">
          <Field
            type="textbox"
            name="privacy"
            className={
              errorExistForField('privacy')
                ? 'form-control is-invalid'
                : 'form-control'
            }
          />
          {errorExistForField('privacy') && (
            <small className="text-danger">{errorsForField('privacy')}</small>
          )}
        </div>
      </div>
      <div className="form-group row">
        <label
          htmlFor="name"
          className={
            errorExistForField('username')
              ? 'col-sm-2 col-form-label is-invalid'
              : 'col-sm-2 col-form-label'
          }
        >
          Username
        </label>
        <div className="col-sm-12">
          <Field
            type="textbox"
            name="username"
            className={
              errorExistForField('username')
                ? 'form-control is-invalid'
                : 'form-control'
            }
          />
          {errorExistForField('username') && (
            <small className="text-danger">{errorsForField('username')}</small>
          )}
        </div>
      </div>
      <div className="form-group row">
        <label
          htmlFor="name"
          className={
            errorExistForField('website')
              ? 'col-sm-2 col-form-label is-invalid'
              : 'col-sm-2 col-form-label'
          }
        >
          Website
        </label>
        <div className="col-sm-12">
          <Field
            type="textbox"
            name="website"
            className={
              errorExistForField('website')
                ? 'form-control is-invalid'
                : 'form-control'
            }
          />
          {errorExistForField('website') && (
            <small className="text-danger">{errorsForField('website')}</small>
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

const UserEdit = withFormik<Props, UserViewModel>({
  mapPropsToValues: props => {
    let response = new UserViewModel();
    response.setProperties(
      props.model!.bioImgUrl,
      props.model!.birthday,
      props.model!.contentDescription,
      props.model!.email,
      props.model!.fullName,
      props.model!.headerImgUrl,
      props.model!.interest,
      props.model!.locationLocationId,
      props.model!.password,
      props.model!.phoneNumber,
      props.model!.privacy,
      props.model!.userId,
      props.model!.username,
      props.model!.website
    );
    return response;
  },

  // Custom sync validation
  validate: values => {
    let errors: FormikErrors<UserViewModel> = {};

    if (values.email == '') {
      errors.email = 'Required';
    }
    if (values.fullName == '') {
      errors.fullName = 'Required';
    }
    if (values.locationLocationId == 0) {
      errors.locationLocationId = 'Required';
    }
    if (values.password == '') {
      errors.password = 'Required';
    }
    if (values.privacy == '') {
      errors.privacy = 'Required';
    }
    if (values.userId == 0) {
      errors.userId = 'Required';
    }
    if (values.username == '') {
      errors.username = 'Required';
    }

    return errors;
  },
  handleSubmit: (values, actions) => {
    actions.setStatus(undefined);

    let mapper = new UserMapper();

    axios
      .put(
        Constants.ApiEndpoint + ApiRoutes.Users + '/' + values.userId,

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
            Api.UserClientRequestModel
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

  displayName: 'UserEdit',
})(UserEditDisplay);

interface IParams {
  userId: number;
}

interface IMatch {
  params: IParams;
}

interface UserEditComponentProps {
  match: IMatch;
}

interface UserEditComponentState {
  model?: UserViewModel;
  loading: boolean;
  loaded: boolean;
  errorOccurred: boolean;
  errorMessage: string;
}

export default class UserEditComponent extends React.Component<
  UserEditComponentProps,
  UserEditComponentState
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
          ApiRoutes.Users +
          '/' +
          this.props.match.params.userId,
        {
          headers: {
            'Content-Type': 'application/json',
          },
        }
      )
      .then(
        resp => {
          let response = resp.data as Api.UserClientResponseModel;

          console.log(response);

          let mapper = new UserMapper();

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
      return <UserEdit model={this.state.model} />;
    } else {
      return null;
    }
  }
}


/*<Codenesium>
    <Hash>804a5cb290151f4d6d37cff18f27f5f6</Hash>
</Codenesium>*/